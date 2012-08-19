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
        private readonly IMovieData _movieData;

        public ReviewsController()
        {
            _movieData = new MovieData();
        }

        public ReviewsController(IMovieData movieData)
        {
            _movieData = movieData;
        }

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
                var movie = _movieData.Movies.Single(m => m.Id == movieId);
                movie.Reviews.Add(review);
                _movieData.SaveChanges();
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
