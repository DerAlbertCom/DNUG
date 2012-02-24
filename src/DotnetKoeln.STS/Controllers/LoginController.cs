using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;
using DotnetKoeln.STS.Entities;
using DotnetKoeln.STS.Models;
using DotnetKoeln.STS.Services;

namespace DotnetKoeln.STS.Controllers
{
    public class LoginController : BaseController
    {
        readonly ILoginValidation loginValidation;

        public LoginController(ILoginValidation loginValidation)
        {
            this.loginValidation = loginValidation;
        }

        [HttpGet]
        public ActionResult Index(string returnUrl = null)
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("LogOut");
            return View(new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var webUser = loginValidation.ValidateUser(model.UserName, model.Password);
                if (webUser != null)
                {
                    AuthenticateUser(webUser);

                    if (string.IsNullOrWhiteSpace(returnUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    return Redirect(returnUrl);
                }
            }
            return View(model);
        }

        void AuthenticateUser(WebUser webUser)
        {
            FormsAuthentication.SetAuthCookie(webUser.Username, false);
        }
        
        public ActionResult LogOut()
        {
            return View();
        }

        [HttpPost]
        [ActionName("LogOut")]
        public ActionResult LogOutPost()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}