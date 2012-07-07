using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movies.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {            
            ViewBag.Message = Resources.Global.HomeMessage;

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
