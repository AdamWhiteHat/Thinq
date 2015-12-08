using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ThinqCore
{
	public class EnumerableRange
	{
		private int _minValue;
		private int _maxValue;
		private int _incrementSize;
		private int _counterValue;

		private int _maxIterations = 10000000; // 10,000,000
		private int _counterIterations;

		public EnumerableRange(int minValue, int maxValue, int incrementSize)
		{
			if (maxValue <= minValue) { throw new ArgumentOutOfRangeException("maxValue <= minValue"); }
			if (minValue + incrementSize > maxValue) { throw new ArgumentOutOfRangeException("(minValue + stepValue) > maxValue"); }

			if (incrementSize < 1) { throw new ArgumentOutOfRangeException("stepValue < 1"); }

			_minValue = minValue;
			_maxValue = maxValue;
			_incrementSize = incrementSize;
			_counterValue = 0;
			_counterIterations = 1;
		}

		public IEnumerable<int> GetNext()
		{
			while (_counterValue < _maxValue && _counterIterations < _maxIterations)
			{							
				_counterValue += _incrementSize;
				yield return _counterValue;
				_counterIterations++;
			}
									
			if (Settings.IsDebug())
			{
				Console.WriteLine("Factor: {0}", _incrementSize);
				Console.WriteLine("\tcounterValue (max): {0:n0} ({1:n0})", _counterValue, _maxValue);
				Console.WriteLine("\tcounterIterations (max): {0:n0} ({1:n0})", _counterIterations, _maxIterations);
				Console.WriteLine();
			}

			yield break;
		}

		public bool IsIn(EnumerableRange range)
		{
			bool result = range._minValue <= this._minValue;
			result &= range._maxValue >= this._maxValue;
			return result;
		}

		public bool Contains(int value)
		{
			if (value < _minValue)
			{
				return false;
			}
			if (value > _maxValue)
			{
				return false;
			}
			return true;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}

			EnumerableRange other = obj as EnumerableRange;
			if (other == null)
			{
				return false;
			}

			bool result = false;
			result = this._minValue == other._minValue;
			result &= this._maxValue == other._maxValue;
			result &= this._incrementSize == other._incrementSize;
			return result;
		}

		public override int GetHashCode()
		{
			unchecked
			{
				long a = this._minValue * 3;
				long b = this._maxValue * 7;
				long c = this._incrementSize * 17;
				int result = (int)(a + b + c);
				return result;
			}
		}


	} // END class
}
