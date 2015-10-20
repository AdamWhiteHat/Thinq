using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Reactive;
using System.Reactive.Threading.Tasks;
using System.Reactive.Threading;
using System.Reactive.Subjects;
using System.Reactive.PlatformServices;
using System.Reactive.Joins;
using System.Reactive.Disposables;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Linq.Observαble;

namespace ThinqCore
{
	public class Range
	{
		private int _minValue;
		private int _maxValue;
		private int _commonDifference;
		private int _counterValue;

		private int _maxIterations = 10000000; // 10,000,000
		private int _counterIterations;

		public Range(int minValue, int maxValue, int commonDifference)
		{
			if (maxValue <= minValue) { throw new ArgumentOutOfRangeException("maxValue <= minValue"); }
			if (minValue + commonDifference > maxValue) { throw new ArgumentOutOfRangeException("(minValue + stepValue) > maxValue"); }

			if (commonDifference < 1) { throw new ArgumentOutOfRangeException("stepValue < 1"); }

			_minValue = minValue;
			_maxValue = maxValue;
			_commonDifference = commonDifference;
			_counterValue = 0;
			_counterIterations = 1;
		}

		public IEnumerable<int> GetNext()
		{
			while (_counterValue < _maxValue && _counterIterations < _maxIterations)
			{							
				_counterValue += _commonDifference;
				yield return _counterValue;
				_counterIterations++;
			}
			
			if (Settings.IsDebug())
			{
				Console.WriteLine("Factor: {0}", _commonDifference);
				Console.WriteLine("\tcounterValue (max): {0:n0} ({1:n0})", _counterValue, _maxValue);
				Console.WriteLine("\tcounterIterations (max): {0:n0} ({1:n0})", _counterIterations, _maxIterations);
				Console.WriteLine();
			}
		}

		public bool IsIn(Range range)
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

			Range other = obj as Range;
			if (other == null)
			{
				return false;
			}

			bool result = false;
			result = this._minValue == other._minValue;
			result &= this._maxValue == other._maxValue;
			result &= this._commonDifference == other._commonDifference;
			return result;
		}
	} // END class
}
