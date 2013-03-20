using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AtTheMovies.Domain;
using AtTheMovies.Infrastructure;

namespace AtTheMovies.Controllers
{
    public class MovieController : ApiController
    {
        private MovieData _db;

        public MovieController()
        {
            _db = new MovieData();
        }

        public IEnumerable<Movie> Get()
        {
            return _db.Movies.Take(25);
        }

        public HttpResponseMessage Get(int id)
        {
            Movie movie = _db.Movies.Find(id);
            if (movie == null)
            {
                return Request.CreateErrorResponse(
                    HttpStatusCode.NotFound, "Movie not found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, movie);
        }

        public HttpResponseMessage Put(int id, Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            try
            {
                _db.Entry(movie).State = EntityState.Modified;
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public HttpResponseMessage Delete(int id)
        {
            Movie movie = _db.Movies.Find(id);
            if (movie == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            try
            {            
                _db.Movies.Remove(movie);
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, movie);
        }


        public HttpResponseMessage Post(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _db.Movies.Add(movie);
                _db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, movie);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = movie.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
        }
    }
}
