namespace WinFormsApp1
{
	partial class DPISetting
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
			System.Windows.Forms.Label dpiLabel;
			System.Windows.Forms.Label formatLabel;
			System.Windows.Forms.TableLayoutPanel buttonTableLayoutPanel;
			System.Windows.Forms.TableLayoutPanel groupTableLayoutPanel;
			System.Windows.Forms.TableLayoutPanel allTableLayoutPanel;
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.dpiNumberBox = new WinFormsApp1.NumberBox();
			this.formatEnumComboBox = new WinFormsApp1.EnumComboBox();
			this.coloredGroupBox1 = new WinFormsApp1.ColoredGroupBox();
			dpiLabel = new System.Windows.Forms.Label();
			formatLabel = new System.Windows.Forms.Label();
			buttonTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			groupTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			allTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			buttonTableLayoutPanel.SuspendLayout();
			groupTableLayoutPanel.SuspendLayout();
			allTableLayoutPanel.SuspendLayout();
			this.coloredGroupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dpiLabel
			// 
			dpiLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
			dpiLabel.AutoSize = true;
			dpiLabel.Location = new System.Drawing.Point(37, 7);
			dpiLabel.Name = "dpiLabel";
			dpiLabel.Size = new System.Drawing.Size(37, 15);
			dpiLabel.TabIndex = 4;
			dpiLabel.Text = "DPI：";
			// 
			// formatLabel
			// 
			formatLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
			formatLabel.AutoSize = true;
			formatLabel.Location = new System.Drawing.Point(3, 36);
			formatLabel.Name = "formatLabel";
			formatLabel.Size = new System.Drawing.Size(71, 15);
			formatLabel.TabIndex = 5;
			formatLabel.Text = "印刷サイズ：";
			// 
			// buttonTableLayoutPanel
			// 
			buttonTableLayoutPanel.AutoSize = true;
			buttonTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			buttonTableLayoutPanel.ColumnCount = 1;
			buttonTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			buttonTableLayoutPanel.Controls.Add(this.okButton, 0, 0);
			buttonTableLayoutPanel.Controls.Add(this.cancelButton, 0, 1);
			buttonTableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			buttonTableLayoutPanel.Location = new System.Drawing.Point(255, 3);
			buttonTableLayoutPanel.Name = "buttonTableLayoutPanel";
			buttonTableLayoutPanel.RowCount = 2;
			buttonTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			buttonTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			buttonTableLayoutPanel.Size = new System.Drawing.Size(69, 62);
			buttonTableLayoutPanel.TabIndex = 8;
			// 
			// okButton
			// 
			this.okButton.AutoSize = true;
			this.okButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.okButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.okButton.Location = new System.Drawing.Point(3, 3);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(63, 25);
			this.okButton.TabIndex = 2;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.Button_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.AutoSize = true;
			this.cancelButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.cancelButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cancelButton.Location = new System.Drawing.Point(3, 34);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(63, 25);
			this.cancelButton.TabIndex = 0;
			this.cancelButton.Text = "キャンセル";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.Button_Click);
			// 
			// groupTableLayoutPanel
			// 
			groupTableLayoutPanel.AutoSize = true;
			groupTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			groupTableLayoutPanel.ColumnCount = 2;
			groupTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			groupTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			groupTableLayoutPanel.Controls.Add(this.dpiNumberBox, 1, 0);
			groupTableLayoutPanel.Controls.Add(this.formatEnumComboBox, 1, 1);
			groupTableLayoutPanel.Controls.Add(formatLabel, 0, 1);
			groupTableLayoutPanel.Controls.Add(dpiLabel, 0, 0);
			groupTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			groupTableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			groupTableLayoutPanel.Location = new System.Drawing.Point(3, 19);
			groupTableLayoutPanel.Name = "groupTableLayoutPanel";
			groupTableLayoutPanel.RowCount = 2;
			groupTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			groupTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			groupTableLayoutPanel.Size = new System.Drawing.Size(240, 58);
			groupTableLayoutPanel.TabIndex = 0;
			// 
			// dpiNumberBox
			// 
			this.dpiNumberBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.dpiNumberBox.DefaultValue = 350;
			this.dpiNumberBox.EnableTextChanged = false;
			this.dpiNumberBox.Location = new System.Drawing.Point(80, 3);
			this.dpiNumberBox.Name = "dpiNumberBox";
			this.dpiNumberBox.Size = new System.Drawing.Size(157, 23);
			this.dpiNumberBox.TabIndex = 0;
			this.dpiNumberBox.Value = 350;
			this.dpiNumberBox.ValueMin = 1;
			// 
			// formatEnumComboBox
			// 
			this.formatEnumComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.formatEnumComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.formatEnumComboBox.EnumName = "Format";
			this.formatEnumComboBox.FormattingEnabled = true;
			this.formatEnumComboBox.Location = new System.Drawing.Point(80, 32);
			this.formatEnumComboBox.Name = "formatEnumComboBox";
			this.formatEnumComboBox.SelectedEnumValue = null;
			this.formatEnumComboBox.Size = new System.Drawing.Size(157, 23);
			this.formatEnumComboBox.TabIndex = 1;
			// 
			// allTableLayoutPanel
			// 
			allTableLayoutPanel.AutoSize = true;
			allTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			allTableLayoutPanel.ColumnCount = 2;
			allTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			allTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			allTableLayoutPanel.Controls.Add(this.coloredGroupBox1, 0, 0);
			allTableLayoutPanel.Controls.Add(buttonTableLayoutPanel, 1, 0);
			allTableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			allTableLayoutPanel.Location = new System.Drawing.Point(12, 12);
			allTableLayoutPanel.Name = "allTableLayoutPanel";
			allTableLayoutPanel.RowCount = 1;
			allTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			allTableLayoutPanel.Size = new System.Drawing.Size(327, 86);
			allTableLayoutPanel.TabIndex = 0;
			// 
			// coloredGroupBox1
			// 
			this.coloredGroupBox1.AutoSize = true;
			this.coloredGroupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.coloredGroupBox1.Controls.Add(groupTableLayoutPanel);
			this.coloredGroupBox1.Location = new System.Drawing.Point(3, 3);
			this.coloredGroupBox1.Name = "coloredGroupBox1";
			this.coloredGroupBox1.Size = new System.Drawing.Size(246, 80);
			this.coloredGroupBox1.TabIndex = 1;
			this.coloredGroupBox1.TabStop = false;
			this.coloredGroupBox1.Text = "設定";
			// 
			// DPISetting
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(allTableLayoutPanel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DPISetting";
			this.Text = "本体サイズ設定";
			buttonTableLayoutPanel.ResumeLayout(false);
			buttonTableLayoutPanel.PerformLayout();
			groupTableLayoutPanel.ResumeLayout(false);
			groupTableLayoutPanel.PerformLayout();
			allTableLayoutPanel.ResumeLayout(false);
			allTableLayoutPanel.PerformLayout();
			this.coloredGroupBox1.ResumeLayout(false);
			this.coloredGroupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private NumberBox dpiNumberBox;
		private EnumComboBox formatEnumComboBox;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button cancelButton;
		private ColoredGroupBox coloredGroupBox1;
	}
}