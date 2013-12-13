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
    public class AdminController : Controller
    {
        private VolunteerOrgContext db = new VolunteerOrgContext();
        //
        // GET: /Admin/

        [Authorize]
        public ActionResult Index()
        {
            Admin currentuser = GetCurrentUser();

            if (currentuser.Association == null)
            {
                ViewBag.Authenticated = false;
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
            if (ModelState.IsValid)
            {
                db.Organizations.Add(organization);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(organization);
        }

        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            Organization organization = db.Organizations.Find(id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        [Authorize]
        public ActionResult Organizations()
        {
            Admin currentuser = GetCurrentUser();

            if (currentuser.Association == null)
            {
                ViewBag.Authenticated = false;
            }
            return View(db.Organizations.ToList());
        }

        [Authorize]
        public ActionResult Organization(int id)
        {
            Organization organization = db.Organizations.Find(id);
            return View(organization);
        }

        public ActionResult JoinOrganization(int id)
        {
            Admin currentUser = GetCurrentUser();
            Organization organization = db.Organizations.Find(id);

            currentUser.AssociateOrganization(organization);
            db.Entry(currentUser).State = EntityState.Modified;
            db.Entry(organization).State = EntityState.Modified;
            db.SaveChanges();
            return View();
        }

        private Admin GetCurrentUser()
        {
            return db.Admins.ToList().Where(v => v.UserName.ToLower() == WebSecurity.CurrentUserName.ToLower()).FirstOrDefault();
        }

    }
}
