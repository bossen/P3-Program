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

        public ActionResult Edit(int id = 0)
        {
            ViewBag.IsAdmin = true;
            Organization organization = db.Organizations.Find(id);
            if (organization == null)
            {
                return HttpNotFound();
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
            return View();
        }

        private Admin GetCurrentUser()
        {
            return db.Admins.ToList().Where(v => v.UserName.ToLower() == WebSecurity.CurrentUserName.ToLower()).FirstOrDefault();
        }

    }
}
