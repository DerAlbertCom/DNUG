using System.Web.Mvc;
using DotnetKoeln.STS.Models;

namespace DotnetKoeln.STS.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View(new LoginViewModel());
        }
    }
}