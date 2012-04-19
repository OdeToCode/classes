using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cars.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            string message = String.Format("Hello, from {0}!",
             Environment.OSVersion.VersionString);

            ViewBag.Message = message;

            return View();
        }
    }
}
