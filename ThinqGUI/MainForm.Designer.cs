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
				if (backgroundTask != null)
				{
					backgroundTask.Dispose();
				}
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
			this.tbOutput = new System.Windows.Forms.TextBox();
			this.panelOutput = new System.Windows.Forms.Panel();
			this.tbCoPrimeTo = new System.Windows.Forms.TextBox();
			this.tbCoPrimeMin = new System.Windows.Forms.TextBox();
			this.tbCoFactorMax = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnEnumerateCoprimes = new System.Windows.Forms.Button();
			this.listCoFactors = new System.Windows.Forms.ListBox();
			this.contextMenuCoFactors = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menuDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.label5 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.btnAddCofactor = new System.Windows.Forms.Button();
			this.tbCoFactorAdd = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.tbCoPrimeMax = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.groupCoprime = new System.Windows.Forms.GroupBox();
			this.groupFactors = new System.Windows.Forms.GroupBox();
			this.btnEnumerateCoFactors = new System.Windows.Forms.Button();
			this.btnCancelEnumerateCoFactors = new System.Windows.Forms.Button();
			this.panelFactors = new System.Windows.Forms.Panel();
			this.tbCoFactorMin = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.panelOutput.SuspendLayout();
			this.contextMenuCoFactors.SuspendLayout();
			this.groupCoprime.SuspendLayout();
			this.groupFactors.SuspendLayout();
			this.panelFactors.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbOutput
			// 
			this.tbOutput.AcceptsReturn = true;
			this.tbOutput.AcceptsTab = true;
			this.tbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbOutput.Location = new System.Drawing.Point(3, 4);
			this.tbOutput.Margin = new System.Windows.Forms.Padding(4);
			this.tbOutput.Multiline = true;
			this.tbOutput.Name = "tbOutput";
			this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbOutput.Size = new System.Drawing.Size(497, 189);
			this.tbOutput.TabIndex = 0;
			this.tbOutput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbOutput_KeyUp);
			// 
			// panelOutput
			// 
			this.panelOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelOutput.Controls.Add(this.tbOutput);
			this.panelOutput.Location = new System.Drawing.Point(0, 183);
			this.panelOutput.Name = "panelOutput";
			this.panelOutput.Size = new System.Drawing.Size(503, 196);
			this.panelOutput.TabIndex = 2;
			// 
			// tbCoPrimeTo
			// 
			this.tbCoPrimeTo.Location = new System.Drawing.Point(159, 20);
			this.tbCoPrimeTo.Name = "tbCoPrimeTo";
			this.tbCoPrimeTo.Size = new System.Drawing.Size(60, 20);
			this.tbCoPrimeTo.TabIndex = 0;
			this.tbCoPrimeTo.Text = "7";
			this.tbCoPrimeTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// tbCoPrimeMin
			// 
			this.tbCoPrimeMin.Location = new System.Drawing.Point(233, 20);
			this.tbCoPrimeMin.Name = "tbCoPrimeMin";
			this.tbCoPrimeMin.Size = new System.Drawing.Size(60, 20);
			this.tbCoPrimeMin.TabIndex = 1;
			this.tbCoPrimeMin.Text = "8";
			this.tbCoPrimeMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// tbCoFactorMax
			// 
			this.tbCoFactorMax.Location = new System.Drawing.Point(247, 39);
			this.tbCoFactorMax.Name = "tbCoFactorMax";
			this.tbCoFactorMax.Size = new System.Drawing.Size(149, 20);
			this.tbCoFactorMax.TabIndex = 3;
			this.tbCoFactorMax.Text = "100,000,000";
			this.tbCoFactorMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(247, 60);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(149, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Max value";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(160, 42);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(59, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "CoPrime to";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(233, 42);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(137, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "Range (min / max)";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnEnumerateCoprimes
			// 
			this.btnEnumerateCoprimes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEnumerateCoprimes.Location = new System.Drawing.Point(393, 17);
			this.btnEnumerateCoprimes.Name = "btnEnumerateCoprimes";
			this.btnEnumerateCoprimes.Size = new System.Drawing.Size(97, 23);
			this.btnEnumerateCoprimes.TabIndex = 3;
			this.btnEnumerateCoprimes.Text = "List Co-Primes";
			this.btnEnumerateCoprimes.UseVisualStyleBackColor = true;
			this.btnEnumerateCoprimes.Click += new System.EventHandler(this.btnCoprimes_Click);
			// 
			// listCoFactors
			// 
			this.listCoFactors.ContextMenuStrip = this.contextMenuCoFactors;
			this.listCoFactors.FormattingEnabled = true;
			this.listCoFactors.Items.AddRange(new object[] {
            "3",
            "7",
            "11",
            "13",
            "17",
            "19"});
			this.listCoFactors.Location = new System.Drawing.Point(63, 3);
			this.listCoFactors.Name = "listCoFactors";
			this.listCoFactors.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.listCoFactors.Size = new System.Drawing.Size(60, 69);
			this.listCoFactors.TabIndex = 0;
			this.listCoFactors.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listCoFactors_KeyUp);
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
			this.menuDelete.Click += new System.EventHandler(this.listCoFactors_menuDelete_Click);
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(4, 3);
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
			this.label7.Location = new System.Drawing.Point(34, 3);
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
			this.label8.Location = new System.Drawing.Point(126, 3);
			this.label8.Margin = new System.Windows.Forms.Padding(0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(26, 65);
			this.label8.TabIndex = 17;
			this.label8.Text = ")";
			this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnAddCofactor
			// 
			this.btnAddCofactor.Location = new System.Drawing.Point(153, 37);
			this.btnAddCofactor.Name = "btnAddCofactor";
			this.btnAddCofactor.Size = new System.Drawing.Size(60, 23);
			this.btnAddCofactor.TabIndex = 2;
			this.btnAddCofactor.Text = "<-- Add";
			this.btnAddCofactor.UseVisualStyleBackColor = true;
			this.btnAddCofactor.Click += new System.EventHandler(this.btnAddCoFactor_Click);
			// 
			// tbCoFactorAdd
			// 
			this.tbCoFactorAdd.Location = new System.Drawing.Point(153, 11);
			this.tbCoFactorAdd.Name = "tbCoFactorAdd";
			this.tbCoFactorAdd.Size = new System.Drawing.Size(60, 20);
			this.tbCoFactorAdd.TabIndex = 1;
			this.tbCoFactorAdd.Text = "23";
			this.tbCoFactorAdd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tbCoFactorAdd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbCoFactorAdd_KeyUp);
			// 
			// label9
			// 
			this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.label9.Font = new System.Drawing.Font("Arial Narrow", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(214, 3);
			this.label9.Margin = new System.Windows.Forms.Padding(0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(32, 65);
			this.label9.TabIndex = 20;
			this.label9.Text = "<";
			this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// tbCoPrimeMax
			// 
			this.tbCoPrimeMax.Location = new System.Drawing.Point(310, 20);
			this.tbCoPrimeMax.Name = "tbCoPrimeMax";
			this.tbCoPrimeMax.Size = new System.Drawing.Size(60, 20);
			this.tbCoPrimeMax.TabIndex = 2;
			this.tbCoPrimeMax.Text = "48";
			this.tbCoPrimeMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(222, 24);
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
			this.label6.Location = new System.Drawing.Point(295, 24);
			this.label6.Margin = new System.Windows.Forms.Padding(0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(12, 13);
			this.label6.TabIndex = 23;
			this.label6.Text = "/";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupCoprime
			// 
			this.groupCoprime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupCoprime.Controls.Add(this.btnEnumerateCoprimes);
			this.groupCoprime.Controls.Add(this.tbCoPrimeTo);
			this.groupCoprime.Controls.Add(this.label6);
			this.groupCoprime.Controls.Add(this.tbCoPrimeMin);
			this.groupCoprime.Controls.Add(this.label4);
			this.groupCoprime.Controls.Add(this.label3);
			this.groupCoprime.Controls.Add(this.tbCoPrimeMax);
			this.groupCoprime.Controls.Add(this.label2);
			this.groupCoprime.Location = new System.Drawing.Point(4, 4);
			this.groupCoprime.Name = "groupCoprime";
			this.groupCoprime.Size = new System.Drawing.Size(496, 67);
			this.groupCoprime.TabIndex = 25;
			this.groupCoprime.TabStop = false;
			this.groupCoprime.Text = "Co-Prime";
			// 
			// groupFactors
			// 
			this.groupFactors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupFactors.Controls.Add(this.btnEnumerateCoFactors);
			this.groupFactors.Controls.Add(this.btnCancelEnumerateCoFactors);
			this.groupFactors.Controls.Add(this.panelFactors);
			this.groupFactors.Location = new System.Drawing.Point(4, 77);
			this.groupFactors.Name = "groupFactors";
			this.groupFactors.Size = new System.Drawing.Size(496, 100);
			this.groupFactors.TabIndex = 26;
			this.groupFactors.TabStop = false;
			this.groupFactors.Text = "Common Factors";
			// 
			// btnEnumerateCoFactors
			// 
			this.btnEnumerateCoFactors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEnumerateCoFactors.Location = new System.Drawing.Point(411, 30);
			this.btnEnumerateCoFactors.Name = "btnEnumerateCoFactors";
			this.btnEnumerateCoFactors.Size = new System.Drawing.Size(75, 23);
			this.btnEnumerateCoFactors.TabIndex = 30;
			this.btnEnumerateCoFactors.Text = "Enumerate";
			this.btnEnumerateCoFactors.UseVisualStyleBackColor = true;
			this.btnEnumerateCoFactors.Click += new System.EventHandler(this.btnEnumerateCoFactors_Click);
			// 
			// btnCancelEnumerateCoFactors
			// 
			this.btnCancelEnumerateCoFactors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancelEnumerateCoFactors.Location = new System.Drawing.Point(411, 55);
			this.btnCancelEnumerateCoFactors.Name = "btnCancelEnumerateCoFactors";
			this.btnCancelEnumerateCoFactors.Size = new System.Drawing.Size(75, 23);
			this.btnCancelEnumerateCoFactors.TabIndex = 31;
			this.btnCancelEnumerateCoFactors.Text = "&Cancel";
			this.btnCancelEnumerateCoFactors.UseVisualStyleBackColor = true;
			this.btnCancelEnumerateCoFactors.Visible = false;
			this.btnCancelEnumerateCoFactors.Click += new System.EventHandler(this.btnCancelEnumerateCoFactors_Click);
			// 
			// panelFactors
			// 
			this.panelFactors.AutoSize = true;
			this.panelFactors.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panelFactors.Controls.Add(this.tbCoFactorMin);
			this.panelFactors.Controls.Add(this.label10);
			this.panelFactors.Controls.Add(this.listCoFactors);
			this.panelFactors.Controls.Add(this.label8);
			this.panelFactors.Controls.Add(this.tbCoFactorMax);
			this.panelFactors.Controls.Add(this.label7);
			this.panelFactors.Controls.Add(this.label9);
			this.panelFactors.Controls.Add(this.btnAddCofactor);
			this.panelFactors.Controls.Add(this.label1);
			this.panelFactors.Controls.Add(this.label5);
			this.panelFactors.Controls.Add(this.tbCoFactorAdd);
			this.panelFactors.Location = new System.Drawing.Point(6, 19);
			this.panelFactors.Name = "panelFactors";
			this.panelFactors.Size = new System.Drawing.Size(399, 75);
			this.panelFactors.TabIndex = 27;
			// 
			// tbCoFactorMin
			// 
			this.tbCoFactorMin.Location = new System.Drawing.Point(247, 2);
			this.tbCoFactorMin.Name = "tbCoFactorMin";
			this.tbCoFactorMin.Size = new System.Drawing.Size(149, 20);
			this.tbCoFactorMin.TabIndex = 21;
			this.tbCoFactorMin.Text = "100";
			this.tbCoFactorMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(247, 24);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(149, 13);
			this.label10.TabIndex = 22;
			this.label10.Text = "Start value";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(504, 381);
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
			this.panelFactors.ResumeLayout(false);
			this.panelFactors.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox tbOutput;
		private System.Windows.Forms.Panel panelOutput;
		private System.Windows.Forms.TextBox tbCoPrimeTo;
		private System.Windows.Forms.TextBox tbCoPrimeMin;
		private System.Windows.Forms.TextBox tbCoFactorMax;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnEnumerateCoprimes;
		private System.Windows.Forms.ListBox listCoFactors;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button btnAddCofactor;
		private System.Windows.Forms.TextBox tbCoFactorAdd;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox tbCoPrimeMax;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ContextMenuStrip contextMenuCoFactors;
		private System.Windows.Forms.ToolStripMenuItem menuDelete;
		private System.Windows.Forms.GroupBox groupCoprime;
		private System.Windows.Forms.GroupBox groupFactors;
		private System.Windows.Forms.Panel panelFactors;
		private System.Windows.Forms.TextBox tbCoFactorMin;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Button btnEnumerateCoFactors;
		private System.Windows.Forms.Button btnCancelEnumerateCoFactors;
	}
}

