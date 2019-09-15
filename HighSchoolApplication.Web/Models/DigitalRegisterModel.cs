using HighSchoolApplication.API.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HighSchoolApplication.Web.Models
{
    public class DigitalRegisterModel
    {
        public List<sp_GetUsersByClassModel> users { get; set; }
        public  CalendarModel calendar { get; set; }

        public Dictionary<string, string> RegisterValue { get; set; }
    }
}
