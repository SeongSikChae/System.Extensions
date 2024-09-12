namespace System
{
	/// <summary>
	/// Exception when using unsupported TimeGranularityUnit
	/// </summary>
	/// <param name="message">Error Message</param>
	/// <param name="innerException">Inner Exception</param>
	public sealed class UnsupportedTimeGranularityUnitException(string? message, Exception? innerException) : Exception(message, innerException)
	{
		/// <summary>
		/// Exception when using unsupported TimeGranularityUnit
		/// </summary>
		/// <param name="message">Error Message</param>
		public UnsupportedTimeGranularityUnitException(string message) : this(message, null) { }

		/// <summary>
		/// Exception when using unsupported TimeGranularityUnit
		/// </summary>
		public UnsupportedTimeGranularityUnitException() : this(null, null) { }
	}
}
