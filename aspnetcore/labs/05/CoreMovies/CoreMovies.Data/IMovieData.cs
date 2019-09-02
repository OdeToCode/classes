using System;
using System.Collections.Generic;
using CoreMovies.Entities;

namespace CoreMovies.Data
{
    public interface IMovieData
    {
        int Count();
        IEnumerable<Movie> GetAll();
    }
}
