using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Functional.Tests
{
    [TestClass]
    public class MovieConstructionTests
    {
        [TestMethod]
        public void Default_release_date_is_current_date()
        {
            var expectedDate = new DateTime(2002, 6, 11);
            SystemTime.Now = () => expectedDate;

            var movie = new Movie();

            Assert.AreEqual(expectedDate, movie.ReleaseDate);
        }
    }
}
