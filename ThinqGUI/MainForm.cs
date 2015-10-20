using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;

using ThinqCore;

namespace ThinqGUI
{
	public partial class MainForm : Form
	{
		Intersection intersectionSet;

		public int Max { get { return GetValue(tbMax); } }
		List<int> CoFactors { get { return listCoFactors.Items.Cast<string>().Select(s => ParseString(s)).ToList(); } }
		
		protected static string numeric = "0123456789";

		public MainForm()
		{
			InitializeComponent();
		}

		protected static int ParseString(string text)
		{
			int result = -1;
			string sanitized = new string(text.Where(c => numeric.Contains(c)).ToArray());
			return int.TryParse(sanitized, out result) ? result : -1;
		}

		protected int GetValue(TextBox textBox)
		{
			return ParseString(textBox.Text);
		}

		private void btnCoprimes_Click(object sender, EventArgs e)
		{
			int coprimeTO = GetValue(tbCoPrimeTo);
			int coprimeMIN = GetValue(tbCoPrimeMin);
			int coprimeMAX = GetValue(tbCoPrimeMax);

			List<int> coprimes = Coprimes.FindCoprimes(coprimeTO, coprimeMIN, coprimeMAX);
			string joinedCoprimes = "(Found no results)";

			if (coprimes != null && coprimes.Count > 0)
			{
				joinedCoprimes = string.Join(Environment.NewLine, coprimes);
			}

			tbOutput.Text = string.Join(Environment.NewLine,
						string.Format("Co-primes: {0}", coprimes.Count),
						joinedCoprimes
					);			
		}

		private void btnEnumerate_Click(object sender, EventArgs e)
		{
			tbOutput.Text = string.Empty;
			Console.Clear();
			FindFactorsFromListBox();
		}

		private void SetControlsStatus(bool IsEnabled)
		{
			groupCoprime.Enabled = IsEnabled;
			groupFactors.Enabled = IsEnabled;
			btnEnumerate.Enabled = IsEnabled;
		}

		private void FindFactorsFromListBox()
		{
			if (CoFactors.Any(i => i < 1) || Max < 1)
			{
				return;
			}			

			backgroundWorkerEnumerate.DoWork += backgroundWorkerEnumerate_DoWork;
			backgroundWorkerEnumerate.RunWorkerCompleted += backgroundWorkerEnumerate_RunWorkerCompleted;

			SetControlsStatus(false);

			backgroundWorkerEnumerate.RunWorkerAsync();
		}

		void backgroundWorkerEnumerate_DoWork(object sender, DoWorkEventArgs e)
		{
			backgroundWorkerEnumerate.DoWork -= backgroundWorkerEnumerate_DoWork;
			DisplayArithmeticSequence();
		}

		void backgroundWorkerEnumerate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			SetControlsStatus(true);
		}

		private void DisplayArithmeticSequence()
		{
			DateTime startTime = DateTime.Now;

			intersectionSet = new Intersection(Max, CoFactors.ToArray());
			List<int> factors = intersectionSet.Finalize().ToList();

			TimeSpan timeSpent = DateTime.Now.Subtract(startTime);

			if (tbOutput.InvokeRequired)
			{
				tbOutput.Invoke(new MethodInvoker(() =>
					tbOutput.Text = string.Join(Environment.NewLine,
							string.Format("Factors: {0}", factors.Count),
							string.Format("Time elapsed: {0}", timeSpent.ToString(@"mm\:ss\.ff")),
							string.Join(Environment.NewLine, factors)
					)					
				));
			}
			else
			{
				tbOutput.Text = string.Join(Environment.NewLine,
					string.Format("Factors: {0}", factors.Count),
					string.Format("Time elapsed: {0}", timeSpent.ToString(@"mm\:ss\.ff")),
					string.Join(Environment.NewLine, factors)
				);
			}
		}

		private void btnAddCofactor_Click(object sender, EventArgs e)
		{
			int newCofactor = GetValue(tbNewCofactor);
			if (newCofactor > 0)
			{
				if (intersectionSet == null)
				{
				}
				tbNewCofactor.Text = string.Empty;
				listCoFactors.Items.Add(newCofactor.ToString());
				FindFactorsFromListBox();
			}
		}

		private void menuDelete_Click(object sender, EventArgs e)
		{
			List<object> selectedItems = listCoFactors.SelectedItems.OfType<object>().ToList();

			foreach(object item in selectedItems)
			{
				listCoFactors.Items.Remove(item);
			}
		}

	}
}
