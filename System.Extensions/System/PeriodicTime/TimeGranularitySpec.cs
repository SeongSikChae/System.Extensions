namespace System.PeriodicTime
{
	/// <summary>
	/// Time Granularity Spec
	/// </summary>
	/// <param name="prefix">Time Unit Prefix</param>
	/// <param name="suffix">Time Unit Suffix</param>
	/// <param name="maxFactor">Max Factor</param>
	public sealed class TimeGranularitySpec(string prefix, string suffix, int maxFactor)
	{
		/// <summary>
		/// Time Unit Prefix
		/// </summary>
		public string Prefix => prefix;

		/// <summary>
		/// Time Unit Suffix
		/// </summary>
		public string Suffix => suffix;

		/// <summary>
		/// Max Factor
		/// </summary>
		public int MaxFactor => maxFactor;

		/// <summary>
		/// Time Granularity Spec Validate Factor
		/// </summary>
		public bool ValidGranularity(int factor)
		{
			if (factor < 1 || factor > maxFactor)
				return false;
			return true;
		}

		/// <summary>
		/// Time Granularity Unit To TimeGranularitySpec
		/// </summary>
		/// <exception cref="UnsupportedTimeGranularityUnitException"></exception>
		public static TimeGranularitySpec Of(TimeGranularityUnit unit)
		{
			return unit switch
			{
				TimeGranularityUnit.SECONDS => new TimeGranularitySpec("PT", "S", 60),
				TimeGranularityUnit.MINUTES => new TimeGranularitySpec("PT", "M", 60),
				TimeGranularityUnit.HOURS => new TimeGranularitySpec("PT", "H", 24),
				TimeGranularityUnit.DAYS => new TimeGranularitySpec("P", "D", 7),
				TimeGranularityUnit.WEEK => new TimeGranularitySpec("P", "W", 5),
				TimeGranularityUnit.MONTHS => new TimeGranularitySpec("P", "M", 12),
				TimeGranularityUnit.QUARTER => new TimeGranularitySpec("P", "Q", 4),
				TimeGranularityUnit.YEARS => new TimeGranularitySpec("P", "Y", 1),
				_ => throw new UnsupportedTimeGranularityUnitException("invalid unit"),
			};
		}
	}
}
