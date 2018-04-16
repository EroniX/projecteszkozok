using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeTableDesigner.DataAccess.DataContext;
using TimeTableDesigner.Shared.Access.Repository;
using TimeTableDesigner.Shared.Entity.Web;
using TimeTableDesigner.Shared.Enum;

namespace TimeTableDesigner.DataAccess.Repository
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly ScheduleContext _scheduleContext;

        public ScheduleRepository(ScheduleContext scheduleContext)
        {
            _scheduleContext = scheduleContext;
        }

        public async Task<IEnumerable<WebSemester>> ListSemestersAsync(Func<WebSemester, bool> predicate = null)
        {
            if (predicate != null)
            {
                return (await _scheduleContext.ListSemestersAsync()).Where(predicate);

            }
            return await _scheduleContext.ListSemestersAsync();
        }

        public async Task<IEnumerable<WebDepartment>> ListDepartmentsAsync(Func<WebDepartment, bool> predicate = null)
        {
            if (predicate != null)
            {
                return (await _scheduleContext.ListDepartmentsAsync()).Where(predicate);
            }
            return await _scheduleContext.ListDepartmentsAsync();
        }

        public async Task<IEnumerable<WebCourse>> ListWebCoursesByDepartmentAsync(string department, string semester,
            int grade, Limit limit, Func<WebCourse, bool> predicate = null)
        {
            if (predicate != null)
            {
                return (await _scheduleContext.ListWebCoursesByDepartmentAsync(department, semester, grade, limit))
                    .Where(predicate);
            }
            return await _scheduleContext.ListWebCoursesByDepartmentAsync(department, semester, grade, limit);
        }

        public async Task<IEnumerable<WebCourse>> ListWebCoursesByNameAsync(string name, string semester,
            Limit limit, Func<WebCourse, bool> predicate = null)
        {
            if (predicate != null)
            {
                return (await _scheduleContext.ListWebCoursesByNameAsync(name, semester, limit)).Where(predicate);
            }
            return await _scheduleContext.ListWebCoursesByNameAsync(name, semester, limit);
        }

        public async Task<IEnumerable<WebCourse>> ListWebCoursesByIdAsync(string id, string semester,
            Limit limit, Func<WebCourse, bool> predicate = null)
        {
            if (predicate != null)
            {
                return (await _scheduleContext.ListWebCoursesByIdAsync(id, semester, limit)).Where(predicate);
            }
            return await _scheduleContext.ListWebCoursesByIdAsync(id, semester, limit);
        }

        public async Task<IEnumerable<WebCourse>> ListWebCoursesByTeacherAsync(string teacher,
            string semester, Limit limit, Func<WebCourse, bool> predicate = null)
        {
            if (predicate != null)
            {
                return (await _scheduleContext.ListWebCoursesByTeacherAsync(teacher, semester, limit)).Where(predicate);
            }
            return await _scheduleContext.ListWebCoursesByTeacherAsync(teacher, semester, limit);
        }
    }
}
