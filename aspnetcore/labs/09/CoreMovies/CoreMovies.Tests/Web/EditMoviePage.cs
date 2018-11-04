using System;
using System.Collections.Generic;
using System.Text;
using CoreMovies.Data;
using CoreMovies.Entities;
using CoreMovies.Web.Pages.Movies;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CoreMovies.Tests.Web
{
    public class EditMoviePage
    {
        MovieDbContext CreateDb()
        {
            var options = new DbContextOptionsBuilder<MovieDbContext>()
                            .UseInMemoryDatabase(nameof(EditMoviePage))
                            .Options;
            return new MovieDbContext(options);
        }

        [Fact]
        public void FindsMovieToEdit()
        {
            var db = CreateDb();
            var movie = new Movie { Id = 99, Name = "Test 1", Year = 2019 };            
            db.Movies.Add(movie);

            var page = new EditModel(new SqlMovieData(db));
            page.OnGet(99);

            Assert.Equal(movie.Id, page.Movie.Id);
        }       
    }
}
