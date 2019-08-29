using HighSchoolApplication.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HighSchoolApplication.Infrastructure
{
    public interface IClassesRepository
    {
        IList<Class> GetSchoolClasses(int schoolId);
        IList<Class> GetClassesByClassYear(int ClassYear);
        Class GetClassByClassNo(string ClassNo);
    }
}
