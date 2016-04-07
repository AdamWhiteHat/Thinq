using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using ThinqCore;

namespace ThinqGUI
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		public void SetControlsStatus(bool IsEnabled)
		{
			groupCoprime.Enabled = IsEnabled;
			panelFactors.Enabled = IsEnabled;
			btnEnumerateCoFactors.Enabled = IsEnabled;
			if (IsEnabled)
			{
				if (btnCancelEnumerateCoFactors.Enabled == false)
				{
					btnCancelEnumerateCoFactors.Enabled = true;
				}
			}
			else
			{
				btnCancelEnumerateCoFactors.Visible = true;
			}
		}

		#region CoPrime Enumeration

		public int CoprimeTo { get { return tbCoPrimeTo.ToInt32(); } }
		public int CoprimeMin { get { return tbCoPrimeMin.ToInt32(); } }
		public int CoprimeMax { get { return tbCoPrimeMax.ToInt32(); } }

		private void btnCoprimes_Click(object sender, EventArgs e)
		{
			Coprimes coprimeFinder = new Coprimes(CoprimeTo, CoprimeMin, CoprimeMax);
			List<int> coPrimes = coprimeFinder.GetCoprimes().ToList();
			string joinedCoprimes = string.Join(Environment.NewLine, coPrimes);

			StringBuilder resultString = new StringBuilder();
			resultString.AppendFormat("Total # of co-primes found in range: {0}", coPrimes.Count);
			resultString.AppendLine();
			resultString.Append(joinedCoprimes);

			tbOutput.Clear();
			DisplayOutput(resultString.ToString());
			tbOutput.Select(0, 0);
			tbOutput.ScrollToCaret();
		}

		#endregion

		#region CoFactor Enumeration

		public ulong ResultMinValue { get { return tbResultMinValue.ToUInt64(); } }
		public ulong ResultMaxValue { get { return tbResultMaxValue.ToUInt64(); } }
		public ulong ResultMaxQuantity { get { return tbResultMaxQuantity.ToUInt64(); } }
		public List<ulong> CoFactors { get { return listCoFactors.Items.Cast<string>().Select(s => TryParse.UInt64(s)).ToList(); } }

		private AsyncBackgroundTask backgroundTask = null;

		private void btnEnumerateCoFactors_Click(object sender, EventArgs e)
		{
			Console.Clear();
			tbOutput.Clear();
			EnumerateCoFactors();
		}

		private void btnCancelEnumerateCoFactors_Click(object sender, EventArgs e)
		{
			if (backgroundTask.CancelAsync())
			{
				btnCancelEnumerateCoFactors.Enabled = false;
			}
		}

		private void EnumerateCoFactors()
		{
			if (CoFactors.Count < 1
				|| CoFactors.Any(i => i < 2)
				//|| CoFactors.Any(i => i < CoFactorMin)
				|| CoFactors.Any(i => i > ResultMaxValue)
				|| ResultMinValue >= ResultMaxValue
				|| ResultMinValue < 2
				|| ResultMaxValue < 2)
			{
				return;
			}

			if (backgroundTask != null)
			{
				if (!backgroundTask.IsDisposed)
				{
					if (backgroundTask.IsBusy)
					{
						return;
					}
					backgroundTask.Dispose();
				}
				backgroundTask = null;
			}

			backgroundTask = new AsyncBackgroundTask(this);
			if (backgroundTask != null)
			{
				SetControlsStatus(false);
				backgroundTask.RunWorkerAsync();
			}
		}

		private void btnAddCoFactor_Click(object sender, EventArgs e)
		{
			AddNewCoFactor();
		}

		private void tbCoFactorAdd_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
			{
				AddNewCoFactor();
			}
		}

		private void listCoFactors_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete)
			{
				RemoveSelectedCoFactors();
			}
		}

		private void listCoFactors_menuDelete_Click(object sender, EventArgs e)
		{
			RemoveSelectedCoFactors();
		}

		private void AddNewCoFactor()
		{
			ulong newCofactor = tbCoFactorAdd.ToUInt64();
			if (newCofactor > 1 && !CoFactors.Contains(newCofactor))
			{
				tbCoFactorAdd.Text = string.Empty;
				listCoFactors.Items.Add(newCofactor.ToString()); //FindFactorsFromListBox();
				tbCoFactorAdd.Select(); // Put the cursor back in the TextBox to smooth experience for adding another number
			}
		}

		private void RemoveSelectedCoFactors()
		{
			int lastIndex = -1;
			List<object> selectedListItems = listCoFactors.SelectedItems.OfType<object>().ToList();
			foreach (object item in selectedListItems)
			{
				lastIndex = listCoFactors.Items.IndexOf(item);
				listCoFactors.Items.Remove(item);
			}

			// Limit lastIndex to within range
			if (lastIndex > listCoFactors.Items.Count - 1)
			{
				lastIndex = listCoFactors.Items.Count - 1;
			}

			// Check for valid lastIndex
			if (lastIndex > -1)
			{
				// Highlight next item after deleted item. This creates a smoother keyboard experience
				listCoFactors.SetSelected(lastIndex, true);
			}
		}

		#endregion

		#region Output TextBox

		public void DisplayOutput(string format, params object[] args)
		{
			if (tbOutput.InvokeRequired)
			{
				tbOutput.Invoke(new MethodInvoker(() => DisplayOutput(format, args)));
			}
			else
			{
				StringBuilder newText = new StringBuilder();
				if (!string.IsNullOrEmpty(format))
				{
					if (args == null || args.Length < 1)
					{
						newText.Append(format);
					}
					else
					{
						newText.AppendFormat(format, args);
					}
				}
				newText.AppendLine(); //if (!newText.ToString().EndsWith(Environment.NewLine))
				tbOutput.AppendText(newText.ToString());
			}
		}

		private void tbOutput_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.Control)
			{
				if (e.KeyCode == Keys.A) // CTRL + A, Select all
				{
					tbOutput.SelectAll();
				}
				else if (e.KeyCode == Keys.S) // CTRL + S, Save as
				{
					using (SaveFileDialog saveFileDialog = new SaveFileDialog())
					{
						if (saveFileDialog.ShowDialog() == DialogResult.OK)
						{
							string filename = saveFileDialog.FileName;
							File.WriteAllLines(filename, tbOutput.Lines);
						}
					}
				}
			}
		}

		#endregion

		private void btnEnumerateGCD_Click(object sender, EventArgs e)
		{
			IEnumerable<int> numbers = CoFactors.Select(l => (int)l);
			DisplayOutput("FindGCD[{0}]:", string.Join(", ", numbers));
			DisplayOutput("{0}", Coprimes.FindGCD(numbers));
			DisplayOutput("");
			//ApplyOperationToValues(Coprimes.FindGCD, CoFactors.Select(l => (int)l).ToList());
		}

		private void btnEnumerateLCM_Click(object sender, EventArgs e)
		{
			ApplyOperationToValues(Coprimes.FindLCM, CoFactors.Select(l => (int)l).ToList());
		}

		private void ApplyOperationToValues(Coprimes.BinaryOperationDelegate operation, List<int> values, bool useAnswers = true)
		{
			int lastValue = values.First();			
			List<int> inputValues = values.Except(new int[] { lastValue }).ToList();			
			Coprimes.BinaryOperationDelegate operationFunction = operation;

			List<int> results = new List<int>();
			foreach (int number in inputValues)
			{
				int answer = operationFunction.Invoke(lastValue, number);
				results.Add(answer);

				lastValue = useAnswers ? answer : number;
			}

			DisplayOutput("{0}[{1}]: ({2} results)", operationFunction.Method.Name, string.Join(", ", values), results.Count);
			DisplayOutput(string.Join(Environment.NewLine, results));
			DisplayOutput("");
		}
	}
}
