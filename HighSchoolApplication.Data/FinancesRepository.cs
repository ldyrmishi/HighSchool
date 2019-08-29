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

        /// <summary>
        /// Returns all expenses of school
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Finances> GetAllExpenses()
        {
            return _dbContext.Finances.Where(x => x.IsExpense == true).ToList();
        }

        /// <summary>
        /// Returns all earnings of school
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Finances> GetAllIncomings()
        {
            return _dbContext.Finances.Where(x => x.IsExpense == false).ToList();
        }
    }
}
