using System.Linq;
using System.Web.Mvc;
using Aperea.Data;
using Aperea.Infrastructure.Mappings;
using UserGroup.Entities;
using UserGroup.Web.Models;

namespace UserGroup.Web.Controllers
{
    public class ShowSpeakerController : BaseController
    {
        readonly IRepository<Speaker> repository;

        public ShowSpeakerController(IRepository<Speaker> repository)
        {
            this.repository = repository;
        }

        public ActionResult Details(string slug)
        {
            return View(repository.Entities.Single(l => l.Slug == slug).MapTo<ShowSpeakerModel>());
        }
    }
}