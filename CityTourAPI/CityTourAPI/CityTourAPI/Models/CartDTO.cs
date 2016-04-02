using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace CityTourAPI.Models
{
    [DataContract (Name = "Cart")]
    [Serializable]
    public class CartDTO
    {   
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public Nullable<int> CustomerId { get; set; }
    }
}