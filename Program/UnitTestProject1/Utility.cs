using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace UnitTestProject1
{
    public static class Utility
    {
        public static Volunteer GetVolunteer()
        {
            Location l = new Location("address", "city");
            return GetVolunteer("username", "name", l, "mail");
        }

        public static Volunteer GetVolunteer(string username, string name, Location l, string mail)
        {
            return new Volunteer
            {
                UserName = username,
                Name = name,
                Location = l,
                Email = mail
            };
        }

        public static VolunteerProject GetVolunteerProject()
        {
            DateTime time = DateTime.Now.AddDays(1);
            Topic Topics = new Topic();
            Topics.Church = true;
            Organization o = Utility.GetOrganization();
            Location l = new Location("address", "city");
            return GetVolunteerProject("title", l, time, Topics, o, "description", true);
        }

        public static VolunteerProject GetVolunteerProject(string title, Location l, DateTime time, Topic Topics, Organization o, string Description, bool signup)
        {
            return new VolunteerProject
            {
                Title = title,
                Location = l,
                Time = time,
                ProjectTopics = Topics,
                Owner = o,
                Description = Description,
                Signup = signup
            };
        }

        public static Organization GetOrganization()
        {
            Location l = new Location("address", "city");
            return GetOrganization("name", l, "mail");
        }

        public static Organization GetOrganization(string name, Location l, string mail)
        {
            return new Organization
            {
                Name = name,
                Location = l,
                Email = mail
            };
        }
    }
}
