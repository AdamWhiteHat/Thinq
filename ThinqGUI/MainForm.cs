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
		// Factors
		public ulong StartValue { get { return tbMin.ToUInt64(); } }
		public ulong MultipleMax { get { return tbMax.ToUInt64(); } }
		public List<ulong> CoFactors { get { return listCoFactors.Items.Cast<string>().Select(s => TryParse.UInt64(s)).ToList(); } }

		// Co-primes
		public int CoprimeOf { get { return  tbCoPrimeOf.ToInt32(); } }
		public int CoprimeMin { get { return tbCoPrimeMin.ToInt32(); } }
		public int CoprimeMax { get { return tbCoPrimeMax.ToInt32(); } }

		private AsyncBackgroundTask backgroundTask;

		public MainForm()
		{
			InitializeComponent();			
			tbOutput.ShortcutsEnabled = true;
		}

		private void btnCoprimes_Click(object sender, EventArgs e)
		{
			Coprimes coprimeFinder = new Coprimes(CoprimeOf, CoprimeMin, CoprimeMax);

			string joinedCoprimes = string.Join(Environment.NewLine, coprimeFinder.GetCoprimes());		

			tbOutput.Text = string.Join(Environment.NewLine,
						string.Format("Co-primes found: {0}", joinedCoprimes.Count(c => c == '\n')+1),
						joinedCoprimes
					);
		}

		private void btnEnumerate_Click(object sender, EventArgs e)
		{
			Console.Clear();
			tbOutput.Text = string.Empty;
			FindFactorsFromListBox();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			backgroundTask.CancelAsync();
			btnCancel.Enabled = false;
		}
		
		private void FindFactorsFromListBox()
		{
			if (CoFactors.Any(i => i < 1) || MultipleMax < 1)
			{
				return;
			}

			if (backgroundTask != null)
			{
				backgroundTask.Dispose();
				backgroundTask = null;
			}

			backgroundTask = new AsyncBackgroundTask(this);
			if (backgroundTask != null)
			{
				SetControlsStatus(false);
				backgroundTask.RunWorkerAsync();
			}
		}

		public void SetControlsStatus(bool IsEnabled)
		{
			groupCoprime.Enabled = IsEnabled;
			panelFactors.Enabled = IsEnabled;
			btnEnumerate.Enabled = IsEnabled;
			if (IsEnabled)
			{
				if (btnCancel.Enabled == false)
				{ 
					btnCancel.Enabled = true;
				}
			}
			else
			{
				btnCancel.Visible = true; 
			}
		}

		public void DisplayOutput(string format, params object[] args)
		{
			DisplayOutput(false, format, args);
		}

		public void DisplayOutput(bool onTop, string format, params object[] args)
		{
			if (tbOutput.InvokeRequired)
			{	
				tbOutput.Invoke(new MethodInvoker(() => DisplayOutput(onTop, format, args)));	
			}
			else
			{
				if (onTop)
				{
					tbOutput.Text = string.Concat(string.Format(format, args), Environment.NewLine, tbOutput.Text);
				}
				else
				{
					tbOutput.Text += string.Concat(string.Format(format, args), Environment.NewLine);
					tbOutput.Select(tbOutput.TextLength, 0);
					tbOutput.ScrollToCaret();
				}
			}
		}

		private void btnAddCofactor_Click(object sender, EventArgs e)
		{
			ulong newCofactor = tbAddCofactor.ToUInt64();
			if (newCofactor > 0)
			{
				tbAddCofactor.Text = string.Empty;
				listCoFactors.Items.Add(newCofactor.ToString()); //FindFactorsFromListBox();
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

		private void btnTest_Click(object sender, EventArgs e)
		{
			string result = SerializableExpressionTree.GenerateMathExpressionTree();
			result = "Result: " + result;
			tbOutput.Text = result;
		}
	}
}
