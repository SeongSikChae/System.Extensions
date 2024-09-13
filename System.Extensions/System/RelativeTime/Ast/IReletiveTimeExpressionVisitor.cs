namespace System.RelativeTime.Ast
{
	public interface IReletiveTimeExpressionVisitor
	{
		void Visit(IReletiveTimeExpression.ReletiveTimeExpression expression);

		void Visit(IReletiveTimeExpression.NowPart nowPart);

		void Visit(IReletiveTimeExpression.ModifierPart modifierPart);

		void Visit(IReletiveTimeExpression.SnapPart snapPart);
	}
}
