using System.Xml;

namespace System.Tests
{
	[TestClass]
	public class DateTimeExtensionsTests
	{
		[TestMethod]
		public void GetQuarterTest()
		{
			TimeSpan ts = XmlConvert.ToTimeSpan("PT1M");

			Assert.AreEqual(Quarter.Q1, new DateTime(2024, 1, 12, 12, 59, 59, 555).GetQuarter());
			Assert.AreEqual(Quarter.Q1, new DateTime(2024, 2, 12, 12, 59, 59, 555).GetQuarter());
			Assert.AreEqual(Quarter.Q1, new DateTime(2024, 3, 12, 12, 59, 59, 555).GetQuarter());
			Assert.AreEqual(Quarter.Q2, new DateTime(2024, 4, 12, 12, 59, 59, 555).GetQuarter());
			Assert.AreEqual(Quarter.Q2, new DateTime(2024, 5, 12, 12, 59, 59, 555).GetQuarter());
			Assert.AreEqual(Quarter.Q2, new DateTime(2024, 6, 12, 12, 59, 59, 555).GetQuarter());
			Assert.AreEqual(Quarter.Q3, new DateTime(2024, 7, 12, 12, 59, 59, 555).GetQuarter());
			Assert.AreEqual(Quarter.Q3, new DateTime(2024, 8, 12, 12, 59, 59, 555).GetQuarter());
			Assert.AreEqual(Quarter.Q3, new DateTime(2024, 9, 12, 12, 59, 59, 555).GetQuarter());
			Assert.AreEqual(Quarter.Q4, new DateTime(2024, 10, 12, 12, 59, 59, 555).GetQuarter());
			Assert.AreEqual(Quarter.Q4, new DateTime(2024, 11, 12, 12, 59, 59, 555).GetQuarter());
			Assert.AreEqual(Quarter.Q4, new DateTime(2024, 12, 12, 12, 59, 59, 555).GetQuarter());
		}

		[TestMethod]
		public void TruncateTest()
		{
			DateTime baseTime = new DateTime(2024, 9, 12, 12, 59, 59, 555);
			Assert.AreEqual(new DateTime(2024, 9, 12, 12, 59, 59), baseTime.Truncate(TimeGranularityUnit.SECONDS));
			Assert.AreEqual(new DateTime(2024, 9, 12, 12, 59, 0), baseTime.Truncate(TimeGranularityUnit.MINUTES));
			Assert.AreEqual(new DateTime(2024, 9, 12, 12, 0, 0), baseTime.Truncate(TimeGranularityUnit.HOURS));
			Assert.AreEqual(new DateTime(2024, 9, 12, 0, 0, 0), baseTime.Truncate(TimeGranularityUnit.DAYS));

			{
				Assert.AreEqual(new DateTime(2024, 9, 8, 0, 0, 0), new DateTime(2024, 9, 8, 0, 0, 0).Truncate(TimeGranularityUnit.WEEK));
				Assert.AreEqual(new DateTime(2024, 9, 8, 0, 0, 0), new DateTime(2024, 9, 9, 0, 0, 0).Truncate(TimeGranularityUnit.WEEK));
				Assert.AreEqual(new DateTime(2024, 9, 8, 0, 0, 0), new DateTime(2024, 9, 10, 0, 0, 0).Truncate(TimeGranularityUnit.WEEK));
				Assert.AreEqual(new DateTime(2024, 9, 8, 0, 0, 0), new DateTime(2024, 9, 11, 0, 0, 0).Truncate(TimeGranularityUnit.WEEK));
				Assert.AreEqual(new DateTime(2024, 9, 8, 0, 0, 0), new DateTime(2024, 9, 12, 0, 0, 0).Truncate(TimeGranularityUnit.WEEK));
				Assert.AreEqual(new DateTime(2024, 9, 8, 0, 0, 0), new DateTime(2024, 9, 13, 0, 0, 0).Truncate(TimeGranularityUnit.WEEK));
				Assert.AreEqual(new DateTime(2024, 9, 8, 0, 0, 0), new DateTime(2024, 9, 14, 0, 0, 0).Truncate(TimeGranularityUnit.WEEK));
			}

			Assert.AreEqual(new DateTime(2024, 9, 1, 0, 0, 0), baseTime.Truncate(TimeGranularityUnit.MONTHS));

			{
				Assert.AreEqual(new DateTime(2024, 1, 1, 0, 0, 0), new DateTime(2024, 2, 1, 0, 0, 0).Truncate(TimeGranularityUnit.QUARTER));
				Assert.AreEqual(new DateTime(2024, 4, 1, 0, 0, 0), new DateTime(2024, 5, 1, 0, 0, 0).Truncate(TimeGranularityUnit.QUARTER));
				Assert.AreEqual(new DateTime(2024, 7, 1, 0, 0, 0), new DateTime(2024, 8, 1, 0, 0, 0).Truncate(TimeGranularityUnit.QUARTER));
				Assert.AreEqual(new DateTime(2024, 10, 1, 0, 0, 0), new DateTime(2024, 11, 1, 0, 0, 0).Truncate(TimeGranularityUnit.QUARTER));
			}

			Assert.AreEqual(new DateTime(2024, 1, 1, 0, 0, 0), baseTime.Truncate(TimeGranularityUnit.YEARS));
		}

		[TestMethod]
		public void NextTest()
		{
			DateTime baseTime = new DateTime(2024, 9, 12, 12, 59, 59, 555);
			Assert.AreEqual(baseTime, baseTime.Next(TimeGranularityUnit.SECONDS, 0));
			Assert.ThrowsException<ArgumentException>(() =>
			{
				baseTime.Next(TimeGranularityUnit.SECONDS, -1);
			});
			Assert.AreEqual(new DateTime(2024, 9, 12, 13, 00, 00, 555), baseTime.Next(TimeGranularityUnit.SECONDS, 1));
			Assert.AreEqual(new DateTime(2024, 9, 12, 13, 00, 59, 555), baseTime.Next(TimeGranularityUnit.MINUTES, 1));
			Assert.AreEqual(new DateTime(2024, 9, 12, 13, 59, 59, 555), baseTime.Next(TimeGranularityUnit.HOURS, 1));
			Assert.AreEqual(new DateTime(2024, 9, 13, 12, 59, 59, 555), baseTime.Next(TimeGranularityUnit.DAYS, 1));
			Assert.AreEqual(new DateTime(2024, 9, 19, 12, 59, 59, 555), baseTime.Next(TimeGranularityUnit.WEEK, 1));
			Assert.AreEqual(new DateTime(2024, 10, 12, 12, 59, 59, 555), baseTime.Next(TimeGranularityUnit.MONTHS, 1));
			Assert.AreEqual(new DateTime(2024, 12, 12, 12, 59, 59, 555), baseTime.Next(TimeGranularityUnit.QUARTER, 1));
			Assert.AreEqual(new DateTime(2025, 9, 12, 12, 59, 59, 555), baseTime.Next(TimeGranularityUnit.YEARS, 1));
		}

		[TestMethod]
		public void PreviousTest()
		{
			DateTime baseTime = new DateTime(2024, 9, 12, 12, 59, 59, 555);
			Assert.AreEqual(baseTime, baseTime.Previous(TimeGranularityUnit.SECONDS, 0));
			Assert.ThrowsException<ArgumentException>(() =>
			{
				baseTime.Previous(TimeGranularityUnit.SECONDS, -1);
			});
			Assert.AreEqual(new DateTime(2024, 9, 12, 12, 59, 58, 555), baseTime.Previous(TimeGranularityUnit.SECONDS, 1));
			Assert.AreEqual(new DateTime(2024, 9, 12, 12, 58, 59, 555), baseTime.Previous(TimeGranularityUnit.MINUTES, 1));
			Assert.AreEqual(new DateTime(2024, 9, 12, 11, 59, 59, 555), baseTime.Previous(TimeGranularityUnit.HOURS, 1));
			Assert.AreEqual(new DateTime(2024, 9, 11, 12, 59, 59, 555), baseTime.Previous(TimeGranularityUnit.DAYS, 1));
			Assert.AreEqual(new DateTime(2024, 9, 5, 12, 59, 59, 555), baseTime.Previous(TimeGranularityUnit.WEEK, 1));
			Assert.AreEqual(new DateTime(2024, 8, 12, 12, 59, 59, 555), baseTime.Previous(TimeGranularityUnit.MONTHS, 1));
			Assert.AreEqual(new DateTime(2024, 6, 12, 12, 59, 59, 555), baseTime.Previous(TimeGranularityUnit.QUARTER, 1));
			Assert.AreEqual(new DateTime(2023, 9, 12, 12, 59, 59, 555), baseTime.Previous(TimeGranularityUnit.YEARS, 1));
		}

		[TestMethod]
		public void ToMillisecondsTest()
		{
			DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
			Assert.AreEqual(0, dateTime.ToMilliseconds());

			TimeZoneInfo kstTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Korea Standard Time");
			DateTime kstDateTime = TimeZoneInfo.ConvertTimeFromUtc(dateTime, kstTimeZone);
			kstDateTime = kstDateTime.AddHours(-9);
			Assert.AreEqual(-32400000, kstDateTime.ToMilliseconds());
		}

		[TestMethod]
		public void ToTimeSecondsTest()
		{
			DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
			Assert.AreEqual(0, dateTime.ToTimeSeconds());

			TimeZoneInfo kstTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Korea Standard Time");
			DateTime kstDateTime = TimeZoneInfo.ConvertTimeFromUtc(dateTime, kstTimeZone);
			kstDateTime = kstDateTime.AddHours(-9);
			Assert.AreEqual(-32400, kstDateTime.ToTimeSeconds());
		}

		[TestMethod]
		public void SnapTest()
		{
			{
				DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
				Assert.AreEqual(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc), dateTime.Snap(5000));
			}

			{
				DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 1, DateTimeKind.Utc);
				Assert.AreEqual(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc), dateTime.Snap(5000));
			}

			{
				DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 2, DateTimeKind.Utc);
				Assert.AreEqual(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc), dateTime.Snap(5000));
			}

			{
				DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 3, DateTimeKind.Utc);
				Assert.AreEqual(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc), dateTime.Snap(5000));
			}

			{
				DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 4, DateTimeKind.Utc);
				Assert.AreEqual(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc), dateTime.Snap(5000));
			}

			{
				DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 5, DateTimeKind.Utc);
				Assert.AreEqual(new DateTime(1970, 1, 1, 0, 0, 5, DateTimeKind.Utc), dateTime.Snap(5000));
			}

			{
				DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 6, DateTimeKind.Utc);
				Assert.AreEqual(new DateTime(1970, 1, 1, 0, 0, 5, DateTimeKind.Utc), dateTime.Snap(5000));
			}

			{
				DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 7, DateTimeKind.Utc);
				Assert.AreEqual(new DateTime(1970, 1, 1, 0, 0, 5, DateTimeKind.Utc), dateTime.Snap(5000));
			}

			{
				DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 8, DateTimeKind.Utc);
				Assert.AreEqual(new DateTime(1970, 1, 1, 0, 0, 5, DateTimeKind.Utc), dateTime.Snap(5000));
			}

			{
				DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 9, DateTimeKind.Utc);
				Assert.AreEqual(new DateTime(1970, 1, 1, 0, 0, 5, DateTimeKind.Utc), dateTime.Snap(5000));
			}

			{
				DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 10, DateTimeKind.Utc);
				Assert.AreEqual(new DateTime(1970, 1, 1, 0, 0, 10, DateTimeKind.Utc), dateTime.Snap(5000));
			}
		}

		[TestMethod]
		public void SnapTestFromFactor()
		{
			{
				DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 4, DateTimeKind.Utc);
				Assert.AreEqual(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc), dateTime.Snap(5, TimeGranularityUnit.SECONDS));
			}

			{
				DateTime dateTime = new DateTime(1970, 1, 1, 0, 4, 0, DateTimeKind.Utc);
				Assert.AreEqual(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc), dateTime.Snap(5, TimeGranularityUnit.MINUTES));
			}

			{
				DateTime dateTime = new DateTime(1970, 1, 1, 4, 0, 0, DateTimeKind.Utc);
				Assert.AreEqual(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc), dateTime.Snap(5, TimeGranularityUnit.HOURS));
			}

			{
				DateTime dateTime = new DateTime(1970, 1, 4, 0, 0, 4, DateTimeKind.Utc);
				Assert.AreEqual(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc), dateTime.Snap(5, TimeGranularityUnit.DAYS));
			}

			{
				DateTime dateTime = new DateTime(1970, 1, 4, 0, 0, 0, DateTimeKind.Utc);
				Assert.AreEqual(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc), dateTime.Snap(5, TimeGranularityUnit.WEEK));
			}

			{
				DateTime dateTime = new DateTime(1970, 2, 1, 0, 0, 0, DateTimeKind.Utc);
				Assert.AreEqual(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc), dateTime.Snap(5, TimeGranularityUnit.MONTHS));
			}

			{
				DateTime dateTime = new DateTime(1974, 1, 1, 0, 0, 0, DateTimeKind.Utc);
				Assert.AreEqual(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc), dateTime.Snap(5, TimeGranularityUnit.YEARS));
			}
		}
	}
}