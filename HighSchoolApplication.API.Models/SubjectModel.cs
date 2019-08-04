using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace HighSchoolApplication.API.Models
{
    [DataContract]
    public class SubjectModel
    {
        [DataMember(Name = "SubjectId")]
        public int SubjectId { get; set; }
        [DataMember(Name = "SubjectTitle")]
        public string SubjectTitle { get; set; }
        [DataMember(Name = "SubjectDescription")]
        public string SubjectDescription { get; set; }
        [DataMember(Name = "Term")]
        public string Term { get; set; }
        [DataMember(Name = "CreatedAt")]
        public DateTime? CreatedAt { get; set; }
        [DataMember(Name = "ModifiedAt")]
        public DateTime? ModifiedAt { get; set; }
        [DataMember(Name = "MaxPoints")]
        public int? MaxPoints { get; set; }

        [DataMember(Name = "Diary")]
        public ICollection<DiaryModel> Diary { get; set; }
        [DataMember(Name = "Documents")]
        public ICollection<DocumentsModel> Documents { get; set; }
        [DataMember(Name = "FinalExams")]
        public ICollection<FinalExamsModel> FinalExams { get; set; }
        [DataMember(Name = "Lesson")]
        public ICollection<LessonModel> Lesson { get; set; }
        [DataMember(Name = "SubjectPoints")]
        public ICollection<SubjectPointsModel> SubjectPoints { get; set; }
    }
}
