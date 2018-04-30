///Fájl neve: TimeTableIndexViewModel.cs
///Dátum: 2018. 04. 25.

namespace TimeTableDesigner.Web.Models.TimeTableViewModels
{
    using System.ComponentModel;

    /// <summary>
    /// A TimeTableIndexViewModel osztály
    /// </summary>
    public class TimeTableIndexViewModel
    {
        /// <summary>
        /// A "Name" adattag (GETTER, SETTER)
        /// </summary>
        [DisplayName("Név")]
        public string Name { get; set; }

        /// <summary>
        /// A "Semester" adattag (GETTER, SETTER)
        /// </summary>
        [DisplayName("Félév")]
        public string Semester { get; set; }

        /// <summary>
        /// A "CoursesCount" adattag (GETTER, SETTER)
        /// </summary>
        [DisplayName("Kurzusok száma")]
        public int CoursesCount { get; set; }
    }
}
