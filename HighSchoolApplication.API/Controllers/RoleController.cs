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
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public Message<IEnumerable<RolesModel>> Get()
        {
            try
            {
                IEnumerable<Roles> roles = _repository.GetAll();

                var rolesModels = _mapper.Map<IEnumerable<RolesModel>>(roles);

                _logger.LogInformation("List of Roles returned succesfully");

                return new Message<IEnumerable<RolesModel>>()
                {
                    StatusCode = 200,
                    IsSuccess = true,
                    ReturnMessage = "OK",
                    Data = rolesModels
                };

            }
            catch(Exception ex)
            {
                _logger.LogError("Error on retrieving list", ex);

                return new Message<IEnumerable<RolesModel>>()
                {
                    StatusCode = 404,
                    IsSuccess = false,
                    ReturnMessage = "Error",
                    Data = null
                };
            }
        }

        // GET: api/Role/5
        [HttpGet("{id}", Name = "Get")]
        public Message<RolesModel> Get(int id)
        {
            try
            {
                var role = _repository.GetById(id);

                var roleModel = _mapper.Map<RolesModel>(role);

                return new Message<RolesModel>()
                {
                    IsSuccess = true,
                    ReturnMessage = "OK",
                    StatusCode = 200,
                    Data = roleModel
                };
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);

                return new Message<RolesModel>()
                {
                    StatusCode = 404,
                    IsSuccess = false,
                    ReturnMessage = "Error",
                    Data = null
                };
            } 
        }

        // POST: api/Role
        [HttpPost]
        [Route("AddRole")]
        public Message<RolesModel> Post([FromBody] RolesModel roleModel)
        {
            try
            {
                var roleEntity = _mapper.Map<Roles>(roleModel);

                _repository.Insert(roleEntity);
                _repository.Save();

                return new Message<RolesModel>()
                {
                    StatusCode = 200,
                    IsSuccess = true,
                    ReturnMessage = "OK",
                    Data = roleModel
                };
            }
            catch(Exception ex)
            {
                _logger.LogError("Error", ex);

                return new Message<RolesModel>()
                {
                    StatusCode = 404,
                    IsSuccess = false,
                    ReturnMessage = "Error",
                    Data = roleModel
                };
            }
            
        }
    }
}
