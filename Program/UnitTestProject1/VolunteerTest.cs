using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace UnitTestProject1
{
    [TestClass]
    public class VolunteerTest
    {
        [TestMethod]
        public void VolunteerConstructors()
        {
            string username = "username", name = "name", address = "address", city = "city", mail = "mail";
            Location l = new Location(address, city);

            Volunteer v1 = new Volunteer(username, name, l, mail);
            Assert.AreEqual(DateTime.Now.Second, v1.Creation.Second);
            Assert.AreEqual(name, v1.Name);
            Assert.AreEqual(l.Address, v1.Location.Address);
            Assert.AreEqual(l.City, v1.Location.City);
            Assert.AreEqual(mail, v1.Email);

            //Test minimum constructor parameters
            Volunteer v2 = new Volunteer(username, name);
            Assert.AreEqual(DateTime.Now.Second, v2.Creation.Second);
            Assert.AreEqual(username, v1.UserName);
        }

        [TestMethod]
        public void TestSuggestion()
        {
            string username = "username", name = "name", address = "address", city = "city", mail = "mail";
            string title = "title", description = "description";
            Location l = new Location(address, city);
            DateTime time = DateTime.Now;
            Topic Topics = new Topic();
            Topics.Church = true;

            Organization o = new Organization();
            Volunteer v = new Volunteer(username, name, new Location(address, city), mail);
            VolunteerProject vp = new VolunteerProject(title, l, time, Topics, o, description, true);

            Suggestion Expected = new Suggestion();
            Expected.Volunteer = v;
            Suggestion output = v.AddSuggestion(vp);
            Assert.AreEqual(Expected.Volunteer, output.Volunteer);

            Expected.Project = vp;
            Assert.AreEqual(Expected.Project, output.Project);
        }

        [TestMethod]
        public void TestWorkRequest()
        {
            string username = "username", name = "name", address = "address", city = "city", mail = "mail";
            string title = "title", description = "description";
            Location l = new Location(address, city);
            DateTime time = DateTime.Now;
            Topic Topics = new Topic();
            Topics.Church = true;

            Organization o = new Organization();
            Volunteer v = new Volunteer(username, name, new Location(address, city), mail);
            VolunteerProject vp = new VolunteerProject(title, l, time, Topics, o, description, true);

            v.AddWorkRequest(vp);
        }
    }
}
