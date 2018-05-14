using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using EroniX.Core.Audit;
using EroniX.Core.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeTableDesigner.DataAccess.DataContext;
using TimeTableDesigner.DataAccess.Repository;
using TimeTableDesigner.DataAccess.UnitOfWork;
using TimeTableDesigner.Logic.Services;
using TimeTableDesigner.Shared.Access.Service;
using TimeTableDesigner.Shared.Entity.Web;
using TimeTableDesigner.Shared.Enum;
using TimeTableDesigner.Shared.Helper.Converter;
using TimeTableDesigner.Shared.Helper.Converter.StringToList;
using TimeTableDesigner.Shared.Helper.Web;
using TimeTableDesigner.Web;

namespace TimeTableDesigner.Test
{
    [TestClass]
    public class WebDataServiceTest
    {
        private readonly IWebDataService _webDataService;
        private readonly ILogger _logger;

        public WebDataServiceTest()
        {
            this._logger = new NLogLogger(null);

            this._webDataService = new WebDataService(
                new ScheduleRepository(new ScheduleContext(
                    new WebHtmlReader(),
                    new HtmlTableToListConverter(new NLogLogger(new TimeTableAppContextProvider())),
                    new HtmlDropDownToListConverter(new NLogLogger(new TimeTableAppContextProvider())),
                    Config.Create(ConfigurationManager.AppSettings)
                )),
                null, null);
        }

        [TestMethod]
        public void ListSearchTypesTest()
        {
            List<SearchType> searchTypes = _webDataService.ListSearchTypes().ToList();
            Assert.AreEqual(searchTypes[0], SearchType.Name);
            Assert.AreEqual(searchTypes[1], SearchType.Id);
            Assert.AreEqual(searchTypes[2], SearchType.Teacher);
        }

        [TestMethod]
        public void ListLimitsTest()
        {
            List<Limit> limits = _webDataService.ListLimits().ToList();
            Assert.AreEqual(limits[0], Limit.Fifty);
            Assert.AreEqual(limits[1], Limit.Hundred);
            Assert.AreEqual(limits[2], Limit.All);
        }

        [TestMethod]
        public void ListGradesTest()
        {
            List<int> grades = _webDataService.ListGrades().ToList();
            Assert.AreEqual(grades[0], 1);
            Assert.AreEqual(grades[1], 2);
            Assert.AreEqual(grades[2], 3);
            Assert.AreEqual(grades[3], 4);
            Assert.AreEqual(grades[4], 5);
        }
    }
}
