using HighSchoolApplication.API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolApplication.API.Client
{
    public partial class ApiClient
    {
        public async Task<Message<IEnumerable<SubjectModel>>> GetSubjects(string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Subjects/GetAllSubjects"));
            return await GetAsync<IEnumerable<SubjectModel>>(requestUrl,token);
        }

        public async Task<Message<IEnumerable<SubjectModel>>> GetSubjectsByTerm(string term, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Subjects/GetSubjectsByTerm/{0}", term));
            return await GetAsync<IEnumerable<SubjectModel>>(requestUrl, token);
        }

        public async Task<Message<SubjectModel>> AddSubject(SubjectModel model, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Subjects/NewSubject"));
            return await PostAsync<SubjectModel>(requestUrl, model, token);
        }
    }
}
