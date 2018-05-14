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
    public class WebHtmlReaderTest
    {
       private readonly IWebHtmlReader _webHtmlReader;

        public WebHtmlReaderTest()
        {
            this._webHtmlReader = new WebHtmlReader();
        }

        [TestMethod]
        public void GetHtmlTest()
        {
            var testInput =
                "https://tarhelypark.hu/favicon.ico";
            var html = _webHtmlReader.GetHtml("http://tamasvaczi.com/");
            Assert.IsTrue(html.Contains(testInput));
        }

        [TestMethod]
        public async Task GetHtmlTest1()
        {
            var testInput =
                "https://tarhelypark.hu/favicon.ico";
            var html = await _webHtmlReader.GetHtmlAsync("http://tamasvaczi.com/");
            Assert.IsTrue(html.Contains(testInput));
        }
    }
}
