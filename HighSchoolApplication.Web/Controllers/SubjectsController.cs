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
    public class SubjectsController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var response = await HighSchoolApiClientFactory.Instance.GetSubjects(HttpContext.Session.GetString("Token"));
            return View(response.Data);
        }

        public ActionResult AddSubject()
        {
            var Term = new List<SelectListItem>
            {
                new SelectListItem{ Text="Semestri i pare", Value = "FirstTerm", Selected = true },
                new SelectListItem{ Text="Semestri i dyte", Value = "SecondTerm"}
            };

            ViewData["Term"] = Term;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSubject([Bind("SubjectTitle", "SubjectDescription","MaxPoints")] SubjectModel subjectModel)
        {
            if (ModelState.IsValid)
            {
                string termSelectedValue = Request.Form["Term"].ToString();

                subjectModel.CreatedAt = DateTime.Now;
                subjectModel.ModifiedAt = DateTime.Now;
                subjectModel.Term = termSelectedValue;

                await HighSchoolApiClientFactory.Instance.AddSubject(subjectModel, HttpContext.Session.GetString("Token"));
            }

            return RedirectToAction("Index");
        }
    }
}