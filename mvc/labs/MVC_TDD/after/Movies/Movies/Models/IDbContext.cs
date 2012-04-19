using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Web;

namespace Movies.Models
{
    public interface IDbContext
    {
        IObjectSet<Movie> Movies { get; }
        IObjectSet<Review> Reviews { get; }
    }

}