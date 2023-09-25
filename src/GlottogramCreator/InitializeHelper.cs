using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
	/// <summary>
	/// インスタンス化と同時にプロパティを設定できるヘルパー関数クラス
	/// </summary>
	public static class InitializeHelper
	{
		/// <summary>
		/// 新たにPen型のインスタンスを作成する。
		/// </summary>
		/// <param name="color">線の色</param>
		/// <param name="width">線の太さ</param>
		/// <param name="dashStyle">線のスタイル</param>
		/// <returns>プロパティを設定したPen</returns>
		public static Pen CreatePen(Color color, float width = 1.0f, System.Drawing.Drawing2D.DashStyle dashStyle = System.Drawing.Drawing2D.DashStyle.Solid)
		{
			Pen ret = new(color, width);
			ret.DashStyle = dashStyle;
			return ret;
		}

		/// <summary>
		/// <para>新たにStringFormat型のインスタンスを作成する。</para>
		/// <para>StringAlignment：</para>
		/// <para>Near => 左揃え、上揃え</para>
		/// <para>Center => 中央揃え</para>
		/// <para>Far => 右揃え、下揃え</para>
		/// </summary>
		/// <param name="alignment">水平方向の位置</param>
		/// <param name="lineAlignment">垂直方向の位置</param>
		/// <returns>プロパティを指定したStringFormat</returns>
		public static StringFormat CreateStringFormat(StringAlignment alignment, StringAlignment lineAlignment)
		{
			StringFormat ret = new();
			ret.Alignment = alignment;
			ret.LineAlignment = lineAlignment;
			return ret;
		}


		public static Icon CreateIconFromResource(Type type, string resourcefilename, Icon defaultValue = null)
		{
			try
			{
				return new Icon(type, resourcefilename);
			}
			catch
			{
				return defaultValue;
			}
		}
	}
}
