using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinqCore
{
	public class Intersection
	{
		List<int> CoFactors;
		int _max;
		QuotientGroup _quotientGroup;

		public IEnumerable<int> ResultSet;

		private Intersection() { }
		public Intersection(int max, params int[] factors)
		{
			if (max < 1) { throw new ArgumentOutOfRangeException(paramName: "max", message: "Parameter 'max' cannot be less than 1."); }
			if (factors == null || factors.Length < 1) { throw new ArgumentOutOfRangeException(paramName: "factors", message: "Parameter 'factors' must contain at least one element."); }

			ResultSet = null;
			//_multiples = new List<Range>();
			//_enumerables = new List<IEnumerable<int>>();
			_max = max;
			CoFactors = new List<int>(factors);

			_quotientGroup = new QuotientGroup(0, _max, CoFactors);

			ResultSet = _quotientGroup.GetNext();
		}

		public IEnumerable<int> Finalize()
		{
			return ResultSet.TakeWhile<int>(i => i < _max);
		}

	} // END class
}
