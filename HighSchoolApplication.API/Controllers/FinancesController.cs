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
        [Route("ExpensesList")]
        public Message<IEnumerable<FinancesModel>> Get()
        {
            try
            {
                var expensesList = _financesRepository.GetAllExpenses();

                var expensesModelList = _mapper.Map<IEnumerable<FinancesModel>>(expensesList);

                return new Message<IEnumerable<FinancesModel>>()
                {
                    IsSuccess = true,
                    ReturnMessage = "Success",
                    StatusCode = 200,
                    Data = expensesModelList

                };
            }
            catch (Exception ex)
            {
                _logger.LogError("Error on getting expenses", ex);

                return new Message<IEnumerable<FinancesModel>>()
                {
                    IsSuccess = false,
                    ReturnMessage = "Error",
                    StatusCode = 404,
                    Data = null
                };
            }
            
        }

        [HttpGet]
        [Route("IncomingsList")]
        public Message<IEnumerable<FinancesModel>> IncomingsList()
        {
            try
            {
                var incomingsList = _financesRepository.GetAllIncomings();
                var icomingsModelList = _mapper.Map<IEnumerable<FinancesModel>>(incomingsList);

                return new Message<IEnumerable<FinancesModel>>()
                {
                    IsSuccess = true,
                    ReturnMessage = "Success",
                    StatusCode = 200,
                    Data = icomingsModelList

                };
            }
            catch (Exception ex)
            {
                _logger.LogError("Error on getting incomings", ex);

                return new Message<IEnumerable<FinancesModel>>()
                {
                    IsSuccess = false,
                    ReturnMessage = "Error",
                    StatusCode = 404,
                    Data = null
                };
            }
        }
    }
}
