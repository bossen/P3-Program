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
            return Index();
        }

        // GET: /Profile/Edit/5

        public ActionResult Edit()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Profile");
            }

            return View(user);
        }
        
    }
}
