using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml.Linq;

namespace WinFormsApp1
{
	public class GraphicsTextBox
	{
		Font m_font = new(Config.MainFont.FontFamily, Config.MainFont.Size * (Config.MainFont.Unit == GraphicsUnit.Point ? 1.33f : 1), FontStyle.Regular, GraphicsUnit.Pixel);
		Pen m_borderPen = InitializeHelper.CreatePen(Color.Black);

		public bool Enabled { get; set; } = true;
		public bool IsTransparent { get; set; } = false;
		public bool BorderEnabled { get; set; } = true;

		public float Left { get; set; } = 0;
		public float Top { get; set; } = 0;

		public Color BackColor { get; set; } = Color.White;
		public Color ForeColor { get; set; } = Color.Black;
		public Pen BorderPen {
			get => m_borderPen;
			private set
			{
				if (value is null) return;
				m_borderPen?.Dispose();
				m_borderPen = value.Clone() as Pen;
			}
		}
		public Color BorderColor
		{
			get => m_borderPen.Color;
			set => BorderPen = InitializeHelper.CreatePen(value, m_borderPen.Width, m_borderPen.DashStyle);
		}
		public float BorderWidth
		{
			get => m_borderPen.Width;
			set
			{
				if (value > 0) BorderPen = InitializeHelper.CreatePen(m_borderPen.Color, value, m_borderPen.DashStyle);
			}
		}
		public DashStyle BorderDashStyle
		{
			get => m_borderPen.DashStyle;
			set => BorderPen = InitializeHelper.CreatePen(m_borderPen.Color, m_borderPen.Width, value);
		}

		public RectangleF Rectangle { get; set; } = RectangleF.Empty;

		public string Text { get; set; } = null;
		public Font Font {
			get => m_font;
			set
			{
				if (value is null) return;
				m_font?.Dispose();
				m_font = value.Clone() as Font;
			}
		}

		public void SetBorder(Color color, float width, DashStyle dashStyle) => BorderPen = InitializeHelper.CreatePen(color, width, dashStyle);

		public void Dispose()
		{
			m_borderPen?.Dispose();
			m_borderPen = null;
			m_font?.Dispose();
			m_font = null;
			Text = null;
		}

		public void Draw(Graphics graphics)
		{
			if (graphics is null) return;
			if (!IsTransparent)
			{
				using Brush backBrush = new SolidBrush(BackColor);
				graphics.FillRectangle(backBrush, Rectangle);
			}
			using Brush foreBrush = new SolidBrush(ForeColor);
			RectangleF textRect = Rectangle;
			textRect.Width = (textRect.Width - Left).ClampEx(0, textRect.Width);
			textRect.Height = (textRect.Height - Top).ClampEx(0, textRect.Height);
			textRect.X += Left;
			textRect.Y += Top;
			graphics.DrawString(Text, Font, foreBrush, textRect);
			if (BorderEnabled) graphics.DrawRectangle(BorderPen, Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
		}
	}

	partial class FromXElement
	{
		public static GraphicsTextBox GetGraphicsTextBoxEx(this XElement element, GraphicsTextBox defaultValue)
		{
			GraphicsTextBox ret = new();
			if (defaultValue is not null)
			{
				ret.Enabled = defaultValue.Enabled;
				ret.IsTransparent = defaultValue.IsTransparent;
				ret.BorderEnabled = defaultValue.BorderEnabled;
				ret.Left = defaultValue.Left;
				ret.Top = defaultValue.Top;
				ret.BackColor = defaultValue.BackColor;
				ret.ForeColor = defaultValue.ForeColor;
				ret.SetBorder(defaultValue.BorderColor, defaultValue.BorderWidth, defaultValue.BorderDashStyle);
				ret.Rectangle = defaultValue.Rectangle;
				ret.Text = defaultValue.Text;
				ret.Font = defaultValue.Font.Clone() as Font;
			}
			foreach (XElement el in CommonGetEx(element))
			{
				if (el.GetAttributeValueEx("name") is not string propertyName) continue;
				if (propertyName == nameof(ret.Enabled)) ret.Enabled = el.Value.GetBoolEx(ret.Enabled);
				else if (propertyName == nameof(ret.IsTransparent)) ret.IsTransparent = el.Value.GetBoolEx(ret.IsTransparent);
				else if (propertyName == nameof(ret.BorderEnabled)) ret.BorderEnabled = el.Value.GetBoolEx(ret.BorderEnabled);
				else if (propertyName == nameof(ret.Left)) ret.Left = el.Value.GetFloatEx(ret.Left);
				else if (propertyName == nameof(ret.Top)) ret.Top = el.Value.GetFloatEx(ret.Top);
				else if (propertyName == nameof(ret.BackColor)) ret.BackColor = el.GetColorEx(ret.BackColor);
				else if (propertyName == nameof(ret.ForeColor)) ret.ForeColor = el.GetColorEx(ret.ForeColor);
				else if (propertyName == nameof(ret.BorderPen) && el.GetPenEx(ret.BorderPen) is Pen tPen) ret.SetBorder(tPen.Color, tPen.Width, tPen.DashStyle);
				else if (propertyName == nameof(ret.Rectangle)) ret.Rectangle = el.GetRectangleFEx(ret.Rectangle);
				else if (propertyName == nameof(ret.Text)) ret.Text = string.IsNullOrEmpty(el.Value) ? null : el.Value;
				else if (propertyName == nameof(ret.Font)) ret.Font = el.GetFontEx(ret.Font);
			}
			return ret;
		}
	}

	partial class ToXElement
	{
		public static XElement ToXElementEx(this GraphicsTextBox value, string elementName, string varName)
		{
			XElement ret = CommonToXElement(elementName, varName, nameof(GraphicsTextBox));
			ret.Add(
				value.Enabled.ToPropertyEx(nameof(value.Enabled)),
				value.IsTransparent.ToPropertyEx(nameof(value.IsTransparent)),
				value.BorderEnabled.ToPropertyEx(nameof(value.BorderEnabled)),
				value.Left.ToPropertyEx(nameof(value.Left)),
				value.Top.ToPropertyEx(nameof(value.Top)),
				value.BackColor.ToPropertyEx(nameof(value.BackColor)),
				value.ForeColor.ToPropertyEx(nameof(value.ForeColor)),
				value.BorderPen.ToPropertyEx(nameof(value.BorderPen)),
				value.Rectangle.ToPropertyEx(nameof(value.Rectangle)),
				value.Text.ToPropertyEx(nameof(value.Text)),
				value.Font.ToPropertyEx(nameof(value.Font))
				);
			return ret;
		}
	}

	partial class ToProperty
	{
		public static XElement ToPropertyEx(this GraphicsTextBox value, string name) => value.ToXElementEx("property", name);
	}
}
