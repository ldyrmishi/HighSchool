using HighSchoolApplication.Infrastructure;
using HighSchoolApplication.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;
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
            throw new NotImplementedException();
        }

        public IEnumerable<Documents> GetPrivateDocuments()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Documents> GetStudentDocuments()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Documents> GetSubjectPlanDocuments()
        {
            throw new NotImplementedException();
        }

        public async Task<List<sp_GetStudentCertificateDetails>> GetStudentCertificateData(int UserId)
        {
            return  await _dbContext.GetStudentCertificateDetails(UserId);
        }

    }
}
