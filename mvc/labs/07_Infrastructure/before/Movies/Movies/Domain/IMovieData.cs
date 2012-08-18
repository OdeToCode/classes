using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Domain
{
    public interface IMovieData
    {
        IQueryable<Review> Reviews { get; }
        IQueryable<Movie> Movies { get; }

        void SaveChanges();
        void AddOrAttach<T>(T entity) where T : class;
    }
}
