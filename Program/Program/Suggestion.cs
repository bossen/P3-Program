using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Suggestion : Match
    {
        public VolunteerProject Project { get; set; }

        public Suggestion(Volunteer receiver, VolunteerProject project)
            : base(null, receiver, false)
        {
            this.Project = project;
        }
    }
}
