using HighSchoolApplication.API.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolApplication.API.Client
{
    public partial class ApiClient
    {
        public async Task<Message<List<DocumentsModel>>> GetDocuments(string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "User/GetAllUsers"));
            return await GetAsync<List<DocumentsModel>>(requestUrl,token);
        }

        public async Task<Message<DocumentsModel>> SaveDocuments(DocumentsModel model, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "User/SaveUser"));
            return await PostAsync<DocumentsModel>(requestUrl, model,token);
        }

        public async Task<Message<DocumentsModel>> GenerateDocuments(DocumentsModel model, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Documents/GenerateStudentCertificate"));
            return await PostAsync<DocumentsModel>(requestUrl, model, token);
        }

        public async Task<Message<IEnumerable<DocumentsModel>>> GetUserPrivateDocuments(int id, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Documents/UserPrivateDocuments/{0}", id));
            return await GetAsync<IEnumerable<DocumentsModel>>(requestUrl, token);
        }

        public async Task<Message<IEnumerable<DocumentsModel>>> GetStudentDocuments(int id, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Documents/StudentDocuments/{0}", id));
            return await GetAsync<IEnumerable<DocumentsModel>>(requestUrl, token);
        }

        public async Task<Message<IEnumerable<DocumentsModel>>> GetTeacherSubjectPlans(int id, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Documents/TeacherSubjectPlanDocuments/{0}", id));
            return await GetAsync<IEnumerable<DocumentsModel>>(requestUrl, token);
        }

        public async Task<Message<IEnumerable<DocumentsModel>>> GetTeacherPortofolio(int id, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Documents/TeacherPortofolio/{0}", id));
            return await GetAsync<IEnumerable<DocumentsModel>>(requestUrl, token);
        }

    }
}
