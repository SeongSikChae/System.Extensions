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
        DateTime Parse(IRelativeTimeExpression expression);

        internal sealed class RelativeTimeToDateTimeParser : IRelativeTimeExpressionVisitor, IRelativeTimeToDateTimeParser
        {
            public DateTime Parse(IRelativeTimeExpression expression)
            {
                lock (this)
                {
                    stack.Clear();
                    expression.Accept(this);
                    return stack.Pop();
                }
            }

            private readonly Stack<DateTime> stack = new Stack<DateTime>();

            public void Visit(IRelativeTimeExpression.RelativeTimeExpression expression)
            {
                if (expression.NowPart is not null)
                    expression.NowPart.Accept(this);

                if (expression.ModifierPart is not null)
					expression.ModifierPart.Accept(this);

                if (expression.SnapPart is not null)
                    expression.SnapPart.Accept(this);
            }

            public void Visit(IRelativeTimeExpression.NowPart nowPart)
            {
                stack.Push(DateTime.Now);
            }

            public void Visit(IRelativeTimeExpression.ModifierPart modifierPart)
            {
                if (!stack.TryPop(out DateTime dateTime))
                    dateTime = DateTime.Now;
                if (modifierPart.Factor.HasValue)
                {
                    switch (modifierPart.OperatorType)
                    {
                        case IRelativeTimeExpression.OperatorType.PLUS:
                            stack.Push(dateTime.Next(modifierPart.Unit, (int)Math.Abs(modifierPart.Factor.Value)));
                            break;
                        default:
							stack.Push(dateTime.Previous(modifierPart.Unit, (int)Math.Abs(modifierPart.Factor.Value)));
							break;
                    }
                }
                 else
                    stack.Push(dateTime);
            }

            public void Visit(IRelativeTimeExpression.SnapPart snapPart)
            {
				if (!stack.TryPop(out DateTime dateTime))
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

				stack.Push(dateTime);

				if (snapPart.ModifierPart is not null)
                    snapPart.ModifierPart.Accept(this);
            }
        }
    }
}
