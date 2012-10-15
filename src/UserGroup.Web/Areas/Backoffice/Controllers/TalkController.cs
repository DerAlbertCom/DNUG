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
    public class TalkController : BackofficeController
    {
        readonly IRepository<Talk> _repository;

        public TalkController(IRepository<Talk> repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            return View(_repository.Entities.ToList<EditTalkModel>());
        }

        //
        // GET: /Backoffice/Talk/Details/5

        public ActionResult Details(int id)
        {
            var model = GetTalk(id).MapTo<EditTalkModel>();
            return View(model);
        }

        //
        // GET: /Backoffice/Talk/Create

        public ActionResult Create()
        {
            return View(new EditTalkModel());
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
                _repository.Add(talk);
                _repository.SaveChanges();
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
            return _repository.Include(t => t.Meeting)
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
                _repository.SaveChanges();
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