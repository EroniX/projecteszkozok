using System;
using TimeTableDesigner.Shared.Enum;
using TimeTableDesigner.Shared.Helper.Utility;

namespace TimeTableDesigner.Shared.Entity.Domain
{
    public class CourseDayInterval
    {
        public CourseDay CourseDay { get; set; }
        public CourseInterval Interval { get; set; }

        public CourseDayInterval(CourseDay courseDay, CourseInterval interval)
        {
            CourseDay = courseDay;
            Interval = interval;
        }

        public override string ToString()
        {
            return $"{EnumUtility.GetDescriptionFromEnumValue(CourseDay)}, {Interval}";
        }

        public static CourseDayInterval ToCourseDayInterval(string courseDayInterval)
        {
            if (courseDayInterval == null)
            {
                throw new ArgumentNullException();
            }

            if (courseDayInterval == "")
            {
                return null;
            }

            var splitted = courseDayInterval.Split(' ');
            if (splitted.Length != 2)
            {
                throw new ArgumentException();
            }

            var courseDay = EnumUtility.GetValueFromDescription<CourseDay>(splitted[0]);
            var interval = CourseInterval.ToCourseInterval(splitted[1]);

            return new CourseDayInterval(
                courseDay
              , interval);
        }
    }
}
