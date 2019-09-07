using HighSchoolApplication.API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolApplication.API.Client
{
    public partial class ApiClient
    {
        public async Task<Message<IEnumerable<DocumentCategoryModel>>> GetDocumentCategories(string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "DocumentCategory/DocumentCategoriesList"));
            return await GetAsync<IEnumerable<DocumentCategoryModel>>(requestUrl, token);
        }

        public async Task<Message<DocumentCategoryModel>> AddDocumentCategory(DocumentCategoryModel model, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "DocumentCategory/AddDocumentCategories"));
            return await PostAsync<DocumentCategoryModel>(requestUrl, model, token);
        }
    }
}
