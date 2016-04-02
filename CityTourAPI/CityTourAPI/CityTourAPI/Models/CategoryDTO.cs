using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Web;

namespace CityTourAPI.Models
{
    [DataContract(Name = "Category")]
    [Serializable]
    public class CategoryDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}