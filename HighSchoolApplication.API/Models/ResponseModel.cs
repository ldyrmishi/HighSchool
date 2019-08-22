using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HighSchoolApplication.API.Models
{
    public class ResponseModel
    {
        public int StatusCode { get; set; }
        public string StatusDescription { get; set; }
        public string Message { get; set; }
        public object Body { get; set; }
    }
}
