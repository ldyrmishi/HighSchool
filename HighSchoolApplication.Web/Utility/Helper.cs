using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HighSchoolApplication.Web.Utility
{
    public static class Helper
    {
        public static IEnumerable<DateTime> Daily(this TimeSpan ts, DayOfWeek startDayOfWeek = DayOfWeek.Monday, DateTime? checkDay = null)
        {
            var compDate = checkDay ?? DateTime.UtcNow;
            var days = startDayOfWeek - compDate.DayOfWeek;
            days = days > 0 ? days - 7 : days;
            var startDate = compDate.AddDays(days);

            for (var i = 0; i < 7; i++)
            {
                yield return startDate.AddDays(i).Date + ts;
            }
        }
    }
}
