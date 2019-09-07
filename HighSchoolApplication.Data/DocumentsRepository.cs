using HighSchoolApplication.Infrastructure;
using HighSchoolApplication.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HighSchoolApplication.Data
{
    public class DocumentsRepository : IDocumentsRepository
    {
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
    }
}
