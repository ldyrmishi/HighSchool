using System;
using System.Collections.Generic;
using System.Text;

namespace HighSchoolApplication.Infrastructure.Models
{
    public class sp_GetUserByClass
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int IdUser { get; set; }
        public int ClassId { get; set; }
        public int SchoolId { get; set; }
        public int ClassYear { get; set; }
        public string ClassNo { get; set; }
    }
}
