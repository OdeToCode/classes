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
    }
}
