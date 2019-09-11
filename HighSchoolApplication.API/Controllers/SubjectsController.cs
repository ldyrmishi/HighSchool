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
    public class SubjectsController : ControllerBase
    {
        public IRepository<Subjects> _repository;
        public ISubjectsRepository _subjectsRepository;
        public IMapper _mapper;
        public ILogger<Subjects> _logger;

        public SubjectsController(IRepository<Subjects> repository, ISubjectsRepository subjectsRepository, IMapper mapper, ILogger<Subjects> logger)
        {
            _repository = repository;
            _subjectsRepository = subjectsRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetAllSubjects")]
        public Message<IEnumerable<SubjectModel>> GetAllSubjects()
        {
            try
            {
                var data = _repository.GetAll();
                var subjectsList = _mapper.Map<IEnumerable<SubjectModel>>(data);

                return new Message<IEnumerable<SubjectModel>>()
                {
                    IsSuccess = true,
                    ReturnMessage = "OK",
                    StatusCode = 200,
                    Data = subjectsList
                };
            }
            catch (Exception ex)
            {
                _logger.LogError("Error on Getting users", ex);
                return new Message<IEnumerable<SubjectModel>>()
                {
                    IsSuccess = false,
                    ReturnMessage = "Error",
                    StatusCode = 503,
                    Data = null
                };
            }
        }

        [HttpGet]
        [Route("GetSubjectsByTerm")]
        public Message<IEnumerable<SubjectModel>> GetSubjectsByTerm(string term)
        {
            try
            {
                var data = _subjectsRepository.GetSubjectsByTerm(term);
                var subjectsList = _mapper.Map<IEnumerable<SubjectModel>>(data);

                return new Message<IEnumerable<SubjectModel>>()
                {
                    IsSuccess = true,
                    ReturnMessage = "OK",
                    StatusCode = 200,
                    Data = subjectsList
                };
            }
            catch (Exception ex)
            {
                _logger.LogError("Error on Getting users", ex);
                return new Message<IEnumerable<SubjectModel>>()
                {
                    IsSuccess = false,
                    ReturnMessage = "Error",
                    StatusCode = 503,
                    Data = null
                };
            }
        }

        [HttpPost]
        [Route("NewSubject")]
        public Message<SubjectModel> AddSubject(SubjectModel subjectModel)
        {
            try
            {
                var subjectEntity = _mapper.Map<Subjects>(subjectModel);

                _repository.Insert(subjectEntity);
                _repository.Save();

                return new Message<SubjectModel>()
                {
                    IsSuccess = true,
                    ReturnMessage = "OK",
                    StatusCode = 200,
                    Data = subjectModel
                };
            }
            catch(Exception ex)
            {
                _logger.LogError("Error on saving subject", ex);
                return new Message<SubjectModel>()
                {
                    IsSuccess = false,
                    ReturnMessage = "Error",
                    StatusCode = 503,
                    Data = subjectModel
                };
            }
        }
    }
}