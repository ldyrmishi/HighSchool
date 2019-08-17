using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HighSchoolApplication.Infrastructure.Models
{
    public partial class DocumentCategory
    {
        public DocumentCategory()
        {
            Documents = new HashSet<Documents>();
        }

        [Required]
        [Key]
        [Column("DocumentCategoryId")]
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public ICollection<Documents> Documents { get; set; }
    }
}
