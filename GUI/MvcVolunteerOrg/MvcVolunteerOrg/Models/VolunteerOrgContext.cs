using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using System.Data.Entity;

namespace MvcVolunteerOrg.Models
{
    public class VolunteerOrgContext : DbContext
    {
        // Initialize Database from different classes.
        DbSet<User> Users { get; set; }
        DbSet<Organization> Organizations { get; set; }
        DbSet<VolunteerProject> VolunteerProjects { get; set; }
        DbSet<Match> Matches { get; set; }
    }
}