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
using Model;

namespace TestWeb2.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {

        #region Non test methods
        private static HomeController GetHomeController(IModelRepository repository, TestWeb2.Models.ISecurityWrap security)
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

        private VolunteerProject GetAProject() 
        {
            return GetAProject("Project title",  "A project"); 
        }

        private VolunteerProject GetAProject(string title, string description) 
        {
            return GetAProject(title, new Location("street", "City"),
                DateTime.Parse("1996-6-6"), new Topic() { Church = true }, null, description, false);
        }

        private VolunteerProject GetAProject(string title, Location location, 
            DateTime time, Topic topics, Organization owner, string description, bool signup)
        {
            return new VolunteerProject(title, location, time, topics, owner, description, signup);
        }

        private Admin GetAAdmin()
        {
            return GetAAdmin("Username");
        }
        private Admin GetAAdmin(string username)
        {
            return GetAAdmin(username, "Name", new Location("streeet", "city"), "EMAIL@host.dk");
        }

        private Admin GetAAdmin(string username, string name, Location location, string email)
        {
            return new Admin(username, name, location, email);
        }

        private Volunteer GetAVolunteer()
        {
            return GetAVolunteer("Username");
        }
        private Volunteer GetAVolunteer(string username)
        {
            return GetAVolunteer(username, "Name", new Location("streeet", "city"), "EMAIL@host.dk");
        }

        private Volunteer GetAVolunteer(string username, string name, Location location, string email)
        {
            return new Volunteer(username, name, location, email);
        }

        private Organization GetAOrganization()
        {
            return GetAOrganization("Some organization", "some@email.dk");
        }

        private Organization GetAOrganization(string name, string email)
        {
            return GetAOrganization(name, DateTime.Parse("1996-04-02"),
                new Location("street", "chitty"), email);
        }


        private Organization GetAOrganization(string name, DateTime creation, Location location, string email) 
        {
            return new Organization() { Name = name, Creation = creation, Email = email, Location = location };
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
            var model = (IEnumerable<VolunteerProject>)result.ViewData.Model;
            CollectionAssert.AreEqual(new List<VolunteerProject>(), model.ToList());
        }

        [TestMethod]
        public void Home_Projects_With_Projects()
        {
            // Arrange
            MocModelRepository repository = new MocModelRepository();
            VolunteerProject project = GetAProject("Some Project", "Testing testing");
            VolunteerProject project2 = GetAProject("Another Project", "Just a test");
            repository.CreateProject(project);
            repository.CreateProject(project2);
            HomeController controller = GetHomeController(repository, new MocWebSecurity(false));

            // Act
            ViewResult result = controller.Projects() as ViewResult;

            // Assert
            var model = (IEnumerable<VolunteerProject>)result.ViewData.Model;
            CollectionAssert.Contains(model.ToList(),project);
            CollectionAssert.Contains(model.ToList(), project2);
        }
        #endregion

        #region Index view
        [TestMethod]
        public void Home_Index_Not_Logged_In_displays_No_Projects()
        {
            // Arrange
            HomeController controller = GetHomeController(new MocModelRepository(), new MocWebSecurity(false));

            // Act
            ViewResult result = controller.Index() as ViewResult;
            IEnumerable<VolunteerProject> resList = (IEnumerable<VolunteerProject>)result.ViewBag.Suggestions;
            // Assert
            Assert.AreEqual(0, resList.Count());
        }

        [TestMethod]
        public void Home_Index_Not_Logged_In_With_Projects_displays()
        {
            // Arrange
            MocModelRepository repository = new MocModelRepository();
            VolunteerProject project = GetAProject();
            repository.CreateProject(project);
            HomeController controller = GetHomeController(repository, new MocWebSecurity(false));
            
            // Act
            ViewResult result = controller.Index() as ViewResult;
            var suggestionList = (IEnumerable<VolunteerProject>)result.ViewBag.Suggestions;

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
            Admin admin = new Admin("SomeAdmin");
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
            Volunteer volunteer = new Volunteer("SomeVolunteer");
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

        #region Project View
        [TestMethod]
        public void Home_Project_Finds_all_Project_data()
        {
            //Arrange
            VolunteerProject project = GetAProject("The Project", "Should have a lot of stuff");
            Organization organization = GetAOrganization("Fisher", "shop@scam.com");
            project.Owner = organization;
            project.Id = 1;
            MocModelRepository repository = new MocModelRepository();
            repository.CreateOrganization(organization);
            repository.CreateProject(project);
            HomeController controller = GetHomeController(repository, new MocWebSecurity(false));

            //Act
            ViewResult result = controller.Project(1) as ViewResult;

            //Assert
            var model = (VolunteerProject)result.ViewData.Model;
            Assert.AreEqual(project, model);//Uses reference equals beware!
        }

        [TestMethod]
        public void HomeProject_Returns_404_if_id_not_found()
        {
            //Arrange
            HomeController controller = GetHomeController(new MocModelRepository(), new MocWebSecurity(false));

            //Act
            var result = (HttpNotFoundResult)controller.Project(1);

            //Assert
            Assert.AreEqual(new HttpNotFoundResult().StatusCode, result.StatusCode);

        }
        #endregion

        #region Organization View
        [TestMethod]
        public void Home_Organization_Finds_all_Organization_Data()
        {
            //Arrange
            VolunteerProject project1 = GetAProject("Project one of SuperOrg", "Fishing");
            VolunteerProject project2 = GetAProject("Project two if Super rg", "cooking");
            Organization organization = GetAOrganization("SuperOrg", "orgsaregreat@mail.com");
            project1.Owner = organization;
            project2.Owner = organization;
            organization.Id = 1;

            MocModelRepository repository = new MocModelRepository();
            repository.CreateOrganization(organization);
            repository.CreateProject(project1);
            repository.CreateProject(project2);

            HomeController controller = GetHomeController(repository, new MocWebSecurity(false));

            //Act
            var result = controller.Organization(organization.Id) as ViewResult;

            //Assert
            var model = (Organization)result.ViewData.Model;
            Assert.AreEqual(organization,model);

        }

        [TestMethod]
        public void Home_Organization_returns_404_if_id_not_found()
        {
            //Arrange
            HomeController controller = GetHomeController(new MocModelRepository(), new MocWebSecurity(false));

            //Act
            var result = (HttpNotFoundResult)controller.Organization(666);

            //Assert
            Assert.AreEqual(new HttpNotFoundResult().StatusCode, result.StatusCode);

        }

        #endregion

        #region Organizations View
        [TestMethod]
        public void Home_Organizations_Returns_OrganizationList_when_they_exist()
        {
            //Arrange
            MocModelRepository repository = new MocModelRepository();
            Organization orgnaization1 = GetAOrganization("Organization 1 - Vi har kager", "cake@email.com");
            Organization orgnaization2 = GetAOrganization("organization 2 - vi har ikke kager", "nocake@mail.com");
            repository.CreateOrganization(orgnaization1);
            repository.CreateOrganization(orgnaization2);
            HomeController controller = GetHomeController(repository, new MocWebSecurity(false));

            //Act
            var result = controller.Organizations() as ViewResult;

            //Assert
            var model = (IEnumerable<Organization>)result.ViewData.Model;
            CollectionAssert.Contains(model.ToList(), orgnaization1);
            CollectionAssert.Contains(model.ToList(), orgnaization2);

        }

        [TestMethod]
        public void Home_Organizations_Return_EmptyList_When_No_Organizations_Exist()
        {
            //Arrange
            HomeController controller = GetHomeController(new MocModelRepository(), new MocWebSecurity(false));

            //Act
            var result = controller.Organizations() as ViewResult;

            //Assert
            var model = (IEnumerable<Organization>)result.ViewData.Model;
            CollectionAssert.AreEqual(new List<Organization>(), model.ToList());
        }
        #endregion

        #region Volunteer View
        [TestMethod]
        public void Home_Volunteer_Return_Volunteer()
        {
            //Arrange
            Volunteer volunteer = GetAVolunteer("bent");
            VolunteerProject project = GetAProject("kage", "chokolade");
            Invite invite = new Invite(volunteer, project);
            MocModelRepository repository = new MocModelRepository();
            volunteer.ID = 1;
            repository.CreateVolunteer(volunteer);
            repository.CreateProject(project);
            HomeController controller = GetHomeController(repository, new MocWebSecurity(false));

            //Act
            var result = controller.Volunteer(volunteer.ID) as ViewResult;

            //Assert
            var model = (Volunteer)result.ViewData.Model;
            Assert.AreEqual(volunteer, model);
            
        }

        [TestMethod]
        public void Home_Volunteer_Returns_404_if_Id_Not_Found()
        {
            //Arrange
            HomeController controller = GetHomeController(new MocModelRepository() , new MocWebSecurity(false));
 
           //Act
            var result = (HttpNotFoundResult)controller.Volunteer(123);

            //Assert
            Assert.AreEqual(new HttpNotFoundResult().StatusCode, result.StatusCode);
        }
        #endregion

        #region Volunteers
        [TestMethod]
        public void Home_Volunteers_Return_VolunteerList_When_They_Exsist()
        {
            //Arrange
            MocModelRepository repository = new MocModelRepository();
            Volunteer volunteer1 = GetAVolunteer("bent");
            Volunteer volunteer2 = GetAVolunteer("ole");
            repository.CreateVolunteer(volunteer1);
            repository.CreateVolunteer(volunteer2);
            HomeController controller = GetHomeController(repository, new MocWebSecurity(false));

            //Act
            var result = controller.Volunteers() as ViewResult;

            //Assert
            var model = (IEnumerable<Volunteer>)result.ViewData.Model;
            CollectionAssert.Contains(model.ToList(), volunteer1);
            CollectionAssert.Contains(model.ToList(), volunteer2);

        }

        [TestMethod]
        public void Home_Volunteers_return_EmptyList_when_no_Volunteers_Exist()
        {
            //Arrange
            HomeController controller = GetHomeController(new MocModelRepository(), new MocWebSecurity(false));

            //Act
            var result = controller.Volunteers() as ViewResult;

            //Assert
            var model = (IEnumerable<Volunteer>)result.ViewData.Model;
            CollectionAssert.AreEqual(new List<Volunteer>(), model.ToList());
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
            Assert.AreEqual("About", result.ViewName);
        }
    }
}
