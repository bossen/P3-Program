using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;


namespace TestWeb2.Tests.Models
{
    class MocModelRepository : Model.IModelRepository
    {
        private List<Model.VolunteerProject> _projects = new List<Model.VolunteerProject>();
        private List<Model.Volunteer> _vounteers = new List<Volunteer>();
        private List<Model.Admin> _admins = new List<Admin>();
        private List<Model.Match> _matches = new List<Match>();
        private List<Model.Organization> _organizations = new List<Organization>();

        #region GetAll...
        public IEnumerable<Model.VolunteerProject> GetAllProjects()
        {
            return _projects;
        }

        public IEnumerable<Volunteer> GetAllVolunteers()
        {
            return _vounteers;
        }

        public IEnumerable<Admin> GetAllAdmins()
        {
            return _admins;
        }

        public IEnumerable<Match> GetAllMatches()
        {
            return _matches;
        }
        #endregion

        #region Create Methods
        public void CreateProject(VolunteerProject project)
        {
            _projects.Add(project);
        }

        public Model.VolunteerProject GetProject(int id)
        {
            return _projects.FirstOrDefault(p => p.Id == id);
        }

        public void CreateAdmin(Admin admin)
        {
            _admins.Add(admin);
        }

        public void CreateOrganization(Model.Organization organization)
        {
            _organizations.Add(organization);
        }
        
        public void CreateVolunteer(Volunteer volunteer)
        {
            _vounteers.Add(volunteer);
        }
        #endregion
    }
}
