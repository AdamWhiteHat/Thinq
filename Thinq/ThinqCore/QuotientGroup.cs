using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinqCore
{
	public class QuotientGroup
	{
		private ulong _minValue;
		private ulong _maxValue;
		//private ulong _stepValue;
		private ulong _counterValue;
		private List<ulong> _coFactors;
		private ulong _maxReturnValues = 1000000; // 1,000,000
		private ulong _counterValuesReturned;

#if DEBUG
		TimeSpan _processingTotalTime = TimeSpan.Zero; // Performance counter
		private ulong _counterFirstLoop_Skipped;
		private ulong _counterFirstLoop_FailFast;
		private ulong _counterDivisionOperations_Performed;
		private ulong _counterDivisionOperations_PostYieldSkipped;
		private ulong _counterDivisionOperations_TotalSkipped { get { return _counterDivisionOperations_PostYieldSkipped + _counterFirstLoop_Skipped; } }
#endif

		public QuotientGroup(ulong minValue, ulong maxValue, List<ulong> coFactors)
		{
			if (maxValue <= minValue) { throw new ArgumentOutOfRangeException("maxValue must be greater than minValue"); }
			if (minValue > maxValue) { throw new ArgumentOutOfRangeException("maxValue minus minValue must be greater than or equal to stepValue"); }

			if (coFactors == null) { throw new ArgumentOutOfRangeException("coFactors cannot be null"); }
			if (!coFactors.Any()) { throw new ArgumentOutOfRangeException("coFactors cannot be empty"); }
			if (coFactors.Any(i => i == 0)) { throw new ArgumentOutOfRangeException("coFactors cannot contain a value of zero"); }

			_minValue = minValue;
			_maxValue = maxValue;
			_coFactors = coFactors;
		}

		public IEnumerable<ulong> GetEnumerable()
		{
			_coFactors = _coFactors.Distinct().OrderBy(i => i).ToList();

			ulong smallestFactor = _coFactors.FirstOrDefault(); // Smallest value
			_coFactors.Remove(smallestFactor);

			List<ulong> otherFactors = _coFactors.OrderByDescending(i => i).ToList();
			ulong largestFactor = otherFactors.FirstOrDefault();

			ulong postYieldSkip = 0;
			ulong smallestFactorQuotient = largestFactor / smallestFactor;
			if (largestFactor % smallestFactor == 0)
			{
				smallestFactorQuotient -= 1;
			}

			if (smallestFactorQuotient > 0)
			{
				postYieldSkip = (smallestFactor * smallestFactorQuotient);
			}

			Debug.InitialMessage(smallestFactor, largestFactor, smallestFactorQuotient, postYieldSkip);

			bool isFactor = false;
			_counterValue = _minValue;
			_counterValuesReturned = 1;

#if DEBUG
			_counterDivisionOperations_Performed = 1; // Metrics (Debug)
			_counterDivisionOperations_PostYieldSkipped = 0;
			_counterFirstLoop_FailFast = 0;
			_counterFirstLoop_Skipped = 0;
			bool isFirstLoop = true;
#endif

			while (_counterValue < _maxValue && _counterValuesReturned < _maxReturnValues)
			{
				_counterValue += smallestFactor;
#if DEBUG
				isFirstLoop = true;
#endif
				isFactor = true;
				foreach (ulong factor in otherFactors)
				{
					isFactor &= (_counterValue % factor == 0);

#if DEBUG
					isFirstLoop = false;
					if (Settings.IsDebug()) { _counterDivisionOperations_Performed++; }
#endif

					if (!isFactor)
					{
						break;
					}

				}

#if DEBUG
				if (isFirstLoop)
				{
					_counterFirstLoop_FailFast++;
					_counterFirstLoop_Skipped += (ulong)_coFactors.TakeWhile(i => _counterValue % i == 0).Count();
				}
				if (isFactor) { _counterDivisionOperations_PostYieldSkipped += postYieldSkip; }
#endif

				if (isFactor)
				{
					yield return _counterValue;
					_counterValuesReturned++;
					_counterValue += postYieldSkip;
				}
			}

			Debug.BreakMessage(this);

			yield break;
		}

		internal static class Debug
		{
			[Conditional("DEBUG")]
			public static void InitialMessage(ulong smallestFactor, ulong largestFactor, ulong smallestFactorQuotient, ulong postYieldSkip)
			{
				Console.WriteLine("Initializing GetNext()");
				Console.WriteLine("smallestFactor/largestFactor (smallestFactorQuotient): {0:n0}/{1:n0} ({2:n0})", smallestFactor, largestFactor, smallestFactorQuotient);
				Console.WriteLine("postYieldSkip: {0:n0}", postYieldSkip);
				Console.WriteLine();
			}

			[Conditional("DEBUG")]
			public static void BreakMessage(QuotientGroup quotientGroup)
			{
				//DateTime startTime = DateTime.Now;
				//_processingTotalTime = DateTime.Now.Subtract(startTime);
				//string timeElapsed = string.Format("Total Time Elapsed: {0}", _processingTotalTime.ToString(@"mm\:ss\.ff"));
				Console.ResetColor();
				Console.Write("Value (max): {0:n0} ", quotientGroup._counterValue);
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.WriteLine("({0:n0})", quotientGroup._maxValue);
				Console.ResetColor();
				Console.Write("Iterations (max): {0:n0} ", quotientGroup._counterValuesReturned);
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.WriteLine("({0:n0})", quotientGroup._maxReturnValues);
				Console.ResetColor();
				Console.WriteLine("--- Perf stats ---");
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				#if DEBUG
				Console.WriteLine("Divisions Performed: {0:n0}", quotientGroup._counterDivisionOperations_Performed);
				Console.ResetColor();
				Console.WriteLine("FirstLoopFailFast (OperationsSaved): {0:n0} ({1:n0})", quotientGroup._counterFirstLoop_FailFast, quotientGroup._counterFirstLoop_Skipped);
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("PostYieldSkipped + FirstLoopSkipped = TotalSkipped: {0:n0} + {1:n0} = {2:n0}", quotientGroup._counterDivisionOperations_PostYieldSkipped, quotientGroup._counterFirstLoop_Skipped, quotientGroup._counterDivisionOperations_TotalSkipped);
				#endif
				Console.ResetColor();
				Console.WriteLine();
			}
		}

	} // END class QuotientGroup
}
