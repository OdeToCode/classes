using System.Collections.Generic;
using CoreMovies.Entities;
using System.Linq;

namespace CoreMovies.Data
{
    public class InMemoryMovieData : IMovieData
    {
        List<Movie> movies = new List<Movie>()
        {
            new Movie { Id = 1, Name = "Star Wars", Year = 1979 },
            new Movie { Id = 2, Name = "Inception", Year = 2010 },
            new Movie { Id = 3, Name = "Cleopatra", Year = 1963 }
        };


        public int Count()
        {
            return movies.Count();            
        }

        public IEnumerable<Movie> GetAll()
        {
            return 
                from m in movies 
                orderby m.Year descending
                select m;
        }
    }
}
