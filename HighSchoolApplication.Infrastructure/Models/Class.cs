using System;
using System.Collections.Generic;

namespace HighSchoolApplication.Infrastructure.Models
{
    public partial class Class
    {
        public Class()
        {
            Lesson = new HashSet<Lesson>();
            UsersClass = new HashSet<UsersClass>();
        }

        public int ClassId { get; set; }
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
