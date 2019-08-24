using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HighSchoolApplication.Web.Factory;
using HighSchoolApplication.API.Models;

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
            var data = await HighSchoolApiClientFactory.Instance.GetRoles();
            return View(data);
        }

        public async Task<IActionResult> Details(int id)
        {
            var role = await HighSchoolApiClientFactory.Instance.GetRoleById(id);

            return View(role);
        }

        public async Task<IActionResult> Create()
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
                var data = await HighSchoolApiClientFactory.Instance.Login(roleModel);

                return RedirectToAction("Index", "Home");
            }
            return View(roleModel);
        }
    }
}
