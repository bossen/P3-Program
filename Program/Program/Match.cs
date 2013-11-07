using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class Match
    {
        #region Properties
        public User Sender { get; set; }
        public User Receiver { get; set; }
        public bool? Accepted { get; set; }
        public DateTime Expire { get; set; }
        #endregion

        #region Constructors
        public Match(User sender, User receiver, bool? accepted = null)
        {
            this.Sender = sender;
            this.Receiver = receiver;
            this.Accepted = accepted;
        }

        public Match(User sender, User receiver, DateTime expire, bool? accepted = null)
            :this(sender, receiver, accepted)
        {
            this.Expire = expire;
        }
        #endregion

        #region Methods
        void AcceptMatch(bool choice)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
