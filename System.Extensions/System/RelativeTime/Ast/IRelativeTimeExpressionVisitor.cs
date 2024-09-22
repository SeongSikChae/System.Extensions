namespace System.RelativeTime.Ast
{
	/// <summary>
	/// Relative Time Expression Visitor Interface
	/// </summary>
	public interface IRelativeTimeExpressionVisitor
	{
		/// <summary>
		/// Relative Time Expression Visit
		/// </summary>
		/// <param name="expression"></param>
		void Visit(IRelativeTimeExpression.RelativeTimeExpression expression);

		/// <summary>
		/// NowPart Visit
		/// </summary>
		/// <param name="nowPart"></param>
		void Visit(IRelativeTimeExpression.NowPart nowPart);

		/// <summary>
		/// ModifierPart Visit
		/// </summary>
		/// <param name="modifierPart"></param>
		void Visit(IRelativeTimeExpression.ModifierPart modifierPart);

		/// <summary>
		/// SnapPart Visit
		/// </summary>
		/// <param name="snapPart"></param>
		void Visit(IRelativeTimeExpression.SnapPart snapPart);
	}
}
