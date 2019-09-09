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
    public class DocumentCategoryController : Controller
    {
        // GET: DocumentCategory
        public async Task<ActionResult> Index()
        {
            var data = await HighSchoolApiClientFactory.Instance.GetDocumentCategories(HttpContext.Session.GetString("Token"));
            return View(data.Data);
        }

        // GET: DocumentCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DocumentCategory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Description")] DocumentCategoryModel documentCategoryModel)
        {
            if (ModelState.IsValid)
            {
                documentCategoryModel.CreatedAt = DateTime.Now;
                documentCategoryModel.ModifiedAt = DateTime.Now;
                var data = await HighSchoolApiClientFactory.Instance.AddDocumentCategory(documentCategoryModel, HttpContext.Session.GetString("Token"));

                return RedirectToAction("Index", "DocumentCategory");
            }
            return View(documentCategoryModel);
        }
    }
}