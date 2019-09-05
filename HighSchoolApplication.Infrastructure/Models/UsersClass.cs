using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HighSchoolApplication.Infrastructure.Models
{
    public partial class UsersClass
    {
        [Required]
        [Key]
        [Column("StudentId")]
        public int Id { get; set; }
        public int? ClassId { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public Class Class { get; set; }
        public Users User { get; set; }
    }
}
