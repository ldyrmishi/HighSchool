using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HighSchoolApplication.API.Models;
using HighSchoolApplication.Web.Factory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Omu.AwesomeMvc;

namespace HighSchoolApplication.Web.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public async Task<ActionResult> TestView(GridParams g)
        {
            var data = await HighSchoolApiClientFactory.Instance.GetSubjects(HttpContext.Session.GetString("Token"));
            return Json(new GridModelBuilder<SubjectModel>(data.Data.AsQueryable(), g).Build());
        }

    }
}