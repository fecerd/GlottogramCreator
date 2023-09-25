using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
	public partial class GraphicsTextBoxList : GraphicsTextBoxList_Internal
	{
		public GraphicsTextBoxList()
		{
			InitializeComponent();
			Config.SetMainFont(this);
			graphicsTextBoxEditDataGridView1.ContextMenuStrip = dataGridViewContextMenuStrip;
			Shown += (object sender, EventArgs e) =>
			{
				graphicsTextBoxEditDataGridView1.SetItems(GlottogramProperty.TextBoxes);
			};
			okButton.Click += Button_Click;
		}

		void OpenEdit_Event(object sender, EventArgs e)
		{
			if (sender is not ToolStripMenuItem item || item.GetSourceControlEx() is not GraphicsTextBoxEditDataGridView dataGridView) return;
			if (dataGridView.SelectedItem is GraphicsTextBox graphicsTextBox)
			{
				if (EditGraphicsTextBox.ShowDialog(this, graphicsTextBox) == DialogResult.OK) dataGridView.UpdateView();
			}
			else MessageForm.Show("列が選択されていません。", "エラー", MessageBoxButtons.OK);
		}

		void Button_Click(object sender, EventArgs e)
		{
			if (sender is not Button button) return;
			if (button == okButton)
			{
				DialogResult = DialogResult.OK;
				Close();
			}
		}
	}

	public class GraphicsTextBoxList_Internal : SingletonForm<GraphicsTextBoxList> { }
}
