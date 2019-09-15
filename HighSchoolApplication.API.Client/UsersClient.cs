using HighSchoolApplication.API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolApplication.API.Client
{
    public partial class ApiClient
    {
        public async Task<Message<IEnumerable<UsersModel>>> GetActiveStudents(string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Users/StudentsList"));
            return await GetAsync<IEnumerable<UsersModel>>(requestUrl,token);
        }

        public async Task<Message<IEnumerable<UsersModel>>> GetUsersList(string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Users/UsersList"));
            return await GetAsync<IEnumerable<UsersModel>>(requestUrl, token);
        }

        public async Task<Message<IEnumerable<sp_GetUsersByClassModel>>> GetUsersByClass(int ClassId, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Users/UsersByClass/{0}", ClassId));
            return await GetAsync<IEnumerable<sp_GetUsersByClassModel>>(requestUrl, token);
        }


    }
}
