using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace UnitTestProject1
{
    [TestClass]
    public class MailTest
    {
        //[TestMethod]
        //public void SendMail()
        //{
        //    Mail m = new Mail();
        //    m.SendMail("ds308e13@cs.aau.dk", "[ROBOT] Mail system test", "Det virker, hilsen jeres robot overlord");
        //}

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Not a valid email!")]
        public void SendInvalidMail()
        {
            Mail m = new Mail();
            m.SendMail("INVALID", "[ROBOT] Mail system test", "Det virker, hilsen jeres robot overlord");
        }
    }
}
