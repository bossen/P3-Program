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
            //Volunteer v1 = new Volunteer("jack", "jack", new Location("råbaaavejen 22", "rødeskovkildelyst"), "nice@mail.dk");
            //Organization o1 = new Organization("green", new Location("address", "city"), "mail@mail.dk");
            //VolunteerProject vp1 = o1.CreateProject("title", new Location("address", "city"), DateTime.Now.AddDays(2), new List<Preference>() { Preference.Church }, "description");
            //Suggestion s1 = v1.AddSuggestion(vp1);
            //db.VolunteerProjects.Add(vp1);
            //Volunteer ole = db.Volunteers.ToList().Where(v => v.UserName.ToLower() == "spinkelben").FirstOrDefault();
            //ole.AddSuggestion(vp1);
            //Invite i1 = new Invite(ole, vp1);
            //ole.AddMatch(i1);

            //db.Organizations.Add(o1);
            //db.Volunteers.Add(v1);
            //db.SaveChanges();

            ViewBag.Authenticated = WebSecurity.IsAuthenticated;

            if (WebSecurity.IsAuthenticated)
            {
                Volunteer currentUser = GetCurrentUser();
                ViewBag.Title = "";

                if (currentUser.GetInvites() != null)
                    ViewBag.Invites = currentUser.GetInvites();

                List<VolunteerProject> projectSuggestions = new List<VolunteerProject>();
                foreach (Match match in currentUser.GetSortMatches())
	            {
                    projectSuggestions.Add(match.Project);
	            }
                ViewBag.Suggestions = projectSuggestions;
                ViewBag.Accepted = currentUser.GetAcceptedMatches();
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
            VolunteerProject project = db.VolunteerProjects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
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
                .Where(o => o.Id == id)
                .FirstOrDefault();

            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        public ActionResult Organizations()
        {
            ViewBag.Title = "List of Organizations";
            var organizations = db.Organizations;
            return View(organizations.ToList());
        }

        public ActionResult JoinProject(int id)
        {
            if (!WebSecurity.IsAuthenticated)
                return RedirectToAction("index", "home");

            Volunteer currentUser = GetCurrentUser();
            VolunteerProject project = db.VolunteerProjects.Find(id);

            currentUser.AddWorkRequest(project);
            db.Entry(currentUser).State = EntityState.Modified;
            db.Entry(project).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("project", "home", new { id = project.Id });

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

        private Volunteer GetCurrentUser()
        {
            return db.Volunteers.ToList().Where(v => v.UserName.ToLower() == WebSecurity.CurrentUserName.ToLower()).FirstOrDefault();
        }
    }
}
