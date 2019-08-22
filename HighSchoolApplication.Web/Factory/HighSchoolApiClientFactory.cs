using HighSchoolApplication.API.Client;
using HighSchoolApplication.Web.Utility;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HighSchoolApplication.Web.Factory
{
    internal static class HighSchoolApiClientFactory
    {
        private static Uri apiUri;
        //private static IConfiguration configuration;
        private static Lazy<ApiClient> restClient = new Lazy<ApiClient>(() => new ApiClient(apiUri),
                                                                               LazyThreadSafetyMode.ExecutionAndPublication);
        static HighSchoolApiClientFactory()
        {
            apiUri = new Uri("http://localhost:5454/api/");
        }

        public static ApiClient Instance
        {
            get
            {
                return restClient.Value;
            }
        }
    }
}
