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
	public partial class EditGraphicsTextBox : EditGraphicsTextBox_Internal
	{
		public EditGraphicsTextBox()
		{
			InitializeComponent();
			Config.SetMainFont(this);
			okButton.Click += Button_Click;
			cancelButton.Click += Button_Click;
			fontButton.Click += FontButton_Click;
		}

		GraphicsTextBox current = null;
		GraphicsTextBox Current
		{
			get => current;
			set
			{
				current = value;
				enabledCheckBox.Checked = current.Enabled;
				textTextBox.Text = current.Text;
				RectangleF rect = current.Rectangle;
				xNumberBox.Value = rect.X;
				yNumberBox.Value = rect.Y;
				widthNumberBox.Value = rect.Width;
				heightNumberBox.Value = rect.Height;
				paddingLeftNumberBox.Value = current.Left;
				paddingTopNumberBox.Value = current.Top;
				TextFont = current.Font;
				fontColorButton.Color = current.ForeColor;
				borderEnabledCheckBox.Checked = current.BorderEnabled;
				borderColorButton.Color = current.BorderColor;
				borderWidthNumberBox.Value = current.BorderWidth;
				borderStyleComboBox.SelectedDashStyle = current.BorderDashStyle;
				backColorButton.Color = current.BackColor;
				transparentCheckBox.Checked = current.IsTransparent;
			}
		}

		Font textFont = null;
		Font TextFont
		{
			get => textFont;
			set
			{
				if (value is not null)
				{
					textFont?.Dispose();
					textFont = value.Clone() as Font;
					fontNameTextBox.Text = textFont.Name;
					fontStyleTextBox.Text = textFont.Style.ToString();
					fontSizeTextBox.Text = textFont.Size.ToString() + " " + textFont.Unit.ToString();
					fontStrikeoutCheckBox.Checked = textFont.Strikeout;
					fontUnderlineCheckBox.Checked = textFont.Underline;
				}
			}
		}

		void Button_Click(object sender, EventArgs e)
		{
			if (sender is not Button button) return;
			if (button == okButton)
			{
				DialogResult = DialogResult.OK;
				if (current is not null)
				{
					current.Enabled = enabledCheckBox.Checked;
					current.Text = textTextBox.Text;
					current.Rectangle = new(
						xNumberBox.GetValue<float>(current.Rectangle.X),
						yNumberBox.GetValue<float>(current.Rectangle.Y),
						widthNumberBox.GetValue<float>(current.Rectangle.Width),
						heightNumberBox.GetValue<float>(current.Rectangle.Height)
						);
					current.Left = paddingLeftNumberBox.GetValue<float>(current.Left);
					current.Top = paddingTopNumberBox.GetValue<float>(current.Top);
					current.Font = TextFont.Clone() as Font;
					current.ForeColor = fontColorButton.Color;
					current.BorderEnabled = borderEnabledCheckBox.Checked;
					current.SetBorder(borderColorButton.Color, borderWidthNumberBox.GetValue<float>(1), borderStyleComboBox.SelectedDashStyle);
					current.BackColor = backColorButton.Color;
					current.IsTransparent = transparentCheckBox.Checked;
				}
				Close();
			}
			else if (button == cancelButton)
			{
				current = null;
				DialogResult = DialogResult.Cancel;
				Close();
			}
		}

		void FontButton_Click(object sender, EventArgs e)
		{
			if (FontDialogEx.ShowDialog(fontColorButton.Color, TextFont, this) == DialogResult.OK)
			{
				fontColorButton.Color = FontDialogEx.StaticColor;
				TextFont = FontDialogEx.StaticFont.Clone() as Font;
			}
		}

		public static DialogResult ShowDialog(Form owner = null, GraphicsTextBox graphicsTextBox = null)
		{
			EditGraphicsTextBox singleton = GetSingleton();
			singleton.Current = graphicsTextBox;
			if (singleton.Current is not null)
			{
				OpenOrShowDialog(owner);
				return StaticDialogResult;
			}
			else return DialogResult.Cancel;
		}
	}

	public class EditGraphicsTextBox_Internal : SingletonForm<EditGraphicsTextBox> { }
}
