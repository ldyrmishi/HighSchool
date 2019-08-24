using HighSchoolApplication.Infrastructure;
using HighSchoolApplication.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HighSchoolApplication.Data
{
    public class FinancesRepository : IFinancesRepository
    {
        private readonly HighSchoolContext _dbContext;

        public FinancesRepository(HighSchoolContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Finances> GetAllExpenses()
        {
            return _dbContext.Finances.ToList();
        }
    }
}
