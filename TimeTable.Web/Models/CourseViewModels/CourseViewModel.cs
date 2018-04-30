///Fájl neve: CourseViewModel.cs
///Dátum: 2018. 04. 25.

namespace TimeTableDesigner.Web.Models.CourseViewModels
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.ComponentModel;
    using TimeTableDesigner.Shared.Enum;

    /// <summary>
    /// A CourseViewModel osztály
    /// </summary>
    public class CourseViewModel
    {
        /// <summary>
        /// A "Department" adattag (GETTER, SETTER)
        /// </summary>
        [DisplayName("Szak")]
        public string Department { get; set; }

        /// <summary>
        /// A "SearchTerm" adattag (GETTER, SETTER)
        /// </summary>
        [DisplayName("Keresés")]
        public string SearchTerm { get; set; }

        /// <summary>
        /// A "Semester" adattag (GETTER, SETTER)
        /// </summary>
        [DisplayName("Félév")]
        public string Semester { get; set; }

        /// <summary>
        /// A "Limit" adattag (GETTER, SETTER)
        /// </summary>
        [DisplayName("Limit")]
        public Limit Limit { get; set; }

        /// <summary>
        /// A "Grade" adattag (GETTER, SETTER)
        /// </summary>
        [DisplayName("Évfolyam")]
        public int Grade { get; set; }

        /// <summary>
        /// A "SearchType" adattag (GETTER, SETTER)
        /// </summary>
        [DisplayName("Keresés típusa")]
        public SearchType SearchType { get; set; }

        /// <summary>
        /// A "Departments" adattag (GETTER, SETTER)
        /// </summary>
        public IEnumerable<SelectListItem> Departments { get; set; }

        /// <summary>
        /// A "Semesters" adattag (GETTER, SETTER)
        /// </summary>
        public IEnumerable<SelectListItem> Semesters { get; set; }

        /// <summary>
        /// A "Grades" adattag (GETTER, SETTER)
        /// </summary>
        public IEnumerable<SelectListItem> Grades { get; set; }

        /// <summary>
        /// A "Limits" adattag (GETTER, SETTER)
        /// </summary>
        public IEnumerable<SelectListItem> Limits { get; set; }

        /// <summary>
        /// A "SearchTypes" adattag (GETTER, SETTER)
        /// </summary>
        public IEnumerable<SelectListItem> SearchTypes { get; set; }
    }
}
