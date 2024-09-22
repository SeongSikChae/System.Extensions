using System.Text;

namespace System.RelativeTime.Ast
{
	/// <summary>
	/// Relative Time Expression AST Interface
	/// </summary>
	public interface IRelativeTimeExpression
	{
		/// <summary>
		/// Relative Time Expression Visitor Accept
		/// </summary>
		/// <param name="visitor">Relative Time Expression Visitor</param>
		void Accept(IRelativeTimeExpressionVisitor visitor);

		/// <summary>
		/// Relative Time Expression AST
		/// </summary>
		/// <param name="nowPart">NowPart AST</param>
		/// <param name="modifierPart">ModifierPart AST</param>
		/// <param name="snapPart">SnapPart AST</param>
		public sealed class RelativeTimeExpression(NowPart? nowPart, ModifierPart? modifierPart, SnapPart? snapPart) : IRelativeTimeExpression
		{
			/// <summary>
			/// NowPart AST Property
			/// </summary>
			public NowPart? NowPart => nowPart;
			/// <summary>
			/// ModifierPart AST Property
			/// </summary>
			public ModifierPart? ModifierPart => modifierPart;
			/// <summary>
			/// SnapPart Property
			/// </summary>
			public SnapPart? SnapPart => snapPart;

			/// <summary>
			/// Relative Time Expression Visitor Accept
			/// </summary>
			/// <param name="visitor">Relative Time Expression Visitor</param>
			public void Accept(IRelativeTimeExpressionVisitor visitor)
			{
				visitor.Visit(this);
			}

			/// <summary>
			/// Relative Time Expression AST Override ToString
			/// </summary>
			/// <returns></returns>
			public override string ToString()
			{
				StringBuilder builder = new StringBuilder("RelativeTimeExpression [NowPart=")
					.Append(NowPart)
					.Append(", ModifierPart=")
					.Append(ModifierPart)
					.Append(", SnapPart=")
					.Append(SnapPart)
					.Append(']');
				return builder.ToString();
			}
		}

		/// <summary>
		/// NowPart AST
		/// </summary>
		public sealed class NowPart : IRelativeTimeExpression
		{
			/// <summary>
			/// Relative Time Expression Visitor Accept
			/// </summary>
			/// <param name="visitor">Relative Time Expression Visitor</param>
			public void Accept(IRelativeTimeExpressionVisitor visitor)
			{
				visitor.Visit(this);
			}

			/// <summary>
			/// NowPart AST Override ToString
			/// </summary>
			/// <returns></returns>
			public override string ToString()
			{
				return "now";
			}
		}

		/// <summary>
		/// ModifierPart OperatorType Enumeration
		/// </summary>
		public enum OperatorType
		{
			/// <summary>
			/// PLUS(+)
			/// </summary>
			PLUS, 
			/// <summary>
			/// MINUS(-)
			/// </summary>
			MINUS
		}

		/// <summary>
		/// ModifierPart AST
		/// </summary>
		/// <param name="operatorType">Operator Type</param>
		/// <param name="unit">Time Granularity Unit</param>
		/// <param name="factor">Time Factor</param>
		public sealed class ModifierPart(OperatorType operatorType, TimeGranularityUnit unit, int? factor = 1) : IRelativeTimeExpression
		{
			/// <summary>
			/// OperatorType Property
			/// </summary>
			public OperatorType OperatorType => operatorType;
			/// <summary>
			/// Time Factor Property
			/// </summary>
			public int? Factor => factor;
			/// <summary>
			/// Time Granularity Unit Property
			/// </summary>
			public TimeGranularityUnit Unit => unit;

			/// <summary>
			/// Relative Time Expression Visitor Accept
			/// </summary>
			/// <param name="visitor">Relative Time Expression Visitor</param>
			public void Accept(IRelativeTimeExpressionVisitor visitor)
			{
				visitor.Visit(this);
			}

			/// <summary>
			/// ModifierPart AST Override ToString
			/// </summary>
			/// <returns></returns>
			public override string ToString()
			{
				StringBuilder builder = new StringBuilder("ModifierPart [op=")
					.Append(Enum.GetName(OperatorType))
					.Append(", Factor=")
					.Append(Factor)
					.Append(", Unit=")
					.Append(Enum.GetName(Unit))
					.Append(']');
				return builder.ToString();
			}
		}

		/// <summary>
		/// Snap Time Unit Enumeration
		/// </summary>
		public enum SnapTimeUnit
		{
			/// <summary>
			/// Seconds
			/// </summary>
			SECONDS,
			/// <summary>
			/// Minutes
			/// </summary>
			MINUTES,
			/// <summary>
			/// Hours
			/// </summary>
			HOURS,
			/// <summary>
			/// Days
			/// </summary>
			DAYS,
			/// <summary>
			/// Weeks
			/// </summary>
			WEEK,
			/// <summary>
			/// Weeks (W1)
			/// </summary>
			WEEK1,
			/// <summary>
			/// Weeks (20)
			/// </summary>
			WEEK2,
			/// <summary>
			/// Weeks (W3)
			/// </summary>
			WEEK3,
			/// <summary>
			/// Weeks (W4)
			/// </summary>
			WEEK4,
			/// <summary>
			/// Weeks (W5)
			/// </summary>
			WEEK5,
			/// <summary>
			/// Weeks (W6)
			/// </summary>
			WEEK6,
			/// <summary>
			/// Months
			/// </summary>
			MONTHS,
			/// <summary>
			/// Quarters
			/// </summary>
			QUARTER,
			/// <summary>
			/// Years
			/// </summary>
			YEARS
		}

		/// <summary>
		/// SnapPart AST
		/// </summary>
		/// <param name="snapUnit">Snap Time Unit</param>
		/// <param name="modifierPart">Modifier Part</param>
		public sealed class SnapPart(SnapTimeUnit snapUnit, ModifierPart? modifierPart) : IRelativeTimeExpression
		{
			/// <summary>
			/// Snap Unit Property
			/// </summary>
			public SnapTimeUnit SnapUnit => snapUnit;
			/// <summary>
			/// ModifierPart Property
			/// </summary>
			public ModifierPart? ModifierPart => modifierPart;

			/// <summary>
			/// Relative Time Expression Visitor Accept
			/// </summary>
			/// <param name="visitor">Relative Time Expression Visitor</param>
			public void Accept(IRelativeTimeExpressionVisitor visitor)
			{
				visitor.Visit(this);
			}

			/// <summary>
			/// SnapPart AST Override ToString
			/// </summary>
			/// <returns></returns>
			public override string ToString()
			{
				StringBuilder builder = new StringBuilder("SnapPart [SnapUnit=")
					.Append(Enum.GetName(SnapUnit))
					.Append(", ModifierPart=")
					.Append(ModifierPart)
					.Append(']');
				return builder.ToString();
			}
		}
	}
}
