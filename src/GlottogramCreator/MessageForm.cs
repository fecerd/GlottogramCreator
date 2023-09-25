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
	public partial class MessageForm : Form
	{
		static MessageForm Singleton { get; set; } = new();

		static Button OK { get; } = CreateButton("OK", DialogResult.OK, 0);

		static Button Cancel { get; } = CreateButton("キャンセル", DialogResult.Cancel, 6);

		static Button Yes { get; } = CreateButton("はい(&Y)", DialogResult.Yes, 1);

		static Button No { get; } = CreateButton("いいえ(&N)", DialogResult.No, 2);

		static Button Abort { get; } = CreateButton("中止(&A)", DialogResult.Abort, 3);

		static Button Retry { get; } = CreateButton("再試行(&R)", DialogResult.Retry, 4);

		static Button Ignore { get; } = CreateButton("無視(&I)", DialogResult.Ignore, 5);

		static Button Try { get; } = CreateButton("再実行(&T)", DialogResult.TryAgain, 7);

		static Button Continue { get; } = CreateButton("続行(&C)", DialogResult.Continue, 8);

		static Button CreateButton(string text, DialogResult dialogResult, int tabIndex) => new Button() { AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink, FlatStyle = FlatStyle.System, Text = text, DialogResult = dialogResult, TabIndex = tabIndex };

		static int ButtonRowIndex { get; } = 0;

		static int ButtonColummIndex { get; } = 3;

		public MessageForm()
		{
			InitializeComponent();
			//イベント設定
			Click += (object sender, EventArgs e) => ActiveControl = null;
			Shown += (object sender, EventArgs e) => ActiveControl = ActiveControl is not Button ? null : ActiveControl;
		}

		public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
		{
			if (Singleton is null) Singleton = new();
			Config.SetMainFont(Singleton);
			Singleton.Owner = owner as Form;
			Singleton.Text = caption ?? string.Empty;
			Singleton.messageTextBox.Text = text.Replace("\r\n", "\n").Replace("\n", "\r\n");
			Singleton.messageTextBox.SelectionStart = 0;
			Size size = TextRenderer.MeasureText(Singleton.messageTextBox.Text, Singleton.Font);
			Singleton.textBoxPanel.Width = size.Width + 6;
			Singleton.messageTextBox.Height = size.Height + 6;
			if (icon == MessageBoxIcon.Asterisk) Singleton.Icon = SystemIcons.Asterisk;
			else if (icon == MessageBoxIcon.Error) Singleton.Icon = SystemIcons.Error;
			else if (icon == MessageBoxIcon.Exclamation) Singleton.Icon = SystemIcons.Exclamation;
			else if (icon == MessageBoxIcon.Hand) Singleton.Icon = SystemIcons.Hand;
			else if (icon == MessageBoxIcon.Information) Singleton.Icon = SystemIcons.Information;
			else if (icon == MessageBoxIcon.Question) Singleton.Icon = SystemIcons.Question;
			else if (icon == MessageBoxIcon.Stop) Singleton.Icon = SystemIcons.Hand;
			else if (icon == MessageBoxIcon.Warning) Singleton.Icon = SystemIcons.Warning;
			else Singleton.Icon = null;
			TableLayoutPanel tableLayoutPanel = Singleton.tableLayoutPanel1;
			for (int i = 0; i <= ButtonColummIndex; ++i) if (tableLayoutPanel.GetControlFromPosition(i, ButtonRowIndex) is Button b) tableLayoutPanel.Controls.Remove(b);
			if (buttons == MessageBoxButtons.OK) tableLayoutPanel.Controls.Add(OK, ButtonColummIndex, ButtonRowIndex);
			else if (buttons == MessageBoxButtons.OKCancel)
			{
				tableLayoutPanel.Controls.Add(OK, ButtonColummIndex - 1, ButtonRowIndex);
				tableLayoutPanel.Controls.Add(Cancel, ButtonColummIndex, ButtonRowIndex);
			}
			else if (buttons == MessageBoxButtons.YesNo)
			{
				tableLayoutPanel.Controls.Add(Yes, ButtonColummIndex - 1, ButtonRowIndex);
				tableLayoutPanel.Controls.Add(No, ButtonColummIndex, ButtonRowIndex);
			}
			else if (buttons == MessageBoxButtons.YesNoCancel)
			{
				tableLayoutPanel.Controls.Add(Yes, ButtonColummIndex - 2, ButtonRowIndex);
				tableLayoutPanel.Controls.Add(No, ButtonColummIndex - 1, ButtonRowIndex);
				tableLayoutPanel.Controls.Add(Cancel, ButtonColummIndex, ButtonRowIndex);
			}
			else if (buttons == MessageBoxButtons.AbortRetryIgnore)
			{
				tableLayoutPanel.Controls.Add(Abort, ButtonColummIndex - 2, ButtonRowIndex);
				tableLayoutPanel.Controls.Add(Retry, ButtonColummIndex - 1, ButtonRowIndex);
				tableLayoutPanel.Controls.Add(Ignore, ButtonColummIndex, ButtonRowIndex);
			}
			else if (buttons == MessageBoxButtons.RetryCancel)
			{
				tableLayoutPanel.Controls.Add(Retry, ButtonColummIndex - 1, ButtonRowIndex);
				tableLayoutPanel.Controls.Add(Cancel, ButtonColummIndex, ButtonRowIndex);
			}
			else if (buttons == MessageBoxButtons.CancelTryContinue)
			{
				tableLayoutPanel.Controls.Add(Cancel, ButtonColummIndex - 2, ButtonRowIndex);
				tableLayoutPanel.Controls.Add(Try, ButtonColummIndex - 1, ButtonRowIndex);
				tableLayoutPanel.Controls.Add(Continue, ButtonColummIndex, ButtonRowIndex);
			}
			if (defaultButton == MessageBoxDefaultButton.Button1 && tableLayoutPanel.GetControlFromPosition(ButtonColummIndex, ButtonRowIndex) is Button b1) Singleton.ActiveControl = b1;
			else if (defaultButton == MessageBoxDefaultButton.Button2 && tableLayoutPanel.GetControlFromPosition(ButtonColummIndex - 1, ButtonRowIndex) is Button b2) Singleton.ActiveControl = b2;
			else if (defaultButton == MessageBoxDefaultButton.Button3 && tableLayoutPanel.GetControlFromPosition(ButtonColummIndex - 2, ButtonRowIndex) is Button b3) Singleton.ActiveControl = b3;
			else if (defaultButton == MessageBoxDefaultButton.Button4 && tableLayoutPanel.GetControlFromPosition(ButtonColummIndex - 3, ButtonRowIndex) is Button b4) Singleton.ActiveControl = b4;
			DialogResult ret = Singleton.ShowDialog();
			return ret;
		}

		public static DialogResult Show(string text) => Show(null, text, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
		public static DialogResult Show(string text, string caption) => Show(null, text, caption, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
		public static DialogResult Show(string text, string caption, MessageBoxButtons buttons) => Show(null, text, caption, buttons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
	}
}
