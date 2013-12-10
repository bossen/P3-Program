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
                    Name = "Spinkelben",
                    Creation = DateTime.Parse("1992-05-05"),
                    Email = "hej@mail.dk",
                    IsAdmin = false,
                    Location = new Location("blah 1", "Blah blah"),
                    Preferences = new List<Preference>(),
                    _matches = new List<Match>()

                }
            );
        }
    }
}
