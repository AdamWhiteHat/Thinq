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
		#region Public Properties & Events

		/// <summary>
		/// Gets a value indicating whether the AsyncBackgroundTask is running an asynchronous operation.
		/// </summary>
		public bool IsBusy { get; private set; }

		/// <summary>
		/// Gets a value indicating whether the Dispose() method has been called.
		/// </summary>
		public bool IsDisposed { get; private set; }

		/// <summary>
		/// Gets a value indicating whether the application has requested cancellation of a background operation.
		/// </summary>
		public bool CancellationPending { get; private set; }

		/// <summary>
		/// Gets a value indicating whether the AsyncBackgroundTask class supports cancellation of a background operation. This value always returns true.
		/// </summary>
		public bool WorkerSupportsCancellation { get { return true; } }
		
		/// <summary>
		/// Occurs when AsyncBackgroundTask.RunWorkerAsync() is called.
		/// </summary>		
		public event DoWorkEventHandler DoWork
		{
			add { if (!IsDisposed) { _backgroundWorker.DoWork += value; } }
			remove { if (!IsDisposed) { _backgroundWorker.DoWork -= value; } }
		}

		/// <summary>
		/// Occurs when the background operation has completed, has been canceled, or has raised an exception.
		/// </summary>
		public event RunWorkerCompletedEventHandler RunWorkerCompleted
		{
			add {  if (!IsDisposed) { _backgroundWorker.RunWorkerCompleted += value; } }
			remove {  if (!IsDisposed) { _backgroundWorker.RunWorkerCompleted -= value; } }
		}

		#endregion

		#region Private Fields & Classes

		private Stats _operationStats = null;
		private Intersection _intersectionSet = null;
		private BackgroundWorker _backgroundWorker = null;

		private class Stats
		{
			public ulong Counter { get; internal set; }
			public TimeSpan ProcessingTime { get; internal set; }
			public Stats() { ProcessingTime = TimeSpan.Zero; }
		}

		#endregion

		#region Public Methods

		#region Constructor

		/// <summary>
		///  Initializes a new instance of the AsyncBackgroundTask class.
		/// </summary>		
		public AsyncBackgroundTask(MainForm mainForm)
		{
			_operationStats = new Stats();
			_backgroundWorker = new BackgroundWorker();

			IsBusy = false;
			IsDisposed = false;
			CancellationPending = false;			
		}

		#endregion

		/// <summary>
		/// Starts execution of a background operation.
		/// </summary>
		/// <returns>True if a new background operation was started, or false if a background operation was already running, was pending cancellation, or the object was disposed.</returns>
		public bool RunWorkerAsync()
		{
			if (!CancellationPending && !IsBusy && !IsDisposed)
			{
				IsBusy = true;
				this.DoWork += BeginDoWork;
				_backgroundWorker.RunWorkerAsync();
				return true;
			}
			return false;
		}

		/// <summary>
		/// Requests cancellation of a pending background operation.
		/// </summary>
		/// <returns>True if the background worker was running and a cancellation request was sent, or false if no background operations were running, the operation had already been canceled, or the object was disposed.</returns>
		public bool CancelAsync()
		{
			if (IsBusy && !CancellationPending && !IsDisposed)
			{
				CancellationPending = true;
				if (_intersectionSet != null)
				{
					_intersectionSet.CancelAsync();
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Releases all resources used by the class.
		/// </summary>
		public void Dispose()
		{
			if (!IsDisposed)
			{
				IsDisposed = true;
				if (_intersectionSet != null)
				{
					if (!_intersectionSet.IsDisposed)
					{
						_intersectionSet.Dispose();
					}
					_intersectionSet = null;
				}

				if (_backgroundWorker != null)
				{
					_backgroundWorker.Dispose();
					_backgroundWorker = null;
				}

				if (_operationStats != null)
				{
					_operationStats = null;
				}
			}
		}

		#endregion

		#region Private Methods

		private void BeginDoWork(object sender, DoWorkEventArgs e)
		{
			this.DoWork -= BeginDoWork;
			if (IsBusy && !CancellationPending && !IsDisposed)
			{
				this.RunWorkerCompleted += BeginWorkerCompleted;
				CalculateIntersectionSet();
			}
		}

		private void BeginWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.RunWorkerCompleted -= BeginWorkerCompleted;
			Program.ThinqMainForm.SetControlsStatus(true);
			if (CancellationPending)
			{
				Program.DisplayFunction("Task Canceled");
			}
			IsBusy = false;
		}
		
		private void CalculateIntersectionSet()
		{
			if (!IsDisposed && !CancellationPending && _intersectionSet == null)
			{
				DateTime startTime = DateTime.Now;
				ulong minValue = Program.ThinqMainForm.ResultMinValue;
				ulong maxValue = Program.ThinqMainForm.ResultMaxValue;
				ulong maxQuantity = Program.ThinqMainForm.ResultMaxQuantity;
				int padLen = maxValue.ToString().Length;
				ulong[] cofactors = Program.ThinqMainForm.CoFactors.ToArray();

				try
				{
					_operationStats.Counter = 0;
					_intersectionSet = new Intersection(minValue, maxValue, cofactors, maxQuantity);
					foreach (ulong factor in _intersectionSet.GetEnumerable())
					{
						_operationStats.Counter++;
						Program.DisplayFunction(string.Concat("{0,", padLen.ToString(), "}"), factor);

						if (CancellationPending)
						{
							break;
						}
					}
				}
				finally
				{
					_operationStats.ProcessingTime = DateTime.Now.Subtract(startTime);

					StringBuilder strBldr = new StringBuilder();
					strBldr.AppendLine("-------------------------------");
					strBldr.AppendFormat("Max: {0:n0}", maxValue).AppendLine();
					strBldr.AppendFormat("LCM[{0}]", string.Join(",", cofactors)).AppendLine();
					strBldr.AppendFormat("Factors found: {0}", _operationStats.Counter).AppendLine();
					strBldr.AppendFormat("Time elapsed: {0}", _operationStats.ProcessingTime.ToString(@"mm\:ss\.ff"));

					Program.DisplayFunction(strBldr.ToString());
				}
			}
		}

		#endregion
	}
}
