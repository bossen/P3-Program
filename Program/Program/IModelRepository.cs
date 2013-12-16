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

    }

}
