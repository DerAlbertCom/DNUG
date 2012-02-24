using System;
using System.Web.Mvc;
using System.Web.Routing;
using Aperea.Infrastructure.Bootstrap;

namespace UserGroup.Web.Initialize
{
    public class InitializeHttpRoutes : BootstrapItem
    {
        public override void Execute()
        {
            RegisterRoutes(RouteTable.Routes);
        }

        static void RegisterRoutes(RouteCollection routes)
        {
        }
    }
}