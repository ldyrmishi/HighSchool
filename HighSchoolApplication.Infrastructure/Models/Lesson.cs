using System;
using System.Collections.Generic;

namespace HighSchoolApplication.Infrastructure.Models
{
    public partial class Lesson
    {
        public Lesson()
        {
            Absents = new HashSet<Absents>();
        }

        public int LessonId { get; set; }
        public int? DiaryId { get; set; }
        public int? SubjectId { get; set; }
        public int? ClassId { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string Description { get; set; }

        public Class Class { get; set; }
        public Diary Diary { get; set; }
        public Subjects Subject { get; set; }
        public ICollection<Absents> Absents { get; set; }
    }
}
