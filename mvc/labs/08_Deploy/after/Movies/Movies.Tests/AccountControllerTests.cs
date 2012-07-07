using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Movies.Controllers;
using Movies.Models;

namespace Movies.Tests
{
    [TestClass]
    public class AccountControllerTests
    {
        [TestMethod]
        public void SignOnInvokedWhenUserIsValidated()
        {
            var authService = new Mock<IFormsAuthenticationService>();
            var membershipService = new Mock<IMembershipService>();
            var httpContext = new Mock<HttpContextBase>();
            var urlHelper = new UrlHelper(
                new RequestContext(httpContext.Object, new RouteData()));

            var controller = new AccountController(authService.Object,
                                                   membershipService.Object);
            controller.Url = urlHelper;

            membershipService.Setup(s => s.ValidateUser("test", "test")).Returns(true);            

            var logOnModel = new LogOnModel
            {
                UserName = "test",
                Password = "test",
                RememberMe = true
            };

            controller.LogOn(logOnModel, "");

            authService.Verify(s => s.SignIn("test", true));
        }


        [TestMethod]
        public void SignOnNotInvokedForInvalidUser()
        {
            var authService = new Mock<IFormsAuthenticationService>();
            var membershipService = new Mock<IMembershipService>();
            var httpContext = new Mock<HttpContextBase>();
            var urlHelper = new UrlHelper(
                   new RequestContext(httpContext.Object, new RouteData()));

            membershipService.Setup(s => s.ValidateUser(
                It.IsAny<string>(), It.IsAny<string>()))
                .Returns(false);

            var controller = new AccountController(authService.Object,
                                membershipService.Object);

            var logOnModel = new LogOnModel
            {
                UserName = "testy",
                Password = "test",
                RememberMe = true
            };

            controller.LogOn(logOnModel, "");

            authService.Verify(s => s.SignIn(It.IsAny<string>(), true), Times.Never());
        }

    }    
}
