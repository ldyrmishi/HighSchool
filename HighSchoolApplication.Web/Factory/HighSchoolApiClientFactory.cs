using HighSchoolApplication.API.Client;
using HighSchoolApplication.Web.Utility;
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
        private static Lazy<ApiClient> restClient = new Lazy<ApiClient>(() => new ApiClient(apiUri),
                                                                               LazyThreadSafetyMode.ExecutionAndPublication);
        static HighSchoolApiClientFactory()
        {
            apiUri = new Uri(ApplicationSettings.WebApiUrl);
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
