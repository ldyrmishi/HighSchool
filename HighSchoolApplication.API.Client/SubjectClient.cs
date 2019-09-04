using HighSchoolApplication.API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolApplication.API.Client
{
    public partial class ApiClient
    {
        public async Task<Message<List<SubjectModel>>> GetSubjects(string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "User/GetAllUsers"));
            return await GetAsync<List<SubjectModel>>(requestUrl,token);
        }

        public async Task<Message<SubjectModel>> SaveSubjects(SubjectModel model, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "User/SaveUser"));
            return await PostAsync<SubjectModel>(requestUrl, model,token);
        }
    }
}
