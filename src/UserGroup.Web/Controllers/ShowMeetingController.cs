using System;
using System.Linq;
using System.Web.Mvc;
using Aperea.Infrastructure.Mappings;
using UserGroup.Data;
using UserGroup.Entities;
using UserGroup.Web.Extensions;
using UserGroup.Web.Models;

namespace UserGroup.Web.Controllers
{
    public class ShowMeetingController : BaseController
    {
        readonly IRepository<Meeting> _repository;

        public ShowMeetingController(IRepository<Meeting> repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {

            var model = _repository.Entities.OrderByDescending(e => e.StartTime).ToList<MeetingLineModel>();
            return View(model);
        }

        public ActionResult Details(string slug)
        {
            var model = GetMeeting(slug).MapTo<ShowMeetingModel>();
            return View(model);
        }

        Meeting GetMeeting(string slug)
        {
            return _repository.Include("Location","Talks").Single(m=>m.Slug==slug);
        }
    }
}