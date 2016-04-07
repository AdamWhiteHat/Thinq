using System;
using System.Linq;
using System.Collections.Generic;

namespace ThinqCore
{
	public class Intersection : IDisposable
	{
		public bool IsDisposed { get; private set; }
		public bool CancellationPending { get; internal set; }
		public IEnumerable<ulong> ResultSet { get { return _quotientGroup == null ? default(IEnumerable<ulong>) : _quotientGroup.GetEnumerable(); } }

		private ulong _minValue;
		private ulong _maxValue;
		private List<ulong> _coFactors;
		private QuotientGroup _quotientGroup;

		public Intersection(ulong minValue, ulong maxValue, params ulong[] sequenceRoots)
		{
			if (maxValue < minValue) { throw new ArgumentOutOfRangeException(paramName: "maxValue", message: "Parameter 'maxValue' cannot be less than parameter 'minValue'."); }
			if (sequenceRoots == null || sequenceRoots.Length < 1) { throw new ArgumentOutOfRangeException(paramName: "sequenceRoots", message: "Parameter 'sequenceRoots' must contain at least one element."); }

			_minValue = minValue;
			_maxValue = maxValue;
			_coFactors = new List<ulong>(sequenceRoots);
			_quotientGroup = new QuotientGroup(_minValue, _maxValue, _coFactors);
		}

		public IEnumerable<ulong> GetEnumerable()
		{
			return ResultSet.TakeWhile<ulong>(i => (i < _maxValue) && !this.CancellationPending);
		}

		public void CancelAsync()
		{
			if (!CancellationPending && !IsDisposed)
			{
				CancellationPending = true;
				_quotientGroup.CancelAsync();
			}
		}

		public void Dispose()
		{
			if (!IsDisposed)
			{
				IsDisposed = true;

				if (_quotientGroup != null)
				{
					if (!_quotientGroup.IsDisposed)
					{
						_quotientGroup.Dispose();
					}
					_quotientGroup = null;
				}

				if (_coFactors != null)
				{
					_coFactors.Clear();
					_coFactors = null;
				}
			}
		}

	} // END class
}
