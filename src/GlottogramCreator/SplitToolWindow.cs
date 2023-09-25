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
	public partial class SplitToolWindow : Form
	{
		public SplitToolWindow()
		{
			InitializeComponent();
			Config.SetMainFont(this);
		}

		private void otherCheckBox_CheckedChanged(object sender, EventArgs e) => otherTextBox.Enabled = (sender as CheckBox).Checked;
	}
}
