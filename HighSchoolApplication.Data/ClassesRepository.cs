using HighSchoolApplication.Infrastructure;
using HighSchoolApplication.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HighSchoolApplication.Data
{
    public class ClassesRepository : IClassesRepository
    {
        private readonly HighSchoolContext _dbContext;

        public ClassesRepository(HighSchoolContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Return classes by class number example: Class 3A
        /// </summary>
        /// <param name="ClassNo"></param>
        /// <returns></returns>
        public Class GetClassByClassNo(string ClassNo)
        {
            return _dbContext.Class.Where(x => x.ClassNo == ClassNo).FirstOrDefault();
        }

        /// <summary>
        /// Return Classes by ClassYear Example: All classes of 3 year
        /// </summary>
        /// <param name="ClassYear"></param>
        /// <returns></returns>
        public IList<Class> GetClassesByClassYear(int ClassYear)
        {
            return _dbContext.Class.Where(x => x.ClassYear == ClassYear).ToList();
        }

        /// <summary>
        /// Returns All classes of school
        /// </summary>
        /// <returns></returns>
        public IList<Class> GetSchoolClasses(int schoolId)
        {
            return _dbContext.Class.Where(x => x.SchoolId == schoolId).ToList();
        }

        public IEnumerable<Class> GetUserClasses(int UserId)
        {
            IEnumerable<UsersClass> usersClasses = _dbContext.UsersClass.Where(x => x.UserId == UserId);

            IList<Class> listClasses = new List<Class>();
            
            foreach(var item in usersClasses)
            {
                listClasses.Add(_dbContext.Class.Find(item.ClassId));
            }

            return listClasses;
        }
    }
}
