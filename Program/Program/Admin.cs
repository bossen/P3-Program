using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Admin : User
    {
        #region Properties
        private List<VolunteerProject> _volunteerProjects = new List<VolunteerProject>();
        #endregion

        #region Constructors
        public Admin(int userId, string name = null, Location location = null, string email = null)
            : base(userId, name, location, email)
        { }
        #endregion

        #region Methods
        #endregion
    }
}