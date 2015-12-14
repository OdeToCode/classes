using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Flow.Models;

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
            Guest newGuest = new Guest();
            TryUpdateModel(newGuest);

            if (ModelState.IsValid)
            {
                GuestBook book = new GuestBook();
                try
                {
                    book.AddGuest(newGuest);
                }
                catch(ArgumentException e)
                {
                    ModelState.AddModelError("", e.Message);
                    return View();
                }
                return RedirectToAction("index", "home");
            }
            return View();

        }
    }
}
