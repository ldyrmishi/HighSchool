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
    public class DocumentCategoryController : ControllerBase
    {
        public IRepository<DocumentCategory> _repository;
        public IMapper _mapper;
        public ILogger<DocumentCategory> _logger;

        DocumentCategoryController(IRepository<DocumentCategory> repository, IMapper mapper, ILogger<DocumentCategory> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [Route("DocumentCategoriesList")]
        public Message<IEnumerable<DocumentCategoryModel>> Get()
        {
            try
            {
                var documentCategories = _repository.GetAll();
                var documentCategoriesList = _mapper.Map<IEnumerable<DocumentCategoryModel>>(documentCategories);

                return new Message<IEnumerable<DocumentCategoryModel>>()
                {
                    IsSuccess = true,
                    StatusCode = 200,
                    ReturnMessage = "OK",
                    Data = documentCategoriesList
                };
            }
            catch (Exception ex)
            {
                _logger.LogError("Error on getting document categories");
                return new Message<IEnumerable<DocumentCategoryModel>>()
                {
                    IsSuccess = false,
                    StatusCode = 500,
                    ReturnMessage = "Error",
                    Data = null
                };
            }
        }

        [HttpPost]
        [Route("AddDocumentCategories")]
        public Message<DocumentCategoryModel> Post(DocumentCategoryModel documentCategoryModel)
        {
            try
            {
                var data = _mapper.Map<DocumentCategory>(documentCategoryModel);

                _repository.Insert(data);
                _repository.Save();

                return new Message<DocumentCategoryModel>()
                {
                    IsSuccess = true,
                    ReturnMessage = "OK",
                    StatusCode = 200,
                    Data = documentCategoryModel
                };
            }
            catch (Exception ex)
            {
                _logger.LogError("Error on saving document category");
                return new Message<DocumentCategoryModel>()
                {
                    IsSuccess = false,
                    ReturnMessage = "Error on saving document category",
                    StatusCode = 500,
                    Data = null
                };
            }
        }
    }
}