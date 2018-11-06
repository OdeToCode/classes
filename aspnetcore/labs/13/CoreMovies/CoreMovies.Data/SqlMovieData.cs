using System;
using System.Collections.Generic;
using System.Linq;
using CoreMovies.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreMovies.Data
{
    public class SqlMovieData : IMovieData
    {
        private readonly MovieDbContext movieDb;

        public SqlMovieData(MovieDbContext movieDb)
        {
            this.movieDb = movieDb;
        }

        public Movie Add(Movie newMovie)
        {
            movieDb.Add(newMovie);
            return newMovie;
        }

        public int Commit()
        {
            return movieDb.SaveChanges();
        }

        public int Count()
        {
            return movieDb.Movies.Count();
        }

        public void Delete(int id)
        {
            var movie = GetById(id);
            movieDb.Movies.Remove(movie);        
        }

        public IEnumerable<Movie> FindByNameMatch(string name)
        {
            return from m in movieDb.Movies
                   where String.IsNullOrEmpty(name) || m.Name.StartsWith(name)
                   orderby m.Year
                   select m;
        }

        public IEnumerable<Movie> GetAll()
        {
            return movieDb.Movies;
        }

        public Movie GetById(int id)
        {
            return movieDb.Movies.Find(id);
        }

        public Movie Update(Movie updatedMovie)
        {
            var entry = movieDb.Entry(updatedMovie);
            entry.State = EntityState.Modified;
            return updatedMovie;
        }
    }
}
