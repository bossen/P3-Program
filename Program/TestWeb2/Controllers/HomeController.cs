using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Model;
using System.Data.Entity;
using WebMatrix.WebData;

namespace TestWeb2.Controllers
{
    public class HomeController : Controller
    {
        private VolunteerOrgContext db = new VolunteerOrgContext();

        public ActionResult Index()
        {
            

            Volunteer v1 = new Volunteer("jack", "jack", new Location("råbaaavejen 22", "rødeskovkildelyst"), "nice@mail.dk");
            Organization o1 = new Organization("green", new Location("address", "city"), "mail@mail.dk");
            VolunteerProject vp1 = o1.CreateProject("title", new Location("address", "city"), DateTime.Now.AddDays(2), new List<Preference>() { Preference.Church }, "description");
            Suggestion s1 = v1.AddSuggestion(vp1);
            db.Organizations.Add(o1);
            db.Volunteers.Add(v1);
            db.SaveChanges();


            Volunteer currentUser = db.Volunteers.ToList().Where(v => v.UserName == WebSecurity.CurrentUserName).FirstOrDefault();

            ViewBag.Message = currentUser.Name;
            //ViewBag.Suggestions = v1.GetSortMatches().Take(5);
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
            return View("Profile/Index");
        }

        public ActionResult ProfileCreate()
        {
            return View("Profile/Create");
        }

        public ActionResult ProfileEdit()
        {
            return View("Profile/Edit");
        }

        public ActionResult ProfileDashboard()
        {
            return View("Profile/Dashboard");
        }

        public ActionResult CreateOrNot()
        {
            return View("Organization/CreateOrNot");
        }

        public ActionResult Organization()
        {
            return View("Organization/Index");
        }

        public ActionResult OrganizationCreate()
        {
            return View("Organization/Create");
        }

        public ActionResult OrganizationEdit()
        {
            return View("Organization/Edit");
        }

        public ActionResult OrganizationDashboard()
        {
            return View("Organization/Dashboard");
        }
    }
}
