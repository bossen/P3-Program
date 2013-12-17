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

            List<Volunteer> volunteers = new List<Volunteer>() {
                new Volunteer
                {
                    ID = 1,
                    UserName = "Spinkelben",
                    Password = "123456",
                    Name = "Søren R",
                    Creation = DateTime.Parse("1992-05-05"),
                    Email = "hej@mail.dk",
                    IsAdmin = false,
                    Location = new Location("blah gade 1", "Blah blah By"),
                    Matches = new List<Match>(),
                    VolunteerPreferences = new Topic { Church = true }
                }
            };


            List<Organization> organizations = new List<Organization>()
            {
                new Organization
                {
                    Id = 1,
                    Name = "Aalborg Eventclub",
                    Creation = DateTime.Parse("2012-06-06"),
                    Location = new Location("Christiansgade 10", "Aalborg"),
                    Email = "email@bold.dk"
                }
 
            };

            List<VolunteerProject> projects = new List<VolunteerProject>()
            {
                new VolunteerProject
                {
                    Id = 1,
                    Owner = organizations.Find(o => o.Id == 1),
                    Title = "Fodbold For 12-15 årige",
                    Location = new Location("Torvegade 3", "Aalborg"),
                    Time = DateTime.Parse("2013-12-25"),
                    Description = "Vi søger to fodbold trænere til dette hold.",
                    ProjectTopics = new Topic { Sport = true },
                    Signup = true
                },

                new VolunteerProject
                {
                    Id = 2,
                    Owner = organizations.Find(o => o.Id == 1),
                    Title = "Kirkegang",
                    Location = new Location("Christansgade 10", "Aalborg"),
                    Time = DateTime.Parse("2013-12-25"),
                    Description = "Det er her det sker.",
                    ProjectTopics = new Topic { Church = true },
                    Signup = true
                },

                new VolunteerProject
                {
                    Id = 3,
                    Owner = organizations.Find(o => o.Id == 1),
                    Title = "Svømmetime",
                    Location = new Location("Lollandsgade 17", "Aalborg"),
                    Time = DateTime.Parse("2013-12-25"),
                    Description = "Hjælp jeg er en fisk.",
                    ProjectTopics = new Topic { Sport = true },
                    Signup = true
                }
            };

            List<WorkRequest> workrequests = new List<WorkRequest>()
            {
                new WorkRequest
                {
                    Id = 1,
                    Accepted = true,
                    Score = 50,
                    Expire = projects.Find(p => p.Id == 1).Time,
                    Project = projects.Find(p => p.Id == 1),
                    Volunteer = volunteers.Find(v => v.ID == 1)
                }
            };

            List<Invite> invites = new List<Invite>()
            {
                new Invite
                {
                    Id = 2,
                    Accepted = null,
                    Score = 50,
                    Expire = projects.Find(p => p.Id == 2).Time,
                    Project = projects.Find(p => p.Id == 2),
                    Volunteer = volunteers.Find(v => v.ID == 1)
                }
            };

            List<Admin> admins = new List<Admin>()
            {
                new Admin 
                {
                    ID = 1,
                    Association = organizations.Find(o => o.Id == 1),
                    Creation = DateTime.Parse("2012-03-07"),
                    Email = "John@kors.dk",
                    IsAdmin = true,
                    Location = new Location("Badehusvej 13","Aalborg"),
                    Name = "John Andersen",
                    UserName = "John9000"
                }
            };

            volunteers.Find(v => v.ID == 1).AddMatch(workrequests.Find(w => w.Id == 1));

            volunteers.ForEach(v => context.Volunteers.AddOrUpdate(p => p.UserName, v));
            context.SaveChanges();
            organizations.ForEach(o => context.Organizations.AddOrUpdate(p => p.Name, o));
            context.SaveChanges();
            projects.ForEach(p => context.VolunteerProjects.AddOrUpdate(q => q.Title, p));
            context.SaveChanges();
            workrequests.ForEach(w => context.WorkRequest.AddOrUpdate(x => x.Id, w));
            context.SaveChanges();
            invites.ForEach(i => context.Matches.AddOrUpdate(x => x.Id, i));
            context.SaveChanges();
            admins.ForEach(a => context.Admins.AddOrUpdate(b => b.UserName, a));
            context.SaveChanges();

        }
    }
}
