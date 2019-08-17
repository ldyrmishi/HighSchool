using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HighSchoolApplication.Infrastructure.Models
{
    public partial class UsersSubjectPoints
    {
        [Required]
        [Key]
        [Column("UserSubjectPointsId")]
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? SubjectPointsId { get; set; }
        public int? Grade { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public SubjectPoints SubjectPoints { get; set; }
        public Users User { get; set; }
    }
}
