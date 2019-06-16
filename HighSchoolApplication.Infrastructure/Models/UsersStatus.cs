using System;
using System.Collections.Generic;

namespace HighSchoolApplication.Infrastructure.Models
{
    public partial class UsersStatus
    {
        public UsersStatus()
        {
            Users = new HashSet<Users>();
        }

        public int UsersStatusId { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public ICollection<Users> Users { get; set; }
    }
}
