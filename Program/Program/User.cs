using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Summary description for User
    /// </summary>
    public abstract class User
    {
        #region Properties
        [Key]
        [Required()]
        private int UserId { get; set; }

        public int VolunteerProjectId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }//NEED HASHING

        [Required(ErrorMessage="Name is required.")]
        [Display(Name="Name")]
        public string Name { get; set; }

        [Required()]
        [Display(Name="Creation Date")]
        public DateTime Creation { get; set; }

        [Required(ErrorMessage="A location is required")]
        [Display(Name="Location")]
        public Location Location { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name="Email")]
        public string Email { get; set; }


        

        #endregion

        #region Constructors
        public User(string username, string password, string name = null, Location location = null, string email = null)
        {
            this.Username = username;
            this.Password = password;
            this.Creation = DateTime.Now;
            this.Name = name;
            this.Location = location;
            this.Email = email;
        }
        #endregion
    }
}