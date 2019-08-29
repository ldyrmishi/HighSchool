using HighSchoolApplication.Infrastructure;
using HighSchoolApplication.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HighSchoolApplication.Data
{
    public class UsersRepository : IUsersRepository
    {
        private readonly HighSchoolContext _dbContext;

        public UsersRepository(HighSchoolContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Users GetActiveUserByUsername(string username)
        {
            Users user = new Users();

            user = _dbContext.Users.Where(x => x.Username == username && x.IsActive == true).FirstOrDefault();
            user.Role = GetUserRole(Convert.ToInt32(user.RoleId));

            return user;
        }

        /// <summary>
        /// Returns specific user role
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns>Return Roles Object</returns>
        public Roles GetUserRole(int roleId)
        {
            return _dbContext.Roles.Where(x => x.Id == roleId).FirstOrDefault();
        }

        /// <summary>
        /// Returns All Active Administrators
        /// </summary>
        /// <returns></returns>
        public IList<Users> GetActiveAdministrators()
        {
            return _dbContext.Users.Where(x => x.RoleId == 1 && x.IsActive == true).ToList();
        }

        /// <summary>
        /// Returns All Active Students
        /// </summary>
        /// <returns>Returns IList<Users></returns>
        public IList<Users> GetActiveStudents()
        {
            return _dbContext.Users.Where(x => x.RoleId == 2 && x.IsActive == true).ToList();
        }

        /// <summary>
        /// Returns All Active Administrators
        /// </summary>
        /// <returns></returns>
        public IList<Users> GetActiveTeachers()
        {
            return _dbContext.Users.Where(x => x.RoleId == 3 && x.IsActive == true).ToList();
        }

        /// <summary>
        /// Returns All Active Administrators
        /// </summary>
        /// <returns></returns>
        public IList<Users> GetActiveDirectors()
        {
            return _dbContext.Users.Where(x => x.RoleId == 4 && x.IsActive == true).ToList();
        }

        /// <summary>
        /// Returns All users with role Secretary
        /// </summary>
        /// <returns></returns>
        public IList<Users> GetActiveSecretary()
        {
            return _dbContext.Users.Where(x => x.RoleId == 5 && x.IsActive == true).ToList();
        }

        /// <summary>
        /// Returns All InActiveUsers
        /// </summary>
        /// <returns></returns>
        public IList<Users> GetInActiveUsers()
        {
            return _dbContext.Users.Where(x => x.IsActive == false).ToList();
        }
    }
}
