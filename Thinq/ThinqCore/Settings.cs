using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
