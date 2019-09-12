using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HighSchoolApplication.Web.Controllers
{
    public class DiaryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SubjectDiaries()
        {
            return View();
        }
    }
}