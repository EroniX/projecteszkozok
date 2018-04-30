using System;
using TimeTableDesigner.Shared.Enum;

namespace TimeTableDesigner.Logic.Helpers
{
    public class SchoolHelper
    {
        public static DateTime FirstDay(int? year = null)
        {
            if (year == null)
            {
                year = DateTime.Now.Year;
            }

            var firstDay = new DateTime(year.Value, 9, 1);

            for (var i = 0; i < 4; ++i)
            {
                firstDay = firstDay.AddDays(1);
            }

            while (firstDay.DayOfWeek != DayOfWeek.Monday)
            {
                firstDay = firstDay.AddDays(1);
            }

            return firstDay;
        }

        public static DateTime CourseTime(DateTime firstDay, int week, CourseDay day)
        {
            return firstDay.AddDays((week - 2) * 7 + (int)day);
        }
    }
}
