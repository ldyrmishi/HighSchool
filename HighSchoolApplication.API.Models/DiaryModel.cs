using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace HighSchoolApplication.API.Models
{
    [DataContract]
    public class DiaryModel
    {
        [DataMember(Name ="DiaryId")]
        public int DiaryId { get; set; }
        [DataMember(Name = "Title")]
        public string Title { get; set; }
        [DataMember(Name = "Description")]
        public DateTime? Description { get; set; }
        [DataMember(Name = "DiaryDate")]
        public DateTime? DiaryDate { get; set; }
        [DataMember(Name = "CreatedAt")]
        public DateTime? CreatedAt { get; set; }
        [DataMember(Name = "ModifiedAt")]
        public DateTime? ModifiedAt { get; set; }

        [DataMember(Name = "Subject")]
        public SubjectModel Subject { get; set; }
        [DataMember(Name = "User")]
        public UsersModel User { get; set; }
        [DataMember(Name = "Lesson")]
        public ICollection<LessonModel> Lesson { get; set; }
    }
}
