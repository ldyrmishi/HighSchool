using HighSchoolApplication.Infrastructure;
using HighSchoolApplication.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolApplication.Data
{
    public class DocumentsRepository : IDocumentsRepository
    {
        private readonly HighSchoolContext _dbContext;

        public DocumentsRepository(HighSchoolContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Documents> GetPortofolioDocuments(int UserId)
        {
            return _dbContext.Documents.Where(x => x.DocumentCategoryId == 1 && x.UserId == UserId);
        }

        public IEnumerable<Documents> GetPrivateDocuments(int UserId)
        {
            return _dbContext.Documents.Where(x => x.DocumentCategoryId == 2 && x.UserId == UserId);
        }

        public IEnumerable<Documents> GetStudentDocuments(int UserId)
        {
           return _dbContext.Documents.Where(x => x.DocumentCategoryId == 3 && x.UserId == UserId);
        }

        public IEnumerable<Documents> GetSubjectPlanDocuments(int UserId)
        {
            return _dbContext.Documents.Where(x => x.DocumentCategoryId == 4 && x.UserId == UserId);
        }

        public async Task<List<sp_GetStudentCertificateDetails>> GetStudentCertificateData(int UserId)
        {
            return  await _dbContext.GetStudentCertificateDetails(UserId);
        }

    }
}
