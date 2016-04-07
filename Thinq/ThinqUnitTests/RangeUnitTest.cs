using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ThinqCore;

namespace ThinqUnitTests
{
	[TestClass]
	public class RangeUnitTest
	{
		[TestMethod]
		public void TestRange()
		{
			long zero = 0;
			long startValue = -4;
			long endValue = 2996;
			long lessThanValue = startValue - 1;
			long greaterThanValue = endValue + 1;

			Range range = Range.Factory.StartCount(startValue, Math.Abs(startValue) + endValue);

			bool answerZero = range.IsIn(zero);
			bool answerStartValue = range.IsIn(startValue);
			bool answerEndValue = range.IsIn(endValue);
			bool answerLessThanValue = range.IsIn(lessThanValue);
			bool answerGreaterThanValue = range.IsIn(greaterThanValue);

			// True
			Assert.IsTrue(answerZero);
			Assert.IsTrue(answerStartValue);
			Assert.IsTrue(answerEndValue);
			// False
			Assert.IsFalse(answerLessThanValue);
			Assert.IsFalse(answerGreaterThanValue);
		}
	}
}
