using System;
using System.Configuration;
using System.Linq;
using EroniX.Core.Audit;
using EroniX.Core.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeTableDesigner.DataAccess.DataContext;
using TimeTableDesigner.DataAccess.Repository;
using TimeTableDesigner.DataAccess.UnitOfWork;
using TimeTableDesigner.Shared.Enum;
using TimeTableDesigner.Shared.Helper.Converter;
using TimeTableDesigner.Shared.Helper.Converter.StringToList;
using TimeTableDesigner.Shared.Helper.Web;
using TimeTableDesigner.Web;

namespace TimeTableDesigner.Test
{
    [TestClass]
    public class POC
    {
        [TestMethod]
        public void TimeTableContextTest()
        {
            var timeTableContext = new TimeTableContext("DefaultConnection");
        }

        [TestMethod]
        public void TestCourseContext()
        {
            var scheduleContext = new ScheduleContext
            (
                new WebHtmlReader(),
                new HtmlTableToListConverter(new NLogLogger(new TimeTableAppContextProvider())),
                new HtmlDropDownToListConverter(new NLogLogger(new TimeTableAppContextProvider())),
                new Config(ConfigurationManager.AppSettings)
            );
            var result = scheduleContext.ListSemestersAsync().Result.ToList();
        }

        [TestMethod]
        public void TestCourseRepository()
        {
            var scheduleContext = new ScheduleContext
            (
                new WebHtmlReader(),
                new HtmlTableToListConverter(new NLogLogger(new TimeTableAppContextProvider())),
                new HtmlDropDownToListConverter(new NLogLogger(new TimeTableAppContextProvider())),
                new Config(ConfigurationManager.AppSettings)
            );

            var repository = new ScheduleRepository(scheduleContext);
            var result = repository.ListWebCoursesByDepartmentAsync("BFÖL", "semester", 1, Limit.All).Result.ToList();
        }


        [TestMethod]
        public void TestScheduleContext()
        {
            var scheduleContext = new ScheduleContext
            (
                new WebHtmlReader(),
                new HtmlTableToListConverter(new NLogLogger(new TimeTableAppContextProvider())),
                new HtmlDropDownToListConverter(new NLogLogger(new TimeTableAppContextProvider())),
                new Config(ConfigurationManager.AppSettings)
            );

            var result = scheduleContext.ListSemestersAsync().Result.ToList();
        }
    }
}
