using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace CityTourAPI.Models
{
    [DataContract (Name = "Customer")]
    [Serializable]
    public class CustomerDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public Nullable<int> AddressId { get; set; }
        [DataMember]
        public Nullable<int> Phone { get; set; }
        [DataMember]
        public string Email { get; set; }
    }
}