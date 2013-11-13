using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Location
    {
        public string Address { get; set; }
        public string City { get; set; }

        public Location(string address, string city)
        {
            this.Address = address;
            this.City = city;
        }
    }
}
