using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ThinqCore;

namespace ThinqUnitTests
{
	[TestClass]
	public class CoFactorsUnitTest
	{
		[TestMethod]
		public void TestCoFactorsExplicit()
		{
			ulong minValue = 800100100;
			ulong maxValue = 900000000;
			ulong[] cofactors = new ulong[] { 3, 7, 11, 13, 17, 19, 23 };
			int expectedFactorCount = 5;
			List<ulong> expectedValues = new List<ulong>() { 803134332, 825443619, 847752906, 870062193, 892371480 };

			Intersection intersection = new Intersection(minValue, maxValue, cofactors);
			List<ulong> intersectionResult = intersection.GetEnumerable().ToList();
			int resultFactorCount = intersectionResult.Count;

			Assert.AreEqual(expectedFactorCount, resultFactorCount);
			Assert.IsFalse(expectedValues.Except(intersectionResult).Any());
		}

		[TestMethod]
		public void TestCoFactorsCount()
		{
			ulong minValue = 4300100100;
			ulong maxValue = 9000000000;
			ulong[] cofactors = new ulong[] { 251, 257, 259, 263 };
			int expectedFactorCount = 2;
			ulong expectedFirst = 4394023319;
			ulong expectedLast = 8788046638;

			Intersection intersection = new Intersection(minValue, maxValue, cofactors);
			List<ulong> intersectionResult = intersection.GetEnumerable().ToList();
			int resultFactorCount = intersectionResult.Count;

			Assert.AreEqual(expectedFactorCount, resultFactorCount);
			Assert.AreEqual(expectedFirst, intersectionResult.First());
			Assert.AreEqual(expectedLast, intersectionResult.Last());
		}

		[TestMethod]
		public void TestCoFactorsEmpty()
		{
			ulong minValue = 4200100100;
			ulong maxValue = 8300100100;
			ulong[] cofactors = new ulong[] { 251, 257, 64506 };
			int expectedFactorCount = 0;

			Intersection intersection = new Intersection(minValue, maxValue, cofactors);
			List<ulong> intersectionResult = intersection.GetEnumerable().ToList();
			int resultFactorCount = intersectionResult.Count;

			Assert.AreEqual(expectedFactorCount, resultFactorCount);
		}
	}
}
