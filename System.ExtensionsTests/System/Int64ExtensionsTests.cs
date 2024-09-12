namespace System.Tests
{
	[TestClass]
	public class Int64ExtensionsTests
	{
		[TestMethod]
		public void FromUnixTimeMillisecondsTest()
		{
			DateTime UnixEpoch = DateTime.UnixEpoch;

			DateTime t1 = 0L.FromUnixTimeMilliseconds(DateTimeKind.Utc);
			Assert.AreEqual(UnixEpoch, t1);
						
			DateTime t2 = 0L.FromUnixTimeMilliseconds(DateTimeKind.Local);
			Assert.AreEqual(UnixEpoch.AddMinutes(TimeZoneInfo.Local.BaseUtcOffset.TotalMinutes), t2);
		}

		[TestMethod]
		public void FromUnixTimeSecondsTest()
		{
			DateTime UnixEpoch = DateTime.UnixEpoch;

			DateTime t1 = 0L.FromUnixTimeSeconds(DateTimeKind.Utc);
			Assert.AreEqual(UnixEpoch, t1);

			DateTime t2 = 0L.FromUnixTimeSeconds(DateTimeKind.Local);
			Assert.AreEqual(UnixEpoch.AddMinutes(TimeZoneInfo.Local.BaseUtcOffset.TotalMinutes), t2);
		}
	}
}