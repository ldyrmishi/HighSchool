using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HighSchoolApplication.Web.Controllers
{
    public class AccountController : Controller
    {
        //private readonly HighSchoolContext db;

        //private readonly IRepository _repository;

        //public AccountController(IRepository repository)
        //{
        //    _repository = repository;
        //}

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            
            return View();
        }

        //public ActionResult Validate(Users user)
        //{
        //    var _user = db.Users.Where(x => x.Username == user.Username);
        //    if (_user.Any())
        //    {
        //        return Json(new { status = true, message = "Login Successful!" });
        //        //if (_user.Where(s => s.Password == user.Password).Any())
        //        //{
        //        //    return Json(new { status = true, message = "Login Successful!" });
        //        //}
        //        //else
        //        //{
        //        //    return Json(new { status = false, message = "Invalid Password" });
        //        //}
        //    }
        //    else
        //    {
        //        return Json(new { status = false, message = "Invalid Email" });
        //    }
        //}
    }
}
