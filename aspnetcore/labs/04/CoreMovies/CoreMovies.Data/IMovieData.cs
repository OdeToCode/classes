using CoreMovies.Entities;
using System.Collections.Generic;

namespace CoreMovies.Data
{
    public interface IMovieData
    {
        int Count();
        IEnumerable<Movie> GetAll();
    }
}
