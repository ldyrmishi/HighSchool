using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
        public IRepository<Users> _genericUsersRepository;
        public IRepository<School> _genericSchoolRepository;
        public IRepository<UsersClass> _genericUsersClassRepository;
        public IRepository<Class> _genericClassRepository;
        public IDocumentsRepository _documentsRepository;
        public ILogger<Documents> _logger;
        
        public DocumentsController(IConverter converter, IRepository<Documents> repository,IRepository<Users> genericUsersRepository,
            IRepository<School> genericSchoolRepository, IRepository<UsersClass> genericUsersClassRepository, IRepository<Class> genericClassRepository, ILogger<Documents> logger,
            IDocumentsRepository documentsRepository
            )
        {
            _converter = converter;
            _repository = repository;
            _genericUsersRepository = genericUsersRepository;
            _genericSchoolRepository = genericSchoolRepository;
            _genericUsersClassRepository = genericUsersClassRepository;
            _genericClassRepository = genericClassRepository;
            _logger = logger;
            _documentsRepository = documentsRepository;
        }

        [HttpPost]
        [Route("GenerateDocument")]
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

    }
}