using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HighSchoolApplication.Infrastructure.Models
{
    public class sp_GetStudentCertificateDetails
    {
        public string FullName { get; set; }
        public string SchoolName { get; set; }
        public string NrAmze { get; set; }
        public int ClassYear { get; set; }
    }
}
