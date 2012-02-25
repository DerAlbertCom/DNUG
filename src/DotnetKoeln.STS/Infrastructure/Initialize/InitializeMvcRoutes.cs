using System;
using System.Web.Mvc;
using System.Web.Routing;
using Aperea.Infrastructure.Bootstrap;

namespace DotnetKoeln.STS.Infrastructure.Initialize
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
                name: "PassiveTokenIssuer",
                url: "issuer/passive/{wa}",
                defaults: new {controller = "Token", action = "Index", wa = UrlParameter.Optional}
                );

            routes.MapRoute(
                name: "FederationMedatadata",
                url: "federationmetadata/2007-06/federationmetadata.xml",
                defaults: new {controller = "Metadata", action = "Federation"}
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional}
                );
        }
    }
}