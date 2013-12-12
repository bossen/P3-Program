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
    }
}
