using System.Web.Http;
using Aperea.Infrastructure.Bootstrap;
using Aperea.Infrastructure.IoC;

namespace UserGroup.Web.Infrastructure.Initialize
{
    public class InitializeWebApi : BootstrapItem
    {

        public override void Execute()
        {
            Configure(GlobalConfiguration.Configuration);
        }

        void Configure(HttpConfiguration config)
        {
            config.SetDependencyResolver();
        }
    }
}