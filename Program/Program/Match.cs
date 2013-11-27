using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class Match
    {
        #region Properties
        public Volunteer Volunteer { get; set; }
        public bool? Accepted { get; set; }
        public DateTime Expire { get; set; }
        public VolunteerProject Project { get; set; }
        #endregion

        #region Constructors
        public Match(Volunteer volunteer, VolunteerProject project, DateTime expire, bool? accepted = null)
        {
            this.Volunteer = volunteer;
            this.Project = project;
            this.Accepted = accepted;
            this.Expire = expire;
        }

        public Match(Volunteer volunteer, VolunteerProject project, bool? accepted = null)
            :this(volunteer, project, project.Time, accepted)
        { }
        #endregion

        #region Methods
        public void AcceptMatch()
        {
            this.Accepted = true;
        }

        public void DeleteMatch()
        {
            this.Project = null;
            this.Volunteer = null;
        }
        #endregion
    }
}