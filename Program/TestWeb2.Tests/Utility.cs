using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWeb2
{
    static class Utility
    {
        public static VolunteerProject GetAProject()
        {
            return GetAProject("Project title", "A project");
        }

        public static VolunteerProject GetAProject(string title, string description)
        {
            return GetAProject(title, new Location("street", "City"),
                DateTime.Parse("1996-6-6"), new Topic() { Church = true }, null, description, false);
        }

        public static VolunteerProject GetAProject(string title, Location location,
            DateTime time, Topic topics, Organization owner, string description, bool signup)
        {
            return new VolunteerProject(title, location, time, topics, owner, description, signup);
        }

        public static Admin GetAnAdmin()
        {
            return GetAnAdmin("Username");
        }
        public static Admin GetAnAdmin(string username)
        {
            return GetAnAdmin(username, "Name", new Location("streeet", "city"), "EMAIL@host.dk");
        }

        public static Admin GetAnAdmin(string username, string name, Location location, string email)
        {
            return new Admin(username, name, location, email);
        }

        public static Volunteer GetAVolunteer()
        {
            return GetAVolunteer("Username");
        }
        public static Volunteer GetAVolunteer(string username)
        {
            return GetAVolunteer(username, "Name", new Location("streeet", "city"), "EMAIL@host.dk");
        }

        public static Volunteer GetAVolunteer(string username, string name, Location location, string email)
        {
            return new Volunteer(username, name, location, email);
        }

        public static Organization GetAnOrganization()
        {
            return GetAnOrganization("Some organization", "some@email.dk");
        }

        public static Organization GetAnOrganization(string name, string email)
        {
            return GetAnOrganization(name, DateTime.Parse("1996-04-02"),
                new Location("street", "chitty"), email);
        }
        
        public static Organization GetAnOrganization(string name, DateTime creation, Location location, string email)
        {
            return new Organization() { Name = name, Creation = creation, Email = email, Location = location };
        }
    }
}
