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
	public partial class FontDialogEx : FontDialogEx_Internal
	{
		public FontDialogEx()
		{
			InitializeComponent();
			Config.SetMainFont(this);
			using System.Drawing.Text.InstalledFontCollection collection = new();
			FontFamilies = collection.Families;
			Shown += (object sender, EventArgs e) =>
			{
				EnableUpdate = false;
				Font_Changed();
				EnableUpdate = true;
			};
			okButton.Click += (object sender, EventArgs e) =>
			{
				Font_Update();
			};
			fontNameListBox.SelectedIndexChanged += SelectedIndexChanged_Event;
			fontStyleListBox.SelectedIndexChanged += SelectedIndexChanged_Event;
			fontSizeListBox.SelectedIndexChanged += SelectedIndexChanged_Event;
			fontSizeNumberBox.TextChanged += TextChanged_Event;
			strikeoutCheckBox.CheckedChanged += CheckedChanged_Event;
			underlineCheckBox.CheckedChanged += CheckedChanged_Event;
			fontColorButton.BackColorChanged += ColorChanged_Event;
		}

		FontFamily[] FontFamilies { set; get; }

		List<(string Name, FontStyle style)> FontStyles { get; } = new[] { ("標準", FontStyle.Regular), ("太字", FontStyle.Bold), ("斜体", FontStyle.Italic), ("太字斜体", FontStyle.Bold | FontStyle.Italic) }.ToList();

		Font font = null;
		new Font Font
		{
			get => font;
			set
			{
				font?.Dispose();
				font = value.Clone() as Font;
			}
		}

		Color Color { get; set; } = Color.Black;

		public static Font StaticFont { get => GetSingleton().Font.Clone() as Font; }

		public static Color StaticColor { get => GetSingleton().Color; }

		bool EnableUpdate { get; set; } = true;

		void Load_Event(object sender, EventArgs e)
		{
			if (FontFamilies.Length < 1) return;
			EnableUpdate = false;
			fontNameListBox.Items.Clear();
			foreach (var f in FontFamilies) fontNameListBox.Items.Add(f.Name);
			fontStyleListBox.Items.Clear();
			foreach (var s in FontStyles) fontStyleListBox.Items.Add(s.Name);
			fontSizeListBox.Items.Clear();
			foreach (var size in Enumerable.Range(5, 60)) fontSizeListBox.Items.Add(size);
			if (Font is null) Font = base.Font.Clone() as Font;
			EnableUpdate = true;
		}

		void Font_Changed()
		{
			int index = fontNameListBox.Items.IndexOf(Font.Name);
			fontNameListBox.SelectedIndex = index != -1 ? index : 0;
			index = FontStyles.IndexOf(FontStyles.Where(x => x.style == Font.Style).FirstOrDefault());
			fontStyleListBox.SelectedIndex = index != -1 ? index : 0;
			if (Font.Unit == GraphicsUnit.Pixel)
			{
				if (Font.Size.IsInteger(0.01f, out int i) && i.IsRangeClosed(5, 60))
				{
					fontSizeListBox.SelectedItem = i;
					fontSizeNumberBox.Value = i;
				}
				else fontSizeNumberBox.Value = Font.Size;
			}
			else if (Font.Unit == GraphicsUnit.Point)
			{
				float size = Font.Size * 1.33f;
				if (size.IsInteger(0.01f, out int i) && i.IsRangeClosed(5, 60))
				{
					fontSizeListBox.SelectedItem = i;
					fontSizeNumberBox.Value = i;
				}
				else fontSizeNumberBox.Value = size;
			}
			else fontSizeListBox.SelectedItem = 10;
			strikeoutCheckBox.Checked = Font.Strikeout;
			underlineCheckBox.Checked = Font.Underline;
			sampleLabel.Font = Font.Clone() as Font;
		}

		void Color_Changed() { fontColorButton.Color = Color; }

		void SelectedIndexChanged_Event(object sender, EventArgs e)
		{
			if (sender is not ListBox listBox) return;
			if (listBox == fontNameListBox) fontNameTextBox.Text = listBox.SelectedIndex == -1 ? null : listBox.SelectedItem as string;
			else if (listBox == fontStyleListBox) fontStyleTextBox.Text = listBox.SelectedIndex == -1 ? null : listBox.SelectedItem as string;
			else if (listBox == fontSizeListBox && listBox.SelectedIndex != -1) fontSizeNumberBox.Value = (int)listBox.SelectedItem;
			if (EnableUpdate) Font_Update();
		}

		void CheckedChanged_Event(object sender, EventArgs e) { if (EnableUpdate) Font_Update(); }

		void TextChanged_Event(object sender, EventArgs e) { if (EnableUpdate) Font_Update(true); }

		void ColorChanged_Event(object sender, EventArgs e)
		{
			if (sender is not ColorButton colorButton) return;
			if (colorButton == fontColorButton) Color = colorButton.Color;
			sampleLabel.ForeColor = Color;
		}

		void Font_Update(bool textChaned = false)
		{
			if (fontStyleListBox.SelectedIndex == -1) return;
			FontFamily fontFamily = 0 <= fontNameListBox.SelectedIndex && fontNameListBox.SelectedIndex < FontFamilies.Length ? FontFamilies[fontNameListBox.SelectedIndex] : Config.MainFont.FontFamily;
			FontStyle fontStyle = 0 <= fontStyleListBox.SelectedIndex && fontStyleListBox.SelectedIndex < FontStyles.Count ? FontStyles[fontStyleListBox.SelectedIndex].style : FontStyle.Regular;
			if (strikeoutCheckBox.Checked) fontStyle |= FontStyle.Strikeout;
			if (underlineCheckBox.Checked) fontStyle |= FontStyle.Underline;
			float emSize = textChaned ? fontSizeNumberBox.Text.GetFloatEx(Font.Size) : fontSizeNumberBox.GetValue<float>(Font.Size);
			if (Font.FontFamily == fontFamily && Font.Style == fontStyle && Font.Size == emSize && Font.Unit == GraphicsUnit.Pixel) return;
			using Font f = new(fontFamily, emSize, fontStyle, GraphicsUnit.Pixel);
			font?.Dispose();
			font = f.Clone() as Font;
			sampleLabel.Font = Font.Clone() as Font;
		}

		public static DialogResult ShowDialog(Color color, Font font = null, Form owner = null)
		{
			FontDialogEx singleton = GetSingleton();
			singleton.Color = color;
			singleton.Color_Changed();
			singleton.Font = font?.Clone() as Font ?? Config.MainFont.Clone() as Font;
			OpenOrShowDialog(owner);
			return StaticDialogResult;
		}
	}
	public class FontDialogEx_Internal : SingletonForm<FontDialogEx> { }
}
