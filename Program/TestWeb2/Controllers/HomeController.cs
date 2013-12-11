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

            //Volunteer ole = db.Volunteers.ToList().Where(v => v.UserName == "ole").FirstOrDefault();
            //ole.AddSuggestion(vp1);
            //Invite i1 = new Invite(ole, vp1);
            //ole.AddMatch(i1);

            db.Organizations.Add(o1);
            db.Volunteers.Add(v1);
            db.SaveChanges();

            ViewBag.Authenticated = WebSecurity.IsAuthenticated;

            if (WebSecurity.IsAuthenticated)
            {
                Volunteer currentUser = db.Volunteers.ToList().Where(v => v.UserName == WebSecurity.CurrentUserName).FirstOrDefault();
                ViewBag.Title = "";

                if (currentUser.GetInvites() != null)
                    ViewBag.Invites = currentUser.GetInvites();
                ViewBag.Suggestions = currentUser.GetSortMatches();
            }
            else
            {
                ViewBag.Title = "Welcome";
                ViewBag.Suggestions = db.VolunteerProjects.OrderBy(p => p.Time).Take(5);
            }

            return View();
        }

        public ActionResult Projects()
        {
            ViewBag.Title = "List of Volunteer Projects";
            ViewBag.Projects = db.VolunteerProjects;
            return View();
        }

        public ViewResult Project(VolunteerProject project)
        {
            return View(project);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Profile()
        {
            return View("~/Views/Home/Profile/Index.cshtml");
        }

        public ActionResult ProfileCreate()
        {
            return View("~/Views/Home/Profile/Create.cshtml");
        }

        public ActionResult ProfileEdit()
        {
            return View("~/Views/Home/Profile/Edit.cshtml");
        }

        public ActionResult ProfileDashboard()
        {
            return View("~/Views/Home/Profile/Dashboard.cshtml");
        }

        public ActionResult CreateOrNot()
        {
            return View("~/Views/Home/Organization/CreateOrNot.cshtml");
        }

        public ActionResult Organization()
        {
            return View("~/Views/Home/Organization/Index.cshtml");
        }

        public ActionResult OrganizationCreate()
        {
            return View("~/Views/Home/Organization/Create.cshtml");
        }

        public ActionResult OrganizationEdit()
        {
            return View("~/Views/Home/Organization/Edit.cshtml");
        }

        public ActionResult OrganizationDashboard()
        {
            return View("~/Views/Home/Organization/Dashboard.cshtml");
        }

        public ActionResult OrganizationProjectAll()
        {
            return View("~/Views/Home/Organization/Project/All.cshtml");
        }

        public ActionResult OrganizationProjectCreate()
        {
            return View("~/Views/Home/Organization/Project/Create.cshtml");
        }

        public ActionResult OrganizationProjectEdit()
        {
            return View("~/Views/Home/Organization/Project/Edit.cshtml");
        }
    }
}
