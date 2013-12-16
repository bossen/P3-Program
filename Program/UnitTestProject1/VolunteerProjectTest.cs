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
            Volunteer tester = new Volunteer("username", null, null, null);
            VolunteerProject vp2 = new VolunteerProject();
            Topic Topics = new Topic();
            
            Topics.Church = true;
            Assert.IsTrue(Topics.Church);

            Topics.Church = false;
            Assert.IsFalse(Topics.Church);
        }

        [TestMethod]
        public void TestCalculate()
        {
        Topic Topics = new Topic();
        
        Organization o = new Organization();

        Location lvp = new Location();
        Location lv = new Location();

        VolunteerProject vp2 = new VolunteerProject("title", lvp, DateTime.Now, Topics, o, "description", true);
        Volunteer v = new Volunteer("username", null, lv, null);
        
        lvp.Lat = 50.0;
        lvp.Lng = 15.0;
        
        lv.Lat = 55.0;
        lv.Lng = 10.0;
        double output = vp2.Calculate(vp2, v);
        double expected = 651.43;

        Assert.AreEqual(expected, output, 1.0);

        //Test for wrong value        
        lvp.Lat = 50.0;
        lvp.Lng = 15.0;

        lv.Lat = 55.0;
        lv.Lng = 10.0;
        double output2 = vp2.Calculate(vp2, v);
        double expected2 = 10; //Wrong value

        Assert.AreNotEqual(expected2, output2, 1.0);
        }
    }
}
