using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WinFormsApp1
{
	public static class SingletonFontDialog
	{
		private static FontDialog singleton = null; //外部が使用できる唯一のインスタンス

		private static void InitializeSingleton(Font font, Color color)
		{
			if (singleton is null) singleton = new();
			if (font is not null)
			{
				Font = font;
				singleton.Font = font;
			}
			Color = color;
			singleton.Color = color;
		}

		public static void ShowDialog(Color color, Font font = null, Form owner = null)
		{
			InitializeSingleton(font, color);
			DialogResult dialogResult;
			if (owner is null) dialogResult = singleton.ShowDialog();
			else dialogResult = singleton.ShowDialog(owner);
			if (dialogResult == DialogResult.OK)
			{
				Font = singleton.Font;
				Color = singleton.Color;
			}
		}

		private static Font font = SystemFonts.DefaultFont.Clone() as Font;

		public static Font Font
		{
			get => font;
			private set
			{
				font?.Dispose();
				font = value;
			}
		}

		public static Color Color { get; private set; } = Color.Black;
	}
}
