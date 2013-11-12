using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Suggestion : Match
    {

        public Suggestion(Volunteer volunteer, VolunteerProject project)
            : base(volunteer, project, project.Time.AddDays(-1), null)
        {
            this.Project = project;
        }
    }
}
