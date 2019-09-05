using CoreMovies.Data;
using CoreMovies.Entities;
using CoreMovies.Web.Pages.Movies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        
        [Fact]
        public void RejectsBadModel()
        {
            var db = CreateDb();

            var page = new EditModel(new SqlMovieData(db));
            page.ModelState.AddModelError("Name", "Name is empty");
            page.Movie = new Movie();

            var result = page.OnPost(3) as PageResult;
            Assert.NotNull(result);
        }

        [Fact]
        public void AddsMovie()
        {
            var db = CreateDb();

            var page = new EditModel(new SqlMovieData(db));
            page.Movie = new Movie() { Id = 0, Name = "TestMovie1", Year = 2000 };

            var result = page.OnPost(0) as RedirectToPageResult;
            
        }
    }
}
