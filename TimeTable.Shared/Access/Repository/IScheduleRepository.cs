using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeTableDesigner.Shared.Entity.Web;
using TimeTableDesigner.Shared.Enum;

namespace TimeTableDesigner.Shared.Access.Repository
{
    public interface IScheduleRepository
    {
        Task<IEnumerable<WebSemester>> ListSemestersAsync(Func<WebSemester, bool> predicate = null);

        Task<IEnumerable<WebDepartment>> ListDepartmentsAsync(Func<WebDepartment, bool> predicate = null);

        Task<IEnumerable<WebCourse>> ListWebCoursesByDepartmentAsync(string department, string semester, 
            int grade, Limit limit, Func<WebCourse, bool> predicate = null);

        Task<IEnumerable<WebCourse>> ListWebCoursesByNameAsync(string name, string semester,
            Limit limit, Func<WebCourse, bool> predicate = null);

        Task<IEnumerable<WebCourse>> ListWebCoursesByIdAsync(string id, string semester,
            Limit limit, Func<WebCourse, bool> predicate = null);

        Task<IEnumerable<WebCourse>> ListWebCoursesByTeacherAsync(string teacher, string semester,
            Limit limit, Func<WebCourse, bool> predicate = null);
    }
}
