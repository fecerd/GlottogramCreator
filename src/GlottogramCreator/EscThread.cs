using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace WinFormsApp1
{
	static class EscThread
	{
		static object mutex = new();
		static bool pressed = false;
		public static bool Pressed
		{
			get { lock (mutex) return pressed; }
			private set { lock (mutex) pressed = value; }
		}

		static Form Form { get; set; } = null;
		static Action Action { get; set; } = null;
		static Action Final { get; set; } = null;
		static Thread Thread { get; set; } = null;

		static void KeyDown_Event(object sender, KeyEventArgs e) { if (e.KeyData == Keys.Escape) Pressed = true; }

		public static void Start(Form form, Action action, Action final)
		{
			Pressed = false;
			Form = form;
			if (Form is not null) Form.KeyDown += KeyDown_Event;
			Action = action;
			Final = final;
			Thread = new(new ThreadStart(Invoke)) { IsBackground = true };
			Thread.Start();
		}

		public static void Stop() => Pressed = true;

		static void Invoke()
		{
			try
			{
				if (Action is not null) Action();
			}
			finally
			{
				if (Final is not null) Final();
				Action = null;
				Final = null;
				if (Form is not null) Form.KeyDown -= KeyDown_Event;
				Form = null;
				Pressed = false;
			}
		}
	}
}
