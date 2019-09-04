using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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

            ViewBag.RolesList = roles.Data.AsEnumerable().Select(b => new SelectListItem { Value = b.Id.ToString(), Text = b.RoleDescription });

            var Gender = new List<SelectListItem>
            {
                new SelectListItem{ Text="Femer", Value = "Femer" },
                new SelectListItem{ Text="Mashkull", Value = "Mashkull" , Selected = true  }
            };

            ViewData["Gender"] = Gender;
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

                //ruhet roli dhe gjinia nga vlerat e zgjedhura te dropdown-it
                string GenderSelectedValue = Request.Form["Gender"].ToString();
                int RoleId = Convert.ToInt32(Request.Form["RolesList"]);
                //userModel.Role = await HighSchoolApiClientFactory.Instance.GetRoleById(RoleId , HttpContext.Session.GetString("Token"));
                await HighSchoolApiClientFactory.Instance.SaveUsers(userModel, HttpContext.Session.GetString("Token"));


                //ketu ben reload-in dhe i mbush perseri me vlera.
                var roles = await HighSchoolApiClientFactory.Instance.GetRoles(HttpContext.Session.GetString("Token"));

                ViewBag.RolesList = roles.Data.AsEnumerable().Select(b => new SelectListItem { Value = b.Id.ToString(), Text = b.RoleDescription });

                var Gender = new List<SelectListItem>
            {
                new SelectListItem{ Text="Femer", Value = "Femer" },
                new SelectListItem{ Text="Mashkull", Value = "Mashkull" , Selected = true  }
            };

                ViewData["Gender"] = Gender;
                //GetData();
                return View(userModel);
            }
            return View(userModel);
        }
       
    }
}
