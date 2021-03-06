﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HighSchoolApplication.Web.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using HighSchoolApplication.Web.Utility;
using HighSchoolApplication.API.Models;
using HighSchoolApplication.Web.Factory;
using Microsoft.AspNetCore.Http;

namespace HighSchoolApplication.Web.Controllers
{
    public class HomeController : Controller
    {


        //public HomeController(IRepository repository)
        //{
        //    _repository = repository;
        //}
        private readonly ILogger<HomeController> _logger;
        private readonly IOptions<MySettingsViewModel> appSettings;

        public HomeController(IOptions<MySettingsViewModel> app, ILogger<HomeController> logger)
        {
            appSettings = app;
            ApplicationSettings.WebApiUrl = appSettings.Value.WebApiBaseUrl;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                DashboardViewModel dashboard = new DashboardViewModel();
                var data =  await HighSchoolApiClientFactory.Instance.GetClasses(HttpContext.Session.GetString("Token"));
                var users = await HighSchoolApiClientFactory.Instance.GetClasses(HttpContext.Session.GetString("Token"));


                dashboard.students_count = users.Data.Count;
                dashboard.teachers_count = 12;
                dashboard.classes_count = data.Data.Count;

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
            var data = await HighSchoolApiClientFactory.Instance.GetValues(HttpContext.Session.GetString("Token"));
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

            var response = await HighSchoolApiClientFactory.Instance.SaveValues(model, HttpContext.Session.GetString("Token"));
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
