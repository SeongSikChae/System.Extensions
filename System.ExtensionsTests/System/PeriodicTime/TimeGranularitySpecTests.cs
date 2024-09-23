namespace System.PeriodicTime.Tests
{
	[TestClass]
	public class TimeGranularitySpecTests
	{
		[TestMethod]
		public void OfTest()
		{
			{
				TimeGranularitySpec spec = TimeGranularitySpec.Of(TimeGranularityUnit.SECONDS);
				Assert.AreEqual("PT", spec.Prefix);
				Assert.AreEqual("S", spec.Suffix);
				Assert.AreEqual(60, spec.MaxFactor);
			}

			{
				TimeGranularitySpec spec = TimeGranularitySpec.Of(TimeGranularityUnit.MINUTES);
				Assert.AreEqual("PT", spec.Prefix);
				Assert.AreEqual("M", spec.Suffix);
				Assert.AreEqual(60, spec.MaxFactor);
			}

			{
				TimeGranularitySpec spec = TimeGranularitySpec.Of(TimeGranularityUnit.HOURS);
				Assert.AreEqual("PT", spec.Prefix);
				Assert.AreEqual("H", spec.Suffix);
				Assert.AreEqual(24, spec.MaxFactor);
			}

			{
				TimeGranularitySpec spec = TimeGranularitySpec.Of(TimeGranularityUnit.DAYS);
				Assert.AreEqual("P", spec.Prefix);
				Assert.AreEqual("D", spec.Suffix);
				Assert.AreEqual(7, spec.MaxFactor);
			}

			{
				TimeGranularitySpec spec = TimeGranularitySpec.Of(TimeGranularityUnit.WEEK);
				Assert.AreEqual("P", spec.Prefix);
				Assert.AreEqual("W", spec.Suffix);
				Assert.AreEqual(5, spec.MaxFactor);
			}

			{
				TimeGranularitySpec spec = TimeGranularitySpec.Of(TimeGranularityUnit.MONTHS);
				Assert.AreEqual("P", spec.Prefix);
				Assert.AreEqual("M", spec.Suffix);
				Assert.AreEqual(12, spec.MaxFactor);
			}

			{
				TimeGranularitySpec spec = TimeGranularitySpec.Of(TimeGranularityUnit.QUARTER);
				Assert.AreEqual("P", spec.Prefix);
				Assert.AreEqual("Q", spec.Suffix);
				Assert.AreEqual(4, spec.MaxFactor);
			}

			{
				TimeGranularitySpec spec = TimeGranularitySpec.Of(TimeGranularityUnit.YEARS);
				Assert.AreEqual("P", spec.Prefix);
				Assert.AreEqual("Y", spec.Suffix);
				Assert.AreEqual(1, spec.MaxFactor);
			}

			Assert.ThrowsException<UnsupportedTimeGranularityUnitException>(() =>
			{
				TimeGranularitySpec.Of((TimeGranularityUnit)8);
			});
		}

		[TestMethod]
		public void ValidGranularityTest()
		{
			TimeGranularitySpec spec = TimeGranularitySpec.Of(TimeGranularityUnit.HOURS);
			Assert.IsFalse(spec.ValidGranularity(0));
			Assert.IsTrue(spec.ValidGranularity(1));
			Assert.IsTrue(spec.ValidGranularity(2));
			Assert.IsTrue(spec.ValidGranularity(3));
			Assert.IsTrue(spec.ValidGranularity(4));
			Assert.IsTrue(spec.ValidGranularity(5));
			Assert.IsTrue(spec.ValidGranularity(6));
			Assert.IsTrue(spec.ValidGranularity(7));
			Assert.IsTrue(spec.ValidGranularity(8));
			Assert.IsTrue(spec.ValidGranularity(9));
			Assert.IsTrue(spec.ValidGranularity(10));
			Assert.IsTrue(spec.ValidGranularity(11));
			Assert.IsTrue(spec.ValidGranularity(12));
			Assert.IsTrue(spec.ValidGranularity(13));
			Assert.IsTrue(spec.ValidGranularity(14));
			Assert.IsTrue(spec.ValidGranularity(15));
			Assert.IsTrue(spec.ValidGranularity(16));
			Assert.IsTrue(spec.ValidGranularity(17));
			Assert.IsTrue(spec.ValidGranularity(18));
			Assert.IsTrue(spec.ValidGranularity(19));
			Assert.IsTrue(spec.ValidGranularity(20));
			Assert.IsTrue(spec.ValidGranularity(21));
			Assert.IsTrue(spec.ValidGranularity(22));
			Assert.IsTrue(spec.ValidGranularity(23));
			Assert.IsTrue(spec.ValidGranularity(24));
			Assert.IsFalse(spec.ValidGranularity(25));
		}
	}
}