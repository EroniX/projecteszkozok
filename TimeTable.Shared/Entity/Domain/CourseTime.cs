///Fájl neve: CourseTime.cs
///Dátum: 2018. 04. 24.

namespace TimeTableDesigner.Shared.Entity.Domain
{
    using System;
    using System.Data;
    using TimeTableDesigner.Shared.Enum;
    using TimeTableDesigner.Shared.Helper.Utility;

    /// <summary>
    /// A CourseTime osztály
    /// </summary>
    public class CourseTime
    {
        /// <summary>
        /// A "CourseDay" adattag (GETTER, SETTER)
        /// </summary>
        public CourseDay CourseDay { get; set; }

        /// <summary>
        /// Az "Interval" adattag (GETTER, SETTER)
        /// </summary>
        public Interval Interval { get; set; }

        /// <summary>
        /// A konstruktor, ami létrehoz egy CourseTime objektumot
        /// </summary>
        /// <param name="courseDay">A CourseDay</param>
        /// <param name="interval">Az Interval</param>
        public CourseTime(CourseDay courseDay, Interval interval)
        {
            CourseDay = courseDay;
            Interval = interval;
        }

        /// <summary>
        /// Az objektum stringgé konvertálását megvalósító függvény
        /// </summary>
        /// <returns>A string reprezentáció</returns>
        public override string ToString()
        {
            return $"{EnumUtility.GetDescriptionFromEnumValue(CourseDay)}, {Interval}";
        }

        /// <summary>
        /// A courseTime string CourseTime objektummá konvertálását megvalósító függvény
        /// </summary>
        /// <param name="courseTime">A courseTime stringként</param>
        /// <returns>Az elkészített CourseTime objektum, ha nem történt hiba</returns>
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
