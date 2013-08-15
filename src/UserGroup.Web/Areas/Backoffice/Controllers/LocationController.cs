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
    public class LocationController : BackofficeController
    {
        readonly IRepository<Location> _repository;

        public LocationController(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            return View(_repository.Entities.ToList<EditLocationModel>());
        }

        //
        // GET: /Backoffice/Location/Details/5

        public ActionResult Details(int id)
        {
            var model = GetLocation(id).MapTo<EditLocationModel>();
            return View(model);
        }

        //
        // GET: /Backoffice/Location/Create

        public ActionResult Create()
        {
            return View(new EditLocationModel());
        }

        //
        // POST: /Backoffice/Location/Create

        [HttpPost]
        public ActionResult Create(EditLocationModel model)
        {
            if (ModelState.IsValid)
            {
                var location = new Location();
                model.MapTo(location);
                _repository.Add(location);
                _repository.SaveAllChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        //
        // GET: /Backoffice/Location/Edit/5

        public ActionResult Edit(int id)
        {
            return View(GetLocation(id).MapTo<EditLocationModel>());
        }

        Location GetLocation(int id)
        {
            return _repository.Entities
                .Single(m => m.Id == id);
        }

        //
        // POST: /Backoffice/Location/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, EditLocationModel model)
        {
            if (ModelState.IsValid)
            {
                var location = GetLocation(id);
                model.MapTo(location);
                _repository.SaveAllChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        //
        // GET: /Backoffice/Location/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Backoffice/Location/Delete/5

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