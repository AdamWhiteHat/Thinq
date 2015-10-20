using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ThinqCore
{
	public static class Settings
	{
		private static bool _isDebug;

		static Settings()
		{
			bool result = false;
#if DEBUG
			result = true;
#endif
			_isDebug = result;
		}

		public static bool IsRelease() { return !IsDebug(); }
		public static bool IsDebug()
		{
			return _isDebug;
		}
		
	}
}
