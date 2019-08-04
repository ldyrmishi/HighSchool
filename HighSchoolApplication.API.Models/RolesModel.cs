using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace HighSchoolApplication.API.Models
{
    [DataContract]
    public class RolesModel
    {
        [DataMember(Name = "RoleId")]
        public int RoleId { get; set; }
        [DataMember(Name = "RoleDescription")]
        public string RoleDescription { get; set; }
        [DataMember(Name = "CreatedAt")]
        public DateTime? CreatedAt { get; set; }
        [DataMember(Name = "ModifiedAt")]
        public DateTime? ModifiedAt { get; set; }

        [DataMember(Name = "Users")]
        public ICollection<UsersModel> Users { get; set; }
    }
}
