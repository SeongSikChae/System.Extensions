namespace System.RelativeTime.Ast
{
	/// <summary>
	/// Relative Time Expression Visitor Interface
	/// </summary>
	public interface IRelativeTimeExpressionVisitor<TContext> where TContext : IRelativeTimeExpressionContext
	{
		/// <summary>
		/// Relative Time Expression Visit
		/// </summary>
		void Visit(IRelativeTimeExpression.RelativeTimeExpression expression, TContext context);

		/// <summary>
		/// NowPart Visit
		/// </summary>
		void Visit(IRelativeTimeExpression.NowPart nowPart, TContext context);

		/// <summary>
		/// ModifierPart Visit
		/// </summary>
		void Visit(IRelativeTimeExpression.ModifierPart modifierPart, TContext context);

		/// <summary>
		/// SnapPart Visit
		/// </summary>
		void Visit(IRelativeTimeExpression.SnapPart snapPart, TContext context);
	}

	/// <summary>
	/// IRelativeTimeExpressionVisitor Context
	/// </summary>
	public interface IRelativeTimeExpressionContext
	{
	}
}
