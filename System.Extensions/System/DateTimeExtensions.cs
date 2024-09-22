namespace System
{
	/// <summary>
	/// Extensions to System.DateTime
	/// </summary>
	public static class DateTimeExtensions
	{
		/// <summary>
		/// Gets a quarter (date) from a specific time.
		/// </summary>
		/// <param name="dateTime">Specific Datetime</param>
		/// <returns>Quarter</returns>
		public static Quarter GetQuarter(this DateTime dateTime)
		{
			return dateTime.Month switch
			{
				1 or 2 or 3 => Quarter.Q1,
				4 or 5 or 6 => Quarter.Q2,
				7 or 8 or 9 => Quarter.Q3,
				_ => Quarter.Q4,
			};
		}

		/// <summary>
		/// Truncate remaining information based on a specific unit of time
		/// </summary>
		/// <param name="dateTime">Target time</param>
		/// <param name="unit">granularityUnit</param>
		/// <returns>Truncated DateTime</returns>
		/// <exception cref="UnsupportedTimeGranularityUnitException"></exception>
		public static DateTime Truncate(this DateTime dateTime, TimeGranularityUnit unit)
		{
			switch (unit)
			{
				case TimeGranularityUnit.SECONDS:
					return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Kind);
				case TimeGranularityUnit.MINUTES:
					return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, 0, dateTime.Kind);
				case TimeGranularityUnit.HOURS:
					return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, 0, 0, dateTime.Kind);
				case TimeGranularityUnit.DAYS:
					return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0, dateTime.Kind);
				case TimeGranularityUnit.WEEK:
					DateTime targetTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0, dateTime.Kind);
					switch (targetTime.DayOfWeek)
					{
						case DayOfWeek.Monday:
							targetTime = targetTime.AddDays(-1);
							break;
						case DayOfWeek.Tuesday:
							targetTime = targetTime.AddDays(-2);
							break;
						case DayOfWeek.Wednesday:
							targetTime = targetTime.AddDays(-3);
							break;
						case DayOfWeek.Thursday:
							targetTime = targetTime.AddDays(-4);
							break;
						case DayOfWeek.Friday:
							targetTime = targetTime.AddDays(-5);
							break;
						case DayOfWeek.Saturday:
							targetTime = targetTime.AddDays(-6);
							break;
					}
					return targetTime;
				case TimeGranularityUnit.MONTHS:
					return new DateTime(dateTime.Year, dateTime.Month, 1, 0, 0, 0, dateTime.Kind);
				case TimeGranularityUnit.QUARTER:
					Quarter quarter = dateTime.GetQuarter();
					return quarter switch
					{
						Quarter.Q1 => new DateTime(dateTime.Year, 1, 1, 0, 0, 0, dateTime.Kind),
						Quarter.Q2 => new DateTime(dateTime.Year, 4, 1, 0, 0, 0, dateTime.Kind),
						Quarter.Q3 => new DateTime(dateTime.Year, 7, 1, 0, 0, 0, dateTime.Kind),
						_ => new DateTime(dateTime.Year, 10, 1, 0, 0, 0, dateTime.Kind),
					};
				case TimeGranularityUnit.YEARS:
					return new DateTime(dateTime.Year, 1, 1, 0, 0, 0, dateTime.Kind);
				default:
					throw new UnsupportedTimeGranularityUnitException($"unsupported '{unit}'");
			}
		}

		/// <summary>
		/// Gets the next time by a specific number of units from a specific time.
		/// </summary>
		/// <param name="dateTime">Target time</param>
		/// <param name="unit">Specific unit</param>
		/// <param name="amount">next step</param>
		/// <returns>Next DateTime</returns>
		/// <exception cref="ArgumentException">amount is less 0</exception>
		/// <exception cref="UnsupportedTimeGranularityUnitException"></exception>
		public static DateTime Next(this DateTime dateTime, TimeGranularityUnit unit, int amount)
		{
			if (amount == 0)
				return dateTime;
			if (amount < 0)
				throw new ArgumentException($"required amount > 0 fail ('{amount}')");
			return unit switch
			{
				TimeGranularityUnit.SECONDS => dateTime.AddSeconds(amount),
				TimeGranularityUnit.MINUTES => dateTime.AddMinutes(amount),
				TimeGranularityUnit.HOURS => dateTime.AddHours(amount),
				TimeGranularityUnit.DAYS => dateTime.AddDays(amount),
				TimeGranularityUnit.WEEK => dateTime.AddDays(7 * amount),
				TimeGranularityUnit.MONTHS => dateTime.AddMonths(amount),
				TimeGranularityUnit.QUARTER => dateTime.AddMonths(3 * amount),
				TimeGranularityUnit.YEARS => dateTime.AddYears(amount),
				_ => throw new UnsupportedTimeGranularityUnitException($"unsupported '{unit}'"),
			};
		}

		/// <summary>
		/// 특정 시간을 특정 시간 단위로 이전 시간을 가져옵니다.
		/// </summary>
		/// <param name="dateTime">Target time</param>
		/// <param name="unit">Specific unit</param>
		/// <param name="amount">previous step</param>
		/// <returns>Previous DateTime</returns>
		/// <exception cref="ArgumentException">amount is less 0</exception>
		/// <exception cref="UnsupportedTimeGranularityUnitException"></exception>
		public static DateTime Previous(this DateTime dateTime, TimeGranularityUnit unit, int amount)
		{
			if (amount == 0)
				return dateTime;
			if (amount < 0)
				throw new ArgumentException($"required amount > 0 fail ('{amount}')");
			return unit switch
			{
				TimeGranularityUnit.SECONDS => dateTime.AddSeconds(-amount),
				TimeGranularityUnit.MINUTES => dateTime.AddMinutes(-amount),
				TimeGranularityUnit.HOURS => dateTime.AddHours(-amount),
				TimeGranularityUnit.DAYS => dateTime.AddDays(-amount),
				TimeGranularityUnit.WEEK => dateTime.AddDays(7 * -amount),
				TimeGranularityUnit.MONTHS => dateTime.AddMonths(-amount),
				TimeGranularityUnit.QUARTER => dateTime.AddMonths(3 * -amount),
				TimeGranularityUnit.YEARS => dateTime.AddYears(-amount),
				_ => throw new UnsupportedTimeGranularityUnitException($"unsupported '{unit}'"),
			};
		}

		/// <summary>
		/// Get UNIX Time Milliseconds for a specific time.
		/// </summary>
		/// <param name="dateTime">Specific time</param>
		/// <returns>UNIX Time Milliseconds</returns>
		public static long ToMilliseconds(this DateTime dateTime)
		{
			return new DateTimeOffset(dateTime.ToUniversalTime()).ToUnixTimeMilliseconds();
		}

		/// <summary>
		/// Get UNIX Time Seconds for a specific time.
		/// </summary>
		/// <param name="dateTime">Specific time</param>
		/// <returns>UNIX Time Seconds</returns>
		public static long ToTimeSeconds(this DateTime dateTime)
		{
			return new DateTimeOffset(dateTime.ToUniversalTime()).ToUnixTimeSeconds();
		}

		/// <summary>
		/// Matches a specific time to a time closer to a specific interval.
		/// </summary>
		/// <param name="dateTime">Specific DateTime</param>
		/// <param name="interval">Specific Interval</param>
		/// <returns>Snapped DateTime</returns>
		public static DateTime Snap(this DateTime dateTime, long interval)
		{
			long time = dateTime.ToUniversalTime().ToMilliseconds();
			return (time - (time % interval)).FromUnixTimeMilliseconds(dateTime.Kind);
		}

		/// <summary>
		/// Matches a specific time to a closer time based on a factor of a specific unit.
		/// </summary>
		/// <param name="dateTime">Specific DateTime</param>
		/// <param name="factor">Time Factor</param>
		/// <param name="unit">Time Unit</param>
		/// <returns>Snapped DateTime</returns>
		/// <exception cref="UnsupportedTimeGranularityUnitException"></exception>
		public static DateTime Snap(this DateTime dateTime, int factor, TimeGranularityUnit unit)
		{
			if (factor != 1)
			{
				switch (unit)
				{
					case TimeGranularityUnit.SECONDS:
						return dateTime.Snap(1000L * factor);
					case TimeGranularityUnit.MINUTES:
						return dateTime.Snap(1000L * 60 * factor);
					case TimeGranularityUnit.HOURS:
						return dateTime.Snap(1000L * 60 * 60 * factor);
					case TimeGranularityUnit.DAYS:
						return dateTime.Snap(1000L * 60 * 60 * 24 * factor);
					case TimeGranularityUnit.WEEK:
						return dateTime.Snap(factor * 7, TimeGranularityUnit.DAYS);
					case TimeGranularityUnit.MONTHS:
						{
							int r = dateTime.Month - 1;
							int m = (r - r % factor) + 1;
							return new DateTime(dateTime.Year, m, 1, 0, 0, 0, dateTime.Kind);
						}
					case TimeGranularityUnit.QUARTER:
						return dateTime.Snap(factor * 3, TimeGranularityUnit.MONTHS);
					case TimeGranularityUnit.YEARS:
						{
							int y = (dateTime.Year - dateTime.Year % factor);
							return new DateTime(y, 1, 1, 0, 0, 0, dateTime.Kind);
						}
					default:
						throw new UnsupportedTimeGranularityUnitException();
				}
			}
			else
				return dateTime.Truncate(unit);
		}
	}
}
