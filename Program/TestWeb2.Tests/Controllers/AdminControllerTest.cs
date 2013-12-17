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
    public class AdminControllerTest
    {
        private static AdminController GetAdminController(IModelRepository repository, TestWeb2.Models.ISecurityWrap security)
        {
            AdminController controller = new AdminController(repository, security);

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
        #region Index Method
        [TestMethod]
        public void Admin_Index_Not_Associated()
        {
            //Arrange
            Admin admin = Utility.GetAnAdmin("bent");
            admin.Association = null;
            MocWebSecurity security = new MocWebSecurity(true);
            MocModelRepository repository = new MocModelRepository();
            repository.CreateAdmin(admin);
            security.Username = "bent";
            AdminController controller = GetAdminController(repository, security);

            //Act
            var result = controller.Index() as ViewResult;

            //Assert
            Assert.AreEqual(true, result.ViewBag.Authenticated);
            Assert.AreEqual("", result.ViewName);

        }

        [TestMethod]
        public void Admin_Index_IS_Associated()
        {
            //Arrange
            Admin admin = Utility.GetAnAdmin("bent");
            Organization organization = Utility.GetAnOrganization("Fisker", "fisk@email.dk");
            admin.Association = organization;
            MocWebSecurity security = new MocWebSecurity(true);
            MocModelRepository repository = new MocModelRepository();
            repository.CreateAdmin(admin);
            repository.CreateOrganization(organization);
            security.Username = "bent";
            AdminController controller = GetAdminController(repository, security);

            //Act
            var result = controller.Index() as ViewResult;

            //Assert
            Assert.AreEqual(false, result.ViewBag.Authenticated);
            Assert.AreEqual("", result.ViewName);

        }
        #endregion

        [TestMethod]
        public void Admin_Create_Organization_returns_index_if_modelstate_invalid() 
        {
            //Arrange
            AdminController controller = GetAdminController(new MocModelRepository(), new MocWebSecurity(true));
            // Simply executing a method during a unit test does just that - executes a method, and no more. 
            // The MVC pipeline doesn't run, so binding and validation don't run.
            controller.ModelState.AddModelError("", "Mock error. Haha! I Mock you, error.");
            Organization organization = Utility.GetAnOrganization();
            //Act
            var result = (ViewResult)controller.Create(organization);

            //Assert
            Assert.AreEqual("", result.ViewName);//The "" indicates that it should return to the index
        }

        [TestMethod]
        public void Admin_Create_Adds_A_Organisation_to_the_list()
        {
            //Arrange
            MocModelRepository repository = new MocModelRepository();
            AdminController controller = GetAdminController(repository, new MocWebSecurity(true));
            Organization organization = Utility.GetAnOrganization("Orgname", "mail@stuf.dk");

            //Act
            controller.Create(organization);

            //Assert
            CollectionAssert.Contains(repository.GetAllOrganizations().ToList(), organization);

        }

    }


}
