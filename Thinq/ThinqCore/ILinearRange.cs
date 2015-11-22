using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinqCore
{
	interface ILinearRange
	{
		long Max { get; }
		long Min { get; }
		//long Length { get; }
		bool IsIn(long value);
		bool IsIn(ILinearRange range);
	}
}
