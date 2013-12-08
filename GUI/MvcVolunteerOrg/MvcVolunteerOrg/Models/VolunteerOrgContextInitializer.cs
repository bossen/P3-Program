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
                Organization o1 = new Organization()
                {
                    Name = "Green Plus",
                    Id = 1,
                    Email = "GreenPlus@greenplus.dk",
                    Creation = DateTime.Now,
                    Location = new Location("Green Road 42", "Green City")
                };
                context.Organizations.Add(o1);

                
                Organization o2 = new Organization()
                {
                    Name = "Blue Plus",
                    Id = 2,
                    Email = "BluePlus@blueplus.dk",
                    Creation = DateTime.Now,
                    Location = new Location("Blue Road 42", "Blue City")
                };
                context.Organizations.Add(o2);

                context.Volunteers.Add(
                    new Volunteer()
                    {
                        Name = "Lukas",
                        Creation = DateTime.Now,
                        Email = "Lukas@Volunteer.dk",
                        Id = 1,
                        Location = new Location("Volunteer Street 1", "Volunteertown"),
                        UserId = 1,
                        Preferences = new List<Preference>() {Preference.Church, Preference.Festival, Preference.Sport}
                    });
                context.Volunteers.Add(
                    new Volunteer()
                    {
                        Name = "Jannek",
                        Creation = DateTime.Now,
                        Email = "Jannek@Volunteer.dk",
                        Id = 2,
                        Location = new Location("Volunteer Street 2", "Volunteertown"),
                        UserId = 2,
                        Preferences = new List<Preference>() {Preference.Festival, Preference.Political}
                    });

                context.VolunteerProjects.Add(
                    new VolunteerProject()
                    {
                        Owner = o1,
                        Id = 1,
                        Description = "This is about helping YOUNG people",
                        Title = "Helping YOUNG People",
                        Location = new Location("Project Street 1", "Project city"),
                        Time = DateTime.Today,
                        Topics = new List<Preference>() {Preference.Culture, Preference.Sport},
                        //Matches needed----- ???
                    });

                context.VolunteerProjects.Add(
                    new VolunteerProject()
                    {
                        Owner = o1,
                        Id = 2,
                        Description = "This is about helping OLD people",
                        Title = "Helping OLD People",
                        Location = new Location("Project Street 2", "Project city"),
                        Time = DateTime.Today,
                        Topics = new List<Preference>() {Preference.Church, Preference.Nature}
                        //Matches = "", -------List of Matches?
                    });

                context.VolunteerProjects.Add(
                    new VolunteerProject()
                    {
                        Owner = o1,
                        Id = 3,
                        Description = "This is about helping Music!!!",
                        Title = "Helping Music",
                        Location = new Location("Project Street 3", "Project city"),
                        Time = DateTime.Today,
                        Topics = new List<Preference>() {Preference.Culture, Preference.Festival}
                        //Matches = "", -------List of Matches?
                    });

                context.VolunteerProjects.Add(
                    new VolunteerProject()
                    {
                        Owner = o2,
                        Id = 4,
                        Description = "PARTY PARTY",
                        Title = "Helping at a church",
                        Location = new Location("Project Street 4", "Project city"),
                        Time = DateTime.Today,
                        Topics = new List<Preference>() {Preference.Festival, Preference.Political}
                        //Matches = "", -------List of Matches?
                    });

                context.VolunteerProjects.Add(
                    new VolunteerProject()
                    {
                        Owner = o2,
                        Id = 5,
                        Description = "Placeholder",
                        Title = "Placeholder",
                        Location = new Location("Project Street 5", "Project city"),
                        Time = DateTime.Today,
                        Topics = new List<Preference>() {Preference.Church, Preference.Culture, Preference.Festival, Preference.Nature, Preference.Political, Preference.Sport}
                        //Matches = "", -------List of Matches?
                    });










            context.Admins.Add(
                new Admin()
                {
                    Id = 1,
                    UserId = 1,
                    Name = "Patrick",
                    Email = "Adminpat@admin.dk",
                    Creation = DateTime.Now,
                    Location = new Location("Admin Path 7", "Admin Universe"),
                    Association = o1
                });

            context.Admins.Add(
                new Admin()
                {
                    Id = 2,
                    UserId = 2,
                    Name = "Mike",
                    Email = "Adminmike@admin.dk",
                    Creation = DateTime.Now,
                    Location = new Location("Admin Path 8", "Admin Universe"),
                    Association = o2
                });





            context.SaveChanges();
        }
    }
}