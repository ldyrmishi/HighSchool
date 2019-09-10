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

        public IEnumerable<Documents> GetPortofolioDocuments()
        {
            return _dbContext.Documents.Where(x => x.DocumentCategoryId == 1);
        }

        public IEnumerable<Documents> GetPrivateDocuments()
        {
            return _dbContext.Documents.Where(x => x.DocumentCategoryId == 2);
        }

        public IEnumerable<Documents> GetStudentDocuments()
        {
           return _dbContext.Documents.Where(x => x.DocumentCategoryId == 3);
        }

        public IEnumerable<Documents> GetSubjectPlanDocuments()
        {
            return _dbContext.Documents.Where(x => x.DocumentCategoryId == 4);
        }

        public async Task<List<sp_GetStudentCertificateDetails>> GetStudentCertificateData(int UserId)
        {
            return  await _dbContext.GetStudentCertificateDetails(UserId);
        }

    }
}
