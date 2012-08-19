using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movies.Infrastructure;
using System.Data.Entity;

namespace Movies.Controllers
{
    public class MoviesController : Controller
    {
        //
        // GET: /Movie/
        [OutputCache(CacheProfile = "Regular")]        
        public ActionResult Index()
        {
            var db = new MovieData();
            var movies =
                from m in db.Movies
                orderby m.Year descending
                select m;

            return View(movies.Take(25));
        }

        public ActionResult Details(int id)
        {
            var db = new MovieData();
            var movie = db.Movies
                          .Include(m => m.Reviews)
                          .First(m => m.Id == id);
            return View(movie);
        }

    }
}
