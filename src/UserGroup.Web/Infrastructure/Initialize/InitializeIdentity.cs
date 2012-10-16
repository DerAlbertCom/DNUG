using System.Web.Helpers;
using Aperea.Infrastructure.Bootstrap;

namespace UserGroup.Web.Infrastructure.Initialize
{
    public class InitializeIdentity : BootstrapItem
    {
        public override void Execute()
        {
            AntiForgeryConfig.UniqueClaimTypeIdentifier = Microsoft.IdentityModel.Claims.ClaimTypes.Name;
        }
    }
}