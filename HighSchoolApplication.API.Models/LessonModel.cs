using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace HighSchoolApplication.API.Models
{
    [DataContract]
    public class LessonModel
    {
        [DataMember(Name ="Id")]
        public int Id { get; set; }

        [DataMember(Name ="StartDateTime")]
        public DateTime? StartDateTime { get; set; }

        [DataMember(Name = "EndDateTime")]
        public DateTime? EndDateTime { get; set; }

        [DataMember(Name = "CreatedAt")]
        public DateTime? CreatedAt { get; set; }

        [DataMember(Name = "ModifiedAt")]
        public DateTime? ModifiedAt { get; set; }

        [DataMember(Name = "Description")]
        public string Description { get; set; }

        [DataMember(Name = "DiaryId")]
        public int? DiaryId { get; set; }

        [DataMember(Name = "SubjectId")]
        public int? SubjectId { get; set; }

        [DataMember(Name = "ClassId")]
        public int? ClassId { get; set; }
        [DataMember(Name = "Class")]
        public ClassModel Class { get; set; }

        [DataMember(Name = "Diary")]
        public DiaryModel Diary { get; set; }

        [DataMember(Name = "Subject")]
        public SubjectModel Subject { get; set; }

        [DataMember(Name = "Absents")]
        public ICollection<AbsentsModel> Absents { get; set; }
    }
}
