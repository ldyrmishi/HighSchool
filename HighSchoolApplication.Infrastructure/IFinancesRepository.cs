using HighSchoolApplication.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HighSchoolApplication.Infrastructure
{
    public interface IFinancesRepository
    {
        IEnumerable<Finances> GetAllExpenses();
        IEnumerable<Finances> GetAllIncomings();
    }
}
