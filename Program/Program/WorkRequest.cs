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
        public WorkRequest(User sender, User receiver, bool? accepted = null)
            :base(sender, receiver, accepted)
        {
        }

        public WorkRequest(User sender, User receiver, DateTime expire, bool? accepted = null)
            :base(sender, receiver, expire, accepted)
        {
        }
        #endregion

        #region Methods
        void AcceptVolunteer(bool choice)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
