///Fájl neve: CourseDay.cs
///Dátum: 2018. 04. 23.

namespace TimeTableDesigner.Shared.Enum
{
    using System.ComponentModel;

    /// <summary>
    /// A CourseDay felsorolási típus
    /// </summary>
    public enum CourseDay
    {
        /// <summary>
        /// Hétfő
        /// </summary>
        [Description("Hétfo")]
        Monday,

        /// <summary>
        /// Kedd
        /// </summary>
        [Description("Kedd")]
        Tuesday,

        /// <summary>
        /// Szerda
        /// </summary>
        [Description("Szerda")]
        Wednesday,

        /// <summary>
        /// Csütörtök
        /// </summary>
        [Description("Csütörtök")]
        Thursday,

        /// <summary>
        /// Péntek
        /// </summary>
        [Description("Péntek")]
        Friday,

        /// <summary>
        /// Szombat
        /// </summary>
        [Description("Szombat")]
        Saturday,

        /// <summary>
        /// Vasárnap
        /// </summary>
        [Description("Vasárnap")]
        Sunday
    }
}
