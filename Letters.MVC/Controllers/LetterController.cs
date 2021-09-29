using Letters.Models;
using Letters.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Letters.MVC.Controllers
{
    [Authorize]
    public class LetterController : Controller
    {
        // GET: Note
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LetterService(userId);
            var model = service.GetLetters();

            return View(model);
        }

        //GET: Note
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LetterCreate model)
        {
            if(!ModelState.IsValid)
            {
            return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LetterService(userId);

            service.CreateLetter(model);
            return RedirectToAction("Index");
        }
    }
}