using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Organization
    {
        #region Properties
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage="Name is required")]
        [Display(Name="Name")]
        public string Name { get; set; }

        [Required()]
        [DataType(DataType.Date)]
        [Column(TypeName = "DateTime2")]
        [Display(Name = "Creation Date")]
        public DateTime Creation { get; set; }

        [Required(ErrorMessage = "A location is required")]
        [Display(Name = "Location")]
        public Location Location { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }


        public List<VolunteerProject> VolunteerProjects { get; set; }
        #endregion
        
        #region Constructors
        public Organization(string name = null, Location location = null, string email = null)
        {
            this.Name = name;
            this.Creation = DateTime.Now;
            this.Location = location;
            this.Email = email;
            this.VolunteerProjects = new List<VolunteerProject>();
            /*using (var db = new VolunteerOrgContext())
            {
                db.Organizations.Add(this);
                db.SaveChanges();
            }*/
        }

        public Organization()
        {
            this.VolunteerProjects = new List<VolunteerProject>();
        }
        #endregion

        #region Methods
        public VolunteerProject CreateProject(string title, Location location, DateTime time, Topic topics, string description = "")
        {
            VolunteerProject newProject = new VolunteerProject(title, location, time, topics, this, description, true);
            VolunteerProjects.Add(newProject);

            return newProject;
        }

        public List<VolunteerProject> GetProjects()
        {
            return VolunteerProjects;
        }
        #endregion
    }
}