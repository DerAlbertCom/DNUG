using System;
using System.Web.Mvc;
using System.Web.Routing;
using Aperea.Infrastructure.Bootstrap;

namespace DotnetKoeln.STS.Initialize
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
                defaults: new {controller = "Token", action = "Index", id = UrlParameter.Optional}
                );
        }
    }
}