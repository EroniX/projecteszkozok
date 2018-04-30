///Fájl neve: Time.cs
///Dátum: 2018. 04. 24.

namespace TimeTableDesigner.Shared.Entity.Domain
{
    using System;

    /// <summary>
    /// A Time osztály
    /// </summary>
    public class Time
    {
        /// <summary>
        /// A "Hour" adattag (GETTER, SETTER)
        /// </summary>
        public int Hour { get; set; }

        /// <summary>
        /// A "Minute" adattag (GETTER, SETTER)
        /// </summary>
        public int Minute { get; set; }

        /// <summary>
        /// Az órát megjelenítő függvény
        /// </summary>
        public string DisplayHour=> Hour < 10
            ? $"0{Hour}"
            : Hour.ToString();

        /// <summary>
        /// A percet megjelenítő függvény
        /// </summary>
        public string DisplayMinute=> Minute < 10
            ? $"0{Minute}"
            : Minute.ToString();

        /// <summary>
        /// A konstruktor, ami készít egy Time objektumot 
        /// </summary>
        /// <param name="hour">Az óra</param>
        /// <param name="minute">A perc</param>
        public Time(int hour, int minute)
        {
            Hour = hour;
            Minute = minute;
        }

        /// <summary>
        /// Az objektum stringgé konvertálását megvalósító függvény
        /// </summary>
        /// <returns>A string reprezentáció</returns>
        public override string ToString()
        {
            return $"{DisplayHour}:{DisplayMinute}";
        }

        /// <summary>
        /// A time string Time objektummá konvertálását megvalósító függvény
        /// </summary>
        /// <param name="time">A Time stringként</param>
        /// <returns>Az elkészített Time objektum, ha nem történt hiba</returns>
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
