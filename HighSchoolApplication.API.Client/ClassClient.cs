using HighSchoolApplication.API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolApplication.API.Client
{
    public partial class ApiClient
    {
        public async Task<Message<List<ClassModel>>> GetClasses(string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Classes/ClassesList"));
            return await GetAsync<List<ClassModel>>(requestUrl,token);
        }

        public async Task<Message<IEnumerable<ClassModel>>> GetLoggedUserClasses(int IdUser,string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Classes/UsersListOfClasses/{0}", IdUser));
            return await GetAsync<IEnumerable<ClassModel>>(requestUrl, token);
        }

        public async Task<Message<ClassModel>> SaveClass(ClassModel model, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Classes/AddClass"));
            return await PostAsync<ClassModel>(requestUrl, model,token);
        }
    }
}
