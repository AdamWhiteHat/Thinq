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
		//List<QuotientGroup> _multiples;
		//List<IEnumerable<int>> _enumerables;

		public IEnumerable<int> ResultSet;

		private Intersection() { }
		public Intersection(int max, params int[] factors)
		{
			if (max < 1) { throw new ArgumentOutOfRangeException(paramName: "max", message: "Parameter 'max' cannot be less than 1."); }
			if (factors == null || factors.Length < 1) { throw new ArgumentOutOfRangeException(paramName: "factors", message: "Parameter 'factors' must contain at least one element."); }

			ResultSet = null;
			//_multiples = new List<QuotientGroup>();
			//_enumerables = new List<IEnumerable<int>>();
			_max = max;
			CoFactors = new List<int>(factors);

			foreach (int factor in CoFactors)
			{
				AddCofactor(factor);
			}
		}

		public void AddCofactor(int coFactor)
		{
			QuotientGroup m = new QuotientGroup(coFactor, _max);
			IEnumerable<int> e = m.GetNextQuotient().Where(i => i < _max);

			//_enumerables.Add(e);
			//_multiples.Add(m);

			if (ResultSet == null)
			{
				ResultSet = e;
			}
			else
			{
				ResultSet = ResultSet.Intersect(e);
			}
		}
	} // END class
}
