using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolApplication.API.Client
{
    public partial class ApiClient
    {
        public async Task<string> Login()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Account/Login"));
            return await GetAsync<string>(requestUrl);
        }
    }
}
