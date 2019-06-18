using System;
using System.Collections.Generic;

namespace HighSchoolApplication.Infrastructure.Models
{
    public partial class DocumentCategory : BaseEntity
    {
        public DocumentCategory()
        {
            Documents = new HashSet<Documents>();
        }

        public int DocumentCategoryId { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public ICollection<Documents> Documents { get; set; }
    }
}
