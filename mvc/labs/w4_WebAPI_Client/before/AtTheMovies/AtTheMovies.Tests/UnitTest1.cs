using System;
using AtTheMovies.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AtTheMovies.Tests
{
    [TestClass]
    public class HelloController_Tests
    {
        [TestMethod]
        public void Produces_Personalized_Greeting()
        {
            var controller = new HelloController();

            var result = controller.GetMessage("Scott");

            Assert.AreEqual("Hello, Scott!", result);
        }
    }
}
