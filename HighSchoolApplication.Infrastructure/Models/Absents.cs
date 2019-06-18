using System;
using System.Collections.Generic;

namespace HighSchoolApplication.Infrastructure.Models
{
    public partial class Absents : BaseEntity
    {
        public int AbsentsId { get; set; }
        public int? LessonId { get; set; }
        public int? UserId { get; set; }
        public bool? IsInClass { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime? AbsentDate { get; set; }
        public bool? IsJustificated { get; set; }
        public string Reason { get; set; }

        public Lesson Lesson { get; set; }
        public Users User { get; set; }
    }
}
