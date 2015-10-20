namespace ThinqGUI
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.btnEnumerate = new System.Windows.Forms.Button();
			this.tbOutput = new System.Windows.Forms.TextBox();
			this.panelOutput = new System.Windows.Forms.Panel();
			this.tbCoPrimeTo = new System.Windows.Forms.TextBox();
			this.tbCoPrimeMin = new System.Windows.Forms.TextBox();
			this.tbMax = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnCoprimes = new System.Windows.Forms.Button();
			this.listCoFactors = new System.Windows.Forms.ListBox();
			this.contextMenuCoFactors = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menuDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.label5 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.btnAddCofactor = new System.Windows.Forms.Button();
			this.tbNewCofactor = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.tbCoPrimeMax = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.groupCoprime = new System.Windows.Forms.GroupBox();
			this.groupFactors = new System.Windows.Forms.GroupBox();
			this.backgroundWorkerEnumerate = new System.ComponentModel.BackgroundWorker();
			this.panelOutput.SuspendLayout();
			this.contextMenuCoFactors.SuspendLayout();
			this.groupCoprime.SuspendLayout();
			this.groupFactors.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnEnumerate
			// 
			this.btnEnumerate.Location = new System.Drawing.Point(343, 35);
			this.btnEnumerate.Name = "btnEnumerate";
			this.btnEnumerate.Size = new System.Drawing.Size(75, 23);
			this.btnEnumerate.TabIndex = 0;
			this.btnEnumerate.Text = "Enumerate";
			this.btnEnumerate.UseVisualStyleBackColor = true;
			this.btnEnumerate.Click += new System.EventHandler(this.btnEnumerate_Click);
			// 
			// tbOutput
			// 
			this.tbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbOutput.Location = new System.Drawing.Point(14, 16);
			this.tbOutput.Multiline = true;
			this.tbOutput.Name = "tbOutput";
			this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbOutput.Size = new System.Drawing.Size(424, 163);
			this.tbOutput.TabIndex = 1;
			// 
			// panelOutput
			// 
			this.panelOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelOutput.Controls.Add(this.tbOutput);
			this.panelOutput.Location = new System.Drawing.Point(0, 188);
			this.panelOutput.Name = "panelOutput";
			this.panelOutput.Size = new System.Drawing.Size(448, 191);
			this.panelOutput.TabIndex = 2;
			// 
			// tbCoPrimeTo
			// 
			this.tbCoPrimeTo.Location = new System.Drawing.Point(117, 19);
			this.tbCoPrimeTo.Name = "tbCoPrimeTo";
			this.tbCoPrimeTo.Size = new System.Drawing.Size(60, 20);
			this.tbCoPrimeTo.TabIndex = 3;
			this.tbCoPrimeTo.Text = "7";
			this.tbCoPrimeTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// tbCoPrimeMin
			// 
			this.tbCoPrimeMin.Location = new System.Drawing.Point(191, 19);
			this.tbCoPrimeMin.Name = "tbCoPrimeMin";
			this.tbCoPrimeMin.Size = new System.Drawing.Size(60, 20);
			this.tbCoPrimeMin.TabIndex = 4;
			this.tbCoPrimeMin.Text = "8";
			this.tbCoPrimeMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// tbMax
			// 
			this.tbMax.Location = new System.Drawing.Point(252, 37);
			this.tbMax.Name = "tbMax";
			this.tbMax.Size = new System.Drawing.Size(80, 20);
			this.tbMax.TabIndex = 5;
			this.tbMax.Text = "1,000,000";
			this.tbMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(252, 60);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Max";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(118, 41);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(59, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "CoPrime to";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(183, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(105, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "Range (min / max)";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnCoprimes
			// 
			this.btnCoprimes.Location = new System.Drawing.Point(343, 17);
			this.btnCoprimes.Name = "btnCoprimes";
			this.btnCoprimes.Size = new System.Drawing.Size(75, 23);
			this.btnCoprimes.TabIndex = 13;
			this.btnCoprimes.Text = "Co-Primes";
			this.btnCoprimes.UseVisualStyleBackColor = true;
			this.btnCoprimes.Click += new System.EventHandler(this.btnCoprimes_Click);
			// 
			// listCoFactors
			// 
			this.listCoFactors.ContextMenuStrip = this.contextMenuCoFactors;
			this.listCoFactors.FormattingEnabled = true;
			this.listCoFactors.Items.AddRange(new object[] {
            "3",
            "5",
            "7",
            "11",
            "13",
            "17",
            "19"});
			this.listCoFactors.Location = new System.Drawing.Point(72, 19);
			this.listCoFactors.Name = "listCoFactors";
			this.listCoFactors.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.listCoFactors.Size = new System.Drawing.Size(60, 69);
			this.listCoFactors.TabIndex = 14;
			// 
			// contextMenuCoFactors
			// 
			this.contextMenuCoFactors.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDelete});
			this.contextMenuCoFactors.Name = "contextMenuCoFactors";
			this.contextMenuCoFactors.Size = new System.Drawing.Size(108, 26);
			// 
			// menuDelete
			// 
			this.menuDelete.Name = "menuDelete";
			this.menuDelete.Size = new System.Drawing.Size(107, 22);
			this.menuDelete.Text = "Delete";
			this.menuDelete.Click += new System.EventHandler(this.menuDelete_Click);
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(13, 19);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(27, 65);
			this.label5.TabIndex = 15;
			this.label5.Text = "∩";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label7
			// 
			this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.label7.Font = new System.Drawing.Font("Arial Narrow", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(43, 19);
			this.label7.Margin = new System.Windows.Forms.Padding(0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(26, 65);
			this.label7.TabIndex = 16;
			this.label7.Text = "(";
			// 
			// label8
			// 
			this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.label8.Font = new System.Drawing.Font("Arial Narrow", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(135, 19);
			this.label8.Margin = new System.Windows.Forms.Padding(0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(26, 65);
			this.label8.TabIndex = 17;
			this.label8.Text = ")";
			this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnAddCofactor
			// 
			this.btnAddCofactor.Location = new System.Drawing.Point(154, 53);
			this.btnAddCofactor.Name = "btnAddCofactor";
			this.btnAddCofactor.Size = new System.Drawing.Size(60, 23);
			this.btnAddCofactor.TabIndex = 18;
			this.btnAddCofactor.Text = "<-- Add";
			this.btnAddCofactor.UseVisualStyleBackColor = true;
			this.btnAddCofactor.Click += new System.EventHandler(this.btnAddCofactor_Click);
			// 
			// tbNewCofactor
			// 
			this.tbNewCofactor.Location = new System.Drawing.Point(154, 27);
			this.tbNewCofactor.Name = "tbNewCofactor";
			this.tbNewCofactor.Size = new System.Drawing.Size(60, 20);
			this.tbNewCofactor.TabIndex = 19;
			this.tbNewCofactor.Text = "23";
			this.tbNewCofactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label9
			// 
			this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.label9.Font = new System.Drawing.Font("Arial Narrow", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(217, 19);
			this.label9.Margin = new System.Windows.Forms.Padding(0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(32, 65);
			this.label9.TabIndex = 20;
			this.label9.Text = "<";
			this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// tbCoPrimeMax
			// 
			this.tbCoPrimeMax.Location = new System.Drawing.Point(268, 19);
			this.tbCoPrimeMax.Name = "tbCoPrimeMax";
			this.tbCoPrimeMax.Size = new System.Drawing.Size(60, 20);
			this.tbCoPrimeMax.TabIndex = 21;
			this.tbCoPrimeMax.Text = "48";
			this.tbCoPrimeMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(180, 23);
			this.label4.Margin = new System.Windows.Forms.Padding(0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(10, 13);
			this.label4.TabIndex = 22;
			this.label4.Text = ":";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(253, 23);
			this.label6.Margin = new System.Windows.Forms.Padding(0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(12, 13);
			this.label6.TabIndex = 23;
			this.label6.Text = "/";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupCoprime
			// 
			this.groupCoprime.Controls.Add(this.btnCoprimes);
			this.groupCoprime.Controls.Add(this.tbCoPrimeTo);
			this.groupCoprime.Controls.Add(this.label6);
			this.groupCoprime.Controls.Add(this.tbCoPrimeMin);
			this.groupCoprime.Controls.Add(this.label4);
			this.groupCoprime.Controls.Add(this.label3);
			this.groupCoprime.Controls.Add(this.tbCoPrimeMax);
			this.groupCoprime.Controls.Add(this.label2);
			this.groupCoprime.Location = new System.Drawing.Point(10, 7);
			this.groupCoprime.Name = "groupCoprime";
			this.groupCoprime.Size = new System.Drawing.Size(429, 69);
			this.groupCoprime.TabIndex = 25;
			this.groupCoprime.TabStop = false;
			this.groupCoprime.Text = "Co-Prime";
			// 
			// groupFactors
			// 
			this.groupFactors.Controls.Add(this.listCoFactors);
			this.groupFactors.Controls.Add(this.btnEnumerate);
			this.groupFactors.Controls.Add(this.tbMax);
			this.groupFactors.Controls.Add(this.label9);
			this.groupFactors.Controls.Add(this.label1);
			this.groupFactors.Controls.Add(this.tbNewCofactor);
			this.groupFactors.Controls.Add(this.label5);
			this.groupFactors.Controls.Add(this.btnAddCofactor);
			this.groupFactors.Controls.Add(this.label7);
			this.groupFactors.Controls.Add(this.label8);
			this.groupFactors.Location = new System.Drawing.Point(10, 82);
			this.groupFactors.Name = "groupFactors";
			this.groupFactors.Size = new System.Drawing.Size(429, 100);
			this.groupFactors.TabIndex = 26;
			this.groupFactors.TabStop = false;
			this.groupFactors.Text = "Common Factors";
			// 
			// backgroundWorkerEnumerate
			// 
			this.backgroundWorkerEnumerate.WorkerSupportsCancellation = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(449, 381);
			this.Controls.Add(this.groupFactors);
			this.Controls.Add(this.groupCoprime);
			this.Controls.Add(this.panelOutput);
			this.MinimumSize = new System.Drawing.Size(465, 420);
			this.Name = "MainForm";
			this.Text = "Thinq";
			this.panelOutput.ResumeLayout(false);
			this.panelOutput.PerformLayout();
			this.contextMenuCoFactors.ResumeLayout(false);
			this.groupCoprime.ResumeLayout(false);
			this.groupCoprime.PerformLayout();
			this.groupFactors.ResumeLayout(false);
			this.groupFactors.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnEnumerate;
		private System.Windows.Forms.TextBox tbOutput;
		private System.Windows.Forms.Panel panelOutput;
		private System.Windows.Forms.TextBox tbCoPrimeTo;
		private System.Windows.Forms.TextBox tbCoPrimeMin;
		private System.Windows.Forms.TextBox tbMax;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnCoprimes;
		private System.Windows.Forms.ListBox listCoFactors;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button btnAddCofactor;
		private System.Windows.Forms.TextBox tbNewCofactor;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox tbCoPrimeMax;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ContextMenuStrip contextMenuCoFactors;
		private System.Windows.Forms.ToolStripMenuItem menuDelete;
		private System.Windows.Forms.GroupBox groupCoprime;
		private System.Windows.Forms.GroupBox groupFactors;
		private System.ComponentModel.BackgroundWorker backgroundWorkerEnumerate;
	}
}

