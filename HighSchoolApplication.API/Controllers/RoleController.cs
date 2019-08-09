using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HighSchoolApplication.API.Models;
using HighSchoolApplication.API.Models.Profiles;
using HighSchoolApplication.Infrastructure;
using HighSchoolApplication.Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HighSchoolApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IRolesRepository _rolesRepository;

        RolesListMapper rolesListMapper = new RolesListMapper();
        RolesMapper rolesMapper = new RolesMapper();
        public List<RolesModel> rolesListModel = new List<RolesModel>();

        public RoleController(IRepository repository, IRolesRepository rolesRepository)
        {
            _repository = repository;
            _rolesRepository = rolesRepository;
        }
        // GET: api/Role
        [HttpGet]
        public IEnumerable<RolesModel> Get()
        {
            //return rolesListMapper.entityToDTO(_rolesRepository.GetAllRoles());

            RolesModel rolesModel = new RolesModel()
            {
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                RoleDescription = "Description Test",
                RoleId = 1,
                Users = null

            };

            rolesListModel.Add(rolesModel);
            return rolesListModel;
        }

        // GET: api/Role/5
        [HttpGet("{id}", Name = "Get")]
        public RolesModel Get(int id)
        {
            RolesModel rolesModel = new RolesModel()
            {
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                RoleDescription = "Description Test",
                RoleId = 1,
                Users = null

            };
            //return rolesMapper.EntityToDTO(_repository.GetById<Roles>(id));
            return rolesModel;
        }

        // POST: api/Role
        [HttpPost]
        public void Post([FromBody] RolesModel roleModel)
        {
            //_context.Add(rolesMapper.dtoToEntity(roleModel));
            rolesListModel.Add(roleModel);
        }

        // PUT: api/Role/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
