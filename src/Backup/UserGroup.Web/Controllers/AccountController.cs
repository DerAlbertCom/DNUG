using System;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.IdentityModel.Web;

namespace UserGroup.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        //
        // GET: /Account/LogOff

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            DeleteSessionTokenCookie();
            return RedirectToAction("Index", "Home");
        }

        static void DeleteSessionTokenCookie()
        {
            var authenticationModule = FederatedAuthentication.SessionAuthenticationModule;
            if (authenticationModule != null)
                authenticationModule.DeleteSessionTokenCookie();
        }
    }
}