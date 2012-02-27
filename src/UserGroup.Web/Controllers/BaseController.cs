using System;
using System.Web.Mvc;
using JetBrains.Annotations;
using UserGroup.Web.Infrastructure.Mvc;

namespace UserGroup.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected override IActionInvoker CreateActionInvoker()
        {
            return new DatabaseContextActionInvoker();
        }

        protected ActionResult RedirectToHomepage()
        {
            return Redirect("~/");
        }

        protected void SetBackLink([AspMvcAction] string action, [AspMvcController] string controller,
                                   object routeValues = null)
        {
            ViewBag.BackLinkUrl = Url.Action(action, controller, routeValues, null);
        }

        protected void SetReferrerAsBacklink()
        {
            Uri urlReferrer = HttpContext.Request.UrlReferrer;
            if (urlReferrer != null)
                ViewBag.BackLinkUrl = urlReferrer.AbsolutePath;
        }
    }
}