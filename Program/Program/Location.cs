using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Model
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }

        public Location() { }


        public Location(string address, string city)
        {
            this.Address = address;
            this.City = city;
        }

        public string GetAddress()
        {
            return this.Address + " " + this.City;
        }
    }
}
