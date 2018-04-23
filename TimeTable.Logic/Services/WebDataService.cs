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
    /// <summary>
    /// WebDataService
    /// </summary>
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

        /// <summary>
        /// Kurzus id alapján történő keresése
        /// </summary>
        /// <param name="id">Az azonosító</param>
        /// <param name="semester">A szemeszter</param>
        /// <returns>A megfelelő WebCourse objektum</returns>
        public WebCourse FindCourseById(string id, string semester)
        {
            return ListWebCoursesByIdAsync(id, semester, Limit.All)
                .Result
                .SingleOrDefault();
        }

        /// <summary>
        /// Keresési típusok kilistázása
        /// </summary>
        /// <returns>SearchType objektumokat tartalmazó lista</returns>
        public IEnumerable<SearchType> ListSearchTypes()
        {
            return new List<SearchType>
            {
                SearchType.Name,
                SearchType.Id,
                SearchType.Teacher
            };
        }

        /// <summary>
        /// Korlátok kilistázása
        /// </summary>
        /// <returns>Limit objektumokat tartalmazó lista</returns>
        public IEnumerable<Limit> ListLimits()
        {
            return Enum.GetValues(typeof(Limit))
                .Cast<Limit>();
        }

        /// <summary>
        /// Jegyek listázása
        /// </summary>
        /// <returns>Egy 1-től 5-ig a számokat tartalmazó lista</returns>
        public IEnumerable<int> ListGrades()
        {
            return Enumerable.Range(1, 5);
        }

        /// <summary>
        /// Kurzusok listázása szemeszter alapján
        /// </summary>
        /// <returns>WebCourse objektumokat tartalmazó lista</returns>
        public async Task<IEnumerable<WebSemester>> ListSemestersAsync()
        {
            return await _scheduleRepository.ListSemestersAsync();
        }

        /// <summary>
        /// Kurzusok listázása szak alapján
        /// </summary>
        /// <returns>WebCourse objektumokat tartalmazó lista</returns>
        public async Task<IEnumerable<WebDepartment>> ListDepartmentsAsync()
        {
            return await _scheduleRepository.ListDepartmentsAsync();
        }

        /// <summary>
        /// Kurzusok listázása szak alapján
        /// </summary>
        /// <param name="department">A szak</param>
        /// <param name="semester">A szemeszter</param>
        /// <param name="grade">A jegy</param>
        /// <param name="limit">A limit</param>
        /// <param name="predicate">A predikátum</param>
        /// <returns>WebCourse objektumokat tartalmazó lista</returns>
        public async Task<IEnumerable<WebCourse>> ListWebCoursesByDepartmentAsync(string department, string semester,
            int grade, Limit limit, Func<WebCourse, bool> predicate = null)
        {
            return await _scheduleRepository.ListWebCoursesByDepartmentAsync(department, semester, grade, limit, predicate);
        }

        /// <summary>
        /// Kurzusok listázása név alapján
        /// </summary>
        /// <param name="id">A név</param>
        /// <param name="semester">A szemeszter</param>
        /// <param name="limit">A limit</param>
        /// <param name="predicate">A predikátum</param>
        /// <returns>WebCourse objektumokat tartalmazó lista</returns>
        public async Task<IEnumerable<WebCourse>> ListWebCoursesByNameAsync(string id, string semester,
            Limit limit, Func<WebCourse, bool> predicate = null)
        {
            return await _scheduleRepository.ListWebCoursesByNameAsync(id, semester, limit, predicate);
        }

        /// <summary>
        /// Kurzusok listázása azonosító alapján
        /// </summary>
        /// <param name="id">Az azonosító</param>
        /// <param name="semester">A szemeszter</param>
        /// <param name="limit">A limit</param>
        /// <param name="predicate">A predikátum</param>
        /// <returns>WebCourse objektumokat tartalmazó lista</returns>
        public async Task<IEnumerable<WebCourse>> ListWebCoursesByIdAsync(string id, string semester,
            Limit limit, Func<WebCourse, bool> predicate = null)
        {
            return await _scheduleRepository.ListWebCoursesByIdAsync(id, semester, limit, predicate);
        }

        /// <summary>
        /// Kurzusok listázása tanár alapján
        /// </summary>
        /// <param name="teacher">A tanár</param>
        /// <param name="semester">A szemeszter</param>
        /// <param name="limit">A limit</param>
        /// <param name="predicate">A predikátum</param>
        /// <returns>WebCourse objektumokat tartalmazó lista</returns>
        public async Task<IEnumerable<WebCourse>> ListWebCoursesByTeacherAsync(string teacher,
            string semester, Limit limit, Func<WebCourse, bool> predicate = null)
        {
            return await _scheduleRepository.ListWebCoursesByTeacherAsync(teacher, semester, limit, predicate);
        }
    }
}
