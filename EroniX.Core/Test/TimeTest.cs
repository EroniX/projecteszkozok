using EroniX.Core.Time;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EroniX.Core.Test
{
    [TestClass]
    public class TimeTest
    {
        [TestMethod]
        public void IsInIntervalTest()
        {
            var time1 = new Time.Time(10, 20);
            var time2 = new Time.Time(11, 20);

            var time3 = new Time.Time(10, 30);

            var time4 = new Time.Time(9, 20);
            var time5 = new Time.Time(12, 20);

            var interval = new Interval(time1, time2);

            Assert.AreEqual(interval.IsInInterval(time1), true);
            Assert.AreEqual(interval.IsInInterval(time2), true);
            Assert.AreEqual(interval.IsInInterval(time3), true);
            Assert.AreEqual(interval.IsInInterval(time4), false);
            Assert.AreEqual(interval.IsInInterval(time5), false);

            Assert.AreEqual(interval.IsInInterval(time1, false), false);
            Assert.AreEqual(interval.IsInInterval(time2, false), false);
            Assert.AreEqual(interval.IsInInterval(time3, false), true);
            Assert.AreEqual(interval.IsInInterval(time4, false), false);
            Assert.AreEqual(interval.IsInInterval(time5, false), false);
        }

        [TestMethod]
        public void HaveIntersectionTest()
        {
            var time1 = new Time.Time(10, 20);
            var time2 = new Time.Time(11, 20);

            var time3 = new Time.Time(10, 30);

            var time4 = new Time.Time(9, 20);
            var time5 = new Time.Time(12, 20);

            var interval1 = new Interval(time1, time2);
            var interval2 = new Interval(time3, time2);
            var interval3 = new Interval(time2, time5);
            var interval4 = new Interval(time4, time1);
            var interval5 = new Interval(time4, time4);

            Assert.AreEqual(interval1.HaveIntersection(interval2), true);
            Assert.AreEqual(interval1.HaveIntersection(interval3), true);
            Assert.AreEqual(interval1.HaveIntersection(interval4), true);
            Assert.AreEqual(interval1.HaveIntersection(interval5), false);

            Assert.AreEqual(interval1.HaveIntersection(interval2, false), true);
            Assert.AreEqual(interval1.HaveIntersection(interval3, false), false);
            Assert.AreEqual(interval1.HaveIntersection(interval4, false), false);
            Assert.AreEqual(interval1.HaveIntersection(interval5, false), false);
        }
    }
}
