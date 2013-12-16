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
            Topic Topics = new Topic();
            Topics.Church = true;

            Organization o = new Organization();

            VolunteerProject vp = new VolunteerProject(title, l, time, Topics, o, description, true);

            Assert.AreEqual(title, vp.Title);
            Assert.AreEqual(l.Address, vp.Location.Address);
            Assert.AreEqual(l.City, vp.Location.City);
            Assert.AreEqual(Topics.Church, vp.ProjectTopics.Church);
            Assert.AreEqual(o, vp.Owner);
            Assert.AreEqual(description, vp.Description);
            Assert.AreEqual(true, vp.Signup);
        }
        
        //Test
        [TestMethod]
        public void TestAddRemoveTopic()
        {
            Volunteer tester = Utility.GetVolunteer();
            VolunteerProject vp2 = Utility.GetVolunteerProject();
            Topic Topics = new Topic();

            vp2.ProjectTopics = Topics;
            Topics.Church = true;
            Assert.AreEqual(Topics.Church, vp2.ProjectTopics.Church);

            vp2.ProjectTopics = Topics;
            Topics.Church = false;
            Assert.AreEqual(Topics.Church, vp2.ProjectTopics.Church);
        }

        [TestMethod]
        public void TestCalculate()
        {
            VolunteerProject vp2 = Utility.GetVolunteerProject();
            Volunteer v = Utility.GetVolunteer();

            vp2.Location.Lat = 50.0;
            vp2.Location.Lng = 15.0;

            v.Location.Lat = 55.0;
            v.Location.Lng = 10.0;
            double output = vp2.Calculate(vp2, v);
            double expected = 651.43;

            Assert.AreEqual(expected, output, 1.0);

            //Test for wrong value
            double expected2 = 10; //Wrong value

            Assert.AreNotEqual(expected2, output, 1.0);
        }
    }
}
