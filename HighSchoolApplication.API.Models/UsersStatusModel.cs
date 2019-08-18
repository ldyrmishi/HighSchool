using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace HighSchoolApplication.API.Models
{
    [DataContract]
    public class UsersStatusModel
    {
        [DataMember(Name ="Id")]
        public int Id { get; set; }
        [DataMember(Name = "Status")]
        public string Status { get; set; }
        [DataMember(Name = "CreatedAt")]
        public DateTime? CreatedAt { get; set; }
        [DataMember(Name = "ModifiedAt")]
        public DateTime? ModifiedAt { get; set; }

        [DataMember(Name = "Users")]
        public ICollection<UsersModel> Users { get; set; }
    }
}
