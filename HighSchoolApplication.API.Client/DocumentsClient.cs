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
        public async Task<Message<DocumentsModel>> GetDocumentById(int idDocument, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Documents/GetDocumentById/{0}", idDocument));
            return await GetAsync<DocumentsModel>(requestUrl, token);
        }


        public async Task<Message<DocumentsModel>> AddDocument(DocumentsModel model, string token)
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
