using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinqCore
{
	public class Range
	{
		public static Range Empty = new Range(min: 0, max: 0);

		private long _min;
		private long _max;

		public Range(long min, long max)
		{
			if (min > max)
			{
				throw new ArgumentOutOfRangeException("min, max", "min cannot be greater than max");
			}
			_min = min;
			_max = max;
		}

		//public Range(long ordinal, long count)
		//{
		//	_min = ordinal;
		//	_max = ordinal + count;
		//}
		
		public Range(long triCenter)
		{
			if (triCenter < 0)
			{
				throw new ArgumentOutOfRangeException("triCenter", "absolute value cannot be negative.");
			}
			_min = triCenter - triCenter;
			_max = triCenter + triCenter;
		}
	}
}
