using CoreMovies.Entities;
using System.Collections.Generic;

namespace CoreMovies.Data
{
    public interface IMovieData
    {
        int Count();
        IEnumerable<Movie> GetAll();
        Movie GetById(int id);
        IEnumerable<Movie> FindByNameMatch(string name);
        Movie Add(Movie newMovie);
        Movie Update(Movie updatedMovie);
        void Delete(int id);
        int Commit();
    }
}
