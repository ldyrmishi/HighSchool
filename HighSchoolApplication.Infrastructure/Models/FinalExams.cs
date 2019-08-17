using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HighSchoolApplication.Infrastructure.Models
{
    public partial class FinalExams
    {
        [Required]
        [Key]
        [Column("FinalExamId")]
        public int Id { get; set; }
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
