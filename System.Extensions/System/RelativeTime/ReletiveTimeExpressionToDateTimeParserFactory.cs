namespace System.RelativeTime
{
	/// <summary>
	/// Relative Time To System.DateTime Parser Factorcy
	/// </summary>
	public static class RelativeTimeExpressionToDateTimeParserFactory
	{
		/// <summary>
		/// Relative Time To System.DateTime Parser Create
		/// </summary>
		/// <returns></returns>
		public static IRelativeTimeToDateTimeParser Create()
		{
			return new IRelativeTimeToDateTimeParser.RelativeTimeToDateTimeParser();
		}
	}
}
