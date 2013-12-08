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
