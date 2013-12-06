using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;



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

        public int UserId { get; set; }

        public int VolunteerProjectId { get; set; }

        [Required]
        [Display(Name = "User name")]
        public string Username { get; set; }

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
<<<<<<< HEAD
        public User()
        { }

        public User(string username, string password, string name = null, Location location = null, string email = null)
=======
        public User(string username, int userid, string name = null, Location location = null, string email = null)
>>>>>>> b2c3b1559d0f274bf3114dec070731db594bf478
        {
            this.Username = username;
            this.UserId = userid;
            this.Creation = DateTime.Now;
            this.Name = name;
            this.Location = location;
            this.Email = email;
        }

        public User()
        { }

        #endregion
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "User name")]
        public string Username { get; set; }

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

    /*public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }*/

    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }

    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string Username { get; set; }
    }


}