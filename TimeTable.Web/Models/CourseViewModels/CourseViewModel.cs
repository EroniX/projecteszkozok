using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using TimeTableDesigner.Shared.Enum;

namespace TimeTableDesigner.Web.Models.CourseViewModels
{
    public class CourseViewModel
    {
        [DisplayName("Szak")]
        public string Department { get; set; }

        [DisplayName("Keresés")]
        public string SearchTerm { get; set; }

        [DisplayName("Félév")]
        public string Semester { get; set; }

        [DisplayName("Limit")]
        public Limit Limit { get; set; }

        [DisplayName("Évfolyam")]
        public int Grade { get; set; }

        [DisplayName("Keresés típusa")]
        public SearchType SearchType { get; set; }

        public IEnumerable<SelectListItem> Departments { get; set; }
        public IEnumerable<SelectListItem> Semesters { get; set; }
        public IEnumerable<SelectListItem> Grades { get; set; }
        public IEnumerable<SelectListItem> Limits { get; set; }
        public IEnumerable<SelectListItem> SearchTypes { get; set; }
    }
}
