namespace System.Revision
{
	/// <summary>
	/// Revision 정보를 제공할 Interface
	/// </summary>
	public interface IRevision
	{
		/// <summary>
		/// Revision 정보
		/// </summary>
		string Revision { get; }
	}
}
