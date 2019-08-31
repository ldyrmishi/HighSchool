using HighSchoolApplication.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HighSchoolApplication.Infrastructure
{
    public interface ISubjectsRepository
    {
        IList<Subjects> GetSubjectsByTerm(string term);
    }
}
