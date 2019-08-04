using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace HighSchoolApplication.API.Models
{
    [DataContract]
    public class DocumentCategoryModel
    {
        [DataMember(Name ="DocumentCategoryId")]
        public int DocumentCategoryId { get; set; }
        [DataMember(Name ="Description")]
        public string Description { get; set; }
        [DataMember(Name ="CreatedAt")]
        public DateTime? CreatedAt { get; set; }
        [DataMember(Name = "ModifiedAt")]
        public DateTime? ModifiedAt { get; set; }

        [DataMember(Name = "Documents")]
        public ICollection<DocumentsModel> Documents { get; set; }
    }
}
