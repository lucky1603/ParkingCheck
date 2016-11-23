using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkingCheck.Models
{
    public class Garage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PlacesTotal { get; set; }
        public int PlacesFree { get; set; }
        public int PlacesTaken
        {
            get
            {
                return this.PlacesTotal - this.PlacesFree;
            }
        }
        public string Address{ get;set;}
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}