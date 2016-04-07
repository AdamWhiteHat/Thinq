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
		private ulong _minValue;
		private ulong _maxValue;
		//private ulong _stepValue;
		private ulong _counterValue;
		private List<ulong> _coFactors;
		private ulong _maxReturnValues = 1000000; // 1,000,000
		private ulong _counterValuesReturned;
		private Debug debugMetrics;

		public bool IsDisposed { get; private set; }
		public bool CancellationPending { get; internal set; }

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

				while (_counterValue % smallestFactor != 0)
				{
					_counterValue += 1;
				}

				debugMetrics.Reset();

				while (_counterValue < _maxValue && _counterValuesReturned < _maxReturnValues)
				{
					_counterValue += smallestFactor;
					debugMetrics.NewLoop();
					ulong lastFactorValue = 0;
					isFactor = true;
					foreach (ulong factor in otherFactors)
					{
						lastFactorValue = factor;
						isFactor &= (_counterValue % factor == 0);

						debugMetrics.OnFirstDivisionOperation();

						if (CancellationPending)
						{
							break;
						}
						if (!isFactor)
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

						if (isFactor)
						{
							debugMetrics._counterDivisionOperations_PostYieldSkipped += postYieldSkip;
						}
					}

					if (isFactor)
					{
						string assertEquation = string.Format("{0} % {1} == 0", _counterValue, lastFactorValue);

						yield return _counterValue;
						_counterValuesReturned++;
						_counterValue += postYieldSkip;
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
				Console.WriteLine("({0:n0})", quotientGroup._maxValue);
				Console.ResetColor();
				Console.Write("Iterations (max): {0:n0} ", quotientGroup._counterValuesReturned);
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.WriteLine("({0:n0})", quotientGroup._maxReturnValues);
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
