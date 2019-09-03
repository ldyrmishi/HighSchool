﻿using HighSchoolApplication.Web.Factory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HighSchoolApplication.Web.ViewComponents
{
    public class ExpensesViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await HighSchoolApiClientFactory.Instance.GetExpenses(HttpContext.Session.GetString("Token"));
            return View(data);
        }
    }
}
