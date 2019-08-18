using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace HighSchoolApplication.API.Models
{
    [DataContract]
    public class SchoolModel
    {
        [DataMember(Name="Id")]
        public int Id { get; set; }
        [DataMember(Name = "Name")]
        public string Name { get; set; }
        [DataMember(Name = "Address")]
        public string Address { get; set; }
        [DataMember(Name = "PhoneNumber")]
        public int? PhoneNumber { get; set; }
        [DataMember(Name = "Logo")]
        public string Logo { get; set; }
        [DataMember(Name = "City")]
        public string City { get; set; }
        [DataMember(Name = "CreatedAt")]
        public DateTime? CreatedAt { get; set; }
        [DataMember(Name = "ModifiedAt")]
        public DateTime? ModifiedAt { get; set; }

        [DataMember(Name = "Class")]
        public ICollection<ClassModel> Class { get; set; }
        [DataMember(Name = "Finances")]
        public ICollection<FinancesModel> Finances { get; set; }
        [DataMember(Name = "Users")]
        public ICollection<UsersModel> Users { get; set; }
    }
}
