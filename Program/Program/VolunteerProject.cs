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
        #region Fields
        List<int> _topicsInt = new List<int>();
        List<Preference> _topics = new List<Preference>();
        #endregion

        #region Properties
        [Key]
        [Required()]
        public int Id { get; set; }
        public Organization Owner { get; set; }
        public List<Match> Matches { get; set; }
        public string Title { get; set; }
        public Location Location { get; set; }
        public DateTime Time { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public bool Signup { get; private set; }
        public List<Preference> Topics
        {
            get
            {
                return _topics;
            }
            private set
            {
                _topics = value;
                _topicsInt = new List<int>();
                value.ForEach(p => _topicsInt.Add((int)p));
            }
        }
        public List<int> TopicsInt
        {
            get
            {
                return _topicsInt;
            }
            private set
            {
                _topicsInt = value;
                value.ForEach(p => _topics.Add((Preference)p));
            }
        }
        public List<int> AwesomeList { get; set; }
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

            //SuggestVolunteers();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Adds a topic to the list of topics
        /// </summary>
        /// <param name="topic">The topic to be added</param>
        public void AddTopic(Preference topic)
        {
            _topics.Add(topic);
            _topicsInt.Add((int)topic);
        }
        /// <summary>
        /// Adds a topic to the list of topics
        /// </summary>
        /// <param name="topic">The int representing a topic to be added</param>
        public void AddTopic(int topic)
        {
            _topicsInt.Add(topic);
            _topics.Add((Preference)topic);
        }
        /// <summary>
        /// Removes a topic from the list of topics
        /// </summary>
        /// <param name="topic">The topic to remove</param>
        public void RemoveTopic(Preference topic)
        {
            _topics.Remove(topic);
            _topicsInt.Remove((int)topic);
        }
        /// <summary>
        /// Removes a topic from the list of topics
        /// </summary>
        /// <param name="topic">The topic to remove</param>
        public void RemoveTopic(int topic)
        {
            _topicsInt.Remove(topic);
            _topics.Remove((Preference)topic);
        }

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
                if (match.Accepted == true)
                    participants.Add(match.Volunteer);
            }
            return participants;
        }

        //Checks if the project matches the user's preferences.
        //Always returns true if the user has no set preferences.
        private bool CheckVolunteerSuggest(Volunteer volunteer)
        {
            if (volunteer.Preferences.Intersect(this.Topics).Count() > 0 && volunteer.Preferences.Count != 0)
                return false;
            return true;
        }

        private void SuggestVolunteers()
        {
            using (var db = new VolunteerOrgContext())
            {
                foreach (Volunteer volunteer in db.Volunteers)
                {
                    if (CheckVolunteerSuggest(volunteer) == true)
                    {
                        Suggestion newSuggestion = volunteer.AddSuggestion(this);
                        Matches.Add(newSuggestion);
                    }
                }
            }
        }

        public double Calculate(VolunteerProject VpLoc, Volunteer VtLoc)
        {

            double Radius = 6372.8; // Radius of the earth
            // Calculating Delta longitude and latitude in radians
            double DeltaLat = ToRadians(VtLoc.Location.Lat - VpLoc.Location.Lat);
            double DeltaLng = ToRadians(VtLoc.Location.Lng - VpLoc.Location.Lng);

            VpLoc.Location.Lat = ToRadians(VpLoc.Location.Lat);
            VpLoc.Location.Lng = ToRadians(VpLoc.Location.Lat);

            //Haversine formular
            double SideA = Math.Sin(DeltaLat / 2) * Math.Sin(DeltaLat / 2) + Math.Sin(DeltaLng / 2) * Math.Sin(DeltaLng / 2) * Math.Cos(VtLoc.Location.Lat) * Math.Cos(VpLoc.Location.Lat);
            double SideC = 2 * Math.Asin(Math.Sqrt(SideA));

            return Radius * 2 * Math.Asin(Math.Sqrt(SideA));
        }

        // Method for converting to radians.
        public static double ToRadians(double alpha)
        {
            return Math.PI * alpha / 180;
        }
        #endregion
    }
}