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
    public class SchoolController : ControllerBase
    {
        private readonly IRepository<School> _repository;
        private readonly ILogger<School> _logger;
        private readonly IMapper _mapper;

        public SchoolController(IRepository<School> repository, ILogger<School> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("SchoolsList")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IEnumerable<SchoolModel> Get()
        {
            try
            {
                IEnumerable<School> schools = _repository.GetAll();

                var schoolList = _mapper.Map<IEnumerable<SchoolModel>>(schools);

                _logger.LogInformation("List of Schools returned succesfully");

                return schoolList;

            }
            catch (Exception ex)
            {
                _logger.LogError("Error on retrieving list", ex);
                throw ex;
            }
        }

        [HttpPost]
        [Route("AddSchool")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public void Post([FromBody] SchoolModel schoolModel)
        {
            try
            {
                var schoolEntity = _mapper.Map<School>(schoolModel);

                _repository.Insert(schoolEntity);
                _repository.Save();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error on Inserting School", ex);
                throw ex;
            }
        }

        [HttpPost]
        [Route("EditSchool")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public void EditSchool([FromBody] SchoolModel schoolModel)
        {
            try
            {
                var schoolEntity = _mapper.Map<School>(schoolModel);

                _repository.Update(schoolEntity);
                _repository.Save();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error on Inserting School", ex);
                throw ex;
            }
        }
    }
}