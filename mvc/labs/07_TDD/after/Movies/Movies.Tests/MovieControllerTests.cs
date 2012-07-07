using System;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Movies.Controllers;
using Movies.Models;
using Movies.Tests.Fakes;
using MvcContrib.Pagination;

namespace Movies.Tests
{
    public class MovieControllerTests
    {
        public MovieControllerTests()
        {
            _dbContext = new FakeDbContext();
            _controller = new MovieController(_dbContext);
        }

        protected FakeDbContext _dbContext;
        protected MovieController _controller;
    }

    [TestClass]
    public class When_displaying_the_list_of_movies
         : MovieControllerTests
    {
        [TestMethod]
        public void should_render_the_default_view()
        {
            var result = _controller.Index(null);

            Assert.IsTrue(result.ViewName == "");
        }

        [TestMethod]
        public void should_return_first_page_as_default()
        {
            var result = _controller.Index(null);
            var model = result.ViewData.Model as IPagination<Movie>;

            Assert.IsTrue(model.PageNumber == 1);
        }

        [TestMethod]
        public void should_return_second_page_for_page_value_2()
        {
            var result = _controller.Index(2);
            var model = result.ViewData.Model as IPagination<Movie>;

            Assert.IsTrue(model.PageNumber == 2);
        }
       
        [TestMethod]
        public void should_order_movies_by_release_date_descending()
        {
            // this movie should appear first
            var latestMovie = new Movie
            {
                ID = 0,
                Title = ".NET 8.0",
                ReleaseDate = new DateTime(2020, 1, 1)

            };
            this._dbContext.Movies.AddObject(latestMovie);

            var result = _controller.Index(1);
            var model = result.ViewData.Model as IPagination<Movie>;

            Assert.IsTrue(model.First() == latestMovie);
        }
    }

    [TestClass]
    public class When_displaying_a_movie_detail
               : MovieControllerTests
    {
        [TestMethod]
        public void should_return_the_correct_movie()
        {
            // this movie should appear first
            var theMovie = new Movie { ID = 10399 };
            this._dbContext.Movies.AddObject(theMovie);

            var result = _controller.Details(10399);
            var model = result.ViewData.Model as Movie;

            Assert.IsTrue(model == theMovie);
        }
    }

    [TestClass]
    public class When_displaying_a_quick_movie_detail
               : MovieControllerTests
    {
        [TestMethod]
        public void should_calculate_the_average_rating()
        {
            var theMovie = new Movie
            {
                ID = 10399,
                Reviews = new EntityCollection<Review>
                          {
                              new Review {Rating = 2},
                              new Review {Rating = 10}
                          }
            };

            this._dbContext.Movies.AddObject(theMovie);

            var result = _controller.QuickDetails(10399);
            var model = result.Data;
            var value = model.GetType()
                             .GetProperty("AverageReview")
                             .GetValue(model, null);

            Assert.AreEqual((double)value, 6.0, 0.1);
        }
    }

}
