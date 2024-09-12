namespace System
{
	/// <summary>
	/// Extensions to System.Int64
	/// </summary>
	public static class Int64Extensions
	{
		/// <summary>
		/// Convert UNIX Time Milliseconds to System.DateTime.
		/// </summary>
		/// <param name="milliseconds">UNIX Time Milliseconds</param>
		/// <param name="kind">DateTimeKind(UTC, LOCAL)</param>
		/// <returns>DateTime corresponding to kind</returns>
		public static DateTime FromUnixTimeMilliseconds(this long milliseconds, DateTimeKind kind)
		{
			DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(milliseconds);
			switch (kind)
			{
				case DateTimeKind.Utc:
					return dateTimeOffset.UtcDateTime;
				default:
					return dateTimeOffset.LocalDateTime;
			}
		}

		/// <summary>
		/// Convert UNIX Time Seconds to System.DateTime
		/// </summary>
		/// <param name="timeSeconds">UNIX Time Seconds</param>
		/// <param name="kind">DateTimeKind(UTC, LOCAL)</param>
		/// <returns>DateTime corresponding to kind</returns>
		public static DateTime FromUnixTimeSeconds(this long timeSeconds, DateTimeKind kind)
		{
			DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(timeSeconds);
			switch (kind)
			{
				case DateTimeKind.Utc:
					return dateTimeOffset.UtcDateTime;
				default:
					return dateTimeOffset.LocalDateTime;
			}
		}
	}
}
