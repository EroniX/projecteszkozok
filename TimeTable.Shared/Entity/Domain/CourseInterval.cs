using System;
using EroniX.Core.Time;

namespace TimeTableDesigner.Shared.Entity.Domain
{
    public class CourseInterval : Interval
    {
        public CourseInterval(Time from, Time to) 
            : base(from, to)
        { }

        public static CourseInterval ToCourseInterval(string interval)
        {
            if (interval == null)
            {
                throw new ArgumentNullException();
            }

            var splitted = interval.Split('-');
            if (splitted.Length != 2)
            {
                throw new ArgumentException();
            }

            var from = CourseTime.ToCourseTime(splitted[0]);
            var to = CourseTime.ToCourseTime(splitted[1]);

            return new CourseInterval(from, to);
        }
    }
}
