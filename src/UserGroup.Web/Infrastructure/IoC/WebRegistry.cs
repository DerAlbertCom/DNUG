using Aperea.Identity;
using StructureMap.Configuration.DSL;
using UserGroup.Web.Security;

namespace UserGroup.Web.Infrastructure.IoC
{
    public class WebRegistry : Registry
    {
        public WebRegistry()
        {
            For<IRelyingPartyConfiguration>().Use<RelyingPartyConfiguration>();
        }
    }
}