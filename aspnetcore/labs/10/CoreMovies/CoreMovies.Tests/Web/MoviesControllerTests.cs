using CoreMovies.Data;
using CoreMovies.Entities;
using CoreMovies.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;

namespace CoreMovies.Tests.Web
{
    public class MoviesControllerTests
    {
        [Fact]
        public void Returns404WhenNotExists()
        {
            var movies = new List<Movie>();
            var data = new InMemoryMovieData(movies);
            var controller = new MoviesController(data);

            var result = controller.GetById(5);
            var notFound = result.Result as NotFoundResult;
            Assert.NotNull(notFound);
        }
    }
}
