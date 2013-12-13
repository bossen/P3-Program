using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using WebMatrix.WebData;

namespace TestWeb2.Controllers
{
    public class OrganizationController : Controller
    {
        private VolunteerOrgContext db = new VolunteerOrgContext();
        //
        // GET: /Organization/

        [Authorize]
        public ActionResult Index()
        {
            Admin currentUser = GetCurrentUser();
            if (currentUser.Association == null)
            {
                return RedirectToAction("Index", "Admin");
            }
                
            else
            {
                if (currentUser.Association.VolunteerProjects == null)
                {
                    ViewBag.projectNull = true;
                }
                else 
                {
                    ViewBag.projectNull = false;
                }
                return View(currentUser);
            }
            
        }

        [Authorize]
        public ActionResult AllProjects(int id)
        {
            return View();
        }

        [Authorize]
        public ActionResult CreateProject()
        {
            return View();
        }

        [Authorize]
        public ActionResult EditProject(int id = 0)
        {
            VolunteerProject volunteerProject = db.VolunteerProjects.Find(id);
            if (volunteerProject == null)
            {
                return HttpNotFound();
            }
            return View(volunteerProject);
        }

        public ActionResult DetailsProject()
        {
            return View();
        }

        public ActionResult CancelProject()
        {
            return View();
        }


        private Admin GetCurrentUser()
        {
            int id = db.Admins.ToList().Where(v => v.UserName.ToLower() == WebSecurity.CurrentUserName.ToLower()).FirstOrDefault().ID;
            var admin = db.Admins
                .Include("Association")
                .Include("Association.VolunteerProjects")
                .Where(v => v.ID == id)
                .FirstOrDefault();

            return admin;
        }
    }
}
