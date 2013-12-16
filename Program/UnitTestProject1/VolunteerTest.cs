using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace UnitTestProject1
{
    [TestClass]
    public class VolunteerTest
    {
        [TestMethod]
        public void VolunteerConstructors()
        {
            string username = "username", name = "name", address = "address", city = "city", mail = "mail";
            Location l = new Location(address, city);

            Volunteer v1 = new Volunteer(username, name, l, mail);
            Assert.AreEqual(DateTime.Now.Second, v1.Creation.Second);
            Assert.AreEqual(name, v1.Name);
            Assert.AreEqual(l.Address, v1.Location.Address);
            Assert.AreEqual(l.City, v1.Location.City);
            Assert.AreEqual(mail, v1.Email);

            //Test minimum constructor parameters
            Volunteer v2 = new Volunteer(username, name);
            Assert.AreEqual(DateTime.Now.Second, v2.Creation.Second);
            Assert.AreEqual(username, v1.UserName);
        }

        [TestMethod]
        public void TestSuggestion()
        {
            Volunteer v = (Utility.GetVolunteer());
            VolunteerProject vp = (Utility.GetVolunteerProject());

            Suggestion Expected = new Suggestion();
            Expected.Volunteer = v;
            Suggestion output = v.AddSuggestion(vp);
            Assert.AreEqual(Expected.Volunteer, output.Volunteer);

            Expected.Project = vp;
            Assert.AreEqual(Expected.Project, output.Project);
        }

        [TestMethod]
        public void TestWorkRequest()
        {
            Volunteer v = (Utility.GetVolunteer());
            VolunteerProject vp = (Utility.GetVolunteerProject());
            
            WorkRequest wr = new WorkRequest();
            wr = (WorkRequest)v.AddWorkRequest(vp);

            CollectionAssert.Contains(v.Matches, wr);
        }

        [TestMethod]
        public void TestSortMatches()
        {
            Volunteer v = (Utility.GetVolunteer());
            VolunteerProject vp = (Utility.GetVolunteerProject());

            v.AddWorkRequest(vp);
            v.AddWorkRequest(vp).AcceptMatch();

            CollectionAssert.Contains(v.Matches, v.GetAcceptedMatches());
        }
    }
}
