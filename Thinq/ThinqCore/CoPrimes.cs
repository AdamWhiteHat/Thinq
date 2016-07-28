using System;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Threading;

namespace ThinqCore
{
	public class Coprimes
	{
		public BigInteger Target { get; private set; }
		public BigInteger Min { get; private set; }
		public BigInteger Max { get; private set; }

		private BigInteger counter;

		public Coprimes(BigInteger target, BigInteger min, BigInteger max)
		{
			Target = new BigInteger(target.ToByteArray());
			Min = min;
			Max = max;

			counter = Min;
		}
		
		public List<BigInteger> GetCoprimesParallel()
		{
			if (Max < 2 || Min < 1 || Max <= Min || Target < 1) { throw new ArgumentException(); }

			int[] intRange = Enumerable.Range((int)Min, (int)(Max - Min)).ToArray();

			ThreadLocal<BigInteger> localTarget = 
				new ThreadLocal<BigInteger>(() => new BigInteger(Target.ToByteArray()));

			//BigInteger localTarget = new BigInteger(Target.ToByteArray());

			ConcurrentBag<int> resultCollection = new ConcurrentBag<int>();
			ParallelLoopResult result = Parallel.ForEach(intRange, count =>
			{
				if (IsCoprime(localTarget.Value, count))
				{
					resultCollection.Add(count);
				}
			});

			return resultCollection.Select(i => (BigInteger)i).ToList();
		}

		public IEnumerable<BigInteger> GetCoprimes()
		{
			if (Max < 2 || Min < 1 || Max <= Min || Target < 1) { yield break; }

			counter = Min;

			while (counter < Max)
			{
				if (IsCoprime(Target, counter))
				{
					yield return counter;
				}
				counter++;
			}
			yield break;
		}

		public IEnumerable<BigInteger> GetPrimeFactors(int Count = 2)
		{
			if (Max < 2 || Min < 1 || Max <= Min || Target < 1) { yield break; }

			counter = Min;

			if (counter % 2 == 0)
			{
				counter += 1;
			}

			List<BigInteger> factors = new List<BigInteger>();

			while (counter < Max)
			{
				if (factors.Count > 0)
				{
					if ((Count - factors.Count) == 1)
					{
						BigInteger product = factors.Aggregate(BigInteger.Multiply);
						BigInteger remainder = new BigInteger();

						BigInteger quotient = BigInteger.DivRem(Target, product, out remainder);

						if (remainder == 0)
						{
							factors.Add(quotient);
							yield return quotient;
						}
					}

					if (factors.Count == Count)
					{
						break;
					}

					if (factors.Any(f => !IsCoprime(f, counter)))
					{
						counter += 2;
						continue;
					}
				}

				if (!IsCoprime(Target, counter))
				{
					factors.Add(counter);
					yield return counter;
				}
				counter += 2;
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

		public static BigInteger FindLCM(BigInteger num1, BigInteger num2)
		{
			return (num1 * num2) / FindGCD(num1, num2);
		}
	}
}
