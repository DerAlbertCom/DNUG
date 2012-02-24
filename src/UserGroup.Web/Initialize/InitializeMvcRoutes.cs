using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Aperea.Infrastructure.Bootstrap;

namespace UserGroup.Web.Initialize
{
    public class InitializeMvcRoutes : BootstrapItem
    {
        public override void Execute()
        {
            RegisterRoutes(RouteTable.Routes);
        }

        static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional}
                );
        }
    }
}