using HighSchoolApplication.Infrastructure;
using HighSchoolApplication.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HighSchoolApplication.Data
{
    public class DiaryRepository : IDiaryRepository
    {
        private readonly HighSchoolContext _dbContext;

        public DiaryRepository(HighSchoolContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Diary> GetDiaryBySubjectId(int subjectId)
        {
            return _dbContext.Diary.Where(x => x.SubjectId == subjectId);
        }

        public IEnumerable<Diary> GetDiaryByUserId(int UserId)
        {
            return _dbContext.Diary.Where(x => x.UserId == UserId);
        }

        public Diary GetSpecificDiary(DateTime diaryDate, int subjectId, int UserId)
        {
            return _dbContext.Diary.Where(x => x.SubjectId == subjectId && x.DiaryDate == diaryDate && x.UserId == UserId).FirstOrDefault();
        }
    }
}
