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
    public class PageController : BackofficeController
    {
        readonly IRepository<Page> _repository;

        public PageController(IRepository<Page> repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            return View(_repository.Entities.ToList<EditPageModel>());
        }

        //
        // GET: /Backoffice/Page/Details/5

        public ActionResult Details(int id)
        {
            var model = GetPage(id).MapTo<EditPageModel>();
            return View(model);
        }

        //
        // GET: /Backoffice/Page/Create

        public ActionResult Create()
        {
            return View(new EditPageModel());
        }

        //
        // POST: /Backoffice/Page/Create

        [HttpPost]
        public ActionResult Create(EditPageModel model)
        {
            if (ModelState.IsValid)
            {
                var page = new Page();
                model.MapTo(page);
                _repository.Add(page);
                _repository.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        //
        // GET: /Backoffice/Page/Edit/5

        public ActionResult Edit(int id)
        {
            return View(GetPage(id).MapTo<EditPageModel>());
        }

        Page GetPage(int id)
        {
            return _repository.Entities
                .Single(m => m.Id == id);
        }

        //
        // POST: /Backoffice/Page/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, EditPageModel model)
        {
            if (ModelState.IsValid)
            {
                var page = GetPage(id);
                model.MapTo(page);
                _repository.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        //
        // GET: /Backoffice/Page/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Backoffice/Page/Delete/5

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