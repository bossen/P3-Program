using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace UnitTestProject1
{
    [TestClass]
    public class SuggestionTest
    {
        [TestMethod]
        public void SuggestionConstructors()
        {
            string username = "username", password = "password", name = "name", address = "address", city = "city", mail = "mail";
            string title = "title", description = "description";
            Location l = new Location(address, city);
            DateTime time = DateTime.Now.AddDays(1);
            List<Preference> preferences = new List<Preference>();
            preferences.Add(Preference.Church);
            preferences.Add(Preference.Festival);

            Volunteer v = new Volunteer(1, username, name, l, mail);
            Organization o = new Organization();
            VolunteerProject vp = new VolunteerProject(title, l, time, preferences, o, description, true);

            Suggestion s = new Suggestion(v, vp);

            Assert.AreEqual(v, s.Volunteer);
            Assert.AreEqual(vp, s.Project);
            Assert.AreEqual(DateTime.Now.AddDays(1).Second, s.Expire.Second);
            Assert.IsNull(s.Accepted);
        }

        [TestMethod]
        public void SuggestionMethods()
        {
            string username = "username", password = "password", name = "name", address = "address", city = "city", mail = "mail";
            string title = "title", description = "description";
            Location l = new Location(address, city);
            DateTime time = DateTime.Now;
            List<Preference> preferences = new List<Preference>();
            preferences.Add(Preference.Church);
            preferences.Add(Preference.Festival);

            Volunteer v = new Volunteer(1, name, l, mail);
            Organization o = new Organization();
            VolunteerProject vp = new VolunteerProject(title, l, time, preferences, o, description, true);

            Suggestion s = new Suggestion(v, vp);

            //Check AcceptMatch
            s.AcceptMatch();

            Assert.AreEqual(true, s.Accepted);

            //Check DeleteMatch
            s.DeleteMatch();

            Assert.IsNull(s.Volunteer);
            Assert.IsNull(s.Project);
        }
    }
}
