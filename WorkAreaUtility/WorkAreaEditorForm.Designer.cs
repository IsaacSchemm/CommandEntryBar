namespace WorkAreaUtility {
	partial class WorkAreaEditorForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.monitorsListBox = new System.Windows.Forms.ListBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.numTop = new System.Windows.Forms.NumericUpDown();
			this.numLeft = new System.Windows.Forms.NumericUpDown();
			this.numRight = new System.Windows.Forms.NumericUpDown();
			this.numBottom = new System.Windows.Forms.NumericUpDown();
			this.pnlPreview = new System.Windows.Forms.Panel();
			this.btnApply = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numTop)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numLeft)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numRight)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numBottom)).BeginInit();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.monitorsListBox);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
			this.splitContainer1.Size = new System.Drawing.Size(384, 161);
			this.splitContainer1.SplitterDistance = 100;
			this.splitContainer1.TabIndex = 0;
			// 
			// monitorsListBox
			// 
			this.monitorsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.monitorsListBox.FormattingEnabled = true;
			this.monitorsListBox.Location = new System.Drawing.Point(0, 0);
			this.monitorsListBox.Name = "monitorsListBox";
			this.monitorsListBox.Size = new System.Drawing.Size(100, 161);
			this.monitorsListBox.TabIndex = 0;
			this.monitorsListBox.SelectedIndexChanged += new System.EventHandler(this.monitorsListBox_SelectedIndexChanged);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.tableLayoutPanel1.Controls.Add(this.numTop, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.numLeft, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.numRight, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.numBottom, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.pnlPreview, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.btnApply, 2, 2);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(280, 161);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// numTop
			// 
			this.numTop.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.numTop.Location = new System.Drawing.Point(63, 9);
			this.numTop.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
			this.numTop.Name = "numTop";
			this.numTop.Size = new System.Drawing.Size(154, 20);
			this.numTop.TabIndex = 0;
			// 
			// numLeft
			// 
			this.numLeft.Dock = System.Windows.Forms.DockStyle.Top;
			this.numLeft.Location = new System.Drawing.Point(3, 35);
			this.numLeft.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
			this.numLeft.Name = "numLeft";
			this.numLeft.Size = new System.Drawing.Size(54, 20);
			this.numLeft.TabIndex = 1;
			// 
			// numRight
			// 
			this.numRight.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.numRight.Location = new System.Drawing.Point(223, 105);
			this.numRight.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
			this.numRight.Name = "numRight";
			this.numRight.Size = new System.Drawing.Size(54, 20);
			this.numRight.TabIndex = 2;
			// 
			// numBottom
			// 
			this.numBottom.Dock = System.Windows.Forms.DockStyle.Top;
			this.numBottom.Location = new System.Drawing.Point(63, 131);
			this.numBottom.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
			this.numBottom.Name = "numBottom";
			this.numBottom.Size = new System.Drawing.Size(154, 20);
			this.numBottom.TabIndex = 3;
			// 
			// pnlPreview
			// 
			this.pnlPreview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlPreview.Location = new System.Drawing.Point(63, 35);
			this.pnlPreview.Name = "pnlPreview";
			this.pnlPreview.Size = new System.Drawing.Size(154, 90);
			this.pnlPreview.TabIndex = 4;
			// 
			// btnApply
			// 
			this.btnApply.Location = new System.Drawing.Point(223, 131);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new System.Drawing.Size(54, 23);
			this.btnApply.TabIndex = 5;
			this.btnApply.Text = "Apply";
			this.btnApply.UseVisualStyleBackColor = true;
			this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(384, 161);
			this.Controls.Add(this.splitContainer1);
			this.Name = "Form1";
			this.Text = "Work Area Utility";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numTop)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numLeft)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numRight)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numBottom)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ListBox monitorsListBox;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.NumericUpDown numTop;
		private System.Windows.Forms.NumericUpDown numLeft;
		private System.Windows.Forms.NumericUpDown numRight;
		private System.Windows.Forms.NumericUpDown numBottom;
		private System.Windows.Forms.Panel pnlPreview;
		private System.Windows.Forms.Button btnApply;
	}
}

