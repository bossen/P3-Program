using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class WorkRequest : Match
    {

        #region Constructors
        public WorkRequest(Volunteer volunteer, VolunteerProject project)
            : base(volunteer, project)
        { }
        #endregion

        #region Methods
        void AcceptVolunteer(bool choice)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}