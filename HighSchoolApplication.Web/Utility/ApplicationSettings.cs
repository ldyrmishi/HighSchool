using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HighSchoolApplication.Web.Utility
{
    public class ApplicationSettings
    {
        private static IConfiguration configuration;
        public static string WebApiUrl { get
            { return configuration.GetSection("MySettings").GetSection("WebApiBaseUrl").Value;
            } set { } }
    }
}
