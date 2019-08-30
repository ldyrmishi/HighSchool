using HighSchoolApplication.Infrastructure;
using HighSchoolApplication.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HighSchoolApplication.Data
{
    public class RolesRepository : IRolesRepository
    {
        private readonly HighSchoolContext _dbContext;

        public RolesRepository(HighSchoolContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Roles> GetAllRoles()
        {
            return _dbContext.Roles;
        }
    }
}
