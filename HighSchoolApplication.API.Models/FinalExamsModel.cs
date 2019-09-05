using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace HighSchoolApplication.API.Models
{
    [DataContract]
    public class FinalExamsModel
    {
        [DataMember(Name ="Id")]
        public int Id { get; set; }

        [DataMember(Name = "MaxPoints")]
        public int? MaxPoints { get; set; }

        [DataMember(Name = "Grade")]
        public int? Grade { get; set; }

        [DataMember(Name = "PointsDate")]
        public DateTime? PointsDate { get; set; }

        [DataMember(Name = "CreatedAt")]
        public DateTime? CreatedAt { get; set; }

        [DataMember(Name = "ModifiedAt")]
        public DateTime? ModifiedAt { get; set; }

        [DataMember(Name = "SubjectId")]
        public int? SubjectId { get; set; }

        [DataMember(Name = "UserId")]
        public int? UserId { get; set; }

        [DataMember(Name = "Subject")]
        public SubjectModel Subject { get; set; }

        [DataMember(Name = "User")]
        public UsersModel User { get; set; }
    }
}
