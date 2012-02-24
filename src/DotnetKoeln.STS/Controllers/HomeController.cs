using System.Web.Mvc;

namespace DotnetKoeln.STS.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}