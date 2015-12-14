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
            var model = new GuestBook().Entries;
            return View("Index", model);
        }

        public ViewResult Create()
        {
            return View();
        }

        [HandleError]
        [HttpPost]      
        public ActionResult Create(GuestEntry entry)
        {
            if (entry.Name == "Fido")
            {
                throw new InvalidOperationException("No dogs allowed");
            }

            var book = new GuestBook();
            book.Add(entry);

            return RedirectToAction("List");
        }
    }
}
