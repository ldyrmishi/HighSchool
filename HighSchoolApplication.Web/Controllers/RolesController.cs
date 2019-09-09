using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HighSchoolApplication.Web.Factory;
using HighSchoolApplication.API.Models;
using Microsoft.AspNetCore.Http;

namespace HighSchoolApplication.Web.Controllers
{
    public class RolesController : Controller
    {
        public RolesController()
        {
        }

        // GET: Roles
        public async Task<IActionResult> Index()
        {
            var data = await HighSchoolApiClientFactory.Instance.GetRoles(HttpContext.Session.GetString("Token"));
            return View(data.Data);
        }

        public async Task<IActionResult> Details(int id)
        {
            var role = await HighSchoolApiClientFactory.Instance.GetRoleById(id, HttpContext.Session.GetString("Token"));

            return View(role.Data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoleDescription")] RolesModel roleModel)
        {
            if (ModelState.IsValid)
            {
                roleModel.CreatedAt = DateTime.Now;
                roleModel.ModifiedAt = DateTime.Now;
                var data = await HighSchoolApiClientFactory.Instance.SaveRoles(roleModel,HttpContext.Session.GetString("Token"));

                return RedirectToAction("Index", "Home");
            }
            return View(roleModel);
        }
    }
}
