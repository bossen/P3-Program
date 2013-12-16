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

        [DataType(DataType.Date)]
        public DateTime Time { get; set; }
        
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public bool Signup { get; set; }

        public Topic ProjectTopics { get; set; }
        #endregion

        #region Constructors
        public VolunteerProject()
        {
            ProjectTopics = new Topic();
        }

        public VolunteerProject(string title, Location location, DateTime time, Topic topics, Organization owner, string description, bool signup)
        {
            this.Title = title;
            this.Location = location;
            this.Time = time;
            this.ProjectTopics = topics;
            this.Owner = owner;
            this.Description = description;
            this.Signup = signup;
            //SuggestVolunteers();
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
                if (match.Accepted == true)
                    participants.Add(match.Volunteer);
            }
            return participants;
        }

        //Checks if the project matches the user's preferences.
        //Always returns true if the user has no set preferences.
        private bool CheckVolunteerSuggest(Volunteer volunteer)
        {
            Topic tmp = new Topic();
            tmp.QuickSetProperties(true, true, true, true, true, true);
            if (volunteer.VolunteerPreferences.CompareTopics(tmp) == 0)
                return true;

            if (volunteer.VolunteerPreferences.CompareTopics(this.ProjectTopics) == 0)
                return false;
            return true;
        }

        private void SuggestVolunteers()
        {
            using (var db = new VolunteerOrgContext())
            {
                foreach (Volunteer volunteer in db.Volunteers.Include("Location"))
                {
                    if (CheckVolunteerSuggest(volunteer) == true)
                    {
                        Suggestion newSuggestion = volunteer.AddSuggestion(this);
                        Matches.Add(newSuggestion);
                    }
                }
            }
        }

        public double Calculate(VolunteerProject pos1, Volunteer pos2)
        {
            if (pos1.Location == null || 
                pos1.Location.Lat == null || 
                pos1.Location.Lng == null || 
                pos2.Location == null ||
                pos2.Location.Lat == null || 
                pos2.Location.Lng == null)
            {
                return -1;
            }
            double Radius = 6371; //Mean radius of the earth in kilometers

            //Finds the delta longitude and latitude of the positions.
            double dLat = ToRadians(pos2.Location.Lat - pos1.Location.Lat);
            double dLon = ToRadians(pos2.Location.Lng - pos1.Location.Lng);
            
            double lat1 = ToRadians(pos1.Location.Lat);
            double lat2 = ToRadians(pos2.Location.Lat);

            //Haversine Formula
            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(lat1) * Math.Cos(lat2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return Radius * c;
        }

        // Method for converting to radians.
        public static double ToRadians(double alpha)
        {
            return (Math.PI / 180) * alpha;
        }
        #endregion
    }
}