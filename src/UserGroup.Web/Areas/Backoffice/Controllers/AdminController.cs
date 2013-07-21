using System.Web.Mvc;

namespace UserGroup.Web.Areas.BackOffice.Controllers
{
    public class AdminController : BackofficeController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}