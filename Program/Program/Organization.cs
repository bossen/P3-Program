using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Organization
    {
        #region Properties
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage="Name is required")]
        [Display(Name="Name")]
        public string Name { get; set; }

        [Required()]
        [Display(Name = "Creation Date")]
        public DateTime Creation { get; set; }

        [Required(ErrorMessage = "A location is required")]
        [Display(Name = "Location")]
        public Location Location { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public event EventHandler NewProjectHandler;


        private List<VolunteerProject> _volunteerProjects = new List<VolunteerProject>();
        #endregion
        
        #region Constructors
        public Organization(string name = null, Location location = null, string email = null)
        {
            this.Name = name;
            this.Creation = DateTime.Now;
            this.Location = location;
            this.Email = email;

            using (var db = new VolunteerOrgContext())
            {
                db.Organizations.Add(this);
                db.SaveChanges();
            }
        }

        public Organization()
        { }
        #endregion

        #region Methods
        public void CreateProject(string title, Location location, DateTime time, List<Preference> topics, string description = "")
        {
            VolunteerProject newProject = new VolunteerProject(title, location, time, topics, this, description, true);
            _volunteerProjects.Add(newProject);
        }

        public List<VolunteerProject> GetProjects()
        {
            return _volunteerProjects;
        }
        #endregion
    }
}