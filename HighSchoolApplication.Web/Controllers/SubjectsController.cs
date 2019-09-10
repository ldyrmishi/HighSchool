using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HighSchoolApplication.Web.Factory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HighSchoolApplication.Web.Controllers
{
    public class SubjectsController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var response = await HighSchoolApiClientFactory.Instance.GetSubjects(HttpContext.Session.GetString("Token"));
            return View(response.Data);
        }
    }
}