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
        //    //Adding dummy objects to database
        //    using (var db = new VolunteerOrgContext())
        //    {
        //        db.Database.ExecuteSqlCommand("delete from VolunteerProjects");

        //        Organization o1 = new Organization("Green", new Location("Lundvej 2", "Aalborg"), "contact@green.com");
        //        Organization o2 = new Organization("Blue", new Location("Strandsevej 53", "Aalborg"), "contact@blue.com");
        //        Organization o3 = new Organization("Red", new Location("Råbærvej 101", "CPH"), "contact@red.com");

        //        VolunteerProject p1 = new VolunteerProject("Project 1", new Location("location", "city"), DateTime.Now.AddDays(5), new List<Preference>() { Preference.Festival }, o1, "omg omg omg", true);
        //        VolunteerProject p2 = new VolunteerProject("Project 2", new Location("location", "city"), DateTime.Now.AddDays(3), new List<Preference>() { Preference.Festival }, o2, "omg omg omg", true);
        //        VolunteerProject p3 = new VolunteerProject("Project 3", new Location("location", "city"), DateTime.Now.AddDays(2), new List<Preference>() { Preference.placeholder, Preference.Church }, o2, "omg omg omg", true);
        //        VolunteerProject p4 = new VolunteerProject("Project 4", new Location("location", "city"), DateTime.Now.AddDays(10), new List<Preference>() { Preference.Festival }, o3, "omg omg omg", true);
        //        VolunteerProject p5 = new VolunteerProject("Project 5", new Location("location", "city"), DateTime.Now.AddDays(1), new List<Preference>() { Preference.Festival }, o2, "omg omg omg", true);

        //        db.Organizations.Add(o1);
        //        db.Organizations.Add(o2);
        //        db.Organizations.Add(o3);

        //        db.VolunteerProjects.Add(p2);
        //        db.VolunteerProjects.Add(p3);
        //        db.VolunteerProjects.Add(p4);
        //        db.VolunteerProjects.Add(p5);
        //        db.VolunteerProjects.Add(p1);

        //        db.SaveChanges();
        //    }


            string name = WebSecurity.IsAuthenticated ? WebSecurity.CurrentUserName : "guest";
            ViewBag.Title = "Welcome " + name + ".";

            using (var db = new VolunteerOrgContext())
            {
                if (WebSecurity.IsAuthenticated)
                {
                    ViewBag.Authenticated = true;
                    Volunteer currentUser = db.Volunteers.Where(v => v.UserId == WebSecurity.CurrentUserId).First();

                    Debug.WriteLine(currentUser.Id);
                    if (currentUser.GetPendingMatches()[0] != null)
                    {
                        var SuggestedProjects = (from p in currentUser.GetPendingMatches()
                                                 orderby p.Expire
                                                 select p).Take(5);

                        ViewBag.Projects = SuggestedProjects;
                    }
                    foreach (User u in db.Volunteers)
                    {
                        Debug.WriteLine(u.Name);
                    }
                    ViewBag.Projects = db.VolunteerProjects.ToList().OrderBy(b => b.Time).Take(5);
                }
                else
                {
                    ViewBag.Authenticated = false;
                    var test = db.VolunteerProjects.ToList();
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
