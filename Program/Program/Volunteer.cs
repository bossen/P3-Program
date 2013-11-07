using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Volunteer : User
    {
        #region Properties
        public List<Preference> Preferences { get; set; }
        public List<Suggestion> Suggestions { get; set; }
        public List<VolunteerProject> VolunteerProjects { get; set; }

        #endregion

        #region Constructors
        Volunteer(string username, string password, string name = null, Location location = null, string email = null)
            :base(username, password, name, location, email)
        {

        }
        #endregion
    }
}
