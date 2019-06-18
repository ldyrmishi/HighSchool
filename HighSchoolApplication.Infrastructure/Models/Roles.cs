using System;
using System.Collections.Generic;

namespace HighSchoolApplication.Infrastructure.Models
{
    public partial class Roles : BaseEntity
    {
        public Roles()
        {
            Users = new HashSet<Users>();
        }

        public int RoleId { get; set; }
        public string RoleDescription { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public ICollection<Users> Users { get; set; }
    }
}
