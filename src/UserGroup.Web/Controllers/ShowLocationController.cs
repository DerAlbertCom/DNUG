using System.Linq;
using System.Web.Mvc;
using Aperea.Infrastructure.Mappings;
using UserGroup.Data;
using UserGroup.Entities;
using UserGroup.Web.Models;

namespace UserGroup.Web.Controllers
{
    public class ShowLocationController : BaseController
    {
        readonly IRepository<Location> _repository;

        public ShowLocationController(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public ActionResult Details(string slug)
        {
            return View(_repository.Entities.Single(l => l.Slug == slug).MapTo<ShowLocationModel>());
        }
    }
}