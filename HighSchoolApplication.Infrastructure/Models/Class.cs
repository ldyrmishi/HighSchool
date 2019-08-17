using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HighSchoolApplication.Infrastructure.Models
{
    public partial class Class
    {
        public Class()
        {
            Lesson = new HashSet<Lesson>();
            UsersClass = new HashSet<UsersClass>();
        }

        [Required]
        [Key]
        [Column("ClassId")]
        public int Id { get; set; }
        public string ClassNo { get; set; }
        public int? ClassYear { get; set; }
        public int? SchoolId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int? UserId { get; set; }

        public School School { get; set; }
        public Users User { get; set; }
        public ICollection<Lesson> Lesson { get; set; }
        public ICollection<UsersClass> UsersClass { get; set; }
    }
}
