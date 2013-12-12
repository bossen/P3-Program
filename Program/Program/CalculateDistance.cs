using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Math;

    namespace Model {

        public static class {    
            public static double Calculate(double EventLat, double EventLng, double VolunteerLat, double VolunteerLng) {
 
                double Radius = 6372.8; // Radius of the earth
                // Calculating Delta longitude and latitude in radians
                double DeltaLat = ToRadians(VolunteerLat - EventLat);
                double DeltaLng = ToRadians(VolunteerLng - EventLng);
            
                EventLat = ToRadians(EventLat);
                EventLng = ToRadians(EventLat);

                //Haversine formular
                double SideA = Math.Sin(DeltaLat / 2) * Math.Sin(DeltaLat / 2) + Math.Sin(DeltaLng / 2) * Math.Sin(DeltaLng / 2) * Math.Cos(VolunteerLat) * Math.Cos(EventLat);
                double SideC = 2 * Math.Asin(Math.Sqrt(SideA));

                return (int)Radius * 2 * Math.Asin(Math.Sqrt(SideA));

            }

            // Method for converting to radians.
            public static double ToRadians(double alpha){
                return Math.PI * alpha / 180;
            }
        }

    }
