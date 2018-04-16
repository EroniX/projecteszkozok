using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EroniX.Core.Audit;
using EroniX.Core.Services;
using TimeTableDesigner.Shared.Access;
using TimeTableDesigner.Shared.Access.Repository;
using TimeTableDesigner.Shared.Access.Service;
using TimeTableDesigner.Shared.Entity.Web;
using TimeTableDesigner.Shared.Enum;

namespace TimeTableDesigner.Logic.Services
{
    public class WebDataService : ServiceBase<ITimeTableAppContextProvider>, IWebDataService
    {
        private readonly IScheduleRepository _scheduleRepository;

        public WebDataService
        (
            IScheduleRepository scheduleRepository,
            ITimeTableAppContextProvider appContextProvider,
            ILogger logger
        )
            : base(appContextProvider, logger)
        {
            _scheduleRepository = scheduleRepository;
        }

        public WebCourse FindCourseById(string id, string semester)
        {
            return ListWebCoursesByIdAsync(id, semester, Limit.All)
                .Result
                .SingleOrDefault();
        }

        public IEnumerable<SearchType> ListSearchTypes()
        {
            return new List<SearchType>
            {
                SearchType.Name,
                SearchType.Id,
                SearchType.Teacher
            };
        }

        public IEnumerable<Limit> ListLimits()
        {
            return Enum.GetValues(typeof(Limit))
                .Cast<Limit>();
        }

        public IEnumerable<int> ListGrades()
        {
            return Enumerable.Range(1, 5);
        }

        public async Task<IEnumerable<WebSemester>> ListSemestersAsync()
        {
            return await _scheduleRepository.ListSemestersAsync();
        }

        public async Task<IEnumerable<WebDepartment>> ListDepartmentsAsync()
        {
            return await _scheduleRepository.ListDepartmentsAsync();
        }

        public async Task<IEnumerable<WebCourse>> ListWebCoursesByDepartmentAsync(string department, string semester,
            int grade, Limit limit, Func<WebCourse, bool> predicate = null)
        {
            return await _scheduleRepository.ListWebCoursesByDepartmentAsync(department, semester, grade, limit, predicate);
        }

        public async Task<IEnumerable<WebCourse>> ListWebCoursesByNameAsync(string id, string semester,
            Limit limit, Func<WebCourse, bool> predicate = null)
        {
            return await _scheduleRepository.ListWebCoursesByNameAsync(id, semester, limit, predicate);
        }

        public async Task<IEnumerable<WebCourse>> ListWebCoursesByIdAsync(string id, string semester,
            Limit limit, Func<WebCourse, bool> predicate = null)
        {
            return await _scheduleRepository.ListWebCoursesByIdAsync(id, semester, limit, predicate);
        }

        public async Task<IEnumerable<WebCourse>> ListWebCoursesByTeacherAsync(string teacher,
            string semester, Limit limit, Func<WebCourse, bool> predicate = null)
        {
            return await _scheduleRepository.ListWebCoursesByTeacherAsync(teacher, semester, limit, predicate);
        }
    }
}
