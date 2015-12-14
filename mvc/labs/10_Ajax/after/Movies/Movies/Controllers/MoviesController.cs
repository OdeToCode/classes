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
        public ActionResult Index(string searchTerm)
        {
            var db = new MovieData();
            var movies =
                from m in db.Movies
                where searchTerm == null || m.Title.Contains(searchTerm)
                orderby m.Year descending
                select m;
            
            if(Request.IsAjaxRequest())
            {
                return PartialView("_MovieTable", movies.Take(25));
            }

            return View(movies.Take(25));
        }


        public ActionResult SearchAutoComplete(string term)
        {
            var db = new MovieData();
            var movies =
                db.Movies.Where(m => term == null || m.Title.Contains(term))
                    .Take(10)
                    .Select(m => new {label = m.Title});

            return Json(movies, JsonRequestBehavior.AllowGet);
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
