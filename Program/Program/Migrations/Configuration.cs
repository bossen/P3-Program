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
                    Name = "Søren Rant",
                    Creation = DateTime.Parse("1992-05-05"),
                    Email = "SRant@mail.dk",
                    IsAdmin = false,
                    Location = new Location("Algade 15", "Aalborg"),
                    Matches = new List<Match>(),
                    VolunteerPreferences = new Topic { Church = true, Culture = true }
                },
                new Volunteer
                {
                    ID = 2,
                    UserName = "MrVolunteer",
                    Password = "123456",
                    Name = "Michael Plads",
                    Creation = DateTime.Parse("2013-05-08"),
                    Email = "MrVolunteer@mail.dk",
                    IsAdmin = false,
                    Location = new Location("Løkkegade 5", "Aalborg"),
                    Matches = new List<Match>(),
                    VolunteerPreferences = new Topic { Political = true, Festival = true }
                },
                new Volunteer
                {
                    ID = 3,
                    UserName = "VolunteerGirl",
                    Password = "123456",
                    Name = "Emma Manchio",
                    Creation = DateTime.Parse("2013-08-07"),
                    Email = "Mhmm@mail.dk",
                    IsAdmin = false,
                    Location = new Location("Bjerggade 7", "Nørresundby"),
                    Matches = new List<Match>(),
                    VolunteerPreferences = new Topic { Nature = true, Culture = true, Sport = true }
                },
                new Volunteer
                {
                    ID = 4,
                    UserName = "ChurchBoy",
                    Password = "123456",
                    Name = "Christian God",
                    Creation = DateTime.Parse("2000-01-01"),
                    Email = "GodChristian@mail.dk",
                    IsAdmin = false,
                    Location = new Location("Strandvejen 20", "Aalborg"),
                    Matches = new List<Match>(),
                    VolunteerPreferences = new Topic { Church = true }
                },
                new Volunteer
                {
                    ID = 5,
                    UserName = "NonSleeper",
                    Password = "123456",
                    Name = "Emmanuel Goldstein",
                    Creation = DateTime.Parse("2013-02-05"),
                    Email = "CerealKiller@mail.dk",
                    IsAdmin = false,
                    Location = new Location("Danmarksgade 17", "Aalborg"),
                    Matches = new List<Match>(),
                    VolunteerPreferences = new Topic { Festival = true, Political = true, Culture = true }
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
                },

                new Organization
                {
                    Id = 2,
                    Name = "Budolfi Church",
                    Creation = DateTime.Parse("2013-12-07"),
                    Location = new Location("Algade 40", "Aalborg"),
                    Email = "Budolfi@Budolfi.dk"
                },

                new Organization
                {
                    Id = 3,
                    Name = "Utzon Center",
                    Creation = DateTime.Parse("2011-06-12"),
                    Location = new Location("Slotspladsen 4", "Aalborg"),
                    Email = "Utzon@Utzon.dk"
                },

                new Organization
                {
                    Id = 4,
                    Name = "Beach Park Nørresundby",
                    Creation = DateTime.Parse("2013-08-02"),
                    Location = new Location("Thistedvej 2", "Aalborg"),
                    Email = "BPN@BPN.dk"
                }
 
            };

            List<VolunteerProject> projects = new List<VolunteerProject>()
            {
                new VolunteerProject
                {
                    Id = 1,
                    Owner = organizations.Find(o => o.Id == 1),
                    Title = "Football for 12-15 years",
                    Location = new Location("Scoresbysundvej 3", "Aalborg"),
                    Time = DateTime.Parse("2014-12-25"),
                    Description = "We're currently looking for two football trainers.",
                    ProjectTopics = new Topic { Sport = true },
                    Signup = true
                },

                new VolunteerProject
                {
                    Id = 2,
                    Owner = organizations.Find(o => o.Id == 1),
                    Title = "Swimming day",
                    Location = new Location("Willy Brandts Vej 31", "Aalborg"),
                    Time = DateTime.Parse("2014-02-18"),
                    Description = "Finding Nemo Swim day for all family with live music",
                    ProjectTopics = new Topic { Sport = true, Culture = true },
                    Signup = true
                },

                new VolunteerProject
                {
                    Id = 3,
                    Owner = organizations.Find(o => o.Id == 1),
                    Title = "Laser Tag Tournament",
                    Location = new Location("Vesterå 5", "Aalborg"),
                    Time = DateTime.Parse("2014-02-08"),
                    Description = "We are looking for people to help us keep score board.",
                    ProjectTopics = new Topic { Culture = true },
                    Signup = true
                },

                new VolunteerProject
                {
                    Id = 4,
                    Owner = organizations.Find(o => o.Id == 2),
                    Title = "Sunday Church",
                    Location = new Location("Algade 40", "Aalborg"),
                    Time = DateTime.Parse("2014-12-29"),
                    Description = "We'll be listening to God one last time this year before we go into a new year with god.",
                    ProjectTopics = new Topic { Church = true },
                    Signup = true
                },

                new VolunteerProject
                {
                    Id = 5,
                    Owner = organizations.Find(o => o.Id == 2),
                    Title = "General Meeting - Budolfi",
                    Location = new Location("Algade 35", "Aalborg"),
                    Time = DateTime.Parse("2014-02-20"),
                    Description = "We will have a general meeting to discuss the future of Budolfi Square and make it more interesting for people.",
                    ProjectTopics = new Topic { Political = true },
                    Signup = true
                },

                new VolunteerProject
                {
                    Id = 6,
                    Owner = organizations.Find(o => o.Id == 2),
                    Title = "Concert - Singing",
                    Location = new Location("Algade 40", "Aalborg"),
                    Time = DateTime.Parse("2014-12-24"),
                    Description = "We are having a concert on Christmas Eve and we need some to come sing.",
                    ProjectTopics = new Topic { Culture = true, Festival = true, Church = true },
                    Signup = true
                },

                new VolunteerProject
                {
                    Id = 7,
                    Owner = organizations.Find(o => o.Id == 3),
                    Title = "Segway Tour - Guides",
                    Location = new Location("Slotspladsen 4", "Aalborg"),
                    Time = DateTime.Parse("2014-04-28"),
                    Description = "We're in need a people to guide tourist around on segways and assisting them, while talking about culture and history.",
                    ProjectTopics = new Topic { Culture = true },
                    Signup = true
                },

                new VolunteerProject
                {
                    Id = 8,
                    Owner = organizations.Find(o => o.Id == 3),
                    Title = "Future of Culture - Meeting",
                    Location = new Location("Slotsgade 2", "Aalborg"),
                    Time = DateTime.Parse("2014-02-24"),
                    Description = "We invite people to come discuss the future of Culture in Aalborg.",
                    ProjectTopics = new Topic { Culture = true, Political = true },
                    Signup = false
                },

                new VolunteerProject
                {
                    Id = 9,
                    Owner = organizations.Find(o => o.Id == 3),
                    Title = "Spread the knowledge",
                    Location = new Location("Nytorv 5", "Aalborg"),
                    Time = DateTime.Parse("2014-02-17"),
                    Description = "We need as many we can get to spread the knowledge about Aalborg in all aspects.",
                    ProjectTopics = new Topic { Culture = true, Church = true, Festival = true, Nature = true, Political = true, Sport = true },
                    Signup = true
                },

                new VolunteerProject
                {
                    Id = 10,
                    Owner = organizations.Find(o => o.Id == 4),
                    Title = "Ice Bathing",
                    Location = new Location("Thistedvej 2", "Aalborg"),
                    Time = DateTime.Parse("2014-03-03"),
                    Description = "We hope a lot will be joining us in the first ice bathing of this year.",
                    ProjectTopics = new Topic { Culture = true, Nature = true },
                    Signup = false
                },

                new VolunteerProject
                {
                    Id = 11,
                    Owner = organizations.Find(o => o.Id == 4),
                    Title = "Glowing Frisbee Night",
                    Location = new Location("Thistedvej 3", "Aalborg"),
                    Time = DateTime.Parse("2014-12-31"),
                    Description = "Come celebrate the ending of the year with frisbee night and fireworks.",
                    ProjectTopics = new Topic { Sport = true, Culture = true },
                    Signup = true
                },

                new VolunteerProject
                {
                    Id = 12,
                    Owner = organizations.Find(o => o.Id == 4),
                    Title = "Green Concert - Booth",
                    Location = new Location("Vendilavej 11", "Aalborg"),
                    Time = DateTime.Parse("2014-06-20"),
                    Description = "We need people to come help in the booths and sell beverages and food.",
                    ProjectTopics = new Topic { Festival = true },
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
                    Volunteer = volunteers.Find(v => v.ID == 3)
                },

                new WorkRequest
                {
                    Id = 2,
                    Accepted = true,
                    Score = 50,
                    Expire = projects.Find(p => p.Id == 2).Time,
                    Project = projects.Find(p => p.Id == 2),
                    Volunteer = volunteers.Find(v => v.ID == 1)
                },

                new WorkRequest
                {
                    Id = 3,
                    Accepted = true,
                    Score = 50,
                    Expire = projects.Find(p => p.Id == 2).Time,
                    Project = projects.Find(p => p.Id == 2),
                    Volunteer = volunteers.Find(v => v.ID == 3)
                },

                new WorkRequest
                {
                    Id = 4,
                    Accepted = true,
                    Score = 50,
                    Expire = projects.Find(p => p.Id == 2).Time,
                    Project = projects.Find(p => p.Id == 2),
                    Volunteer = volunteers.Find(v => v.ID == 5)
                },

                new WorkRequest
                {
                    Id = 5,
                    Accepted = true,
                    Score = 50,
                    Expire = projects.Find(p => p.Id == 3).Time,
                    Project = projects.Find(p => p.Id == 3),
                    Volunteer = volunteers.Find(v => v.ID == 1)
                },

                new WorkRequest
                {
                    Id = 6,
                    Accepted = true,
                    Score = 50,
                    Expire = projects.Find(p => p.Id == 3).Time,
                    Project = projects.Find(p => p.Id == 3),
                    Volunteer = volunteers.Find(v => v.ID == 3)
                },

                new WorkRequest
                {
                    Id = 7,
                    Accepted = true,
                    Score = 50,
                    Expire = projects.Find(p => p.Id == 3).Time,
                    Project = projects.Find(p => p.Id == 3),
                    Volunteer = volunteers.Find(v => v.ID == 5)
                },

                new WorkRequest
                {
                    Id = 8,
                    Accepted = true,
                    Score = 50,
                    Expire = projects.Find(p => p.Id == 4).Time,
                    Project = projects.Find(p => p.Id == 4),
                    Volunteer = volunteers.Find(v => v.ID == 1)
                },

                new WorkRequest
                {
                    Id = 9,
                    Accepted = true,
                    Score = 50,
                    Expire = projects.Find(p => p.Id == 4).Time,
                    Project = projects.Find(p => p.Id == 4),
                    Volunteer = volunteers.Find(v => v.ID == 4)
                },

                new WorkRequest
                {
                    Id = 10,
                    Accepted = true,
                    Score = 50,
                    Expire = projects.Find(p => p.Id == 5).Time,
                    Project = projects.Find(p => p.Id == 5),
                    Volunteer = volunteers.Find(v => v.ID == 2)
                },

                new WorkRequest
                {
                    Id = 11,
                    Accepted = true,
                    Score = 50,
                    Expire = projects.Find(p => p.Id == 5).Time,
                    Project = projects.Find(p => p.Id == 5),
                    Volunteer = volunteers.Find(v => v.ID == 5)
                },

                new WorkRequest
                {
                    Id = 12,
                    Accepted = true,
                    Score = 50,
                    Expire = projects.Find(p => p.Id == 6).Time,
                    Project = projects.Find(p => p.Id == 6),
                    Volunteer = volunteers.Find(v => v.ID == 1)
                },

                new WorkRequest
                {
                    Id = 13,
                    Accepted = true,
                    Score = 50,
                    Expire = projects.Find(p => p.Id == 6).Time,
                    Project = projects.Find(p => p.Id == 6),
                    Volunteer = volunteers.Find(v => v.ID == 2)
                },

                new WorkRequest
                {
                    Id = 14,
                    Accepted = true,
                    Score = 50,
                    Expire = projects.Find(p => p.Id == 6).Time,
                    Project = projects.Find(p => p.Id == 6),
                    Volunteer = volunteers.Find(v => v.ID == 3)
                },

                new WorkRequest
                {
                    Id = 15,
                    Accepted = true,
                    Score = 50,
                    Expire = projects.Find(p => p.Id == 6).Time,
                    Project = projects.Find(p => p.Id == 6),
                    Volunteer = volunteers.Find(v => v.ID == 4)
                },

                new WorkRequest
                {
                    Id = 16,
                    Accepted = true,
                    Score = 50,
                    Expire = projects.Find(p => p.Id == 6).Time,
                    Project = projects.Find(p => p.Id == 6),
                    Volunteer = volunteers.Find(v => v.ID == 5)
                },

                new WorkRequest
                {
                    Id = 17,
                    Accepted = true,
                    Score = 50,
                    Expire = projects.Find(p => p.Id == 7).Time,
                    Project = projects.Find(p => p.Id == 7),
                    Volunteer = volunteers.Find(v => v.ID == 1)
                },

                new WorkRequest
                {
                    Id = 18,
                    Accepted = true,
                    Score = 50,
                    Expire = projects.Find(p => p.Id == 7).Time,
                    Project = projects.Find(p => p.Id == 7),
                    Volunteer = volunteers.Find(v => v.ID == 3)
                },

                new WorkRequest
                {
                    Id = 19,
                    Accepted = true,
                    Score = 50,
                    Expire = projects.Find(p => p.Id == 7).Time,
                    Project = projects.Find(p => p.Id == 7),
                    Volunteer = volunteers.Find(v => v.ID == 5)
                },

                new WorkRequest
                {
                    Id = 20,
                    Accepted = true,
                    Score = 50,
                    Expire = projects.Find(p => p.Id == 8).Time,
                    Project = projects.Find(p => p.Id == 8),
                    Volunteer = volunteers.Find(v => v.ID == 1)
                },

                new WorkRequest
                {
                    Id = 21,
                    Accepted = true,
                    Score = 50,
                    Expire = projects.Find(p => p.Id == 8).Time,
                    Project = projects.Find(p => p.Id == 8),
                    Volunteer = volunteers.Find(v => v.ID == 2)
                },

                new WorkRequest
                {
                    Id = 22,
                    Accepted = true,
                    Score = 50,
                    Expire = projects.Find(p => p.Id == 8).Time,
                    Project = projects.Find(p => p.Id == 8),
                    Volunteer = volunteers.Find(v => v.ID == 3)
                },

                new WorkRequest
                {
                    Id = 23,
                    Accepted = true,
                    Score = 50,
                    Expire = projects.Find(p => p.Id == 8).Time,
                    Project = projects.Find(p => p.Id == 8),
                    Volunteer = volunteers.Find(v => v.ID == 5)
                },

                new WorkRequest
                {
                    Id = 24,
                    Accepted = true,
                    Score = 50,
                    Expire = projects.Find(p => p.Id == 9).Time,
                    Project = projects.Find(p => p.Id == 9),
                    Volunteer = volunteers.Find(v => v.ID == 1)
                },

                new WorkRequest
                {
                    Id = 25,
                    Accepted = true,
                    Score = 50,
                    Expire = projects.Find(p => p.Id == 9).Time,
                    Project = projects.Find(p => p.Id == 9),
                    Volunteer = volunteers.Find(v => v.ID == 2)
                },

                new WorkRequest
                {
                    Id = 26,
                    Accepted = true,
                    Score = 50,
                    Expire = projects.Find(p => p.Id == 9).Time,
                    Project = projects.Find(p => p.Id == 9),
                    Volunteer = volunteers.Find(v => v.ID == 3)
                },

                new WorkRequest
                {
                    Id = 27,
                    Accepted = true,
                    Score = 50,
                    Expire = projects.Find(p => p.Id == 9).Time,
                    Project = projects.Find(p => p.Id == 9),
                    Volunteer = volunteers.Find(v => v.ID == 4)
                },

                new WorkRequest
                {
                    Id = 28,
                    Accepted = true,
                    Score = 50,
                    Expire = projects.Find(p => p.Id == 9).Time,
                    Project = projects.Find(p => p.Id == 9),
                    Volunteer = volunteers.Find(v => v.ID == 5)
                },

                new WorkRequest
                {
                    Id = 29,
                    Accepted = true,
                    Score = 50,
                    Expire = projects.Find(p => p.Id == 10).Time,
                    Project = projects.Find(p => p.Id == 10),
                    Volunteer = volunteers.Find(v => v.ID == 1)
                },

                new WorkRequest
                {
                    Id = 30,
                    Accepted = true,
                    Score = 50,
                    Expire = projects.Find(p => p.Id == 10).Time,
                    Project = projects.Find(p => p.Id == 10),
                    Volunteer = volunteers.Find(v => v.ID == 3)
                },

                new WorkRequest
                {
                    Id = 31,
                    Accepted = true,
                    Score = 50,
                    Expire = projects.Find(p => p.Id == 10).Time,
                    Project = projects.Find(p => p.Id == 10),
                    Volunteer = volunteers.Find(v => v.ID == 5)
                },

                new WorkRequest
                {
                    Id = 32,
                    Accepted = true,
                    Score = 50,
                    Expire = projects.Find(p => p.Id == 11).Time,
                    Project = projects.Find(p => p.Id == 11),
                    Volunteer = volunteers.Find(v => v.ID == 1)
                },

                new WorkRequest
                {
                    Id = 33,
                    Accepted = true,
                    Score = 50,
                    Expire = projects.Find(p => p.Id == 11).Time,
                    Project = projects.Find(p => p.Id == 11),
                    Volunteer = volunteers.Find(v => v.ID == 3)
                },

                new WorkRequest
                {
                    Id = 34,
                    Accepted = true,
                    Score = 50,
                    Expire = projects.Find(p => p.Id == 11).Time,
                    Project = projects.Find(p => p.Id == 11),
                    Volunteer = volunteers.Find(v => v.ID == 5)
                },

                new WorkRequest
                {
                    Id = 35,
                    Accepted = true,
                    Score = 50,
                    Expire = projects.Find(p => p.Id == 12).Time,
                    Project = projects.Find(p => p.Id == 12),
                    Volunteer = volunteers.Find(v => v.ID == 2)
                },

                new WorkRequest
                {
                    Id = 36,
                    Accepted = true,
                    Score = 50,
                    Expire = projects.Find(p => p.Id == 12).Time,
                    Project = projects.Find(p => p.Id == 12),
                    Volunteer = volunteers.Find(v => v.ID == 5)
                }
            };

            List<Invite> invites = new List<Invite>()
            {
                new Invite
                {
                    Id = 1,
                    Accepted = null,
                    Score = 50,
                    Expire = projects.Find(p => p.Id == 2).Time,
                    Project = projects.Find(p => p.Id == 2),
                    Volunteer = volunteers.Find(v => v.ID == 1)
                },

                new Invite
                {
                    Id = 2,
                    Accepted = null,
                    Score = 50,
                    Expire = projects.Find(p => p.Id == 8).Time,
                    Project = projects.Find(p => p.Id == 8),
                    Volunteer = volunteers.Find(v => v.ID == 2)
                },

                new Invite
                {
                    Id = 3,
                    Accepted = null,
                    Score = 50,
                    Expire = projects.Find(p => p.Id == 1).Time,
                    Project = projects.Find(p => p.Id == 1),
                    Volunteer = volunteers.Find(v => v.ID == 3)
                },

                new Invite
                {
                    Id = 4,
                    Accepted = null,
                    Score = 50,
                    Expire = projects.Find(p => p.Id == 4).Time,
                    Project = projects.Find(p => p.Id == 4),
                    Volunteer = volunteers.Find(v => v.ID == 4)
                },

                new Invite
                {
                    Id = 5,
                    Accepted = null,
                    Score = 50,
                    Expire = projects.Find(p => p.Id == 12).Time,
                    Project = projects.Find(p => p.Id == 12),
                    Volunteer = volunteers.Find(v => v.ID == 5)
                },
            };

            List<Suggestion> suggestions = new List<Suggestion>()
            {
                new Suggestion
                {
                    Id = 1,
                    Accepted = null,
                    Score = 50,
                    Expire = projects.Find(p => p.Id == 7).Time,
                    Project = projects.Find(p => p.Id == 7),
                    Volunteer = volunteers.Find(v => v.ID == 1)
                },

                new Suggestion
                {
                    Id = 2,
                    Accepted = null,
                    Score = 50,
                    Expire = projects.Find(p => p.Id == 9).Time,
                    Project = projects.Find(p => p.Id == 9),
                    Volunteer = volunteers.Find(v => v.ID == 2)
                },

                new Suggestion
                {
                    Id = 3,
                    Accepted = null,
                    Score = 50,
                    Expire = projects.Find(p => p.Id == 10).Time,
                    Project = projects.Find(p => p.Id == 10),
                    Volunteer = volunteers.Find(v => v.ID == 3)
                },

                new Suggestion
                {
                    Id = 4,
                    Accepted = null,
                    Score = 50,
                    Expire = projects.Find(p => p.Id == 9).Time,
                    Project = projects.Find(p => p.Id == 9),
                    Volunteer = volunteers.Find(v => v.ID == 4)
                },

                new Suggestion
                {
                    Id = 5,
                    Accepted = null,
                    Score = 50,
                    Expire = projects.Find(p => p.Id == 8).Time,
                    Project = projects.Find(p => p.Id == 8),
                    Volunteer = volunteers.Find(v => v.ID == 5)
                }
            };

            List<Admin> admins = new List<Admin>()
            {
                new Admin 
                {
                    ID = 1,
                    Association = organizations.Find(o => o.Id == 2),
                    Creation = DateTime.Parse("2012-03-07"),
                    Email = "John@kors.dk",
                    IsAdmin = true,
                    Location = new Location("Badehusvej 13","Aalborg"),
                    Name = "John Andersen",
                    UserName = "John9000"
                },

                new Admin 
                {
                    ID = 2,
                    Association = organizations.Find(o => o.Id == 1),
                    Creation = DateTime.Parse("2012-05-07"),
                    Email = "Nicklas@eclub.dk",
                    IsAdmin = true,
                    Location = new Location("Strandvejen 15","Aalborg"),
                    Name = "Nicklas Egoclub",
                    UserName = "NegoC"
                },

                new Admin 
                {
                    ID = 3,
                    Association = organizations.Find(o => o.Id == 3),
                    Creation = DateTime.Parse("2012-04-07"),
                    Email = "Helle@Utzon.dk",
                    IsAdmin = true,
                    Location = new Location("Engvej 18","Aalborg"),
                    Name = "Helle Utzu",
                    UserName = "Hutzu"
                },

                new Admin 
                {
                    ID = 4,
                    Association = organizations.Find(o => o.Id == 4),
                    Creation = DateTime.Parse("2012-06-07"),
                    Email = "Peter@Beach.dk",
                    IsAdmin = true,
                    Location = new Location("Thistedvej 17","Nørresundby"),
                    Name = "Peter Beach",
                    UserName = "PBeach"
                }
            };

            volunteers.Find(v => v.ID == 3).AddMatch(workrequests.Find(w => w.Id == 1));
            volunteers.Find(v => v.ID == 1).AddMatch(workrequests.Find(w => w.Id == 2));
            volunteers.Find(v => v.ID == 3).AddMatch(workrequests.Find(w => w.Id == 3));
            volunteers.Find(v => v.ID == 5).AddMatch(workrequests.Find(w => w.Id == 4));
            volunteers.Find(v => v.ID == 1).AddMatch(workrequests.Find(w => w.Id == 5));
            volunteers.Find(v => v.ID == 3).AddMatch(workrequests.Find(w => w.Id == 6));
            volunteers.Find(v => v.ID == 5).AddMatch(workrequests.Find(w => w.Id == 7));
            volunteers.Find(v => v.ID == 1).AddMatch(workrequests.Find(w => w.Id == 8));
            volunteers.Find(v => v.ID == 4).AddMatch(workrequests.Find(w => w.Id == 9));
            volunteers.Find(v => v.ID == 2).AddMatch(workrequests.Find(w => w.Id == 10));
            volunteers.Find(v => v.ID == 5).AddMatch(workrequests.Find(w => w.Id == 11));
            volunteers.Find(v => v.ID == 1).AddMatch(workrequests.Find(w => w.Id == 12));
            volunteers.Find(v => v.ID == 2).AddMatch(workrequests.Find(w => w.Id == 13));
            volunteers.Find(v => v.ID == 3).AddMatch(workrequests.Find(w => w.Id == 14));
            volunteers.Find(v => v.ID == 4).AddMatch(workrequests.Find(w => w.Id == 15));
            volunteers.Find(v => v.ID == 5).AddMatch(workrequests.Find(w => w.Id == 16));
            volunteers.Find(v => v.ID == 1).AddMatch(workrequests.Find(w => w.Id == 17));
            volunteers.Find(v => v.ID == 3).AddMatch(workrequests.Find(w => w.Id == 18));
            volunteers.Find(v => v.ID == 5).AddMatch(workrequests.Find(w => w.Id == 19));
            volunteers.Find(v => v.ID == 1).AddMatch(workrequests.Find(w => w.Id == 20));
            volunteers.Find(v => v.ID == 2).AddMatch(workrequests.Find(w => w.Id == 21));
            volunteers.Find(v => v.ID == 3).AddMatch(workrequests.Find(w => w.Id == 22));
            volunteers.Find(v => v.ID == 5).AddMatch(workrequests.Find(w => w.Id == 23));
            volunteers.Find(v => v.ID == 1).AddMatch(workrequests.Find(w => w.Id == 24));
            volunteers.Find(v => v.ID == 2).AddMatch(workrequests.Find(w => w.Id == 25));
            volunteers.Find(v => v.ID == 3).AddMatch(workrequests.Find(w => w.Id == 26));
            volunteers.Find(v => v.ID == 4).AddMatch(workrequests.Find(w => w.Id == 27));
            volunteers.Find(v => v.ID == 5).AddMatch(workrequests.Find(w => w.Id == 28));
            volunteers.Find(v => v.ID == 1).AddMatch(workrequests.Find(w => w.Id == 29));
            volunteers.Find(v => v.ID == 3).AddMatch(workrequests.Find(w => w.Id == 30));
            volunteers.Find(v => v.ID == 5).AddMatch(workrequests.Find(w => w.Id == 31));
            volunteers.Find(v => v.ID == 1).AddMatch(workrequests.Find(w => w.Id == 32));
            volunteers.Find(v => v.ID == 3).AddMatch(workrequests.Find(w => w.Id == 33));
            volunteers.Find(v => v.ID == 5).AddMatch(workrequests.Find(w => w.Id == 34));
            volunteers.Find(v => v.ID == 2).AddMatch(workrequests.Find(w => w.Id == 35));
            volunteers.Find(v => v.ID == 5).AddMatch(workrequests.Find(w => w.Id == 36));


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
