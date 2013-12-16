using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.WebData;

namespace TestWeb2.Models
{
    public class WebSecurityProvider : ISecurityWrap
    {
        public bool IsAuthenticated()
        {
            return WebSecurity.IsAuthenticated;
        }
        public string GetCurrentUserName()
        {
            return WebSecurity.CurrentUserName;
        }
    }
}