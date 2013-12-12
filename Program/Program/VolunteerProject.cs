﻿using System;
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
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public bool Signup { get; private set; }
        public List<Tag> Topics { get; set ;}
        #endregion

        #region Constructors
        public VolunteerProject()
        {
            Topics = new List<Tag>();
        }

        public VolunteerProject(string title, Location location, DateTime time, List<Tag> topics, Organization owner, string description, bool signup)
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
        public void AddTopic(Tag topic)
        {
            Topics.Add(topic);
        }
        /// <summary>
        /// Removes a topic from the list of topics
        /// </summary>
        /// <param name="topic">The topic to remove</param>
        public void RemoveTopic(Tag topic)
        {
            Topics.Remove(topic);
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

        public double Calculate(VolunteerProject Volunteerproject, Volunteer Volunteer)
        {

            double Radius = 6372.8; // Radius of the earth
            // Calculating Delta longitude and latitude in radians
            double DeltaLat = ToRadians(Volunteer.Location.Lat - Volunteerproject.Location.Lat);
            double DeltaLng = ToRadians(Volunteer.Location.Lng - Volunteerproject.Location.Lng);

            Volunteerproject.Location.Lat = ToRadians(Volunteerproject.Location.Lat);
            Volunteerproject.Location.Lng = ToRadians(Volunteerproject.Location.Lat);

            //Haversine formular
            double SideA = Math.Sin(DeltaLat / 2) * Math.Sin(DeltaLat / 2) + Math.Sin(DeltaLng / 2) * Math.Sin(DeltaLng / 2) * Math.Cos(Volunteer.Location.Lat) * Math.Cos(Volunteerproject.Location.Lat);
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