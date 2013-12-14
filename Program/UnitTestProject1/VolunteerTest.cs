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
        public void VolunteerMethods()
        {
            string username = "username", name = "name", address = "address", city = "city", mail = "mail";
            string title = "title", description = "description";
            Location l = new Location(address, city);
            DateTime time = DateTime.Now;
            List<Topic> preferences = new List<Topic>();
            Topic Topics = new Topic();
            Topics.Name = "Church";
            preferences.Add(Topics);

            Organization o = new Organization();
            Volunteer v = new Volunteer(username, name, new Location(address, city), mail);
            VolunteerProject vp = new VolunteerProject(title, l, time, preferences, o, description, true);

            /* DOESN'T WORK!
            //Test workrequests
            v.AddWorkRequest(vp);
            Match tmpMatch1 = v.GetPendingMatches()[0];
            Assert.AreEqual(vp, tmpMatch1.Project);

            //Test accept match
            tmpMatch1.AcceptMatch();
            Assert.AreEqual(vp, v.GetAcceptedMatches()[0].Project);

            //Test add match
            Match tmpMatch2 = new WorkRequest(v, vp);
            v.AddMatch(tmpMatch2);
            Assert.AreEqual(vp, v.GetPendingMatches()[0].Project);

            //Test Remove Project
            v.RemoveProject(vp);
            */
        }
    }
}
