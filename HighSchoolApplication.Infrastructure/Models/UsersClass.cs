using System;
using System.Collections.Generic;

namespace HighSchoolApplication.Infrastructure.Models
{
    public partial class UsersClass
    {
        public int StudentId { get; set; }
        public int? ClassId { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public Class Class { get; set; }
        public Users User { get; set; }
    }
}
