using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class VolunteerProject
    {
        #region Properties
        public string Title { get; set; }
        public Location Location { get; set; }
        public DateTime Time { get; set; }
        public List<Preference> Topics { get; set; }
        public List<Match> VolunteersMatches { get; set; } //Participants better name?
        public Organization Owner { get; set; }
        public string Description { get; set; }
        #endregion

        #region Constructors
        public VolunteerProject(string title, Location location, DateTime time, List<Preference> topics, Organization owner, string description)
        {
            this.Title = title;
            this.Location = location;
            this.Topics = topics;
            this.Owner = owner;
            this.Description = description;
        }
        #endregion

        #region Methods
        void RequestWork(Volunteer volunteer)
        {
            throw new NotImplementedException();
        }

        void CloseProject()
        {
            throw new NotImplementedException();
        }

        void CancelProject()
        {
            throw new NotImplementedException();
        }

        void OpenProjectSignup()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}