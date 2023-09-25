namespace WinFormsApp1
{
	partial class GraphicsTextBoxList
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
			System.Windows.Forms.TableLayoutPanel allTableLayoutPanel;
			this.okButton = new System.Windows.Forms.Button();
			this.graphicsTextBoxEditDataGridView1 = new WinFormsApp1.GraphicsTextBoxEditDataGridView();
			this.dataGridViewContextMenuStrip = new WinFormsApp1.ContextMenuStripEx();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			allTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			allTableLayoutPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.graphicsTextBoxEditDataGridView1)).BeginInit();
			this.dataGridViewContextMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// allTableLayoutPanel
			// 
			allTableLayoutPanel.AutoSize = true;
			allTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			allTableLayoutPanel.ColumnCount = 1;
			allTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			allTableLayoutPanel.Controls.Add(this.okButton, 0, 1);
			allTableLayoutPanel.Controls.Add(this.graphicsTextBoxEditDataGridView1, 0, 0);
			allTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			allTableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			allTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
			allTableLayoutPanel.Name = "allTableLayoutPanel";
			allTableLayoutPanel.RowCount = 2;
			allTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			allTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			allTableLayoutPanel.Size = new System.Drawing.Size(974, 353);
			allTableLayoutPanel.TabIndex = 2;
			// 
			// okButton
			// 
			this.okButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.okButton.AutoSize = true;
			this.okButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.okButton.Location = new System.Drawing.Point(920, 325);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(51, 25);
			this.okButton.TabIndex = 1;
			this.okButton.Text = "   OK   ";
			this.okButton.UseVisualStyleBackColor = true;
			// 
			// graphicsTextBoxEditDataGridView1
			// 
			this.graphicsTextBoxEditDataGridView1.AllowDrag = true;
			this.graphicsTextBoxEditDataGridView1.AllowDrop = true;
			this.graphicsTextBoxEditDataGridView1.AllowUserToResizeColumns = true;
			this.graphicsTextBoxEditDataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.graphicsTextBoxEditDataGridView1.Location = new System.Drawing.Point(3, 3);
			this.graphicsTextBoxEditDataGridView1.Name = "graphicsTextBoxEditDataGridView1";
			this.graphicsTextBoxEditDataGridView1.Size = new System.Drawing.Size(968, 316);
			this.graphicsTextBoxEditDataGridView1.TabIndex = 0;
			this.graphicsTextBoxEditDataGridView1.ViewProperties.Add("Text");
			this.graphicsTextBoxEditDataGridView1.ViewProperties.Add("Rectangle");
			this.graphicsTextBoxEditDataGridView1.ViewProperties.Add("BackColor");
			this.graphicsTextBoxEditDataGridView1.ViewProperties.Add("ForeColor");
			this.graphicsTextBoxEditDataGridView1.ViewProperties.Add("Font");
			// 
			// dataGridViewContextMenuStrip
			// 
			this.dataGridViewContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem});
			this.dataGridViewContextMenuStrip.Name = "dataGridViewContextMenuStrip";
			this.dataGridViewContextMenuStrip.Size = new System.Drawing.Size(185, 26);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.editToolStripMenuItem.Text = "選択中の列を編集する";
			this.editToolStripMenuItem.Click += new System.EventHandler(this.OpenEdit_Event);
			// 
			// GraphicsTextBoxList
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(974, 353);
			this.Controls.Add(allTableLayoutPanel);
			this.Name = "GraphicsTextBoxList";
			this.Text = "テキストボックス一覧";
			allTableLayoutPanel.ResumeLayout(false);
			allTableLayoutPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.graphicsTextBoxEditDataGridView1)).EndInit();
			this.dataGridViewContextMenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private GraphicsTextBoxEditDataGridView graphicsTextBoxEditDataGridView1;
		private System.Windows.Forms.Button okButton;
		private ContextMenuStripEx dataGridViewContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
	}
}