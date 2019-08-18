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
        private readonly Infrastructure.Models.HighSchoolContext _dbContext;

        public UsersRepository(Infrastructure.Models.HighSchoolContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Users GetActiveUserByUsername(string username)
        {
            return _dbContext.Users.Where(x => x.Username == username).FirstOrDefault();
        }
    }
}
