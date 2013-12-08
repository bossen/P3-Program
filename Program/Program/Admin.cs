using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Diagnostics;
using Model;
using System.Data.Entity.Validation;

namespace Model
{
    public class Admin : User
    {
        #region Properties
        private List<VolunteerProject> _volunteerProjects = new List<VolunteerProject>();
        public Organization Association { get; set; }
        #endregion

        #region Constructors
        public Admin(int userid, string name = null, Location location = null, string email = null)
            : base(userid, name, location, email)
        { }

        public Admin()
        { }
        #endregion

        #region Methods
        public Organization CreateOrganization(string name, Location location, string email)
        {
            using (var db  = new VolunteerOrgContext())
            {
                Organization newOrganization = new Organization(name, location, email);
                this.Association = newOrganization;

                db.Organizations.Add(newOrganization);
                db.SaveChanges();
                return newOrganization;
            }
        }

        public void AssociateOrganization(Organization organization)
        {
            this.Association = organization;
        }
        #endregion
    }
}