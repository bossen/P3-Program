using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace UnitTestProject1
{
    [TestClass]
    public class OrganizationTest 
    {
        [TestMethod]
        public void OrganizationConstructors()
        {
            string name = "name", email = "email";
            Location location = new Location("address", "city");
            Organization o = new Organization(name, location, email);

            Assert.AreEqual(name, o.Name);
            Assert.AreEqual(email, o.Email);
            Assert.AreEqual(location, o.Location);
        }

        [TestMethod]
        public void OrganizationMethods()
        {
            string name = "name", email = "mail", title = "title", description = "description";
            DateTime time = DateTime.Now;
            Topic Topics = new Topic();
            Topics.Church = true;
            Location location = new Location("address", "city");
            Organization o = new Organization(name, location, email);

            //Test CreateProject
            o.CreateProject(title, location, time, Topics, description);

            Assert.AreEqual(title, o.GetProjects()[0].Title);
            Assert.AreEqual(location, o.GetProjects()[0].Location);
            Assert.AreEqual(time, o.GetProjects()[0].Time);
            Assert.AreEqual(Topics.Church, o.GetProjects()[0].ProjectTopics.Church);
            Assert.AreEqual(description, o.GetProjects()[0].Description);
            Assert.AreEqual(o, o.GetProjects()[0].Owner);
            Assert.AreEqual(true, o.GetProjects()[0].Signup);
        }
    }
}