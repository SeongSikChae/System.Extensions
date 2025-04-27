namespace System.PeriodicTime
{
	/// <summary>
	/// Periodic Time Interval (System.DateTime[Start], System.DateTime[End])
	/// </summary>
	public sealed class PeriodicTimeInterval(DateTime start, DateTime end)
	{
		/// <summary>
		/// System.DateTime[Start]
		/// </summary>
		public DateTime Start => start;

		/// <summary>
		/// System.DateTime[End]
		/// </summary>
		public DateTime End => end;

		/// <summary>
		/// Validate Interval From PeriodicTimeGranularity
		/// </summary>
		/// <param name="granularity"></param>
		/// <returns></returns>
		public bool ValidInterval(PeriodicTimeGranularity granularity)
		{
			DateTime s0 = granularity.Snap(Start);
			if (!s0.Equals(Start))
				return false;
			DateTime s1 = granularity.Next(s0);
			if (!s1.Equals(End))
				return false;
			return true;
		}

		/// <summary>
		/// Periodic Time Interval Override ToString
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return $"{Start:yyyy-MM-dd HH:mm:ss.fff}~{End:yyyy-MM-dd HH:mm:ss.fff}";
		}

		/// <summary>
		/// Interval List From Period, Delay, Initial, LastDone, System.DateTime
		/// </summary>
		/// <param name="period">Interval period</param>
		/// <param name="delay">Interval Delay</param>
		/// <param name="retroactive">Retroactive Interval </param>
		/// <param name="lastExecutionInterval"></param>
		/// <param name="now"></param>
		/// <exception cref="Exception"></exception>
		public static List<PeriodicTimeInterval> GetToDoIntervals(PeriodicTimeGranularity period, PeriodicTimeGranularity delay, PeriodicTimeGranularity retroactive, PeriodicTimeInterval? lastExecutionInterval, DateTime now)
		{
			DateTime endTime = period.Next(period.Snap(now));
			endTime = period.Snap(endTime.Previous(delay.Unit, delay.Factor));

			List<PeriodicTimeInterval> l = new List<PeriodicTimeInterval>();
			DateTime startTime = period.Snap(endTime.Previous(retroactive.Unit, retroactive.Factor));
			if (lastExecutionInterval is not null && lastExecutionInterval.ValidInterval(period))
			{
				DateTime nextOfLast = lastExecutionInterval.End;
				if (nextOfLast.CompareTo(startTime) > 0)
					startTime = nextOfLast;
			}

			DateTime time = startTime;
			while (time.CompareTo(endTime) < 0)
			{
				DateTime next = period.Next(time);
				l.Add(new PeriodicTimeInterval(time, next));
				time = next;
			}

			if (startTime.CompareTo(endTime) == 0)
				return l;

			if (lastExecutionInterval == null && l.Count == 0)
				throw new Exception("illegal period paramters : initial must be older");

			return l;
		}
	}
}
