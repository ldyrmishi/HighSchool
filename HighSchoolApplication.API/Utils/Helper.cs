using AutoMapper;
using HighSchoolApplication.API.Models;
using HighSchoolApplication.Infrastructure;
using HighSchoolApplication.Infrastructure.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolApplication.API.Utils
{
    public static class Helper
    {
        public static string Hash(string Value)
        {
            return Convert.ToBase64String(System.Security.Cryptography.SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(Value)));
        }

        public static byte[] ReadFileContent(string Url)
        {
            return File.ReadAllBytes(Url);
        }

        public static void AddDocumentToDocumentSet(string documentPath, byte[] fileBytes)
        {
            File.WriteAllBytes(documentPath, fileBytes);
        }

        public static void SaveDocument(DocumentsModel documentsModel,IRepository<Documents> repository, IMapper mapper, ILogger<Documents> logger)
        {
            try
            {
                var documentEntity = mapper.Map<Documents>(documentsModel);

                repository.Insert(documentEntity);
                repository.Save();

            }
            catch (Exception ex)
            {
                logger.LogError("Error", ex);
            }
        }
    }
}
