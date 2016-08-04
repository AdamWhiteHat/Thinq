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
			this.label3 = new System.Windows.Forms.Label();
			this.btnEnumerateCoprimes = new System.Windows.Forms.Button();
			this.contextMenuCoFactors = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menuDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.tbCoPrimeMax = new System.Windows.Forms.TextBox();
			this.groupCoprime = new System.Windows.Forms.GroupBox();
			this.btnEnumeratePrimeFactors = new System.Windows.Forms.Button();
			this.btnEnumerateGCD = new System.Windows.Forms.Button();
			this.btnEnumerateLCM = new System.Windows.Forms.Button();
			this.groupFactors = new System.Windows.Forms.GroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this.btnCancelEnumerateCoFactors = new System.Windows.Forms.Button();
			this.tbResultMaxQuantity = new System.Windows.Forms.TextBox();
			this.btnEnumerateCoFactors = new System.Windows.Forms.Button();
			this.label11 = new System.Windows.Forms.Label();
			this.tbResultMinValue = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.listCoFactors = new System.Windows.Forms.ListBox();
			this.label8 = new System.Windows.Forms.Label();
			this.tbResultMaxValue = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.btnAddCofactor = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.tbCoFactorAdd = new System.Windows.Forms.TextBox();
			this.panelOutput.SuspendLayout();
			this.contextMenuCoFactors.SuspendLayout();
			this.groupCoprime.SuspendLayout();
			this.groupFactors.SuspendLayout();
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
			this.tbOutput.Size = new System.Drawing.Size(655, 189);
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
			this.panelOutput.Size = new System.Drawing.Size(661, 196);
			this.panelOutput.TabIndex = 2;
			// 
			// tbCoPrimeTo
			// 
			this.tbCoPrimeTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbCoPrimeTo.Location = new System.Drawing.Point(8, 19);
			this.tbCoPrimeTo.Name = "tbCoPrimeTo";
			this.tbCoPrimeTo.Size = new System.Drawing.Size(200, 20);
			this.tbCoPrimeTo.TabIndex = 0;
			this.tbCoPrimeTo.Text = "256";
			this.tbCoPrimeTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// tbCoPrimeMin
			// 
			this.tbCoPrimeMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tbCoPrimeMin.Location = new System.Drawing.Point(235, 17);
			this.tbCoPrimeMin.Margin = new System.Windows.Forms.Padding(0);
			this.tbCoPrimeMin.Name = "tbCoPrimeMin";
			this.tbCoPrimeMin.Size = new System.Drawing.Size(190, 20);
			this.tbCoPrimeMin.TabIndex = 1;
			this.tbCoPrimeMin.Text = "600";
			this.tbCoPrimeMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.Location = new System.Drawing.Point(8, 41);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(200, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "CoPrime to";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnEnumerateCoprimes
			// 
			this.btnEnumerateCoprimes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEnumerateCoprimes.Location = new System.Drawing.Point(465, 14);
			this.btnEnumerateCoprimes.Name = "btnEnumerateCoprimes";
			this.btnEnumerateCoprimes.Size = new System.Drawing.Size(109, 23);
			this.btnEnumerateCoprimes.TabIndex = 3;
			this.btnEnumerateCoprimes.Text = "Find Co-Primes";
			this.btnEnumerateCoprimes.UseVisualStyleBackColor = true;
			this.btnEnumerateCoprimes.Click += new System.EventHandler(this.btnCoprimes_Click);
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
			// tbCoPrimeMax
			// 
			this.tbCoPrimeMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tbCoPrimeMax.Location = new System.Drawing.Point(230, 38);
			this.tbCoPrimeMax.Margin = new System.Windows.Forms.Padding(0);
			this.tbCoPrimeMax.Name = "tbCoPrimeMax";
			this.tbCoPrimeMax.Size = new System.Drawing.Size(200, 20);
			this.tbCoPrimeMax.TabIndex = 2;
			this.tbCoPrimeMax.Text = "65000";
			this.tbCoPrimeMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// groupCoprime
			// 
			this.groupCoprime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupCoprime.Controls.Add(this.label6);
			this.groupCoprime.Controls.Add(this.btnEnumeratePrimeFactors);
			this.groupCoprime.Controls.Add(this.btnEnumerateCoprimes);
			this.groupCoprime.Controls.Add(this.btnEnumerateGCD);
			this.groupCoprime.Controls.Add(this.btnEnumerateLCM);
			this.groupCoprime.Controls.Add(this.tbCoPrimeTo);
			this.groupCoprime.Controls.Add(this.tbCoPrimeMin);
			this.groupCoprime.Controls.Add(this.label3);
			this.groupCoprime.Controls.Add(this.tbCoPrimeMax);
			this.groupCoprime.Location = new System.Drawing.Point(4, 4);
			this.groupCoprime.Name = "groupCoprime";
			this.groupCoprime.Size = new System.Drawing.Size(654, 67);
			this.groupCoprime.TabIndex = 25;
			this.groupCoprime.TabStop = false;
			this.groupCoprime.Text = "Co-Prime";
			// 
			// btnEnumeratePrimeFactors
			// 
			this.btnEnumeratePrimeFactors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEnumeratePrimeFactors.Location = new System.Drawing.Point(465, 37);
			this.btnEnumeratePrimeFactors.Name = "btnEnumeratePrimeFactors";
			this.btnEnumeratePrimeFactors.Size = new System.Drawing.Size(109, 23);
			this.btnEnumeratePrimeFactors.TabIndex = 29;
			this.btnEnumeratePrimeFactors.Text = "Find Prime Factors";
			this.btnEnumeratePrimeFactors.UseVisualStyleBackColor = true;
			this.btnEnumeratePrimeFactors.Click += new System.EventHandler(this.btnEnumeratePrimeFactors_Click);
			// 
			// btnEnumerateGCD
			// 
			this.btnEnumerateGCD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEnumerateGCD.Location = new System.Drawing.Point(574, 14);
			this.btnEnumerateGCD.Name = "btnEnumerateGCD";
			this.btnEnumerateGCD.Size = new System.Drawing.Size(75, 23);
			this.btnEnumerateGCD.TabIndex = 27;
			this.btnEnumerateGCD.Text = "Find GCD";
			this.btnEnumerateGCD.UseVisualStyleBackColor = true;
			this.btnEnumerateGCD.Click += new System.EventHandler(this.btnEnumerateGCD_Click);
			// 
			// btnEnumerateLCM
			// 
			this.btnEnumerateLCM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEnumerateLCM.Location = new System.Drawing.Point(574, 37);
			this.btnEnumerateLCM.Name = "btnEnumerateLCM";
			this.btnEnumerateLCM.Size = new System.Drawing.Size(75, 23);
			this.btnEnumerateLCM.TabIndex = 28;
			this.btnEnumerateLCM.Text = "Find LCM";
			this.btnEnumerateLCM.UseVisualStyleBackColor = true;
			this.btnEnumerateLCM.Click += new System.EventHandler(this.btnEnumerateLCM_Click);
			// 
			// groupFactors
			// 
			this.groupFactors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupFactors.Controls.Add(this.btnCancelEnumerateCoFactors);
			this.groupFactors.Controls.Add(this.tbResultMaxQuantity);
			this.groupFactors.Controls.Add(this.btnEnumerateCoFactors);
			this.groupFactors.Controls.Add(this.label11);
			this.groupFactors.Controls.Add(this.tbResultMinValue);
			this.groupFactors.Controls.Add(this.label10);
			this.groupFactors.Controls.Add(this.listCoFactors);
			this.groupFactors.Controls.Add(this.label8);
			this.groupFactors.Controls.Add(this.tbResultMaxValue);
			this.groupFactors.Controls.Add(this.label7);
			this.groupFactors.Controls.Add(this.label9);
			this.groupFactors.Controls.Add(this.btnAddCofactor);
			this.groupFactors.Controls.Add(this.label1);
			this.groupFactors.Controls.Add(this.label5);
			this.groupFactors.Controls.Add(this.tbCoFactorAdd);
			this.groupFactors.Location = new System.Drawing.Point(4, 77);
			this.groupFactors.Name = "groupFactors";
			this.groupFactors.Size = new System.Drawing.Size(654, 100);
			this.groupFactors.TabIndex = 26;
			this.groupFactors.TabStop = false;
			this.groupFactors.Text = "Common Factors";
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.Location = new System.Drawing.Point(433, 14);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(31, 46);
			this.label6.TabIndex = 31;
			this.label6.Text = "min/ max";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnCancelEnumerateCoFactors
			// 
			this.btnCancelEnumerateCoFactors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancelEnumerateCoFactors.Location = new System.Drawing.Point(574, 33);
			this.btnCancelEnumerateCoFactors.Name = "btnCancelEnumerateCoFactors";
			this.btnCancelEnumerateCoFactors.Size = new System.Drawing.Size(75, 23);
			this.btnCancelEnumerateCoFactors.TabIndex = 46;
			this.btnCancelEnumerateCoFactors.Text = "&Cancel";
			this.btnCancelEnumerateCoFactors.UseVisualStyleBackColor = true;
			this.btnCancelEnumerateCoFactors.Visible = false;
			// 
			// tbResultMaxQuantity
			// 
			this.tbResultMaxQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tbResultMaxQuantity.Location = new System.Drawing.Point(459, 57);
			this.tbResultMaxQuantity.Name = "tbResultMaxQuantity";
			this.tbResultMaxQuantity.Size = new System.Drawing.Size(190, 20);
			this.tbResultMaxQuantity.TabIndex = 43;
			this.tbResultMaxQuantity.Text = "2";
			this.tbResultMaxQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// btnEnumerateCoFactors
			// 
			this.btnEnumerateCoFactors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEnumerateCoFactors.Location = new System.Drawing.Point(574, 9);
			this.btnEnumerateCoFactors.Name = "btnEnumerateCoFactors";
			this.btnEnumerateCoFactors.Size = new System.Drawing.Size(75, 23);
			this.btnEnumerateCoFactors.TabIndex = 45;
			this.btnEnumerateCoFactors.Text = "Enumerate";
			this.btnEnumerateCoFactors.UseVisualStyleBackColor = true;
			// 
			// label11
			// 
			this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label11.Location = new System.Drawing.Point(459, 77);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(190, 13);
			this.label11.TabIndex = 44;
			this.label11.Text = "Max result quantity";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbResultMinValue
			// 
			this.tbResultMinValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbResultMinValue.Location = new System.Drawing.Point(253, 21);
			this.tbResultMinValue.Name = "tbResultMinValue";
			this.tbResultMinValue.Size = new System.Drawing.Size(188, 20);
			this.tbResultMinValue.TabIndex = 41;
			this.tbResultMinValue.Text = "3,592,624,039";
			this.tbResultMinValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label10
			// 
			this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label10.Location = new System.Drawing.Point(253, 43);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(188, 13);
			this.label10.TabIndex = 42;
			this.label10.Text = "Min result value";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            "13",
            "23",
            "101",
            "103"});
			this.listCoFactors.Location = new System.Drawing.Point(64, 14);
			this.listCoFactors.Margin = new System.Windows.Forms.Padding(0);
			this.listCoFactors.Name = "listCoFactors";
			this.listCoFactors.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.listCoFactors.Size = new System.Drawing.Size(60, 82);
			this.listCoFactors.TabIndex = 32;
			// 
			// label8
			// 
			this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.label8.Font = new System.Drawing.Font("Arial Narrow", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(127, 14);
			this.label8.Margin = new System.Windows.Forms.Padding(0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(26, 82);
			this.label8.TabIndex = 39;
			this.label8.Text = ")";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tbResultMaxValue
			// 
			this.tbResultMaxValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbResultMaxValue.Location = new System.Drawing.Point(248, 57);
			this.tbResultMaxValue.Name = "tbResultMaxValue";
			this.tbResultMaxValue.Size = new System.Drawing.Size(198, 20);
			this.tbResultMaxValue.TabIndex = 35;
			this.tbResultMaxValue.Text = "4,500,000,000";
			this.tbResultMaxValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label7
			// 
			this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.label7.Font = new System.Drawing.Font("Arial Narrow", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(35, 14);
			this.label7.Margin = new System.Windows.Forms.Padding(0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(26, 82);
			this.label7.TabIndex = 38;
			this.label7.Text = "(";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label9
			// 
			this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.label9.Font = new System.Drawing.Font("Arial Narrow", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(215, 16);
			this.label9.Margin = new System.Windows.Forms.Padding(0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(32, 80);
			this.label9.TabIndex = 40;
			this.label9.Text = "<";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnAddCofactor
			// 
			this.btnAddCofactor.Location = new System.Drawing.Point(154, 55);
			this.btnAddCofactor.Name = "btnAddCofactor";
			this.btnAddCofactor.Size = new System.Drawing.Size(60, 23);
			this.btnAddCofactor.TabIndex = 34;
			this.btnAddCofactor.Text = "<-- Add";
			this.btnAddCofactor.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(250, 77);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(196, 13);
			this.label1.TabIndex = 36;
			this.label1.Text = "Max result value";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(5, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(27, 80);
			this.label5.TabIndex = 37;
			this.label5.Text = "∩";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbCoFactorAdd
			// 
			this.tbCoFactorAdd.Location = new System.Drawing.Point(154, 34);
			this.tbCoFactorAdd.Name = "tbCoFactorAdd";
			this.tbCoFactorAdd.Size = new System.Drawing.Size(60, 20);
			this.tbCoFactorAdd.TabIndex = 33;
			this.tbCoFactorAdd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(662, 381);
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

		private System.Windows.Forms.Panel panelOutput;
		private System.Windows.Forms.TextBox tbCoPrimeTo;
		private System.Windows.Forms.TextBox tbCoPrimeMin;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnEnumerateCoprimes;
		private System.Windows.Forms.TextBox tbCoPrimeMax;
		private System.Windows.Forms.ContextMenuStrip contextMenuCoFactors;
		private System.Windows.Forms.ToolStripMenuItem menuDelete;
		private System.Windows.Forms.GroupBox groupCoprime;
		private System.Windows.Forms.GroupBox groupFactors;
		private System.Windows.Forms.Button btnEnumerateGCD;
		private System.Windows.Forms.Button btnEnumerateLCM;
		public System.Windows.Forms.TextBox tbOutput;
		private System.Windows.Forms.Button btnEnumeratePrimeFactors;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btnCancelEnumerateCoFactors;
		private System.Windows.Forms.TextBox tbResultMaxQuantity;
		private System.Windows.Forms.Button btnEnumerateCoFactors;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox tbResultMinValue;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ListBox listCoFactors;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox tbResultMaxValue;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Button btnAddCofactor;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tbCoFactorAdd;
	}
}

