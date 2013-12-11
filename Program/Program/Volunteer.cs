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
        public List<Match> Matches { get; set; }
        #endregion

        #region Constructors
        public Volunteer()
        { this.Matches = new List<Match>(); }

        public Volunteer(string username, string name = null, Location location = null, string email = null)
            : base(username, name, location, email)
        { this.Matches = new List<Match>(); }
        #endregion

        #region Methods

        public void AddMatch(Match match)
        {
            Matches.Add(match);
        }

        public void AddWorkRequest(VolunteerProject project)
        {
            WorkRequest newWorkRequest = new WorkRequest(this, project);
            Matches.Add(newWorkRequest);
        }

        public Suggestion AddSuggestion(VolunteerProject project)
        {
            Suggestion newSuggestion = new Suggestion(this, project);
            Matches.Add(newSuggestion);
            return newSuggestion;
        }

        private IEnumerable<Match> GetMatches(bool? input)
        {
            List<Match> matches = new List<Match>();

            foreach (Match match in Matches)
            {
                if (match.Accepted == input)
                    matches.Add(match);
            }
            return matches;
        }

        public IEnumerable<Match> GetAcceptedMatches()
        {
            return GetMatches(true);
        }

        public IEnumerable<Match> GetPendingMatches()
        {
            return GetMatches(null);
        }

        //Returns all pending matches sorted by revelance (score)
        public IEnumerable<Match> GetSortMatches()
        {
            return GetPendingMatches().Where(x => x.Score > 0).OrderBy<Match, int>(x => x.Score);
        }

        public void RemoveProject(VolunteerProject project)
        {
            foreach (Match match in Matches)
            {
                if (match.Project == project)
                {
                    Matches.Remove(match);
                    break;
                }
            }
        }

        public IEnumerable<Invite> GetInvites()
        {
            return Matches.OfType<Invite>();
        }

        public string GetStatusOfProject(VolunteerProject project)
        {
            foreach (Match match in Matches)
	        {
                if (match.Project == project)
                    return match is Invite ? "invited" : 
                        match is WorkRequest ? "work requested" : 
                        "join";
	        }
            return "join";
        }
        #endregion
    }
}
