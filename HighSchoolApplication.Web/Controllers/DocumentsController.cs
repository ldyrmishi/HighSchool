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
    public class DocumentsController : Controller
    {
        // GET: Documents
        public ActionResult Index()
        {
            return View();
        }

        // GET: Documents/Create
        public async Task<IActionResult> GenerateStudentCertificate()
        {
            var students = await HighSchoolApiClientFactory.Instance.GetActiveStudents(HttpContext.Session.GetString("Token"));

            ViewBag.StudentsList = students.Data.AsEnumerable().Select(x => new SelectListItem { Value = x.Id.ToString(), Text = (x.Firstname + " " + x.Lastname) });

            var documentCategories = await HighSchoolApiClientFactory.Instance.GetDocumentCategories(HttpContext.Session.GetString("Token"));

            ViewBag.DocumentCategories = documentCategories.Data.AsEnumerable().Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Description });

            return View();
        }

        // POST: Documents/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GenerateStudentCertificate(DocumentsModel documentsModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    documentsModel.CreatedAt = DateTime.Now;
                    documentsModel.ModifiedAt = DateTime.Now;
                    int userId = Convert.ToInt32(Request.Form["StudentsList"]);
                    int documentCategoryId = Convert.ToInt32(Request.Form["DocumentCategories"]);
                    documentsModel.UserId = userId;
                    documentsModel.DocumentCategoryId = documentCategoryId;

                    await HighSchoolApiClientFactory.Instance.GenerateDocuments(documentsModel, HttpContext.Session.GetString("Token"));

                }
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View(documentsModel);
            }
        }
    }
}