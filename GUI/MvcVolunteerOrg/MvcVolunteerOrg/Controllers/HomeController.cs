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
            //Adding dummy objects to database
            using (var db = new VolunteerOrgContext()
            {
                db.Database.ExecuteSqlCommand("delete from VolunteerProjects");
                
                Organization o1 = new Organization("Green", new Location("Lundvej 2", "Aalborg"), "contact@green.com");
                Organization o2 = new Organization("Blue", new Location("Strandsevej 53", "Aalborg"), "contact@blue.com");
                Organization o3 = new Organization("Red", new Location("Råbærvej 101", "Aalborg"), "contact@red.com");
            
                db.Organizations.Add(o1);
                db.Organizations.Add(o2);
                db.Organizations.Add(o3);

                db.SaveChanges();
            }


            string name = WebSecurity.IsAuthenticated ? WebSecurity.CurrentUserName : "guest";
            ViewBag.Title = "Welcome " + name + ".";
            using (var db = new VolunteerOrgContext())
            {
                ViewBag.VolunteerProjects = db.VolunteerProjects.ToList().OrderBy(b => b.Time);
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
