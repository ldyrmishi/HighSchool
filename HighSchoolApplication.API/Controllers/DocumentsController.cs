//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;
//using DinkToPdf;
//using DinkToPdf.Contracts;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace HighSchoolApplication.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class DocumentsController : ControllerBase
//    {

//        private IConverter _converter;
//        public DocumentsController(IConverter converter)
//        {
//            _converter = converter;
//        }

//        [HttpGet]
//        [Route("/api/GenerateDocument")]

//        public IActionResult GenerateDocuments()
//        { 
//            var globalSettings = new GlobalSettings
//            {
//                ColorMode = ColorMode.Color,
//                Orientation = Orientation.Portrait,
//                PaperSize = PaperKind.A4,
//                Margins = new MarginSettings { Top = 10 },
//                DocumentTitle = "PDF Report",
//                Out = @"D:\PDFCreator\Employee_Report.pdf"
//            };

//            var objectSettings = new ObjectSettings
//            {
//                PagesCount = true,
//                HtmlContent = TemplateGenerator.GetHTMLString(),
//                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
//                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
//                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
//            };

//            var pdf = new HtmlToPdfDocument()
//            {
//                GlobalSettings = globalSettings,
//                Objects = { objectSettings }
//            };

//            var output = _converter.Convert(pdf);

//            return File(output, "application/pdf");
//        }

//    }
//}