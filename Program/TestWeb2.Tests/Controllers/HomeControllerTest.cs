using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestWeb2;
using TestWeb2.Controllers;
using TestWeb2.Tests.Models;
using System.Web.Routing;
using System.Web;
using System.Security.Principal;

namespace TestWeb2.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {

        private static HomeController GetHomeController(Model.IModelRepository repository, TestWeb2.Models.ISecurityWrap security)
        {
            HomeController controller = new HomeController(repository, security);

            controller.ControllerContext = new ControllerContext()
            {
                Controller = controller,
                RequestContext = new RequestContext(new MockHttpContext(), new RouteData())
            };
            return controller;
        }


        private class MockHttpContext : HttpContextBase
        {
            private readonly IPrincipal _user = new GenericPrincipal(
                     new GenericIdentity("someUser"), null /* roles */);
            
            public override IPrincipal User
            {
                get
                {
                    return _user;
                }
                set
                {
                    base.User = value;
                }
            }
        }

        [TestMethod]
        public void Home_Projects_With_No_Projects()
        {
            // Arrange
            HomeController controller = GetHomeController(new MocModelRepository(), new MocWebSecurity(false));

            // Act
            ViewResult result = controller.Projects() as ViewResult;

            // Assert
            var model = (IEnumerable<Model.VolunteerProject>)result.ViewData.Model;
            CollectionAssert.AreEqual(new List<Model.VolunteerProject>(), model.ToList());
        }

        [TestMethod]
        public void Home_Projects_With_Projects()
        {
            // Arrange
            MocModelRepository repository = new MocModelRepository();
            Model.VolunteerProject project = new Model.VolunteerProject("Fisk", new Model.Location("somewhere", "sometowen"), DateTime.Parse("1999-12-19"), new Model.Topic(), null, "Hello", false);
            repository.CreateProject(project);
            HomeController controller = GetHomeController(repository, new MocWebSecurity(false));

            // Act
            ViewResult result = controller.Projects() as ViewResult;

            // Assert
            var model = (IEnumerable<Model.VolunteerProject>)result.ViewData.Model;
            CollectionAssert.Contains(model.ToList(),project);
        }

        [TestMethod]
        public void Index_Not_Logged_In_No_Projects()
        {
            // Arrange
            HomeController controller = GetHomeController(new MocModelRepository(), new MocWebSecurity(false));

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual(0, result.ViewBag.Count());
        }

        [TestMethod]
        public void Index_Not_Logged_In_With_Projects()
        {
            // Arrange
            MocModelRepository repository = new MocModelRepository();
            Model.VolunteerProject project = new Model.VolunteerProject("Fisk", new Model.Location("somewhere", "sometowen"), DateTime.Parse("1999-12-19"), new Model.Topic(), null, "Hello", false);
            repository.CreateProject(project);
            HomeController controller = GetHomeController(repository, new MocWebSecurity(false));
            
            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual(0, result.ViewBag.Suggestion.Count());
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
