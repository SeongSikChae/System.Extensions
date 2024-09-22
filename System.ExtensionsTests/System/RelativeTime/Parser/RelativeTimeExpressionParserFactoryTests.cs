namespace System.RelativeTime.Parser.Tests
{
	using Diagnostics;
	using RelativeTime.Ast;

	[TestClass]
	public class RelativeTimeExpressionParserFactoryTests
	{
		[TestMethod]
		public void ParseTest()
		{
			IRelativeTimeExpressionParser parser = RelativeTimeExpressionParserFactory.Create();
			{
				IRelativeTimeExpression expr = parser.Parse("now");
				Trace.WriteLine(expr);
				Assert.IsTrue(expr is IRelativeTimeExpression.RelativeTimeExpression);
				IRelativeTimeExpression.RelativeTimeExpression e = (IRelativeTimeExpression.RelativeTimeExpression)expr;
				Assert.IsNotNull(e.NowPart);
				Assert.IsNull(e.ModifierPart);
				Assert.IsNull(e.SnapPart);
			}

			{
				IRelativeTimeExpression expr = parser.Parse("-5s");
				Trace.WriteLine(expr);
				Assert.IsTrue(expr is IRelativeTimeExpression.RelativeTimeExpression);
				IRelativeTimeExpression.RelativeTimeExpression e = (IRelativeTimeExpression.RelativeTimeExpression)expr;
				Assert.IsNull(e.NowPart);
				Assert.IsNotNull(e.ModifierPart);
				Assert.AreEqual(IRelativeTimeExpression.OperatorType.MINUS, e.ModifierPart.OperatorType);
				Assert.AreEqual(5, e.ModifierPart.Factor);
				Assert.AreEqual(TimeGranularityUnit.SECONDS, e.ModifierPart.Unit);
				Assert.IsNull(e.SnapPart);
			}

			{
				IRelativeTimeExpression expr = parser.Parse("-5m");
				Trace.WriteLine(expr);
				Assert.IsTrue(expr is IRelativeTimeExpression.RelativeTimeExpression);
				IRelativeTimeExpression.RelativeTimeExpression e = (IRelativeTimeExpression.RelativeTimeExpression)expr;
				Assert.IsNull(e.NowPart);
				Assert.IsNotNull(e.ModifierPart);
				Assert.AreEqual(IRelativeTimeExpression.OperatorType.MINUS, e.ModifierPart.OperatorType);
				Assert.AreEqual(5, e.ModifierPart.Factor);
				Assert.AreEqual(TimeGranularityUnit.MINUTES, e.ModifierPart.Unit);
				Assert.IsNull(e.SnapPart);
			}

			{
				IRelativeTimeExpression expr = parser.Parse("-5h");
				Trace.WriteLine(expr);
				Assert.IsTrue(expr is IRelativeTimeExpression.RelativeTimeExpression);
				IRelativeTimeExpression.RelativeTimeExpression e = (IRelativeTimeExpression.RelativeTimeExpression)expr;
				Assert.IsNull(e.NowPart);
				Assert.IsNotNull(e.ModifierPart);
				Assert.AreEqual(IRelativeTimeExpression.OperatorType.MINUS, e.ModifierPart.OperatorType);
				Assert.AreEqual(5, e.ModifierPart.Factor);
				Assert.AreEqual(TimeGranularityUnit.HOURS, e.ModifierPart.Unit);
				Assert.IsNull(e.SnapPart);
			}

			{
				IRelativeTimeExpression expr = parser.Parse("-5d");
				Trace.WriteLine(expr);
				Assert.IsTrue(expr is IRelativeTimeExpression.RelativeTimeExpression);
				IRelativeTimeExpression.RelativeTimeExpression e = (IRelativeTimeExpression.RelativeTimeExpression)expr;
				Assert.IsNull(e.NowPart);
				Assert.IsNotNull(e.ModifierPart);
				Assert.AreEqual(IRelativeTimeExpression.OperatorType.MINUS, e.ModifierPart.OperatorType);
				Assert.AreEqual(5, e.ModifierPart.Factor);
				Assert.AreEqual(TimeGranularityUnit.DAYS, e.ModifierPart.Unit);
				Assert.IsNull(e.SnapPart);
			}

			{
				IRelativeTimeExpression expr = parser.Parse("-5w");
				Trace.WriteLine(expr);
				Assert.IsTrue(expr is IRelativeTimeExpression.RelativeTimeExpression);
				IRelativeTimeExpression.RelativeTimeExpression e = (IRelativeTimeExpression.RelativeTimeExpression)expr;
				Assert.IsNull(e.NowPart);
				Assert.IsNotNull(e.ModifierPart);
				Assert.AreEqual(IRelativeTimeExpression.OperatorType.MINUS, e.ModifierPart.OperatorType);
				Assert.AreEqual(5, e.ModifierPart.Factor);
				Assert.AreEqual(TimeGranularityUnit.WEEK, e.ModifierPart.Unit);
				Assert.IsNull(e.SnapPart);
			}

			{
				IRelativeTimeExpression expr = parser.Parse("-5mon");
				Trace.WriteLine(expr);
				Assert.IsTrue(expr is IRelativeTimeExpression.RelativeTimeExpression);
				IRelativeTimeExpression.RelativeTimeExpression e = (IRelativeTimeExpression.RelativeTimeExpression)expr;
				Assert.IsNull(e.NowPart);
				Assert.IsNotNull(e.ModifierPart);
				Assert.AreEqual(IRelativeTimeExpression.OperatorType.MINUS, e.ModifierPart.OperatorType);
				Assert.AreEqual(5, e.ModifierPart.Factor);
				Assert.AreEqual(TimeGranularityUnit.MONTHS, e.ModifierPart.Unit);
				Assert.IsNull(e.SnapPart);
			}

			{
				IRelativeTimeExpression expr = parser.Parse("-5q");
				Trace.WriteLine(expr);
				Assert.IsTrue(expr is IRelativeTimeExpression.RelativeTimeExpression);
				IRelativeTimeExpression.RelativeTimeExpression e = (IRelativeTimeExpression.RelativeTimeExpression)expr;
				Assert.IsNull(e.NowPart);
				Assert.IsNotNull(e.ModifierPart);
				Assert.AreEqual(IRelativeTimeExpression.OperatorType.MINUS, e.ModifierPart.OperatorType);
				Assert.AreEqual(5, e.ModifierPart.Factor);
				Assert.AreEqual(TimeGranularityUnit.QUARTER, e.ModifierPart.Unit);
				Assert.IsNull(e.SnapPart);
			}

			{
				IRelativeTimeExpression expr = parser.Parse("-5y");
				Trace.WriteLine(expr);
				Assert.IsTrue(expr is IRelativeTimeExpression.RelativeTimeExpression);
				IRelativeTimeExpression.RelativeTimeExpression e = (IRelativeTimeExpression.RelativeTimeExpression)expr;
				Assert.IsNull(e.NowPart);
				Assert.IsNotNull(e.ModifierPart);
				Assert.AreEqual(IRelativeTimeExpression.OperatorType.MINUS, e.ModifierPart.OperatorType);
				Assert.AreEqual(5, e.ModifierPart.Factor);
				Assert.AreEqual(TimeGranularityUnit.YEARS, e.ModifierPart.Unit);
				Assert.IsNull(e.SnapPart);
			}

			{
				IRelativeTimeExpression expr = parser.Parse("now-1h");
				Trace.WriteLine(expr);
				Assert.IsTrue(expr is IRelativeTimeExpression.RelativeTimeExpression);
				IRelativeTimeExpression.RelativeTimeExpression e = (IRelativeTimeExpression.RelativeTimeExpression)expr;
				Assert.IsNotNull(e.NowPart);
				Assert.IsNotNull(e.ModifierPart);
				Assert.AreEqual(IRelativeTimeExpression.OperatorType.MINUS, e.ModifierPart.OperatorType);
				Assert.AreEqual(1, e.ModifierPart.Factor);
				Assert.AreEqual(TimeGranularityUnit.HOURS, e.ModifierPart.Unit);
				Assert.IsNull(e.SnapPart);
			}

			{
				IRelativeTimeExpression expr = parser.Parse("@d");
				Trace.WriteLine(expr);
				Assert.IsTrue(expr is IRelativeTimeExpression.RelativeTimeExpression);
				IRelativeTimeExpression.RelativeTimeExpression e = (IRelativeTimeExpression.RelativeTimeExpression)expr;
				Assert.IsNull(e.NowPart);
				Assert.IsNull(e.ModifierPart);
				Assert.IsNotNull(e.SnapPart);
				Assert.AreEqual(IRelativeTimeExpression.SnapTimeUnit.DAYS, e.SnapPart.SnapUnit);
			}

			{
				IRelativeTimeExpression expr = parser.Parse("@w1");
				Trace.WriteLine(expr);
				Assert.IsTrue(expr is IRelativeTimeExpression.RelativeTimeExpression);
				IRelativeTimeExpression.RelativeTimeExpression e = (IRelativeTimeExpression.RelativeTimeExpression)expr;
				Assert.IsNull(e.NowPart);
				Assert.IsNull(e.ModifierPart);
				Assert.IsNotNull(e.SnapPart);
				Assert.AreEqual(IRelativeTimeExpression.SnapTimeUnit.WEEK1, e.SnapPart.SnapUnit);
				Assert.IsNull(e.SnapPart.ModifierPart);
			}

			{
				IRelativeTimeExpression expr = parser.Parse("@w1-1d");
				Trace.WriteLine(expr);
				Assert.IsTrue(expr is IRelativeTimeExpression.RelativeTimeExpression);
				IRelativeTimeExpression.RelativeTimeExpression e = (IRelativeTimeExpression.RelativeTimeExpression)expr;
				Assert.IsNull(e.NowPart);
				Assert.IsNull(e.ModifierPart);
				Assert.IsNotNull(e.SnapPart);
				Assert.AreEqual(IRelativeTimeExpression.SnapTimeUnit.WEEK1, e.SnapPart.SnapUnit);
				Assert.IsNotNull(e.SnapPart.ModifierPart);
				Assert.AreEqual(IRelativeTimeExpression.OperatorType.MINUS, e.SnapPart.ModifierPart.OperatorType);
				Assert.IsNotNull(e.SnapPart.ModifierPart.Factor);
				Assert.AreEqual(1, e.SnapPart.ModifierPart.Factor);
				Assert.AreEqual(TimeGranularityUnit.DAYS, e.SnapPart.ModifierPart.Unit);
			}
		}
	}
}