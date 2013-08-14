using System.Web.Http;
using System.Web.Routing;
using Aperea;
using Aperea.Infrastructure.Bootstrap;
using Aperea.Infrastructure.IoC;

namespace UserGroup.Web.Infrastructure.Initialize
{
    [UsedImplicitly]
    public class InitializeWebApi : BootstrapItem
    {
        public override void Execute()
        {
            Configure(GlobalConfiguration.Configuration);
            RegisterRoutes(RouteTable.Routes);
        }

        private void RegisterRoutes(RouteCollection routes)
        {
            routes.MapHttpRoute(
                name: "Backoffice API With Action",
                routeTemplate: "api/v1/backoffice/{controller}/{id}/{action}"
                );

            routes.MapHttpRoute(
                name: "Backoffice API",
                routeTemplate: "api/v1/backoffice/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
                );
        }

        private void Configure(HttpConfiguration config)
        {
            config.SetDependencyResolver();
        }
    }
}