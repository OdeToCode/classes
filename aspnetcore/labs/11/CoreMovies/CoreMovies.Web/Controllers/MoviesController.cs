using CoreMovies.Data;
using CoreMovies.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CoreMovies.Web.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieData movieData;

        public MoviesController(IMovieData movieData)
        {
            this.movieData = movieData;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Get([FromQuery]string name)
        {
            var result = Enumerable.Empty<Movie>();
            if (string.IsNullOrEmpty(name))
            {
                result = movieData.GetAll();
            }
            else
            {
                result = movieData.FindByNameMatch(name);
            }
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Movie> GetById(int id)
        {
            var result = movieData.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public ActionResult<Movie> Post([FromBody] Movie newMovie)
        {
            movieData.Add(newMovie);
            movieData.Commit();
            return CreatedAtAction("Get", new { id = newMovie.Id }, newMovie);
        }

        [HttpPut("{id:int}")]
        public ActionResult<Movie> Put(int id, [FromBody]Movie updatedMovie)
        {
            if (id != updatedMovie.Id)
            {
                ModelState.AddModelError("id", "Route id does not match entity id");
                return BadRequest();
            }

            var movie = movieData.Update(updatedMovie);
            movieData.Commit();
            return Ok(movie);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            movieData.Delete(id);
            movieData.Commit();
            return NoContent();
        }
    }
}
