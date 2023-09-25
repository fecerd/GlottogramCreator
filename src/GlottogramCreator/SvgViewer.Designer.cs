
namespace WinFormsApp1
{
	partial class SvgViewer
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
			System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
			System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
			System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
			System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
			System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
			System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.colorButton = new WinFormsApp1.ColorButton();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.scaleBox = new WinFormsApp1.NumberBox();
			this.label9 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.horizontalInversionCheckBox = new System.Windows.Forms.CheckBox();
			this.verticalInversionCheckBox = new System.Windows.Forms.CheckBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.angleBox = new WinFormsApp1.NumberBox();
			this.submitButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.resetButton = new System.Windows.Forms.Button();
			this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
			tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
			tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
			tableLayoutPanel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox4.SuspendLayout();
			tableLayoutPanel2.SuspendLayout();
			this.groupBox2.SuspendLayout();
			tableLayoutPanel3.SuspendLayout();
			this.groupBox3.SuspendLayout();
			tableLayoutPanel5.SuspendLayout();
			this.tableLayoutPanel4.SuspendLayout();
			tableLayoutPanel6.SuspendLayout();
			tableLayoutPanel8.SuspendLayout();
			this.tableLayoutPanel7.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.AutoSize = true;
			tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			tableLayoutPanel1.ColumnCount = 2;
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
			tableLayoutPanel1.Controls.Add(this.groupBox4, 1, 0);
			tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
			tableLayoutPanel1.Controls.Add(this.groupBox3, 1, 1);
			tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			tableLayoutPanel1.Location = new System.Drawing.Point(140, 3);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 2;
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel1.Size = new System.Drawing.Size(251, 137);
			tableLayoutPanel1.TabIndex = 8;
			// 
			// groupBox1
			// 
			this.groupBox1.AutoSize = true;
			this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBox1.Controls.Add(this.colorButton);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(2, 2);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
			this.groupBox1.Size = new System.Drawing.Size(82, 61);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "色設定";
			// 
			// colorButton
			// 
			this.colorButton.BackColor = System.Drawing.Color.Black;
			this.colorButton.Color = System.Drawing.Color.Black;
			this.colorButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowFrame;
			this.colorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.colorButton.Location = new System.Drawing.Point(16, 20);
			this.colorButton.Margin = new System.Windows.Forms.Padding(2);
			this.colorButton.Name = "colorButton";
			this.colorButton.Size = new System.Drawing.Size(35, 21);
			this.colorButton.TabIndex = 0;
			this.colorButton.UseVisualStyleBackColor = false;
			this.colorButton.Click += new System.EventHandler(this.ColorButton_Click);
			// 
			// groupBox4
			// 
			this.groupBox4.AutoSize = true;
			this.groupBox4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBox4.Controls.Add(tableLayoutPanel2);
			this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox4.Location = new System.Drawing.Point(88, 2);
			this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
			this.groupBox4.Size = new System.Drawing.Size(161, 61);
			this.groupBox4.TabIndex = 4;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "大きさ";
			// 
			// tableLayoutPanel2
			// 
			tableLayoutPanel2.AutoSize = true;
			tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			tableLayoutPanel2.ColumnCount = 2;
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel2.Controls.Add(this.scaleBox, 1, 0);
			tableLayoutPanel2.Controls.Add(this.label9, 0, 0);
			tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel2.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			tableLayoutPanel2.Location = new System.Drawing.Point(2, 18);
			tableLayoutPanel2.Name = "tableLayoutPanel2";
			tableLayoutPanel2.RowCount = 1;
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel2.Size = new System.Drawing.Size(157, 41);
			tableLayoutPanel2.TabIndex = 9;
			// 
			// scaleBox
			// 
			this.scaleBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.scaleBox.DefaultValue = 0F;
			this.scaleBox.EnableTextChanged = false;
			this.scaleBox.Location = new System.Drawing.Point(49, 9);
			this.scaleBox.Margin = new System.Windows.Forms.Padding(2);
			this.scaleBox.Name = "scaleBox";
			this.scaleBox.Size = new System.Drawing.Size(64, 23);
			this.scaleBox.TabIndex = 0;
			this.scaleBox.TypeName = "Single";
			this.scaleBox.Value = 1F;
			this.scaleBox.ValueMax = 2.147484E+09F;
			this.scaleBox.ValueMin = 0.1F;
			this.scaleBox.TextChanged += new System.EventHandler(this.NumberBox_TextChanged);
			this.scaleBox.Leave += new System.EventHandler(this.NumberBox_Leave);
			// 
			// label9
			// 
			this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(2, 13);
			this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(43, 15);
			this.label9.TabIndex = 13;
			this.label9.Text = "倍率：";
			// 
			// groupBox2
			// 
			this.groupBox2.AutoSize = true;
			this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBox2.Controls.Add(tableLayoutPanel3);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(2, 67);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
			this.groupBox2.Size = new System.Drawing.Size(82, 68);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "反転";
			// 
			// tableLayoutPanel3
			// 
			tableLayoutPanel3.AutoSize = true;
			tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			tableLayoutPanel3.ColumnCount = 1;
			tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel3.Controls.Add(this.horizontalInversionCheckBox, 0, 1);
			tableLayoutPanel3.Controls.Add(this.verticalInversionCheckBox, 0, 0);
			tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel3.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			tableLayoutPanel3.Location = new System.Drawing.Point(2, 18);
			tableLayoutPanel3.Name = "tableLayoutPanel3";
			tableLayoutPanel3.RowCount = 2;
			tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel3.Size = new System.Drawing.Size(78, 48);
			tableLayoutPanel3.TabIndex = 9;
			// 
			// horizontalInversionCheckBox
			// 
			this.horizontalInversionCheckBox.AutoSize = true;
			this.horizontalInversionCheckBox.Location = new System.Drawing.Point(2, 25);
			this.horizontalInversionCheckBox.Margin = new System.Windows.Forms.Padding(2);
			this.horizontalInversionCheckBox.Name = "horizontalInversionCheckBox";
			this.horizontalInversionCheckBox.Size = new System.Drawing.Size(74, 19);
			this.horizontalInversionCheckBox.TabIndex = 1;
			this.horizontalInversionCheckBox.Text = "左右反転";
			this.horizontalInversionCheckBox.UseVisualStyleBackColor = true;
			this.horizontalInversionCheckBox.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
			// 
			// verticalInversionCheckBox
			// 
			this.verticalInversionCheckBox.AutoSize = true;
			this.verticalInversionCheckBox.Location = new System.Drawing.Point(2, 2);
			this.verticalInversionCheckBox.Margin = new System.Windows.Forms.Padding(2);
			this.verticalInversionCheckBox.Name = "verticalInversionCheckBox";
			this.verticalInversionCheckBox.Size = new System.Drawing.Size(74, 19);
			this.verticalInversionCheckBox.TabIndex = 0;
			this.verticalInversionCheckBox.Text = "上下反転";
			this.verticalInversionCheckBox.UseVisualStyleBackColor = true;
			this.verticalInversionCheckBox.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
			// 
			// groupBox3
			// 
			this.groupBox3.AutoSize = true;
			this.groupBox3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBox3.Controls.Add(tableLayoutPanel5);
			this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox3.Location = new System.Drawing.Point(88, 67);
			this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
			this.groupBox3.Size = new System.Drawing.Size(161, 68);
			this.groupBox3.TabIndex = 6;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "回転";
			// 
			// tableLayoutPanel5
			// 
			tableLayoutPanel5.AutoSize = true;
			tableLayoutPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			tableLayoutPanel5.ColumnCount = 1;
			tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel5.Controls.Add(this.label6, 0, 1);
			tableLayoutPanel5.Controls.Add(this.tableLayoutPanel4, 0, 0);
			tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel5.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			tableLayoutPanel5.Location = new System.Drawing.Point(2, 18);
			tableLayoutPanel5.Name = "tableLayoutPanel5";
			tableLayoutPanel5.RowCount = 2;
			tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel5.Size = new System.Drawing.Size(157, 48);
			tableLayoutPanel5.TabIndex = 10;
			// 
			// label6
			// 
			this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(2, 33);
			this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(105, 15);
			this.label6.TabIndex = 15;
			this.label6.Text = "(範囲：0.0～360.0)";
			// 
			// tableLayoutPanel4
			// 
			this.tableLayoutPanel4.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.tableLayoutPanel4.AutoSize = true;
			this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel4.ColumnCount = 3;
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel4.Controls.Add(this.label4, 0, 0);
			this.tableLayoutPanel4.Controls.Add(this.label5, 2, 0);
			this.tableLayoutPanel4.Controls.Add(this.angleBox, 1, 0);
			this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 1;
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel4.Size = new System.Drawing.Size(151, 27);
			this.tableLayoutPanel4.TabIndex = 9;
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(2, 6);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(43, 15);
			this.label4.TabIndex = 13;
			this.label4.Text = "度数：";
			// 
			// label5
			// 
			this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(117, 6);
			this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(32, 15);
			this.label5.TabIndex = 14;
			this.label5.Text = "度(°)";
			// 
			// angleBox
			// 
			this.angleBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.angleBox.DefaultValue = 0F;
			this.angleBox.EnableTextChanged = false;
			this.angleBox.Location = new System.Drawing.Point(49, 2);
			this.angleBox.Margin = new System.Windows.Forms.Padding(2);
			this.angleBox.Name = "angleBox";
			this.angleBox.Size = new System.Drawing.Size(64, 23);
			this.angleBox.TabIndex = 0;
			this.angleBox.TypeName = "Single";
			this.angleBox.Value = 0F;
			this.angleBox.ValueMax = 360F;
			this.angleBox.ValueMin = 0F;
			this.angleBox.TextChanged += new System.EventHandler(this.NumberBox_TextChanged);
			this.angleBox.Leave += new System.EventHandler(this.NumberBox_Leave);
			// 
			// tableLayoutPanel6
			// 
			tableLayoutPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			tableLayoutPanel6.AutoSize = true;
			tableLayoutPanel6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			tableLayoutPanel6.ColumnCount = 3;
			tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel6.Controls.Add(this.submitButton, 0, 0);
			tableLayoutPanel6.Controls.Add(this.cancelButton, 1, 0);
			tableLayoutPanel6.Controls.Add(this.resetButton, 2, 0);
			tableLayoutPanel6.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			tableLayoutPanel6.Location = new System.Drawing.Point(623, 111);
			tableLayoutPanel6.Name = "tableLayoutPanel6";
			tableLayoutPanel6.RowCount = 1;
			tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel6.Size = new System.Drawing.Size(167, 29);
			tableLayoutPanel6.TabIndex = 9;
			// 
			// submitButton
			// 
			this.submitButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.submitButton.AutoSize = true;
			this.submitButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.submitButton.Location = new System.Drawing.Point(2, 2);
			this.submitButton.Margin = new System.Windows.Forms.Padding(2);
			this.submitButton.Name = "submitButton";
			this.submitButton.Size = new System.Drawing.Size(41, 25);
			this.submitButton.TabIndex = 7;
			this.submitButton.Text = "決定";
			this.submitButton.UseVisualStyleBackColor = true;
			this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.cancelButton.AutoSize = true;
			this.cancelButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.cancelButton.Location = new System.Drawing.Point(47, 2);
			this.cancelButton.Margin = new System.Windows.Forms.Padding(2);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(63, 25);
			this.cancelButton.TabIndex = 0;
			this.cancelButton.Text = "キャンセル";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// resetButton
			// 
			this.resetButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.resetButton.AutoSize = true;
			this.resetButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.resetButton.Location = new System.Drawing.Point(114, 2);
			this.resetButton.Margin = new System.Windows.Forms.Padding(2);
			this.resetButton.Name = "resetButton";
			this.resetButton.Size = new System.Drawing.Size(51, 25);
			this.resetButton.TabIndex = 1;
			this.resetButton.Text = "リセット";
			this.resetButton.UseVisualStyleBackColor = true;
			this.resetButton.Click += new System.EventHandler(this.ResetButton_Click);
			// 
			// tableLayoutPanel8
			// 
			tableLayoutPanel8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			tableLayoutPanel8.AutoSize = true;
			tableLayoutPanel8.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			tableLayoutPanel8.ColumnCount = 1;
			tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel8.Controls.Add(this.tableLayoutPanel7, 0, 1);
			tableLayoutPanel8.Controls.Add(this.dataGridView1, 0, 0);
			tableLayoutPanel8.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			tableLayoutPanel8.Location = new System.Drawing.Point(12, 12);
			tableLayoutPanel8.Name = "tableLayoutPanel8";
			tableLayoutPanel8.RowCount = 2;
			tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel8.Size = new System.Drawing.Size(799, 444);
			tableLayoutPanel8.TabIndex = 11;
			// 
			// tableLayoutPanel7
			// 
			this.tableLayoutPanel7.AutoSize = true;
			this.tableLayoutPanel7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel7.ColumnCount = 3;
			this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel7.Controls.Add(tableLayoutPanel6, 2, 0);
			this.tableLayoutPanel7.Controls.Add(this.panel1, 0, 0);
			this.tableLayoutPanel7.Controls.Add(tableLayoutPanel1, 1, 0);
			this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 298);
			this.tableLayoutPanel7.Name = "tableLayoutPanel7";
			this.tableLayoutPanel7.RowCount = 1;
			this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel7.Size = new System.Drawing.Size(793, 143);
			this.tableLayoutPanel7.TabIndex = 10;
			// 
			// panel1
			// 
			this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.panel1.BackColor = System.Drawing.SystemColors.Window;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Location = new System.Drawing.Point(2, 10);
			this.panel1.Margin = new System.Windows.Forms.Padding(2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(133, 122);
			this.panel1.TabIndex = 2;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
			this.pictureBox1.Location = new System.Drawing.Point(12, 11);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Padding = new System.Windows.Forms.Padding(2);
			this.pictureBox1.Size = new System.Drawing.Size(109, 100);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToResizeColumns = false;
			this.dataGridView1.AllowUserToResizeRows = false;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.ColumnHeadersVisible = false;
			this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.dataGridView1.Location = new System.Drawing.Point(3, 3);
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.RowTemplate.Height = 25;
			this.dataGridView1.ShowCellToolTips = false;
			this.dataGridView1.Size = new System.Drawing.Size(793, 289);
			this.dataGridView1.TabIndex = 2;
			this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
			// 
			// SvgViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(817, 466);
			this.Controls.Add(tableLayoutPanel8);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SvgViewer";
			this.Text = "記号選択";
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			tableLayoutPanel2.ResumeLayout(false);
			tableLayoutPanel2.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			tableLayoutPanel3.ResumeLayout(false);
			tableLayoutPanel3.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			tableLayoutPanel5.ResumeLayout(false);
			tableLayoutPanel5.PerformLayout();
			this.tableLayoutPanel4.ResumeLayout(false);
			this.tableLayoutPanel4.PerformLayout();
			tableLayoutPanel6.ResumeLayout(false);
			tableLayoutPanel6.PerformLayout();
			tableLayoutPanel8.ResumeLayout(false);
			tableLayoutPanel8.PerformLayout();
			this.tableLayoutPanel7.ResumeLayout(false);
			this.tableLayoutPanel7.PerformLayout();
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox horizontalInversionCheckBox;
		private System.Windows.Forms.CheckBox verticalInversionCheckBox;
		private System.Windows.Forms.Button submitButton;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private NumberBox angleBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.GroupBox groupBox4;
		private NumberBox scaleBox;
		private System.Windows.Forms.Label label9;
		private ColorButton colorButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button resetButton;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
	}
}