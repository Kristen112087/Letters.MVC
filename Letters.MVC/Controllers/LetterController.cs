using Letters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Letters.MVC.Controllers
{
    public class LetterController : Controller
    {
        // GET: Note
        public ActionResult Index()
        {
            var model = new LetterListItem[0];
            return View();
        }
    }
}