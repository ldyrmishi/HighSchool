using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HighSchoolApplication.Infrastructure.Models
{
    public partial class UsersStatus
    {
        public UsersStatus()
        {
            Users = new HashSet<Users>();
        }

        [Required]
        [Key]
        [Column("UsersStatusId")]
        public int Id { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public ICollection<Users> Users { get; set; }
    }
}
