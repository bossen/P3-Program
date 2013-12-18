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
        public void Admin_Organizations_All_Added()
        {
            //Arrange
            MocModelRepository repository = new MocModelRepository();
            //Organization orgnaization1 = Utility.GetAnOrganization("Organization 1 - Vi har kager", "cake@email.com");
            //Organization orgnaization2 = Utility.GetAnOrganization("organization 2 - vi har ikke kager", "nocake@mail.com");
            //repository.CreateOrganization(orgnaization1);
            //repository.CreateOrganization(orgnaization2);
            AdminController controller = GetAdminController(repository, new MocWebSecurity(false));

            //Act
            var result = controller.Organizations() as ViewResult;

            //Assert
            //var model = (IEnumerable<Organization>)result.ViewData.Model;
            //CollectionAssert.Contains(model.ToList(), orgnaization1);
            //CollectionAssert.Contains(model.ToList(), orgnaization2);
        }

    }


}
