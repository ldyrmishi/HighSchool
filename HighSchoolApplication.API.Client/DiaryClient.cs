using HighSchoolApplication.API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolApplication.API.Client
{
    public partial class ApiClient
    {
        public async Task<Message<IEnumerable<DiaryModel>>> GetDiaryBySubjectId(int SubjectId, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Diary/GetDiaryBySubjectId/{0}", SubjectId));
            return await GetAsync<IEnumerable<DiaryModel>>(requestUrl, token);
        }

        public async Task<Message<IEnumerable<DiaryModel>>> GetDiaryByUserId(int UserId, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Diary/GetDiaryByUserId/{0}", UserId));
            return await GetAsync<IEnumerable<DiaryModel>>(requestUrl, token);
        }

        public async Task<Message<IEnumerable<DiaryModel>>> GetSpecificDiary(DateTime date,int SubjectId,int UserId, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Diary/UserPrivateDocuments/{0}/{1}/{2}",date, SubjectId,UserId));
            return await GetAsync<IEnumerable<DiaryModel>>(requestUrl, token);
        }


    }
}
