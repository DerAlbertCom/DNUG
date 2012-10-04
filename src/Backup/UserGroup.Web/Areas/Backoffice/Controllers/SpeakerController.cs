using System;
using System.Linq;
using System.Web.Mvc;
using Aperea.Mappings;
using UserGroup.Data;
using UserGroup.Entities;
using UserGroup.Web.Areas.Backoffice.Models;
using UserGroup.Web.Extensions;
using UserGroup.Web.Models;

namespace UserGroup.Web.Areas.Backoffice.Controllers
{
    public class SpeakerController : BackofficeController
    {
        readonly IRepository<Speaker> repository;

        public SpeakerController(IRepository<Speaker> repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            return View(repository.Entities.ToList<EditSpeakerModel>());
        }

        //
        // GET: /Backoffice/Speaker/Details/5

        public ActionResult Details(int id)
        {
            EditSpeakerModel model = GetSpeaker(id).MapTo<EditSpeakerModel>();
            return View(model);
        }

        //
        // GET: /Backoffice/Speaker/Create

        public ActionResult Create()
        {
            return View(new EditSpeakerModel());
        }

        //
        // POST: /Backoffice/Speaker/Create

        [HttpPost]
        public ActionResult Create(EditSpeakerModel model)
        {
            if (ModelState.IsValid)
            {
                var Speaker = new Speaker();
                model.MapTo(Speaker);
                repository.Add(Speaker);
                repository.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        //
        // GET: /Backoffice/Speaker/Edit/5

        public ActionResult Edit(int id)
        {
            return View(GetSpeaker(id).MapTo<EditSpeakerModel>());
        }

        Speaker GetSpeaker(int id)
        {
            return repository.Entities
                .Single(m => m.Id == id);
        }

        //
        // POST: /Backoffice/Speaker/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, EditSpeakerModel model)
        {
            if (ModelState.IsValid)
            {
                var Speaker = GetSpeaker(id);
                model.MapTo(Speaker);
                repository.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        //
        // GET: /Backoffice/Speaker/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Backoffice/Speaker/Delete/5

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