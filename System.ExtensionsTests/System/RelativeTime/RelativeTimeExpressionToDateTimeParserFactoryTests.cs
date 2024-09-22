using System.Diagnostics;

namespace System.RelativeTime.Tests
{
	[TestClass]
	public class RelativeTimeExpressionToDateTimeParserFactoryTests
	{
		[TestMethod]
		public void ParseTest()
		{
			IRelativeTimeToDateTimeParser parser = RelativeTimeExpressionToDateTimeParserFactory.Create();
			{
				DateTime dateTime = parser.Parse(new Ast.IRelativeTimeExpression.NowPart());
				Trace.WriteLine($"{dateTime:yyyy-MM-ddTHH:mm:ss.fff}");
			}
			{
				DateTime dateTime = parser.Parse(new Ast.IRelativeTimeExpression.ModifierPart(Ast.IRelativeTimeExpression.OperatorType.PLUS, TimeGranularityUnit.SECONDS, null));
				Trace.WriteLine($"{dateTime:yyyy-MM-ddTHH:mm:ss.fff}");
			}
			{
				DateTime dateTime = parser.Parse(new Ast.IRelativeTimeExpression.ModifierPart(Ast.IRelativeTimeExpression.OperatorType.PLUS, TimeGranularityUnit.SECONDS));
				Trace.WriteLine($"{dateTime:yyyy-MM-ddTHH:mm:ss.fff}");
			}
			{
				DateTime dateTime = parser.Parse(new Ast.IRelativeTimeExpression.ModifierPart(Ast.IRelativeTimeExpression.OperatorType.MINUS, TimeGranularityUnit.SECONDS));
				Trace.WriteLine($"{dateTime:yyyy-MM-ddTHH:mm:ss.fff}");
			}
			{
				DateTime dateTime = parser.Parse(new Ast.IRelativeTimeExpression.SnapPart(Ast.IRelativeTimeExpression.SnapTimeUnit.SECONDS, null));
				Trace.WriteLine($"{dateTime:yyyy-MM-ddTHH:mm:ss.fff}");
			}
			{
				DateTime dateTime = parser.Parse(new Ast.IRelativeTimeExpression.SnapPart(Ast.IRelativeTimeExpression.SnapTimeUnit.MINUTES, null));
				Trace.WriteLine($"{dateTime:yyyy-MM-ddTHH:mm:ss.fff}");
			}
			{
				DateTime dateTime = parser.Parse(new Ast.IRelativeTimeExpression.SnapPart(Ast.IRelativeTimeExpression.SnapTimeUnit.HOURS, null));
				Trace.WriteLine($"{dateTime:yyyy-MM-ddTHH:mm:ss.fff}");
			}
			{
				DateTime dateTime = parser.Parse(new Ast.IRelativeTimeExpression.SnapPart(Ast.IRelativeTimeExpression.SnapTimeUnit.DAYS, null));
				Trace.WriteLine($"{dateTime:yyyy-MM-ddTHH:mm:ss.fff}");
			}
			{
				DateTime dateTime = parser.Parse(new Ast.IRelativeTimeExpression.SnapPart(Ast.IRelativeTimeExpression.SnapTimeUnit.WEEK, null));
				Trace.WriteLine($"{dateTime:yyyy-MM-ddTHH:mm:ss.fff}");
			}
			{
				DateTime dateTime = parser.Parse(new Ast.IRelativeTimeExpression.SnapPart(Ast.IRelativeTimeExpression.SnapTimeUnit.WEEK1, null));
				Trace.WriteLine($"{dateTime:yyyy-MM-ddTHH:mm:ss.fff}");
			}
			{
				DateTime dateTime = parser.Parse(new Ast.IRelativeTimeExpression.SnapPart(Ast.IRelativeTimeExpression.SnapTimeUnit.WEEK2, null));
				Trace.WriteLine($"{dateTime:yyyy-MM-ddTHH:mm:ss.fff}");
			}
			{
				DateTime dateTime = parser.Parse(new Ast.IRelativeTimeExpression.SnapPart(Ast.IRelativeTimeExpression.SnapTimeUnit.WEEK3, null));
				Trace.WriteLine($"{dateTime:yyyy-MM-ddTHH:mm:ss.fff}");
			}
			{
				DateTime dateTime = parser.Parse(new Ast.IRelativeTimeExpression.SnapPart(Ast.IRelativeTimeExpression.SnapTimeUnit.WEEK4, null));
				Trace.WriteLine($"{dateTime:yyyy-MM-ddTHH:mm:ss.fff}");
			}
			{
				DateTime dateTime = parser.Parse(new Ast.IRelativeTimeExpression.SnapPart(Ast.IRelativeTimeExpression.SnapTimeUnit.WEEK5, null));
				Trace.WriteLine($"{dateTime:yyyy-MM-ddTHH:mm:ss.fff}");
			}
			{
				DateTime dateTime = parser.Parse(new Ast.IRelativeTimeExpression.SnapPart(Ast.IRelativeTimeExpression.SnapTimeUnit.WEEK6, null));
				Trace.WriteLine($"{dateTime:yyyy-MM-ddTHH:mm:ss.fff}");
			}
			{
				DateTime dateTime = parser.Parse(new Ast.IRelativeTimeExpression.SnapPart(Ast.IRelativeTimeExpression.SnapTimeUnit.MONTHS, null));
				Trace.WriteLine($"{dateTime:yyyy-MM-ddTHH:mm:ss.fff}");
			}
			{
				DateTime dateTime = parser.Parse(new Ast.IRelativeTimeExpression.SnapPart(Ast.IRelativeTimeExpression.SnapTimeUnit.QUARTER, null));
				Trace.WriteLine($"{dateTime:yyyy-MM-ddTHH:mm:ss.fff}");
			}
			{
				DateTime dateTime = parser.Parse(new Ast.IRelativeTimeExpression.SnapPart(Ast.IRelativeTimeExpression.SnapTimeUnit.YEARS, null));
				Trace.WriteLine($"{dateTime:yyyy-MM-ddTHH:mm:ss.fff}");
			}
			{
				DateTime dateTime = parser.Parse(new Ast.IRelativeTimeExpression.RelativeTimeExpression(
					new Ast.IRelativeTimeExpression.NowPart(), 
					new Ast.IRelativeTimeExpression.ModifierPart(
						Ast.IRelativeTimeExpression.OperatorType.PLUS, 
						TimeGranularityUnit.DAYS, 1), 
					new Ast.IRelativeTimeExpression.SnapPart(
						Ast.IRelativeTimeExpression.SnapTimeUnit.DAYS, 
						new Ast.IRelativeTimeExpression.ModifierPart(
							Ast.IRelativeTimeExpression.OperatorType.PLUS, 
							TimeGranularityUnit.MINUTES, 5))));
				Trace.WriteLine($"{dateTime:yyyy-MM-ddTHH:mm:ss.fff}");
			}
		}
	}
}