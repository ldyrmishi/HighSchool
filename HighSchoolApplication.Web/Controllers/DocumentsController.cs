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

        public async Task<IActionResult> GetDocumentById(int id)
        {
            var response = await HighSchoolApiClientFactory.Instance.GetDocumentById(id, HttpContext.Session.GetString("Token"));
            byte[] output = response.Data.FileBytes;

            return File(output, "application/pdf");
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

        public async Task<IActionResult> AddDocument()
        {
            var users = await HighSchoolApiClientFactory.Instance.GetUsersList(HttpContext.Session.GetString("Token"));

            ViewBag.UsersList = users.Data.AsEnumerable().Select(x => new SelectListItem { Value = x.Id.ToString(), Text = (x.Firstname + " " + x.Lastname) });

            var subjectsList = await HighSchoolApiClientFactory.Instance.GetSubjects(HttpContext.Session.GetString("Token"));

            ViewBag.SubjectsList = subjectsList.Data.AsEnumerable().Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.SubjectTitle });

            var documentCategories = await HighSchoolApiClientFactory.Instance.GetDocumentCategories(HttpContext.Session.GetString("Token"));

            ViewBag.DocumentCategories = documentCategories.Data.AsEnumerable().Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Description });

            return View();
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
                documentsModel.UserId = Convert.ToInt32(Request.Form["UsersList"]);
                documentsModel.SubjectId = Convert.ToInt32(Request.Form["SubjectsList"]);
                documentsModel.DocumentCategoryId = Convert.ToInt32(Request.Form["DocumentCategories"]);

                await HighSchoolApiClientFactory.Instance.AddDocument(documentsModel, HttpContext.Session.GetString("Token"));

                return RedirectToAction("Index", "Documents");
            }
            return View(documentsModel);
        }

        public async Task<IActionResult> StudentsDocuments()
        {
            var response = await HighSchoolApiClientFactory.Instance.GetStudentDocuments(Convert.ToInt32(HttpContext.Session.GetString("IdUser")),HttpContext.Session.GetString("Token"));
            return View(response.Data);
        }

        public async Task<IActionResult> TeacherPortofolioDocuments()
        {
            var response = await HighSchoolApiClientFactory.Instance.GetTeacherPortofolio(Convert.ToInt32(HttpContext.Session.GetString("IdUser")), HttpContext.Session.GetString("Token"));
            return View(response.Data);
        }

        public async Task<IActionResult> TeacherSubjectPlans()
        {
            var response = await HighSchoolApiClientFactory.Instance.GetTeacherSubjectPlans(Convert.ToInt32(HttpContext.Session.GetString("IdUser")), HttpContext.Session.GetString("Token"));
            return View(response.Data);
        }

        public async Task<IActionResult> UserPrivateDocuments()
        {
            var response = await HighSchoolApiClientFactory.Instance.GetUserPrivateDocuments(Convert.ToInt32(HttpContext.Session.GetString("IdUser")), HttpContext.Session.GetString("Token"));
            return View(response.Data);
        }
    }
}