using HighSchoolApplication.Infrastructure;
using HighSchoolApplication.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HighSchoolApplication.Data
{
    public class SubjectsRepository : ISubjectsRepository
    {

        private readonly HighSchoolContext _dbContext;

        public SubjectsRepository(HighSchoolContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Subjects> GetSubjectsByTerm(string term)
        {
            return _dbContext.Subjects.Where(x => x.Term == term).ToList();
        }
    }
}
