///Fájl neve: SearchType.cs
///Dátum: 2018. 04. 23.

namespace TimeTableDesigner.Shared.Enum
{
    using System.ComponentModel;

    /// <summary>
    /// SearchType felsorolái típus
    /// </summary>
    public enum SearchType
    {
        /// <summary>
        /// Név
        /// </summary>
        [Description("Név")]
        Name = 0,

        /// <summary>
        /// Azonosító
        /// </summary>
        [Description("Azonosító")]
        Id = 1,

        /// <summary>
        /// Tanár
        /// </summary>
        [Description("Tanár")]
        Teacher = 2,

        /// <summary>
        /// Szakirány
        /// </summary>
        [Description("Szakirány")]
        Department = 3
    }
}
