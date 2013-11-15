using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod]
        //public void Class1Test()
        //{
        //    Class1 o = new Class1(1);
        //    Assert.AreEqual(1, o.MyProperty, "Super mega awesome!");
        //    Assert.AreEqual(2 - o.MyProperty, o.MyProperty, "Super mega awesome!");
        //}

        //[TestMethod]
        //public void Class1Test2()
        //{
        //    Class1 o = new Class1(0);
        //    Assert.AreEqual(0, o.MyProperty, "Super mega awesome!");
        //}

        //[TestMethod]
        //public void TEST()
        //{
        //    Organization o = new Organization("organization", "password");
        //    Volunteer v = new Volunteer("username", "password");
        //    o.CreateProject("name", new Location("address", "city"), DateTime.Now, new System.Collections.Generic.List<Preference>() { Preference.Church, Preference.Festival }, "none");

        //}
        [TestMethod]
        public void Test()
        {
            Class1 hej = new Class1(1);
            hej.SendTestMail();
        }
    }
}
