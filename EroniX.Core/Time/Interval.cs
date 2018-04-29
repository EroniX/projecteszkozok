namespace EroniX.Core.Time
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

        public bool IsInInterval(Time time, bool withBorder = true)
        {
            if (withBorder)
            {
                return time.CompareTo(From) != -1 && time.CompareTo(To) != 1;
            }
            return time.CompareTo(From) == 1 && time.CompareTo(To) == -1;
        }

        public bool HaveIntersection(Interval interval, bool withBorder = true)
        {
            return IsInInterval(interval.From, withBorder) || IsInInterval(interval.To, withBorder);
        }
    }
}
