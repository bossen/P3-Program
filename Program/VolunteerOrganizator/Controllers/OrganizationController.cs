using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using VolunteerOrganizator.Models;

namespace MvcVolunteerOrg.Controllers
{
    public class OrganizationController : Controller
    {
        //
        // GET: /Organization/

        public ActionResult Index()
        {
            return View();
        }

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
        public ActionResult Create(Organization organization)
        {
            if (ModelState.IsValid)
            {
                using (var db = new VolunteerOrganizatorContext())
                {
                    db.Organizations.Add(organization);
                    db.SaveChanges();
                }
            
                return RedirectToAction("Index", "Organization");
            }

            return View(organization);
        }
    }
}
