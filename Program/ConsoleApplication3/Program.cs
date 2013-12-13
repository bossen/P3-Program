using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new VolunteerOrgContext())
            {
                Volunteer v1 = new Volunteer(1, "username") { VolunteerPreferences = new List<Preference>() { Preference.Festival } };
                Organization o1 = new Organization("blue pills");
                o1.CreateProject("cool stuff", new Location("11", "aalborg"), DateTime.Now.AddDays(2), new List<Preference>() { Preference.Culture, Preference.Festival }, "NOTHING HERE");
                

                foreach (Match m in v1.GetPendingMatches())
                {
                    Console.WriteLine(m.Project.Title);
                }
            }
        }
    }
}
