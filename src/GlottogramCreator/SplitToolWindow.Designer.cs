
namespace WinFormsApp1
{
	partial class SplitToolWindow
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
			System.Windows.Forms.Label label1;
			System.Windows.Forms.Label label2;
			System.Windows.Forms.Label label3;
			System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
			System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
			System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
			System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
			System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
			this.slashCheckBox = new System.Windows.Forms.CheckBox();
			this.spaceCheckBox = new System.Windows.Forms.CheckBox();
			this.commaCheckBox = new System.Windows.Forms.CheckBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.tabCheckBox = new System.Windows.Forms.CheckBox();
			this.otherCheckBox = new System.Windows.Forms.CheckBox();
			this.otherTextBox = new System.Windows.Forms.TextBox();
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
			tableLayoutPanel2.SuspendLayout();
			tableLayoutPanel1.SuspendLayout();
			tableLayoutPanel3.SuspendLayout();
			tableLayoutPanel4.SuspendLayout();
			tableLayoutPanel5.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(3, 42);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(101, 21);
			label1.TabIndex = 0;
			label1.Text = "区切り文字：";
			// 
			// label2
			// 
			label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(3, 0);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(329, 21);
			label2.TabIndex = 8;
			label2.Text = "列の分割に使用する区切り文字を選択してください";
			// 
			// label3
			// 
			label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(3, 21);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(100, 21);
			label3.TabIndex = 9;
			label3.Text = "(複数選択可)";
			// 
			// tableLayoutPanel2
			// 
			tableLayoutPanel2.AutoSize = true;
			tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			tableLayoutPanel2.ColumnCount = 1;
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel2.Controls.Add(label2, 0, 0);
			tableLayoutPanel2.Controls.Add(label1, 0, 2);
			tableLayoutPanel2.Controls.Add(label3, 0, 1);
			tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel2.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
			tableLayoutPanel2.Name = "tableLayoutPanel2";
			tableLayoutPanel2.RowCount = 3;
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel2.Size = new System.Drawing.Size(335, 63);
			tableLayoutPanel2.TabIndex = 11;
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.AutoSize = true;
			tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			tableLayoutPanel1.ColumnCount = 2;
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel1.Controls.Add(this.slashCheckBox, 1, 0);
			tableLayoutPanel1.Controls.Add(this.spaceCheckBox, 1, 1);
			tableLayoutPanel1.Controls.Add(this.commaCheckBox, 1, 2);
			tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
			tableLayoutPanel1.Controls.Add(this.tabCheckBox, 1, 3);
			tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 1, 4);
			tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			tableLayoutPanel1.Location = new System.Drawing.Point(3, 72);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 5;
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel1.Size = new System.Drawing.Size(335, 171);
			tableLayoutPanel1.TabIndex = 12;
			// 
			// slashCheckBox
			// 
			this.slashCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.slashCheckBox.AutoSize = true;
			this.slashCheckBox.Location = new System.Drawing.Point(37, 6);
			this.slashCheckBox.Name = "slashCheckBox";
			this.slashCheckBox.Size = new System.Drawing.Size(146, 25);
			this.slashCheckBox.TabIndex = 1;
			this.slashCheckBox.Text = "半角スラッシュ(\"/\")";
			this.slashCheckBox.UseVisualStyleBackColor = true;
			// 
			// spaceCheckBox
			// 
			this.spaceCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.spaceCheckBox.AutoSize = true;
			this.spaceCheckBox.Location = new System.Drawing.Point(37, 40);
			this.spaceCheckBox.Name = "spaceCheckBox";
			this.spaceCheckBox.Size = new System.Drawing.Size(134, 25);
			this.spaceCheckBox.TabIndex = 3;
			this.spaceCheckBox.Text = "半角スペース(\" \")";
			this.spaceCheckBox.UseVisualStyleBackColor = true;
			// 
			// commaCheckBox
			// 
			this.commaCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.commaCheckBox.AutoSize = true;
			this.commaCheckBox.Location = new System.Drawing.Point(37, 71);
			this.commaCheckBox.Name = "commaCheckBox";
			this.commaCheckBox.Size = new System.Drawing.Size(122, 25);
			this.commaCheckBox.TabIndex = 2;
			this.commaCheckBox.Text = "半角カンマ(\",\")";
			this.commaCheckBox.UseVisualStyleBackColor = true;
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(28, 31);
			this.panel1.TabIndex = 11;
			// 
			// tabCheckBox
			// 
			this.tabCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.tabCheckBox.AutoSize = true;
			this.tabCheckBox.Location = new System.Drawing.Point(37, 102);
			this.tabCheckBox.Name = "tabCheckBox";
			this.tabCheckBox.Size = new System.Drawing.Size(89, 25);
			this.tabCheckBox.TabIndex = 4;
			this.tabCheckBox.Text = "タブ(\"\\t\")";
			this.tabCheckBox.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel3
			// 
			tableLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.Left;
			tableLayoutPanel3.AutoSize = true;
			tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			tableLayoutPanel3.ColumnCount = 2;
			tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel3.Controls.Add(this.otherCheckBox, 0, 0);
			tableLayoutPanel3.Controls.Add(this.otherTextBox, 1, 0);
			tableLayoutPanel3.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			tableLayoutPanel3.Location = new System.Drawing.Point(37, 133);
			tableLayoutPanel3.Name = "tableLayoutPanel3";
			tableLayoutPanel3.RowCount = 1;
			tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel3.Size = new System.Drawing.Size(217, 35);
			tableLayoutPanel3.TabIndex = 13;
			// 
			// otherCheckBox
			// 
			this.otherCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.otherCheckBox.AutoSize = true;
			this.otherCheckBox.Location = new System.Drawing.Point(3, 5);
			this.otherCheckBox.Name = "otherCheckBox";
			this.otherCheckBox.Size = new System.Drawing.Size(70, 25);
			this.otherCheckBox.TabIndex = 5;
			this.otherCheckBox.Text = "その他";
			this.otherCheckBox.UseVisualStyleBackColor = true;
			this.otherCheckBox.CheckedChanged += new System.EventHandler(this.otherCheckBox_CheckedChanged);
			// 
			// otherTextBox
			// 
			this.otherTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.otherTextBox.Enabled = false;
			this.otherTextBox.Location = new System.Drawing.Point(79, 3);
			this.otherTextBox.MaxLength = 1;
			this.otherTextBox.Name = "otherTextBox";
			this.otherTextBox.Size = new System.Drawing.Size(135, 29);
			this.otherTextBox.TabIndex = 6;
			// 
			// tableLayoutPanel4
			// 
			tableLayoutPanel4.Anchor = System.Windows.Forms.AnchorStyles.Right;
			tableLayoutPanel4.AutoSize = true;
			tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			tableLayoutPanel4.ColumnCount = 2;
			tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel4.Controls.Add(this.okButton, 0, 0);
			tableLayoutPanel4.Controls.Add(this.cancelButton, 1, 0);
			tableLayoutPanel4.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			tableLayoutPanel4.Location = new System.Drawing.Point(226, 249);
			tableLayoutPanel4.Name = "tableLayoutPanel4";
			tableLayoutPanel4.RowCount = 1;
			tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel4.Size = new System.Drawing.Size(112, 37);
			tableLayoutPanel4.TabIndex = 13;
			// 
			// okButton
			// 
			this.okButton.AutoSize = true;
			this.okButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new System.Drawing.Point(3, 3);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(52, 31);
			this.okButton.TabIndex = 7;
			this.okButton.Text = "決定";
			this.okButton.UseVisualStyleBackColor = true;
			// 
			// cancelButton
			// 
			this.cancelButton.AutoSize = true;
			this.cancelButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(61, 3);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(48, 31);
			this.cancelButton.TabIndex = 0;
			this.cancelButton.Text = "戻る";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel5
			// 
			tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			tableLayoutPanel5.AutoSize = true;
			tableLayoutPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			tableLayoutPanel5.ColumnCount = 1;
			tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel5.Controls.Add(tableLayoutPanel4, 0, 2);
			tableLayoutPanel5.Controls.Add(tableLayoutPanel2, 0, 0);
			tableLayoutPanel5.Controls.Add(tableLayoutPanel1, 0, 1);
			tableLayoutPanel5.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			tableLayoutPanel5.Location = new System.Drawing.Point(12, 12);
			tableLayoutPanel5.Name = "tableLayoutPanel5";
			tableLayoutPanel5.RowCount = 3;
			tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel5.Size = new System.Drawing.Size(341, 289);
			tableLayoutPanel5.TabIndex = 14;
			// 
			// SplitToolWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(365, 313);
			this.Controls.Add(tableLayoutPanel5);
			this.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SplitToolWindow";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "文字列の分割";
			this.TopMost = true;
			tableLayoutPanel2.ResumeLayout(false);
			tableLayoutPanel2.PerformLayout();
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			tableLayoutPanel3.ResumeLayout(false);
			tableLayoutPanel3.PerformLayout();
			tableLayoutPanel4.ResumeLayout(false);
			tableLayoutPanel4.PerformLayout();
			tableLayoutPanel5.ResumeLayout(false);
			tableLayoutPanel5.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button cancelButton;
		public System.Windows.Forms.CheckBox slashCheckBox;
		public System.Windows.Forms.CheckBox commaCheckBox;
		public System.Windows.Forms.CheckBox spaceCheckBox;
		public System.Windows.Forms.CheckBox tabCheckBox;
		public System.Windows.Forms.CheckBox otherCheckBox;
		public System.Windows.Forms.TextBox otherTextBox;
		private System.Windows.Forms.Panel panel1;
	}
}