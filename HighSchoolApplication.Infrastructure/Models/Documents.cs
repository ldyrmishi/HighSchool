﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HighSchoolApplication.Infrastructure.Models
{
    public partial class Documents
    {
        [Required]
        [Key]
        [Column("DocumentId")]
        public int Id { get; set; }
        public string DocumentDescription { get; set; }
        public string DocumentUrl { get; set; }
        public int? UserId { get; set; }
        public int? SubjectId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int? DocumentCategoryId { get; set; }

        public DocumentCategory DocumentCategory { get; set; }
        public Subjects Subject { get; set; }
        public Users User { get; set; }
    }
}
