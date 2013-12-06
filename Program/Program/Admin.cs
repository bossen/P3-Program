using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Model
{
    public class Admin : User
    {
        #region Properties
        [Key]
        public int Id { get; set; }
        private List<VolunteerProject> _volunteerProjects = new List<VolunteerProject>();
        #endregion

        #region Constructors
        public Admin(int userid, string name = null, Location location = null, string email = null)
            : base(userid, name, location, email)
        { }
        #endregion

        #region Methods
        #endregion
    }
}