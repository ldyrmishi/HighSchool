using System;
using System.Collections.Generic;

namespace HighSchoolApplication.Infrastructure.Models
{
    public partial class Subjects : BaseEntity
    {
        public Subjects()
        {
            Diary = new HashSet<Diary>();
            Documents = new HashSet<Documents>();
            FinalExams = new HashSet<FinalExams>();
            Lesson = new HashSet<Lesson>();
            SubjectPoints = new HashSet<SubjectPoints>();
        }

        public int SubjectId { get; set; }
        public string SubjectTitle { get; set; }
        public string SubjectDescription { get; set; }
        public string Term { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int? MaxPoints { get; set; }

        public ICollection<Diary> Diary { get; set; }
        public ICollection<Documents> Documents { get; set; }
        public ICollection<FinalExams> FinalExams { get; set; }
        public ICollection<Lesson> Lesson { get; set; }
        public ICollection<SubjectPoints> SubjectPoints { get; set; }
    }
}
