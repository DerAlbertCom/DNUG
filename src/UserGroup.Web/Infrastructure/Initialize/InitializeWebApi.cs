using System.Web.Http;
using Aperea.Infrastructure.Bootstrap;
using StructureMap;
using UserGroup.Web.Infrastructure.IoC;

namespace UserGroup.Web.Infrastructure.Initialize
{
    public class InitializeWebApi : BootstrapItem
    {
        readonly IContainer container;

        public InitializeWebApi(IContainer container)
        {
            this.container = container;
        }

        public override void Execute()
        {
            Configure(GlobalConfiguration.Configuration);
        }

        void Configure(HttpConfiguration config)
        {
            config.DependencyResolver = new StructureMapWebApiDependencyResolver(container);
        }
    }
}