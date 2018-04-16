using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EroniX.Core.Config;
using HtmlAgilityPack;
using TimeTableDesigner.Shared.Entity.Web;
using TimeTableDesigner.Shared.Enum;
using TimeTableDesigner.Shared.Helper.Converter.StringToList;
using TimeTableDesigner.Shared.Helper.Web;

namespace TimeTableDesigner.DataAccess.DataContext
{
    public class ScheduleContext
    {
        private readonly IWebHtmlReader _webHtmlReader;
        private readonly IStringToListConverter _htmlTableToListConverter;
        private readonly IStringToListConverter _htmlDropDownToListConverter;
        private readonly IConfig _config;

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
