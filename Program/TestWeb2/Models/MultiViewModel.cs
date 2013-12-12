using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;

namespace TestWeb2.Models
{
    public class MultiViewModel
    {
<<<<<<< HEAD
        public Admin Admin { get; set; }
        public Organization Organization { get; set; }
        public Volunteer Volunteer { get; set; }
=======
        public Admin Admin { get; private set; }
        public Organization Organization { get; private set; }
        public Volunteer Volunteer { get; private set; }
        public VolunteerProject VolunteerProject { get; set; }
>>>>>>> a0b0f2ddbe400334450b59e682cb7eb14179c7fa
    }
}