using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcVolunteerOrg.Models;
using WebMatrix.WebData;
using System.Data.Entity;
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

        [AllowAnonymous]
        public ActionResult Create()
        {
            using (var db = new VolunteerOrgContext())
            {
                Volunteer newVolunteer = new Volunteer(WebSecurity.CurrentUserId);
                db.Volunteers.Add(newVolunteer);
                db.SaveChanges();
            }

            using (var db = new VolunteerOrgContext())
            {
                var test = db.Volunteers;
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Volunteer volunteer)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Profile");
            }

            return View(volunteer);
        }

        public ActionResult CreateOrNot()
        {
            using (var db = new VolunteerOrgContext())
            {
                Admin newAdmin = new Admin(WebSecurity.CurrentUserId);
                db.Admins.Add(newAdmin);
                db.SaveChanges();
            }
            
            return View();
        }
        
    }
}
