using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
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
        public List<Match> _matches = new List<Match>();
        #endregion

        #region Constructors
        public Volunteer()
        { }

        public Volunteer(int userid, string name = null, Location location = null, string email = null)
            :base(userid, name, location, email)
        { }
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

        private List<Match> GetMatches(bool? input)
        {
            List<Match> matches = new List<Match>();

            foreach (Match match in _matches)
            {
                if (match.Accepted == input)
                    matches.Add(match);
            }
            return matches;
        }

        public List<Match> GetAcceptedMatches()
        {
            return GetMatches(true);
        }

        public List<Match> GetPendingMatches()
        {
            return GetMatches(null);
        }

        public void RemoveProject(VolunteerProject project)
        {
            foreach (Match match in _matches)
            {
                if (match.Project == project)
                {
                    _matches.Remove(match);
                    break;
                }
            }
        }
        #endregion
    }
}
