using System.Web.Mvc;

namespace UserGroup.Web.Areas.Backoffice
{
    public class BackofficeAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Backoffice";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Backoffice_default",
                "backoffice/{controller}/{action}/{id}",
                new { controller="Admin", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
