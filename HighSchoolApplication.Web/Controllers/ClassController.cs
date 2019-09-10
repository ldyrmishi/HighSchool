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
    public class ClassController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var response = await HighSchoolApiClientFactory.Instance.GetClasses(HttpContext.Session.GetString("Token"));
            return View(response.Data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoleDescription")] ClassModel classModel)
        {
            if (ModelState.IsValid)
            {
                classModel.CreatedAt = DateTime.Now;
                classModel.ModifiedAt = DateTime.Now;
                var data = await HighSchoolApiClientFactory.Instance.SaveClass(classModel, HttpContext.Session.GetString("Token"));

                return RedirectToAction("Index", "Home");
            }
            return View(classModel);
        }
    }
}