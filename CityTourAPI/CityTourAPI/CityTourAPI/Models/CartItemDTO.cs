using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace CityTourAPI.Models
{
    [DataContract (Name ="CartItem")]
    [Serializable]
    public class CartItemDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public Nullable<int> ProductId { get; set; }
        [DataMember]
        public Nullable<int> CartId { get; set; }
        [DataMember]
        public Nullable<decimal> Total { get; set; }
        [DataMember]
        public Nullable<int> Quantity { get; set; }
        [DataMember]
        public string ImageUrl { get; set; }
        [DataMember]
        public string ProductName { get; set; }
    }
}

