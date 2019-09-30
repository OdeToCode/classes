using Microsoft.AspNetCore.Mvc;
using Movies.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Controllers
{
    // /api/movies/52/actors

    [ApiController]
    [Route("/api/[controller]")]
    public class MoviesController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            var model = FetchMovies();
            var result = new OkObjectResult(model);
            return result;
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get([FromRoute] int id)
        {
            var model = FetchMovies().SingleOrDefault(m => m.Id == id);
            if(model == null)
            {
                return NotFound();
            }
            var result = new OkObjectResult(model);
            return result;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Movie newMovie)
        {
            // save movie

            return Ok();
        }

        private static IEnumerable<Movie> FetchMovies()
        {
            yield return new Movie() { Id = 1, Name = "Star Wars" };
            yield return new Movie() { Id = 2, Name = "Star Trek" };
            yield return new Movie() { Id = 3, Name = "Starship Troopers" };
        }
    }
}
