///Fájl neve: Interval.cs
///Dátum: 2018. 04. 24.

namespace TimeTableDesigner.Shared.Entity.Domain
{
    using System;

    /// <summary>
    /// Az Interval osztály
    /// </summary>
    public class Interval
    {
        /// <summary>
        /// A "From" adattag (GETTER, SETTER)
        /// </summary>
        public Time From { get; set; }

        /// <summary>
        /// A "To" adattag (GETTER, SETTER)
        /// </summary>
        public Time To { get; set; }

        /// <summary>
        /// A konstruktor, ami létrehoz egy Interval objektumot
        /// </summary>
        /// <param name="from">A kezdete (Time)</param>
        /// <param name="to">A vége (Time)</param>
        public Interval(Time from, Time to)
        {
            From = from;
            To = to;
        }

        /// <summary>
        /// Az objektum stringgé konvertálását megvalósító függvény
        /// </summary>
        /// <returns>A string reprezentáció</returns>
        public override string ToString()
        {
            return $"{From}-{To}";
        }

        /// <summary>
        /// Az interval string Interval objektummá konvertálását megvalósító függvény
        /// </summary>
        /// <param name="interval">Az interval stringként</param>
        /// <returns>Az elkészített Interval objektum, ha nem történt hiba</returns>
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
