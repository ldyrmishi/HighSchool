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
    public class DiaryController : ControllerBase
    {
        public IRepository<Diary> _repository;
        public IDiaryRepository _diaryRepository;
        public IMapper _mapper;
        public ILogger<Diary> _logger;

        public DiaryController(IRepository<Diary> repository, IDiaryRepository diaryRepository, ILogger<Diary> logger, IMapper mapper)
        {
            _repository = repository;
            _diaryRepository = diaryRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetDiaryBySubjectId/{SubjectId}")]
        public Message<IEnumerable<DiaryModel>> GetDiaryBySubjectId(int SubjectId)
        {
            try
            {
                var diaryEntityList =  _diaryRepository.GetDiaryBySubjectId(SubjectId);
                var diaryList = _mapper.Map<IEnumerable<DiaryModel>>(diaryEntityList);

                return new Message<IEnumerable<DiaryModel>>()
                {
                    IsSuccess = true,
                    StatusCode = 200,
                    ReturnMessage = "OK",
                    Data = diaryList
                };
            }
            catch(Exception ex)
            {
                _logger.LogError("Error", ex);

                return new Message<IEnumerable<DiaryModel>>()
                {
                    IsSuccess = false,
                    StatusCode = 503,
                    ReturnMessage = "Error",
                    Data = null
                };
            }
        }

        [HttpGet]
        [Route("GetDiaryByUserId/{UserId}")]
        public Message<IEnumerable<DiaryModel>> GetDiaryByUserId(int UserId)
        {
            try
            {
                var diaryEntityList = _diaryRepository.GetDiaryByUserId(UserId);
                var diaryList = _mapper.Map<IEnumerable<DiaryModel>>(diaryEntityList);

                return new Message<IEnumerable<DiaryModel>>()
                {
                    IsSuccess = true,
                    StatusCode = 200,
                    ReturnMessage = "OK",
                    Data = diaryList
                };
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);

                return new Message<IEnumerable<DiaryModel>>()
                {
                    IsSuccess = false,
                    StatusCode = 503,
                    ReturnMessage = "Error",
                    Data = null
                };
            }
        }

        [HttpGet]
        [Route("GetSpecificDiary/{date}/{SubjectId}/{UserId}")]
        public  Message<IEnumerable<DiaryModel>> GetSpecificDiary(DateTime date, int SubjectId, int UserId)
        {
            try
            {
                var diaryEntityList = _diaryRepository.GetSpecificDiary(date, SubjectId, UserId);
                var diaryList = _mapper.Map<IEnumerable<DiaryModel>>(diaryEntityList);

                return new Message<IEnumerable<DiaryModel>>()
                {
                    IsSuccess = true,
                    StatusCode = 200,
                    ReturnMessage = "OK",
                    Data = diaryList
                };
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);

                return new Message<IEnumerable<DiaryModel>>()
                {
                    IsSuccess = false,
                    StatusCode = 503,
                    ReturnMessage = "Error",
                    Data = null
                };
            }
        }
    }
}