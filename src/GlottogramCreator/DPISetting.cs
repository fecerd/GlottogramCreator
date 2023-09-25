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
	public partial class DPISetting : DPISetting_Internal
	{
		public DPISetting()
		{
			InitializeComponent();
			Config.SetMainFont(this);
			formatEnumComboBox.SelectedEnumValue = Format.A4;
		}

		(int w, int h) GetMiliMeter()
		{
			Format format = formatEnumComboBox.GetSelectedEnumValue<Format>(Format.A4);
			if (format == Format.A4) return (210, 297);
			else if (format == Format.B5) return (176, 250);
			else return (0, 0);
		}

		void Button_Click(object sender, EventArgs e)
		{
			if (sender is not Button button) return;
			if (button == okButton)
			{			
				DialogResult = DialogResult.OK;
				int dpi = dpiNumberBox.GetValue<int>(0);
				if (dpi <= 0)
				{
					MessageForm.Show("DPIは1以上の値が必要です。", "エラー", MessageBoxButtons.OK);
					return;
				}
				int wMM, hMM;
				(wMM, hMM) = GetMiliMeter();
				if (wMM == 0 || hMM == 0)
				{
					MessageForm.Show("用紙サイズ設定が読み取れませんでした。", "エラー", MessageBoxButtons.OK);
					return;
				}
				int width = (int)(wMM * dpi / 25.4 + 0.5);
				int height = (int)(hMM * dpi / 25.4 + 0.5);
				float wScale = (float)width / GlottogramHelper.ImageWidth;
				float hScale = (float)height / GlottogramHelper.ImageHeight;
				{
					HeaderProperty.ColumnHeight = (int)(HeaderProperty.TrueColumnHeight * hScale);
					HeaderProperty.RowWidth = (int)(HeaderProperty.TrueRowWidth * wScale);
					Font columnFont = HeaderProperty.ColumnTextFont;
					HeaderProperty.ColumnTextFont = new Font(columnFont.FontFamily, columnFont.Size * MathF.Min(wScale, hScale), columnFont.Style, columnFont.Unit);
					Font rowFont = HeaderProperty.RowTextFont;
					HeaderProperty.RowTextFont = new Font(rowFont.FontFamily, rowFont.Size * MathF.Min(wScale, hScale), rowFont.Style, rowFont.Unit);
					Font topLeftFont = HeaderProperty.TopLeftTextFont;
					HeaderProperty.TopLeftTextFont = new Font(topLeftFont.FontFamily, topLeftFont.Size * MathF.Min(wScale, hScale), topLeftFont.Style, topLeftFont.Unit);
				}
				{
					LegendProperty.Padding = new Padding((int)(LegendProperty.Left * wScale), (int)(LegendProperty.Top * hScale), (int)(LegendProperty.Right * wScale), (int)(LegendProperty.Bottom * hScale));
					LegendProperty.RowHeight *= hScale;
					LegendProperty.SymbolScale *= MathF.Min(wScale, hScale);
					Font font = LegendProperty.SymbolProperty.NameFont;
					LegendProperty.SymbolProperty.NameFont = new Font(font.FontFamily, font.Size * MathF.Min(wScale, hScale), font.Style, font.Unit);
					font = LegendProperty.SymbolProperty.TextFont;
					LegendProperty.SymbolProperty.TextFont = new Font(font.FontFamily, font.Size * MathF.Min(wScale, hScale), font.Style, font.Unit);
					LegendProperty.SymbolProperty.Width = (int)(LegendProperty.SymbolProperty.Width * wScale);
					font = LegendProperty.ValueProperty.NameFont;
					LegendProperty.ValueProperty.NameFont = new Font(font.FontFamily, font.Size * MathF.Min(wScale, hScale), font.Style, font.Unit);
					font = LegendProperty.ValueProperty.TextFont;
					LegendProperty.ValueProperty.TextFont = new Font(font.FontFamily, font.Size * MathF.Min(wScale, hScale), font.Style, font.Unit);
					LegendProperty.ValueProperty.Width = (int)(LegendProperty.ValueProperty.Width * wScale);
					font = LegendProperty.CountProperty.NameFont;
					LegendProperty.CountProperty.NameFont = new Font(font.FontFamily, font.Size * MathF.Min(wScale, hScale), font.Style, font.Unit);
					font = LegendProperty.CountProperty.TextFont;
					LegendProperty.CountProperty.TextFont = new Font(font.FontFamily, font.Size * MathF.Min(wScale, hScale), font.Style, font.Unit);
					LegendProperty.CountProperty.Width = (int)(LegendProperty.CountProperty.Width * wScale);
				}
				{
					GlottogramProperty.Padding = new Padding((int)(GlottogramProperty.Left * wScale), (int)(GlottogramProperty.Top * hScale), (int)(GlottogramProperty.Right * wScale), (int)(GlottogramProperty.Bottom * hScale));
					GlottogramProperty.SymbolScale *= MathF.Min(wScale, hScale);
					foreach (GraphicsTextBox graphicsTextBox in GlottogramProperty.TextBoxes)
					{
						Font font = graphicsTextBox.Font;
						graphicsTextBox.Font = new(font.FontFamily, font.Size * MathF.Min(wScale, hScale), font.Style, font.Unit);
						RectangleF rect = graphicsTextBox.Rectangle;
						graphicsTextBox.Rectangle = new(rect.X * wScale, rect.Y * hScale, rect.Width * wScale, rect.Height * hScale);
					}
				}
				int w = width - (GlottogramHelper.LegendWidthWithPadding + GlottogramProperty.Horizontal + HeaderProperty.RowWidth);
				int h = height - (GlottogramProperty.Vertical + HeaderProperty.ColumnHeight);
				if (w <= 0) w = 1;
				if (h <= 0) h = 1;
				GlottogramProperty.Width = w;
				GlottogramProperty.Height = h;
			}
			else if (button == cancelButton) DialogResult = DialogResult.Cancel;
			else return;
			Close();
		}
	}
	public class DPISetting_Internal : SingletonForm<DPISetting> { }

	enum Format
	{
		A4,
		B5
	}

	partial class ToEnumName
	{
		static string ToEnumNameEx(Format value, int mode)
		{
			return value switch
			{
				Format.A4 => nameof(Format.A4),
				Format.B5 => nameof(Format.B5),
				_ => ""
			};
		}
	}
}
