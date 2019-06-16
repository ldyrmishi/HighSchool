using System;
using System.Collections.Generic;

namespace HighSchoolApplication.Infrastructure.Models
{
    public partial class Diary
    {
        public Diary()
        {
            Lesson = new HashSet<Lesson>();
        }

        public int DiaryId { get; set; }
        public int? UserId { get; set; }
        public int? SubjectId { get; set; }
        public string Title { get; set; }
        public DateTime? Description { get; set; }
        public DateTime? DiaryDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public Subjects Subject { get; set; }
        public Users User { get; set; }
        public ICollection<Lesson> Lesson { get; set; }
    }
}
