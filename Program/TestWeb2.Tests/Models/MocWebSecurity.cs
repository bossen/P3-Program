using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWeb2.Tests.Models
{
    public class MocWebSecurity : TestWeb2.Models.ISecurityWrap
    {
        public string Username { get; set; }
        bool Authenticated { get; set; }
        public bool IsAuthenticated()
        {
            return Authenticated;
        }

        public MocWebSecurity(bool authenticated)
        {
            Authenticated = authenticated;
        }

        public string GetCurrentUserName()
        {
            return Username;
        }
    }
}
