using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Model;
using System.Data.Entity;

namespace TestWeb2.Controllers
{
    public class HomeController : Controller
    {
        private VolunteerOrgContext db = new VolunteerOrgContext();

        public ActionResult Index()
        {
            Volunteer currentUser = db.Volunteers.ToList().Where(v => v.Name == "jack").FirstOrDefault();
            

            Volunteer v1 = new Volunteer("jack", "jack", new Location("råbaaavejen 22", "rødeskovkildelyst"), "nice@mail.dk");
            Organization o1 = new Organization("green", new Location("address", "city"), "mail@mail.dk");
            o1.CreateProject("title", new Location("address", "city"), DateTime.Now.AddDays(2), new List<Preference>() { Preference.Church }, "description");
            db.Organizations.Add(o1);
            db.Volunteers.Add(v1);
            db.SaveChanges();



            ViewBag.Message = currentUser.Name;
            ViewBag.Suggestions = currentUser.GetSortMatches().Take(5);

            return View();
        }

        public ActionResult DashBoard()
        {
            Volunteer currentUser = db.Volunteers.ToList().Where(v => v.Name == "jack").FirstOrDefault();
            ViewBag.Suggestions = currentUser.GetSortMatches();

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

        public ActionResult ProfileEdit()
        {
            return View("Home/Profile/Edit");
        }

        public ActionResult ProfileDashboard()
        {
            return View("Home/Profile/Dashboard");
        }

        public ActionResult CreateOrNot()
        {
            return View("Home/Organization/CreateOrNot");
        }

        public ActionResult Organization()
        {
            return View("Home/Organization/Index");
        }

        public ActionResult OrganizationCreate()
        {
            return View("Home/Organization/Create");
        }

        public ActionResult OrganizationEdit()
        {
            return View("Home/Organization/Edit");
        }

        public ActionResult OrganizationDashboard()
        {
            return View("Home/Organization/Dashboard");
        }
    }
}
