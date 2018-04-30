///Fájl neve: IWebDataService.cs
///Dátum: 2018. 04. 24.

namespace TimeTableDesigner.Shared.Access.Service
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TimeTableDesigner.Shared.Entity.Web;
    using TimeTableDesigner.Shared.Enum;

    /// <summary>
    /// Az IWebDataService interfész
    /// </summary>
    public interface IWebDataService
    {
        /// <summary>
        /// Kurzus id alapján történő keresése
        /// </summary>
        /// <param name="id">Az azonosító</param>
        /// <param name="semester">A szemeszter</param>
        /// <returns>A megfelelő WebCourse objektum</returns>
        WebCourse FindCourseById(string id, string semester);

        /// <summary>
        /// Keresési típusok kilistázása
        /// </summary>
        /// <returns>SearchType objektumokat tartalmazó lista</returns>
        IEnumerable<SearchType> ListSearchTypes();

        /// <summary>
        /// Korlátok kilistázása
        /// </summary>
        /// <returns>Limit objektumokat tartalmazó lista</returns>
        IEnumerable<Limit> ListLimits();

        /// <summary>
        /// Jegyek listázása
        /// </summary>
        /// <returns>Egy 1-től 5-ig a számokat tartalmazó lista</returns>
        IEnumerable<int> ListGrades();

        /// <summary>
        /// Kurzusok listázása szak alapján
        /// </summary>
        /// <returns>WebCourse objektumokat tartalmazó lista</returns>
        Task<IEnumerable<WebDepartment>> ListDepartmentsAsync();

        /// <summary>
        /// Kurzusok listázása szemeszter alapján
        /// </summary>
        /// <returns>WebCourse objektumokat tartalmazó lista</returns>
        Task<IEnumerable<WebSemester>> ListSemestersAsync();

        /// <summary>
        /// Kurzusok listázása szak alapján
        /// </summary>
        /// <param name="department">A szak</param>
        /// <param name="semester">A szemeszter</param>
        /// <param name="grade">A jegy</param>
        /// <param name="limit">A limit</param>
        /// <param name="predicate">A predikátum</param>
        /// <returns>WebCourse objektumokat tartalmazó lista</returns>
        Task<IEnumerable<WebCourse>> ListWebCoursesByDepartmentAsync(string department, string semester,
            int grade, Limit limit, Func<WebCourse, bool> predicate = null);

        /// <summary>
        /// Kurzusok listázása név alapján
        /// </summary>
        /// <param name="id">A név</param>
        /// <param name="semester">A szemeszter</param>
        /// <param name="limit">A limit</param>
        /// <param name="predicate">A predikátum</param>
        /// <returns>WebCourse objektumokat tartalmazó lista</returns>
        Task<IEnumerable<WebCourse>> ListWebCoursesByNameAsync(string id, string semester,
            Limit limit, Func<WebCourse, bool> predicate = null);

        /// <summary>
        /// Kurzusok listázása azonosító alapján
        /// </summary>
        /// <param name="id">Az azonosító</param>
        /// <param name="semester">A szemeszter</param>
        /// <param name="limit">A limit</param>
        /// <param name="predicate">A predikátum</param>
        /// <returns>WebCourse objektumokat tartalmazó lista</returns>
        Task<IEnumerable<WebCourse>> ListWebCoursesByIdAsync(string id, string semester,
            Limit limit, Func<WebCourse, bool> predicate = null);

        /// <summary>
        /// Kurzusok listázása tanár alapján
        /// </summary>
        /// <param name="teacher">A tanár</param>
        /// <param name="semester">A szemeszter</param>
        /// <param name="limit">A limit</param>
        /// <param name="predicate">A predikátum</param>
        /// <returns>WebCourse objektumokat tartalmazó lista</returns>
        Task<IEnumerable<WebCourse>> ListWebCoursesByTeacherAsync(string teacher, string semester,
            Limit limit, Func<WebCourse, bool> predicate = null);
    }
}
