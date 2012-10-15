using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Aperea.Identity.Settings;
using Microsoft.IdentityModel.Claims;
using Microsoft.IdentityModel.Configuration;
using Microsoft.IdentityModel.Protocols.WSIdentity;
using UserGroup.Web.Services;

namespace UserGroup.Web.Security
{
    public class RelyingPartyConfiguration : Aperea.Identity.IRelyingPartyConfiguration
    {
        readonly IActionUrlBuilder _urlBuilder;
        readonly IEncryptionSettings _encryptionSettings;
        readonly ISigningSettings _signingSettings;

        public RelyingPartyConfiguration(IActionUrlBuilder urlBuilder, IEncryptionSettings encryptionSettings,
                                         ISigningSettings signingSettings)
        {
            _urlBuilder = urlBuilder;
            _encryptionSettings = encryptionSettings;
            _signingSettings = signingSettings;
        }

        public string IssuerUri
        {
            get { return _urlBuilder.GetActionUrl("Index", "Home"); }
        }

        public X509Certificate2 EncryptionCertificate
        {
            get { return _encryptionSettings.Certificate; }
        }

        public bool Encrypt
        {
            get { return _encryptionSettings.Encrypt; }
        }

        public bool Sign
        {
            get { return _signingSettings.Sign; }
        }

        public X509Certificate2 SigningCertificate
        {
            get { return _signingSettings.Certificate; }
        }

        public IEnumerable<string> GetPassiveRequestorEndpoints()
        {
            yield return _urlBuilder.GetActionUrl("Index", "Home");
        }

        public IEnumerable<DisplayClaim> GetClaimTypsRequested()
        {
            yield return new DisplayClaim(ClaimTypes.Name, "Name", "Name des Benutzers", "", false);
            yield return new DisplayClaim(ClaimTypes.Email, "EMail", "E-Mail des Benutzers", "", true);
        }

        public IEnumerable<string> GetSecurityTokenServiceEndpoints()
        {
            var section = MicrosoftIdentityModelSection.Current;
            if (section == null)
            {
                throw new ConfigurationErrorsException(
                    "missing <microsoft.identityModel/> section in the configuration file");
            }
            return from ServiceElement serviceElement in section.ServiceElements
                   select serviceElement.FederatedAuthentication
                   into authenticationElement
                   where authenticationElement != null && authenticationElement.WSFederation != null
                   select authenticationElement.WSFederation.Issuer;
        }
    }
}