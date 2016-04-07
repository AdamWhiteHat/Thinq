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
		public void TestCoPrimes253()
		{
			int coprimeTo = 253;
			int coprimeMin = 1456777000;
			int coprimeMax = 1456777777;
			int expectedCoprimeCount = 675;
			int expectedFirst = 1456777000;
			int expectedLast = 1456777776;

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
