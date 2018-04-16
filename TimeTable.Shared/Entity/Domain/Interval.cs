using System;

namespace TimeTableDesigner.Shared.Entity.Domain
{
    public class Interval
    {
        public Time From { get; set; }
        public Time To { get; set; }

        public Interval(Time from, Time to)
        {
            From = from;
            To = to;
        }

        public override string ToString()
        {
            return $"{From}-{To}";
        }

        public static Interval ToInterval(string interval)
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

            var from = Time.ToTime(splitted[0]);
            var to = Time.ToTime(splitted[1]);

            return new Interval(from, to);
        }
    }
}
