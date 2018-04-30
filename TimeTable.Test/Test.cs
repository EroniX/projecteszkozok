using System;
using System.Configuration;
using System.Linq;
using EroniX.Core.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeTableDesigner.DataAccess.DataContext;
using TimeTableDesigner.DataAccess.Repository;
using TimeTableDesigner.DataAccess.UnitOfWork;
using TimeTableDesigner.Shared.Helper.Converter;
using TimeTableDesigner.Shared.Helper.Converter.StringToList;
using TimeTableDesigner.Shared.Helper.Web;

namespace TimeTableDesigner.Test
{
    /// <summary>
    /// A Test osztály
    /// </summary>
    [TestClass]
    public class Test
    {
        //[TestMethod]
        //public void TestCourseContext()
        //{
        //    var scheduleContext = new ScheduleContext
        //    (
        //        new WebHtmlReader(),
        //        new HtmlTableToListConverter(),
        //        new HtmlSemesterDropDownToListConverter(),
        //        new Config(ConfigurationManager.AppSettings)
        //    );
        //    var result = scheduleContext.ListCourseDatasByDepartmentAsync("BFÖL", 1).Result.ToList();
        //}

        //[TestMethod]
        //public void TestCourseRepository()
        //{
        //    var scheduleContext = new ScheduleContext
        //    (
        //        new WebHtmlReader(),
        //        new HtmlTableToListConverter(),
        //        new HtmlDepartmentDropDownToListConverter(),
        //        new HtmlSemesterDropDownToListConverter(),
        //        new Config(ConfigurationManager.AppSettings)
        //    );

        //    var repository = new ScheduleRepository(scheduleContext);

        //    var result = repository.ListCourseDatasByDepartmentAsync("BFÖL", 1, n => n.Name.Contains("Bevezetés")).Result.ToList();
        //}

        //[TestMethod]
        //public void TestTimeTableUoW()
        //{
        //    var timeTableUoW = new TimeTableUoW();
        //    var result = timeTableUoW.ListUser();
        //}

        //[TestMethod]
        //public void TestScheduleContext()
        //{
        //    var scheduleContext = new ScheduleContext
        //    (
        //        new WebHtmlReader(),
        //        new HtmlTableToListConverter(),
        //        new HtmlDropDownToListConverter(),
        //        new Config(ConfigurationManager.AppSettings)
        //    );

        //    var result = scheduleContext.ListSemestersAsync().Result.ToList();
        //}
    }
}
