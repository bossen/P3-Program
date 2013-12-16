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
            DateTime time = DateTime.Now.AddDays(1);
            Volunteer v = (Utility.GetVolunteer());
            VolunteerProject vp = (Utility.GetVolunteerProject());

            Invite i = new Invite(v, vp);

            Assert.AreEqual(v, i.Volunteer);
            Assert.AreEqual(vp, i.Project);
            Assert.AreEqual(time, i.Expire);
            Assert.IsNull(i.Accepted);
        }

        [TestMethod]
        public void InviteMethods()
        {
            Volunteer v = (Utility.GetVolunteer());
            VolunteerProject vp = (Utility.GetVolunteerProject());

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
