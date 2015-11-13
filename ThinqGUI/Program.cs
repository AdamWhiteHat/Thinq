using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ThinqGUI
{
	internal static class Program
	{
		internal static MainForm ThinqMainForm;
		internal static DisplayOutputDelegate DisplayFunction;
		internal static DisplayOutputDelegate2 DisplayFunction2;

		internal delegate void DisplayOutputDelegate(string format, params object[] args);
		internal delegate void DisplayOutputDelegate2(bool onTop, string format, params object[] args);

		static Program()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			ThinqMainForm = new MainForm();
			DisplayFunction = ThinqMainForm.DisplayOutput;
			DisplayFunction2 = ThinqMainForm.DisplayOutput;
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.Run(ThinqMainForm);
		}
	}
}
