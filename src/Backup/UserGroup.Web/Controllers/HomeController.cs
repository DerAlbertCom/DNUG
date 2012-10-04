using System;
using System.Linq;
using System.Web.Mvc;
using Aperea.ActionFilter;
using Aperea.Mappings;
using UserGroup.Data;
using UserGroup.Entities;
using UserGroup.Web.Models;

namespace UserGroup.Web.Controllers
{
    public class HomeController : BaseController
    {
        readonly IRepository<Meeting> meetingRepository;
        readonly IRepository<Page> pageRepository;

        public HomeController(IRepository<Meeting> meetingRepository, IRepository<Page> pageRepository)
        {
            this.meetingRepository = meetingRepository;
            this.pageRepository = pageRepository;
        }

        public ActionResult Index()
        {
            var model = new ShowHomeIndexModel
                            {
                                NextMeeting = GetNextMeeting().MapTo<MeetingLineModel>(),
                                Page = GetHomepage().MapTo<ShowPageModel>()
                            };


            return View(model);
        }

        Page GetHomepage()
        {
            return pageRepository.Entities.Single(p => p.Slug == "homepage");
        }

        Meeting GetNextMeeting()
        {
            var currentDate = DateTime.Now.ToUniversalTime().Date.AddDays(-2);

            var query = from m in meetingRepository.Entities
                        where m.StartTime > currentDate
                        orderby m.StartTime
                        select m;
            return query.Take(1).SingleOrDefault();
        }
    }
}