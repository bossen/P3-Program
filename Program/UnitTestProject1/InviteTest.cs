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
            string username = "username", name = "name", address = "address", city = "city", mail = "mail";
            string title = "title", description = "description";
            Location l = new Location(address, city);
            DateTime time = DateTime.Now.AddDays(1);
            List<Topic> preferences = new List<Topic>();
            Topic Topics = new Topic();
            Topics.Name = "Church";
            preferences.Add(Topics);

            Volunteer v = new Volunteer(username, name, l, mail);
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
            string username = "username", name = "name", address = "address", city = "city", mail = "mail";
            string title = "title", description = "description";
            Location l = new Location(address, city);
            DateTime time = DateTime.Now;
            List<Topic> preferences = new List<Topic>();
            Topic Topics = new Topic();
            Topics.Name = "Church";
            preferences.Add(Topics);

            Volunteer v = new Volunteer(username, name, l, mail);
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
