using CoreMovies.Data;
using CoreMovies.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CoreMovies.Web.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private readonly IMovieData movieData;

        public MoviesController(IMovieData movieData)
        {
            this.movieData = movieData;
        }

        public ActionResult<IEnumerable<Movie>> Get()
        {
            return new ObjectResult(movieData.GetAll());
        }

        [Route("{id:int}")]
        public ActionResult<Movie> GetById(int id)
        {
            var result = movieData.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return new ObjectResult(result);
        }

        [Route("{name}")]
        public ActionResult<IEnumerable<Movie>> GetByName(string name)
        {
            var result = movieData.FindByNameMatch(name);
            return new ObjectResult(result);
        }
    }
}
