using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ThinqCore
{
	public class QuotientGroup : IDisposable
	{
		private BigInteger _minReturnValue;
		private BigInteger _maxReturnValue;
		private BigInteger _maxReturnQuantity;
		private BigInteger _counterValue;
		private List<BigInteger> _coFactors;
		private BigInteger _counterValuesReturned;
		private Debug debugMetrics;

		public bool IsDisposed { get; private set; }
		public bool CancellationPending { get; internal set; }

		public QuotientGroup(BigInteger minValue, BigInteger maxValue, List<BigInteger> coFactors, BigInteger maxQuantity)
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

		public IEnumerable<BigInteger> GetEnumerable()
		{
			if (!IsDisposed && !CancellationPending)
			{
				// OrderBy value ascending
				_coFactors = _coFactors.Distinct().OrderBy(i => i).ToList();

				// Get largest, smallest, quotient
				BigInteger largestFactor = _coFactors.LastOrDefault(); // Largest value	
				BigInteger smallestFactor = _coFactors.FirstOrDefault(); // Smallest value				
				BigInteger smallestFactorQuotient = largestFactor / smallestFactor;
				//_coFactors.Remove(smallestFactor);

				// Roll quotient back by one (floor)
				if (largestFactor % smallestFactor == 0)
				{
					smallestFactorQuotient -= 1;
				}

				// Number to skip after each return yield
				BigInteger postYieldSkip = 0;
				if (smallestFactorQuotient > 0)
				{
					postYieldSkip = (smallestFactor * smallestFactorQuotient);
				}
				
				// No point in searching number less than the LCM
				BigInteger lcm = (BigInteger)Coprimes.FindLCM(_coFactors.Select(l => (int)l).ToArray());

				// Record variables to console
				Debug.InitialMessage(smallestFactor, largestFactor, smallestFactorQuotient, postYieldSkip, lcm);

				// Sometimes the lower limit is set higher than the LCM, in which case, don't overwrite it
				if (lcm > _minReturnValue)
				{
					_counterValue = lcm;
				}
				else
				{
					_counterValue = _minReturnValue;

					// Set starting value, skip non-factors
					while (_counterValue % smallestFactor != 0)
					{
						_counterValue += 1;
					}
				}
				
				bool isFactor = false;
				_counterValuesReturned = 0;	

				debugMetrics.Reset();

				List<BigInteger> otherFactors = _coFactors.OrderByDescending(i => i).ToList();
				while (_counterValue < _maxReturnValue
					&& _counterValuesReturned < _maxReturnQuantity)
				{
					debugMetrics.NewLoop(); // Signify new sub-loop to metrics ()
					isFactor = true; // Reset loop variables
					foreach (BigInteger factor in otherFactors)
					{
						if (CancellationPending) // Cancel request
						{
							Debug.BreakMessage(this);
							yield break;
						}

						isFactor &= (_counterValue % factor == 0); // Divide

						// Metrics
						debugMetrics.OnFirstDivisionOperation();
						
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
							debugMetrics._counterFirstLoop_Skipped += (BigInteger)_coFactors.TakeWhile(i => _counterValue % i == 0).Count();
						}
					}

					if (isFactor)
					{
						_counterValuesReturned++;
						yield return _counterValue;

						_counterValue += postYieldSkip;

						if (Settings.IsDebugBuild)
						{
							debugMetrics._counterDivisionOperations_PostYieldSkipped += postYieldSkip;
						}

						if (IsDisposed)
						{
							yield break;
						}
					}
					else
					{
						_counterValue += smallestFactor;
					}
					
					
				}

				Debug.BreakMessage(this);
			}

			yield break;
		}
		
		#region Debug class

		internal class Debug : IDisposable
		{
			public bool IsFirstLoop { get; private set; }
			internal BigInteger _counterFirstLoop_Skipped;
			internal BigInteger _counterFirstLoop_FailFast;
			internal BigInteger _counterDivisionOperations_Performed;
			internal BigInteger _counterDivisionOperations_PostYieldSkipped;
			internal BigInteger _counterDivisionOperations_TotalSkipped { get { return _counterDivisionOperations_PostYieldSkipped + _counterFirstLoop_Skipped; } }

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
			public static void InitialMessage(BigInteger smallestFactor, BigInteger largestFactor, BigInteger smallestFactorQuotient, BigInteger postYieldSkip, BigInteger lcm)
			{
				Console.WriteLine("(largestFactor: {0:n0} / smallestFactor: {1:n0}) = smallestFactorQuotient: {2:n0}", largestFactor, smallestFactor, smallestFactorQuotient);
				Console.WriteLine("(smallestFactor * smallestFactorQuotient) = postYieldSkip: {0:n0}", postYieldSkip);
				Console.WriteLine("LCM: {0:n0}", lcm);				
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

		#endregion

	} // END class QuotientGroup
}
