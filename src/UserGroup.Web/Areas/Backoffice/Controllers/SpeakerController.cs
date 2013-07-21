using System;
using System.Linq;
using System.Web.Mvc;
using Aperea.Data;
using Aperea.Infrastructure.Mappings;
using UserGroup.Entities;
using UserGroup.Web.Areas.BackOffice.Models;
using UserGroup.Web.Extensions;

namespace UserGroup.Web.Areas.BackOffice.Controllers
{
    public class SpeakerController : BackofficeController
    {
        readonly IRepository<Speaker> _repository;

        public SpeakerController(IRepository<Speaker> repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            return View(_repository.Entities.ToList<EditSpeakerModel>());
        }

        //
        // GET: /Backoffice/Speaker/Details/5

        public ActionResult Details(int id)
        {
            var model = GetSpeaker(id).MapTo<EditSpeakerModel>();
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
                var speaker = new Speaker();
                model.MapTo(speaker);
                _repository.Add(speaker);
                _repository.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        //
        // GET: /Backoffice/Speaker/Edit/5

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(GetSpeaker(id).MapTo<EditSpeakerModel>());
        }

        Speaker GetSpeaker(int id)
        {
            return _repository.Entities
                .Single(m => m.Id == id);
        }

        //
        // POST: /Backoffice/Speaker/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, EditSpeakerModel model)
        {
            if (ModelState.IsValid)
            {
                var speaker = GetSpeaker(id);
                model.MapTo(speaker);
                _repository.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        //
        // GET: /Backoffice/Speaker/Delete/5

        [HttpGet]
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