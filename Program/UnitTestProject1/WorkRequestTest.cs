using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace UnitTestProject1
{
    [TestClass]
    public class WorkRequestTest
    {
        [TestMethod]
        public void WorkRequestConstructors()
        {
            int userid = 1;
            string username = "username", password = "password", name = "name", address = "address", city = "city", mail = "mail";
            string title = "title", description = "description";
            Location l = new Location(address, city);
            DateTime time = DateTime.Now.AddDays(1);
            List<Preference> preferences = new List<Preference>();
            preferences.Add(Preference.Church);
            preferences.Add(Preference.Festival);

            Volunteer v = new Volunteer(userid, username, name, l, mail);
            Organization o = new Organization();
            VolunteerProject vp = new VolunteerProject(title, l, time, preferences, o, description, true);

            WorkRequest wr = new WorkRequest(v, vp);

            Assert.AreEqual(v, wr.Volunteer);
            Assert.AreEqual(vp, wr.Project);
            Assert.AreEqual(time, wr.Expire);
            Assert.IsNull(wr.Accepted);
        }

        [TestMethod]
        public void WorkRequestMethods()
        {
            int userid = 1;
            string username = "username", password = "password", name = "name", address = "address", city = "city", mail = "mail";
            string title = "title", description = "description";
            Location l = new Location(address, city);
            DateTime time = DateTime.Now;
            List<Preference> preferences = new List<Preference>();
            preferences.Add(Preference.Church);
            preferences.Add(Preference.Festival);

            Volunteer v = new Volunteer(userid, name, l, mail);
            Organization o = new Organization();
            VolunteerProject vp = new VolunteerProject(title, l, time, preferences, o, description, true);

            WorkRequest wr = new WorkRequest(v, vp);

            //Check AcceptMatch
            wr.AcceptMatch();

            Assert.AreEqual(true, wr.Accepted);

            //Check DeleteMatch
            wr.DeleteMatch();

            Assert.IsNull(wr.Volunteer);
            Assert.IsNull(wr.Project);
        }
    }
}
