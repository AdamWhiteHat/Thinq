using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThinqCore;

namespace ThinqGUI
{
	public class AsyncBackgroundTask : IDisposable
	{
		BackgroundWorker _backgroundWorker;

		internal Stats ArithmeticSequenceStats { get; private set; }
		public Intersection IntersectionSet { get; private set; }

		public bool IsDisposed { get; private set; }
		public bool IsBusy { get; private set; }
		public bool CancellationPending { get; private set; }
		public bool WorkerReportsProgress { get { return true; } }
		public bool WorkerSupportsCancellation { get { return true; } }

		public event DoWorkEventHandler DoWork 
		{
			add { if (!IsDisposed) { _backgroundWorker.DoWork += value; } }
			remove { if (!IsDisposed) { _backgroundWorker.DoWork -= value; } }
		}

		public event RunWorkerCompletedEventHandler RunWorkerCompleted
		{
			add {  if (!IsDisposed) { _backgroundWorker.RunWorkerCompleted += value; } }
			remove {  if (!IsDisposed) { _backgroundWorker.RunWorkerCompleted -= value; } }
		}

		public AsyncBackgroundTask(MainForm mainForm)
		{
			_backgroundWorker = new BackgroundWorker();

			IsBusy = false;
			IsDisposed = false;
			CancellationPending = false;			
			ArithmeticSequenceStats = new Stats();			
		}

		public void RunWorkerAsync()
		{
			if (!CancellationPending && !IsBusy && !IsDisposed)
			{
				IsBusy = true;
				this.DoWork += doWork;				
				_backgroundWorker.RunWorkerAsync();				
			}
		}

		public void CancelAsync()
		{
			if (IsBusy && !CancellationPending && !IsDisposed)
			{
				CancellationPending = true;
			}
		}

		public void Dispose()
		{
			if (!IsDisposed)
			{
				IsDisposed = true;
				if (IntersectionSet != null)
				{
					IntersectionSet.Dispose();
					IntersectionSet = null;
				}

				if (_backgroundWorker != null)
				{
					_backgroundWorker.Dispose();
					_backgroundWorker = null;
				}

				if (ArithmeticSequenceStats != null)
				{
					ArithmeticSequenceStats = null;
				}
			}
		}

		#region Private Methods
		//
		// Private Methods
		//
		private void doWork(object sender, DoWorkEventArgs e)
		{
			this.DoWork -= doWork;
			if (!CancellationPending && !IsDisposed)
			{
				this.RunWorkerCompleted += runWorkerCompleted;				
				calculateIntersectionSet();
			}
		}

		private void runWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.RunWorkerCompleted -= runWorkerCompleted;
			Program.ThinqMainForm.SetControlsStatus(true);
			if (CancellationPending == true)
			{
				Program.DisplayFunction("Task Canceled");
			}
			IsBusy = false;
		}
		
		private void calculateIntersectionSet()
		{
			if (!IsDisposed)
			{
				DateTime startTime = DateTime.Now;
				ulong minValue = Program.ThinqMainForm.StartValue;
				ulong maxValue = Program.ThinqMainForm.MultipleMax;
				int padLen = maxValue.ToString().Length;
				ulong[] cofactors = Program.ThinqMainForm.CoFactors.ToArray();

				try
				{
					ArithmeticSequenceStats.Counter = 0;
					IntersectionSet = new Intersection(minValue, maxValue, cofactors);
					foreach (ulong factor in IntersectionSet.GetEnumerable())
					{
						ArithmeticSequenceStats.Counter++;
						Program.DisplayFunction(string.Concat("{0,", padLen.ToString(), "}"), factor);

						if (CancellationPending)
						{
							break;
						}
					}
				}
				finally
				{
					ArithmeticSequenceStats.ProcessingTime = DateTime.Now.Subtract(startTime);

					StringBuilder strBldr = new StringBuilder(Environment.NewLine);
					strBldr.AppendFormat("Max: {0:n0}", maxValue).AppendLine();
					strBldr.AppendFormat("LCM[{0}]", string.Join(",", cofactors)); strBldr.AppendLine();
					strBldr.AppendFormat("Factors found: {0}", ArithmeticSequenceStats.Counter); strBldr.AppendLine();
					strBldr.AppendFormat("Time elapsed: {0}", ArithmeticSequenceStats.ProcessingTime.ToString(@"mm\:ss\.ff")); strBldr.AppendLine();
					strBldr.AppendLine("-");
					Program.DisplayFunction2(true, strBldr.ToString());
					Program.DisplayFunction("-------------------------------");
				}
			}
		}

		internal class Stats
		{
			public ulong Counter { get; internal set; }
			public TimeSpan ProcessingTime { get; internal set; }
			public Stats() { ProcessingTime = TimeSpan.Zero; }
		}

		#endregion

	}
}
