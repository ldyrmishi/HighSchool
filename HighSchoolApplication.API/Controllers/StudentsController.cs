using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HighSchoolApplication.API.Models;
using HighSchoolApplication.Infrastructure;
using HighSchoolApplication.Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HighSchoolApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly ILogger<StudentsController> _logger;

        public StudentsController(IRepository repository,ILogger<StudentsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        // GET: api/Students
        [HttpGet]
        public IEnumerable<UsersModel> Get()
        {
            var usersList = new List<UsersModel>();
            var usersModel = new UsersModel();

            try
            {
                //1 Te gjithe perdoruesit qe jane studente
                var users = _repository.List<Users>().Where(x => x.Role.RoleId == 1).ToList();
                foreach(var item in users)
                {
                    //

                }

            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                throw new Exception();
            }
            return users;
        }

        // GET: api/Students/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Students
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Students/5
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
