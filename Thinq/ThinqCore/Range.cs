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
		private int _min;
		private int _max;
		private int _step;
		private int _length;
		private int _cursorPosition;

		public Range(int min, int max, int stepSize, int length)
		{			
			if (max < 1) { throw new ArgumentOutOfRangeException("max"); }
			if (length < 0) { throw new ArgumentOutOfRangeException("length"); }
			if (stepSize < 1) { throw new ArgumentOutOfRangeException("root"); }
			
			_min = min;
			_max = max;
			_step = stepSize;
			_length = length;
			_cursorPosition = 0;
		}

		public IEnumerable<int> GetNext()
		{
			while (_cursorPosition < _max)
			{
				_cursorPosition += _step;
				yield return _cursorPosition;
			}
		}

		public bool Contains(int value)
		{
			if (value < _min)
			{
				return false;
			}
			if (value > _max)
			{
				return false;
			}
			return true;
		}

		public override bool Equals(object obj)
		{
			bool result = false;
			Range other = obj as Range;
			if (other != null)
			{
				result = this._min == other._min;
				result &= this._max == other._max;
				result &= this._step == other._step;
				result &= this._length == other._length;
			}
			return result;
		}

	} // END class
}
