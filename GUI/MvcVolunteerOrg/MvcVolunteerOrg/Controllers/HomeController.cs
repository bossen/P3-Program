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
            using (var db = new VolunteerOrgContext())
            {
                db.Database.ExecuteSqlCommand("delete from VolunteerProjects");
                db.SaveChanges();
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
