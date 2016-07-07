using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

namespace ThinqCore
{
	public class Intersection : IDisposable
	{
		public bool IsDisposed { get; private set; }
		public bool CancellationPending { get; internal set; }
		public IEnumerable<BigInteger> ResultSet { get { return _quotientGroup == null ? default(IEnumerable<BigInteger>) : _quotientGroup.GetEnumerable(); } }

		private BigInteger _minReturnValue;
		private BigInteger _maxReturnValue;
		private BigInteger _maxReturnQuantity;
		private List<BigInteger> _coFactors;
		private QuotientGroup _quotientGroup;

		public Intersection(BigInteger minValue, BigInteger maxValue, IEnumerable<BigInteger> sequenceRoots, BigInteger maxQuantity)
		{
			if (maxValue < minValue) { throw new ArgumentOutOfRangeException(paramName: "maxValue", message: "Parameter 'maxValue' cannot be less than parameter 'minValue'."); }
			if (sequenceRoots == null || sequenceRoots.Count() < 1) { throw new ArgumentOutOfRangeException(paramName: "sequenceRoots", message: "Parameter 'sequenceRoots' must contain at least one element."); }

			_minReturnValue = minValue;
			_maxReturnValue = maxValue;
			_maxReturnQuantity = maxQuantity;
			_coFactors = new List<BigInteger>(sequenceRoots);
			_quotientGroup = new QuotientGroup(_minReturnValue, _maxReturnValue, _coFactors, _maxReturnQuantity);
		}

		public IEnumerable<BigInteger> GetEnumerable()
		{
			return ResultSet.TakeWhile<BigInteger>(i => (i < _maxReturnValue) && !this.CancellationPending);
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
