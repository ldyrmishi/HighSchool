using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace HighSchoolApplication.API.Models
{
    [DataContract]
    public class SubjectPointsModel
    {
        [DataMember(Name = "Id")]
        public int Id { get; set; }
        [DataMember(Name = "Points")]
        public int? Points { get; set; }
        [DataMember(Name = "PointsReason")]
        public string PointsReason { get; set; }
        [DataMember(Name = "MarkType")]
        public string MarkType { get; set; }
        [DataMember(Name = "CreatedAt")]
        public DateTime? CreatedAt { get; set; }
        [DataMember(Name = "ModifiedAt")]
        public DateTime? ModifiedAt { get; set; }
        [DataMember(Name = "PointsDate")]
        public DateTime? PointsDate { get; set; }

        [DataMember(Name = "Subject")]
        public SubjectModel Subject { get; set; }
        [DataMember(Name = "UsersSubjectPoints")]
        public ICollection<UsersSubjectPointsModel> UsersSubjectPoints { get; set; }
    }
}
