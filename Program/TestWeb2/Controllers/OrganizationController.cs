using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace TestWeb2.Controllers
{
    public class OrganizationController : Controller
    {
        private VolunteerOrgContext db = new VolunteerOrgContext();
        //
        // GET: /Organization/

        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult AllProjects()
        {
            return View();
        }

        public ActionResult CreateProject()
        {
            return View();
        }

        public ActionResult Volunteer(int id = 0)
        {
            Volunteer volunteer = db.Volunteers
                .Include("Matches")
                .Include("Matches.Project")
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

        public ActionResult EditProject(int id = 0)
        {
            VolunteerProject volunteerProject = db.VolunteerProjects.Find(id);
            if (volunteerProject == null)
            {
                return HttpNotFound();
            }
            return View(volunteerProject);
        }

    }
}
