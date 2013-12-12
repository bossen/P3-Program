using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace TestWeb2.Controllers
{
    public class TestController : Controller
    {
        private VolunteerOrgContext db = new VolunteerOrgContext();

        public ActionResult Index()
        {
            var volunteers = db.Volunteers.Include(v => v.Location);
            return View(volunteers.ToList()); 
        }

        public ActionResult Welcome(string name, int numtimes = 1)
        {
            ViewBag.Message = "Hello " + name;
            ViewBag.numtimes = numtimes;
            return View();
        }

        public ActionResult Details(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volunteer volunteer = db.Volunteers.Find(ID);
            if (volunteer == null)
            {
                return HttpNotFound();
            }
            return View(volunteer);
        }

        public ActionResult Edit(int ID = 0)
        {
            Volunteer volunteer = db.Volunteers.Find(ID);
            if (volunteer == null)
            {
                return HttpNotFound();
            }
            return View(volunteer);
        }

        [HttpPost]
        public ActionResult Edit(Volunteer volunteer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(volunteer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(volunteer);
        }
    }
}
