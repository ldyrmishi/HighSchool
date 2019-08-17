using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HighSchoolApplication.Infrastructure.Models
{
    public partial class SubjectPoints
    {
        public SubjectPoints()
        {
            UsersSubjectPoints = new HashSet<UsersSubjectPoints>();
        }

        [Required]
        [Key]
        [Column("SubjectPointsId")]
        public int Id { get; set; }
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
