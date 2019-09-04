using HighSchoolApplication.API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolApplication.API.Client
{
    public partial class ApiClient
    {
        public async Task<Message<List<SchoolModel>>> GetSchools(string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "School/SchoolsList"));
            return await GetAsync<List<SchoolModel>>(requestUrl,token);
        }

        public async Task<Message<SchoolModel>> AddSchool(SchoolModel model, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "School/AddSchool"));
            return await PostAsync<SchoolModel>(requestUrl, model, token);
        }

        public async Task<Message<SchoolModel>> EditSchool(SchoolModel model, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "School/EditSchool"));
            return await PostAsync<SchoolModel>(requestUrl, model, token);
        }

    }
}
