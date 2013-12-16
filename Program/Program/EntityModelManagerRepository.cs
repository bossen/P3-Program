﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Model
{
    public class EntityModelManagerRepository : Model.IModelRepository 
    {
        private VolunteerOrgContext db = new VolunteerOrgContext();
        public IEnumerable<VolunteerProject> GetAllProjects()
        {
            return db.VolunteerProjects
                .Include("Location")
                .Include("Matches")
                .Include("Owner")
                .Include("ProjectTopics").ToList();
        }

        public IEnumerable<Volunteer> GetAllVolunteers()
        {
            return db.Volunteers
                .Include("Matches")
                .Include("VolunteerPreferences")
                .Include("Location").ToList();
        }

        public IEnumerable<Admin> GetAllAdmins()
        {
            return db.Admins
                .Include("Association")
                .Include("Location").ToList();
        }

        public IEnumerable<Match> GetAllMatches()
        {
            return db.Matches
                .Include("Volunteer")
                .Include("Project").ToList();

        }

        public VolunteerProject GetProject(int id)
        {
            return db.VolunteerProjects
                .Include("Owner")
                .Include("Location")
                .Include("ProjectTopics")
                .Include("Matches")
                .Include("Matches.Volunteer")
                .Where(v => v.Id == id)
                .FirstOrDefault();
        }
    }
}
