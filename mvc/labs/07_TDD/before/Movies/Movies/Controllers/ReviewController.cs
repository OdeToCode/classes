using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movies.Models;

namespace Movies.Controllers
{
    public class ReviewController : Controller
    {
        public ActionResult Edit(int id)
        {
            var ctx = new MovieContext();
            var review =
                ctx.Reviews
                   .Include("Movie")
                   .Where(r => r.ID == id)
                   .First();

            return View(review);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection c)
        {
            var ctx = new MovieContext();
            var review =
                ctx.Reviews
                    .Include("Movie")
                    .Single(r => r.ID == id);

            TryUpdateModel(review);
            if (ModelState.IsValid)
            {
                ctx.SaveChanges();
                return RedirectToAction("Details", "Movie",
                        new { id = review.Movie.ID });
            }

            return View(review);
        }


    }
}
