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

        #region Non test methods
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

        private Model.VolunteerProject GetAProject() 
        {
            return GetAProject("Project title", new Model.Location("street", "City"),
                DateTime.Parse("1996-6-6"), new Model.Topic() { Church = true }, null, "A project", false); 
        }


        private Model.VolunteerProject GetAProject(string title, Model.Location location, 
            DateTime time, Model.Topic topics, Model.Organization owner, string description, bool signup)
        {
            return new Model.VolunteerProject(title, location, time, topics, owner, description, signup);
        }

        private Model.Admin GetAAdmin()
        {
            return GetAAdmin("Username", "Name", new Model.Location("streeet", "city"), "EMAIL@host.dk");
        }
        private Model.Admin GetAAdmin(string username)
        {
            return GetAAdmin(username, "Name", new Model.Location("streeet", "city"), "EMAIL@host.dk");
        }

        private Model.Admin GetAAdmin(string username, string name, Model.Location location, string email)
        {
            return new Model.Admin(username, name, location, email);
        }

        private Model.Volunteer GetAVolunteer()
        {
            return GetAVolunteer("Username", "Name", new Model.Location("streeet", "city"), "EMAIL@host.dk");
        }
        private Model.Volunteer GetAVolunteer(string username)
        {
            return GetAVolunteer(username, "Name", new Model.Location("streeet", "city"), "EMAIL@host.dk");
        }

        private Model.Volunteer GetAVolunteer(string username, string name, Model.Location location, string email)
        {
            return new Model.Volunteer(username, name, location, email);
        }
        #endregion

        #region Projects View
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
            Model.VolunteerProject project = GetAProject();
            repository.CreateProject(project);
            HomeController controller = GetHomeController(repository, new MocWebSecurity(false));

            // Act
            ViewResult result = controller.Projects() as ViewResult;

            // Assert
            var model = (IEnumerable<Model.VolunteerProject>)result.ViewData.Model;
            CollectionAssert.Contains(model.ToList(),project);
        }
        #endregion

        #region Index view
        [TestMethod]
        public void Home_Index_Not_Logged_In_No_Projects()
        {
            // Arrange
            HomeController controller = GetHomeController(new MocModelRepository(), new MocWebSecurity(false));

            // Act
            ViewResult result = controller.Index() as ViewResult;
            IEnumerable<Model.VolunteerProject> resList = (IEnumerable<Model.VolunteerProject>)result.ViewBag.Suggestions;
            // Assert
            Assert.AreEqual(0, resList.Count());
        }

        [TestMethod]
        public void Home_Index_Not_Logged_In_With_Projects()
        {
            // Arrange
            MocModelRepository repository = new MocModelRepository();
            Model.VolunteerProject project = GetAProject();
            repository.CreateProject(project);
            HomeController controller = GetHomeController(repository, new MocWebSecurity(false));
            
            // Act
            ViewResult result = controller.Index() as ViewResult;
            var suggestionList = (IEnumerable<Model.VolunteerProject>)result.ViewBag.Suggestions;

            // Assert
            CollectionAssert.Contains(suggestionList.ToList(), project);
        }

        [TestMethod]
        public void Home_Index_loggedIn_Admin_Redirects_to_Admin_index()
        {
            // Arrange
            MocWebSecurity auth = new MocWebSecurity(true);
            auth.Username = "SomeAdmin";
            MocModelRepository repository = new MocModelRepository();
            Model.Admin admin = new Model.Admin("SomeAdmin");
            repository.CreateAdmin(admin);
            HomeController controller = GetHomeController(repository, auth);

            // Act
            var result = controller.Index() as RedirectToRouteResult;

            // Assert
            if (result == null)
            {
                Assert.Fail("Should have redirected");
            }
            Assert.AreEqual(result.RouteValues["Controller"], "admin");
            Assert.AreEqual(result.RouteValues["Action"], "index");
                 
        }

        [TestMethod]
        public void Home_Index_loggedIn_Volunteer_redirects_to_Volunteer_Index()
        {
            //Arrange 
            MocWebSecurity auth = new MocWebSecurity(true);
            auth.Username = "SomeVolunteer";
            MocModelRepository repository = new MocModelRepository();
            Model.Volunteer volunteer = new Model.Volunteer("SomeVolunteer");
            repository.CreateVolunteer(volunteer);
            HomeController controller = GetHomeController(repository, auth);

            //Act
            var result = controller.Index() as RedirectToRouteResult;

            //Assert
            if (result == null)
            {
                Assert.Fail("Should have redirected");
            }
            Assert.AreEqual(result.RouteValues["Controller"], "volunteer");
            Assert.AreEqual(result.RouteValues["Action"], "index");
        }
        #endregion

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
