using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HighSchoolApplication.API.Models;
using HighSchoolApplication.Web.Factory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HighSchoolApplication.Web.Controllers
{
    public class ClassController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var response = await HighSchoolApiClientFactory.Instance.GetClasses(HttpContext.Session.GetString("Token"));
            return View(response.Data);
        }

        public async Task<IActionResult> MyClasses()
        {
            var response = await HighSchoolApiClientFactory.Instance.GetLoggedUserClasses(Convert.ToInt32(HttpContext.Session.GetString("IdUser")), HttpContext.Session.GetString("Token"));
            return View(response.Data);
        }

        public async Task<IActionResult> Create()
        {
            var school = await HighSchoolApiClientFactory.Instance.GetSchools(HttpContext.Session.GetString("Token"));

            ViewBag.SchoolList = school.Data.AsEnumerable().Select(b => new SelectListItem { Value = b.Id.ToString(), Text = b.Name + b.Address });

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClassNo", "ClassYear")] ClassModel classModel)
        {
            if (ModelState.IsValid)
            {
                classModel.CreatedAt = DateTime.Now;
                classModel.ModifiedAt = DateTime.Now;
                int schoolId = Convert.ToInt32(Request.Form["SchoolList"]);
                classModel.SchoolId = schoolId;

                var data = await HighSchoolApiClientFactory.Instance.SaveClass(classModel, HttpContext.Session.GetString("Token"));

                return RedirectToAction("Index");
            }
            return View(classModel);
        }
    }
}