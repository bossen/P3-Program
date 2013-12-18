﻿using System;
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
        public List<Match> Matches { get; set; }
        public Topic VolunteerPreferences { get; set; }
        #endregion

        #region Constructors
        public Volunteer()
        {
            this.Matches = new List<Match>();
            this.VolunteerPreferences = new Topic();
        }

        public Volunteer(string username, string name = null, Location location = null, string email = null)
            : base(username, name, location, email)
        {
            this.Matches = new List<Match>();
            this.VolunteerPreferences= new Topic();
        }
        #endregion

        #region Methods      
        public void AddMatch(Match match)
        {
            Matches.Add(match);
        }

        public Match AddWorkRequest(VolunteerProject project)
        {
            foreach (Match match in Matches)
            {
                if (match.Project == project)
                {
                    if (match.GetType() == typeof(Invite))
                    {
                        match.AcceptMatch();
                        return match;
                    }
                    if (match.GetType() == typeof(WorkRequest))
                    {
                        return match;
                    }

                    Matches.Remove(match);
                    break;
                }
            }

            WorkRequest newWorkRequest = new WorkRequest(this, project);
            Matches.Add(newWorkRequest);

            return newWorkRequest;
        }

        public Match AddInvite(VolunteerProject project)
        {
            foreach (Match match in Matches)
            {
                if (match.Project == project)
                {
                    if (match.GetType() == typeof(WorkRequest))
                    {
                        match.AcceptMatch();
                        return match;
                    }

                    if (match.GetType() == typeof(Invite))
                        return match;
                }
            }

            Invite newInvite = new Invite(this, project);
            Matches.Add(newInvite);

            return newInvite;
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
<<<<<<< HEAD
                    return match is Invite ? "You have been invited" :
                        match is WorkRequest ? "You have requested work" :
                        match is Suggestion ? "Event has been suggested" :
                        "Join";
=======
                    return match.Accepted == true ? "leave" :
                        match is Invite ? "accept invite" :
                        match is WorkRequest ? "work requested" :
                        match is Suggestion ? "join suggested" :
                        "join";
>>>>>>> 5984b04078bd7abc077ea44db620fc24fcb49960
            }
            return "Join";
        }
        #endregion
    }
}
