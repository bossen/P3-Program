using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using System.Data.Entity;

namespace TestWeb2.Controllers
{
    public class HomeController : Controller
    {
        private VolunteerOrgContext db = new VolunteerOrgContext();

        public ActionResult Index()
        {
            Volunteer v1 = new Volunteer("jack", "jack", new Location("råbaaavejen 22", "rødeskovkildelyst"), "nice@mail.dk");
            db.Volunteers.Add(v1);
            db.SaveChanges();

            ViewBag.Message = db.Volunteers.ToList()[0].Name;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Profile()
        {
            return View("Home/Profile/Index");
        }

        public ActionResult ProfileCreate()
        {
            return View("Home/Profile/Create");
        }
    }
}
