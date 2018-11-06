using System;
using System.Collections.Generic;
using System.Text;
using CoreMovies.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreMovies.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}
