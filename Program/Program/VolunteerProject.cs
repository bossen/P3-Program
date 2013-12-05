using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class VolunteerProject
    {
        #region Properties
        [Key]
        [Required()]
        public int Id { get; set; }

        public Organization Owner { get; set; }
        public List<Match> Matches { get; set; }
        public string Title { get; set; }
        public Location Location { get; set; }
        public DateTime Time { get; set; }
        public List<Preference> Topics { get; set; }
        public string Description { get; set; }
        public bool Signup { get; private set; }
        #endregion

        #region Constructors
        public VolunteerProject()
        { }

        public VolunteerProject(string title, Location location, DateTime time, List<Preference> topics, Organization owner, string description, bool signup)
        {
            this.Title = title;
            this.Location = location;
            this.Time = time;
            this.Topics = topics;
            this.Owner = owner;
            this.Description = description;
            this.Signup = signup;
        }
        #endregion

        #region Methods
        void RequestWork(Volunteer volunteer)
        {
            Invite newInvite = new Invite(volunteer, this);
            volunteer.AddMatch(newInvite);
        }

        void CloseProject()
        {
            throw new NotImplementedException();
        }

        void CancelProject()
        {
            Signup = false;
            foreach (Match match in Matches)
            {
                match.Volunteer.RemoveProject(this);
            }
        }

        void OpenProjectSignup()
        {
            Signup = true;
        }

        public List<Volunteer> FindParticipants()
        {
            List<Volunteer> participants = new List<Volunteer>();
            foreach (Match match in Matches)
	        {
                if(match.Accepted == true)
                    participants.Add(match.Volunteer);
	        }
            return participants;
        }
        #endregion
    }
}