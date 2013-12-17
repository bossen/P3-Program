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
    class AdminControllerTest
    {
        //private static AdminController GetAdminController(IModelRepository repository, TestWeb2.Models.ISecurityWrap security)
        //{
        //    AdminController controller = new AdminController(repository, security);

        //    controller.ControllerContext = new ControllerContext()
        //    {
        //        Controller = controller,
        //        RequestContext = new RequestContext(new MockHttpContext(), new RouteData())
        //    };
        //    return controller;
        //}


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
        public void Admin_Index_Not_Associated()
        {
            //Arrange
            Admin admin = Utility.GetAAdmin("bent");
            MocWebSecurity security = new MocWebSecurity(true);
            MocModelRepository repository = new MocModelRepository();
            repository.CreateAdmin(admin);
            security.Username = "bent";
            AdminController controller;

        }
    }


}
