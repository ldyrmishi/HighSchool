using System;
using System.Collections.Generic;
using System.Text;

namespace HighSchoolApplication.API.Models
{
    public class sp_GetStudentCertificateDetailsModel
    {
        public string FullName { get; set; }
        public string SchoolName { get; set; }
        public string NrAmze { get; set; }
        public int ClassYear { get; set; }
    }
}
