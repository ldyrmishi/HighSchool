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
    public class ClassesController : ControllerBase
    {
        private readonly IRepository<Class> _repository;
        private readonly IClassesRepository _classesRepository;
        private readonly ILogger<Class> _logger;
        private readonly IMapper _mapper;

        public ClassesController (IRepository<Class> repository, IClassesRepository classesRepository, ILogger<Class> logger, IMapper mapper)
        {
            _repository = repository;
            _classesRepository = classesRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IEnumerable<ClassModel> Get()
        {
            try
            {
                IEnumerable<Class> classes = _repository.GetAll();

                var classList = _mapper.Map<IEnumerable<ClassModel>>(classes);

                _logger.LogInformation("List of classes returned succesfully");

                return classList;

            }
            catch (Exception ex)
            {
                _logger.LogError("Error on retrieving list", ex);
                throw ex;
            }
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("AddClass")]
        public void Post([FromBody] ClassModel classModel)
        {
            var classEntity = _mapper.Map<Class>(classModel);

            _repository.Insert(classEntity);
            _repository.Save();
        }
    }
}