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
        private List<Suggestion> _suggestions = new List<Suggestion>();
        private List<WorkRequest> _workRequests = new List<WorkRequest>();
        private List<Invite> _invites = new List<Invite>();
        #endregion

        #region Constructors
        public Volunteer(string username, string password, string name = null, Location location = null, string email = null)
            :base(username, password, name, location, email)
        {

        }
        #endregion

        #region Methods
        public void AddSuggestion(VolunteerProject project)
        {
            Suggestion newSuggestion = new Suggestion(this, project);
            _suggestions.Add(newSuggestion);
        }

        public void AddInvite(VolunteerProject project)
        {
            Invite newInvite = new Invite(this, project);
            _invites.Add(newInvite);
        }

        public void AddWorkRequest(VolunteerProject project)
        {
            WorkRequest newWorkRequest = new WorkRequest(this, project);
            _workRequests.Add(newWorkRequest);
        }

        private List<Match> GetAllMatches()
        {
            List<Match> matches = new List<Match>();
            matches.AddRange(_suggestions);
            matches.AddRange(_workRequests);
            matches.AddRange(_invites);

            return matches;
        }

        private List<VolunteerProject> FindProjects(bool? input)
        {
            List<Match> matches = GetAllMatches();

            List<VolunteerProject> projects = new List<VolunteerProject>();

            foreach (Match match in matches)
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
            foreach (Invite invite in _invites)
            {
                if (invite.Project == project)
                    _invites.Remove(invite);
            }
            foreach (WorkRequest workRequest in _workRequests)
            {
                if (workRequest.Project == project)
                    _workRequests.Remove(workRequest);
            }
            foreach (Suggestion suggestion in _suggestions)
            {
                if (suggestion.Project == project)
                    _suggestions.Remove(suggestion);
            }
        }
        #endregion
    }
}
