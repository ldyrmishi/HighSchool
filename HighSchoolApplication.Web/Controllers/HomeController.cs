using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HighSchoolApplication.Web.Models;
using HighSchoolApplication.Infrastructure;
using HighSchoolApplication.Infrastructure.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using HighSchoolApplication.Web.Utility;
using HighSchoolApplication.API.Models;
using HighSchoolApplication.Web.Factory;

namespace HighSchoolApplication.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repository;

        //public HomeController(IRepository repository)
        //{
        //    _repository = repository;
        //}
        private readonly ILogger<HomeController> _logger;
        private readonly IOptions<MySettingsViewModel> appSettings;

        public HomeController(IRepository repository,IOptions<MySettingsViewModel> app, ILogger<HomeController> logger)
        {
            appSettings = app;
            ApplicationSettings.WebApiUrl = appSettings.Value.WebApiBaseUrl;
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
            try
            {
                DashboardViewModel dashboard = new DashboardViewModel();

                dashboard.students_count = 476;
                dashboard.teachers_count = 34;
                dashboard.classes_count = 26;

                return View(dashboard);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "HomeController Error");
                return View(); // TODO return error page view
            }
        }

        public async Task<IActionResult> Values()
        {
            var data = await HighSchoolApiClientFactory.Instance.GetValues();
            var response = await SaveValues();
            return View();
        }
        private async Task<JsonResult> SaveValues()
        {
            var model = new ValueModel()
            {
                value1 = "Test",
                value2 = "Test2"
            };

            var response = await HighSchoolApiClientFactory.Instance.SaveValues(model);
            return Json(response);
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
