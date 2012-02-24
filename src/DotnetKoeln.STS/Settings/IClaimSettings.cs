using System;
using System.Collections.Generic;
using DotnetKoeln.STS.Security;
using Microsoft.IdentityModel.Protocols.WSIdentity;

namespace DotnetKoeln.STS.Settings
{
    public interface IClaimSettings
    {
        IEnumerable<DisplayClaim> Claims { get; }
    }

    public class ClaimSettings : IClaimSettings
    {
        public IEnumerable<DisplayClaim> Claims
        {
            get
            {
                yield return new DisplayClaim(ClaimTypes.EMail, "EMail", "E-Mail des Benutzers", "", true);
                yield return new DisplayClaim(ClaimTypes.Role, "Role", "Rolle des Benutzers", "", true);
                yield return new DisplayClaim(ClaimTypes.Name, "Name", "Name des Benutzers", "", false);
            }
        }
    }
}