using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Class1Test()
        {
            Class1 o = new Class1(1);
            Assert.AreEqual(1, o.MyProperty, "Super mega awesome!");
            Assert.AreEqual(2 - o.MyProperty, o.MyProperty, "Super mega awesome!");
        }

        [TestMethod]
        public void Class1Test2()
        {
            Class1 o = new Class1(0);
            Assert.AreEqual(0, o.MyProperty, "Super mega awesome!");
            Assert.AreEqual(2, o.MyProperty, "Super mega awesome!");
            Assert.AreEqual(3, o.MyProperty, "Super mega awesome!");
        }
    }
}
