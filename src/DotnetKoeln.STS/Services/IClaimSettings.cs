using System.Collections.Generic;
using Microsoft.IdentityModel.Protocols.WSIdentity;

namespace DotnetKoeln.STS.Services
{
    public interface IClaimSettings
    {
        List<DisplayClaim> Claims { get; }
    }
}