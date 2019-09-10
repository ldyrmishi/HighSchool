using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DinkToPdf;
using DinkToPdf.Contracts;
using HighSchoolApplication.API.Drops;
using HighSchoolApplication.API.Models;
using HighSchoolApplication.API.Utils;
using HighSchoolApplication.Infrastructure;
using HighSchoolApplication.Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HighSchoolApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {

        private IConverter _converter;
        public IRepository<Documents> _repository;
        public IDocumentsRepository _documentsRepository;
        public ILogger<Documents> _logger;
        public IMapper _mapper;
        
        public DocumentsController(IConverter converter, IRepository<Documents> repository, ILogger<Documents> logger,IDocumentsRepository documentsRepository, IMapper mapper)
        {
            _converter = converter;
            _repository = repository;
            _logger = logger;
            _documentsRepository = documentsRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("UserPrivateDocuments")]
        public Message<IEnumerable<DocumentsModel>> GetUserPrivateDocuments(int UserId)
        {
            try
            {
                var documents = _documentsRepository.GetPrivateDocuments(UserId);

                var documentsModel = _mapper.Map <IEnumerable<DocumentsModel>> (documents);

                return new Message<IEnumerable<DocumentsModel>>()
                {
                    IsSuccess = true,
                    ReturnMessage = "OK",
                    StatusCode = 200,
                    Data = documentsModel
                };
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);

                return new Message<IEnumerable<DocumentsModel>>()
                {
                    StatusCode = 404,
                    IsSuccess = false,
                    ReturnMessage = "Error",
                    Data = null
                };
            }
        }

        [HttpGet]
        [Route("StudentDocuments")]
        public Message<IEnumerable<DocumentsModel>> GetStudentDocuments(int UserId)
        {
            try
            {
                var documents = _documentsRepository.GetStudentDocuments(UserId);

                var documentsModel = _mapper.Map<IEnumerable<DocumentsModel>>(documents);

                return new Message<IEnumerable<DocumentsModel>>()
                {
                    IsSuccess = true,
                    ReturnMessage = "OK",
                    StatusCode = 200,
                    Data = documentsModel
                };
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);

                return new Message<IEnumerable<DocumentsModel>>()
                {
                    StatusCode = 404,
                    IsSuccess = false,
                    ReturnMessage = "Error",
                    Data = null
                };
            }
        }

        [HttpGet]
        [Route("TeacherSubjectPlanDocuments")]
        public Message<IEnumerable<DocumentsModel>> GetTeacherSubjectPlans(int UserId)
        {
            try
            {
                var documents = _documentsRepository.GetSubjectPlanDocuments(UserId);

                var documentsModel = _mapper.Map<IEnumerable<DocumentsModel>>(documents);

                return new Message<IEnumerable<DocumentsModel>>()
                {
                    IsSuccess = true,
                    ReturnMessage = "OK",
                    StatusCode = 200,
                    Data = documentsModel
                };
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);

                return new Message<IEnumerable<DocumentsModel>>()
                {
                    StatusCode = 404,
                    IsSuccess = false,
                    ReturnMessage = "Error",
                    Data = null
                };
            }
        }

        [HttpGet]
        [Route("TeacherPortofolio")]
        public Message<IEnumerable<DocumentsModel>> GetTeacherPortofolio(int UserId)
        {
            try
            {
                var documents = _documentsRepository.GetPortofolioDocuments(UserId);

                var documentsModel = _mapper.Map<IEnumerable<DocumentsModel>>(documents);

                return new Message<IEnumerable<DocumentsModel>>()
                {
                    IsSuccess = true,
                    ReturnMessage = "OK",
                    StatusCode = 200,
                    Data = documentsModel
                };
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);

                return new Message<IEnumerable<DocumentsModel>>()
                {
                    StatusCode = 404,
                    IsSuccess = false,
                    ReturnMessage = "Error",
                    Data = null
                };
            }
        }

        [HttpPost]
        [Route("GenerateStudentCertificate")]
        public async Task<Message<DocumentsModel>> GenerateDocuments(DocumentsModel documentsModel)
        {
            try
            {
                var studentCertificateData = await _documentsRepository.GetStudentCertificateData(Convert.ToInt32(documentsModel.UserId));

                var model = new StudentCertificationDrop();
                
                model.CreationDate = DateTime.Now;
                model.NoAmze = studentCertificateData[0].NrAmze;
                model.SchoolName = studentCertificateData[0].SchoolName;
                model.StudentName = studentCertificateData[0].FullName;
                model.StudentYear = studentCertificateData[0].ClassYear;

                var globalSettings = new GlobalSettings
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                    Margins = new MarginSettings { Top = 10 },
                    DocumentTitle = "Vertetim Studenti",
                    Out = $@"C:\inetpub\wwwroot\HighSchool-API\media\vertetim\VertetimUser{model.StudentName}.pdf"
                };

                var objectSettings = new ObjectSettings
                {
                    PagesCount = true,
                    HtmlContent = TemplateGenerator.GetStudentCertificationHtml("vertetim", model),
                    FooterSettings = { FontName = "Arial", FontSize = 9, Right = "Faqe [page] nga [toPage]", Line = true }
                };

                
                var pdf = new HtmlToPdfDocument()
                {
                    GlobalSettings = globalSettings,
                    Objects = { objectSettings }
                };

                var output = _converter.Convert(pdf);

                documentsModel.FileBytes = output;
                documentsModel.DocumentUrl = globalSettings.Out;

                SaveDocument(documentsModel);

                return new Message<DocumentsModel>()
                {
                    IsSuccess = true,
                    ReturnMessage = "OK",
                    StatusCode = 200,
                    Data = documentsModel
                };
                //return File(output, "application/pdf");
            }
            catch(Exception ex)
            {
                _logger.LogError("Error on generating", ex);
                return new Message<DocumentsModel>()
                {
                    IsSuccess = false,
                    ReturnMessage = "Error",
                    StatusCode = 500,
                    Data = null
                };
            }
            
        }

        public void SaveDocument(DocumentsModel documentsModel)
        {
            try
            {
                var documentEntity = _mapper.Map<Documents>(documentsModel);

                _repository.Insert(documentEntity);
                _repository.Save();

            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
            }
        }
    }
}