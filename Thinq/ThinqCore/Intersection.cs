using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ThinqCore
{
	public class Intersection
	{
		int _maxValue;
		List<int> _coFactors;
		QuotientGroup _quotientGroup;

		public IEnumerable<int> ResultSet;

		private Intersection() { }
		public Intersection(int maxValue, params int[] sequenceRoots)
		{
			if (maxValue < 1) { throw new ArgumentOutOfRangeException(paramName: "max", message: "Parameter 'max' cannot be less than 1."); }
			if (sequenceRoots == null || sequenceRoots.Length < 1) { throw new ArgumentOutOfRangeException(paramName: "factors", message: "Parameter 'factors' must contain at least one element."); }

			ResultSet = null;
			_maxValue = maxValue;
			_coFactors = new List<int>(sequenceRoots);

			_quotientGroup = new QuotientGroup(0, _maxValue, _coFactors);

			ResultSet = _quotientGroup.GetNext();
		}

		public IEnumerable<int> Finalize()
		{
			return ResultSet.TakeWhile<int>(i => i < _maxValue);
		}

	} // END class
}
