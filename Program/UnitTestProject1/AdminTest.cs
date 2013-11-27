using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace UnitTestProject1
{
    [TestClass]
    public class AdminTest
    {
        [TestMethod]
        public void AdminConstructors()
        {
            string username = "username", password = "password", name = "name", address = "address", city = "city", mail = "mail";
            Location l = new Location(address, city);
            Admin a1 = new Admin(username, password, name, l, mail);
            Assert.AreEqual(DateTime.Now.Second, a1.Creation.Second);
            Assert.AreEqual(username, a1.Username);
            Assert.AreEqual(password, a1.Password);
            Assert.AreEqual(name, a1.Name);
            Assert.AreEqual(l.Address, a1.Location.Address);
            Assert.AreEqual(l.City, a1.Location.City);
            Assert.AreEqual(mail, a1.Email);

            //Test minimum constructor parameters
            Volunteer a2 = new Volunteer(username, password);
            Assert.AreEqual(DateTime.Now.Second, a2.Creation.Second);
            Assert.AreEqual(username, a2.Username);
            Assert.AreEqual(password, a2.Password);
        }
    }
}
