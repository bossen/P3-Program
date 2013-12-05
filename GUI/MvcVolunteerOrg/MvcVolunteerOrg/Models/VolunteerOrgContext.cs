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
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<VolunteerProject> VolunteerProjects { get; set; }
        public DbSet<Match> Matches { get; set; }
        
        
    }
}