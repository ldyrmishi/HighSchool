using HighSchoolApplication.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HighSchoolApplication.Infrastructure
{
    public interface IDiaryRepository
    {
        /// <summary>
        /// Returns List of Diary for specific subject (multiple lesson)
        /// </summary>
        /// <param name="subjectId"></param>
        /// <returns></returns>
        IEnumerable<Diary> GetDiaryBySubjectId(int subjectId);

        /// <summary>
        /// Returns list of Diary for specific User (multiple lesson)
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        IEnumerable<Diary> GetDiaryByUserId(int UserId);

        /// <summary>
        /// Returns Diary for subject at specific date
        /// </summary>
        /// <param name="diaryDate"></param>
        /// <param name="subjectId"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        Diary GetSpecificDiary(DateTime diaryDate, int subjectId, int UserId);
    }
}
