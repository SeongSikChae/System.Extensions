namespace System.RelativeTime.Parser
{
	/// <summary>
	/// Relative Time Expression Parse Exception
	/// </summary>
	public sealed class RelativeTimeExpressionParseException(string? message, Exception? innerException) : Exception(message, innerException)
	{
		/// <summary>
		/// Error message only
		/// </summary>
		public RelativeTimeExpressionParseException(string? message) : this(message, null) { }

		/// <summary>
		/// Inner exception only
		/// </summary>
		public RelativeTimeExpressionParseException(Exception? innerException) : this(null, innerException) { }

		/// <summary>
		/// default
		/// </summary>
		public RelativeTimeExpressionParseException() : this(null, null) { }
	}
}
