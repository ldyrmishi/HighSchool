using DotLiquid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HighSchoolApplication.API.Drops
{
    public class StudentCertificationDrop : Drop
    {
        public int ReferenceNumber
        {
            get;
            set;
        }
        public DateTimeOffset CreationDate
        {
            get;
            set;
        }

        public string NoAmze
        {
            get;
            set;
        }

        public string StudentName
        {
            get;
            set;
        }

        public string SchoolName
        {
            get;
            set;
        }

        public int StudentYear
        {
            get;
            set;
        }
    }
}
