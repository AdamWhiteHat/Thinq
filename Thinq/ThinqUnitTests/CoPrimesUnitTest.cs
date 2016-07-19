using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;

using ThinqCore;

namespace ThinqUnitTests
{
	[TestClass]
	public class CoPrimesUnitTest
	{
		[TestMethod]
		public void TestGcdMany()
		{
			BigInteger[] testNumbers1 = new BigInteger[] { 6, 12, 27 };
			BigInteger[] testNumbers2 = new BigInteger[] { 6, 12, 27, 5 };
			BigInteger[] testNumbers3 = new BigInteger[] { 3, 7, 11, 13, 17, 19, 23 };
			BigInteger expectedValue1 = 3;
			BigInteger expectedValue2 = 1;
			BigInteger expectedValue3 = 1;

			BigInteger resultValue1 = Coprimes.FindGCD(testNumbers1);
			BigInteger resultValue2 = Coprimes.FindGCD(testNumbers2);
			BigInteger resultValue3 = Coprimes.FindGCD(testNumbers3);

			Assert.AreEqual(expectedValue1, resultValue1);
			Assert.AreEqual(expectedValue2, resultValue2);
			Assert.AreEqual(expectedValue3, resultValue3);
		}

		[TestMethod]
		public void TestLcmTwo()
		{
			BigInteger[] testNumbers1 = new BigInteger[] { 251, 257 };
			BigInteger expectedValue1 = 64507;

			BigInteger resultValue1 = Coprimes.FindLCM(testNumbers1);

			Assert.AreEqual(expectedValue1, resultValue1);
		}

		[TestMethod]
		public void TestLcmMany()
		{
			// GCD[251, 257] 1	LCM[251, 257] 64507

			BigInteger[] testNumbers1 = new BigInteger[] { 6, 12, 27 };
			BigInteger[] testNumbers2 = new BigInteger[] { 6, 12, 27, 5 };
			BigInteger[] testNumbers3 = new BigInteger[] { 3, 7, 11, 13, 17, 19, 23 };
			BigInteger expectedValue1 = 108;
			BigInteger expectedValue2 = 540;
			BigInteger expectedValue3 = 22309287;

			BigInteger resultValue1 = Coprimes.FindLCM(testNumbers1);
			BigInteger resultValue2 = Coprimes.FindLCM(testNumbers2);
			BigInteger resultValue3 = Coprimes.FindLCM(testNumbers3);

			Assert.AreEqual(expectedValue1, resultValue1);
			Assert.AreEqual(expectedValue2, resultValue2);
			Assert.AreEqual(expectedValue3, resultValue3);
		}

		[TestMethod]
		public void TestCoPrimes256()
		{
			BigInteger coprimeTo = 256;
			BigInteger coprimeMin = 16777216;
			BigInteger coprimeMax = 16777700;
			int expectedCoprimeCount = 242;
			BigInteger expectedFirst = 16777217;
			BigInteger expectedLast = 16777699;

			Coprimes coprimes = new Coprimes(coprimeTo, coprimeMin, coprimeMax);
			List<BigInteger> resultCoprimes = coprimes.GetCoprimes().ToList();
			int resultCoprimeCount = resultCoprimes.Count;

			Assert.AreEqual(expectedCoprimeCount, resultCoprimeCount);
			Assert.AreEqual(expectedFirst, resultCoprimes.First());
			Assert.AreEqual(expectedLast, resultCoprimes.Last());
		}

		[TestMethod]
		public void TestCoPrimes251()
		{
			BigInteger coprimeTo = 251;
			BigInteger coprimeMin = 1234567000;
			BigInteger coprimeMax = 1234568000;
			int expectedCoprimeCount = 996;
			BigInteger expectedFirst = 1234567000;
			BigInteger expectedLast = 1234567999;

			Coprimes coprimes = new Coprimes(coprimeTo, coprimeMin, coprimeMax);
			List<BigInteger> resultCoprimes = coprimes.GetCoprimes().ToList();
			int resultCoprimeCount = resultCoprimes.Count;

			Assert.AreEqual(expectedCoprimeCount, resultCoprimeCount);
			Assert.AreEqual(expectedFirst, resultCoprimes.First());
			Assert.AreEqual(expectedLast, resultCoprimes.Last());
		}

		[TestMethod]
		public void TestCoPrimesEmpty()
		{
			BigInteger coprimeTo = 20160;
			BigInteger coprimeMin = 6777122;
			BigInteger coprimeMax = 6777131;
			int expectedCoprimeCount = 0;

			Coprimes coprimes = new Coprimes(coprimeTo, coprimeMin, coprimeMax);
			List<BigInteger> resultCoprimes = coprimes.GetCoprimes().ToList();
			int resultCoprimeCount = resultCoprimes.Count;

			Assert.AreEqual(expectedCoprimeCount, resultCoprimeCount);
		}

		[TestMethod]
		public void TestFindPrimeFactors()
		{
			BigInteger coprimeTo = 111247819;
			BigInteger coprimeMin = 2;
			BigInteger coprimeMax = 111247820;
			int expectedCoprimeCount = 2;
			BigInteger primeP = 10007;
			BigInteger primeQ = 11117;

			Coprimes coprimes = new Coprimes(coprimeTo, coprimeMin, coprimeMax);
			List<BigInteger> resultCoprimes = coprimes.GetPrimeFactors().ToList();
			int resultCoprimeCount = resultCoprimes.Count;

			Assert.AreEqual(expectedCoprimeCount, resultCoprimeCount);
			Assert.AreEqual(resultCoprimes[0], primeP);
			Assert.AreEqual(resultCoprimes[1], primeQ);
		}

		[TestMethod]
		public void TestFindPrimeFactors32bit()
		{
			BigInteger coprimeTo = 1202664026348236889;
			BigInteger coprimeMin = 1069760585;
			BigInteger coprimeMax = 1202664026348236890;
			int expectedCoprimeCount = 2;								
			BigInteger primeP = 1074936217;
			BigInteger primeQ = 1118823617;

			Coprimes coprimes = new Coprimes(coprimeTo, coprimeMin, coprimeMax);
			List<BigInteger> resultCoprimes = coprimes.GetPrimeFactors().ToList();
			int resultCoprimeCount = resultCoprimes.Count;

			Assert.AreEqual(expectedCoprimeCount, resultCoprimeCount);
			Assert.AreEqual(resultCoprimes[0], primeP);
			Assert.AreEqual(resultCoprimes[1], primeQ);
		}

		[TestMethod]
		public void TestFindPrimeFactors64bit()
		{
			BigInteger coprimeTo = BigInteger.Parse("90459209396766660489526818707270239963");
			BigInteger coprimeMin = 9223506588021000000;
			BigInteger coprimeMax = BigInteger.Parse("90459209396766660489526818707270239964");
			int expectedCoprimeCount = 2;
			BigInteger primeP = 9223506588022268141;
			BigInteger primeQ = 9807464062988563943;

			Coprimes coprimes = new Coprimes(coprimeTo, coprimeMin, coprimeMax);
			List<BigInteger> resultCoprimes = coprimes.GetPrimeFactors().ToList();
			int resultCoprimeCount = resultCoprimes.Count;

			Assert.AreEqual(expectedCoprimeCount, resultCoprimeCount);
			Assert.AreEqual(resultCoprimes[0], primeP);
			Assert.AreEqual(resultCoprimes[1], primeQ);
		}
	}
}
