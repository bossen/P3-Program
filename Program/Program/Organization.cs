using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Organization
    {
        #region Properties
        public string Name { get; set; }
        public DateTime Creation { get; set; }
        public Location Location { get; set; }
        public string Email { get; set; }
        private List<VolunteerProject> _volunteerProjects = new List<VolunteerProject>();
        #endregion
        
        #region Constructors
        public Organization(string name = null, Location location = null, string email = null)
        {
            this.Name = name;
            this.Creation = DateTime.Now;
            this.Location = location;
            this.Email = email;
        }
        #endregion

        #region Methods
        public void CreateProject(string title, Location location, DateTime time, List<Preference> topics, string description = "")
        {
            VolunteerProject newProject = new VolunteerProject(title, location, time, topics, this, description, true);
            _volunteerProjects.Add(newProject);
        }

        public List<VolunteerProject> GetProjects()
        {
            return _volunteerProjects;
        }
        #endregion
    }
}