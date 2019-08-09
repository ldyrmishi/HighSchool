using HighSchoolApplication.API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolApplication.API.Client
{
    public partial class ApiClient
    {
        public async Task<List<RolesModel>> GetRoles()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Role"));
            return await GetAsync<List<RolesModel>>(requestUrl);
        }

        public async Task<RolesModel> GetRoleById(int id)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Role/{0}",id));
            return await GetAsync<RolesModel>(requestUrl);
        }

        public async Task<Message<RolesModel>> SaveRoles(RolesModel model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Role"));
            return await PostAsync<RolesModel>(requestUrl, model);
        }
    }
}
