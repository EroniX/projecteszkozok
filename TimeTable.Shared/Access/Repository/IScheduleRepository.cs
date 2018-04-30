///Fájl neve: IScheduleRepository.cs
///Dátum: 2018. 04. 24.

namespace TimeTableDesigner.Shared.Access.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TimeTableDesigner.Shared.Entity.Web;
    using TimeTableDesigner.Shared.Enum;

    /// <summary>
    /// Az IScheduleRepository interfész
    /// </summary>
    public interface IScheduleRepository
    {
        /// <summary>
        /// A szemeszterek listázására szolgáló függvény
        /// </summary>
        /// <param name="predicate">A predikátum</param>
        /// <returns>A szemeszterek egy listában</returns>
        Task<IEnumerable<WebSemester>> ListSemestersAsync(Func<WebSemester, bool> predicate = null);

        /// <summary>
        /// A szakirányok listázására szolgáló függvény
        /// </summary>
        /// <param name="predicate">A predikátum</param>
        /// <returns>A szakirányok egy listában</returns>
        Task<IEnumerable<WebDepartment>> ListDepartmentsAsync(Func<WebDepartment, bool> predicate = null);

        /// <summary>
        /// A kurzusok szakirány alapján történő listázására szolgáló függvény
        /// </summary>
        /// <param name="department">A szakirány</param>
        /// <param name="semester">A szemeszter</param>
        /// <param name="grade">Az évfolyam</param>
        /// <param name="limit">A limit</param>
        /// <param name="predicate">A predikátum</param>
        /// <returns>A megfelelő kurzusok egy listában</returns>
        Task<IEnumerable<WebCourse>> ListWebCoursesByDepartmentAsync(string department, string semester, 
            int grade, Limit limit, Func<WebCourse, bool> predicate = null);

        /// <summary>
        /// A kurzusok név alapján történő listázására szolgáló függvény
        /// </summary>
        /// <param name="name">A kurzus neve</param>
        /// <param name="semester">A szemeszter</param>
        /// <param name="limit">A limit</param>
        /// <param name="predicate">A predikátum</param>
        /// <returns>A megfelelő kurzusok egy listában</returns>
        Task<IEnumerable<WebCourse>> ListWebCoursesByNameAsync(string name, string semester,
            Limit limit, Func<WebCourse, bool> predicate = null);

        /// <summary>
        /// A kurzusok azonosító alapján történő listázására szolgáló függvény
        /// </summary>
        /// <param name="id">Az azonosító</param>
        /// <param name="semester">A szemeszter</param>
        /// <param name="limit">A limit</param>
        /// <param name="predicate">A predikátum</param>
        /// <returns>A megfelelő kurzusok egy listában</returns>
        Task<IEnumerable<WebCourse>> ListWebCoursesByIdAsync(string id, string semester,
            Limit limit, Func<WebCourse, bool> predicate = null);

        /// <summary>
        /// A kurzusok tanár alapján történő listázására szolgáló függvény
        /// </summary>
        /// <param name="teacher">A tanár</param>
        /// <param name="semester">A szemeszter</param>
        /// <param name="limit">A limit</param>
        /// <param name="predicate">A predikátum</param>
        /// <returns>A megfelelő kurzusok egy listában</returns>
        Task<IEnumerable<WebCourse>> ListWebCoursesByTeacherAsync(string teacher, string semester,
            Limit limit, Func<WebCourse, bool> predicate = null);
    }
}
