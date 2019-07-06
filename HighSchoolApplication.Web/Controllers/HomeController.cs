using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HighSchoolApplication.Web.Models;
using HighSchoolApplication.Infrastructure;
using HighSchoolApplication.Infrastructure.Models;

namespace HighSchoolApplication.Web.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IRepository _repository;

        //public HomeController(IRepository repository)
        //{
        //    _repository = repository;
        //}

        public IActionResult Index()
        {
            DashboardViewModel dashboard = new DashboardViewModel();

            dashboard.doctors_count = 4;
            dashboard.nurses_count = 5;
            dashboard.patients_count = 4;

            return View(dashboard);
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
