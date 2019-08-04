using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace HighSchoolApplication.API.Models
{
    [DataContract]
    public class AbsentsModel
    {
        [DataMember(Name ="AbsentsId")]
        public int AbsentsId { get; set; }
        [DataMember(Name = "LessonId")]
        public int? LessonId { get; set; }
        [DataMember(Name = "UserId")]
        public int? UserId { get; set; }
        [DataMember(Name = "IsInClass")]
        public bool? IsInClass { get; set; }
        [DataMember(Name = "CreatedAt")]
        public DateTime? CreatedAt { get; set; }
        [DataMember(Name = "ModifiedAt")]
        public DateTime? ModifiedAt { get; set; }
        [DataMember(Name = "AbsentDate")]
        public DateTime? AbsentDate { get; set; }
        [DataMember(Name = "IsJustificated")]
        public bool? IsJustificated { get; set; }
        [DataMember(Name = "Reason")]
        public string Reason { get; set; }

        [DataMember(Name = "Lesson")]
        public LessonModel Lesson { get; set; }
        [DataMember(Name = "User")]
        public UsersModel User { get; set; }
    }
}
