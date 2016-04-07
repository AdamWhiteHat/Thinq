
namespace ThinqCore
{
	public static class Settings
	{
		public static bool IsReleaseBuild { get { return !_isDebugAssembly; } }
		public static bool IsDebugBuild { get { return _isDebugAssembly; } }
		private static bool _isDebugAssembly;

		static Settings()
		{
			bool debugFlag = false;
#if DEBUG
			debugFlag = true;
#endif
			_isDebugAssembly = debugFlag;
		}
	}
}
