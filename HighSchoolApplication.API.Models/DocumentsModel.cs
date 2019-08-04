using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace HighSchoolApplication.API.Models
{
    [DataContract]
    public class DocumentsModel
    {
        [DataMember(Name ="DocumentId")]
        public int DocumentId { get; set; }
        [DataMember(Name = "DocumentDescription")]
        public string DocumentDescription { get; set; }
        [DataMember(Name = "DocumentUrl")]
        public string DocumentUrl { get; set; }
        [DataMember(Name = "CreatedAt")]
        public DateTime? CreatedAt { get; set; }
        [DataMember(Name = "ModifiedAt")]
        public DateTime? ModifiedAt { get; set; }

        [DataMember(Name = "DocumentCategory")]
        public DocumentCategoryModel DocumentCategory { get; set; }
        [DataMember(Name = "Subject")]
        public SubjectModel Subject { get; set; }
        [DataMember(Name = "User")]
        public UsersModel User { get; set; }
    }
}
