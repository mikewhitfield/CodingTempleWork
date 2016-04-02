using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace CityTourAPI.Models
{
    [DataContract(Name = "Product")]
    [Serializable]
    public class ProductDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string ImageUrl { get; set; }
        [DataMember]
        public string Summary { get; set; }
        [DataMember]
        public Nullable<decimal> Latitude { get; set; }
        [DataMember]
        public Nullable<decimal> Longitude { get; set; }
        [DataMember]
        public Nullable<decimal> Price { get; set; }
        [DataMember]
        public string Marker { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string CatagoryName {get; set;}
    }
}