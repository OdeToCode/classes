using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Controllers.Models;

namespace Controllers.Controllers
{
    public class GuestEntryController : Controller
    {
        //
        // GET: /GuestEntry/
        [ActionName("List")]    
        public ViewResult Index()
        {
            var book = new GuestBook();
            return View("Index", book.Entries);
        }

        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        [HandleError]
        public ActionResult Create(GuestEntry entry)
        {
            var book = new GuestBook();
            book.Add(entry);

            return RedirectToAction("List");
        }
    }
}
