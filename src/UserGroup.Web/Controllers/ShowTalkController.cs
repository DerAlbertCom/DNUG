using System.Web.Mvc;

namespace UserGroup.Web.Controllers
{
    public class ShowTalkController : BaseController
    {
        public ActionResult Details(string slug)
        {
            return View();
        }
    }
}