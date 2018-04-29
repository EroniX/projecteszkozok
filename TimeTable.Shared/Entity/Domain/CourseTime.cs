using System;
using EroniX.Core.Time;

namespace TimeTableDesigner.Shared.Entity.Domain
{
    public class CourseTime : Time
    {
        public CourseTime(int hour, int minute) 
            : base(hour, minute)
        { }

        public static CourseTime ToCourseTime(string time)
        {
            if (time == null)
            {
                throw new ArgumentNullException();
            }

            var splitted = time.Split(':');
            if (splitted.Length != 2)
            {
                throw new ArgumentException();
            }

            var hour = int.Parse(splitted[0]);
            var minute = int.Parse(splitted[1]);

            return new CourseTime(hour, minute);
        }
    }
}
