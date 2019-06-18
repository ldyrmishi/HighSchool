using System;
using System.Collections.Generic;

namespace HighSchoolApplication.Infrastructure.Models
{
    public partial class Address : BaseEntity
    {
        public Address()
        {
            Users = new HashSet<Users>();
        }

        public int AddressId { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string StreetAddress { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public ICollection<Users> Users { get; set; }
    }
}
