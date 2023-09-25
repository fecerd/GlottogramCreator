using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace WinFormsApp1
{
	public class ColorButton : Button
	{
		public ColorButton()
		{
			this.FlatStyle = FlatStyle.Flat;
			this.FlatAppearance.BorderColor = SystemColors.WindowFrame;
			this.Text = "";
			this.Click += Event_Click;
		}

		[Browsable(false)]
		public override Color BackColor { get => base.BackColor; set => base.BackColor = value; }

		/// <summary>
		/// このボタンの色
		/// </summary>
		[Browsable(true)]
		[Category("Extend")]
		[DefaultValue(typeof(Color), "White")]
		[Description("この色選択ボタンに表示する色")]
		public Color Color
		{
			get => base.BackColor;
			set => base.BackColor = value;
		}

		[Browsable(true)]
		[Category("Extend")]
		[DefaultValue(true)]
		[Description("デフォルトのClickイベントを使用するか")]
		public bool EnableClick { get; set; } = true;

		private void Event_Click(object sender, EventArgs e)
		{
			if (!EnableClick) return;
			SingletonColorDialog.ShowDialog(this.BackColor);
			this.BackColor = SingletonColorDialog.Color;
		}
	}
}
