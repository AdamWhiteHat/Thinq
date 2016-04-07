using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinqCore
{
	public class QuotientGroup : IDisposable
	{
		private ulong _minReturnValue;
		private ulong _maxReturnValue;
		private ulong _maxReturnQuantity;
		//private ulong _stepValue;
		private ulong _counterValue;
		private List<ulong> _coFactors;		
		private ulong _counterValuesReturned;
		private Debug debugMetrics;

		public bool IsDisposed { get; private set; }
		public bool CancellationPending { get; internal set; }

		public QuotientGroup(ulong minValue, ulong maxValue, List<ulong> coFactors, ulong maxQuantity = 1000000)
		{
			if (maxValue <= minValue) { throw new ArgumentOutOfRangeException("maxValue must be greater than minValue"); }
			if (minValue > maxValue) { throw new ArgumentOutOfRangeException("maxValue minus minValue must be greater than or equal to stepValue"); }

			if (coFactors == null) { throw new ArgumentOutOfRangeException("coFactors cannot be null"); }
			if (!coFactors.Any()) { throw new ArgumentOutOfRangeException("coFactors cannot be empty"); }
			if (coFactors.Any(i => i == 0)) { throw new ArgumentOutOfRangeException("coFactors cannot contain a value of zero"); }

			_minReturnValue = minValue;
			_maxReturnValue = maxValue;
			_maxReturnQuantity = maxQuantity;
			_coFactors = coFactors;			

			_counterValue = 0;
			_counterValuesReturned = 0;

			debugMetrics = new Debug();
		}

		public void Dispose()
		{
			if (!IsDisposed)
			{
				IsDisposed = true;

				if (_coFactors != null)
				{
					_coFactors.Clear();
					_coFactors = null;
				}

				if (debugMetrics != null)
				{
					debugMetrics.Dispose();
					debugMetrics = null;
				}
			}
		}

		public void CancelAsync()
		{
			if (!CancellationPending && !IsDisposed)
			{
				CancellationPending = true;
			}
		}

		public IEnumerable<ulong> GetEnumerable()
		{
			if (!IsDisposed && !CancellationPending)
			{
				// OrderBy value ascending
				_coFactors = _coFactors.Distinct().OrderBy(i => i).ToList();

				// Get largest, smallest, quotient
				ulong largestFactor = _coFactors.LastOrDefault(); // Largest value	
				ulong smallestFactor = _coFactors.FirstOrDefault(); // Smallest value				
				ulong smallestFactorQuotient = largestFactor / smallestFactor;
				_coFactors.Remove(smallestFactor);

				// Roll quotient back by one (floor)
				if (largestFactor % smallestFactor == 0)
				{
					smallestFactorQuotient -= 1;
				}

				// Number to skip after each return yield
				ulong postYieldSkip = 0;
				if (smallestFactorQuotient > 0)
				{
					postYieldSkip = (smallestFactor * smallestFactorQuotient);
				}

				// Record variables to console
				Debug.InitialMessage(smallestFactor, largestFactor, smallestFactorQuotient, postYieldSkip);

				bool isFactor = false;
				_counterValue = _minReturnValue;
				_counterValuesReturned = 1;
				
				// Set starting value, skip non-factors
				while (_counterValue % smallestFactor != 0)
				{
					_counterValue += 1;
				}

				debugMetrics.Reset();

				List<ulong> otherFactors = _coFactors.OrderByDescending(i => i).ToList();
				while (_counterValue < _maxReturnValue && _counterValuesReturned < _maxReturnQuantity)
				{
					// Increment count by smallest factor
					_counterValue += smallestFactor;

					debugMetrics.NewLoop(); // Signify new sub-loop to metrics ()
					ulong lastFactorValue = 0; isFactor = true; // Reset loop variables
					foreach (ulong factor in otherFactors)
					{
						lastFactorValue = factor; // Set last factor
						isFactor &= (_counterValue % factor == 0); // Divide

						// Metrics
						debugMetrics.OnFirstDivisionOperation();

						if (CancellationPending) // Cancel request
						{
							break;
						}
						if (!isFactor) // Try different number if even one cofactor is not a factor
						{
							break;
						}
					}

					if (Settings.IsDebugBuild)
					{
						if (debugMetrics.IsFirstLoop)
						{
							debugMetrics._counterFirstLoop_FailFast++;
							debugMetrics._counterFirstLoop_Skipped += (ulong)_coFactors.TakeWhile(i => _counterValue % i == 0).Count();
						}
					}

					if (isFactor)
					{
						string assertEquation = string.Format("{0} % {1} == 0", _counterValue, lastFactorValue);

						yield return _counterValue;
						_counterValuesReturned++;
						_counterValue += postYieldSkip;

						if (Settings.IsDebugBuild)
						{ debugMetrics._counterDivisionOperations_PostYieldSkipped += postYieldSkip; }

						if (IsDisposed)
						{
							break;
						}
					}

					if (CancellationPending)
					{
						break;
					}
				}

				Debug.BreakMessage(this);
			}

			yield break;
		}

		internal class Debug : IDisposable
		{
			public bool IsFirstLoop { get; private set; }
			internal TimeSpan _processingTotalTime; // Performance counter
			internal ulong _counterFirstLoop_Skipped;
			internal ulong _counterFirstLoop_FailFast;
			internal ulong _counterDivisionOperations_Performed;
			internal ulong _counterDivisionOperations_PostYieldSkipped;
			internal ulong _counterDivisionOperations_TotalSkipped { get { return _counterDivisionOperations_PostYieldSkipped + _counterFirstLoop_Skipped; } }

			public Debug()
			{
				Clear();				
			}

			public void Reset()
			{
				IsFirstLoop = true;
				_counterFirstLoop_Skipped = 0;
				_counterFirstLoop_FailFast = 0;
				_counterDivisionOperations_Performed = 1; // Metrics (Debug)
				_counterDivisionOperations_PostYieldSkipped = 0;				
			}

			private void Clear()
			{
				IsFirstLoop = true;
				_counterFirstLoop_Skipped = 0;
				_counterFirstLoop_FailFast = 0;
				_counterDivisionOperations_Performed = 0;
				_counterDivisionOperations_PostYieldSkipped = 0;
				_processingTotalTime = TimeSpan.Zero;
			}

			public void Dispose()
			{
				Clear();
			}

			public void NewLoop()
			{
				IsFirstLoop = true;
			}

			public void OnFirstDivisionOperation()
			{
				IsFirstLoop = false;
				_counterDivisionOperations_Performed++;
			}

			[Conditional("DEBUG")]
			public static void InitialMessage(ulong smallestFactor, ulong largestFactor, ulong smallestFactorQuotient, ulong postYieldSkip)
			{
				Console.WriteLine("smallestFactor: {0:n0}",smallestFactor);
				Console.WriteLine("largestFactor: {0:n0}",largestFactor);
				Console.WriteLine("smallestFactorQuotient: {0:n0}", smallestFactorQuotient);
				Console.WriteLine("postYieldSkip: {0:n0}", postYieldSkip);
				Console.WriteLine();
			}

			[Conditional("DEBUG")]
			public static void BreakMessage(QuotientGroup quotientGroup)
			{
				Console.WriteLine("-");
				Console.ResetColor();
				Console.Write("Value (max): {0:n0} ", quotientGroup._counterValue);
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.WriteLine("({0:n0})", quotientGroup._maxReturnValue);
				Console.ResetColor();
				Console.Write("Iterations (max): {0:n0} ", quotientGroup._counterValuesReturned);
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.WriteLine("({0:n0})", quotientGroup._maxReturnQuantity);
				Console.ResetColor();
				Console.WriteLine("-");
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.WriteLine("Divisions Performed: {0:n0}", quotientGroup.debugMetrics._counterDivisionOperations_Performed);
				Console.ResetColor();
				Console.WriteLine("FirstLoopFailFast (OperationsSaved): {0:n0} ({1:n0})", quotientGroup.debugMetrics._counterFirstLoop_FailFast, quotientGroup.debugMetrics._counterFirstLoop_Skipped);
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("PostYieldSkipped + FirstLoopSkipped = TotalSkipped: {0:n0} + {1:n0} = {2:n0}", quotientGroup.debugMetrics._counterDivisionOperations_PostYieldSkipped, quotientGroup.debugMetrics._counterFirstLoop_Skipped, quotientGroup.debugMetrics._counterDivisionOperations_TotalSkipped);

				Console.ResetColor();
				Console.WriteLine();
			}
		}

	} // END class QuotientGroup
}
