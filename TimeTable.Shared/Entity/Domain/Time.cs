using System;

namespace TimeTableDesigner.Shared.Entity.Domain
{
    public class Time
    {
        public int Hour { get; set; }
        public int Minute { get; set; }

        public string DisplayHour => Hour < 10
            ? $"0{Hour}"
            : Hour.ToString();

        public string DisplayMinute => Minute < 10
            ? $"0{Minute}"
            : Minute.ToString();

        public Time(int hour, int minute)
        {
            Hour = hour;
            Minute = minute;
        }

        public override string ToString()
        {
            return $"{DisplayHour}:{DisplayMinute}";
        }

        public static Time ToTime(string time)
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

            return new Time(hour, minute);
        }
    }
}
