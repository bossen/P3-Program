using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Class1
    {
        public int MyProperty { get; set; }

        public Class1(int myProperty)
        {
            MyProperty = myProperty;
        }

        public void SendTestMail()
        {
            Mail mail = new Mail("ds308e13@cs.aau.dk", "[ROBOT] Mail system test", "Det virker, hilsen jeres robot overlord");
            mail.SendMail();
        }

    }
}
