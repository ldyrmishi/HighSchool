using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace HighSchoolApplication.API.Models
{
    [DataContract]
    public class ClassModel
    {
        [DataMember(Name ="Id")]
        public int Id { get; set; }

        [DataMember(Name = "ClassNo")]
        public string ClassNo { get; set; }

        [DataMember(Name = "ClassYear")]
        public int? ClassYear { get; set; }

        [DataMember(Name = "CreatedAt")]
        public DateTime? CreatedAt { get; set; }

        [DataMember(Name = "ModifiedAt")]
        public DateTime? ModifiedAt { get; set; }

        [DataMember(Name = "SchoolId")]
        public int? SchoolId { get; set; }

        [DataMember(Name = "UserId")]
        public int? UserId { get; set; }

        [DataMember(Name = "School")]
        public SchoolModel School { get; set; }

        [DataMember(Name = "User")]
        public UsersModel User { get; set; }

        [DataMember(Name = "Lesson")]
        public ICollection<LessonModel> Lesson { get; set; }

        [DataMember(Name = "UsersClass")]
        public ICollection<UsersClassModel> UsersClass { get; set; }
    }
}
