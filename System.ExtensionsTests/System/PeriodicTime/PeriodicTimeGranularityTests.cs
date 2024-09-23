using System.Diagnostics;

namespace System.PeriodicTime.Tests
{
	[TestClass]
	public class PeriodicTimeGranularityTests
	{
		[TestMethod]
		public void PeriodicTimeGranularityTest()
		{
			_ = new PeriodicTimeGranularity(TimeGranularityUnit.SECONDS, 65, false);
			Assert.ThrowsException<ArgumentException>(() =>
			{
				new PeriodicTimeGranularity(TimeGranularityUnit.SECONDS, 65);
			});
		}

		[TestMethod]
		public void ValidGranularityTest()
		{
			Assert.IsFalse(new PeriodicTimeGranularity(TimeGranularityUnit.SECONDS, 65, false).ValidGranularity);
			Assert.IsTrue(new PeriodicTimeGranularity(TimeGranularityUnit.SECONDS, 35).ValidGranularity);
		}

		[TestMethod]
		public void SnapTest()
		{
			Assert.ThrowsException<Exception>(() =>
			{
				new PeriodicTimeGranularity(TimeGranularityUnit.SECONDS, 65, false).Snap(DateTime.Now);
			});
			Trace.WriteLine(new PeriodicTimeGranularity(TimeGranularityUnit.SECONDS, 30, false).Snap(DateTime.Now));
		}

		[TestMethod]
		public void NextTest()
		{
			Trace.WriteLine(new PeriodicTimeGranularity(TimeGranularityUnit.SECONDS, 30, false).Next(DateTime.Now));
		}

		[TestMethod]
		public void CompareToTest()
		{
			Assert.AreEqual(0, new PeriodicTimeGranularity(TimeGranularityUnit.SECONDS, 30, false).CompareTo(null));
			Assert.AreEqual(-1, new PeriodicTimeGranularity(TimeGranularityUnit.SECONDS, 30, false).CompareTo(new PeriodicTimeGranularity(TimeGranularityUnit.MINUTES, 30, false)));
			Assert.AreEqual(-1, new PeriodicTimeGranularity(TimeGranularityUnit.SECONDS, 30, false).CompareTo(new PeriodicTimeGranularity(TimeGranularityUnit.SECONDS, 31, false)));
			Assert.AreEqual(1, new PeriodicTimeGranularity(TimeGranularityUnit.MINUTES, 30, false).CompareTo(new PeriodicTimeGranularity(TimeGranularityUnit.SECONDS, 30, false)));
			Assert.AreEqual(1, new PeriodicTimeGranularity(TimeGranularityUnit.SECONDS, 31, false).CompareTo(new PeriodicTimeGranularity(TimeGranularityUnit.SECONDS, 30, false)));
		}

		[TestMethod]
		public void GetHashCodeTest()
		{
			Trace.WriteLine(new PeriodicTimeGranularity(TimeGranularityUnit.SECONDS, 30).GetHashCode());
		}

		[TestMethod]
		public void EqualsTest()
		{
			Assert.AreNotEqual(new PeriodicTimeGranularity(TimeGranularityUnit.SECONDS, 31), null);
			Assert.AreEqual(new PeriodicTimeGranularity(TimeGranularityUnit.SECONDS, 31), new PeriodicTimeGranularity(TimeGranularityUnit.SECONDS, 31));
		}

		[TestMethod]
		public void ToStringTest()
		{
			Trace.WriteLine(new PeriodicTimeGranularity(TimeGranularityUnit.SECONDS, 31));
		}

		[TestMethod]
		public void OfTest()
		{
			PeriodicTimeGranularity periodicTimeGranularity = PeriodicTimeGranularity.Of("PT5M");
			Assert.AreEqual(TimeGranularityUnit.MINUTES, periodicTimeGranularity.Unit);
			Assert.AreEqual(5, periodicTimeGranularity.Factor);
		}
	}
}