using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace UnitTestProject1
{
    [TestClass]
    public class TestTopics
    {
        [TestMethod]
        public void TestCompareTopics()
        {
            //Give each topic 3 topics of which 2 are the same across both.
            Topic Topics1 = new Topic();
            Topics1.QuickSetProperties(true, true, false, true, false, false);

            Topic Topics2 = new Topic();
            Topics2.Culture = true;
            Topics2.Nature = true;
            Topics2.Political = true;

            Assert.AreEqual(Topics2.Nature, Topics1.Nature);
            Assert.AreNotEqual(Topics2.Political, Topics1.Political);

            Volunteer v = new Volunteer();
            v.VolunteerPreferences = Topics2;
            int output = v.VolunteerPreferences.CompareTopics(Topics1);
            int expected = 2;
            Assert.AreEqual(expected, output);
        }
        [TestMethod]
        public void TestPrint()
        {
            Topic Topics = new Topic();
            Topics.QuickSetProperties(true, true, false, false, false, false);

            Volunteer v = new Volunteer();
            string expected = "Church Culture ";
            v.VolunteerPreferences = Topics;
            string output = v.VolunteerPreferences.Print();
            Assert.AreEqual(expected, output);
        }
    }
}
