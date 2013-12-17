using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    public interface IModelRepository
    {
        IEnumerable<VolunteerProject> GetAllProjects();
        IEnumerable<Volunteer> GetAllVolunteers();
        IEnumerable<Admin> GetAllAdmins();
        IEnumerable<Match> GetAllMatches();
        IEnumerable<Organization> GetAllOrganizations();

        VolunteerProject GetProject(int id);
        Organization GetOrganization(int id);
        Volunteer GetVolunteer(int id);
    }

}
