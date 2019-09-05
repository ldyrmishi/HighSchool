using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace HighSchoolApplication.API.Models
{
    [DataContract]
    public class UsersSubjectPointsModel
    {
        [DataMember(Name ="Id")]
        public int Id { get; set; }

        [DataMember(Name = "Grade")]
        public int? Grade { get; set; }

        [DataMember(Name = "CreatedAt")]
        public DateTime? CreatedAt { get; set; }

        [DataMember(Name = "ModifiedAt")]
        public DateTime? ModifiedAt { get; set; }

        [DataMember(Name = "SubjectPointsId")]
        public int? SubjectPointsId { get; set; }

        [DataMember(Name = "SubjectPoints")]
        public SubjectPointsModel SubjectPoints { get; set; }

        [DataMember(Name = "User")]
        public UsersModel User { get; set; }
    }
}
