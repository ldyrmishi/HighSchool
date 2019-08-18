using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HighSchoolApplication.Web.Factory;
using HighSchoolApplication.API.Models;
using HighSchoolApplication.Infrastructure;
using HighSchoolApplication.Infrastructure.Models;

namespace HighSchoolApplication.Web.Controllers
{
    public class RolesController : Controller
    {
        private readonly IRepository<Roles> _repository;
        private readonly IRolesRepository _rolesRepository;


        public List<RolesModel> rolesListModel = new List<RolesModel>();

        public RolesController(IRepository<Roles> repository, IRolesRepository rolesRepository)
        {
            _repository = repository;
            _rolesRepository = rolesRepository;
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
    }
}
