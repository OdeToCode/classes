using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Simple
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    [Route("api/[controller]")]
    public class MoviesController 
    {
        public IEnumerable<Movie> Get()
        {
            return new Movie[]
            {
                new Movie { Id = 1, Name = "One" },
                new Movie { Id = 2, Name = "Two" },
                new Movie { Id = 3, Name = "Three" }
            };
        }
    }
}
