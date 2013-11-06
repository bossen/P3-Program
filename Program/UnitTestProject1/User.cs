using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    class User
    {
        #region Properties
        public string Username { get; set; }
        public string Password { get; set; } // NEED HASHING
        public string Name { get; set; }
        public DateTime Creation { get; set; }
        public Location Location { get; set; }
        public string Email { get; set; }
        #endregion

        #region Constructors
        User(string username, string password, string name = null, Location location = null, string email = null)
        {
            this.Username = username;
            this.Password = password;
            this.Creation = DateTime.Now;
        }
        #endregion
    }
}