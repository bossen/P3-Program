using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcVolunteerOrg.Controllers
{
    public class UserController : Controller
    {

        public ActionResult VolunteerProfile()
        {
            //Lav en "If not volunteer but OrgProfile, Then Redirect to OrgProfile"

            return View();
        }


        public ActionResult OrgProfile()
        {
            return View();
        }
    }
}
