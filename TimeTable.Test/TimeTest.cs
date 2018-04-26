using System;
using System.Configuration;
using System.Linq;
using EroniX.Core.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeTableDesigner.DataAccess.DataContext;
using TimeTableDesigner.DataAccess.Repository;
using TimeTableDesigner.DataAccess.UnitOfWork;
using TimeTableDesigner.Shared.Entity.Domain;
using TimeTableDesigner.Shared.Helper.Converter;
using TimeTableDesigner.Shared.Helper.Converter.StringToList;
using TimeTableDesigner.Shared.Helper.Web;

namespace TimeTableDesigner.Test
{
    [TestClass]
    public class TimeTest
    {
        [TestMethod]
        public void Time()
        {
            var time1 = new Time(10, 20);
            var time2 = new Time(11, 20);
            var interval = new Interval(time1, time2);

            var time3 = new Time(10, 20);
            var time4 = new Time(11, 20);
            var time5 = new Time(10, 30);
            var time6 = new Time(9, 20);

            Assert.AreEqual(interval.IsInInterval(time3), true);
            Assert.AreEqual(interval.IsInInterval(time3), true);
        }

        //[TestMethod]
        //public void Interval1()
        //{
        //    var time1 = new Time(10, 20);
        //    var time2 = new Time(11, 20);
        //    var interval1 = new Interval(time1, time2);

        //    var time3 = new Time(9, 20);
        //    var time4 = new Time(10, 20);
        //    var interval2 = new Interval(time3, time4);

        //    var time5 = new Time(11, 20);
        //    var time6 = new Time(12, 20);
        //    var interval3 = new Interval(time5, time6);

        //    var time7 = new Time(10, 30);
        //    var time8 = new Time(12, 20);
        //    var interval4 = new Interval(time7, time8);

        //    Assert.AreEqual(interval1.IsInInterval(), -1);
        //}

        //[TestMethod]
        //public void Interval()
        //{
        //    var time1 = new Time(10, 20);
        //    var time2 = new Time(11, 20);
        //    var interval1 = new Interval(time1, time2);

        //    var time3 = new Time(9, 20);
        //    var time4 = new Time(10, 20);
        //    var interval2 = new Interval(time3, time4);

        //    var time5 = new Time(11, 20);
        //    var time6 = new Time(12, 20);
        //    var interval3 = new Interval(time5, time6);

        //    var time7 = new Time(10, 30);
        //    var time8 = new Time(12, 20);
        //    var interval4 = new Interval(time7, time8);

        //    Assert.AreEqual(interval1., -1);
        //}
    }
}
