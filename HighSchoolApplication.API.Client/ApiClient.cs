﻿using HighSchoolApplication.API.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolApplication.API.Client
{
    public partial class ApiClient
    {
        private readonly HttpClient _httpClient;

        private Uri BaseEndpoint { get; set; }

        public ApiClient(Uri baseEndpoint)
        {
            if(baseEndpoint == null)
            {
                throw new ArgumentNullException("baseEndpoint");
            }
            BaseEndpoint = baseEndpoint;
            _httpClient = new HttpClient();
        }
       
        ///<summary>
        /// Common method for making GET calls
        ///</summary>
        //private async Task<T> GetAsync<T>(Uri requestUrl, string token)
        //{
        //    addHeaders(token);
        //    var response = await _httpClient.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);
        //    response.EnsureSuccessStatusCode();
        //    var data = await response.Content.ReadAsStringAsync();
        //    return JsonConvert.DeserializeObject<T>(data);
        //}

        private async Task<Message<T>> GetAsync<T>(Uri requestUrl, string token)
        {
            addHeaders(token);
            var response = await _httpClient.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Message<T>>(data);
        }

        ///<summary>
        /// Common method for making POST calls  
        ///</summary>
        private async Task<Message<T>> PostAsync<T>(Uri requestUrl, T content, string token)
        {
            addHeaders(token);
            var response = await _httpClient.PostAsync(requestUrl.ToString(), CreateHttpContent<T>(content));
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Message<T>>(data);
        }

        private async Task<Message<T1>> PostAsync<T1,T2>(Uri requestUrl, T2 content, string token)
        {
            addHeaders(token);
            var response = await _httpClient.PostAsync(requestUrl.ToString(), CreateHttpContent<T2>(content));
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Message<T1>>(data);
        }

        private Uri CreateRequestUri(string relativePath, string queryString = "")
        {
            var endpoint = new Uri(BaseEndpoint, relativePath);
            var uriBuilder = new UriBuilder(endpoint);
            uriBuilder.Query = queryString;
            return uriBuilder.Uri;
        }

        private HttpContent CreateHttpContent<T>(T content)
        {
            var json = JsonConvert.SerializeObject(content, MicrosoftDateFormatSettings);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private static JsonSerializerSettings MicrosoftDateFormatSettings
        {
            get
            {
                return new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };
            }
        }

        private void addHeaders(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            _httpClient.DefaultRequestHeaders.Remove("userIP");
            _httpClient.DefaultRequestHeaders.Add("userIP", "192.168.1.1");
        }

    }
}
