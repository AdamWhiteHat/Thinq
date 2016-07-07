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
			this.tbResultMaxValue = new System.Windows.Forms.TextBox();
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
			this.panelFactors = new System.Windows.Forms.Panel();
			this.btnCancelEnumerateCoFactors = new System.Windows.Forms.Button();
			this.tbResultMaxQuantity = new System.Windows.Forms.TextBox();
			this.btnEnumerateCoFactors = new System.Windows.Forms.Button();
			this.label11 = new System.Windows.Forms.Label();
			this.tbResultMinValue = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.btnEnumerateGCD = new System.Windows.Forms.Button();
			this.btnEnumerateLCM = new System.Windows.Forms.Button();
			this.btnEnumeratePiDigit = new System.Windows.Forms.Button();
			this.tbPiDigit = new System.Windows.Forms.TextBox();
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
			this.tbCoPrimeTo.Location = new System.Drawing.Point(8, 20);
			this.tbCoPrimeTo.Name = "tbCoPrimeTo";
			this.tbCoPrimeTo.Size = new System.Drawing.Size(60, 20);
			this.tbCoPrimeTo.TabIndex = 0;
			this.tbCoPrimeTo.Text = "256";
			this.tbCoPrimeTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// tbCoPrimeMin
			// 
			this.tbCoPrimeMin.Location = new System.Drawing.Point(82, 20);
			this.tbCoPrimeMin.Name = "tbCoPrimeMin";
			this.tbCoPrimeMin.Size = new System.Drawing.Size(60, 20);
			this.tbCoPrimeMin.TabIndex = 1;
			this.tbCoPrimeMin.Text = "2";
			this.tbCoPrimeMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// tbResultMaxValue
			// 
			this.tbResultMaxValue.Location = new System.Drawing.Point(247, 39);
			this.tbResultMaxValue.Name = "tbResultMaxValue";
			this.tbResultMaxValue.Size = new System.Drawing.Size(109, 20);
			this.tbResultMaxValue.TabIndex = 3;
			this.tbResultMaxValue.Text = "20,000,000";
			this.tbResultMaxValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(247, 59);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(109, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Max result value";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(9, 42);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(59, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "CoPrime to";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(82, 42);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(137, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "Range (min / max)";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnEnumerateCoprimes
			// 
			this.btnEnumerateCoprimes.Location = new System.Drawing.Point(225, 18);
			this.btnEnumerateCoprimes.Name = "btnEnumerateCoprimes";
			this.btnEnumerateCoprimes.Size = new System.Drawing.Size(97, 23);
			this.btnEnumerateCoprimes.TabIndex = 3;
			this.btnEnumerateCoprimes.Text = "Find Co-Primes";
			this.btnEnumerateCoprimes.UseVisualStyleBackColor = true;
			this.btnEnumerateCoprimes.Click += new System.EventHandler(this.btnCoprimes_Click);
			// 
			// listCoFactors
			// 
			this.listCoFactors.ContextMenuStrip = this.contextMenuCoFactors;
			this.listCoFactors.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listCoFactors.FormattingEnabled = true;
			this.listCoFactors.HorizontalScrollbar = true;
			this.listCoFactors.Items.AddRange(new object[] {
            "3",
            "5",
            "7",
            "11",
            "13"});
			this.listCoFactors.Location = new System.Drawing.Point(63, 3);
			this.listCoFactors.Margin = new System.Windows.Forms.Padding(0);
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
			this.label5.Location = new System.Drawing.Point(4, 5);
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
			this.label7.Location = new System.Drawing.Point(34, 5);
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
			this.label8.Location = new System.Drawing.Point(126, 5);
			this.label8.Margin = new System.Windows.Forms.Padding(0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(26, 65);
			this.label8.TabIndex = 17;
			this.label8.Text = ")";
			this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnAddCofactor
			// 
			this.btnAddCofactor.Location = new System.Drawing.Point(153, 33);
			this.btnAddCofactor.Name = "btnAddCofactor";
			this.btnAddCofactor.Size = new System.Drawing.Size(60, 23);
			this.btnAddCofactor.TabIndex = 2;
			this.btnAddCofactor.Text = "<-- Add";
			this.btnAddCofactor.UseVisualStyleBackColor = true;
			this.btnAddCofactor.Click += new System.EventHandler(this.btnAddCoFactor_Click);
			// 
			// tbCoFactorAdd
			// 
			this.tbCoFactorAdd.Location = new System.Drawing.Point(153, 12);
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
			this.label9.Location = new System.Drawing.Point(214, 5);
			this.label9.Margin = new System.Windows.Forms.Padding(0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(32, 65);
			this.label9.TabIndex = 20;
			this.label9.Text = "<";
			this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// tbCoPrimeMax
			// 
			this.tbCoPrimeMax.Location = new System.Drawing.Point(159, 20);
			this.tbCoPrimeMax.Name = "tbCoPrimeMax";
			this.tbCoPrimeMax.Size = new System.Drawing.Size(60, 20);
			this.tbCoPrimeMax.TabIndex = 2;
			this.tbCoPrimeMax.Text = "255";
			this.tbCoPrimeMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(71, 24);
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
			this.label6.Location = new System.Drawing.Point(144, 24);
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
			this.groupCoprime.Size = new System.Drawing.Size(327, 67);
			this.groupCoprime.TabIndex = 25;
			this.groupCoprime.TabStop = false;
			this.groupCoprime.Text = "Co-Prime";
			// 
			// groupFactors
			// 
			this.groupFactors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupFactors.Controls.Add(this.panelFactors);
			this.groupFactors.Location = new System.Drawing.Point(4, 77);
			this.groupFactors.Name = "groupFactors";
			this.groupFactors.Size = new System.Drawing.Size(496, 100);
			this.groupFactors.TabIndex = 26;
			this.groupFactors.TabStop = false;
			this.groupFactors.Text = "Common Factors";
			// 
			// panelFactors
			// 
			this.panelFactors.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panelFactors.Controls.Add(this.btnCancelEnumerateCoFactors);
			this.panelFactors.Controls.Add(this.tbResultMaxQuantity);
			this.panelFactors.Controls.Add(this.btnEnumerateCoFactors);
			this.panelFactors.Controls.Add(this.label11);
			this.panelFactors.Controls.Add(this.tbResultMinValue);
			this.panelFactors.Controls.Add(this.label10);
			this.panelFactors.Controls.Add(this.listCoFactors);
			this.panelFactors.Controls.Add(this.label8);
			this.panelFactors.Controls.Add(this.tbResultMaxValue);
			this.panelFactors.Controls.Add(this.label7);
			this.panelFactors.Controls.Add(this.label9);
			this.panelFactors.Controls.Add(this.btnAddCofactor);
			this.panelFactors.Controls.Add(this.label1);
			this.panelFactors.Controls.Add(this.label5);
			this.panelFactors.Controls.Add(this.tbCoFactorAdd);
			this.panelFactors.Location = new System.Drawing.Point(6, 19);
			this.panelFactors.Name = "panelFactors";
			this.panelFactors.Size = new System.Drawing.Size(484, 75);
			this.panelFactors.TabIndex = 27;
			// 
			// btnCancelEnumerateCoFactors
			// 
			this.btnCancelEnumerateCoFactors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancelEnumerateCoFactors.Location = new System.Drawing.Point(425, 8);
			this.btnCancelEnumerateCoFactors.Name = "btnCancelEnumerateCoFactors";
			this.btnCancelEnumerateCoFactors.Size = new System.Drawing.Size(54, 23);
			this.btnCancelEnumerateCoFactors.TabIndex = 31;
			this.btnCancelEnumerateCoFactors.Text = "&Cancel";
			this.btnCancelEnumerateCoFactors.UseVisualStyleBackColor = true;
			this.btnCancelEnumerateCoFactors.Visible = false;
			this.btnCancelEnumerateCoFactors.Click += new System.EventHandler(this.btnCancelEnumerateCoFactors_Click);
			// 
			// tbResultMaxQuantity
			// 
			this.tbResultMaxQuantity.Location = new System.Drawing.Point(365, 39);
			this.tbResultMaxQuantity.Name = "tbResultMaxQuantity";
			this.tbResultMaxQuantity.Size = new System.Drawing.Size(109, 20);
			this.tbResultMaxQuantity.TabIndex = 23;
			this.tbResultMaxQuantity.Text = "2";
			this.tbResultMaxQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// btnEnumerateCoFactors
			// 
			this.btnEnumerateCoFactors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEnumerateCoFactors.Location = new System.Drawing.Point(360, 8);
			this.btnEnumerateCoFactors.Name = "btnEnumerateCoFactors";
			this.btnEnumerateCoFactors.Size = new System.Drawing.Size(67, 23);
			this.btnEnumerateCoFactors.TabIndex = 30;
			this.btnEnumerateCoFactors.Text = "Enumerate";
			this.btnEnumerateCoFactors.UseVisualStyleBackColor = true;
			this.btnEnumerateCoFactors.Click += new System.EventHandler(this.btnEnumerateCoFactors_Click);
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(365, 59);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(109, 13);
			this.label11.TabIndex = 24;
			this.label11.Text = "Max result quantity";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbResultMinValue
			// 
			this.tbResultMinValue.Location = new System.Drawing.Point(247, 3);
			this.tbResultMinValue.Name = "tbResultMinValue";
			this.tbResultMinValue.Size = new System.Drawing.Size(109, 20);
			this.tbResultMinValue.TabIndex = 21;
			this.tbResultMinValue.Text = "2";
			this.tbResultMinValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(247, 25);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(109, 13);
			this.label10.TabIndex = 22;
			this.label10.Text = "Min result value";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnEnumerateGCD
			// 
			this.btnEnumerateGCD.Location = new System.Drawing.Point(420, 8);
			this.btnEnumerateGCD.Name = "btnEnumerateGCD";
			this.btnEnumerateGCD.Size = new System.Drawing.Size(75, 23);
			this.btnEnumerateGCD.TabIndex = 27;
			this.btnEnumerateGCD.Text = "Find GCD";
			this.btnEnumerateGCD.UseVisualStyleBackColor = true;
			this.btnEnumerateGCD.Click += new System.EventHandler(this.btnEnumerateGCD_Click);
			// 
			// btnEnumerateLCM
			// 
			this.btnEnumerateLCM.Location = new System.Drawing.Point(420, 31);
			this.btnEnumerateLCM.Name = "btnEnumerateLCM";
			this.btnEnumerateLCM.Size = new System.Drawing.Size(75, 23);
			this.btnEnumerateLCM.TabIndex = 28;
			this.btnEnumerateLCM.Text = "Find LCM";
			this.btnEnumerateLCM.UseVisualStyleBackColor = true;
			this.btnEnumerateLCM.Click += new System.EventHandler(this.btnEnumerateLCM_Click);
			// 
			// btnEnumeratePiDigit
			// 
			this.btnEnumeratePiDigit.Location = new System.Drawing.Point(420, 54);
			this.btnEnumeratePiDigit.Name = "btnEnumeratePiDigit";
			this.btnEnumeratePiDigit.Size = new System.Drawing.Size(75, 23);
			this.btnEnumeratePiDigit.TabIndex = 29;
			this.btnEnumeratePiDigit.Text = "Find Pi Digit";
			this.btnEnumeratePiDigit.UseVisualStyleBackColor = true;
			// 
			// tbPiDigit
			// 
			this.tbPiDigit.Location = new System.Drawing.Point(354, 56);
			this.tbPiDigit.Name = "tbPiDigit";
			this.tbPiDigit.Size = new System.Drawing.Size(60, 20);
			this.tbPiDigit.TabIndex = 30;
			this.tbPiDigit.Text = "7";
			this.tbPiDigit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(504, 381);
			this.Controls.Add(this.tbPiDigit);
			this.Controls.Add(this.btnEnumeratePiDigit);
			this.Controls.Add(this.btnEnumerateLCM);
			this.Controls.Add(this.btnEnumerateGCD);
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
			this.panelFactors.ResumeLayout(false);
			this.panelFactors.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panelOutput;
		private System.Windows.Forms.TextBox tbCoPrimeTo;
		private System.Windows.Forms.TextBox tbCoPrimeMin;
		private System.Windows.Forms.TextBox tbResultMaxValue;
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
		private System.Windows.Forms.TextBox tbResultMinValue;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Button btnEnumerateCoFactors;
		private System.Windows.Forms.Button btnCancelEnumerateCoFactors;
		private System.Windows.Forms.TextBox tbResultMaxQuantity;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Button btnEnumerateGCD;
		private System.Windows.Forms.Button btnEnumerateLCM;
		private System.Windows.Forms.Button btnEnumeratePiDigit;
		private System.Windows.Forms.TextBox tbPiDigit;
		public System.Windows.Forms.TextBox tbOutput;
	}
}

