using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;

using ThinqCore;

namespace ThinqUnitTests
{
	[TestClass]
	public class CoFactorsUnitTest
	{
		[TestMethod]
		public void TestCoFactorsExplicit()
		{
			BigInteger minValue = 803134100;
			BigInteger maxValue = 892372000;			                      
			BigInteger[] cofactors = new BigInteger[] { 3, 7, 11, 13, 17, 19, 23 };
			int expectedFactorCount = 5;
			List<BigInteger> expectedValues = new List<BigInteger>() { 803134332, 825443619, 847752906, 870062193, 892371480 };

			Intersection intersection = new Intersection(minValue, maxValue, cofactors, new BigInteger(1000000));
			List<BigInteger> intersectionResult = intersection.GetEnumerable().ToList();
			int resultFactorCount = intersectionResult.Count;

			Assert.AreEqual(expectedFactorCount, resultFactorCount);
			Assert.IsFalse(expectedValues.Except(intersectionResult).Any());
		}

		[TestMethod]
		public void TestCoFactorsCount()
		{
			BigInteger minValue = 4394000100;
			BigInteger maxValue = 8788050000;
			BigInteger[] cofactors = new BigInteger[] { 251, 257, 259, 263 };
			int expectedFactorCount = 2;
			BigInteger expectedFirst = 4394023319;
			BigInteger expectedLast = 8788046638;

			Intersection intersection = new Intersection(minValue, maxValue, cofactors, new BigInteger(1000000));
			List<BigInteger> intersectionResult = intersection.GetEnumerable().ToList();
			int resultFactorCount = intersectionResult.Count;

			Assert.AreEqual(expectedFactorCount, resultFactorCount);
			Assert.AreEqual(expectedFirst, intersectionResult.First());
			Assert.AreEqual(expectedLast, intersectionResult.Last());
		}

		[TestMethod]
		public void TestCoFactorsEmpty()
		{
			BigInteger minValue = 8000100100;
			BigInteger maxValue = 8322177083;
			BigInteger[] cofactors = new BigInteger[] { 251, 257, 64506 };
			int expectedFactorCount = 0;

			Intersection intersection = new Intersection(minValue, maxValue, cofactors, new BigInteger(1000000));
			List<BigInteger> intersectionResult = intersection.GetEnumerable().ToList();
			int resultFactorCount = intersectionResult.Count;

			Assert.AreEqual(expectedFactorCount, resultFactorCount);
		}
	}
}
