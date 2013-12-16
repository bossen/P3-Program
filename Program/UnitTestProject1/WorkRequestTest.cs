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
            string username = "username", name = "name", address = "address", city = "city", mail = "mail";
            string title = "title", description = "description";
            Location l = new Location(address, city);
            DateTime time = DateTime.Now.AddDays(1);
            Topic Topics = new Topic();
            Topics.Church = true;

            Volunteer v = new Volunteer(username, name, l, mail);
            Organization o = new Organization();
            VolunteerProject vp = new VolunteerProject(title, l, time, Topics, o, description, true);

            WorkRequest wr = new WorkRequest(v, vp);

            Assert.AreEqual(v, wr.Volunteer);
            Assert.AreEqual(vp, wr.Project);
            Assert.AreEqual(time, wr.Expire);
            Assert.IsNull(wr.Accepted);
        }

        [TestMethod]
        public void WorkRequestMethods()
        {
            string username = "username", name = "name", address = "address", city = "city", mail = "mail";
            string title = "title", description = "description";
            Location l = new Location(address, city);
            DateTime time = DateTime.Now;
            Topic Topics = new Topic();
            Topics.Church = true;

            Volunteer v = new Volunteer(username, name, l, mail);
            Organization o = new Organization();
            VolunteerProject vp = new VolunteerProject(title, l, time, Topics, o, description, true);

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
