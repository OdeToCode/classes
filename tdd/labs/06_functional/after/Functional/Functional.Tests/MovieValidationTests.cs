using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Functional.Tests
{
    [TestClass]
    public class MovieValidationTests
    {
        [TestMethod]
        public void MovieWithNoTitleIsAnError()
        {
            Movie movie = new Movie()
                              {
                                  Title = "",
                                  Duration = 60,
                                  ReleaseDate = DateTime.Now
                              };
            
            var errors = movie.Validate();
            Assert.AreEqual(1, errors.Count());
        }

        [TestMethod]
        public void MovieWithTooShortDurationIsAnError()
        {
            Movie movie = new Movie()
            {
                Title = "Hairspray",
                Duration = 0,
                ReleaseDate = DateTime.Now
            };

            var errors = movie.Validate();
            Assert.AreEqual(1, errors.Count());
        }

        [TestMethod]
        public void MovieWithBadReleaseDateIsError()
        {
            Movie movie = new Movie()
                              {
                                  Title = "Hairspray",
                                  Duration = 60,
                                  ReleaseDate = new DateTime(1859, 1, 1)
                                };

            var errors = movie.Validate();
            Assert.AreEqual(1, errors.Count());
        }
    }
}