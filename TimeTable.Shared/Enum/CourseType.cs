///Fájl neve: CourseType.cs
///Dátum: 2018. 04. 23.

namespace TimeTableDesigner.Shared.Enum
{
    using System.ComponentModel;

    /// <summary>
    /// CourseType felsorolási típus
    /// </summary>
    public enum CourseType
    {
        /// <summary>
        /// Elõadás
        /// </summary>
        [Description("elõadás")]
        Lecture,

        /// <summary>
        /// Gyakorlat
        /// </summary>
        [Description("gyakorlat")]
        Practise,

        /// <summary>
        /// Virtuális
        /// </summary>
        [Description("virtuális")]
        Virtual,

        /// <summary>
        /// Konzultáció
        /// </summary>
        [Description("konzultáció")]
        Constultation,

        /// <summary>
        /// Elfoglaltság
        /// </summary>
        [Description("elfoglaltság")]
        Activity,

        /// <summary>
        /// Szakdolgozat
        /// </summary>
        [Description("szakdolgozat")]
        Thesis,

        /// <summary>
        /// Teremfoglalás
        /// </summary>
        [Description("teremfoglalás")]
        RoomReservation,

        /// <summary>
        /// Otthoni munka
        /// </summary>
        [Description("otthoni munka")]
        HomeWork
    }
}
