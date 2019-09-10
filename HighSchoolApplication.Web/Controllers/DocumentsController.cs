using System;
using System.Collections.Generic;
using System.IO;
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
                byte[] output = null;

                if (ModelState.IsValid)
                {
                    documentsModel.CreatedAt = DateTime.Now;
                    documentsModel.ModifiedAt = DateTime.Now;
                    int userId = Convert.ToInt32(Request.Form["StudentsList"]);
                    int documentCategoryId = Convert.ToInt32(Request.Form["DocumentCategories"]);
                    documentsModel.UserId = userId;
                    documentsModel.DocumentCategoryId = documentCategoryId;

                    var response = await HighSchoolApiClientFactory.Instance.GenerateDocuments(documentsModel, HttpContext.Session.GetString("Token"));
                    output = response.Data.FileBytes;
                }

                return File(output, "application/pdf");
                //return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View(documentsModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddDocument(IFormFile file, DocumentsModel documentsModel)
        {
            var filepath = Path.GetTempFileName();
            byte[] fileBytes = null;

            if(file.Length > 0)
            {
                using (var stream = new FileStream(filepath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                    stream.Read(fileBytes, 0, (int)stream.Length);
                }
            }

            if (ModelState.IsValid)
            {
                documentsModel.DocumentDescription = file.FileName;
                documentsModel.CreatedAt = DateTime.Now;
                documentsModel.ModifiedAt = DateTime.Now;

                await HighSchoolApiClientFactory.Instance.SaveDocuments(documentsModel, HttpContext.Session.GetString("Token"));

                return RedirectToAction("Index", "Documents");
            }
            return View(documentsModel);
        }
    }
}