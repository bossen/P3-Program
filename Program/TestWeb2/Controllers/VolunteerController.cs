using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using WebMatrix.WebData;
using System.Web.Security;

namespace TestWeb2.Controllers
{
    public class VolunteerController : Controller
    {
        private VolunteerOrgContext db = new VolunteerOrgContext();
        //
        // GET: /Volunteer/

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            Volunteer volunteer = db.Volunteers.Find(id);
            if (volunteer == null)
            {
                return HttpNotFound();
            }
            return View(volunteer);
        }

        [Authorize]
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

        [Authorize]
        public ActionResult Organizations()
        {
            ViewBag.Title = "List of Organizations";
            var organizations = db.Organizations;
            return View(organizations.ToList());
        }

        [Authorize]
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}
