using System.Linq;
using System.Web.Mvc;
using Aperea.Infrastructure.Mappings;
using UserGroup.Data;
using UserGroup.Entities;
using UserGroup.Web.Models;

namespace UserGroup.Web.Controllers
{
    public class ShowPageController : Controller
    {
        readonly IRepository<Page> _repository;

        public ShowPageController(IRepository<Page> repository)
        {
            _repository = repository;
        }

        public ActionResult Details(string slug)
        {
            return View(GetPage(slug).MapTo<ShowPageModel>());
        }

        Page GetPage(string slug)
        {
            return _repository.Entities.Single(p => p.Slug == slug);
        }
    }
}