using System;
using System.Data.Entity.Validation;
using System.Web.Mvc;
using UserGroup.Web.ActionFilter;

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

        public void ConvertEntityValidationException(DbEntityValidationException exception)
        {
            foreach (var error in exception.EntityValidationErrors)
            {
                foreach (var validationError in error.ValidationErrors)
                {
                    ModelState.AddModelError("", validationError.PropertyName + @" : " + validationError.ErrorMessage);
                }
            }
        }
    }
}