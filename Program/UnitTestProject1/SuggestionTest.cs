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
            Volunteer v = (Utility.GetVolunteer());
            VolunteerProject vp = (Utility.GetVolunteerProject());

            Suggestion s = new Suggestion(v, vp);

            Assert.AreEqual(v, s.Volunteer);
            Assert.AreEqual(vp, s.Project);
            Assert.AreEqual(DateTime.Now.AddDays(1).Second, s.Expire.Second);
            Assert.IsNull(s.Accepted);
        }

        [TestMethod]
        public void SuggestionMethods()
        {
            Volunteer v = (Utility.GetVolunteer());
            VolunteerProject vp = (Utility.GetVolunteerProject());

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
