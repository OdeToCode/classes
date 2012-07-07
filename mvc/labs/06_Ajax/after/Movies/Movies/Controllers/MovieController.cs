using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movies.Models;

namespace Movies.Controllers
{
    public class MovieController : Controller
    {

        public ActionResult QuickDetails(int id)
        {
            var ctx = new MovieContext();
            var detail =
                ctx.Movies
                   .Where(m => m.ID == id)
                   .Select(m => new
                   {
                       AverageReview = m.Reviews.Average(r => r.Rating),
                       TotalReviews = m.Reviews.Count
                   })
                   .Single();

            return Json(detail, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Index()
        {
            var ctx = new MovieContext();
            var movies = ctx.Movies
                            .OrderByDescending(m => m.ReleaseDate)
                            .Take(25);
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var ctx = new MovieContext();
            var movie = ctx.Movies
                           .Include("Reviews")
                           .Where(m => m.ID == id)
                           .First();
            return View(movie);
        }


    }
}
