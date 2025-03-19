namespace System.RelativeTime
{
	using Ast;

	/// <summary>
	/// Relative Time To System.DateTime Parser Interface
	/// </summary>
	public interface IRelativeTimeToDateTimeParser
	{
		/// <summary>
		/// Relative Time AST To System.DateTime Parse
		/// </summary>
		DateTime Parse(IRelativeTimeExpression expression, DateTime time);

		internal sealed class ParserContext : IRelativeTimeExpressionContext
		{
			private readonly Stack<DateTime> stack = new Stack<DateTime>();

			public void Push(DateTime time)
			{
				stack.Push(time);
			}

			public bool TryPop(out DateTime time)
			{
				return stack.TryPop(out time);
			}

			public DateTime Pop()
			{
				return stack.Pop();
			}
		}

		internal sealed class RelativeTimeToDateTimeParser : IRelativeTimeExpressionVisitor<ParserContext>, IRelativeTimeToDateTimeParser
		{
			public DateTime Parse(IRelativeTimeExpression expression, DateTime time)
			{
				ParserContext context = new ParserContext();
				context.Push(time);

				expression.Accept(this, context);

				return context.Pop();
			}

			public void Visit(IRelativeTimeExpression.RelativeTimeExpression expression, ParserContext context)
			{
				expression.NowPart?.Accept(this, context);
				expression.ModifierPart?.Accept(this, context);
				expression.SnapPart?.Accept(this, context);
			}

			public void Visit(IRelativeTimeExpression.NowPart nowPart, ParserContext context)
			{
				context.Push(DateTime.Now);
			}

			public void Visit(IRelativeTimeExpression.ModifierPart modifierPart, ParserContext context)
			{
				if (!context.TryPop(out DateTime dateTime))
					dateTime = DateTime.Now;
				if (modifierPart.Factor.HasValue)
				{
					switch (modifierPart.OperatorType)
					{
						case IRelativeTimeExpression.OperatorType.PLUS:
							context.Push(dateTime.Next(modifierPart.Unit, (int)Math.Abs(modifierPart.Factor.Value)));
							break;
						default:
							context.Push(dateTime.Previous(modifierPart.Unit, (int)Math.Abs(modifierPart.Factor.Value)));
							break;
					}
				}
				else
					context.Push(dateTime);
			}

			public void Visit(IRelativeTimeExpression.SnapPart snapPart, ParserContext context)
			{
				if (!context.TryPop(out DateTime dateTime))
					dateTime = DateTime.Now;
				switch (snapPart.SnapUnit)
				{
					case IRelativeTimeExpression.SnapTimeUnit.SECONDS:
						dateTime = dateTime.Truncate(TimeGranularityUnit.SECONDS);
						break;
					case IRelativeTimeExpression.SnapTimeUnit.MINUTES:
						dateTime = dateTime.Truncate(TimeGranularityUnit.MINUTES);
						break;
					case IRelativeTimeExpression.SnapTimeUnit.HOURS:
						dateTime = dateTime.Truncate(TimeGranularityUnit.HOURS);
						break;
					case IRelativeTimeExpression.SnapTimeUnit.DAYS:
						dateTime = dateTime.Truncate(TimeGranularityUnit.DAYS);
						break;
					case IRelativeTimeExpression.SnapTimeUnit.WEEK:
						dateTime = dateTime.Truncate(TimeGranularityUnit.WEEK);
						break;
					case IRelativeTimeExpression.SnapTimeUnit.WEEK1:
						dateTime = dateTime.Truncate(TimeGranularityUnit.WEEK).Previous(TimeGranularityUnit.DAYS, 6);
						break;
					case IRelativeTimeExpression.SnapTimeUnit.WEEK2:
						dateTime = dateTime.Truncate(TimeGranularityUnit.WEEK).Previous(TimeGranularityUnit.DAYS, 5);
						break;
					case IRelativeTimeExpression.SnapTimeUnit.WEEK3:
						dateTime = dateTime.Truncate(TimeGranularityUnit.WEEK).Previous(TimeGranularityUnit.DAYS, 4);
						break;
					case IRelativeTimeExpression.SnapTimeUnit.WEEK4:
						dateTime = dateTime.Truncate(TimeGranularityUnit.WEEK).Previous(TimeGranularityUnit.DAYS, 3);
						break;
					case IRelativeTimeExpression.SnapTimeUnit.WEEK5:
						dateTime = dateTime.Truncate(TimeGranularityUnit.WEEK).Previous(TimeGranularityUnit.DAYS, 2);
						break;
					case IRelativeTimeExpression.SnapTimeUnit.WEEK6:
						dateTime = dateTime.Truncate(TimeGranularityUnit.WEEK).Previous(TimeGranularityUnit.DAYS, 1);
						break;
					case IRelativeTimeExpression.SnapTimeUnit.MONTHS:
						dateTime = dateTime.Truncate(TimeGranularityUnit.MONTHS);
						break;
					case IRelativeTimeExpression.SnapTimeUnit.QUARTER:
						dateTime = dateTime.Truncate(TimeGranularityUnit.QUARTER);
						break;
					case IRelativeTimeExpression.SnapTimeUnit.YEARS:
						dateTime = dateTime.Truncate(TimeGranularityUnit.YEARS);
						break;
				}

				context.Push(dateTime);

				if (snapPart.ModifierPart is not null)
					snapPart.ModifierPart.Accept(this, context);
			}
		}
	}
}
