using System;
using System.Collections.Generic;

namespace HighSchoolApplication.Infrastructure.Models
{
    public partial class School : BaseEntity
    {
        public School()
        {
            Class = new HashSet<Class>();
            Finances = new HashSet<Finances>();
            Users = new HashSet<Users>();
        }

        public int SchoolId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int? PhoneNumber { get; set; }
        public string Logo { get; set; }
        public string City { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public ICollection<Class> Class { get; set; }
        public ICollection<Finances> Finances { get; set; }
        public ICollection<Users> Users { get; set; }
    }
}
