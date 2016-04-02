using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CityToursMVC.Models
{
    public class Product
    {
        public string TourName { get; set;}
        public string Lat { get; set; }
        public string Long { get; set; }
        public double TourPrice { get; set; }
        public string TourImage { get; set; }
        public string Type { get; set; }
        public string Icon { get; set; }
        public string Summary { get; set; }
    }
}