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
		internal delegate void DisplayOutputDelegate(string format, params object[] args);

		static Program()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			ThinqMainForm = new MainForm();
			DisplayFunction = ThinqMainForm.DisplayOutput;
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
