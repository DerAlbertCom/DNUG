﻿using System.Linq;
using System.Web.Mvc;
using Aperea.Data;
using Aperea.Infrastructure.Mappings;
using UserGroup.Entities;
using UserGroup.Web.Models;

namespace UserGroup.Web.Controllers
{
    public class ShowPageController : Controller
    {
        readonly IRepository<Page> repository;

        public ShowPageController(IRepository<Page> repository)
        {
            this.repository = repository;
        }

        public ActionResult Details(string slug)
        {
            return View(GetPage(slug).MapTo<ShowPageModel>());
        }

        Page GetPage(string slug)
        {
            return repository.Entities.Single(p => p.Slug == slug);
        }
    }
}