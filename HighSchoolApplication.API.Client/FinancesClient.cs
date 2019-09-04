using HighSchoolApplication.API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolApplication.API.Client
{
    public partial class ApiClient
    {
        public async Task<Message<List<FinancesModel>>> GetExpenses(string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Finances/ExpensesList"));
            return await GetAsync<List<FinancesModel>>(requestUrl,token);
        }

        public async Task<Message<List<FinancesModel>>> GetIncomings(string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Finances/IncomingsList"));
            return await GetAsync<List<FinancesModel>>(requestUrl, token);
        }

        public async Task<Message<FinancesModel>> SaveFinances(FinancesModel model, string token)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "User/SaveUser"));
            return await PostAsync<FinancesModel>(requestUrl, model,token);
        }
    }
}
