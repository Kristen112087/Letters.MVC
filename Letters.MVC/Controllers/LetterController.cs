using Letters.Models;
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
            var model = new LetterListItem[1];
            return View(model);
        }

        //GET: Note
        public ActionResult Create()
        {
            return View();
        }
    }
}