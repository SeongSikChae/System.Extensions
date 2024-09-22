namespace System.RelativeTime.Parser
{
	using Antlr4.Runtime;
	using Antlr4.Runtime.Misc;
	using Ast;
	using Compiler;

	/// <summary>
	/// RelativeTimeExpression String To AST Parser Interface
	/// </summary>
	public interface IRelativeTimeExpressionParser
	{
		/// <summary>
		/// String To AST Parse
		/// </summary>
		IRelativeTimeExpression Parse(string input);

		/// <summary>
		/// TextReader To AST
		/// </summary>
		IRelativeTimeExpression Parse(TextReader reader);

		/// <summary>
		/// Stream To AST
		/// </summary>
		IRelativeTimeExpression Parse(Stream stream);

		internal sealed class RelativeTimeExpressionParser : ExpressionBaseVisitor<IRelativeTimeExpression?>, IRelativeTimeExpressionParser
		{
			public IRelativeTimeExpression Parse(string input)
			{
				return Parse(new AntlrInputStream(input));
			}

			public IRelativeTimeExpression Parse(TextReader reader)
			{
				return Parse(new AntlrInputStream(reader));
			}

			public IRelativeTimeExpression Parse(Stream stream)
			{
				return Parse(new AntlrInputStream(stream));
			}

			private IRelativeTimeExpression Parse(AntlrInputStream stream)
			{
				lock (this)
				{
					operatorTypeStack.Clear();
					factorStack.Clear();
					snapTimeUnitStack.Clear();
					ExpressionLexer lexer = new ExpressionLexer(stream);
					CommonTokenStream cts = new CommonTokenStream(lexer);
					ExpressionParser parser = new ExpressionParser(cts);
					parser.BuildParseTree = true;
					ExpressionParser.ExpressionContext context = parser.expression();
					IRelativeTimeExpression? expr = context.Accept(this);
					if (expr is null)
						throw new RelativeTimeExpressionParseException($"invalid input : '{context.GetText()}'");
					return expr;
				}
			}

			public override IRelativeTimeExpression? VisitExpression([NotNull] ExpressionParser.ExpressionContext context)
			{
				ExpressionParser.NowPartContext? nowPartContext = context.nowPart();
				IRelativeTimeExpression.NowPart? nowPart = null;
				if (nowPartContext is not null)
					nowPart = (IRelativeTimeExpression.NowPart?) nowPartContext.Accept(this);
				
				ExpressionParser.ModifierPartContext? modifierPartContext = context.modifierPart();
				IRelativeTimeExpression.ModifierPart? modifierPart = null;
				if (modifierPartContext is not null)
					modifierPart = (IRelativeTimeExpression.ModifierPart?) modifierPartContext.Accept(this);

				ExpressionParser.SnapPartContext? snapPartContext = context.snapPart();
				IRelativeTimeExpression.SnapPart? snapPart = null;
				if (snapPartContext is not null)
					snapPart = (IRelativeTimeExpression.SnapPart?) snapPartContext.Accept(this);
				return new IRelativeTimeExpression.RelativeTimeExpression(nowPart, modifierPart, snapPart);
			}

			public override IRelativeTimeExpression? VisitNowPart([NotNull] ExpressionParser.NowPartContext context)
			{
				return new IRelativeTimeExpression.NowPart();
			}

			public override IRelativeTimeExpression? VisitModifierPart([NotNull] ExpressionParser.ModifierPartContext context)
			{
				ExpressionParser.OperatorContext operatorContext = context.@operator();
				operatorContext.Accept(this);
				IRelativeTimeExpression.OperatorType operatorType = operatorTypeStack.Pop();
				int? factor = null;
				ExpressionParser.FactorContext? factorContext = context.factor();
				if (factorContext is not null)
				{
					factorContext.Accept(this);
					if (factorStack.TryPop(out int value))
						factor = value;
				}
				ExpressionParser.TimeUnitContext timeUnitContext = context.timeUnit();
				timeUnitContext.Accept(this);
				TimeGranularityUnit unit = timeUnitStack.Pop();
				return new IRelativeTimeExpression.ModifierPart(operatorType, unit, factor);
			}

			private readonly Stack<IRelativeTimeExpression.OperatorType> operatorTypeStack = new Stack<IRelativeTimeExpression.OperatorType>();

			public override IRelativeTimeExpression? VisitOperator([NotNull] ExpressionParser.OperatorContext context)
			{
				switch (context.GetText())
				{
					case "+":
						operatorTypeStack.Push(IRelativeTimeExpression.OperatorType.PLUS);
						break;
					default:
						operatorTypeStack.Push(IRelativeTimeExpression.OperatorType.MINUS);
						break;

				}
				return null;
			}

			private readonly Stack<int> factorStack = new Stack<int>();

			public override IRelativeTimeExpression? VisitFactor([NotNull] ExpressionParser.FactorContext context)
			{
				if (int.TryParse(context.GetText(), out int value))
					factorStack.Push(value);
				return null;
			}

			private readonly Stack<TimeGranularityUnit> timeUnitStack = new Stack<TimeGranularityUnit>();

			public override IRelativeTimeExpression? VisitTimeUnit([NotNull] ExpressionParser.TimeUnitContext context)
			{
				switch (context.GetText())
				{
					case "s":
						timeUnitStack.Push(TimeGranularityUnit.SECONDS);
						break;
					case "m":
						timeUnitStack.Push(TimeGranularityUnit.MINUTES);
						break;
					case "h":
						timeUnitStack.Push(TimeGranularityUnit.HOURS);
						break;
					case "d":
						timeUnitStack.Push(TimeGranularityUnit.DAYS);
						break;
					case "w":
						timeUnitStack.Push(TimeGranularityUnit.WEEK);
						break;
					case "mon":
						timeUnitStack.Push(TimeGranularityUnit.MONTHS);
						break;
					case "q":
						timeUnitStack.Push(TimeGranularityUnit.QUARTER);
						break;
					case "y":
						timeUnitStack.Push(TimeGranularityUnit.YEARS);
						break;
				}
				return null;
			}

			public override IRelativeTimeExpression? VisitSnapPart([NotNull] ExpressionParser.SnapPartContext context)
			{
				ExpressionParser.SnapTimeUnitContext timeUnitContext = context.snapTimeUnit();
				timeUnitContext.Accept(this);
				IRelativeTimeExpression.SnapTimeUnit snapTimeunit = snapTimeUnitStack.Pop();

				IRelativeTimeExpression.ModifierPart? modifierPart = null;
				ExpressionParser.ModifierPartContext? modifierPartContext = context.modifierPart();
				if (modifierPartContext != null)
					modifierPart = (IRelativeTimeExpression.ModifierPart?)modifierPartContext.Accept(this);
				return new IRelativeTimeExpression.SnapPart(snapTimeunit, modifierPart);
			}

			private readonly Stack<IRelativeTimeExpression.SnapTimeUnit> snapTimeUnitStack = new Stack<IRelativeTimeExpression.SnapTimeUnit>();

			public override IRelativeTimeExpression? VisitSnapTimeUnit([NotNull] ExpressionParser.SnapTimeUnitContext context)
			{
				switch (context.GetText())
				{
					case "s":
						snapTimeUnitStack.Push(IRelativeTimeExpression.SnapTimeUnit.SECONDS);
						break;
					case "m":
						snapTimeUnitStack.Push(IRelativeTimeExpression.SnapTimeUnit.MINUTES);
						break;
					case "h":
						snapTimeUnitStack.Push(IRelativeTimeExpression.SnapTimeUnit.HOURS);
						break;
					case "d":
						snapTimeUnitStack.Push(IRelativeTimeExpression.SnapTimeUnit.DAYS);
						break;
					case "w":
					case "w0":
					case "w7":
						snapTimeUnitStack.Push(IRelativeTimeExpression.SnapTimeUnit.WEEK);
						break;
					case "w1":
						snapTimeUnitStack.Push(IRelativeTimeExpression.SnapTimeUnit.WEEK1);
						break;
					case "w2":
						snapTimeUnitStack.Push(IRelativeTimeExpression.SnapTimeUnit.WEEK2);
						break;
					case "w3":
						snapTimeUnitStack.Push(IRelativeTimeExpression.SnapTimeUnit.WEEK3);
						break;
					case "w4":
						snapTimeUnitStack.Push(IRelativeTimeExpression.SnapTimeUnit.WEEK4);
						break;
					case "w5":
						snapTimeUnitStack.Push(IRelativeTimeExpression.SnapTimeUnit.WEEK5);
						break;
					case "w6":
						snapTimeUnitStack.Push(IRelativeTimeExpression.SnapTimeUnit.WEEK6);
						break;
					case "mon":
						snapTimeUnitStack.Push(IRelativeTimeExpression.SnapTimeUnit.MONTHS);
						break;
					case "q":
						snapTimeUnitStack.Push(IRelativeTimeExpression.SnapTimeUnit.QUARTER);
						break;
					case "y":
						snapTimeUnitStack.Push(IRelativeTimeExpression.SnapTimeUnit.YEARS);
						break;
				}
				return null;
			}
		}
	}
}
