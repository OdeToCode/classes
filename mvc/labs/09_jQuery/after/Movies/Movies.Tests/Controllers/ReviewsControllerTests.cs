using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Movies.Controllers;
using Movies.Domain;

namespace Movies.Tests.Controllers
{   
    [TestClass]
    public class ReviewsControllerTests
    {
        private Mock<IMovieData> _mockMovieData;
        private Movie _movie;
        private List<Movie> _movies;
        
        [TestInitialize]
        public void Initialize()
        {
            _mockMovieData = new Mock<IMovieData>();
            _movie = new Movie() { Id = 1, Reviews = new List<Review>() };
            _movies = new List<Movie> { _movie };

            _mockMovieData.Setup(m => m.Movies).Returns(_movies.AsQueryable());
        }

        [TestMethod]
        public void Does_Not_Save_Changes_On_Invalid_Model()
        {                       
            var controller = new ReviewsController(_mockMovieData.Object);
            controller.ModelState.AddModelError("", "Error!");
            
            controller.Create(1, new Review());

            _mockMovieData.Verify(m => m.SaveChanges(), Times.Never());
        }

        [TestMethod]
        public void Save_Changes_On_Valid_Model()
        {
            var controller = new ReviewsController(_mockMovieData.Object);

            controller.Create(1, new Review());

            _mockMovieData.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}
