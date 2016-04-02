using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Web;

namespace CityTourAPI.Models
{
    [DataContract(Name = "Address")]
    [Serializable]
    public class AddressDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Address1 { get; set; }
        [DataMember]
        public string Address2 { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public string Zipcode { get; set; }
        [DataMember]
        public string Country { get; set; }
    }
}