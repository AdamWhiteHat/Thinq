using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinqCore
{
	public class Range : ILinearRange
	{
		private Range()
		{
		}

		private long _min;
		public long Min
		{
			get { return _min; }
			private set { _min = value; }
		}

		private long _max;
		public long Max
		{
			get { return _max; }
			private set { _max = value; }
		}

		public long Length
		{
			get { return _max - _min; }
		}

		public bool IsIn(ILinearRange range)
		{
			if((range.Min >= this.Min) && (range.Max <= this.Max))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool IsIn(long value)
		{
			if ((value >= this.Min) && (value <= this.Max))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public override string ToString()
		{
			return string.Format("Range[{0} -> {1}]", Min, Max);
		}

		public static class Factory
		{
			public static Range MinMax(long min, long max)
			{
				if (min > max)
				{
					throw new ArgumentOutOfRangeException("min, max", "min cannot be greater than max");
				}

				Range result = new Range();

				result.Min = min;
				result.Max = max;

				return result;
			}

			public static Range StartCount(long start, long count)
			{
				Range result = new Range();

				result.Min = start;
				result.Max = start + count;

				return result;
			}

			public static Range OriginRadius(long origin, long radius)
			{
				if (radius < 0)
				{
					throw new ArgumentOutOfRangeException("triCenter", "absolute value cannot be negative.");
				}

				Range result = new Range();

				result.Min = origin - radius;
				result.Max = origin + radius;

				return result;
			}
		}
	}
}
