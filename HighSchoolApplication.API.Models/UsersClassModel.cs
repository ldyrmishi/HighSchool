﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace HighSchoolApplication.API.Models
{
    [DataContract]
    public class UsersClassModel
    {
        [DataMember(Name ="Id")]
        public int Id { get; set; }

        [DataMember(Name = "CreatedAt")]
        public DateTime? CreatedAt { get; set; }

        [DataMember(Name = "ModifiedAt")]
        public DateTime? ModifiedAt { get; set; }

        [DataMember(Name = "ClassId")]
        public int? ClassId { get; set; }

        [DataMember(Name = "UserId")]
        public int? UserId { get; set; }

        [DataMember(Name = "Class")]
        public ClassModel Class { get; set; }

        [DataMember(Name = "User")]
        public UsersModel User { get; set; }
    }
}
