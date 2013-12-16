using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWeb2.Models
{
    public interface ISecurityWrap
    {
        bool IsAuthenticated();
        string GetCurrentUserName();
    }
}