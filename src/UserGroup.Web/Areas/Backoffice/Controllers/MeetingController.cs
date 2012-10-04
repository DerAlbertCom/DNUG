using System;
using System.Linq;
using System.Web.Mvc;
using Aperea.Infrastructure.Mappings;
using UserGroup.Data;
using UserGroup.Entities;
using UserGroup.Web.Areas.Backoffice.Models;
using UserGroup.Web.Extensions;

namespace UserGroup.Web.Areas.Backoffice.Controllers
{
    public class MeetingController : BackofficeController
    {
        readonly IRepository<Meeting> repository;

        public MeetingController(IRepository<Meeting> repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            return View(repository.Entities.ToList<EditMeetingModel>());
        }

        //
        // GET: /Backoffice/Meeting/Details/5

        public ActionResult Details(int id)
        {
            EditMeetingModel model = GetMeeting(id).MapTo<EditMeetingModel>();
            return View(model);
        }

        //
        // GET: /Backoffice/Meeting/Create

        public ActionResult Create()
        {
            return View(new EditMeetingModel());
        }

        //
        // POST: /Backoffice/Meeting/Create

        [HttpPost]
        public ActionResult Create(EditMeetingModel model)
        {
            if (ModelState.IsValid)
            {
                var meeting = new Meeting();
                model.MapTo(meeting);
                repository.Add(meeting);
                repository.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        //
        // GET: /Backoffice/Meeting/Edit/5

        public ActionResult Edit(int id)
        {
            return View(GetMeeting(id).MapTo<EditMeetingModel>());
        }

        Meeting GetMeeting(int id)
        {
            return repository
                .Include(m => m.Location)
                .Single(m => m.Id == id);
        }

        //
        // POST: /Backoffice/Meeting/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, EditMeetingModel model)
        {
            if (ModelState.IsValid)
            {
                var meeting = GetMeeting(id);
                model.MapTo(meeting);
                repository.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        //
        // GET: /Backoffice/Meeting/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Backoffice/Meeting/Delete/5

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