using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Invite : Match
    {
        #region Properties
        #endregion

        #region Constructors
        public Invite()
            : base()
        { }

        public Invite(Volunteer volunteer, VolunteerProject project)
            : base(volunteer, project)
        { }
        #endregion

        #region Methods
        #endregion
    }
}
