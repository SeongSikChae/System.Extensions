namespace System.Revision
{
	using Reflection;

	/// <summary>
	/// IRevision 구현체 로 부터 Revision 정보를 제공하는 Util
	/// </summary>
	public static class RevisionUtil
	{
		/// <summary>
		/// IRevision 구현체로 부터 Revision 정보를 가져옵니다.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static string GetRevision<T>() where T : Attribute, IRevision
		{
			T? attribute = typeof(T).Assembly.GetCustomAttribute<T>();
			if (attribute is not null)
				return attribute.Revision;
			return string.Empty;
		}
	}
}
