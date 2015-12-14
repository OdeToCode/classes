using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Flow.Controllers
{
    public class GuestController : Controller
    {
        [HttpGet]
        public ActionResult Sign()
        {
            return View();  
        }

        [HttpPost]
        public ActionResult Sign(FormCollection c)
        {
            return RedirectToAction("index", "home");
        }
    }
}
