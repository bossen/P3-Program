﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using WebMatrix.WebData;
using System.Data.Entity;

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
            ViewBag.IsAdmin = true;
            Admin currentUser = GetCurrentUser();
            int id = currentUser.Association.Id;
            var organization = db.Organizations
                .Include("VolunteerProjects")
                .Include("Location")
                .Where(o => o.Id == id)
                .FirstOrDefault();

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
                return View(organization);
            }
            
        }

        [Authorize]
        public ActionResult AllProjects()
        {
            ViewBag.IsAdmin = true;
            Admin currentUser = GetCurrentUser();
            int id = currentUser.Association.Id;

            Organization organization = db.Organizations
                .Include("VolunteerProjects")
                .Include("Location")
                .Where(v => v.Id == id)
                .FirstOrDefault();
            return View(organization.VolunteerProjects.ToList());
        }

        [Authorize]
        public ActionResult CreateProject()
        {
            ViewBag.IsAdmin = true;

            var topics = new List<Topic>();
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProject(VolunteerProject project)
        {
            ViewBag.IsAdmin = true;
            Admin currentUser = GetCurrentUser();
            
            if (ModelState.IsValid && currentUser != null)
            {
                project.Owner = currentUser.Association;
                db.VolunteerProjects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index", "Organization");
            }

            return View(project);
        }

        [Authorize]
        public ActionResult Volunteer(int id = 0)
        {
            ViewBag.IsAdmin = true;
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
            ViewBag.IsAdmin = true;
            ViewBag.Title = "List of Volunteers";
            var volunteers = db.Volunteers;
            return View(volunteers.ToList());
        }

        public ActionResult EditProject(int id)
        {
            ViewBag.IsAdmin = true;
            //List<string> topics = getTopic.GetValidTopics();

            VolunteerProject project = db.VolunteerProjects
                .Include("Owner")
                .Include("Location")
                .Include("ProjectTopics")
                .Include("Matches")
                .Where(v => v.Id == id)
                .FirstOrDefault();

            if (project == null)
            {
                return HttpNotFound();
            }

            return View(project);
        }

        [HttpPost]
        public ActionResult EditProject(VolunteerProject volunteerproject, int id)
        {
            ViewBag.IsAdmin = true;
            VolunteerProject project = db.VolunteerProjects.Find(id);
            if (ModelState.IsValid && project != null)
            {
                
                project.Title = volunteerproject.Title;
                project.Time = volunteerproject.Time;
                project.Signup = volunteerproject.Signup;
                project.Description = volunteerproject.Description;
                project.Location = volunteerproject.Location;

                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DetailsProject", "Organization", new { id = project.Id });
            }
            return View(volunteerproject);
        }

        public ActionResult DetailsProject(int id)
        {
            ViewBag.IsAdmin = true;
            Admin currentUser = GetCurrentUser();
            VolunteerProject project = db.VolunteerProjects
                .Include("Owner")
                .Include("Location")
                .Include("ProjectTopics")
                .Include("Matches")
                .Where(v => v.Id == id)
                .FirstOrDefault();
            var organization = db.Organizations
                .Include("VolunteerProjects")
                .Where(o => o.Id == id)
                .FirstOrDefault();
            
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        public ActionResult CancelProject()
        {
            ViewBag.IsAdmin = true;
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
