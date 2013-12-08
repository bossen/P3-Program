using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Data.Entity;
using MvcVolunteerOrg.Models;

namespace Model
{
    public class Admin : User
    {
        #region Properties
        [Key]
        public int Id { get; set; }
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
        public void CreateOrganization(string name, Location location, string email)
        {
            using (var db = new VolunteerOrgContext())
            {
                Organization newOrganization = new Organization(name, location, email);
                this.Association = newOrganization;
                db.Organizations.Add(newOrganization);
                db.SaveChanges();
            }
        }

        public void AssociateOrganization(Organization organization)
        {
            this.Association = organization;
        }
        #endregion
    }
}