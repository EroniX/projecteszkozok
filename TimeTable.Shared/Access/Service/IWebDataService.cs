using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeTableDesigner.Shared.Entity.Web;
using TimeTableDesigner.Shared.Enum;

namespace TimeTableDesigner.Shared.Access.Service
{
    public interface IWebDataService
    {
        IEnumerable<SearchType> ListSearchTypes();

        IEnumerable<Limit> ListLimits();

        IEnumerable<int> ListGrades();

        Task<IEnumerable<WebDepartment>> ListDepartmentsAsync();

        Task<IEnumerable<WebSemester>> ListSemestersAsync();

        Task<IEnumerable<WebCourse>> ListWebCoursesByDepartmentAsync(string department, string semester,
            int grade, Limit limit = Limit.All, Func<WebCourse, bool> predicate = null);

        Task<IEnumerable<WebCourse>> ListWebCoursesByNameAsync(string id, string semester,
            Limit limit = Limit.All, Func<WebCourse, bool> predicate = null);

        Task<IEnumerable<WebCourse>> ListWebCoursesByIdAsync(string id, string semester,
            Limit limit = Limit.All, Func<WebCourse, bool> predicate = null);

        Task<IEnumerable<WebCourse>> ListWebCoursesByTeacherAsync(string teacher, string semester,
            Limit limit = Limit.All, Func<WebCourse, bool> predicate = null);
    }
}
