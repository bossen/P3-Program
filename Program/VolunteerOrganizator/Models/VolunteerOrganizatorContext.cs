using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using System.Data.Entity;

namespace VolunteerOrganizator.Models
{
    public class VolunteerOrganizatorContext : DbContext
    {
        // Initialize Database from different classes.
        DbSet<User> Users { get; set; }
        DbSet<Organization> Organizations { get; set; }
    }
}