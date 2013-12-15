using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace UnitTestProject1
{
    [TestClass]
    public class VolunteerProjectTest
    {
        [TestMethod]
        public void VolunteerProjectConstructors()
        {
            string address = "address", city = "city", title = "title", description = "description";
            Location l = new Location(address, city);
            DateTime time = DateTime.Now;
            List<Topic> preferences = new List<Topic>();
            Topic Topics = new Topic();
            Topics.Name = "Church";
            preferences.Add(Topics);

            Organization o = new Organization();

            VolunteerProject vp = new VolunteerProject(title, l, time, preferences, o, description, true);

            Assert.AreEqual(title, vp.Title);
            Assert.AreEqual(l.Address, vp.Location.Address);
            Assert.AreEqual(l.City, vp.Location.City);
            Assert.AreEqual(preferences, vp.ProjectTopics);
            Assert.AreEqual(o, vp.Owner);
            Assert.AreEqual(description, vp.Description);
            Assert.AreEqual(true, vp.Signup);
        }
        
        //Test
        [TestMethod]
        public void TestAddRemoveTopic()
        {
            Volunteer tester = new Volunteer("username", null, null, null);
            VolunteerProject vp2 = new VolunteerProject();
            Topic Topics = new Topic();
            Topics.Name = "Church";

            vp2.AddTopic(Topics);
            Topic expected = Topics;
            Assert.IsTrue(vp2.ProjectTopics.Contains(expected));

            vp2.RemoveTopic(Topics);
            Assert.IsFalse(vp2.ProjectTopics.Contains(expected));
        }
    }
}
