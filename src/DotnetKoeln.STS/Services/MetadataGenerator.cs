using System;
using System.Collections.Generic;
using System.IO;
using System.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;
using System.Xml;
using DotnetKoeln.STS.Settings;
using Microsoft.IdentityModel.Protocols.WSFederation.Metadata;
using Microsoft.IdentityModel.Protocols.WSIdentity;
using Microsoft.IdentityModel.SecurityTokenService;

namespace DotnetKoeln.STS.Services
{
    public class MetadataGenerator : IMetadataGenerator
    {
        // Fields
        readonly IEnumerable<string> activeEndpoints;
        readonly IEnumerable<DisplayClaim> claims;
        readonly ContactPerson contact;
        readonly string issuerUri;
        readonly Organization organization;
        readonly IEnumerable<string> passiveEndpoints;
        readonly X509Certificate2 serviceCert;
        readonly string serviceName;
        readonly bool sign;

        public MetadataGenerator(IMetadataContactSettings contactSettings, IEndpointSettings endpointSettings,
                                 IIssuerSettings issuerSettings, IClaimSettings claimSettings)
        {
            contact = contactSettings.Contact;
            organization = contactSettings.Organization;
            issuerUri = issuerSettings.IssuerUri;
            serviceName = issuerSettings.ServiceName;
            serviceCert = issuerSettings.ServiceCert;
            sign = issuerSettings.Sign;
            activeEndpoints = endpointSettings.ActiveEndpoints;
            passiveEndpoints = endpointSettings.PassiveEndpoints;
            claims = claimSettings.Claims;
        }

        public string GenerateAsString()
        {
            return GenerateCore();
        }

        string CreateFederationMetadataAsString(EntityDescriptor entity)
        {
            var serializer = new MetadataSerializer();
            var stream = new MemoryStream();
            serializer.WriteMetadata(stream, entity);
            stream.Seek(0, SeekOrigin.Begin);
            return Encoding.UTF8.GetString(stream.ToArray());
        }

        string GenerateCore()
        {
            var entity = new EntityDescriptor(new EntityId(issuerUri));
            if (sign)
            {
                entity.SigningCredentials = new X509SigningCredentials(serviceCert);
            }

            if (contact != null)
            {
                entity.Contacts.Add(contact);
                entity.Organization = organization;
            }

            entity.RoleDescriptors.Add(GetTokenServiceDescriptor());
            return CreateFederationMetadataAsString(entity);
        }

        KeyDescriptor GetSingingKeyDescriptor(X509Certificate2 cert)
        {
            var clause = (new X509SecurityToken(cert)).CreateKeyIdentifierClause<X509RawDataKeyIdentifierClause>();
            var descriptor = new KeyDescriptor(new SecurityKeyIdentifier(new SecurityKeyIdentifierClause[] {clause}));
            descriptor.Use = KeyType.Signing;
            return descriptor;
        }

        SecurityTokenServiceDescriptor GetTokenServiceDescriptor()
        {
            var tokenService = new SecurityTokenServiceDescriptor {ServiceDescription = serviceName};
            tokenService.Keys.Add(GetSingingKeyDescriptor(serviceCert));
            tokenService.ProtocolsSupported.Add(new Uri("http://docs.oasis-open.org/wsfed/federation/200706"));
            tokenService.TokenTypesOffered.Add(new Uri("urn:oasis:names:tc:SAML:1.0:assertion"));
            foreach (DisplayClaim claim in claims)
            {
                tokenService.ClaimTypesOffered.Add(claim);
            }

            AddActiceEndpoints(tokenService);

            bool addPassiveEndpointsAsActive = tokenService.SecurityTokenServiceEndpoints.Count == 0;
            AddPassiveEndpoints(tokenService, addPassiveEndpointsAsActive);
            return tokenService;
        }

        void AddPassiveEndpoints(SecurityTokenServiceDescriptor tokenService, bool addPassiveEndpointsAsActive)
        {
            foreach (string item in passiveEndpoints)
            {
                var endpoint = new EndpointAddress(item);
                tokenService.PassiveRequestorEndpoints.Add(endpoint);
                if (addPassiveEndpointsAsActive)
                {
                    tokenService.SecurityTokenServiceEndpoints.Add(endpoint);
                }
            }
        }

        void AddActiceEndpoints(SecurityTokenServiceDescriptor tokenService)
        {
            foreach (string uri in activeEndpoints)
            {
                var set = new MetadataSet();
                var metadata = new MetadataReference(new EndpointAddress(string.Format("{0}/mex", uri)),
                                                     AddressingVersion.WSAddressing10);
                var item = new MetadataSection(MetadataSection.MetadataExchangeDialect, null, metadata);
                set.MetadataSections.Add(item);
                var sb = new StringBuilder();
                var w = new StringWriter(sb);
                var writer = new XmlTextWriter(w);
                set.WriteTo(writer);
                writer.Flush();
                w.Flush();
                var input = new StringReader(sb.ToString());
                var reader = new XmlTextReader(input);
                XmlDictionaryReader metadataReader = XmlDictionaryReader.CreateDictionaryReader(reader);
                var address = new EndpointAddress(new Uri(uri), null, null, metadataReader, null);
                tokenService.SecurityTokenServiceEndpoints.Add(address);
            }
        }
    }
}