using System.Data.Entity;
using AtTheMovies.Domain;

namespace AtTheMovies.Infrastructure
{
    public class MovieData : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }

}