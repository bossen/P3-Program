﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using WebMatrix.WebData;
using System.Web.Security;
using System.Data.Entity;

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
        public ActionResult Project(int id = 0)
        {
            VolunteerProject project = db.VolunteerProjects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            
            Volunteer currentUser = GetCurrentUser();
            ViewBag.Status = currentUser.GetStatusOfProject(project);
            return View(project);
        }

        [Authorize]
        public ActionResult Projects()
        {
            ViewBag.Title = "List of Volunteer Projects";
            var projects = db.VolunteerProjects.Include("Owner");
            return View(projects.ToList());
        }

        //[Authorize]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult JoinProject(int id)
        {
            Volunteer currentUser = GetCurrentUser();
            VolunteerProject project = db.VolunteerProjects.Find(id);
            
            currentUser.AddWorkRequest(project);
            db.Entry(currentUser).State = EntityState.Modified;
            db.Entry(project).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("project", "volunteer", new { id = project.Id });
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

        private Volunteer GetCurrentUser()
        {
            int id =  db.Volunteers.ToList().Where(v => v.UserName.ToLower() == WebSecurity.CurrentUserName.ToLower()).FirstOrDefault().ID;
            var volunteer = db.Volunteers
                .Include("Matches")
                .Where(v => v.ID == id)
                .FirstOrDefault();

            return volunteer;
        }
    }
}
