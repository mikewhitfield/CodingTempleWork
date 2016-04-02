using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Web;


namespace CityTourAPI.Models
{
    [DataContract(Name = "Featured")]
    [Serializable]
    public class FeaturedDTO
    {   
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public Nullable<int> ProductId { get; set; }
        [DataMember]
        public string CatagoryName { get; set; }
        [DataMember]
        public Nullable<decimal> Longitude  { get; set; }
        [DataMember]
        public Nullable<decimal> Latitude { get; set; }
        [DataMember]
        public string ImageUrl { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public Nullable<decimal> Price { get; set; }
        [DataMember]
        public string Summary { get; set; }
        [DataMember]
        public int ProdId { get; set; }


    }
}