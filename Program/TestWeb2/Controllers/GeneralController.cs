using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Model;

namespace TestWeb2.Controllers
{
    public class GeneralController : Controller
    {
        private VolunteerOrgContext db = new VolunteerOrgContext();
        //
        // GET: /General/

        public ActionResult Index()
        {
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
    }
}
