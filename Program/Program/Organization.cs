using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Organization : User
    {
        #region Properties
        private List<VolunteerProject> _volunteerProjects = new List<VolunteerProject>();
        #endregion
        
        #region Constructors
        public Organization(string username, string password, string name = null, Location location = null, string email = null)
            :base(username, password, name, location, email)
        { }
        #endregion

        #region Methods
        public void CreateProject(string title, Location location, DateTime time, List<Preference> topics, string description = "")
        {
            VolunteerProject newProject = new VolunteerProject(title, location, time, topics, this, description);
            _volunteerProjects.Add(newProject);
        }

        public List<VolunteerProject> getProjects()
        {
            return _volunteerProjects;
        }
        #endregion
    }
}