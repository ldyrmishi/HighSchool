using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace HighSchoolApplication.API.Models
{
    [DataContract]
    public class AddressModel
    {
        [DataMember(Name ="AddressId")]
        public int AddressId { get; set; }
        [DataMember(Name = "State")]
        public string State { get; set; }
        [DataMember(Name = "City")]
        public string City { get; set; }
        [DataMember(Name = "ZipCode")]
        public string ZipCode { get; set; }
        [DataMember(Name = "StreetAddress")]
        public string StreetAddress { get; set; }
        [DataMember(Name = "CreatedAt")]
        public DateTime? CreatedAt { get; set; }
        [DataMember(Name = "ModifiedAt")]
        public DateTime? ModifiedAt { get; set; }

        [DataMember(Name = "Users")]
        public ICollection<UsersModel> Users { get; set; }
    }
}
