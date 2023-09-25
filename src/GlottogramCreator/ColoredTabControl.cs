using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
	public class ColoredTabControl : TabControl
	{
		public ColoredTabControl()
		{
			this.DrawMode = TabDrawMode.OwnerDrawFixed;
			this.DrawItem += Event_DrawItem;
		}

		private void Event_DrawItem(object sender, DrawItemEventArgs e)
		{
			if (sender is not TabControl tabControl) return;
			string text = tabControl.TabPages[e.Index].Text;
			Color backColor = e.State == DrawItemState.Selected ? tabControl.TabPages[e.Index].BackColor : ControlPaint.Light(tabControl.TabPages[e.Index].BackColor);
			Color foreColor = e.State == DrawItemState.Selected ? tabControl.TabPages[e.Index].ForeColor : ControlPaint.Light(tabControl.TabPages[e.Index].ForeColor);
			using Brush backBrush = new SolidBrush(backColor);
			using Brush foreBrush = new SolidBrush(foreColor);
			using StringFormat stringFormat = new();
			stringFormat.Alignment = StringAlignment.Center;
			stringFormat.LineAlignment = StringAlignment.Center;
			e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
			e.Graphics.FillRectangle(backBrush, e.Bounds);
			e.Graphics.DrawString(text, e.Font, foreBrush, e.Bounds, stringFormat);
		}
	}
}
