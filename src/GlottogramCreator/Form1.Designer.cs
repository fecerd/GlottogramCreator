
namespace WinFormsApp1
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.TableLayoutPanel filterSettingTableLayoutPanel;
			System.Windows.Forms.TableLayoutPanel valueTableLayoutPanel;
			System.Windows.Forms.Label label13;
			System.Windows.Forms.TableLayoutPanel x_axisTableLayoutPanel;
			System.Windows.Forms.TableLayoutPanel y_axisTableLayoutPanel;
			System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
			System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
			System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
			System.Windows.Forms.TableLayoutPanel form1TableLayoutPanel;
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.TableLayoutPanel filterTableLayoutPanel;
			System.Windows.Forms.TableLayoutPanel panel2PaddingTableLayoutPanel;
			System.Windows.Forms.Panel selectedSymbolPanel;
			System.Windows.Forms.GroupBox selectedSymbolGroupBox;
			System.Windows.Forms.TableLayoutPanel selectedSymbolTableLayoutPanel;
			System.Windows.Forms.TableLayoutPanel selectedSymbolMemberAndParentTableLayoutPanel;
			System.Windows.Forms.TableLayoutPanel selectedSymbolConvertModeTableLayoutPanel;
			System.Windows.Forms.Panel symbolDataGridViewPanel;
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			this.filterAddButton = new System.Windows.Forms.Button();
			this.filterValueTextBox = new System.Windows.Forms.TextBox();
			this.filterTypeEnumComboBox = new WinFormsApp1.EnumComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.filterKeyComboBox = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.valueListBox = new System.Windows.Forms.ListBox();
			this.valueKeyBox = new System.Windows.Forms.ComboBox();
			this.addValueButton = new System.Windows.Forms.Button();
			this.x_axisTickBox = new WinFormsApp1.NumberBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.x_axisKeyBox = new System.Windows.Forms.ComboBox();
			this.x_axisViewOrderBox = new System.Windows.Forms.ComboBox();
			this.x_axisViewMaxBox = new WinFormsApp1.NumberBox();
			this.label10 = new System.Windows.Forms.Label();
			this.x_axisViewMinBox = new WinFormsApp1.NumberBox();
			this.label9 = new System.Windows.Forms.Label();
			this.x_axisSortKeyBox = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.y_axisTickBox = new WinFormsApp1.NumberBox();
			this.label16 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.y_axisKeyBox = new System.Windows.Forms.ComboBox();
			this.y_axisViewOrderBox = new System.Windows.Forms.ComboBox();
			this.y_axisViewMaxBox = new WinFormsApp1.NumberBox();
			this.label19 = new System.Windows.Forms.Label();
			this.y_axisViewMinBox = new WinFormsApp1.NumberBox();
			this.label18 = new System.Windows.Forms.Label();
			this.y_axisSortKeyBox = new System.Windows.Forms.ComboBox();
			this.label17 = new System.Windows.Forms.Label();
			this.selectedSymbolUngroupButton = new System.Windows.Forms.Button();
			this.selectedSymbolTypeTextBox = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.selectedSymbolCountTextBox = new System.Windows.Forms.TextBox();
			this.selectedSymbolViewCheckBox = new System.Windows.Forms.CheckBox();
			this.selectedSymbolValueTextBox = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.selectedSymbolPictureBox = new System.Windows.Forms.PictureBox();
			this.label8 = new System.Windows.Forms.Label();
			this.selectedSymbolElipsisRelatedYNumberBox = new WinFormsApp1.NumberBox();
			this.selectedSymbolElipsisPictureBox = new System.Windows.Forms.PictureBox();
			this.label22 = new System.Windows.Forms.Label();
			this.selectedSymbolElipsisEnabledCheckBox = new System.Windows.Forms.CheckBox();
			this.openForm2Button = new System.Windows.Forms.Button();
			this.coloredTabControl1 = new WinFormsApp1.ColoredTabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.panel1 = new System.Windows.Forms.Panel();
			this.mainDataGridView = new System.Windows.Forms.DataGridView();
			this.panel1PaddingTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.filterGroupBox = new System.Windows.Forms.GroupBox();
			this.filterAddGroupBox = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			this.selectedFilterGroupBox = new System.Windows.Forms.GroupBox();
			this.selectedFilterListBox = new System.Windows.Forms.ListBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.panel2 = new System.Windows.Forms.Panel();
			this.x_axisGroupBox = new System.Windows.Forms.GroupBox();
			this.valueGroupBox = new System.Windows.Forms.GroupBox();
			this.y_axisGroupBox = new System.Windows.Forms.GroupBox();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.panel3 = new System.Windows.Forms.Panel();
			this.selectedSymbolParentGroupBox = new System.Windows.Forms.GroupBox();
			this.selectedSymbolParentDataGridView = new WinFormsApp1.SymbolDataGridView();
			this.selectedSymbolMembersGroupBox = new System.Windows.Forms.GroupBox();
			this.selectedSymbolMembersDataGridView = new WinFormsApp1.SymbolDataGridView();
			this.selectedSymbolDataTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.selectedSymbolDataGroupBox = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.selectedSymbolCustomNameTextBox = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.selectedSymbolConvertModeEnumComboBox = new WinFormsApp1.EnumComboBox();
			this.symbolGroupBox = new System.Windows.Forms.GroupBox();
			this.symbolDataGridView = new WinFormsApp1.SymbolDataGridView();
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tSVFiletsvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveTSVFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveCSVFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadEditDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveEditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadSymbolDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportSymbolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dataGridViewContextMenuStrip = new WinFormsApp1.ContextMenuStripEx();
			this.splitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.iDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.selectedFilterContextMenuStrip = new WinFormsApp1.ContextMenuStripEx();
			this.selectedFilterDeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.valueListBoxMenu = new WinFormsApp1.ContextMenuStripEx();
			this.deleteKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			filterSettingTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			valueTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			label13 = new System.Windows.Forms.Label();
			x_axisTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			y_axisTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
			tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
			form1TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			filterTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			panel2PaddingTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			selectedSymbolPanel = new System.Windows.Forms.Panel();
			selectedSymbolGroupBox = new System.Windows.Forms.GroupBox();
			selectedSymbolTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			selectedSymbolMemberAndParentTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			selectedSymbolConvertModeTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			symbolDataGridViewPanel = new System.Windows.Forms.Panel();
			filterSettingTableLayoutPanel.SuspendLayout();
			valueTableLayoutPanel.SuspendLayout();
			x_axisTableLayoutPanel.SuspendLayout();
			y_axisTableLayoutPanel.SuspendLayout();
			tableLayoutPanel1.SuspendLayout();
			tableLayoutPanel9.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.selectedSymbolPictureBox)).BeginInit();
			tableLayoutPanel10.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.selectedSymbolElipsisPictureBox)).BeginInit();
			form1TableLayoutPanel.SuspendLayout();
			this.coloredTabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.mainDataGridView)).BeginInit();
			this.panel1PaddingTableLayoutPanel.SuspendLayout();
			this.filterGroupBox.SuspendLayout();
			filterTableLayoutPanel.SuspendLayout();
			this.filterAddGroupBox.SuspendLayout();
			this.selectedFilterGroupBox.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.panel2.SuspendLayout();
			panel2PaddingTableLayoutPanel.SuspendLayout();
			this.x_axisGroupBox.SuspendLayout();
			this.valueGroupBox.SuspendLayout();
			this.y_axisGroupBox.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.panel3.SuspendLayout();
			selectedSymbolPanel.SuspendLayout();
			selectedSymbolGroupBox.SuspendLayout();
			selectedSymbolTableLayoutPanel.SuspendLayout();
			selectedSymbolMemberAndParentTableLayoutPanel.SuspendLayout();
			this.selectedSymbolParentGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.selectedSymbolParentDataGridView)).BeginInit();
			this.selectedSymbolMembersGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.selectedSymbolMembersDataGridView)).BeginInit();
			this.selectedSymbolDataTableLayoutPanel.SuspendLayout();
			this.selectedSymbolDataGroupBox.SuspendLayout();
			this.groupBox3.SuspendLayout();
			selectedSymbolConvertModeTableLayoutPanel.SuspendLayout();
			symbolDataGridViewPanel.SuspendLayout();
			this.symbolGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.symbolDataGridView)).BeginInit();
			this.menuStrip.SuspendLayout();
			this.dataGridViewContextMenuStrip.SuspendLayout();
			this.selectedFilterContextMenuStrip.SuspendLayout();
			this.valueListBoxMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// filterSettingTableLayoutPanel
			// 
			filterSettingTableLayoutPanel.AutoSize = true;
			filterSettingTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			filterSettingTableLayoutPanel.ColumnCount = 6;
			filterSettingTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			filterSettingTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			filterSettingTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			filterSettingTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			filterSettingTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			filterSettingTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			filterSettingTableLayoutPanel.Controls.Add(this.filterAddButton, 5, 1);
			filterSettingTableLayoutPanel.Controls.Add(this.filterValueTextBox, 0, 1);
			filterSettingTableLayoutPanel.Controls.Add(this.filterTypeEnumComboBox, 2, 1);
			filterSettingTableLayoutPanel.Controls.Add(this.label1, 0, 0);
			filterSettingTableLayoutPanel.Controls.Add(this.filterKeyComboBox, 1, 0);
			filterSettingTableLayoutPanel.Controls.Add(this.label2, 5, 0);
			filterSettingTableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			filterSettingTableLayoutPanel.Location = new System.Drawing.Point(3, 18);
			filterSettingTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
			filterSettingTableLayoutPanel.Name = "filterSettingTableLayoutPanel";
			filterSettingTableLayoutPanel.RowCount = 2;
			filterSettingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			filterSettingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			filterSettingTableLayoutPanel.Size = new System.Drawing.Size(364, 56);
			filterSettingTableLayoutPanel.TabIndex = 1;
			// 
			// filterAddButton
			// 
			this.filterAddButton.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.filterAddButton.AutoSize = true;
			this.filterAddButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.filterAddButton.Location = new System.Drawing.Point(320, 29);
			this.filterAddButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.filterAddButton.Name = "filterAddButton";
			this.filterAddButton.Size = new System.Drawing.Size(41, 25);
			this.filterAddButton.TabIndex = 3;
			this.filterAddButton.Text = "追加";
			this.filterAddButton.UseVisualStyleBackColor = true;
			// 
			// filterValueTextBox
			// 
			this.filterValueTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
			filterSettingTableLayoutPanel.SetColumnSpan(this.filterValueTextBox, 2);
			this.filterValueTextBox.Location = new System.Drawing.Point(3, 30);
			this.filterValueTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.filterValueTextBox.Name = "filterValueTextBox";
			this.filterValueTextBox.Size = new System.Drawing.Size(137, 23);
			this.filterValueTextBox.TabIndex = 1;
			// 
			// filterTypeEnumComboBox
			// 
			this.filterTypeEnumComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
			filterSettingTableLayoutPanel.SetColumnSpan(this.filterTypeEnumComboBox, 3);
			this.filterTypeEnumComboBox.EnumName = "FilterType";
			this.filterTypeEnumComboBox.FormattingEnabled = true;
			this.filterTypeEnumComboBox.Location = new System.Drawing.Point(146, 30);
			this.filterTypeEnumComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.filterTypeEnumComboBox.Name = "filterTypeEnumComboBox";
			this.filterTypeEnumComboBox.SelectedEnumValue = null;
			this.filterTypeEnumComboBox.Size = new System.Drawing.Size(168, 23);
			this.filterTypeEnumComboBox.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(31, 15);
			this.label1.TabIndex = 9;
			this.label1.Text = "列：";
			// 
			// filterKeyComboBox
			// 
			this.filterKeyComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
			filterSettingTableLayoutPanel.SetColumnSpan(this.filterKeyComboBox, 4);
			this.filterKeyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.filterKeyComboBox.FormattingEnabled = true;
			this.filterKeyComboBox.Location = new System.Drawing.Point(43, 2);
			this.filterKeyComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.filterKeyComboBox.Name = "filterKeyComboBox";
			this.filterKeyComboBox.Size = new System.Drawing.Size(267, 23);
			this.filterKeyComboBox.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(320, 6);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(39, 15);
			this.label2.TabIndex = 10;
			this.label2.Text = "の値が";
			// 
			// valueTableLayoutPanel
			// 
			valueTableLayoutPanel.AutoSize = true;
			valueTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			valueTableLayoutPanel.ColumnCount = 4;
			valueTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			valueTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			valueTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			valueTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			valueTableLayoutPanel.Controls.Add(this.valueListBox, 1, 1);
			valueTableLayoutPanel.Controls.Add(this.valueKeyBox, 1, 0);
			valueTableLayoutPanel.Controls.Add(label13, 0, 0);
			valueTableLayoutPanel.Controls.Add(this.addValueButton, 3, 0);
			valueTableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			valueTableLayoutPanel.Location = new System.Drawing.Point(4, 20);
			valueTableLayoutPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			valueTableLayoutPanel.Name = "valueTableLayoutPanel";
			valueTableLayoutPanel.RowCount = 2;
			valueTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			valueTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			valueTableLayoutPanel.Size = new System.Drawing.Size(357, 142);
			valueTableLayoutPanel.TabIndex = 1;
			// 
			// valueListBox
			// 
			this.valueListBox.Anchor = System.Windows.Forms.AnchorStyles.None;
			valueTableLayoutPanel.SetColumnSpan(this.valueListBox, 3);
			this.valueListBox.FormattingEnabled = true;
			this.valueListBox.ItemHeight = 15;
			this.valueListBox.Location = new System.Drawing.Point(45, 31);
			this.valueListBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.valueListBox.Name = "valueListBox";
			this.valueListBox.ScrollAlwaysVisible = true;
			this.valueListBox.Size = new System.Drawing.Size(309, 109);
			this.valueListBox.TabIndex = 15;
			this.valueListBox.TabStop = false;
			// 
			// valueKeyBox
			// 
			this.valueKeyBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
			valueTableLayoutPanel.SetColumnSpan(this.valueKeyBox, 2);
			this.valueKeyBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.valueKeyBox.FormattingEnabled = true;
			this.valueKeyBox.Location = new System.Drawing.Point(45, 3);
			this.valueKeyBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.valueKeyBox.Name = "valueKeyBox";
			this.valueKeyBox.Size = new System.Drawing.Size(252, 23);
			this.valueKeyBox.TabIndex = 0;
			// 
			// label13
			// 
			label13.Anchor = System.Windows.Forms.AnchorStyles.Right;
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(3, 7);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(36, 15);
			label13.TabIndex = 29;
			label13.Text = "キー：";
			// 
			// addValueButton
			// 
			this.addValueButton.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.addValueButton.AutoSize = true;
			this.addValueButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.addValueButton.Location = new System.Drawing.Point(308, 2);
			this.addValueButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.addValueButton.Name = "addValueButton";
			this.addValueButton.Size = new System.Drawing.Size(41, 25);
			this.addValueButton.TabIndex = 1;
			this.addValueButton.Text = "追加";
			this.addValueButton.UseVisualStyleBackColor = true;
			// 
			// x_axisTableLayoutPanel
			// 
			x_axisTableLayoutPanel.AutoSize = true;
			x_axisTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			x_axisTableLayoutPanel.ColumnCount = 5;
			x_axisTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			x_axisTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			x_axisTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			x_axisTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			x_axisTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			x_axisTableLayoutPanel.Controls.Add(this.x_axisTickBox, 1, 3);
			x_axisTableLayoutPanel.Controls.Add(this.label3, 0, 0);
			x_axisTableLayoutPanel.Controls.Add(this.label14, 0, 3);
			x_axisTableLayoutPanel.Controls.Add(this.x_axisKeyBox, 1, 0);
			x_axisTableLayoutPanel.Controls.Add(this.x_axisViewOrderBox, 4, 2);
			x_axisTableLayoutPanel.Controls.Add(this.x_axisViewMaxBox, 3, 2);
			x_axisTableLayoutPanel.Controls.Add(this.label10, 2, 2);
			x_axisTableLayoutPanel.Controls.Add(this.x_axisViewMinBox, 1, 2);
			x_axisTableLayoutPanel.Controls.Add(this.label9, 0, 2);
			x_axisTableLayoutPanel.Controls.Add(this.x_axisSortKeyBox, 1, 1);
			x_axisTableLayoutPanel.Controls.Add(this.label4, 0, 1);
			x_axisTableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			x_axisTableLayoutPanel.Location = new System.Drawing.Point(3, 18);
			x_axisTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
			x_axisTableLayoutPanel.Name = "x_axisTableLayoutPanel";
			x_axisTableLayoutPanel.RowCount = 4;
			x_axisTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			x_axisTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			x_axisTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			x_axisTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			x_axisTableLayoutPanel.Size = new System.Drawing.Size(362, 108);
			x_axisTableLayoutPanel.TabIndex = 1;
			// 
			// x_axisTickBox
			// 
			this.x_axisTickBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.x_axisTickBox.DefaultValue = 1;
			this.x_axisTickBox.EnableTextChanged = false;
			this.x_axisTickBox.Location = new System.Drawing.Point(82, 83);
			this.x_axisTickBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.x_axisTickBox.Name = "x_axisTickBox";
			this.x_axisTickBox.Size = new System.Drawing.Size(85, 23);
			this.x_axisTickBox.TabIndex = 5;
			this.x_axisTickBox.Value = 1;
			this.x_axisTickBox.ValueMin = 1;
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(40, 6);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(36, 15);
			this.label3.TabIndex = 0;
			this.label3.Text = "キー：";
			// 
			// label14
			// 
			this.label14.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(13, 87);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(63, 15);
			this.label14.TabIndex = 23;
			this.label14.Text = "目盛り幅：";
			// 
			// x_axisKeyBox
			// 
			this.x_axisKeyBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
			x_axisTableLayoutPanel.SetColumnSpan(this.x_axisKeyBox, 4);
			this.x_axisKeyBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.x_axisKeyBox.FormattingEnabled = true;
			this.x_axisKeyBox.Location = new System.Drawing.Point(82, 2);
			this.x_axisKeyBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.x_axisKeyBox.Name = "x_axisKeyBox";
			this.x_axisKeyBox.Size = new System.Drawing.Size(274, 23);
			this.x_axisKeyBox.TabIndex = 0;
			// 
			// x_axisViewOrderBox
			// 
			this.x_axisViewOrderBox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.x_axisViewOrderBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.x_axisViewOrderBox.FormattingEnabled = true;
			this.x_axisViewOrderBox.Location = new System.Drawing.Point(289, 56);
			this.x_axisViewOrderBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.x_axisViewOrderBox.Name = "x_axisViewOrderBox";
			this.x_axisViewOrderBox.Size = new System.Drawing.Size(70, 23);
			this.x_axisViewOrderBox.TabIndex = 4;
			// 
			// x_axisViewMaxBox
			// 
			this.x_axisViewMaxBox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.x_axisViewMaxBox.EnableTextChanged = false;
			this.x_axisViewMaxBox.Location = new System.Drawing.Point(198, 56);
			this.x_axisViewMaxBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.x_axisViewMaxBox.Name = "x_axisViewMaxBox";
			this.x_axisViewMaxBox.Size = new System.Drawing.Size(85, 23);
			this.x_axisViewMaxBox.TabIndex = 3;
			this.x_axisViewMaxBox.Value = 0;
			// 
			// label10
			// 
			this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(173, 60);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(19, 15);
			this.label10.TabIndex = 22;
			this.label10.Text = "～";
			// 
			// x_axisViewMinBox
			// 
			this.x_axisViewMinBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.x_axisViewMinBox.EnableTextChanged = false;
			this.x_axisViewMinBox.Location = new System.Drawing.Point(82, 56);
			this.x_axisViewMinBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.x_axisViewMinBox.Name = "x_axisViewMinBox";
			this.x_axisViewMinBox.Size = new System.Drawing.Size(85, 23);
			this.x_axisViewMinBox.TabIndex = 2;
			this.x_axisViewMinBox.Value = 0;
			// 
			// label9
			// 
			this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(9, 60);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(67, 15);
			this.label9.TabIndex = 20;
			this.label9.Text = "表示範囲：";
			// 
			// x_axisSortKeyBox
			// 
			this.x_axisSortKeyBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
			x_axisTableLayoutPanel.SetColumnSpan(this.x_axisSortKeyBox, 4);
			this.x_axisSortKeyBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.x_axisSortKeyBox.FormattingEnabled = true;
			this.x_axisSortKeyBox.Location = new System.Drawing.Point(82, 29);
			this.x_axisSortKeyBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.x_axisSortKeyBox.Name = "x_axisSortKeyBox";
			this.x_axisSortKeyBox.Size = new System.Drawing.Size(274, 23);
			this.x_axisSortKeyBox.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 33);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(73, 15);
			this.label4.TabIndex = 2;
			this.label4.Text = "ソート用キー：";
			// 
			// y_axisTableLayoutPanel
			// 
			y_axisTableLayoutPanel.AutoSize = true;
			y_axisTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			y_axisTableLayoutPanel.ColumnCount = 5;
			y_axisTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			y_axisTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			y_axisTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			y_axisTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			y_axisTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			y_axisTableLayoutPanel.Controls.Add(this.y_axisTickBox, 1, 3);
			y_axisTableLayoutPanel.Controls.Add(this.label16, 0, 0);
			y_axisTableLayoutPanel.Controls.Add(this.label15, 0, 3);
			y_axisTableLayoutPanel.Controls.Add(this.y_axisKeyBox, 1, 0);
			y_axisTableLayoutPanel.Controls.Add(this.y_axisViewOrderBox, 4, 2);
			y_axisTableLayoutPanel.Controls.Add(this.y_axisViewMaxBox, 3, 2);
			y_axisTableLayoutPanel.Controls.Add(this.label19, 2, 2);
			y_axisTableLayoutPanel.Controls.Add(this.y_axisViewMinBox, 1, 2);
			y_axisTableLayoutPanel.Controls.Add(this.label18, 0, 2);
			y_axisTableLayoutPanel.Controls.Add(this.y_axisSortKeyBox, 1, 1);
			y_axisTableLayoutPanel.Controls.Add(this.label17, 0, 1);
			y_axisTableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			y_axisTableLayoutPanel.Location = new System.Drawing.Point(3, 18);
			y_axisTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
			y_axisTableLayoutPanel.Name = "y_axisTableLayoutPanel";
			y_axisTableLayoutPanel.RowCount = 4;
			y_axisTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			y_axisTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			y_axisTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			y_axisTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			y_axisTableLayoutPanel.Size = new System.Drawing.Size(362, 108);
			y_axisTableLayoutPanel.TabIndex = 3;
			// 
			// y_axisTickBox
			// 
			this.y_axisTickBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.y_axisTickBox.DefaultValue = 1;
			this.y_axisTickBox.EnableTextChanged = false;
			this.y_axisTickBox.Location = new System.Drawing.Point(82, 83);
			this.y_axisTickBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.y_axisTickBox.Name = "y_axisTickBox";
			this.y_axisTickBox.Size = new System.Drawing.Size(85, 23);
			this.y_axisTickBox.TabIndex = 5;
			this.y_axisTickBox.Value = 1;
			this.y_axisTickBox.ValueMin = 1;
			// 
			// label16
			// 
			this.label16.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(40, 6);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(36, 15);
			this.label16.TabIndex = 0;
			this.label16.Text = "キー：";
			// 
			// label15
			// 
			this.label15.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(13, 87);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(63, 15);
			this.label15.TabIndex = 23;
			this.label15.Text = "目盛り幅：";
			// 
			// y_axisKeyBox
			// 
			this.y_axisKeyBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
			y_axisTableLayoutPanel.SetColumnSpan(this.y_axisKeyBox, 4);
			this.y_axisKeyBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.y_axisKeyBox.FormattingEnabled = true;
			this.y_axisKeyBox.Location = new System.Drawing.Point(82, 2);
			this.y_axisKeyBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.y_axisKeyBox.Name = "y_axisKeyBox";
			this.y_axisKeyBox.Size = new System.Drawing.Size(273, 23);
			this.y_axisKeyBox.TabIndex = 0;
			// 
			// y_axisViewOrderBox
			// 
			this.y_axisViewOrderBox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.y_axisViewOrderBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.y_axisViewOrderBox.FormattingEnabled = true;
			this.y_axisViewOrderBox.Location = new System.Drawing.Point(289, 56);
			this.y_axisViewOrderBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.y_axisViewOrderBox.Name = "y_axisViewOrderBox";
			this.y_axisViewOrderBox.Size = new System.Drawing.Size(70, 23);
			this.y_axisViewOrderBox.TabIndex = 4;
			// 
			// y_axisViewMaxBox
			// 
			this.y_axisViewMaxBox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.y_axisViewMaxBox.EnableTextChanged = false;
			this.y_axisViewMaxBox.Location = new System.Drawing.Point(198, 56);
			this.y_axisViewMaxBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.y_axisViewMaxBox.Name = "y_axisViewMaxBox";
			this.y_axisViewMaxBox.Size = new System.Drawing.Size(85, 23);
			this.y_axisViewMaxBox.TabIndex = 3;
			this.y_axisViewMaxBox.Value = 0;
			// 
			// label19
			// 
			this.label19.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(173, 60);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(19, 15);
			this.label19.TabIndex = 22;
			this.label19.Text = "～";
			// 
			// y_axisViewMinBox
			// 
			this.y_axisViewMinBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.y_axisViewMinBox.EnableTextChanged = false;
			this.y_axisViewMinBox.Location = new System.Drawing.Point(82, 56);
			this.y_axisViewMinBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.y_axisViewMinBox.Name = "y_axisViewMinBox";
			this.y_axisViewMinBox.Size = new System.Drawing.Size(85, 23);
			this.y_axisViewMinBox.TabIndex = 2;
			this.y_axisViewMinBox.Value = 0;
			// 
			// label18
			// 
			this.label18.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(9, 60);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(67, 15);
			this.label18.TabIndex = 20;
			this.label18.Text = "表示範囲：";
			// 
			// y_axisSortKeyBox
			// 
			this.y_axisSortKeyBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
			y_axisTableLayoutPanel.SetColumnSpan(this.y_axisSortKeyBox, 4);
			this.y_axisSortKeyBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.y_axisSortKeyBox.FormattingEnabled = true;
			this.y_axisSortKeyBox.Location = new System.Drawing.Point(82, 29);
			this.y_axisSortKeyBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.y_axisSortKeyBox.Name = "y_axisSortKeyBox";
			this.y_axisSortKeyBox.Size = new System.Drawing.Size(273, 23);
			this.y_axisSortKeyBox.TabIndex = 1;
			// 
			// label17
			// 
			this.label17.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(3, 33);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(73, 15);
			this.label17.TabIndex = 2;
			this.label17.Text = "ソート用キー：";
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			tableLayoutPanel1.AutoSize = true;
			tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			tableLayoutPanel1.ColumnCount = 3;
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel1.Controls.Add(this.selectedSymbolUngroupButton, 2, 0);
			tableLayoutPanel1.Controls.Add(this.selectedSymbolTypeTextBox, 1, 0);
			tableLayoutPanel1.Controls.Add(this.label7, 0, 0);
			tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 1;
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel1.Size = new System.Drawing.Size(256, 29);
			tableLayoutPanel1.TabIndex = 31;
			// 
			// selectedSymbolUngroupButton
			// 
			this.selectedSymbolUngroupButton.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.selectedSymbolUngroupButton.AutoSize = true;
			this.selectedSymbolUngroupButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.selectedSymbolUngroupButton.Enabled = false;
			this.selectedSymbolUngroupButton.Location = new System.Drawing.Point(136, 2);
			this.selectedSymbolUngroupButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.selectedSymbolUngroupButton.Name = "selectedSymbolUngroupButton";
			this.selectedSymbolUngroupButton.Size = new System.Drawing.Size(117, 25);
			this.selectedSymbolUngroupButton.TabIndex = 0;
			this.selectedSymbolUngroupButton.Text = "グループ化を解除する";
			this.selectedSymbolUngroupButton.UseVisualStyleBackColor = true;
			// 
			// selectedSymbolTypeTextBox
			// 
			this.selectedSymbolTypeTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.selectedSymbolTypeTextBox.Enabled = false;
			this.selectedSymbolTypeTextBox.Location = new System.Drawing.Point(52, 3);
			this.selectedSymbolTypeTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.selectedSymbolTypeTextBox.Name = "selectedSymbolTypeTextBox";
			this.selectedSymbolTypeTextBox.Size = new System.Drawing.Size(78, 23);
			this.selectedSymbolTypeTextBox.TabIndex = 0;
			this.selectedSymbolTypeTextBox.TabStop = false;
			// 
			// label7
			// 
			this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(3, 7);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(43, 15);
			this.label7.TabIndex = 30;
			this.label7.Text = "種類：";
			// 
			// tableLayoutPanel9
			// 
			tableLayoutPanel9.AutoSize = true;
			tableLayoutPanel9.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			tableLayoutPanel9.ColumnCount = 3;
			tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel9.Controls.Add(this.selectedSymbolCountTextBox, 2, 2);
			tableLayoutPanel9.Controls.Add(this.selectedSymbolViewCheckBox, 1, 0);
			tableLayoutPanel9.Controls.Add(this.selectedSymbolValueTextBox, 2, 1);
			tableLayoutPanel9.Controls.Add(this.label11, 1, 2);
			tableLayoutPanel9.Controls.Add(this.selectedSymbolPictureBox, 0, 0);
			tableLayoutPanel9.Controls.Add(this.label8, 1, 1);
			tableLayoutPanel9.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			tableLayoutPanel9.Location = new System.Drawing.Point(3, 18);
			tableLayoutPanel9.Margin = new System.Windows.Forms.Padding(0);
			tableLayoutPanel9.Name = "tableLayoutPanel9";
			tableLayoutPanel9.RowCount = 3;
			tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel9.Size = new System.Drawing.Size(295, 77);
			tableLayoutPanel9.TabIndex = 1;
			// 
			// selectedSymbolCountTextBox
			// 
			this.selectedSymbolCountTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.selectedSymbolCountTextBox.Enabled = false;
			this.selectedSymbolCountTextBox.Location = new System.Drawing.Point(137, 52);
			this.selectedSymbolCountTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.selectedSymbolCountTextBox.Name = "selectedSymbolCountTextBox";
			this.selectedSymbolCountTextBox.Size = new System.Drawing.Size(155, 23);
			this.selectedSymbolCountTextBox.TabIndex = 2;
			this.selectedSymbolCountTextBox.TabStop = false;
			// 
			// selectedSymbolViewCheckBox
			// 
			this.selectedSymbolViewCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.selectedSymbolViewCheckBox.AutoSize = true;
			tableLayoutPanel9.SetColumnSpan(this.selectedSymbolViewCheckBox, 2);
			this.selectedSymbolViewCheckBox.Location = new System.Drawing.Point(88, 2);
			this.selectedSymbolViewCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.selectedSymbolViewCheckBox.Name = "selectedSymbolViewCheckBox";
			this.selectedSymbolViewCheckBox.Size = new System.Drawing.Size(69, 19);
			this.selectedSymbolViewCheckBox.TabIndex = 0;
			this.selectedSymbolViewCheckBox.Text = "表示する";
			this.selectedSymbolViewCheckBox.UseVisualStyleBackColor = true;
			// 
			// selectedSymbolValueTextBox
			// 
			this.selectedSymbolValueTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.selectedSymbolValueTextBox.Enabled = false;
			this.selectedSymbolValueTextBox.Location = new System.Drawing.Point(137, 25);
			this.selectedSymbolValueTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.selectedSymbolValueTextBox.Name = "selectedSymbolValueTextBox";
			this.selectedSymbolValueTextBox.Size = new System.Drawing.Size(155, 23);
			this.selectedSymbolValueTextBox.TabIndex = 1;
			// 
			// label11
			// 
			this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(88, 56);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(43, 15);
			this.label11.TabIndex = 33;
			this.label11.Text = "個数：";
			// 
			// selectedSymbolPictureBox
			// 
			this.selectedSymbolPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.selectedSymbolPictureBox.BackColor = System.Drawing.SystemColors.Window;
			this.selectedSymbolPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.selectedSymbolPictureBox.Location = new System.Drawing.Point(3, 2);
			this.selectedSymbolPictureBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.selectedSymbolPictureBox.Name = "selectedSymbolPictureBox";
			this.selectedSymbolPictureBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			tableLayoutPanel9.SetRowSpan(this.selectedSymbolPictureBox, 3);
			this.selectedSymbolPictureBox.Size = new System.Drawing.Size(79, 72);
			this.selectedSymbolPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.selectedSymbolPictureBox.TabIndex = 1;
			this.selectedSymbolPictureBox.TabStop = false;
			// 
			// label8
			// 
			this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(100, 29);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(31, 15);
			this.label8.TabIndex = 31;
			this.label8.Text = "値：";
			// 
			// tableLayoutPanel10
			// 
			tableLayoutPanel10.AutoSize = true;
			tableLayoutPanel10.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			tableLayoutPanel10.ColumnCount = 3;
			tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel10.Controls.Add(this.selectedSymbolElipsisRelatedYNumberBox, 2, 1);
			tableLayoutPanel10.Controls.Add(this.selectedSymbolElipsisPictureBox, 0, 0);
			tableLayoutPanel10.Controls.Add(this.label22, 1, 1);
			tableLayoutPanel10.Controls.Add(this.selectedSymbolElipsisEnabledCheckBox, 1, 0);
			tableLayoutPanel10.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			tableLayoutPanel10.Location = new System.Drawing.Point(3, 18);
			tableLayoutPanel10.Margin = new System.Windows.Forms.Padding(0);
			tableLayoutPanel10.Name = "tableLayoutPanel10";
			tableLayoutPanel10.RowCount = 3;
			tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel10.Size = new System.Drawing.Size(281, 76);
			tableLayoutPanel10.TabIndex = 39;
			// 
			// selectedSymbolElipsisRelatedYNumberBox
			// 
			this.selectedSymbolElipsisRelatedYNumberBox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.selectedSymbolElipsisRelatedYNumberBox.DefaultValue = 0F;
			this.selectedSymbolElipsisRelatedYNumberBox.EnableTextChanged = false;
			this.selectedSymbolElipsisRelatedYNumberBox.Location = new System.Drawing.Point(137, 25);
			this.selectedSymbolElipsisRelatedYNumberBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.selectedSymbolElipsisRelatedYNumberBox.Name = "selectedSymbolElipsisRelatedYNumberBox";
			this.selectedSymbolElipsisRelatedYNumberBox.Size = new System.Drawing.Size(141, 23);
			this.selectedSymbolElipsisRelatedYNumberBox.TabIndex = 1;
			this.selectedSymbolElipsisRelatedYNumberBox.TypeName = "Single";
			this.selectedSymbolElipsisRelatedYNumberBox.Value = 0F;
			this.selectedSymbolElipsisRelatedYNumberBox.ValueMax = 3.402823E+38F;
			this.selectedSymbolElipsisRelatedYNumberBox.ValueMin = -3.402823E+38F;
			// 
			// selectedSymbolElipsisPictureBox
			// 
			this.selectedSymbolElipsisPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.selectedSymbolElipsisPictureBox.BackColor = System.Drawing.SystemColors.Window;
			this.selectedSymbolElipsisPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.selectedSymbolElipsisPictureBox.Location = new System.Drawing.Point(3, 2);
			this.selectedSymbolElipsisPictureBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.selectedSymbolElipsisPictureBox.Name = "selectedSymbolElipsisPictureBox";
			this.selectedSymbolElipsisPictureBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			tableLayoutPanel10.SetRowSpan(this.selectedSymbolElipsisPictureBox, 3);
			this.selectedSymbolElipsisPictureBox.Size = new System.Drawing.Size(79, 72);
			this.selectedSymbolElipsisPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.selectedSymbolElipsisPictureBox.TabIndex = 1;
			this.selectedSymbolElipsisPictureBox.TabStop = false;
			// 
			// label22
			// 
			this.label22.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(88, 29);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(43, 15);
			this.label22.TabIndex = 31;
			this.label22.Text = "位置：";
			// 
			// selectedSymbolElipsisEnabledCheckBox
			// 
			this.selectedSymbolElipsisEnabledCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.selectedSymbolElipsisEnabledCheckBox.AutoSize = true;
			tableLayoutPanel10.SetColumnSpan(this.selectedSymbolElipsisEnabledCheckBox, 2);
			this.selectedSymbolElipsisEnabledCheckBox.Location = new System.Drawing.Point(88, 2);
			this.selectedSymbolElipsisEnabledCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.selectedSymbolElipsisEnabledCheckBox.Name = "selectedSymbolElipsisEnabledCheckBox";
			this.selectedSymbolElipsisEnabledCheckBox.Size = new System.Drawing.Size(126, 19);
			this.selectedSymbolElipsisEnabledCheckBox.TabIndex = 0;
			this.selectedSymbolElipsisEnabledCheckBox.Text = "省略記号を使用する";
			this.selectedSymbolElipsisEnabledCheckBox.UseVisualStyleBackColor = true;
			// 
			// form1TableLayoutPanel
			// 
			form1TableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			form1TableLayoutPanel.ColumnCount = 2;
			form1TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			form1TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			form1TableLayoutPanel.Controls.Add(this.openForm2Button, 1, 0);
			form1TableLayoutPanel.Controls.Add(this.coloredTabControl1, 0, 0);
			form1TableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			form1TableLayoutPanel.Location = new System.Drawing.Point(12, 28);
			form1TableLayoutPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			form1TableLayoutPanel.Name = "form1TableLayoutPanel";
			form1TableLayoutPanel.RowCount = 1;
			form1TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			form1TableLayoutPanel.Size = new System.Drawing.Size(1098, 389);
			form1TableLayoutPanel.TabIndex = 3;
			// 
			// openForm2Button
			// 
			this.openForm2Button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.openForm2Button.AutoSize = true;
			this.openForm2Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.openForm2Button.Location = new System.Drawing.Point(1009, 346);
			this.openForm2Button.Name = "openForm2Button";
			this.openForm2Button.Size = new System.Drawing.Size(86, 40);
			this.openForm2Button.TabIndex = 0;
			this.openForm2Button.Text = "グロットグラムを\r\n表示する";
			this.openForm2Button.UseVisualStyleBackColor = true;
			this.openForm2Button.Click += new System.EventHandler(this.button1_Click);
			// 
			// coloredTabControl1
			// 
			this.coloredTabControl1.Controls.Add(this.tabPage1);
			this.coloredTabControl1.Controls.Add(this.tabPage2);
			this.coloredTabControl1.Controls.Add(this.tabPage3);
			this.coloredTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.coloredTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
			this.coloredTabControl1.Location = new System.Drawing.Point(3, 2);
			this.coloredTabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.coloredTabControl1.Name = "coloredTabControl1";
			this.coloredTabControl1.SelectedIndex = 0;
			this.coloredTabControl1.Size = new System.Drawing.Size(1000, 385);
			this.coloredTabControl1.TabIndex = 1;
			// 
			// tabPage1
			// 
			this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
			this.tabPage1.Controls.Add(this.panel1);
			this.tabPage1.Location = new System.Drawing.Point(4, 24);
			this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(992, 357);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "データ";
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.Controls.Add(this.mainDataGridView);
			this.panel1.Controls.Add(this.panel1PaddingTableLayoutPanel);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(992, 357);
			this.panel1.TabIndex = 0;
			// 
			// mainDataGridView
			// 
			this.mainDataGridView.AllowUserToAddRows = false;
			this.mainDataGridView.AllowUserToDeleteRows = false;
			this.mainDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.mainDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.mainDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.mainDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.mainDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.mainDataGridView.Location = new System.Drawing.Point(3, 2);
			this.mainDataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.mainDataGridView.MultiSelect = false;
			this.mainDataGridView.Name = "mainDataGridView";
			this.mainDataGridView.ReadOnly = true;
			this.mainDataGridView.RowTemplate.Height = 25;
			this.mainDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.ColumnHeaderSelect;
			this.mainDataGridView.ShowCellToolTips = false;
			this.mainDataGridView.Size = new System.Drawing.Size(572, 352);
			this.mainDataGridView.TabIndex = 0;
			this.mainDataGridView.DataSourceChanged += new System.EventHandler(this.DataGridView_DataSourceChanged);
			this.mainDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridView_CellFormatting);
			// 
			// panel1PaddingTableLayoutPanel
			// 
			this.panel1PaddingTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1PaddingTableLayoutPanel.AutoSize = true;
			this.panel1PaddingTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panel1PaddingTableLayoutPanel.ColumnCount = 2;
			this.panel1PaddingTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.panel1PaddingTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.panel1PaddingTableLayoutPanel.Controls.Add(this.filterGroupBox, 1, 0);
			this.panel1PaddingTableLayoutPanel.Location = new System.Drawing.Point(575, 2);
			this.panel1PaddingTableLayoutPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.panel1PaddingTableLayoutPanel.Name = "panel1PaddingTableLayoutPanel";
			this.panel1PaddingTableLayoutPanel.RowCount = 1;
			this.panel1PaddingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.panel1PaddingTableLayoutPanel.Size = new System.Drawing.Size(413, 272);
			this.panel1PaddingTableLayoutPanel.TabIndex = 2;
			// 
			// filterGroupBox
			// 
			this.filterGroupBox.AutoSize = true;
			this.filterGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.filterGroupBox.Controls.Add(filterTableLayoutPanel);
			this.filterGroupBox.Location = new System.Drawing.Point(17, 6);
			this.filterGroupBox.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
			this.filterGroupBox.Name = "filterGroupBox";
			this.filterGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.filterGroupBox.Size = new System.Drawing.Size(389, 260);
			this.filterGroupBox.TabIndex = 1;
			this.filterGroupBox.TabStop = false;
			this.filterGroupBox.Text = "フィルター";
			// 
			// filterTableLayoutPanel
			// 
			filterTableLayoutPanel.AutoSize = true;
			filterTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			filterTableLayoutPanel.ColumnCount = 1;
			filterTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			filterTableLayoutPanel.Controls.Add(this.filterAddGroupBox, 0, 0);
			filterTableLayoutPanel.Controls.Add(this.selectedFilterGroupBox, 0, 1);
			filterTableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			filterTableLayoutPanel.Location = new System.Drawing.Point(7, 21);
			filterTableLayoutPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			filterTableLayoutPanel.Name = "filterTableLayoutPanel";
			filterTableLayoutPanel.RowCount = 2;
			filterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			filterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			filterTableLayoutPanel.Size = new System.Drawing.Size(376, 219);
			filterTableLayoutPanel.TabIndex = 2;
			// 
			// filterAddGroupBox
			// 
			this.filterAddGroupBox.AutoSize = true;
			this.filterAddGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.filterAddGroupBox.Controls.Add(this.tableLayoutPanel4);
			this.filterAddGroupBox.Controls.Add(filterSettingTableLayoutPanel);
			this.filterAddGroupBox.Location = new System.Drawing.Point(3, 2);
			this.filterAddGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.filterAddGroupBox.Name = "filterAddGroupBox";
			this.filterAddGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.filterAddGroupBox.Size = new System.Drawing.Size(370, 92);
			this.filterAddGroupBox.TabIndex = 0;
			this.filterAddGroupBox.TabStop = false;
			this.filterAddGroupBox.Text = "フィルターの追加";
			// 
			// tableLayoutPanel4
			// 
			this.tableLayoutPanel4.AutoSize = true;
			this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel4.ColumnCount = 3;
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 42);
			this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 1;
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel4.Size = new System.Drawing.Size(0, 0);
			this.tableLayoutPanel4.TabIndex = 2;
			// 
			// selectedFilterGroupBox
			// 
			this.selectedFilterGroupBox.AutoSize = true;
			this.selectedFilterGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.selectedFilterGroupBox.Controls.Add(this.selectedFilterListBox);
			this.selectedFilterGroupBox.Location = new System.Drawing.Point(3, 98);
			this.selectedFilterGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.selectedFilterGroupBox.Name = "selectedFilterGroupBox";
			this.selectedFilterGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.selectedFilterGroupBox.Size = new System.Drawing.Size(368, 119);
			this.selectedFilterGroupBox.TabIndex = 1;
			this.selectedFilterGroupBox.TabStop = false;
			this.selectedFilterGroupBox.Text = "現在適用されているフィルター";
			// 
			// selectedFilterListBox
			// 
			this.selectedFilterListBox.FormattingEnabled = true;
			this.selectedFilterListBox.ItemHeight = 15;
			this.selectedFilterListBox.Location = new System.Drawing.Point(4, 20);
			this.selectedFilterListBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.selectedFilterListBox.Name = "selectedFilterListBox";
			this.selectedFilterListBox.ScrollAlwaysVisible = true;
			this.selectedFilterListBox.Size = new System.Drawing.Size(358, 79);
			this.selectedFilterListBox.TabIndex = 0;
			this.selectedFilterListBox.TabStop = false;
			// 
			// tabPage2
			// 
			this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
			this.tabPage2.Controls.Add(this.panel2);
			this.tabPage2.Location = new System.Drawing.Point(4, 24);
			this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(992, 357);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "キー設定";
			// 
			// panel2
			// 
			this.panel2.AutoScroll = true;
			this.panel2.Controls.Add(panel2PaddingTableLayoutPanel);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(992, 357);
			this.panel2.TabIndex = 0;
			// 
			// panel2PaddingTableLayoutPanel
			// 
			panel2PaddingTableLayoutPanel.AutoSize = true;
			panel2PaddingTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			panel2PaddingTableLayoutPanel.ColumnCount = 2;
			panel2PaddingTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			panel2PaddingTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			panel2PaddingTableLayoutPanel.Controls.Add(this.x_axisGroupBox, 0, 0);
			panel2PaddingTableLayoutPanel.Controls.Add(this.valueGroupBox, 0, 1);
			panel2PaddingTableLayoutPanel.Controls.Add(this.y_axisGroupBox, 1, 0);
			panel2PaddingTableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			panel2PaddingTableLayoutPanel.Location = new System.Drawing.Point(3, 2);
			panel2PaddingTableLayoutPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			panel2PaddingTableLayoutPanel.Name = "panel2PaddingTableLayoutPanel";
			panel2PaddingTableLayoutPanel.RowCount = 2;
			panel2PaddingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			panel2PaddingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			panel2PaddingTableLayoutPanel.Size = new System.Drawing.Size(748, 334);
			panel2PaddingTableLayoutPanel.TabIndex = 2;
			// 
			// x_axisGroupBox
			// 
			this.x_axisGroupBox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.x_axisGroupBox.AutoSize = true;
			this.x_axisGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.x_axisGroupBox.Controls.Add(x_axisTableLayoutPanel);
			this.x_axisGroupBox.Location = new System.Drawing.Point(3, 2);
			this.x_axisGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.x_axisGroupBox.Name = "x_axisGroupBox";
			this.x_axisGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.x_axisGroupBox.Size = new System.Drawing.Size(368, 144);
			this.x_axisGroupBox.TabIndex = 0;
			this.x_axisGroupBox.TabStop = false;
			this.x_axisGroupBox.Text = "横軸";
			// 
			// valueGroupBox
			// 
			this.valueGroupBox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.valueGroupBox.AutoSize = true;
			this.valueGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.valueGroupBox.Controls.Add(valueTableLayoutPanel);
			this.valueGroupBox.Location = new System.Drawing.Point(3, 150);
			this.valueGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.valueGroupBox.Name = "valueGroupBox";
			this.valueGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.valueGroupBox.Size = new System.Drawing.Size(367, 182);
			this.valueGroupBox.TabIndex = 2;
			this.valueGroupBox.TabStop = false;
			this.valueGroupBox.Text = "値";
			// 
			// y_axisGroupBox
			// 
			this.y_axisGroupBox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.y_axisGroupBox.AutoSize = true;
			this.y_axisGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.y_axisGroupBox.Controls.Add(y_axisTableLayoutPanel);
			this.y_axisGroupBox.Location = new System.Drawing.Point(377, 2);
			this.y_axisGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.y_axisGroupBox.Name = "y_axisGroupBox";
			this.y_axisGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.y_axisGroupBox.Size = new System.Drawing.Size(368, 144);
			this.y_axisGroupBox.TabIndex = 1;
			this.y_axisGroupBox.TabStop = false;
			this.y_axisGroupBox.Text = "縦軸";
			// 
			// tabPage3
			// 
			this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
			this.tabPage3.Controls.Add(this.panel3);
			this.tabPage3.Location = new System.Drawing.Point(4, 24);
			this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(992, 357);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "記号設定";
			// 
			// panel3
			// 
			this.panel3.AutoScroll = true;
			this.panel3.Controls.Add(selectedSymbolPanel);
			this.panel3.Controls.Add(symbolDataGridViewPanel);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(992, 357);
			this.panel3.TabIndex = 0;
			// 
			// selectedSymbolPanel
			// 
			selectedSymbolPanel.AutoSize = true;
			selectedSymbolPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			selectedSymbolPanel.Controls.Add(selectedSymbolGroupBox);
			selectedSymbolPanel.Dock = System.Windows.Forms.DockStyle.Left;
			selectedSymbolPanel.Location = new System.Drawing.Point(297, 0);
			selectedSymbolPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			selectedSymbolPanel.Name = "selectedSymbolPanel";
			selectedSymbolPanel.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			selectedSymbolPanel.Size = new System.Drawing.Size(632, 357);
			selectedSymbolPanel.TabIndex = 1;
			// 
			// selectedSymbolGroupBox
			// 
			selectedSymbolGroupBox.AutoSize = true;
			selectedSymbolGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			selectedSymbolGroupBox.Controls.Add(selectedSymbolTableLayoutPanel);
			selectedSymbolGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			selectedSymbolGroupBox.Location = new System.Drawing.Point(3, 2);
			selectedSymbolGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			selectedSymbolGroupBox.Name = "selectedSymbolGroupBox";
			selectedSymbolGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			selectedSymbolGroupBox.Size = new System.Drawing.Size(626, 353);
			selectedSymbolGroupBox.TabIndex = 1;
			selectedSymbolGroupBox.TabStop = false;
			selectedSymbolGroupBox.Text = "選択中の記号";
			// 
			// selectedSymbolTableLayoutPanel
			// 
			selectedSymbolTableLayoutPanel.AutoSize = true;
			selectedSymbolTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			selectedSymbolTableLayoutPanel.ColumnCount = 1;
			selectedSymbolTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			selectedSymbolTableLayoutPanel.Controls.Add(selectedSymbolMemberAndParentTableLayoutPanel, 0, 3);
			selectedSymbolTableLayoutPanel.Controls.Add(this.selectedSymbolDataTableLayoutPanel, 0, 1);
			selectedSymbolTableLayoutPanel.Controls.Add(selectedSymbolConvertModeTableLayoutPanel, 0, 2);
			selectedSymbolTableLayoutPanel.Controls.Add(tableLayoutPanel1, 0, 0);
			selectedSymbolTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			selectedSymbolTableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			selectedSymbolTableLayoutPanel.Location = new System.Drawing.Point(3, 18);
			selectedSymbolTableLayoutPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			selectedSymbolTableLayoutPanel.Name = "selectedSymbolTableLayoutPanel";
			selectedSymbolTableLayoutPanel.RowCount = 4;
			selectedSymbolTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			selectedSymbolTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			selectedSymbolTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			selectedSymbolTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			selectedSymbolTableLayoutPanel.Size = new System.Drawing.Size(620, 333);
			selectedSymbolTableLayoutPanel.TabIndex = 0;
			// 
			// selectedSymbolMemberAndParentTableLayoutPanel
			// 
			selectedSymbolMemberAndParentTableLayoutPanel.ColumnCount = 2;
			selectedSymbolMemberAndParentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			selectedSymbolMemberAndParentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			selectedSymbolMemberAndParentTableLayoutPanel.Controls.Add(this.selectedSymbolParentGroupBox, 1, 0);
			selectedSymbolMemberAndParentTableLayoutPanel.Controls.Add(this.selectedSymbolMembersGroupBox, 0, 0);
			selectedSymbolMemberAndParentTableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			selectedSymbolMemberAndParentTableLayoutPanel.Location = new System.Drawing.Point(3, 183);
			selectedSymbolMemberAndParentTableLayoutPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 5);
			selectedSymbolMemberAndParentTableLayoutPanel.Name = "selectedSymbolMemberAndParentTableLayoutPanel";
			selectedSymbolMemberAndParentTableLayoutPanel.RowCount = 1;
			selectedSymbolMemberAndParentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			selectedSymbolMemberAndParentTableLayoutPanel.Size = new System.Drawing.Size(594, 148);
			selectedSymbolMemberAndParentTableLayoutPanel.TabIndex = 1;
			// 
			// selectedSymbolParentGroupBox
			// 
			this.selectedSymbolParentGroupBox.Controls.Add(this.selectedSymbolParentDataGridView);
			this.selectedSymbolParentGroupBox.Location = new System.Drawing.Point(300, 2);
			this.selectedSymbolParentGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.selectedSymbolParentGroupBox.Name = "selectedSymbolParentGroupBox";
			this.selectedSymbolParentGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.selectedSymbolParentGroupBox.Size = new System.Drawing.Size(291, 78);
			this.selectedSymbolParentGroupBox.TabIndex = 6;
			this.selectedSymbolParentGroupBox.TabStop = false;
			this.selectedSymbolParentGroupBox.Text = "所属しているグループ";
			// 
			// selectedSymbolParentDataGridView
			// 
			this.selectedSymbolParentDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.selectedSymbolParentDataGridView.Location = new System.Drawing.Point(3, 18);
			this.selectedSymbolParentDataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.selectedSymbolParentDataGridView.Name = "selectedSymbolParentDataGridView";
			this.selectedSymbolParentDataGridView.Size = new System.Drawing.Size(285, 58);
			this.selectedSymbolParentDataGridView.TabIndex = 0;
			// 
			// selectedSymbolMembersGroupBox
			// 
			this.selectedSymbolMembersGroupBox.Controls.Add(this.selectedSymbolMembersDataGridView);
			this.selectedSymbolMembersGroupBox.Dock = System.Windows.Forms.DockStyle.Left;
			this.selectedSymbolMembersGroupBox.Location = new System.Drawing.Point(3, 2);
			this.selectedSymbolMembersGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 4);
			this.selectedSymbolMembersGroupBox.Name = "selectedSymbolMembersGroupBox";
			this.selectedSymbolMembersGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.selectedSymbolMembersGroupBox.Size = new System.Drawing.Size(290, 142);
			this.selectedSymbolMembersGroupBox.TabIndex = 5;
			this.selectedSymbolMembersGroupBox.TabStop = false;
			this.selectedSymbolMembersGroupBox.Text = "グループメンバー一覧";
			// 
			// selectedSymbolMembersDataGridView
			// 
			this.selectedSymbolMembersDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.selectedSymbolMembersDataGridView.Location = new System.Drawing.Point(3, 18);
			this.selectedSymbolMembersDataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.selectedSymbolMembersDataGridView.Name = "selectedSymbolMembersDataGridView";
			this.selectedSymbolMembersDataGridView.Size = new System.Drawing.Size(284, 122);
			this.selectedSymbolMembersDataGridView.TabIndex = 0;
			// 
			// selectedSymbolDataTableLayoutPanel
			// 
			this.selectedSymbolDataTableLayoutPanel.AutoSize = true;
			this.selectedSymbolDataTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.selectedSymbolDataTableLayoutPanel.ColumnCount = 2;
			this.selectedSymbolDataTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.selectedSymbolDataTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.selectedSymbolDataTableLayoutPanel.Controls.Add(this.selectedSymbolDataGroupBox, 0, 0);
			this.selectedSymbolDataTableLayoutPanel.Controls.Add(this.groupBox3, 1, 0);
			this.selectedSymbolDataTableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			this.selectedSymbolDataTableLayoutPanel.Location = new System.Drawing.Point(3, 31);
			this.selectedSymbolDataTableLayoutPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.selectedSymbolDataTableLayoutPanel.Name = "selectedSymbolDataTableLayoutPanel";
			this.selectedSymbolDataTableLayoutPanel.RowCount = 1;
			this.selectedSymbolDataTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.selectedSymbolDataTableLayoutPanel.Size = new System.Drawing.Size(614, 117);
			this.selectedSymbolDataTableLayoutPanel.TabIndex = 7;
			// 
			// selectedSymbolDataGroupBox
			// 
			this.selectedSymbolDataGroupBox.AutoSize = true;
			this.selectedSymbolDataGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.selectedSymbolDataGroupBox.Controls.Add(tableLayoutPanel9);
			this.selectedSymbolDataGroupBox.Location = new System.Drawing.Point(3, 2);
			this.selectedSymbolDataGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.selectedSymbolDataGroupBox.Name = "selectedSymbolDataGroupBox";
			this.selectedSymbolDataGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.selectedSymbolDataGroupBox.Size = new System.Drawing.Size(301, 113);
			this.selectedSymbolDataGroupBox.TabIndex = 1;
			this.selectedSymbolDataGroupBox.TabStop = false;
			// 
			// groupBox3
			// 
			this.groupBox3.AutoSize = true;
			this.groupBox3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBox3.Controls.Add(tableLayoutPanel10);
			this.groupBox3.Location = new System.Drawing.Point(310, 2);
			this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox3.Size = new System.Drawing.Size(287, 112);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			// 
			// selectedSymbolConvertModeTableLayoutPanel
			// 
			selectedSymbolConvertModeTableLayoutPanel.AutoSize = true;
			selectedSymbolConvertModeTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			selectedSymbolConvertModeTableLayoutPanel.ColumnCount = 4;
			selectedSymbolConvertModeTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			selectedSymbolConvertModeTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			selectedSymbolConvertModeTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			selectedSymbolConvertModeTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			selectedSymbolConvertModeTableLayoutPanel.Controls.Add(this.selectedSymbolCustomNameTextBox, 3, 0);
			selectedSymbolConvertModeTableLayoutPanel.Controls.Add(this.label12, 0, 0);
			selectedSymbolConvertModeTableLayoutPanel.Controls.Add(this.label20, 2, 0);
			selectedSymbolConvertModeTableLayoutPanel.Controls.Add(this.selectedSymbolConvertModeEnumComboBox, 1, 0);
			selectedSymbolConvertModeTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			selectedSymbolConvertModeTableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			selectedSymbolConvertModeTableLayoutPanel.Location = new System.Drawing.Point(3, 152);
			selectedSymbolConvertModeTableLayoutPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			selectedSymbolConvertModeTableLayoutPanel.Name = "selectedSymbolConvertModeTableLayoutPanel";
			selectedSymbolConvertModeTableLayoutPanel.RowCount = 1;
			selectedSymbolConvertModeTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			selectedSymbolConvertModeTableLayoutPanel.Size = new System.Drawing.Size(614, 27);
			selectedSymbolConvertModeTableLayoutPanel.TabIndex = 7;
			// 
			// selectedSymbolCustomNameTextBox
			// 
			this.selectedSymbolCustomNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.selectedSymbolCustomNameTextBox.Location = new System.Drawing.Point(391, 2);
			this.selectedSymbolCustomNameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 7, 2);
			this.selectedSymbolCustomNameTextBox.Name = "selectedSymbolCustomNameTextBox";
			this.selectedSymbolCustomNameTextBox.Size = new System.Drawing.Size(172, 23);
			this.selectedSymbolCustomNameTextBox.TabIndex = 4;
			// 
			// label12
			// 
			this.label12.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(3, 6);
			this.label12.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(102, 15);
			this.label12.TabIndex = 34;
			this.label12.Text = "凡例の変換モード：";
			// 
			// label20
			// 
			this.label20.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(212, 6);
			this.label20.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(173, 15);
			this.label20.TabIndex = 37;
			this.label20.Text = "⇒カスタムのとき表示するテキスト：";
			// 
			// selectedSymbolConvertModeEnumComboBox
			// 
			this.selectedSymbolConvertModeEnumComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.selectedSymbolConvertModeEnumComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.selectedSymbolConvertModeEnumComboBox.EnumName = "ConvertMode";
			this.selectedSymbolConvertModeEnumComboBox.FormattingEnabled = true;
			this.selectedSymbolConvertModeEnumComboBox.Location = new System.Drawing.Point(111, 2);
			this.selectedSymbolConvertModeEnumComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.selectedSymbolConvertModeEnumComboBox.Name = "selectedSymbolConvertModeEnumComboBox";
			this.selectedSymbolConvertModeEnumComboBox.SelectedEnumValue = null;
			this.selectedSymbolConvertModeEnumComboBox.Size = new System.Drawing.Size(95, 23);
			this.selectedSymbolConvertModeEnumComboBox.TabIndex = 3;
			// 
			// symbolDataGridViewPanel
			// 
			symbolDataGridViewPanel.Controls.Add(this.symbolGroupBox);
			symbolDataGridViewPanel.Dock = System.Windows.Forms.DockStyle.Left;
			symbolDataGridViewPanel.Location = new System.Drawing.Point(0, 0);
			symbolDataGridViewPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			symbolDataGridViewPanel.Name = "symbolDataGridViewPanel";
			symbolDataGridViewPanel.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			symbolDataGridViewPanel.Size = new System.Drawing.Size(297, 357);
			symbolDataGridViewPanel.TabIndex = 4;
			// 
			// symbolGroupBox
			// 
			this.symbolGroupBox.Controls.Add(this.symbolDataGridView);
			this.symbolGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.symbolGroupBox.Location = new System.Drawing.Point(3, 2);
			this.symbolGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.symbolGroupBox.Name = "symbolGroupBox";
			this.symbolGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.symbolGroupBox.Size = new System.Drawing.Size(291, 353);
			this.symbolGroupBox.TabIndex = 0;
			this.symbolGroupBox.TabStop = false;
			this.symbolGroupBox.Text = "記号選択";
			// 
			// symbolDataGridView
			// 
			this.symbolDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.symbolDataGridView.Location = new System.Drawing.Point(3, 18);
			this.symbolDataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.symbolDataGridView.Name = "symbolDataGridView";
			this.symbolDataGridView.Size = new System.Drawing.Size(285, 333);
			this.symbolDataGridView.TabIndex = 0;
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
			this.menuStrip.Size = new System.Drawing.Size(1122, 24);
			this.menuStrip.TabIndex = 1;
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.loadFileToolStripMenuItem,
            this.saveFileToolStripMenuItem,
            this.loadEditDataToolStripMenuItem,
            this.saveEditToolStripMenuItem,
            this.loadSymbolDataToolStripMenuItem,
            this.exportSymbolToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
			this.fileToolStripMenuItem.Text = "ファイル(&F)";
			// 
			// loadFileToolStripMenuItem
			// 
			this.loadFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSVFiletsvToolStripMenuItem,
            this.loadCSVToolStripMenuItem,
            this.editFileToolStripMenuItem});
			this.loadFileToolStripMenuItem.Name = "loadFileToolStripMenuItem";
			this.loadFileToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
			this.loadFileToolStripMenuItem.Text = "データ読み込み(&L)";
			// 
			// tSVFiletsvToolStripMenuItem
			// 
			this.tSVFiletsvToolStripMenuItem.Name = "tSVFiletsvToolStripMenuItem";
			this.tSVFiletsvToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
			this.tSVFiletsvToolStripMenuItem.Text = "TSVファイル(.tsv)から読み込む(&T)";
			this.tSVFiletsvToolStripMenuItem.Click += new System.EventHandler(this.tSVFiletsvToolStripMenuItem_Click);
			// 
			// loadCSVToolStripMenuItem
			// 
			this.loadCSVToolStripMenuItem.Name = "loadCSVToolStripMenuItem";
			this.loadCSVToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
			this.loadCSVToolStripMenuItem.Text = "CSVファイル(.csv)から読み込む(&C)";
			this.loadCSVToolStripMenuItem.Click += new System.EventHandler(this.loadCSV_Event);
			// 
			// editFileToolStripMenuItem
			// 
			this.editFileToolStripMenuItem.Name = "editFileToolStripMenuItem";
			this.editFileToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
			this.editFileToolStripMenuItem.Text = "クリップボードから読み込む(&L)";
			this.editFileToolStripMenuItem.Click += new System.EventHandler(this.loadClipboardToolStripMenuItem_Click);
			// 
			// saveFileToolStripMenuItem
			// 
			this.saveFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveTSVFileToolStripMenuItem,
            this.saveCSVFileToolStripMenuItem});
			this.saveFileToolStripMenuItem.Name = "saveFileToolStripMenuItem";
			this.saveFileToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
			this.saveFileToolStripMenuItem.Text = "データを出力する(&O)";
			// 
			// saveTSVFileToolStripMenuItem
			// 
			this.saveTSVFileToolStripMenuItem.Name = "saveTSVFileToolStripMenuItem";
			this.saveTSVFileToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
			this.saveTSVFileToolStripMenuItem.Text = "TSVファイル(.tsv)に出力する(&T)";
			this.saveTSVFileToolStripMenuItem.Click += new System.EventHandler(this.SaveTSVFile_Event);
			// 
			// saveCSVFileToolStripMenuItem
			// 
			this.saveCSVFileToolStripMenuItem.Name = "saveCSVFileToolStripMenuItem";
			this.saveCSVFileToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
			this.saveCSVFileToolStripMenuItem.Text = "CSVファイル(.csv)に出力する(&C)";
			this.saveCSVFileToolStripMenuItem.Click += new System.EventHandler(this.SaveCSVFile_Event);
			// 
			// loadEditDataToolStripMenuItem
			// 
			this.loadEditDataToolStripMenuItem.Name = "loadEditDataToolStripMenuItem";
			this.loadEditDataToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
			this.loadEditDataToolStripMenuItem.Text = "編集データを読み込む(&E)";
			this.loadEditDataToolStripMenuItem.Click += new System.EventHandler(this.LoadEditData);
			// 
			// saveEditToolStripMenuItem
			// 
			this.saveEditToolStripMenuItem.Name = "saveEditToolStripMenuItem";
			this.saveEditToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
			this.saveEditToolStripMenuItem.Text = "編集データを保存する(&S)";
			this.saveEditToolStripMenuItem.Click += new System.EventHandler(this.SaveEditData);
			// 
			// loadSymbolDataToolStripMenuItem
			// 
			this.loadSymbolDataToolStripMenuItem.Name = "loadSymbolDataToolStripMenuItem";
			this.loadSymbolDataToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
			this.loadSymbolDataToolStripMenuItem.Text = "記号設定を読み込む(&Y)";
			// 
			// exportSymbolToolStripMenuItem
			// 
			this.exportSymbolToolStripMenuItem.Name = "exportSymbolToolStripMenuItem";
			this.exportSymbolToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
			this.exportSymbolToolStripMenuItem.Text = "記号設定を出力する(M)";
			// 
			// dataGridViewContextMenuStrip
			// 
			this.dataGridViewContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.splitToolStripMenuItem,
            this.iDToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.removeToolStripMenuItem});
			this.dataGridViewContextMenuStrip.Name = "contextMenuStripEx1";
			this.dataGridViewContextMenuStrip.Size = new System.Drawing.Size(247, 92);
			// 
			// splitToolStripMenuItem
			// 
			this.splitToolStripMenuItem.Name = "splitToolStripMenuItem";
			this.splitToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
			this.splitToolStripMenuItem.Text = "選択列を区切り文字で区切る";
			this.splitToolStripMenuItem.Click += new System.EventHandler(this.splitToolStripMenuItem_Click);
			// 
			// iDToolStripMenuItem
			// 
			this.iDToolStripMenuItem.Name = "iDToolStripMenuItem";
			this.iDToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
			this.iDToolStripMenuItem.Text = "選択列の値にIDを設定する";
			this.iDToolStripMenuItem.Click += new System.EventHandler(this.CreateIDColumn_Click);
			// 
			// indexToolStripMenuItem
			// 
			this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
			this.indexToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
			this.indexToolStripMenuItem.Text = "選択列の値にインデックスを設定する";
			this.indexToolStripMenuItem.Click += new System.EventHandler(this.CreateIndexColumn_Click);
			// 
			// removeToolStripMenuItem
			// 
			this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
			this.removeToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
			this.removeToolStripMenuItem.Text = "選択列を削除する";
			this.removeToolStripMenuItem.Click += new System.EventHandler(this.RemoveColumn_Click);
			// 
			// selectedFilterContextMenuStrip
			// 
			this.selectedFilterContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectedFilterDeleteToolStripMenuItem});
			this.selectedFilterContextMenuStrip.Name = "selectedFilterContextMenuStripEx";
			this.selectedFilterContextMenuStrip.Size = new System.Drawing.Size(99, 26);
			// 
			// selectedFilterDeleteToolStripMenuItem
			// 
			this.selectedFilterDeleteToolStripMenuItem.Name = "selectedFilterDeleteToolStripMenuItem";
			this.selectedFilterDeleteToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
			this.selectedFilterDeleteToolStripMenuItem.Text = "削除";
			// 
			// dataGridViewCheckBoxColumn1
			// 
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			dataGridViewCellStyle2.NullValue = false;
			this.dataGridViewCheckBoxColumn1.DefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridViewCheckBoxColumn1.HeaderText = "表示";
			this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
			// 
			// dataGridViewImageColumn1
			// 
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewImageColumn1.DefaultCellStyle = dataGridViewCellStyle3;
			this.dataGridViewImageColumn1.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn1.Image")));
			this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
			// 
			// dataGridViewTextBoxColumn1
			// 
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle4;
			this.dataGridViewTextBoxColumn1.HeaderText = "値";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// dataGridViewTextBoxColumn2
			// 
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle5;
			this.dataGridViewTextBoxColumn2.HeaderText = "個数";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// valueListBoxMenu
			// 
			this.valueListBoxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteKeyToolStripMenuItem});
			this.valueListBoxMenu.Name = "valueListBoxMenu";
			this.valueListBoxMenu.Size = new System.Drawing.Size(182, 26);
			// 
			// deleteKeyToolStripMenuItem
			// 
			this.deleteKeyToolStripMenuItem.Name = "deleteKeyToolStripMenuItem";
			this.deleteKeyToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.deleteKeyToolStripMenuItem.Text = "選択したキーを取り消し";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
			this.newToolStripMenuItem.Text = "新規";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.LoadNew);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1122, 429);
			this.Controls.Add(form1TableLayoutPanel);
			this.Controls.Add(this.menuStrip);
			this.MainMenuStrip = this.menuStrip;
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "Form1";
			this.Text = "データ読み込み";
			filterSettingTableLayoutPanel.ResumeLayout(false);
			filterSettingTableLayoutPanel.PerformLayout();
			valueTableLayoutPanel.ResumeLayout(false);
			valueTableLayoutPanel.PerformLayout();
			x_axisTableLayoutPanel.ResumeLayout(false);
			x_axisTableLayoutPanel.PerformLayout();
			y_axisTableLayoutPanel.ResumeLayout(false);
			y_axisTableLayoutPanel.PerformLayout();
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			tableLayoutPanel9.ResumeLayout(false);
			tableLayoutPanel9.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.selectedSymbolPictureBox)).EndInit();
			tableLayoutPanel10.ResumeLayout(false);
			tableLayoutPanel10.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.selectedSymbolElipsisPictureBox)).EndInit();
			form1TableLayoutPanel.ResumeLayout(false);
			form1TableLayoutPanel.PerformLayout();
			this.coloredTabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.mainDataGridView)).EndInit();
			this.panel1PaddingTableLayoutPanel.ResumeLayout(false);
			this.panel1PaddingTableLayoutPanel.PerformLayout();
			this.filterGroupBox.ResumeLayout(false);
			this.filterGroupBox.PerformLayout();
			filterTableLayoutPanel.ResumeLayout(false);
			filterTableLayoutPanel.PerformLayout();
			this.filterAddGroupBox.ResumeLayout(false);
			this.filterAddGroupBox.PerformLayout();
			this.selectedFilterGroupBox.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			panel2PaddingTableLayoutPanel.ResumeLayout(false);
			panel2PaddingTableLayoutPanel.PerformLayout();
			this.x_axisGroupBox.ResumeLayout(false);
			this.x_axisGroupBox.PerformLayout();
			this.valueGroupBox.ResumeLayout(false);
			this.valueGroupBox.PerformLayout();
			this.y_axisGroupBox.ResumeLayout(false);
			this.y_axisGroupBox.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			selectedSymbolPanel.ResumeLayout(false);
			selectedSymbolPanel.PerformLayout();
			selectedSymbolGroupBox.ResumeLayout(false);
			selectedSymbolGroupBox.PerformLayout();
			selectedSymbolTableLayoutPanel.ResumeLayout(false);
			selectedSymbolTableLayoutPanel.PerformLayout();
			selectedSymbolMemberAndParentTableLayoutPanel.ResumeLayout(false);
			this.selectedSymbolParentGroupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.selectedSymbolParentDataGridView)).EndInit();
			this.selectedSymbolMembersGroupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.selectedSymbolMembersDataGridView)).EndInit();
			this.selectedSymbolDataTableLayoutPanel.ResumeLayout(false);
			this.selectedSymbolDataTableLayoutPanel.PerformLayout();
			this.selectedSymbolDataGroupBox.ResumeLayout(false);
			this.selectedSymbolDataGroupBox.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			selectedSymbolConvertModeTableLayoutPanel.ResumeLayout(false);
			selectedSymbolConvertModeTableLayoutPanel.PerformLayout();
			symbolDataGridViewPanel.ResumeLayout(false);
			this.symbolGroupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.symbolDataGridView)).EndInit();
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.dataGridViewContextMenuStrip.ResumeLayout(false);
			this.selectedFilterContextMenuStrip.ResumeLayout(false);
			this.valueListBoxMenu.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView mainDataGridView;
		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem tSVFiletsvToolStripMenuItem;
		private System.Windows.Forms.Button openForm2Button;
		private ContextMenuStripEx dataGridViewContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem splitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveTSVFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveCSVFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveEditToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadEditDataToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem iDToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadCSVToolStripMenuItem;
		private System.Windows.Forms.GroupBox filterAddGroupBox;
		private System.Windows.Forms.Label label1;
		private EnumComboBox filterTypeEnumComboBox;
		private System.Windows.Forms.ComboBox filterKeyComboBox;
		private System.Windows.Forms.TextBox filterValueTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox filterGroupBox;
		private System.Windows.Forms.ListBox selectedFilterListBox;
		private System.Windows.Forms.GroupBox selectedFilterGroupBox;
		private System.Windows.Forms.Button filterAddButton;
		private ContextMenuStripEx selectedFilterContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem selectedFilterDeleteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
		private ColoredTabControl coloredTabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.GroupBox x_axisGroupBox;
		private NumberBox x_axisTickBox;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox x_axisKeyBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox x_axisSortKeyBox;
		private System.Windows.Forms.Label label9;
		private NumberBox x_axisViewMinBox;
		private System.Windows.Forms.Label label10;
		private NumberBox x_axisViewMaxBox;
		private System.Windows.Forms.ComboBox x_axisViewOrderBox;
		private System.Windows.Forms.GroupBox y_axisGroupBox;
		private NumberBox y_axisTickBox;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.ComboBox y_axisKeyBox;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.ComboBox y_axisSortKeyBox;
		private System.Windows.Forms.Label label18;
		private NumberBox y_axisViewMinBox;
		private System.Windows.Forms.Label label19;
		private NumberBox y_axisViewMaxBox;
		private System.Windows.Forms.ComboBox y_axisViewOrderBox;
		private System.Windows.Forms.GroupBox valueGroupBox;
		private System.Windows.Forms.ComboBox valueKeyBox;
		private System.Windows.Forms.Button addValueButton;
		private System.Windows.Forms.ListBox valueListBox;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.GroupBox symbolGroupBox;
		private ContextMenuStripEx valueListBoxMenu;
		private System.Windows.Forms.ToolStripMenuItem deleteKeyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadSymbolDataToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportSymbolToolStripMenuItem;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox selectedSymbolTypeTextBox;
		private System.Windows.Forms.GroupBox selectedSymbolDataGroupBox;
		private System.Windows.Forms.TextBox selectedSymbolValueTextBox;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.PictureBox selectedSymbolPictureBox;
		private System.Windows.Forms.TextBox selectedSymbolCountTextBox;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.CheckBox selectedSymbolViewCheckBox;
		private System.Windows.Forms.Label label12;
		private EnumComboBox selectedSymbolConvertModeEnumComboBox;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Button selectedSymbolUngroupButton;
		private System.Windows.Forms.GroupBox groupBox3;
		private NumberBox selectedSymbolElipsisRelatedYNumberBox;
		private System.Windows.Forms.CheckBox selectedSymbolElipsisEnabledCheckBox;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.PictureBox selectedSymbolElipsisPictureBox;
		private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
		private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private SymbolDataGridView selectedSymbolMembersDataGridView;
		private System.Windows.Forms.GroupBox selectedSymbolMembersGroupBox;
		private SymbolDataGridView symbolDataGridView;
		private System.Windows.Forms.GroupBox selectedSymbolParentGroupBox;
		private SymbolDataGridView selectedSymbolParentDataGridView;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
		private System.Windows.Forms.TableLayoutPanel panel1PaddingTableLayoutPanel;
		private System.Windows.Forms.TextBox selectedSymbolCustomNameTextBox;
		private System.Windows.Forms.TableLayoutPanel selectedSymbolDataTableLayoutPanel;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
	}
}

