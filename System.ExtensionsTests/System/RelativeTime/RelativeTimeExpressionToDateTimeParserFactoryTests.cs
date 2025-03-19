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
				DateTime dateTime = parser.Parse(new Ast.IRelativeTimeExpression.NowPart(), DateTime.Now);
				Trace.WriteLine($"{dateTime:yyyy-MM-ddTHH:mm:ss.fff}");
			}
			{
				DateTime dateTime = parser.Parse(new Ast.IRelativeTimeExpression.ModifierPart(Ast.IRelativeTimeExpression.OperatorType.PLUS, TimeGranularityUnit.SECONDS, null), DateTime.Now);
				Trace.WriteLine($"{dateTime:yyyy-MM-ddTHH:mm:ss.fff}");
			}
			{
				DateTime dateTime = parser.Parse(new Ast.IRelativeTimeExpression.ModifierPart(Ast.IRelativeTimeExpression.OperatorType.PLUS, TimeGranularityUnit.SECONDS), DateTime.Now);
				Trace.WriteLine($"{dateTime:yyyy-MM-ddTHH:mm:ss.fff}");
			}
			{
				DateTime dateTime = parser.Parse(new Ast.IRelativeTimeExpression.ModifierPart(Ast.IRelativeTimeExpression.OperatorType.MINUS, TimeGranularityUnit.SECONDS), DateTime.Now);
				Trace.WriteLine($"{dateTime:yyyy-MM-ddTHH:mm:ss.fff}");
			}
			{
				DateTime dateTime = parser.Parse(new Ast.IRelativeTimeExpression.SnapPart(Ast.IRelativeTimeExpression.SnapTimeUnit.SECONDS, null), DateTime.Now);
				Trace.WriteLine($"{dateTime:yyyy-MM-ddTHH:mm:ss.fff}");
			}
			{
				DateTime dateTime = parser.Parse(new Ast.IRelativeTimeExpression.SnapPart(Ast.IRelativeTimeExpression.SnapTimeUnit.MINUTES, null), DateTime.Now);
				Trace.WriteLine($"{dateTime:yyyy-MM-ddTHH:mm:ss.fff}");
			}
			{
				DateTime dateTime = parser.Parse(new Ast.IRelativeTimeExpression.SnapPart(Ast.IRelativeTimeExpression.SnapTimeUnit.HOURS, null), DateTime.Now);
				Trace.WriteLine($"{dateTime:yyyy-MM-ddTHH:mm:ss.fff}");
			}
			{
				DateTime dateTime = parser.Parse(new Ast.IRelativeTimeExpression.SnapPart(Ast.IRelativeTimeExpression.SnapTimeUnit.DAYS, null), DateTime.Now);
				Trace.WriteLine($"{dateTime:yyyy-MM-ddTHH:mm:ss.fff}");
			}
			{
				DateTime dateTime = parser.Parse(new Ast.IRelativeTimeExpression.SnapPart(Ast.IRelativeTimeExpression.SnapTimeUnit.WEEK, null), DateTime.Now);
				Trace.WriteLine($"{dateTime:yyyy-MM-ddTHH:mm:ss.fff}");
			}
			{
				DateTime dateTime = parser.Parse(new Ast.IRelativeTimeExpression.SnapPart(Ast.IRelativeTimeExpression.SnapTimeUnit.WEEK1, null), DateTime.Now);
				Trace.WriteLine($"{dateTime:yyyy-MM-ddTHH:mm:ss.fff}");
			}
			{
				DateTime dateTime = parser.Parse(new Ast.IRelativeTimeExpression.SnapPart(Ast.IRelativeTimeExpression.SnapTimeUnit.WEEK2, null), DateTime.Now);
				Trace.WriteLine($"{dateTime:yyyy-MM-ddTHH:mm:ss.fff}");
			}
			{
				DateTime dateTime = parser.Parse(new Ast.IRelativeTimeExpression.SnapPart(Ast.IRelativeTimeExpression.SnapTimeUnit.WEEK3, null), DateTime.Now);
				Trace.WriteLine($"{dateTime:yyyy-MM-ddTHH:mm:ss.fff}");
			}
			{
				DateTime dateTime = parser.Parse(new Ast.IRelativeTimeExpression.SnapPart(Ast.IRelativeTimeExpression.SnapTimeUnit.WEEK4, null), DateTime.Now);
				Trace.WriteLine($"{dateTime:yyyy-MM-ddTHH:mm:ss.fff}");
			}
			{
				DateTime dateTime = parser.Parse(new Ast.IRelativeTimeExpression.SnapPart(Ast.IRelativeTimeExpression.SnapTimeUnit.WEEK5, null), DateTime.Now);
				Trace.WriteLine($"{dateTime:yyyy-MM-ddTHH:mm:ss.fff}");
			}
			{
				DateTime dateTime = parser.Parse(new Ast.IRelativeTimeExpression.SnapPart(Ast.IRelativeTimeExpression.SnapTimeUnit.WEEK6, null), DateTime.Now);
				Trace.WriteLine($"{dateTime:yyyy-MM-ddTHH:mm:ss.fff}");
			}
			{
				DateTime dateTime = parser.Parse(new Ast.IRelativeTimeExpression.SnapPart(Ast.IRelativeTimeExpression.SnapTimeUnit.MONTHS, null), DateTime.Now);
				Trace.WriteLine($"{dateTime:yyyy-MM-ddTHH:mm:ss.fff}");
			}
			{
				DateTime dateTime = parser.Parse(new Ast.IRelativeTimeExpression.SnapPart(Ast.IRelativeTimeExpression.SnapTimeUnit.QUARTER, null), DateTime.Now);
				Trace.WriteLine($"{dateTime:yyyy-MM-ddTHH:mm:ss.fff}");
			}
			{
				DateTime dateTime = parser.Parse(new Ast.IRelativeTimeExpression.SnapPart(Ast.IRelativeTimeExpression.SnapTimeUnit.YEARS, null), DateTime.Now);
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
							TimeGranularityUnit.MINUTES, 5))), DateTime.Now);
				Trace.WriteLine($"{dateTime:yyyy-MM-ddTHH:mm:ss.fff}");
			}
		}
	}
}