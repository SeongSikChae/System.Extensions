# System namespace Extensions

## System.DateTime Extensions

* TimeGranularityUnit enum (SECONDS, MINUTES, HOURS, DAYS, WEEK, MONTHS, QUATER, YEARS)
* Quarter enum (Q1, Q2, Q3, Q4)
* Quarter GetQuarter();
* DateTime Truncate(TimeGranularityUnit unit);
* DateTime Next(TimeGranularityUnit unit, int amount);
* DateTime Previous(TimeGranularityUnit unit, int amount);
* long ToMilliseconds(); // UNIX TIMESTAMP
* long ToTimeSeconds(); // UNIX TIMESECONDS
* DateTime Sanp(long interval);
* DateTime Sanmp(int factor, TimeGranularityUnit unit);

## System.Int64 Extensions

* DateTime.FromUnixTimeMilliseconds(DateTimeKind kind);
* DateTime.FromUnixTimeSeconds(DateTimeKind kind);

## System.PeriodicTime namespace

* PeriodicTimeGranularity
* PeriodicTimeInterval
* TimeGranularitySpec

## System.RelativeTime namespace

* Expression Parser
* Expression To DateTime Parser

### System.RelativeTime.Ast

* Relative Time Expression
* Relative Time Expression Visitor

### System.RelativeTime.Parser

* ANTRL Expression Parser Compiler
