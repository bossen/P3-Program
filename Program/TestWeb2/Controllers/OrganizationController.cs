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

        public ActionResult CreateOrNot()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id = 0)
        {
            Organization organization = db.Organizations.Find(id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        public ActionResult Dashboard()
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
