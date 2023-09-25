using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
	/// <summary>
	/// シングルトンで運用されるForm
	/// <para>・使用例</para>
	/// <para>class DerivedForm : DerivedForm_Internal {}</para>
	/// <para>class DerivedForm_Internal : <see cref="SingletonForm{DerivedForm}" /> {}</para>
	/// </summary>
	/// <typeparam name="DerivedForm">シングルトンフォーム</typeparam>
	public class SingletonForm<DerivedForm> : Form where DerivedForm : SingletonForm<DerivedForm>
	{
		/// <summary>
		/// ダイアログに紐づけられるデータ
		/// </summary>
		public object DialogReturn { get; set; } = null;

		private static DerivedForm singleton = null; //外部が使用できる唯一のインスタンス
		private static FormWindowState windowState = FormWindowState.Normal;    //singletonの以前の状態を保持

		/// <summary>
		/// DerivedFormのもつデフォルトコンストラクタを呼び出す。
		/// </summary>
		/// <returns>
		/// <para>DerivedFormのインスタンス</para>
		/// </returns>
		private static DerivedForm NewForm()
		{
			Type typeInfo = typeof(DerivedForm);
			var result = typeInfo.GetConstructor(System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public, Type.EmptyTypes);
			return result.Invoke(null) as DerivedForm;
		}

		/// <summary>
		/// 変更後のフォームサイズを保存する
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private static void Event_SizeChanged(object sender, EventArgs e)
		{
			if ((sender as Form).WindowState != FormWindowState.Minimized) windowState = (sender as Form).WindowState;
		}

		/// <summary>
		/// フォームが最小化されているとき、以前の大きさに戻す
		/// </summary>
		private static void Restore()
		{
			if (singleton != null && singleton.WindowState == FormWindowState.Minimized) singleton.WindowState = windowState;
		}

		/// <summary>
		/// DerivedFormのシングルトンなインスタンスを取得する。存在しない場合、新たに作成される。
		/// </summary>
		/// <returns>DerivedFormのインスタンス。存在しない場合、Visible=falseでフォームが作成される。</returns>
		public static DerivedForm GetSingleton()
		{
			if (singleton == null || singleton.IsDisposed)
			{
				singleton = NewForm();
				singleton.SizeChanged += new EventHandler(Event_SizeChanged);
				singleton.Visible = false;
			}
			return singleton;
		}

		/// <summary>
		/// シングルトンなフォームを起動する。すでに起動している場合、最前面に表示する
		/// </summary>
		/// <param name="owner">子フォームとして設定する。</param>
		public static void OpenOrShow(Form owner = null)
		{
			DerivedForm form = GetSingleton();
			form.Owner = owner;
			Restore();
			form.Show();
			form.Activate();
		}

		/// <summary>
		/// シングルトンなダイアログを起動する。すでに起動している場合、最前面に表示する
		/// </summary>
		/// <param name="owner">子フォームとして設定する。</param>
		public static void OpenOrShowDialog(Form owner = null)
		{
			DerivedForm form = GetSingleton();
			form.Owner = owner;
			if (form.Visible == true)
			{
				Restore();
				form.Activate();
				return;
			}
			form.DialogReturn = null;
			form.ShowDialog();
			form.Owner = null;
		}

		public static DialogResult StaticDialogResult
		{
			get
			{
				return singleton.DialogResult;
			}
		}

		public static object StaticDialogReturn
		{
			get
			{
				return singleton.DialogReturn;
			}
		}
	}
}
