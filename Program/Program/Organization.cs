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
        public List<VolunteerProject> VolunteerProjects { get; set; }
        #endregion
        
        #region Constructors
        Organization(string username, string password, string name = null, Location location = null, string email = null)
            :base(username, password, name, location, email)
        {

        }
        #endregion

        #region Methods
        void CreateProject()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
