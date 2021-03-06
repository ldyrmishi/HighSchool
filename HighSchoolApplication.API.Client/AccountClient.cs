﻿using HighSchoolApplication.API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolApplication.API.Client
{
    public partial class ApiClient
    {
        public async Task<Message<LoginModel>> Login(LoginModel model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Account/Login"));
            return await PostAsync<LoginModel>(requestUrl, model,"");
        }
        public async Task<Message<UsersModel>> SaveUsers(UsersModel model, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Account/Register"));
            return await PostAsync<UsersModel>(requestUrl, model, token);
        }
    }
}
