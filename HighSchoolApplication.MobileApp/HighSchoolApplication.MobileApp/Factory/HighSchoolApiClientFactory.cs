using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using HighSchoolApplication.API.Client;

namespace HighSchoolApplication.MobileApp.Factory
{
    public static class HighSchoolApiClientFactory
    {
        private static Uri apiUri;
        //private static IConfiguration configuration;
        private static Lazy<ApiClient> restClient = new Lazy<ApiClient>(() => new ApiClient(apiUri), LazyThreadSafetyMode.ExecutionAndPublication);
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
