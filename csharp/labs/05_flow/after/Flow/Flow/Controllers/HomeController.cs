using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Flow.Models;

namespace Flow.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {                        
            return View(new GuestBook().GetGuests());
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
