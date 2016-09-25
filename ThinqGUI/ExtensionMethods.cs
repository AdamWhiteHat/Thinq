using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace ThinqGUI
{
	public static class TryParse
	{
		private static string NumericCharacters = "0123456789";

		public static string RemoveNonDigits(string input)
		{
			if (string.IsNullOrWhiteSpace(input)) return string.Empty;
			return new string(input.Where(c => NumericCharacters.Contains(c)).ToArray());
		}
	}

	public static class TextBoxExtensionMethods
	{
		public static BigInteger ToBigInteger(this TextBox thisTextBox)
		{
			if (thisTextBox == null || string.IsNullOrWhiteSpace(thisTextBox.Text)) return BigInteger.Zero;
			return BigInteger.Parse(TryParse.RemoveNonDigits(thisTextBox.Text));
		}
	}
}
