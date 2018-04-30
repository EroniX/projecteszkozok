///Fájl neve: ScheduleRepository.cs
///Dátum: 2018. 04. 24.

namespace TimeTableDesigner.DataAccess.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TimeTableDesigner.DataAccess.DataContext;
    using TimeTableDesigner.Shared.Access.Repository;
    using TimeTableDesigner.Shared.Entity.Web;
    using TimeTableDesigner.Shared.Enum;

    /// <summary>
    /// Az ütemezésért/órarendért felelős repository
    /// </summary>
    public class ScheduleRepository : IScheduleRepository
    {
        /// <summary>
        /// A "_scheduleContext" adattag
        /// </summary>
        private readonly ScheduleContext _scheduleContext;

        /// <summary>
        /// A konstruktor, ami létrehoz egy ScheduleRepository objektumot
        /// </summary>
        /// <param name="scheduleContext">A ScheduleContext</param>
        public ScheduleRepository(ScheduleContext scheduleContext)
        {
            _scheduleContext = scheduleContext;
        }

        /// <summary>
        /// A szemeszterek listázására szolgáló függvény
        /// </summary>
        /// <param name="predicate">A predikátum</param>
        /// <returns>A szemeszterek egy listában</returns>
        public async Task<IEnumerable<WebSemester>> ListSemestersAsync(Func<WebSemester, bool> predicate = null)
        {
            if (predicate != null)
            {
                return (await _scheduleContext.ListSemestersAsync()).Where(predicate);

            }
            return await _scheduleContext.ListSemestersAsync();
        }

        /// <summary>
        /// A szakirányok listázására szolgáló függvény
        /// </summary>
        /// <param name="predicate">A predikátum</param>
        /// <returns>A szakirányok egy listában</returns>
        public async Task<IEnumerable<WebDepartment>> ListDepartmentsAsync(Func<WebDepartment, bool> predicate = null)
        {
            if (predicate != null)
            {
                return (await _scheduleContext.ListDepartmentsAsync()).Where(predicate);
            }
            return await _scheduleContext.ListDepartmentsAsync();
        }

        /// <summary>
        /// A kurzusok szakirány alapján történő listázására szolgáló függvény
        /// </summary>
        /// <param name="department">A szakirány</param>
        /// <param name="semester">A szemeszter</param>
        /// <param name="grade">Az évfolyam</param>
        /// <param name="limit">A limit</param>
        /// <param name="predicate">A predikátum</param>
        /// <returns>A megfelelő kurzusok egy listában</returns>
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

        /// <summary>
        /// A kurzusok név alapján történő listázására szolgáló függvény
        /// </summary>
        /// <param name="name">A kurzus neve</param>
        /// <param name="semester">A szemeszter</param>
        /// <param name="limit">A limit</param>
        /// <param name="predicate">A predikátum</param>
        /// <returns>A megfelelő kurzusok egy listában</returns>
        public async Task<IEnumerable<WebCourse>> ListWebCoursesByNameAsync(string name, string semester,
            Limit limit, Func<WebCourse, bool> predicate = null)
        {
            if (predicate != null)
            {
                return (await _scheduleContext.ListWebCoursesByNameAsync(name, semester, limit)).Where(predicate);
            }
            return await _scheduleContext.ListWebCoursesByNameAsync(name, semester, limit);
        }

        /// <summary>
        /// A kurzusok azonosító alapján történő listázására szolgáló függvény
        /// </summary>
        /// <param name="id">Az azonosító</param>
        /// <param name="semester">A szemeszter</param>
        /// <param name="limit">A limit</param>
        /// <param name="predicate">A predikátum</param>
        /// <returns>A megfelelő kurzusok egy listában</returns>
        public async Task<IEnumerable<WebCourse>> ListWebCoursesByIdAsync(string id, string semester,
            Limit limit, Func<WebCourse, bool> predicate = null)
        {
            if (predicate != null)
            {
                return (await _scheduleContext.ListWebCoursesByIdAsync(id, semester, limit)).Where(predicate);
            }
            return await _scheduleContext.ListWebCoursesByIdAsync(id, semester, limit);
        }

        /// <summary>
        /// A kurzusok tanár alapján történő listázására szolgáló függvény
        /// </summary>
        /// <param name="teacher">A tanár</param>
        /// <param name="semester">A szemeszter</param>
        /// <param name="limit">A limit</param>
        /// <param name="predicate">A predikátum</param>
        /// <returns>A megfelelő kurzusok egy listában</returns>
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
