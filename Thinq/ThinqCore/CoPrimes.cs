using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinqCore
{
	public static class Coprimes
	{
		public static List<int> FindCoprimes(int number, int min, int max)
		{
			if (max < 2 || min < 2 || max <= min || number < 1) { return null; }

			List<int> results = new List<int>();
			for (int counter = min; counter < max; counter++)
			{
				if (IsCoprime(number, counter))
				{
					results.Add(counter);
				}
			}
			return results;
		}

		public static bool IsCoprime(int value1, int value2)
		{
			return FindGCDModulus(value1, value2) == 1;
		}

		public static int FindGCDModulus(int value1, int value2)
		{
			while (value1 != 0 && value2 != 0)
			{
				if (value1 > value2)
				{
					value1 %= value2;
				}
				else
				{
					value2 %= value1;
				}
			}
			return Math.Max(value1, value2);
		}
	}
}
