using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WinFormsApp1
{
	public static class SingletonColorDialog
	{
		private static ColorDialog singleton = null; //外部が使用できる唯一のインスタンス

		private static void InitializeSingleton(Color selectedColor, bool allowFullOpen = true, bool fullOpen = true)
		{
			if (singleton is null) singleton = new();
			Color = selectedColor;
			singleton.Color = selectedColor;
			singleton.AllowFullOpen = allowFullOpen;
			singleton.FullOpen = fullOpen;
		}

		public static void ShowDialog(Color selectedColor, bool allowFullOpen = true, bool fullOpen = true, Form owner = null)
		{
			InitializeSingleton(selectedColor, allowFullOpen, fullOpen);
			DialogResult dialogResult;
			if (owner is null) dialogResult = singleton.ShowDialog();
			else dialogResult = singleton.ShowDialog(owner);
			if (dialogResult == DialogResult.OK) Color = singleton.Color;
		}

		public static Color Color { get; private set; } = Color.Black;
	}
}
