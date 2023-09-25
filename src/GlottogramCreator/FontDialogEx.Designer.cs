namespace WinFormsApp1
{
	partial class FontDialogEx
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
			System.Windows.Forms.Label fontNameLabel;
			System.Windows.Forms.TableLayoutPanel fontNameTableLayoutPanel;
			System.Windows.Forms.TableLayoutPanel fontStyleTableLayoutPanel;
			System.Windows.Forms.Label fontStyleLabel;
			System.Windows.Forms.TableLayoutPanel fontSizeTableLayoutPanel;
			System.Windows.Forms.Label fontSizeLabel;
			System.Windows.Forms.Label fontColorLabel;
			System.Windows.Forms.TableLayoutPanel fontColorTableLayoutPanel;
			System.Windows.Forms.TableLayoutPanel optionTableLayoutPanel;
			System.Windows.Forms.TableLayoutPanel sampleTableLayoutPanel;
			System.Windows.Forms.TableLayoutPanel buttonTableLayoutPanel;
			System.Windows.Forms.TableLayoutPanel topTableLayoutPanel;
			System.Windows.Forms.TableLayoutPanel bottomTableLayoutPanel;
			System.Windows.Forms.TableLayoutPanel allTableLayoutPanel;
			this.fontNameListBox = new System.Windows.Forms.ListBox();
			this.fontNameTextBox = new System.Windows.Forms.TextBox();
			this.fontStyleTextBox = new System.Windows.Forms.TextBox();
			this.fontStyleListBox = new System.Windows.Forms.ListBox();
			this.fontSizeListBox = new System.Windows.Forms.ListBox();
			this.fontSizeNumberBox = new WinFormsApp1.NumberBox();
			this.fontColorButton = new WinFormsApp1.ColorButton();
			this.strikeoutCheckBox = new System.Windows.Forms.CheckBox();
			this.underlineCheckBox = new System.Windows.Forms.CheckBox();
			this.sampleLabel = new System.Windows.Forms.Label();
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.coloredGroupBox2 = new WinFormsApp1.ColoredGroupBox();
			this.coloredGroupBox1 = new WinFormsApp1.ColoredGroupBox();
			this.fontDialog1 = new System.Windows.Forms.FontDialog();
			fontNameLabel = new System.Windows.Forms.Label();
			fontNameTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			fontStyleTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			fontStyleLabel = new System.Windows.Forms.Label();
			fontSizeTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			fontSizeLabel = new System.Windows.Forms.Label();
			fontColorLabel = new System.Windows.Forms.Label();
			fontColorTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			optionTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			sampleTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			buttonTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			topTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			bottomTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			allTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			fontNameTableLayoutPanel.SuspendLayout();
			fontStyleTableLayoutPanel.SuspendLayout();
			fontSizeTableLayoutPanel.SuspendLayout();
			fontColorTableLayoutPanel.SuspendLayout();
			optionTableLayoutPanel.SuspendLayout();
			sampleTableLayoutPanel.SuspendLayout();
			buttonTableLayoutPanel.SuspendLayout();
			topTableLayoutPanel.SuspendLayout();
			bottomTableLayoutPanel.SuspendLayout();
			this.coloredGroupBox2.SuspendLayout();
			this.coloredGroupBox1.SuspendLayout();
			allTableLayoutPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// fontNameLabel
			// 
			fontNameLabel.AutoSize = true;
			fontNameLabel.Location = new System.Drawing.Point(3, 0);
			fontNameLabel.Name = "fontNameLabel";
			fontNameLabel.Size = new System.Drawing.Size(69, 15);
			fontNameLabel.TabIndex = 0;
			fontNameLabel.Text = "フォント名(&F):";
			// 
			// fontNameTableLayoutPanel
			// 
			fontNameTableLayoutPanel.AutoSize = true;
			fontNameTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			fontNameTableLayoutPanel.ColumnCount = 1;
			fontNameTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			fontNameTableLayoutPanel.Controls.Add(this.fontNameListBox, 0, 2);
			fontNameTableLayoutPanel.Controls.Add(fontNameLabel, 0, 0);
			fontNameTableLayoutPanel.Controls.Add(this.fontNameTextBox, 0, 1);
			fontNameTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			fontNameTableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			fontNameTableLayoutPanel.Location = new System.Drawing.Point(3, 3);
			fontNameTableLayoutPanel.Name = "fontNameTableLayoutPanel";
			fontNameTableLayoutPanel.RowCount = 3;
			fontNameTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			fontNameTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			fontNameTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			fontNameTableLayoutPanel.Size = new System.Drawing.Size(208, 132);
			fontNameTableLayoutPanel.TabIndex = 3;
			// 
			// fontNameListBox
			// 
			this.fontNameListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.fontNameListBox.FormattingEnabled = true;
			this.fontNameListBox.ItemHeight = 15;
			this.fontNameListBox.Location = new System.Drawing.Point(0, 38);
			this.fontNameListBox.Margin = new System.Windows.Forms.Padding(0);
			this.fontNameListBox.Name = "fontNameListBox";
			this.fontNameListBox.ScrollAlwaysVisible = true;
			this.fontNameListBox.Size = new System.Drawing.Size(208, 94);
			this.fontNameListBox.TabIndex = 2;
			// 
			// fontNameTextBox
			// 
			this.fontNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.fontNameTextBox.Enabled = false;
			this.fontNameTextBox.Location = new System.Drawing.Point(0, 15);
			this.fontNameTextBox.Margin = new System.Windows.Forms.Padding(0);
			this.fontNameTextBox.Name = "fontNameTextBox";
			this.fontNameTextBox.Size = new System.Drawing.Size(208, 23);
			this.fontNameTextBox.TabIndex = 1;
			// 
			// fontStyleTableLayoutPanel
			// 
			fontStyleTableLayoutPanel.AutoSize = true;
			fontStyleTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			fontStyleTableLayoutPanel.ColumnCount = 1;
			fontStyleTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			fontStyleTableLayoutPanel.Controls.Add(fontStyleLabel, 0, 0);
			fontStyleTableLayoutPanel.Controls.Add(this.fontStyleTextBox, 0, 1);
			fontStyleTableLayoutPanel.Controls.Add(this.fontStyleListBox, 0, 2);
			fontStyleTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			fontStyleTableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			fontStyleTableLayoutPanel.Location = new System.Drawing.Point(217, 3);
			fontStyleTableLayoutPanel.Name = "fontStyleTableLayoutPanel";
			fontStyleTableLayoutPanel.RowCount = 3;
			fontStyleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			fontStyleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			fontStyleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			fontStyleTableLayoutPanel.Size = new System.Drawing.Size(150, 132);
			fontStyleTableLayoutPanel.TabIndex = 4;
			// 
			// fontStyleLabel
			// 
			fontStyleLabel.AutoSize = true;
			fontStyleLabel.Location = new System.Drawing.Point(3, 0);
			fontStyleLabel.Name = "fontStyleLabel";
			fontStyleLabel.Size = new System.Drawing.Size(62, 15);
			fontStyleLabel.TabIndex = 0;
			fontStyleLabel.Text = "スタイル(&Y):";
			// 
			// fontStyleTextBox
			// 
			this.fontStyleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.fontStyleTextBox.Enabled = false;
			this.fontStyleTextBox.Location = new System.Drawing.Point(0, 15);
			this.fontStyleTextBox.Margin = new System.Windows.Forms.Padding(0);
			this.fontStyleTextBox.Name = "fontStyleTextBox";
			this.fontStyleTextBox.Size = new System.Drawing.Size(150, 23);
			this.fontStyleTextBox.TabIndex = 1;
			// 
			// fontStyleListBox
			// 
			this.fontStyleListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.fontStyleListBox.FormattingEnabled = true;
			this.fontStyleListBox.ItemHeight = 15;
			this.fontStyleListBox.Location = new System.Drawing.Point(0, 38);
			this.fontStyleListBox.Margin = new System.Windows.Forms.Padding(0);
			this.fontStyleListBox.Name = "fontStyleListBox";
			this.fontStyleListBox.ScrollAlwaysVisible = true;
			this.fontStyleListBox.Size = new System.Drawing.Size(150, 94);
			this.fontStyleListBox.TabIndex = 2;
			// 
			// fontSizeTableLayoutPanel
			// 
			fontSizeTableLayoutPanel.AutoSize = true;
			fontSizeTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			fontSizeTableLayoutPanel.ColumnCount = 1;
			fontSizeTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			fontSizeTableLayoutPanel.Controls.Add(fontSizeLabel, 0, 0);
			fontSizeTableLayoutPanel.Controls.Add(this.fontSizeListBox, 0, 2);
			fontSizeTableLayoutPanel.Controls.Add(this.fontSizeNumberBox, 0, 1);
			fontSizeTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			fontSizeTableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			fontSizeTableLayoutPanel.Location = new System.Drawing.Point(373, 3);
			fontSizeTableLayoutPanel.Name = "fontSizeTableLayoutPanel";
			fontSizeTableLayoutPanel.RowCount = 3;
			fontSizeTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			fontSizeTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			fontSizeTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			fontSizeTableLayoutPanel.Size = new System.Drawing.Size(83, 132);
			fontSizeTableLayoutPanel.TabIndex = 5;
			// 
			// fontSizeLabel
			// 
			fontSizeLabel.AutoSize = true;
			fontSizeLabel.Location = new System.Drawing.Point(3, 0);
			fontSizeLabel.Name = "fontSizeLabel";
			fontSizeLabel.Size = new System.Drawing.Size(52, 15);
			fontSizeLabel.TabIndex = 0;
			fontSizeLabel.Text = "サイズ(&S):";
			// 
			// fontSizeListBox
			// 
			this.fontSizeListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.fontSizeListBox.FormattingEnabled = true;
			this.fontSizeListBox.ItemHeight = 15;
			this.fontSizeListBox.Location = new System.Drawing.Point(0, 38);
			this.fontSizeListBox.Margin = new System.Windows.Forms.Padding(0);
			this.fontSizeListBox.Name = "fontSizeListBox";
			this.fontSizeListBox.ScrollAlwaysVisible = true;
			this.fontSizeListBox.Size = new System.Drawing.Size(83, 94);
			this.fontSizeListBox.TabIndex = 2;
			// 
			// fontSizeNumberBox
			// 
			this.fontSizeNumberBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.fontSizeNumberBox.DefaultValue = 1F;
			this.fontSizeNumberBox.EnableTextChanged = false;
			this.fontSizeNumberBox.Location = new System.Drawing.Point(0, 15);
			this.fontSizeNumberBox.Margin = new System.Windows.Forms.Padding(0);
			this.fontSizeNumberBox.Name = "fontSizeNumberBox";
			this.fontSizeNumberBox.Size = new System.Drawing.Size(83, 23);
			this.fontSizeNumberBox.TabIndex = 3;
			this.fontSizeNumberBox.TypeName = "Single";
			this.fontSizeNumberBox.Value = 1F;
			this.fontSizeNumberBox.ValueMax = 1000F;
			this.fontSizeNumberBox.ValueMin = 1F;
			// 
			// fontColorLabel
			// 
			fontColorLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
			fontColorLabel.AutoSize = true;
			fontColorLabel.Location = new System.Drawing.Point(3, 9);
			fontColorLabel.Name = "fontColorLabel";
			fontColorLabel.Size = new System.Drawing.Size(37, 15);
			fontColorLabel.TabIndex = 9;
			fontColorLabel.Text = "色(&C):";
			// 
			// fontColorTableLayoutPanel
			// 
			fontColorTableLayoutPanel.AutoSize = true;
			fontColorTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			fontColorTableLayoutPanel.ColumnCount = 2;
			fontColorTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			fontColorTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			fontColorTableLayoutPanel.Controls.Add(fontColorLabel, 0, 0);
			fontColorTableLayoutPanel.Controls.Add(this.fontColorButton, 1, 0);
			fontColorTableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			fontColorTableLayoutPanel.Location = new System.Drawing.Point(3, 53);
			fontColorTableLayoutPanel.Name = "fontColorTableLayoutPanel";
			fontColorTableLayoutPanel.RowCount = 1;
			fontColorTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			fontColorTableLayoutPanel.Size = new System.Drawing.Size(74, 33);
			fontColorTableLayoutPanel.TabIndex = 10;
			// 
			// fontColorButton
			// 
			this.fontColorButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.fontColorButton.AutoSize = true;
			this.fontColorButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.fontColorButton.BackColor = System.Drawing.Color.Black;
			this.fontColorButton.Color = System.Drawing.Color.Black;
			this.fontColorButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowFrame;
			this.fontColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.fontColorButton.Location = new System.Drawing.Point(46, 3);
			this.fontColorButton.Name = "fontColorButton";
			this.fontColorButton.Size = new System.Drawing.Size(25, 27);
			this.fontColorButton.TabIndex = 8;
			this.fontColorButton.Text = "  ";
			this.fontColorButton.UseVisualStyleBackColor = false;
			// 
			// optionTableLayoutPanel
			// 
			optionTableLayoutPanel.AutoSize = true;
			optionTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			optionTableLayoutPanel.ColumnCount = 1;
			optionTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			optionTableLayoutPanel.Controls.Add(fontColorTableLayoutPanel, 0, 2);
			optionTableLayoutPanel.Controls.Add(this.strikeoutCheckBox, 0, 0);
			optionTableLayoutPanel.Controls.Add(this.underlineCheckBox, 0, 1);
			optionTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			optionTableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			optionTableLayoutPanel.Location = new System.Drawing.Point(3, 19);
			optionTableLayoutPanel.Name = "optionTableLayoutPanel";
			optionTableLayoutPanel.RowCount = 3;
			optionTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			optionTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			optionTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			optionTableLayoutPanel.Size = new System.Drawing.Size(99, 102);
			optionTableLayoutPanel.TabIndex = 11;
			// 
			// strikeoutCheckBox
			// 
			this.strikeoutCheckBox.AutoSize = true;
			this.strikeoutCheckBox.Location = new System.Drawing.Point(3, 3);
			this.strikeoutCheckBox.Name = "strikeoutCheckBox";
			this.strikeoutCheckBox.Size = new System.Drawing.Size(93, 19);
			this.strikeoutCheckBox.TabIndex = 6;
			this.strikeoutCheckBox.Text = "取り消し線(&K)";
			this.strikeoutCheckBox.UseVisualStyleBackColor = true;
			// 
			// underlineCheckBox
			// 
			this.underlineCheckBox.AutoSize = true;
			this.underlineCheckBox.Location = new System.Drawing.Point(3, 28);
			this.underlineCheckBox.Name = "underlineCheckBox";
			this.underlineCheckBox.Size = new System.Drawing.Size(66, 19);
			this.underlineCheckBox.TabIndex = 7;
			this.underlineCheckBox.Text = "下線(&U)";
			this.underlineCheckBox.UseVisualStyleBackColor = true;
			// 
			// sampleTableLayoutPanel
			// 
			sampleTableLayoutPanel.ColumnCount = 1;
			sampleTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			sampleTableLayoutPanel.Controls.Add(this.sampleLabel, 0, 0);
			sampleTableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			sampleTableLayoutPanel.Location = new System.Drawing.Point(6, 22);
			sampleTableLayoutPanel.Name = "sampleTableLayoutPanel";
			sampleTableLayoutPanel.RowCount = 1;
			sampleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			sampleTableLayoutPanel.Size = new System.Drawing.Size(200, 80);
			sampleTableLayoutPanel.TabIndex = 15;
			// 
			// sampleLabel
			// 
			this.sampleLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.sampleLabel.AutoSize = true;
			this.sampleLabel.Location = new System.Drawing.Point(60, 32);
			this.sampleLabel.Name = "sampleLabel";
			this.sampleLabel.Size = new System.Drawing.Size(79, 15);
			this.sampleLabel.TabIndex = 13;
			this.sampleLabel.Text = "Aaあぁアァ亜宇";
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
			buttonTableLayoutPanel.Location = new System.Drawing.Point(462, 3);
			buttonTableLayoutPanel.Name = "buttonTableLayoutPanel";
			buttonTableLayoutPanel.RowCount = 2;
			buttonTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			buttonTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			buttonTableLayoutPanel.Size = new System.Drawing.Size(69, 62);
			buttonTableLayoutPanel.TabIndex = 17;
			// 
			// okButton
			// 
			this.okButton.AutoSize = true;
			this.okButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.okButton.Location = new System.Drawing.Point(3, 3);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(63, 25);
			this.okButton.TabIndex = 15;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			// 
			// cancelButton
			// 
			this.cancelButton.AutoSize = true;
			this.cancelButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cancelButton.Location = new System.Drawing.Point(3, 34);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(63, 25);
			this.cancelButton.TabIndex = 16;
			this.cancelButton.Text = "キャンセル";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// topTableLayoutPanel
			// 
			topTableLayoutPanel.AutoSize = true;
			topTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			topTableLayoutPanel.ColumnCount = 4;
			topTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			topTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			topTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			topTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			topTableLayoutPanel.Controls.Add(fontSizeTableLayoutPanel, 2, 0);
			topTableLayoutPanel.Controls.Add(fontStyleTableLayoutPanel, 1, 0);
			topTableLayoutPanel.Controls.Add(buttonTableLayoutPanel, 3, 0);
			topTableLayoutPanel.Controls.Add(fontNameTableLayoutPanel, 0, 0);
			topTableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			topTableLayoutPanel.Location = new System.Drawing.Point(3, 3);
			topTableLayoutPanel.Name = "topTableLayoutPanel";
			topTableLayoutPanel.RowCount = 1;
			topTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			topTableLayoutPanel.Size = new System.Drawing.Size(534, 138);
			topTableLayoutPanel.TabIndex = 18;
			// 
			// bottomTableLayoutPanel
			// 
			bottomTableLayoutPanel.AutoSize = true;
			bottomTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			bottomTableLayoutPanel.ColumnCount = 2;
			bottomTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			bottomTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			bottomTableLayoutPanel.Controls.Add(this.coloredGroupBox2, 1, 0);
			bottomTableLayoutPanel.Controls.Add(this.coloredGroupBox1, 0, 0);
			bottomTableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			bottomTableLayoutPanel.Location = new System.Drawing.Point(3, 147);
			bottomTableLayoutPanel.Name = "bottomTableLayoutPanel";
			bottomTableLayoutPanel.RowCount = 1;
			bottomTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			bottomTableLayoutPanel.Size = new System.Drawing.Size(329, 130);
			bottomTableLayoutPanel.TabIndex = 19;
			// 
			// coloredGroupBox2
			// 
			this.coloredGroupBox2.AutoSize = true;
			this.coloredGroupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.coloredGroupBox2.Controls.Add(sampleTableLayoutPanel);
			this.coloredGroupBox2.Location = new System.Drawing.Point(114, 3);
			this.coloredGroupBox2.Name = "coloredGroupBox2";
			this.coloredGroupBox2.Size = new System.Drawing.Size(212, 124);
			this.coloredGroupBox2.TabIndex = 14;
			this.coloredGroupBox2.TabStop = false;
			this.coloredGroupBox2.Text = "サンプル";
			// 
			// coloredGroupBox1
			// 
			this.coloredGroupBox1.AutoSize = true;
			this.coloredGroupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.coloredGroupBox1.Controls.Add(optionTableLayoutPanel);
			this.coloredGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.coloredGroupBox1.Location = new System.Drawing.Point(3, 3);
			this.coloredGroupBox1.Name = "coloredGroupBox1";
			this.coloredGroupBox1.Size = new System.Drawing.Size(105, 124);
			this.coloredGroupBox1.TabIndex = 12;
			this.coloredGroupBox1.TabStop = false;
			this.coloredGroupBox1.Text = "文字飾り";
			// 
			// allTableLayoutPanel
			// 
			allTableLayoutPanel.AutoSize = true;
			allTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			allTableLayoutPanel.ColumnCount = 1;
			allTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			allTableLayoutPanel.Controls.Add(bottomTableLayoutPanel, 0, 1);
			allTableLayoutPanel.Controls.Add(topTableLayoutPanel, 0, 0);
			allTableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			allTableLayoutPanel.Location = new System.Drawing.Point(12, 12);
			allTableLayoutPanel.Name = "allTableLayoutPanel";
			allTableLayoutPanel.RowCount = 2;
			allTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			allTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			allTableLayoutPanel.Size = new System.Drawing.Size(540, 280);
			allTableLayoutPanel.TabIndex = 20;
			// 
			// FontDialogEx
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(allTableLayoutPanel);
			this.Name = "FontDialogEx";
			this.Text = "FontDialogEx";
			this.Load += new System.EventHandler(this.Load_Event);
			fontNameTableLayoutPanel.ResumeLayout(false);
			fontNameTableLayoutPanel.PerformLayout();
			fontStyleTableLayoutPanel.ResumeLayout(false);
			fontStyleTableLayoutPanel.PerformLayout();
			fontSizeTableLayoutPanel.ResumeLayout(false);
			fontSizeTableLayoutPanel.PerformLayout();
			fontColorTableLayoutPanel.ResumeLayout(false);
			fontColorTableLayoutPanel.PerformLayout();
			optionTableLayoutPanel.ResumeLayout(false);
			optionTableLayoutPanel.PerformLayout();
			sampleTableLayoutPanel.ResumeLayout(false);
			sampleTableLayoutPanel.PerformLayout();
			buttonTableLayoutPanel.ResumeLayout(false);
			buttonTableLayoutPanel.PerformLayout();
			topTableLayoutPanel.ResumeLayout(false);
			topTableLayoutPanel.PerformLayout();
			bottomTableLayoutPanel.ResumeLayout(false);
			bottomTableLayoutPanel.PerformLayout();
			this.coloredGroupBox2.ResumeLayout(false);
			this.coloredGroupBox1.ResumeLayout(false);
			this.coloredGroupBox1.PerformLayout();
			allTableLayoutPanel.ResumeLayout(false);
			allTableLayoutPanel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.FontDialog fontDialog1;
		private System.Windows.Forms.TextBox fontNameTextBox;
		private System.Windows.Forms.ListBox fontNameListBox;
		private System.Windows.Forms.TextBox fontStyleTextBox;
		private System.Windows.Forms.ListBox fontStyleListBox;
		private System.Windows.Forms.ListBox fontSizeListBox;
		private NumberBox fontSizeNumberBox;
		private System.Windows.Forms.CheckBox strikeoutCheckBox;
		private System.Windows.Forms.CheckBox underlineCheckBox;
		private ColorButton fontColorButton;
		private ColoredGroupBox coloredGroupBox1;
		private System.Windows.Forms.Label sampleLabel;
		private ColoredGroupBox coloredGroupBox2;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button cancelButton;
	}
}