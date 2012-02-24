using System;
using System.Collections.Generic;
using Microsoft.IdentityModel.Protocols.WSFederation.Metadata;
using Microsoft.IdentityModel.Protocols.WSIdentity;
using Microsoft.IdentityModel.SecurityTokenService;
using System.IdentityModel.Tokens;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;
using System.Xml;

namespace DotnetKoeln.STS.Services
{
	public class MetadataGenerator
	{
		// Methods
		public MetadataGenerator(IMetadataContactSettings contactSettings, IEndpointSettings endpointSettings, IIssuerSettings issuerSettings, IClaimSettings claimSettings)
		{
		    this.contact = contactSettings.Contact;
			this.organization = contactSettings.Organization;
            this.issuerUri = issuerSettings.IssuerUri;
            this.serviceName = issuerSettings.ServiceName;
            this.serviceCert = issuerSettings.ServiceCert;
            this.sign = issuerSettings.Sign;
            this.activeEndpoints = endpointSettings.ActiveEndpoints;
			this.passiveEndpoints = endpointSettings.PassiveEndpoints;
			this.claims = claimSettings.Claims;
		}


		private string CreateFederationMetadataAsString(EntityDescriptor entity)
		{
			MetadataSerializer serializer = new MetadataSerializer();
			MemoryStream stream = new MemoryStream();
			serializer.WriteMetadata(stream, entity);
			stream.Seek(0, SeekOrigin.Begin);
			return Encoding.UTF8.GetString(stream.ToArray());
		}

		public void GenerateAsFile(string fileName)
		{
			string contents = this.GenerateCore();
			File.WriteAllText(fileName, contents);
		}

		public string GenerateAsString()
		{
			return this.GenerateCore();
		}

		private string GenerateCore()
		{
			SecurityTokenServiceDescriptor tokenServiceDescriptor = this.GetTokenServiceDescriptor();
			EntityId entityId = new EntityId(this.issuerUri);
			EntityDescriptor entity = new EntityDescriptor(entityId);
			if (this.sign)
			{
				entity.SigningCredentials = new X509SigningCredentials(this.serviceCert);
			}

			if (this.contact != null)
			{
				entity.Contacts.Add(this.contact);
				entity.Organization = this.organization;
			}

			entity.RoleDescriptors.Add(tokenServiceDescriptor);
			return this.CreateFederationMetadataAsString(entity);
		}

		private KeyDescriptor GetSingingKeyDescriptor(X509Certificate2 cert)
		{
			X509RawDataKeyIdentifierClause clause = (new X509SecurityToken(cert)).CreateKeyIdentifierClause<X509RawDataKeyIdentifierClause>();
			KeyDescriptor descriptor = new KeyDescriptor(new SecurityKeyIdentifier(new SecurityKeyIdentifierClause[] {clause}));
			descriptor.Use = KeyType.Signing;
			return descriptor;
		}

		private SecurityTokenServiceDescriptor GetTokenServiceDescriptor()
		{
			Action<EndpointAddress> action = null;
			SecurityTokenServiceDescriptor tokenService = new SecurityTokenServiceDescriptor();
			tokenService.ServiceDescription = this.serviceName;
			tokenService.Keys.Add(this.GetSingingKeyDescriptor(this.serviceCert));
			tokenService.ProtocolsSupported.Add(new Uri("http://docs.oasis-open.org/wsfed/federation/200706"));
			tokenService.TokenTypesOffered.Add(new Uri("urn:oasis:names:tc:SAML:1.0:assertion"));
			foreach (var claim in claims)
			{
				tokenService.ClaimTypesOffered.Add(claim);
			}

			foreach (string uri in this.activeEndpoints)
			{
				var set = new MetadataSet();
				var metadata = new MetadataReference(new EndpointAddress(string.Format("{0}/mex", uri)), AddressingVersion.WSAddressing10);
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
			bool addPassiveEndpointsAsActive = tokenService.SecurityTokenServiceEndpoints.Count == 0;
			foreach (var item in passiveEndpoints)
			{
				var endpoint = new EndpointAddress(item);
				tokenService.PassiveRequestorEndpoints.Add(endpoint);
				if (addPassiveEndpointsAsActive)
				{
					tokenService.SecurityTokenServiceEndpoints.Add(endpoint);
				}
			}
			return tokenService;
		}


		// Fields
		private readonly ICollection<string> activeEndpoints;
        private readonly ICollection<string> passiveEndpoints;
        private readonly List<DisplayClaim> claims;
		private readonly ContactPerson contact;
		private readonly string issuerUri;
		private readonly Organization organization;
		private readonly X509Certificate2 serviceCert;
		private readonly string serviceName;
		private readonly bool sign;
	}
}