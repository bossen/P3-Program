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
        public int UserId { get; set; }

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
        public User(int userId, string name = null, Location location = null, string email = null)
        {
            this.UserId = userId;
            this.Creation = DateTime.Now;
            this.Name = name;
            this.Location = location;
            this.Email = email;
        }
        #endregion
    }
}