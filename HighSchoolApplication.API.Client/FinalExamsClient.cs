﻿using HighSchoolApplication.API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolApplication.API.Client
{
    public partial class ApiClient
    {
        public async Task<List<FinalExamsModel>> GetFinalExams()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "User/GetAllUsers"));
            return await GetAsync<List<FinalExamsModel>>(requestUrl);
        }

        public async Task<Message<FinalExamsModel>> SaveFinalExams(FinalExamsModel model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "User/SaveUser"));
            return await PostAsync<FinalExamsModel>(requestUrl, model);
        }
    }
}
