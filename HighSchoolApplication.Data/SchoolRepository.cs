using HighSchoolApplication.Infrastructure;
using HighSchoolApplication.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HighSchoolApplication.Data
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly HighSchoolContext _dbContext;

        public SchoolRepository(HighSchoolContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
