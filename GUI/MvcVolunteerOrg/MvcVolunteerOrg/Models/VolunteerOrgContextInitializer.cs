using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Model;

namespace MvcVolunteerOrg.Models
{
    public class VolunteerOrgContextInitializer : DropCreateDatabaseAlways<VolunteerOrgContext>
    {
        protected override void Seed(VolunteerOrgContext context)
        {
            context.Organizations.Add(
                new Organization()
                {
                    Name = "Green Plus",
                    Id = 1,
                    Email = "GreenPlus@greenplus.dk",
                    Creation = DateTime.Now,
                    Location = new Location("Green Road 42", "Green City")
                });

            context.Organizations.Add(
                new Organization()
                {
                    Name = "Blue Plus",
                    Id = 2,
                    Email = "BluePlus@blueplus.dk",
                    Creation = DateTime.Now,
                    Location = new Location("Blue Road 42", "Blue City")
                });

            context.Volunteers.Add(
                new Volunteer()
                {
                    Name = "Lukas",
                    Username = "Lukas",
                    Creation = DateTime.Now,
                    Email = "Lukas@Volunteer.dk",
                    Id = 1,
                    Location = new Location("Volunteer Street 1", "Volunteertown"),
                    UserId = 1,
                    //Missing Preferences?????
                });
            context.Volunteers.Add(
                new Volunteer()
                {
                    Name = "Jannek",
                    Username = "Jannek",
                    Creation = DateTime.Now,
                    Email = "Jannek@Volunteer.dk",
                    Id = 2,
                    Location = new Location("Volunteer Street 2", "Volunteertown"),
                    UserId = 2,
                    //Missing Preferences?????
                });

            context.VolunteerProjects.Add(
                new VolunteerProject()
                {
                    Owner = new Organization(),
                    Id = 1,
                    Description = "This is about helping YOUNG people",
                    Title = "Helping YOUNG People",
                    Location = new Location("Project Street 1", "Project city"),
                    Time = DateTime.Today,
                    //Topics = "",  -------List of Topics?
                    //Matches = "", -------List of Matches?
                });
            
            context.VolunteerProjects.Add(
                new VolunteerProject()
                {
                    //Owner = "", -------- Owner?
                    Id = 2,
                    Description = "This is about helping OLD people",
                    Title = "Helping OLD People",
                    Location = new Location("Project Street 2", "Project city"),
                    Time = DateTime.Today,
                    //Topics = "",  -------List of Topics?
                    //Matches = "", -------List of Matches?
                });

            context.VolunteerProjects.Add(
                new VolunteerProject()
                {
                    //Owner = "", -------- Owner?
                    Id = 3,
                    Description = "This is about helping Music!!!",
                    Title = "Helping Music",
                    Location = new Location("Project Street 3", "Project city"),
                    Time = DateTime.Today,
                    //Topics = "",  -------List of Topics?
                    //Matches = "", -------List of Matches?
                });

            context.VolunteerProjects.Add(
                new VolunteerProject()
                {
                    //Owner = "", -------- Owner?
                    Id = 4,
                    Description = "PARTY PARTY",
                    Title = "Helping at a church",
                    Location = new Location("Project Street 4", "Project city"),
                    Time = DateTime.Today,
                    //Topics = "",  -------List of Topics?
                    //Matches = "", -------List of Matches?
                });

            context.VolunteerProjects.Add(
                new VolunteerProject()
                {
                    //Owner = "", -------- Owner?
                    Id = 5,
                    Description = "Placeholder",
                    Title = "Placeholder",
                    Location = new Location("Project Street 5", "Project city"),
                    Time = DateTime.Today,
                    //Topics = "",  -------List of Topics?
                    //Matches = "", -------List of Matches?
                });










            context.Admins.Add(
                new Admin()
                {
                    Id = 1,
                    UserId = 1,
                    Name = "Patrick",
                    Username = "AdminPat",
                    Email = "Adminpat@admin.dk",
                    Creation = DateTime.Now,
                    Location = new Location("Admin Path 7", "Admin Universe")
                });

            context.Admins.Add(
                new Admin()
                {
                    Id = 2,
                    UserId = 2,
                    Name = "Mike",
                    Username = "AdminMike",
                    Email = "Adminmike@admin.dk",
                    Creation = DateTime.Now,
                    Location = new Location("Admin Path 8", "Admin Universe")
                });





            context.SaveChanges();
        }
    }
}