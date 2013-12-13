﻿using System;
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

            ViewBag.Authenticated = WebSecurity.IsAuthenticated;

            if (WebSecurity.IsAuthenticated)
            {
                User currentUser = GetCurrentUser();
                ViewBag.Title = "";
                if (currentUser.GetType() == typeof(Volunteer))
                {
                    Volunteer volunteerUser = currentUser as Volunteer;
                    if (volunteerUser.GetInvites() != null)
                        ViewBag.Invites = volunteerUser.GetInvites();

                    List<VolunteerProject> projectSuggestions = new List<VolunteerProject>();
                    foreach (Match match in volunteerUser.GetSortMatches())
                    {
                        projectSuggestions.Add(match.Project);
                    }
                    ViewBag.Suggestions = projectSuggestions;
                    ViewBag.Accepted = volunteerUser.GetAcceptedMatches();
                }
                else
                {
                    ViewBag.Invites = new List<Model.Invite>();
                    ViewBag.Suggestions = new List<Model.Match>();
                    ViewBag.Accepted = new List<Model.Match>();
                }

            }
            else
            {
                ViewBag.Title = "Welcome";
                ViewBag.Suggestions = db.VolunteerProjects.OrderBy(p => p.Time).Take(5);
            }

            return View();
        }

        public ActionResult Project(int id = 0)
        {
            VolunteerProject project = db.VolunteerProjects
                .Include("Owner")
                .Include("Location")
                .Include("ProjectTopics")
                .Include("Matches")
                .Include("Matches.Volunteer")
                .Where(v => v.Id == id)
                .FirstOrDefault();

            if (project == null)
                return HttpNotFound();

            return View(project);
        }

        public ActionResult Projects()
        {
            ViewBag.Title = "List of Volunteer Projects";
            var projects = db.VolunteerProjects.Include(p => p.Owner);
            projects = projects.Include(p => p.ProjectTopics);
            return View(projects.ToList());
        }

        public ActionResult Organization(int id = 0)
        {
            var organization = db.Organizations
                .Include("VolunteerProjects")
                .Include("Location")
                .Where(o => o.Id == id)
                .FirstOrDefault();

            if (organization == null)
                return HttpNotFound();

            return View(organization);
        }

        public ActionResult Organizations()
        {
            ViewBag.Title = "List of Organizations";
            var organizations = db.Organizations;
            return View(organizations.ToList());
        }

        /*public ActionResult JoinProject(int id)
        {
            if (!WebSecurity.IsAuthenticated)
                return RedirectToAction("index", "home");

            User tempUser = GetCurrentUser();
            if (tempUser.GetType() == typeof(Volunteer))
            {

                Volunteer currentUser = tempUser as Volunteer;
                VolunteerProject project = db.VolunteerProjects.Find(id);
        }*/

        public ActionResult Volunteer(int id = 0)
        {
            Volunteer volunteer = db.Volunteers
                .Include("Matches")
                .Include("Matches.Project")
                .Include("Location")
                .Include("VolunteerPreferences")
                .Where(v => v.ID == id)
                .FirstOrDefault();

            if (volunteer == null)
                return HttpNotFound();

            return View(volunteer);
        }

        public ActionResult Volunteers()
        {
            ViewBag.Title = "List of Volunteers";
            var volunteers = db.Volunteers;
            return View(volunteers.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult ProfileIndex()
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

        private User GetCurrentUser()
        {
            Volunteer hej = db.Volunteers.ToList().Where(v => v.UserName.ToLower() == WebSecurity.CurrentUserName.ToLower()).FirstOrDefault();
            if (hej != null)
            {
                return hej as User;
            }
            Admin hej2 = db.Admins.ToList().Where(a => a.UserName.ToLower() == WebSecurity.CurrentUserName.ToLower()).FirstOrDefault();
            if (hej2 != null)
            {
                return hej2 as User;
            }
            return null;
        }
    }
}
