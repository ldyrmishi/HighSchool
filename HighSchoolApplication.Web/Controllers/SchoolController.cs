using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HighSchoolApplication.API.Models;
using HighSchoolApplication.Web.Factory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HighSchoolApplication.Web.Controllers
{
    public class SchoolController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var data = await HighSchoolApiClientFactory.Instance.GetSchools(HttpContext.Session.GetString("Token"));
            return View(data.Data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SchoolModel schoolModel)
        {
            if (ModelState.IsValid)
            {
                schoolModel.CreatedAt = DateTime.Now;
                schoolModel.ModifiedAt = DateTime.Now;
                var data = await HighSchoolApiClientFactory.Instance.AddSchool(schoolModel, HttpContext.Session.GetString("Token"));

                return RedirectToAction("Index", "Home");
            }
            return View(schoolModel);
        }
    }
}