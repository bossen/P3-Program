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
            List<Preference> preferences = new List<Preference>();
            preferences.Add(Preference.Church);
            preferences.Add(Preference.Festival);

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
        /* CheckVolunteerSuggest method is private and can't be accessed
        [TestMethod]
        public void TestCheckVolunteerSuggest()
        {
            Volunteer tester = new Volunteer("username", null, null, null);
            VolunteerProject vp2 = new VolunteerProject();

            bool? output = null;
            bool expected = true;

            output = vp2.CheckVolunteerSuggest(tester);

            Assert.AreEqual(expected, output);
        }*/
    }

}
