using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movies.Domain;
using Movies.Infrastructure;

namespace Movies.Controllers
{
    public class ReviewsController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(int movieId, Review review)
        {
            if(ModelState.IsValid)
            {
                var db = new MovieData();
                var movie = db.Movies.Find(movieId);
                movie.Reviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("Details", "Movies", new {id = movieId});
            }
            return View(review);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new MovieData();
            var review = db.Reviews.Find(id);
            return View(review);
        }

        [HttpPost]
        public ActionResult Edit(int movieId, Review review)
        {
            var db = new MovieData();
            if(ModelState.IsValid)
            {
                db.Entry(review).State = EntityState.Modified;
                db.SaveChanges();
                
                return RedirectToAction("Details", "Movies", new {id = movieId});
            }
            return View(review);
        }
    }
}
