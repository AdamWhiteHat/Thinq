using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;

namespace ThinqCore
{
	public class Coprimes
	{
		public delegate BigInteger BinaryOperationDelegate(BigInteger value1, BigInteger value2);
		public BigInteger Number { get; private set; }
		public BigInteger Min { get; private set; }
		public BigInteger Max { get; private set; }
		
		private BigInteger counter;

		public Coprimes(BigInteger number, BigInteger min, BigInteger max)
		{
			Number = number;
			Min = min;
			Max = max;

			counter = Min;
		}

		public IEnumerable<BigInteger> GetCoprimes()
		{
			if (Max < 2 || Min < 2 || Max <= Min || Number < 1) { yield break; }

			while (counter < Max)
			{
				if (IsCoprime(Number, counter))
				{
					yield return counter;
				}
				counter++;
			}
			yield break;
		}

		public static bool IsCoprime(BigInteger value1, BigInteger value2)
		{
			return FindGCD(value1, value2) == 1;
		}

		public static BigInteger FindGCD(IEnumerable<BigInteger> numbers)
		{
			return numbers.Aggregate(FindGCD);
		}

		public static BigInteger FindLCM(IEnumerable<BigInteger> numbers)
		{
			return numbers.Aggregate(FindLCM);
		}

		public static BigInteger FindGCD(BigInteger value1, BigInteger value2)
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
			return BigInteger.Max(value1, value2);
		}

		public static BigInteger FindGCDRecursive(BigInteger value1, BigInteger value2)
		{
			return value2 == 0 ? value1 : FindGCDRecursive(value2, value1 % value2);
		}

		public static BigInteger FindLCM(BigInteger num1, BigInteger num2)
		{
			return (num1 * num2) / FindGCD(num1, num2);
		}
	}
}
