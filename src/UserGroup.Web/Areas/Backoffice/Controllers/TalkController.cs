using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Aperea.Data;
using Aperea.Infrastructure.Mappings;
using UserGroup.Entities;
using UserGroup.Web.Areas.Backoffice.Models;
using UserGroup.Web.Extensions;

namespace UserGroup.Web.Areas.Backoffice.Controllers
{
    public class TalkController : BackofficeController
    {
        readonly IRepository<Talk> repository;
        readonly IRepository<Speaker> speakerRepository;

        public TalkController(IRepository<Talk> repository, IRepository<Speaker> speakerRepository)
        {
            this.repository = repository;
            this.speakerRepository = speakerRepository;
        }

        public ActionResult Index()
        {
            return View(repository.Entities.Include(t=>t.Meeting).OrderByDescending(t=>t.Meeting.StartTime).ToList<DisplayTalkLineModel>());
        }

        //
        // GET: /Backoffice/Talk/Details/5

        public ActionResult Details(int id)
        {
            var model = GetTalk(id).MapTo<DisplayTalkModel>();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddSpeaker(int id, int speakerId)
        {
            var talk = (from t in repository.Include("Speakers")
                       where t.Id == id
                       select t).Single();
            if (talk.Speakers.All(s => s.Id != speakerId))
            {
                var speaker = speakerRepository.Entities.Single(s => s.Id == speakerId);
                talk.Speakers.Add(speaker);
                repository.SaveChanges();
            }
            
            return RedirectToAction("Details",new {id});
        }
        //
        // GET: /Backoffice/Talk/Create

        public ActionResult Create()
        {
            var model = new Talk().MapTo<EditTalkModel>();
            return View(model);
        }

        //
        // POST: /Backoffice/Talk/Create

        [HttpPost]
        public ActionResult Create(EditTalkModel model)
        {
            if (ModelState.IsValid)
            {
                var talk = new Talk();
                model.MapTo(talk);
                repository.Add(talk);
                repository.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        //
        // GET: /Backoffice/Talk/Edit/5

        public ActionResult Edit(int id)
        {
            return View(GetTalk(id).MapTo<EditTalkModel>());
        }

        Talk GetTalk(int id)
        {
            return repository.Include("Meeting","Speakers")
                .Single(m => m.Id == id);
        }

        //
        // POST: /Backoffice/Talk/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, EditTalkModel model)
        {
            if (ModelState.IsValid)
            {
                var talk = GetTalk(id);
                model.MapTo(talk);
                repository.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        //
        // GET: /Backoffice/Talk/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Backoffice/Talk/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}