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


        public IEnumerable<Model.VolunteerProject> GetAllProjects()
        {
            return _projects;
        }

        public void CreateProject(VolunteerProject project)
        {
            _projects.Add(project);
        }

        public IEnumerable<Volunteer> GetAllVolunteers()
        {
            return _vounteers;
        }

        public IEnumerable<Admin> GetAllAdmins()
        {
            return _admins;
        }
    }
}
