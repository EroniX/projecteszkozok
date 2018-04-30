///Fájl neve: Limit.cs
///Dátum: 2018. 04. 23.

namespace TimeTableDesigner.Shared.Enum
{
    using System.ComponentModel;

    /// <summary>
    /// Limit felsorolási típus
    /// </summary>
    public enum Limit
    {
        /// <summary>
        /// Ötven (50)
        /// </summary>
        [Description("50")]
        Fifty = 50,

        /// <summary>
        /// Száz (100)
        /// </summary>
        [Description("100")]
        Hundred = 100,

        /// <summary>
        /// Összes (1000)
        /// </summary>
        [Description("Összes")]
        All = 1000
    }
}
