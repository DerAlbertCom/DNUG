using System.Web.Mvc;

namespace UserGroup.Web.Areas.Backoffice.Controllers
{
    public class AdminController : BackofficeController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}