using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Web;

namespace Movies.Models
{
    public partial class MovieContext : IDbContext
    {
        IObjectSet<Movie> IDbContext.Movies
        {
            get { return Movies; }
        }

        IObjectSet<Review> IDbContext.Reviews
        {
            get { return Reviews; }
        }
    }

}