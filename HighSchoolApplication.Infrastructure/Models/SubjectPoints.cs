using System;
using System.Collections.Generic;

namespace HighSchoolApplication.Infrastructure.Models
{
    public partial class SubjectPoints
    {
        public SubjectPoints()
        {
            UsersSubjectPoints = new HashSet<UsersSubjectPoints>();
        }

        public int SubjectPointsId { get; set; }
        public int? SubjectId { get; set; }
        public int? Points { get; set; }
        public string PointsReason { get; set; }
        public string MarkType { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime? PointsDate { get; set; }

        public Subjects Subject { get; set; }
        public ICollection<UsersSubjectPoints> UsersSubjectPoints { get; set; }
    }
}
