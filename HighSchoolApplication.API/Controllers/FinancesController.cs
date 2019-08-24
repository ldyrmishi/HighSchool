using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
    public class FinancesController : ControllerBase
    {
        private readonly IRepository<Finances> _repository;
        private readonly IFinancesRepository _financesRepository;
        private readonly ILogger<FinancesController> _logger;
        private readonly IMapper _mapper;

        public FinancesController(IRepository<Finances> repository, IFinancesRepository financesRepository, ILogger<FinancesController> logger, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _financesRepository = financesRepository;
            _mapper = mapper;
        }

        // GET: api/Finances
        [HttpGet]
        public IEnumerable<FinancesModel> Get()
        {
            var data = _financesRepository.GetAllExpenses();
            
            return _mapper.Map<IEnumerable<FinancesModel>>(data);
        }

        // GET: api/Finances/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Finances
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Finances/5
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
