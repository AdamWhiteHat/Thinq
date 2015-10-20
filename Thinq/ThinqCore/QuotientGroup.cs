using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinqCore
{
	public class QuotientGroup
	{
		private int _minValue;
		private int _maxValue;
		//private int _stepValue;
		private int _counterValue;
		private List<int> _coFactors;

		private int _maxReturnValues = 1000000; // 1,000,000
		private int _counterValuesReturned;

		// Performance counters
		TimeSpan _processingTotalTime = TimeSpan.Zero;

		private int _counterDivisionOperations_Performed;
		private int _counterDivisionOperations_PostYieldSkipped;

		private int _counterFirstLoop_FailFast;
		private int _counterFirstLoop_Skipped;

		private int _counterDivisionOperations_TotalSkipped { get { return _counterDivisionOperations_PostYieldSkipped + _counterFirstLoop_Skipped; } }


		public QuotientGroup(int minValue, int maxValue, List<int> coFactors)
		{
			if (maxValue <= minValue) { throw new ArgumentOutOfRangeException("maxValue must be greater than minValue"); }
			if (minValue > maxValue) { throw new ArgumentOutOfRangeException("maxValue minus minValue must be greater than or equal to stepValue"); }

			if (coFactors == null) { throw new ArgumentOutOfRangeException("coFactors cannot be null"); }
			if (!coFactors.Any()) { throw new ArgumentOutOfRangeException("coFactors cannot be empty"); }
			if (coFactors.Any(i => i == 0)) { throw new ArgumentOutOfRangeException("coFactors cannot contain a value of zero"); }

			_minValue = minValue;
			_maxValue = maxValue;

			_coFactors = coFactors.Distinct().OrderBy(i => i).ToList();
		}

		public IEnumerable<int> GetNext()
		{
			DateTime startTime = DateTime.Now;

			int smallestFactor = _coFactors.FirstOrDefault(); // Smallest value
			_coFactors.Remove(smallestFactor);

			List<int> otherFactors = _coFactors.OrderByDescending(i => i).ToList();
			int largestFactor = otherFactors.FirstOrDefault();

			int postYieldSkip = 0;
			int smallestFactorQuotient = largestFactor / smallestFactor;
			if (largestFactor % smallestFactor == 0)
			{
				if (Settings.IsDebug())
				{
					Console.WriteLine("Note: smallestFactor goes into largestFactor evenly!");
				}
				smallestFactorQuotient -= 1;
			}

			if (smallestFactorQuotient > 0)
			{
				postYieldSkip = (smallestFactor * smallestFactorQuotient);
			}

			if (Settings.IsDebug())
			{
				Console.WriteLine("Initializing GetNext()");
				Console.WriteLine("smallestFactor/largestFactor (smallestFactorQuotient): {0:n0}/{1:n0} ({2:n0})", smallestFactor, largestFactor, smallestFactorQuotient);
				Console.WriteLine("postYieldSkip: {0:n0}", postYieldSkip);
				Console.WriteLine();
			}

			bool isFactor = false;
			_counterValue = _minValue;
			_counterValuesReturned = 1;
			_counterDivisionOperations_Performed = 1;
			_counterDivisionOperations_PostYieldSkipped = 0;
			_counterFirstLoop_FailFast = 0;
			_counterFirstLoop_Skipped = 0;

			while (_counterValue < _maxValue && _counterValuesReturned < _maxReturnValues)
			{
				_counterValue += smallestFactor;

				isFactor = true;
				bool isFirstLoop = true;
				foreach (int factor in otherFactors)
				{
					isFactor &= (_counterValue % factor == 0);

					if (Settings.IsDebug()) { _counterDivisionOperations_Performed++; }

					if (!isFactor)
					{
						break;
					}
					isFirstLoop = false;
				}

				if (Settings.IsDebug())
				{
					if (isFirstLoop)
					{
						_counterFirstLoop_FailFast++;

						int operations = _coFactors.TakeWhile(i => _counterValue % i == 0).Count();
						_counterFirstLoop_Skipped += operations;
					}
					if (isFactor)
					{
						_counterDivisionOperations_PostYieldSkipped += postYieldSkip;
					}
				}

				if (isFactor)
				{
					yield return _counterValue;
					_counterValuesReturned++;
					_counterValue += postYieldSkip;
				}
			}

			_processingTotalTime = DateTime.Now.Subtract(startTime);
			string timeElapsed = string.Format("Total Time Elapsed: {0}", _processingTotalTime.ToString(@"mm\:ss\.ff"));

			if (Settings.IsDebug())
			{
				Console.ResetColor();
				Console.Write("Value (max): {0:n0} ", _counterValue);
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.WriteLine("({0:n0})", _maxValue);
				Console.ResetColor();
				Console.Write("Iterations (max): {0:n0} ", _counterValuesReturned);
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.WriteLine("({0:n0})", _maxReturnValues);
				Console.ResetColor();
				Console.WriteLine("--- Perf stats ---");
				Console.ForegroundColor = ConsoleColor.DarkCyan;
				Console.WriteLine(timeElapsed);
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.WriteLine("Divisions Performed: {0:n0}", _counterDivisionOperations_Performed);
				Console.ResetColor();
				Console.WriteLine("FirstLoopFailFast (OperationsSaved): {0:n0} ({1:n0})", _counterFirstLoop_FailFast, _counterFirstLoop_Skipped);
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("PostYieldSkipped + FirstLoopSkipped = TotalSkipped: {0:n0} + {1:n0} = {2:n0}", _counterDivisionOperations_PostYieldSkipped, _counterFirstLoop_Skipped, _counterDivisionOperations_TotalSkipped);
				Console.ResetColor();
				Console.WriteLine();
			}
		}

	} // END class QuotientGroup
}
