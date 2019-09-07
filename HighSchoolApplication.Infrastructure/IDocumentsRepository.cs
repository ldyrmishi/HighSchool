using HighSchoolApplication.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HighSchoolApplication.Infrastructure
{
    public interface IDocumentsRepository
    {
        IEnumerable<Documents> GetPrivateDocuments();
        IEnumerable<Documents> GetStudentDocuments();
        IEnumerable<Documents> GetSubjectPlanDocuments();
        IEnumerable<Documents> GetPortofolioDocuments();
    }
}
