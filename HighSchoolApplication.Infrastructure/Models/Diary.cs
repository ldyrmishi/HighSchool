using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HighSchoolApplication.Infrastructure.Models
{
    public partial class Diary
    {
        public Diary()
        {
            Lesson = new HashSet<Lesson>();
        }

        [Required]
        [Key]
        [Column("DiaryId")]
        public int Id { get; set; }
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
