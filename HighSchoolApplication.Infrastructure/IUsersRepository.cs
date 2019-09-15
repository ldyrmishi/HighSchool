using HighSchoolApplication.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolApplication.Infrastructure
{
    public interface IUsersRepository
    {
        Users GetActiveUserByUsername(string username);
        IList<Users> GetActiveAdministrators();
        IList<Users> GetActiveStudents();
        IList<Users> GetActiveTeachers();
        IList<Users> GetActiveDirectors();
        IList<Users> GetActiveSecretary();
        IList<Users> GetInActiveUsers();
        Roles GetUserRole(int roleId);
        Task<List<sp_GetUserByClass>> GetUsersByClass(int ClassId);
    }
}
