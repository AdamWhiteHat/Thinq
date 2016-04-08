using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ThinqCore;

namespace ThinqUnitTests
{
	[TestClass]
	public class CoPrimesUnitTest
	{
		[TestMethod]
		public void TestGcdMany()
		{
			int[] testNumbers1 = new int[] { 6, 12, 27 };
			int[] testNumbers2 = new int[] { 6, 12, 27, 5 };
			int[] testNumbers3 = new int[] { 3, 7, 11, 13, 17, 19, 23 };
			int expectedValue1 = 3;
			int expectedValue2 = 1;
			int expectedValue3 = 1;

			int resultValue1 = Coprimes.FindGCD(testNumbers1);
			int resultValue2 = Coprimes.FindGCD(testNumbers2);
			int resultValue3 = Coprimes.FindGCD(testNumbers3);

			Assert.AreEqual(expectedValue1, resultValue1);
			Assert.AreEqual(expectedValue2, resultValue2);
			Assert.AreEqual(expectedValue3, resultValue3);
		}

		[TestMethod]
		public void TestLcmTwo()
		{
			int[] testNumbers1 = new int[] { 251, 257 };
			int expectedValue1 = 64507;

			int resultValue1 = Coprimes.FindLCM(testNumbers1);

			Assert.AreEqual(expectedValue1, resultValue1);
		}

		[TestMethod]
		public void TestLcmMany()
		{
			// GCD[251, 257] 1	LCM[251, 257] 64507

			int[] testNumbers1 = new int[] { 6, 12, 27 };
			int[] testNumbers2 = new int[] { 6, 12, 27, 5 };
			int[] testNumbers3 = new int[] { 3, 7, 11, 13, 17, 19, 23 };
			int expectedValue1 = 108;
			int expectedValue2 = 540;
			int expectedValue3 = 22309287;

			int resultValue1 = Coprimes.FindLCM(testNumbers1);
			int resultValue2 = Coprimes.FindLCM(testNumbers2);
			int resultValue3 = Coprimes.FindLCM(testNumbers3);

			Assert.AreEqual(expectedValue1, resultValue1);
			Assert.AreEqual(expectedValue2, resultValue2);
			Assert.AreEqual(expectedValue3, resultValue3);
		}

		[TestMethod]
		public void TestCoPrimes256()
		{
			int coprimeTo = 256;
			int coprimeMin = 16777216;
			int coprimeMax = 16777700;
			int expectedCoprimeCount = 242;
			int expectedFirst = 16777217;
			int expectedLast = 16777699;

			Coprimes coprimes = new Coprimes(coprimeTo, coprimeMin, coprimeMax);
			List<int> resultCoprimes = coprimes.GetCoprimes().ToList();
			int resultCoprimeCount = resultCoprimes.Count;

			Assert.AreEqual(expectedCoprimeCount, resultCoprimeCount);
			Assert.AreEqual(expectedFirst, resultCoprimes.First());
			Assert.AreEqual(expectedLast, resultCoprimes.Last());
		}

		[TestMethod]
		public void TestCoPrimes251()
		{
			int coprimeTo = 251;
			int coprimeMin = 1234567000;
			int coprimeMax = 1234568000;
			int expectedCoprimeCount = 996;
			int expectedFirst = 1234567000;
			int expectedLast = 1234567999;

			Coprimes coprimes = new Coprimes(coprimeTo, coprimeMin, coprimeMax);
			List<int> resultCoprimes = coprimes.GetCoprimes().ToList();
			int resultCoprimeCount = resultCoprimes.Count;

			Assert.AreEqual(expectedCoprimeCount, resultCoprimeCount);
			Assert.AreEqual(expectedFirst, resultCoprimes.First());
			Assert.AreEqual(expectedLast, resultCoprimes.Last());
		}

		[TestMethod]
		public void TestCoPrimesEmpty()
		{
			int coprimeTo = 20160;
			int coprimeMin = 6777122;
			int coprimeMax = 6777131;
			int expectedCoprimeCount = 0;

			Coprimes coprimes = new Coprimes(coprimeTo, coprimeMin, coprimeMax);
			List<int> resultCoprimes = coprimes.GetCoprimes().ToList();
			int resultCoprimeCount = resultCoprimes.Count;

			Assert.AreEqual(expectedCoprimeCount, resultCoprimeCount);
		}
	}
}
