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

    
    }
}
