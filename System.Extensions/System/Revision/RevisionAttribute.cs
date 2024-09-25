namespace System.Revision
{
	/// <summary>
	/// Assembly 에 대한 Revision 정보를 제공하기 위한 Attribute
	/// </summary>
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false, Inherited = false)]
	public class RevisionAttribute(string revision) : Attribute, IRevision
	{
		/// <summary>
		/// Assembly 에 대한 Revision 정보 제공
		/// </summary>
		public string Revision => revision;
	}
}
