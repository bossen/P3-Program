using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    ///<summary>
    /// A volunteer is the users which will be able to participate as volunteers and join volunteer events.
    /// He is able to change his preferences, to receive the most relevant invitations to volunteering events.
    /// </summary>
    public class Volunteer : User
    {
        #region Properties
        public List<Preference> Preferences { get; set; }
        public List<Suggestion> Suggestions { get; set; }
        public List<VolunteerProject> VolunteerProjects { get; set; }

        #endregion

        #region Constructors
        public Volunteer(string username, string password, string name = null, Location location = null, string email = null)
            :base(username, password, name, location, email)
        {

        }
        #endregion
    }
}
