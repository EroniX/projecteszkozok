using System;

namespace EroniX.Core.Time
{
    public class Time : IComparable
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

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }

            var time = obj as Time;
            if (time == null)
            {
                throw new ArgumentException();
            }

            if (time.Hour != Hour)
            {
                return time.Hour < Hour
                    ? 1
                    : -1;
            }

            return Minute.CompareTo(time.Minute);
        }
    }
}
