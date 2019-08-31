using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HighSchoolApplication.API.Models;
using HighSchoolApplication.Infrastructure;
using HighSchoolApplication.Infrastructure.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HighSchoolApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRepository<Roles> _repository;
        private readonly IRolesRepository _rolesRepository;
        private readonly ILogger<RoleController> _logger;
        private readonly IMapper _mapper;

        public RoleController(IRepository<Roles> repository, IRolesRepository rolesRepository, ILogger<RoleController> logger, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _rolesRepository = rolesRepository;
            _mapper = mapper;
        }
        // GET: api/Role
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IEnumerable<RolesModel> Get()
        {
            try
            {
                IEnumerable<Roles> roles = _repository.GetAll();

                var rolesModels = _mapper.Map<IEnumerable<RolesModel>>(roles);

                _logger.LogInformation("List of Roles returned succesfully");

                return rolesModels;

            }
            catch(Exception ex)
            {
                _logger.LogError("Error on retrieving list", ex);
                throw ex;
            }


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
                Id = 1,
                Users = null

            };
            //return _rolesMapper.EntityToDTO(_repository.GetById(id));
            return rolesModel;
        }

        // POST: api/Role
        [HttpPost]
        [Route("AddRole")]
        public void Post([FromBody] RolesModel roleModel)
        {
            var roleEntity = _mapper.Map<Roles>(roleModel);

            _repository.Insert(roleEntity);
            _repository.Save();
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
