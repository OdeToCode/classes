using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Movies.Domain;

namespace Movies.Infrastructure
{
    public class MovieData : DbContext, IMovieData
    {
        public MovieData() : base("name=DefaultConnection")
        {
            
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }

        IQueryable<Review> IMovieData.Reviews
        {
            get { return Reviews; }
        }

        IQueryable<Movie> IMovieData.Movies
        {
            get { return Movies; }
        }

        void IMovieData.SaveChanges()
        {
            SaveChanges();
        }

        void IMovieData.AddOrAttach<T>(T entity)
        {
            var entry = Entry(entity);
            entry.State = entry.Property<int>("Id").CurrentValue == 0 ?
                            EntityState.Added : 
                            EntityState.Modified;
        }
    }
}