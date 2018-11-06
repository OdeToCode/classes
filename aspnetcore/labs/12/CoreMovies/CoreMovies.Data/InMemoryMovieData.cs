using CoreMovies.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CoreMovies.Data
{
    public class InMemoryMovieData : IMovieData
    {
        List<Movie> movies;

        public InMemoryMovieData() : this(null)
        {

        }

        public InMemoryMovieData(List<Movie> intialData)
        {
            movies = intialData ?? new List<Movie>()
            {
                new Movie { Id = 1, Name = "Star Wars", Year = 1979 },
                new Movie { Id = 2, Name = "Inception", Year = 2010 },
                new Movie { Id = 3, Name = "Cleopatra", Year = 1963 }
            };
        }

        public Movie Add(Movie newMovie)
        {
            newMovie.Id = movies.Max(m => m.Id) + 1;
            movies.Add(newMovie);
            return newMovie;
        }

        public int Count()
        {
            return movies.Count();
        }

        public void Delete(int id)
        {
            var movie = GetById(id);
            if(movie != null)
            {
                movies.Remove(movie);
            }
        }

        public IEnumerable<Movie> FindByNameMatch(string name)
        {
            return from m in movies
                   where m.Name.StartsWith(name) || name == null
                   orderby m.Year
                   select m;
        }

        public IEnumerable<Movie> GetAll()
        {
            return from m in movies
                   orderby m.Year
                   select m;
        }

        public Movie GetById(int id)
        {
            return movies.SingleOrDefault(m => m.Id == id);
        }

        public Movie Update(Movie updatedMovie)
        {
            var movie = GetById(updatedMovie.Id);
            if(movie != null)
            {
                movie.Name = updatedMovie.Name;
                movie.Year = updatedMovie.Year;
            }
            return movie;
        }

        public int Commit()
        {
            return 0;
        }
    }
}
