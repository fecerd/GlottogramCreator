using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Reflection;

namespace WinFormsApp1
{
	public class ColoredGroupBox : GroupBox
	{
		public ColoredGroupBox() : base()
		{
			DoubleBuffered = true;
		}

		[Browsable(true)]
		[Category("Extend")]
		[Description("グループ名の色")]
		[DefaultValue(typeof(Color), nameof(Color.Black))]
		public Color TextColor { get; set; } = Color.Black;

		[Browsable(true)]
		[Category("Extend")]
		[Description("枠線の色")]
		[DefaultValue(typeof(Color), nameof(Color.Black))]
		public Color BorderColor { get; set; } = Color.Black;

		[Browsable(true)]
		[Category("Extend")]
		[Description("枠線の太さ")]
		[DefaultValue(1)]
		public int BorderWidth { get; set; } = 1;

		[Browsable(true)]
		[Category("Extend")]
		[Description("枠線の種類")]
		[DefaultValue(typeof(ButtonBorderStyle), nameof(ButtonBorderStyle.Solid))]
		public ButtonBorderStyle BorderStyle { get; set; } = ButtonBorderStyle.Solid;

		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
			Size textSize = Size.Ceiling(e.Graphics.MeasureString(Text, Font));
			Rectangle borderRect = new(0, textSize.Height / 2, Width, Height - textSize.Height / 2);
			ControlPaint.DrawBorder(
				e.Graphics, borderRect,
				BorderColor, BorderWidth, BorderStyle,
				BorderColor, BorderWidth, BorderStyle,
				BorderColor, BorderWidth, BorderStyle,
				BorderColor, BorderWidth, BorderStyle
				);
			Rectangle textRect = new(6, 0, textSize.Width, textSize.Height);
			using SolidBrush backBrush = new(BackColor);
			e.Graphics.FillRectangle(backBrush, textRect);
			using SolidBrush foreBrush = new(TextColor);
			e.Graphics.DrawString(Text, Font, foreBrush, textRect.Location);
			return;
		}
	}
}
