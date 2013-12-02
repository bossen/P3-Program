using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace MvcVolunteerOrg.Controllers
{
    public class ProfileController : Controller
    {
        //
        // GET: /Profile/

        public ActionResult Index()
        {
            return View();
        }

        // GET: /Profile/Edit/5

        public ActionResult Edit()
        {
            return View();
        }


        
    }
}
