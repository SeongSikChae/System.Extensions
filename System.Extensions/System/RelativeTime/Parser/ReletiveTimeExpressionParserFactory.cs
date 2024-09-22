namespace System.RelativeTime.Parser
{
	/// <summary>
	/// Relative Time Expression Parser Factory
	/// </summary>
	public static class RelativeTimeExpressionParserFactory
	{
		/// <summary>
		/// Relative Time Expression Parser Create
		/// </summary>
		/// <returns></returns>
		public static IRelativeTimeExpressionParser Create()
		{
			return new IRelativeTimeExpressionParser.RelativeTimeExpressionParser();
		}
	}
}
