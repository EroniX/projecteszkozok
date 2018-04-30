///Fájl neve: ScheduleContext.cs
///Dátum: 2018. 04. 24.

namespace TimeTableDesigner.DataAccess.DataContext
{
    using EroniX.Core.Config;
    using HtmlAgilityPack;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TimeTableDesigner.Shared.Entity.Web;
    using TimeTableDesigner.Shared.Enum;
    using TimeTableDesigner.Shared.Helper.Converter.StringToList;
    using TimeTableDesigner.Shared.Helper.Web;

    /// <summary>
    /// A ScheduleContext osztály
    /// </summary>
    public class ScheduleContext
    {
        /// <summary>
        /// A "_webHtmlReader" adattag
        /// </summary>
        private readonly IWebHtmlReader _webHtmlReader;

        /// <summary>
        /// A "_htmlTableToListConverter" adattag
        /// </summary>
        private readonly IStringToListConverter _htmlTableToListConverter;

        /// <summary>
        /// A "_htmlDropDownToListConverter" adattag
        /// </summary>
        private readonly IStringToListConverter _htmlDropDownToListConverter;

        /// <summary>
        /// A "_config" adattag
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// A konstruktor, ami létrehoz egy ScheduleContext objektumot
        /// </summary>
        /// <param name="webHtmlReader">Az IWebHtmlReader</param>
        /// <param name="htmlTableToListConverter">Az IStringToListConverter</param>
        /// <param name="htmlDropDownToListConverter">Az IStringToListConverter</param>
        /// <param name="config">Az IConfig</param>
        public ScheduleContext
        (
            IWebHtmlReader webHtmlReader,
            IStringToListConverter htmlTableToListConverter,
            IStringToListConverter htmlDropDownToListConverter,
            IConfig config
        )
        {
            _webHtmlReader = webHtmlReader;
            _htmlTableToListConverter = htmlTableToListConverter;
            _htmlDropDownToListConverter = htmlDropDownToListConverter;
            _config = config;
        }

        /// <summary>
        /// A kurzusok szakirány alapján történő listázását megvalósító függvény
        /// </summary>
        /// <param name="department">A kurzus</param>
        /// <param name="semester">A szemeszter</param>
        /// <param name="grade">Az évfolyam</param>
        /// <param name="limit">A limit</param>
        /// <returns>A megfelelő kurzusok egy listában</returns>
        public async Task<IEnumerable<WebCourse>> ListWebCoursesByDepartmentAsync(string department, string semester,
            int grade, Limit limit)
        {
            var document = new HtmlDocument();
            document.LoadHtml(await _webHtmlReader.GetHtmlByPostAsync(
                _config.Get("PostUrl"),
                new Dictionary<string, string>
                {
                    {"melyik", "szakalapjan"},
                    {"felev", semester},
                    {"limit", ((int)limit).ToString()},
                    {"szakkod", department},
                    {"evfolyam", grade.ToString()}
                }
            ));

            return _htmlTableToListConverter.Convert<WebCourse>(
                document.DocumentNode.InnerHtml
            );
        }

        /// <summary>
        /// A kurzusok név alapján történő listázását megvalósító függvény
        /// </summary>
        /// <param name="name">A név</param>
        /// <param name="semester">A szemeszter</param>
        /// <param name="limit">A limit</param>
        /// <returns>A megfelelő kurzusok egy listában</returns>
        public async Task<IEnumerable<WebCourse>> ListWebCoursesByNameAsync(string name, string semester, Limit limit)
        {
            var document = new HtmlDocument();
            document.LoadHtml(await _webHtmlReader.GetHtmlByPostAsync(
                _config.Get("PostUrl"),
                new Dictionary<string, string>
                {
                    {"melyik", "nevalapjan"},
                    {"felev", semester},
                    {"limit", ((int)limit).ToString()},
                    {"targynev", name}
                }
            ));

            return _htmlTableToListConverter.Convert<WebCourse>(
                document.DocumentNode.InnerHtml
            );
        }

        /// <summary>
        /// Kurzusok listázása azonosító alapján
        /// </summary>
        /// <param name="id">Az azonosító</param>
        /// <param name="semester">A szemeszter</param>
        /// <param name="limit">A limit</param>
        /// <returns>WebCourse objektumokat tartalmazó lista</returns>
        public async Task<IEnumerable<WebCourse>> ListWebCoursesByIdAsync(string id, string semester, Limit limit)
        {
            var document = new HtmlDocument();
            document.LoadHtml(await _webHtmlReader.GetHtmlByPostAsync(
                _config.Get("PostUrl"),
                new Dictionary<string, string>
                {
                    {"melyik", "kodalapjan"},
                    {"felev", semester},
                    {"limit", ((int)limit).ToString()},
                    {"targykod", id}
                }
            ));

            return _htmlTableToListConverter.Convert<WebCourse>(
                document.DocumentNode.InnerHtml
            );
        }

        /// <summary>
        /// Kurzusok listázása tanár alapján
        /// </summary>
        /// <param name="teacher">A tanár</param>
        /// <param name="semester">A szemeszter</param>
        /// <param name="limit">A limit</param>
        /// <returns>WebCourse objektumokat tartalmazó lista</returns>
        public async Task<IEnumerable<WebCourse>> ListWebCoursesByTeacherAsync(string teacher, string semester,
            Limit limit)
        {
            var document = new HtmlDocument();
            document.LoadHtml(await _webHtmlReader.GetHtmlByPostAsync(
                _config.Get("PostUrl"),
                new Dictionary<string, string>
                {
                    {"melyik", "oktnevalapjan"},
                    {"felev", semester},
                    {"limit", ((int)limit).ToString()},
                    {"oktnev", teacher}
                }
            ));

            return _htmlTableToListConverter.Convert<WebCourse>(
                document.DocumentNode.InnerHtml
            );
        }

        /// <summary>
        /// Szakirányok listázása
        /// </summary>
        /// <returns>WebDepartment objektumokat tartalmazó lista</returns>
        public async Task<IEnumerable<WebDepartment>> ListDepartmentsAsync()
        {
            var document = new HtmlDocument();
            document.LoadHtml(await _webHtmlReader.GetHtmlAsync(
                _config.Get("MainUrl")
            ));

            return _htmlDropDownToListConverter.Convert<WebDepartment>(
                document.GetElementbyId("szak").InnerHtml
            );
        }

        /// <summary>
        /// Szemeszterek listázása
        /// </summary>
        /// <returns>WebSemester objektumokat tartalmazó lista</returns>
        public async Task<IEnumerable<WebSemester>> ListSemestersAsync()
        {
            var document = new HtmlDocument();
            document.LoadHtml(await _webHtmlReader.GetHtmlAsync(
                _config.Get("MainUrl")
            ));

            return _htmlDropDownToListConverter.Convert<WebSemester>(
                document.GetElementbyId("felev").InnerHtml
            );
        }
    }
}
