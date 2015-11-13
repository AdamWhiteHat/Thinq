using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThinqGUI
{
	public static class TryParse
	{
		private static string NumericCharacters = "0123456789";

		public static string RemoveNonDigits(string input)
		{
			return new string(input.Where(c => NumericCharacters.Contains(c)).ToArray());
		}

		public static int Int32(string text)
		{
			int result = 0;			
			return int.TryParse(RemoveNonDigits(text), out result) ? result : 0;
		}

		public static long Int64(string text)
		{
			long result = 0;
			return long.TryParse(RemoveNonDigits(text), out result) ? result : 0;
		}

		public static ulong UInt64(string text)
		{
			ulong result = 0;
			return ulong.TryParse(RemoveNonDigits(text), out result) ? result : 0;
		}
	}

	public static class TextBoxExtensionMethods
	{
		public static int ToInt32(this TextBox thisTextBox)
		{
			return TryParse.Int32(thisTextBox.Text);
		}

		public static long ToInt64(this TextBox thisTextBox)
		{
			return TryParse.Int64(thisTextBox.Text);
		}

		public static ulong ToUInt64(this TextBox thisTextBox)
		{
			return TryParse.UInt64(thisTextBox.Text);
		}
	}
}
