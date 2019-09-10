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
    }
}
