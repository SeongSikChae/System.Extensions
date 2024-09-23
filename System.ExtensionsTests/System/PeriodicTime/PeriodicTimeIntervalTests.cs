using System.Diagnostics;

namespace System.PeriodicTime.Tests
{
	[TestClass]
	public class PeriodicTimeIntervalTests
	{
		[TestMethod]
		public void ValidIntervalTest()
		{
			DateTime start = DateTime.Now.Truncate(TimeGranularityUnit.DAYS);
			DateTime end = start.Next(TimeGranularityUnit.DAYS, 1);
			Assert.IsTrue(new PeriodicTimeInterval(start, end).ValidInterval(new PeriodicTimeGranularity(TimeGranularityUnit.DAYS, 1)));
			Assert.IsFalse(new PeriodicTimeInterval(start, end).ValidInterval(new PeriodicTimeGranularity(TimeGranularityUnit.SECONDS, 1)));
			Assert.IsFalse(new PeriodicTimeInterval(start.Previous(TimeGranularityUnit.SECONDS, 1), end).ValidInterval(new PeriodicTimeGranularity(TimeGranularityUnit.DAYS, 1)));
		}

		[TestMethod]
		public void GetToDoIntervalsTest()
		{
			List<PeriodicTimeInterval> list = PeriodicTimeInterval.GetToDoIntervals(PeriodicTimeGranularity.Of("PT1M"), PeriodicTimeGranularity.Of("PT1M"), PeriodicTimeGranularity.Of("PT1H"), null, DateTime.MinValue.AddDays(1));
			foreach (PeriodicTimeInterval interval in list)
			{
				Trace.WriteLine(interval);
			}
			Assert.AreEqual(59, list.Count);
			list = PeriodicTimeInterval.GetToDoIntervals(PeriodicTimeGranularity.Of("PT1M"), PeriodicTimeGranularity.Of("PT1M"), PeriodicTimeGranularity.Of("PT1H"), list[list.Count - 1], DateTime.MinValue.AddDays(1));
			Assert.AreEqual(0, list.Count);
		}
	}
}