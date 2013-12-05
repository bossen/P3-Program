using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;
using System.Data.Entity;
using MvcVolunteerOrg.Models;
using System.Diagnostics;
using Model;
using System.Data.Entity.Validation;

namespace MvcVolunteerOrg.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string name = WebSecurity.IsAuthenticated ? WebSecurity.CurrentUserName : "guest";
            ViewBag.Title = "Welcome " + name + ".";

            Organization o = new Organization("greeny", new Location("a", "c"), "mail@mail.mail");
            VolunteerProject p1 = new VolunteerProject("Project 1", new Location("location", "city"), DateTime.Now.AddDays(5), new List<Preference>() { Preference.Festival }, o, "omg omg omg", true);
            VolunteerProject p2 = new VolunteerProject("Project 2", new Location("location", "city"), DateTime.Now.AddDays(3), new List<Preference>() { Preference.Festival }, o, "omg omg omg", true);
            VolunteerProject p3 = new VolunteerProject("Project 3", new Location("location", "city"), DateTime.Now.AddDays(2), new List<Preference>() { Preference.placeholder, Preference.Church }, o, "omg omg omg", true);
            VolunteerProject p4 = new VolunteerProject("Project 4", new Location("location", "city"), DateTime.Now.AddDays(10), new List<Preference>() { Preference.Festival }, o, "omg omg omg", true);
            VolunteerProject p5 = new VolunteerProject("Project 5", new Location("location", "city"), DateTime.Now.AddDays(1), new List<Preference>() { Preference.Festival }, o, "omg omg omg", true);
            using (var db = new VolunteerOrgContext())
            {
                db.Database.ExecuteSqlCommand("delete from VolunteerProjects");
                db.VolunteerProjects.Add(p1);
                db.VolunteerProjects.Add(p2);
                db.VolunteerProjects.Add(p3);
                db.VolunteerProjects.Add(p4);
                db.VolunteerProjects.Add(p5);
                if (WebSecurity.IsAuthenticated)
                {
                    ViewBag.Authenticated = true;
                    /*Volunteer currentUser = (Volunteer)db.Volunteers.ToList().Where(v => v.UserId == WebSecurity.CurrentUserId);
                    var SuggestedProjects = (from p in currentUser.GetPendingMatches()
                                            orderby p.Expire
                                            select p).Take(5);

                    ViewBag.Projects = SuggestedProjects;*/
                    ViewBag.Projects = db.VolunteerProjects.ToList().OrderBy(b => b.Time).Take(5);
                    foreach (User u in db.Volunteers)
                    {
                        Debug.WriteLine(u.Name);
                    }
                }
                else
                {
                    ViewBag.Authenticated = false;
                    ViewBag.Projects = db.VolunteerProjects.ToList().OrderBy(b => b.Time).Take(5);
                }
            }

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Preferences()
        {
            return View();
        }
    }
}
