using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HighSchoolApplication.API.Models;
using HighSchoolApplication.Web.Factory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HighSchoolApplication.Web.Controllers
{
    public class AccountController : Controller
    {

        public IActionResult Login()
        {
           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Username,Password")] LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var data = await HighSchoolApiClientFactory.Instance.Login(loginModel);

                HttpContext.Session.SetString("Token", data.Data.Token);

                return RedirectToAction("Index", "Home");
            }
            return View(loginModel);
        }

        public async Task<IActionResult> Register()
        {
            var roles = await HighSchoolApiClientFactory.Instance.GetRoles(HttpContext.Session.GetString("Token"));

            ViewBag.RolesList = roles.AsEnumerable().Select(b => new SelectListItem { Value = b.Id.ToString(), Text = b.RoleDescription }
);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UsersModel userModel)
        {
            if (ModelState.IsValid)
            {
                userModel.CreatedAt = DateTime.Now;
                userModel.ModifiedAt = DateTime.Now;
                var data = await HighSchoolApiClientFactory.Instance.SaveUsers(userModel, HttpContext.Session.GetString("Token"));

                return RedirectToAction("Index", "Home");
            }
            return View(userModel);
        }
    }
}
