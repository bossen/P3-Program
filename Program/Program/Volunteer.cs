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
        private List<Match> _matches = new List<Match>();
        #endregion

        #region Constructors
        public Volunteer(string username, string password, string name = null, Location location = null, string email = null)
            :base(username, password, name, location, email)
        {

        }
        #endregion

        #region Methods
        public void AddMatch(Match match)
        {
            _matches.Add(match);
        }

        public void AddWorkRequest(VolunteerProject project)
        {
            WorkRequest newWorkRequest = new WorkRequest(this, project);
            _matches.Add(newWorkRequest);
        }

        private List<VolunteerProject> FindProjects(bool? input)
        {
            List<VolunteerProject> projects = new List<VolunteerProject>();

            foreach (Match match in _matches)
            {
                if (match.Accepted == input)
                    projects.Add(match.Project);
            }
            return projects;
        }

        public List<VolunteerProject> FindAcceptedProjects()
        {
            return FindProjects(true);
        }

        public List<VolunteerProject> FindPendingProjects()
        {
            return FindProjects(null);
        }

        public void RemoveProject(VolunteerProject project)
        {
            foreach (Match match in _matches)
            {
                if (match.Project == project)
                    _matches.Remove(match);
            }
        }
        #endregion
    }
}
