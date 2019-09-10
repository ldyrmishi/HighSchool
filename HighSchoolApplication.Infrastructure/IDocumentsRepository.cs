using HighSchoolApplication.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolApplication.Infrastructure
{
    public interface IDocumentsRepository
    {
        /// <summary>
        /// Private documents certificate, ID Card
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        IEnumerable<Documents> GetPrivateDocuments(int UserId);

        /// <summary>
        /// Student documents: Homeworks, Exams
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        IEnumerable<Documents> GetStudentDocuments(int UserId);

        /// <summary>
        /// Teacher Subjects Plans
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        IEnumerable<Documents> GetSubjectPlanDocuments(int UserId);

        /// <summary>
        /// Teacher Portofolio
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        IEnumerable<Documents> GetPortofolioDocuments(int UserId);

        Task<List<sp_GetStudentCertificateDetails>> GetStudentCertificateData(int UserId);
    }
}
