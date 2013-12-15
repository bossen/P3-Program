using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestWeb2.Models;
using WebMatrix.WebData;

namespace TestWeb2.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private VolunteerOrgContext db = new VolunteerOrgContext();
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            ViewBag.IsAdmin = true;
            Admin currentuser = GetCurrentUser();

            if (currentuser.Association == null)
            {
                ViewBag.Authenticated = false;
            }
            else
            {
                ViewBag.Authenticated = true;
            }
            
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Organization organization)
        {
            Admin currentUser = GetCurrentUser();

            if (ModelState.IsValid && currentUser != null)
            {
                
                db.Organizations.Add(organization);
                currentUser.AssociateOrganization(organization);
                //db.Entry(organization).State = EntityState.Added;
                db.Entry(currentUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Organization");
            }

            return View(organization);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.IsAdmin = true;
            var organization = db.Organizations
                .Include("VolunteerProjects")
                .Include("Location.Address")
                .Include("Location.City")
                .Where(o => o.Id == id)
                .FirstOrDefault();
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        [HttpPost]
        public ActionResult Edit(Organization organization, int id)
        {
            var neworganization = db.Organizations
                .Include("VolunteerProjects")
                .Include("Location.Address")
                .Include("Location.City")
                .Where(o => o.Id == id)
                .FirstOrDefault();
            if (ModelState.IsValid && neworganization != null)
            {
                neworganization.Name = organization.Name;
                neworganization.Location = organization.Location;
                neworganization.Email = organization.Email;

                db.Entry(neworganization).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index", "Organization", new { id = neworganization.Id });
            }


            return View(organization);
        }

        public ActionResult Organizations()
        {
            ViewBag.IsAdmin = true;
            Admin currentuser = GetCurrentUser();

            if (currentuser.Association == null)
            {
                ViewBag.Authenticated = false;
            }
            return View(db.Organizations.ToList());
        }

        public ActionResult Organization(int id)
        {
            ViewBag.IsAdmin = true;
            Organization organization = db.Organizations.Find(id);
            return View(organization);
        }

        public ActionResult JoinOrganization(int id)
        {
            ViewBag.IsAdmin = true;
            Admin currentUser = GetCurrentUser();
            Organization organization = db.Organizations.Find(id);

            currentUser.AssociateOrganization(organization);
            db.Entry(currentUser).State = EntityState.Modified;
            db.SaveChanges();
            return View(organization);
        }

        private Admin GetCurrentUser()
        {
            return db.Admins.ToList().Where(v => v.UserName.ToLower() == WebSecurity.CurrentUserName.ToLower()).FirstOrDefault();
        }

    }
}
