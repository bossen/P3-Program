using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Model
{
    public class Suggestion : Match
    {

        [Key]
        public int Id { get; set; }

        public Suggestion(Volunteer volunteer, VolunteerProject project)
            : base(volunteer, project, DateTime.Now.AddDays(1), null) //Instead of add days 1, volunteer.settings.suggestiontime
        {
            this.Project = project;
        }
    }
}
