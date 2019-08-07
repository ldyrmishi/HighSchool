using HighSchoolApplication.API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolApplication.API.Client
{
    public partial class ApiClient 
    {
        public async Task<List<ValueModel>> GetValues()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "api/Values"));
            return await GetAsync<List<ValueModel>>(requestUrl);
        }

        public async Task<Message<ValueModel>> SaveValues(ValueModel model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "User/SaveUser"));
            return await PostAsync<ValueModel>(requestUrl, model);
        }
    }
}
