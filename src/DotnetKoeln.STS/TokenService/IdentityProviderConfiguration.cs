using System.Collections.Generic;
using Aperea.Identity;
using DotnetKoeln.STS.Services;
using Microsoft.IdentityModel.Claims;
using Microsoft.IdentityModel.Protocols.WSIdentity;

namespace DotnetKoeln.STS.TokenService
{
    public class IdentityProviderConfiguration : IIdentityProviderConfiguration
    {
        readonly IActionUrlBuilder urlBuilder;

        public IdentityProviderConfiguration(IActionUrlBuilder urlBuilder)
        {
            this.urlBuilder = urlBuilder;
        }

        public string IssuerUri
        {
            get { return urlBuilder.GetActionUrl("Index", "Token"); }
        }

        public string ServiceName
        {
            get { return "dotnet-koelnbonn.de/sts/"; }
        }

        public IEnumerable<string> ActiveEndpoints
        {
            get { yield break; }
        }

        public IEnumerable<string> PassiveEndpoints
        {
            get { yield return urlBuilder.GetActionUrl("Index", "Token"); }
        }

        public IEnumerable<DisplayClaim> Claims
        {
            get
            {
                yield return new DisplayClaim(ClaimTypes.Email, "EMail", "E-Mail des Benutzers", "", true);
                yield return new DisplayClaim(ClaimTypes.Role, "Role", "Rolle des Benutzers", "", true);
                yield return new DisplayClaim(ClaimTypes.Name, "Name", "Name des Benutzers", "", false);
            }
        }
    }
}