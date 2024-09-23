namespace System.PeriodicTime
{
	using Text.Json.Serialization;
	using Text.RegularExpressions;

	/// <summary>
	/// Periodic Time
	/// </summary>
	public sealed class PeriodicTimeGranularity : IComparable<PeriodicTimeGranularity>
	{
		/// <summary>
		/// Periodic Time Constructor
		/// </summary>
		/// <param name="unit">Time Unit</param>
		/// <param name="factor">Time Factor</param>
		/// <param name="checkMaxFactor">Whether to check Max Factor validity</param>
		/// <exception cref="ArgumentException"></exception>
		public PeriodicTimeGranularity(TimeGranularityUnit unit, int factor, bool checkMaxFactor = true)
		{
			Unit = unit;
			Factor = factor;
			if (!checkMaxFactor)
				return;
			TimeGranularitySpec spec = TimeGranularitySpec.Of(unit);
			if (!spec.ValidGranularity(factor))
				throw new ArgumentException($"factor boundary overflow '{this}'");
		}

		/// <summary>
		/// Time Unit
		/// </summary>
		public TimeGranularityUnit Unit { get; }

		/// <summary>
		/// Time Factor
		/// </summary>
		public int Factor { get; }

		/// <summary>
		/// PeriodicTimeGranularity Validate Property
		/// </summary>
		[JsonIgnore]
		public bool ValidGranularity
		{
			get
			{
				TimeGranularitySpec spec = TimeGranularitySpec.Of(Unit);
				return spec.ValidGranularity(Factor);
			}
		}

		/// <summary>
		/// PeriodicTime to System.DateTime Snap
		/// </summary>
		/// <exception cref="Exception"></exception>
		public DateTime Snap(DateTime t)
		{
			if (!ValidGranularity)
				throw new Exception($"invalid factor : {Factor}");
			return t.Snap(Factor, Unit);
		}

		/// <summary>
		/// PeriodicTime To System.Datetime Next
		/// </summary>
		/// <param name="t"></param>
		/// <returns></returns>
		public DateTime Next(DateTime t)
		{
			return t.Next(Unit, Factor);
		}

		/// <summary>
		/// Periodic Time Compare
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public int CompareTo(PeriodicTimeGranularity? other)
		{
			if (other is null)
				return 0;
			int compare = Unit.CompareTo(other.Unit);
			if (compare == 0)
				compare = Factor.CompareTo(other.Factor);
			return compare;
		}

		/// <summary>
		/// Periodic Time Override GetHashCode
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			HashCode hashCode = new HashCode();
			hashCode.Add(Factor);
			hashCode.Add(Unit);
			return hashCode.ToHashCode();
		}

		/// <summary>
		/// Periodic Time Override Equals
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public override bool Equals(object? obj)
		{
			if (obj is null)
				return false;
			if (obj is not PeriodicTimeGranularity)
				return false;
			if (this == obj)
				return true;
			PeriodicTimeGranularity other = (PeriodicTimeGranularity)obj;
			if (Factor != other.Factor) 
				return false;
			if (Unit != other.Unit)
				return false;
			return true;
		}

		/// <summary>
		/// Periodic Time Override ToString
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			TimeGranularitySpec spec = TimeGranularitySpec.Of(Unit);
			return $"{spec.Prefix}{Factor}{spec.Suffix}";
		}


		private static readonly Regex p = new Regex("(P[T]?)([0-9]+)([SMHDY])");

		/// <summary>
		/// String To Periodic Time
		/// </summary>
		/// <param name="s"></param>
		/// <param name="checkMaxFactor"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"></exception>
		public static PeriodicTimeGranularity Of(string s, bool checkMaxFactor = true)
		{
			Match m = p.Match(s);
			if (m.Success)
			{
				string u = $"{m.Groups[1].Value}{m.Groups[3].Value}";
				int factor = int.Parse(m.Groups[2].Value);
				switch (u)
				{
					case "PTS":
						return new PeriodicTimeGranularity(TimeGranularityUnit.SECONDS, factor, checkMaxFactor);
					case "PTM":
						return new PeriodicTimeGranularity(TimeGranularityUnit.MINUTES, factor, checkMaxFactor);
					case "PTH":
						return new PeriodicTimeGranularity(TimeGranularityUnit.HOURS, factor, checkMaxFactor);
					case "PD":
						return new PeriodicTimeGranularity(TimeGranularityUnit.DAYS, factor, checkMaxFactor);
					case "PW":
						return new PeriodicTimeGranularity(TimeGranularityUnit.WEEK, factor, checkMaxFactor);
					case "PM":
						return new PeriodicTimeGranularity(TimeGranularityUnit.MONTHS, factor, checkMaxFactor);
					case "PQ":
						return new PeriodicTimeGranularity(TimeGranularityUnit.QUARTER, factor, checkMaxFactor);
					case "PY":
						return new PeriodicTimeGranularity(TimeGranularityUnit.YEARS, factor, checkMaxFactor);
				}
			}
			throw new ArgumentException($"illegal granularity '{s}'");
		}
	}
}
