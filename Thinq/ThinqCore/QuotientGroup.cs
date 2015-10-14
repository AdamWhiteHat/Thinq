using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinqCore
{
	public class QuotientGroup
	{
		private int _root;
		private int _max;
		private int _counter;

		public QuotientGroup(int root, int max)
		{
			if (root < 1) { throw new ArgumentOutOfRangeException("root"); }
			if (max < 1) { throw new ArgumentOutOfRangeException("max"); }
			_root = root;
			_max = max;
			_counter = 0;
		}

		public IEnumerable<int> GetNextQuotient()
		{
			while (_counter < _max)
			{
				_counter += _root;
				yield return _counter;
			}
		}

	} // END class QuotientGroup
}
