using System;
using System.Collections.Generic;
using Movies.Models;

namespace Movies.Tests.Fakes
{
    public static class FakeData
    {
        public static IEnumerable<Movie> GenerateMovieData()
        {
            for(int i = 0; i < 1000; i++)
            {
                yield return new Movie {ID = i, Title = i.ToString(), ReleaseDate = DateTime.Now.AddDays(i)};
            }
        }
    }
}