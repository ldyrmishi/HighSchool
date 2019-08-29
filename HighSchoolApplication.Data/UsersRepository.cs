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
            user.Role = _dbContext.Roles.Where(x => x.Id == user.RoleId).FirstOrDefault();

            return user;
        }
    }
}
