using System;
using System.Data;
using TimeTableDesigner.Shared.Enum;
using TimeTableDesigner.Shared.Helper.Utility;

namespace TimeTableDesigner.Shared.Entity.Domain
{
    public class CourseTime
    {
        public CourseDay CourseDay { get; set; }
        public Interval Interval { get; set; }

        public CourseTime(CourseDay courseDay, Interval interval)
        {
            CourseDay = courseDay;
            Interval = interval;
        }

        public override string ToString()
        {
            return $"{EnumUtility.GetDescriptionFromEnumValue(CourseDay)}, {Interval}";
        }

        public static CourseTime ToCourseTime(string courseTime)
        {
            if (courseTime == null)
            {
                throw new ArgumentNullException();
            }

            if (courseTime == "")
            {
                return null;
            }

            var splitted = courseTime.Split(' ');
            if (splitted.Length != 2)
            {
                throw new ArgumentException();
            }

            var courseDay = EnumUtility.GetValueFromDescription<CourseDay>(splitted[0]);
            var interval = Interval.ToInterval(splitted[1]);

            return new CourseTime(
                courseDay
              , interval);
        }
    }
}
