using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using TimeTableDesigner.Shared.Entity.Database;

namespace TimeTableDesigner.Web.Models.TimeTableViewModels
{
    public class TimeTableViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime FirstDay { get; set; }
        public IEnumerable<Course> Courses { get; set; }

        public TimeTable ToTimeTable()
        {
            return null;
        }

        public static TimeTableViewModel Create(TimeTable timeTable)
        {
            return null;
        }
    }
}
