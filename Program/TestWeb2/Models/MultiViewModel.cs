using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;

namespace TestWeb2.Models
{
    public class MultiViewModel
    {
        public Admin Admin { get; set; }
        public Organization Organization { get; set; }
        public Volunteer Volunteer { get; set; }
    }
}