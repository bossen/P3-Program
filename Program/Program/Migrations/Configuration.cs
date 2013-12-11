namespace Model.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Model.VolunteerOrgContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Model.VolunteerOrgContext context)
        {
            context.Volunteers.AddOrUpdate(i => i.Name,
                new Volunteer
                {
                    UserName = "Spinkelben",
                    Password = "123456",
                    Name = "Søren",
                    Creation = DateTime.Parse("1992-05-05"),
                    Email = "hej@mail.dk",
                    IsAdmin = false,
                    Location = new Location("blah gade 1", "Blah blah By"),
                    Preferences = new List<Preference>(),
                    _matches = new List<Match>()

                }
            );


            context.Organizations.AddOrUpdate(i => i.Name,
                new Organization
                {
                    Name = "Omvendt Kors",
                    Creation = DateTime.Parse("1996-06-06"),
                    Location = new Location("Main street 1", "Townsville"),
                    Email = "mail@kors.dk"
                }
            );
            context.SaveChanges();
            context.VolunteerProjects.AddOrUpdate(i => i.Title,
                new VolunteerProject
                {
                    Owner = context.Organizations.FirstOrDefault(x => x.Name == "Omvendt Kors"),
                    Title = "Kors Rotering",
                    Location = new Location("Main street 2", "Townsville"),
                    Time = DateTime.Parse("2013-12-25"),
                    Topics = new List<Preference>(),
                    Description = "Vi roterer kors på jesu fødselsdag"

                }
            );

            context.SaveChanges();
            context.WorkRequest.AddOrUpdate(i => i.Id,
                new WorkRequest
                {
                    Id = 1,
                    Accepted = false,
                    Score = 50,
                    Expire = context.VolunteerProjects.FirstOrDefault(vp => vp.Title == "Kors Rotering").Time,
                    Project = context.VolunteerProjects.FirstOrDefault(y => y.Title == "Kors Rotering"),
                    Volunteer = context.Volunteers.FirstOrDefault(x => x.UserName == "Spinkelben")
                }
            );
            context.SaveChanges();
            //context.Volunteers.AddOrUpdate(i => i.Name,
            //    new Volunteer
            //    {
            //        _matches = new List<Match>() { context.WorkRequest.FirstOrDefault(x => x.Id == 1) }
            //    }
            //);
        }
    }
}
