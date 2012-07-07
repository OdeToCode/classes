using System;
using System.Data.Objects;
using Movies.Models;

namespace Movies.Tests.Fakes
{
    public class FakeDbContext : IDbContext
    {
        public FakeDbContext()
        {
            Movies = new FakeObjectSet<Movie>(FakeData.GenerateMovieData());
        }

        IObjectSet<Movie> IDbContext.Movies
        {
            get { return Movies; }
        }

        IObjectSet<Review> IDbContext.Reviews
        {
            get { return Reviews; }
        }

        public FakeObjectSet<Movie> Movies
        {
            get;
            set;
        }

        public FakeObjectSet<Review> Reviews
        {
            get;
            set;
        }
    }
}