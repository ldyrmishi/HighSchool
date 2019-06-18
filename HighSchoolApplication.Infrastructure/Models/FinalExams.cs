using System;
using System.Collections.Generic;

namespace HighSchoolApplication.Infrastructure.Models
{
    public partial class FinalExams : BaseEntity
    {
        public int FinalExamId { get; set; }
        public int? SubjectId { get; set; }
        public int? UserId { get; set; }
        public int? MaxPoints { get; set; }
        public int? Grade { get; set; }
        public DateTime? PointsDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public Subjects Subject { get; set; }
        public Users User { get; set; }
    }
}
