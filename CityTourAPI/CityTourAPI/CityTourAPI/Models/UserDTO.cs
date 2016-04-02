using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace CityTourAPI.Models
{
    [DataContract (Name = "User")]
    [Serializable]
    public class UserDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public Nullable<int> CustomerId { get; set; }
    }
}