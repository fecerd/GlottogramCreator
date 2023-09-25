using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace WinFormsApp1
{
	public class LineStyleComboBox : EnumComboBox
	{
		public LineStyleComboBox() : base()
		{
			AutoSize = false;
			DrawMode = DrawMode.OwnerDrawVariable;
			DropDownStyle = ComboBoxStyle.DropDownList;
			EnumName = "DashStyle";
		}

		[DefaultValue("DashStyle")]
		public override string EnumName { get => base.EnumName; set => base.EnumName = value; }

		[Browsable(false)]
		private new Enum SelectedEnumValue { get => base.SelectedEnumValue; set => base.SelectedEnumValue = value; }

		[Browsable(false)]
		public DashStyle SelectedDashStyle { get => (DashStyle)(base.SelectedEnumValue ?? DashStyle.Solid); set => base.SelectedEnumValue = value; }

		static EnumComboBox sizeCheck = null;

		protected override void OnFontChanged(EventArgs e)
		{
			base.OnFontChanged(e);
			if (sizeCheck is null || sizeCheck.Font != Font)
			{
				sizeCheck?.Dispose();
				sizeCheck = new() { Font = Font, EnumType = typeof(DashStyle) };
			}
			ItemHeight = sizeCheck.ItemHeight;
		}

		static StringFormat StringFormat { get; } = new() { LineAlignment = StringAlignment.Center };

		/// <summary>
		/// 描画関数
		/// </summary>
		/// <param name="e"></param>
		protected override void OnDrawItem(DrawItemEventArgs e)
		{
			if (GetItem(e.Index) is not DashStyle dashStyle || Items[e.Index] is not string name) return;
			e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			e.DrawBackground();

			Rectangle rectangle = e.Bounds;
			rectangle.Offset((int)(rectangle.Width * 0.02), (int)(rectangle.Height * 0.1));
			rectangle.Width = (int)(rectangle.Width * 0.3);
			rectangle.Height = (int)(rectangle.Height * 0.8);

			using Pen pen = new(e.ForeColor);
			pen.Width = 4;
			pen.DashOffset = 0.5f;
			pen.DashStyle = dashStyle;
			int y = rectangle.Y + (e.Bounds.Height - (int)pen.Width) / 2;
			e.Graphics.DrawLine(pen, new Point(rectangle.X, y), new Point(rectangle.X + rectangle.Width, y));

			using Brush textBrush = new SolidBrush(e.ForeColor);
			e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
			e.Graphics.DrawString(name, Font, textBrush, e.Bounds.X + rectangle.Width + e.Bounds.Width * 0.1f, e.Bounds.Y + e.Bounds.Height / 2, StringFormat);
			base.OnDrawItem(e);
			if (!Enabled)
			{
				using SolidBrush solidBrush = new(Color.FromArgb(128, SystemColors.ControlDark));
				e.Graphics.FillRectangle(solidBrush, e.Bounds);
			}
		}
	}
}
