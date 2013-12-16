using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Model;
using System.Data.Entity;
using WebMatrix.WebData;
using TestWeb2.Models;

namespace TestWeb2.Controllers
{
    public class HomeController : Controller
    {
        IModelRepository _repository;
        ISecurityWrap _secWrap;
        public HomeController() : this(new EntityModelManagerRepository(), new WebSecurityProvider()) { }
        public HomeController(IModelRepository repository, ISecurityWrap secWrap)
        {
            _repository = repository;
            _secWrap = secWrap;
        }

        private VolunteerOrgContext db = new VolunteerOrgContext();

        public ActionResult Index()
        {

            ViewBag.Authenticated = _secWrap.IsAuthenticated();

            if (_secWrap.IsAuthenticated())
            {
                User currentUser = GetCurrentUser();
                ViewBag.Title = "";
                if (currentUser.GetType() == typeof(Volunteer))
                {
                    return RedirectToAction("index", "volunteer");
                }
                else if (currentUser.GetType() == typeof(Admin))
                {
                    return RedirectToAction("index", "admin");
                }

                ViewBag.Invites = new List<Model.Invite>();
                ViewBag.Suggestions = new List<Model.Match>();
                ViewBag.Accepted = new List<Model.Match>();

            }
            else
            {
                ViewBag.Title = "Welcome";
                ViewBag.Suggestions = _repository.GetAllProjects().OrderBy(p => p.Time).Take(5);

            }

            return View();
        }

        public ActionResult Project(int id = 0)
        {
            //VolunteerProject project = db.VolunteerProjects
            //    .Include("Owner")
            //    .Include("Location")
            //    .Include("ProjectTopics")
            //    .Include("Matches")
            //    .Include("Matches.Volunteer")
            //    .Where(v => v.Id == id)
            //    .FirstOrDefault();
            var project = _repository.GetProject(id);

            if (project == null)
                return HttpNotFound();

            return View(project);
        }

        public ActionResult Projects()
        {
            ViewBag.Title = "List of Volunteer Projects";
            //var projects = db.VolunteerProjects.Include(p => p.Owner);
            //projects = projects
            //    .Include(p => p.ProjectTopics)
            //    .Include("Location");
            var projects = _repository.GetAllProjects();
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
            var organizations = db.Organizations.Include("Location");
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
            var volunteers = db.Volunteers
                .Include("Location");
            return View(volunteers.ToList());
        }

        public ActionResult About()
        {
            
            ViewBag.Message = "Your app description page.";

            return View();
        }

        private User GetCurrentUser()
        {
            Volunteer user = _repository.GetAllVolunteers().Where(v => v.UserName.ToLower() == _secWrap.GetCurrentUserName().ToLower()).FirstOrDefault();
            if (user != null)
            {
                return user as User;
            }
            Admin user2 = _repository.GetAllAdmins().Where(a => a.UserName.ToLower() == _secWrap.GetCurrentUserName().ToLower()).FirstOrDefault();
            if (user2 != null)
            {
                return user2 as User;
            }
            return null;
        }
    }
}
