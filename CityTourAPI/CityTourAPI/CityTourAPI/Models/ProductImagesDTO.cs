using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace CityTourAPI.Models
{
    [DataContract (Name = "ProductImages")]
    [Serializable]
    public class ProductImagesDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Url { get; set; }
        [DataMember]
        public Nullable<int> ProductId { get; set; }
    }
}