using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace TimeTableDesigner.Web.Models.TimeTableViewModels
{
    public class TimeTableIndexViewModel
    {
        [DisplayName("Név")]
        public string Name { get; set; }

        [DisplayName("Félév")]
        public string Semester { get; set; }

        [DisplayName("Kurzusok száma")]
        public int CoursesCount { get; set; }
    }
}
