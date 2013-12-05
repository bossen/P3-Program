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
        public int Id { get; set; }

        public int VolunteerProjectId { get; set; }

        [Required]
        [Display(Name = "User name")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
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

    public class LoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Admin?")]
        public bool IsAdmin { get; set; }
    }

}