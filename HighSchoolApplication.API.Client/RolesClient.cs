using HighSchoolApplication.API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolApplication.API.Client
{
    public partial class ApiClient
    {
        public async Task<Message<List<RolesModel>>> GetRoles(string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Role"));
            return await GetAsync<List<RolesModel>>(requestUrl,token);
        }

        public async Task<Message<RolesModel>> GetRoleById(int id, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Role/{0}",id));
            return await GetAsync<RolesModel>(requestUrl,token);
        }

        public async Task<Message<RolesModel>> SaveRoles(RolesModel model, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Role/AddRole"));
            return await PostAsync<RolesModel>(requestUrl, model,token);
        }
    }
}
