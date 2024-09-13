namespace System.RelativeTime.Ast
{
	public interface IReletiveTimeExpression
	{
		void Accept(IReletiveTimeExpressionVisitor visitor);

		public sealed class ReletiveTimeExpression(NowPart? nowPart, ModifierPart? modifierPart, SnapPart? snapPart) : IReletiveTimeExpression
		{
			public NowPart NowPart => nowPart;
			public ModifierPart? ModifierPart => modifierPart;
			public SnapPart SnapPart => snapPart;

			public void Accept(IReletiveTimeExpressionVisitor visitor)
			{
				visitor.Visit(this);
			}
		}

		public sealed class NowPart : IReletiveTimeExpression
		{
			public void Accept(IReletiveTimeExpressionVisitor visitor)
			{
				visitor.Visit(this);
			}
		}

		public enum OperatorType
		{
			PLUS, MINUS
		}

		public sealed class ModifierPart(OperatorType operatorType, int? factor, TimeGranularityUnit unit) : IReletiveTimeExpression
		{
			public OperatorType OperatorType => operatorType;
			public int? Factor => factor;
			public TimeGranularityUnit Unit => unit;

			public void Accept(IReletiveTimeExpressionVisitor visitor)
			{
				visitor.Visit(this);
			}
		}

		public sealed class SnapPart(TimeGranularityUnit unit, int? weekFactor, ModifierPart? modifierPart) : IReletiveTimeExpression
		{
			public TimeGranularityUnit Unit => unit;
			public int? WeekFactor => weekFactor;
			public ModifierPart? ModifierPart => modifierPart;

			public void Accept(IReletiveTimeExpressionVisitor visitor)
			{
				visitor.Visit(this);
			}
		}
	}
}
