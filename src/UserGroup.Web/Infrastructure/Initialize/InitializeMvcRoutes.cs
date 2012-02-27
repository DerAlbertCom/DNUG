using System;
using System.Web.Mvc;
using System.Web.Routing;
using Aperea.Infrastructure.Bootstrap;
using UserGroup.Web.Controllers;

namespace UserGroup.Web.Infrastructure.Initialize
{
    public class InitializeMvcRoutes : BootstrapItem
    {
        public override void Execute()
        {
            RegisterRoutes(RouteTable.Routes);
        }

        static string NameOf<T>() where T : Controller
        {
            var name = typeof (T).Name;
            return name.Substring(0, name.LastIndexOf("Controller", System.StringComparison.Ordinal));
        }

        static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("images/{*pathInfo}");

            routes.MapRoute(
                name: "FederationMedatadata",
                url: "federationmetadata/2007-06/federationmetadata.xml",
                defaults: new {controller = NameOf<MetadataController>(), action = "Federation"}
                );


            routes.MapRoute(
                name: "ShowSpeakers",
                url: "speakers",
                defaults: new {controller = NameOf<ShowSpeakerController>(), action = "Index"}
                );

            routes.MapRoute(
                name: "ShowSpeaker",
                url: "speaker/{slug}",
                defaults: new {controller = NameOf<ShowSpeakerController>(), action = "Details"}
                );

            routes.MapRoute(
                name: "ShowMeetings",
                url: "meetings",
                defaults: new {controller = NameOf<ShowMeetingController>(), action = "Index"}
                );

            routes.MapRoute(
                name: "ShowMeetingTalk",
                url: "meeting/{slug}/{talkSlug}",
                defaults: new {controller = NameOf<ShowMeetingController>(), action = "TalkDetails"}
                );

            routes.MapRoute(
                name: "ShowMeeting",
                url: "meeting/{slug}",
                defaults: new {controller = NameOf<ShowMeetingController>(), action = "Details"}
                );

            routes.MapRoute(
                name: "ShowLocation",
                url: "location/{slug}",
                defaults: new {controller = NameOf<ShowLocationController>(), action = "Details"}
                );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new {controller = NameOf<HomeController>(), action = "Index", id = UrlParameter.Optional}
                );
        }
    }
}