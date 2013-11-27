using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace UnitTestProject1
{
    [TestClass]
    public class InviteTest
    {
        [TestMethod]
        public void InviteConstructors()
        {
            string username = "username", password = "password", name = "name", address = "address", city = "city", mail = "mail";
            string title = "title", description = "description";
            Location l = new Location(address, city);
            DateTime time = DateTime.Now.AddDays(1);
            List<Preference> preferences = new List<Preference>();
            preferences.Add(Preference.Church);
            preferences.Add(Preference.Festival);

            Volunteer v = new Volunteer(username, password, name, l, mail);
            Organization o = new Organization();
            VolunteerProject vp = new VolunteerProject(title, l, time, preferences, o, description, true);

            Invite i = new Invite(v, vp);

            Assert.AreEqual(v, i.Volunteer);
            Assert.AreEqual(vp, i.Project);
            Assert.AreEqual(time, i.Expire);
            Assert.IsNull(i.Accepted);
        }

        [TestMethod]
        public void InviteMethods()
        {
            string username = "username", password = "password", name = "name", address = "address", city = "city", mail = "mail";
            string title = "title", description = "description";
            Location l = new Location(address, city);
            DateTime time = DateTime.Now;
            List<Preference> preferences = new List<Preference>();
            preferences.Add(Preference.Church);
            preferences.Add(Preference.Festival);

            Volunteer v = new Volunteer(username, password, name, l, mail);
            Organization o = new Organization();
            VolunteerProject vp = new VolunteerProject(title, l, time, preferences, o, description, true);

            Invite i = new Invite(v, vp);

            //Check AcceptMatch
            i.AcceptMatch();

            Assert.AreEqual(true, i.Accepted);

            //Check DeleteMatch
            i.DeleteMatch();

            Assert.IsNull(i.Volunteer);
            Assert.IsNull(i.Project);
        }
    }
}
