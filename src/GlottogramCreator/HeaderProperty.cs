using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WinFormsApp1
{
	/// <summary>
	/// ヘッダーの基本設定
	/// </summary>
	public static class HeaderProperty
	{
		private static class Default
		{
			public static int ColumnHeight => 30;
			public static int RowWidth => 200;
			public static Pen ColumnLinePen => InitializeHelper.CreatePen(Color.Black, 2.0f);
			public static Pen RowLinePen => InitializeHelper.CreatePen(Color.Black, 2.0f);
			public static Pen ColumnGridPen => InitializeHelper.CreatePen(Color.Gray, 1.0f);
			public static Pen RowGridPen => InitializeHelper.CreatePen(Color.Gray, 1.0f);
			public static Font TopLeftTextFont => new(SystemFonts.DefaultFont.FontFamily, 24, GraphicsUnit.Pixel);
			public static Font ColumnTextFont => new(SystemFonts.DefaultFont.FontFamily, 24, GraphicsUnit.Pixel);
			public static Font RowTextFont => new(SystemFonts.DefaultFont.FontFamily, 24, GraphicsUnit.Pixel);
			public static SolidBrush TopLeftTextBrush => new(Color.Black);
			public static SolidBrush ColumnTextBrush => new(Color.Black);
			public static SolidBrush RowTextBrush => new(Color.Black);
			public static StringFormat TopLeftTextFormat => InitializeHelper.CreateStringFormat(StringAlignment.Near, StringAlignment.Center);
			public static StringFormat ColumnTextFormat => InitializeHelper.CreateStringFormat(StringAlignment.Near, StringAlignment.Center);
			public static StringFormat RowTextFormat => InitializeHelper.CreateStringFormat(StringAlignment.Near, StringAlignment.Center);
			public static int ColumnTextTick => 10;
			public static int RowTextTick => 1;
		}

		public static void Load(string uri)
		{
			XDocument xDocument = XDocumentExtend.LoadEx(uri);
			IEnumerable<XElement> elements = xDocument?.GetRootElementByNameEx("class", "name", nameof(HeaderProperty))?.Elements();
			if (elements is null) return;
			foreach (var el in elements)
			{
				string propertyName = el.GetAttributeValueEx("name");
				if (propertyName is null) continue;
				if (propertyName == nameof(ColumnIsEnabled)) ColumnIsEnabled = el.Value.GetBoolEx(ColumnIsEnabled);
				else if (propertyName == nameof(RowIsEnabled)) RowIsEnabled = el.Value.GetBoolEx(RowIsEnabled);
				else if (propertyName == nameof(ColumnLineIsEnabled)) ColumnLineIsEnabled = el.Value.GetBoolEx(ColumnLineIsEnabled);
				else if (propertyName == nameof(RowLineIsEnabled)) RowLineIsEnabled = el.Value.GetBoolEx(RowLineIsEnabled);
				else if (propertyName == nameof(ColumnGridIsEnabled)) ColumnGridIsEnabled = el.Value.GetBoolEx(ColumnGridIsEnabled);
				else if (propertyName == nameof(RowGridIsEnabled)) RowGridIsEnabled = el.Value.GetBoolEx(RowGridIsEnabled);
				else if (propertyName == nameof(TopLeftTextIsEnabled)) TopLeftTextIsEnabled = el.Value.GetBoolEx(TopLeftTextIsEnabled);
				else if (propertyName == nameof(ColumnTextIsEnabled)) ColumnTextIsEnabled = el.Value.GetBoolEx(ColumnTextIsEnabled);
				else if (propertyName == nameof(RowTextIsEnabled)) RowTextIsEnabled = el.Value.GetBoolEx(RowTextIsEnabled);
				else if (propertyName == nameof(ColumnHeight)) ColumnHeight = el.Value.GetIntEx(ColumnHeight);
				else if (propertyName == nameof(RowWidth)) RowWidth = el.Value.GetIntEx(RowWidth);
				else if (propertyName == nameof(ColumnLinePen)) ColumnLinePen = el.GetPenEx(ColumnLinePen);
				else if (propertyName == nameof(RowLinePen)) RowLinePen = el.GetPenEx(RowLinePen);
				else if (propertyName == nameof(ColumnGridPen)) ColumnGridPen = el.GetPenEx(ColumnGridPen);
				else if (propertyName == nameof(RowGridPen)) RowGridPen = el.GetPenEx(RowGridPen);
				else if (propertyName == nameof(TopLeftTextFont)) TopLeftTextFont = el.GetFontEx(TopLeftTextFont);
				else if (propertyName == nameof(ColumnTextFont)) ColumnTextFont = el.GetFontEx(ColumnTextFont);
				else if (propertyName == nameof(RowTextFont)) RowTextFont = el.GetFontEx(RowTextFont);
				else if (propertyName == nameof(TopLeftTextBrush)) TopLeftTextBrush = el.GetSolidBrushEx(TopLeftTextBrush);
				else if (propertyName == nameof(ColumnTextBrush)) ColumnTextBrush = el.GetSolidBrushEx(ColumnTextBrush);
				else if (propertyName == nameof(RowTextBrush)) RowTextBrush = el.GetSolidBrushEx(RowTextBrush);
				else if (propertyName == nameof(TopLeftTextFormat)) TopLeftTextFormat = el.GetStringFormatEx(TopLeftTextFormat);
				else if (propertyName == nameof(ColumnTextFormat)) ColumnTextFormat = el.GetStringFormatEx(ColumnTextFormat);
				else if (propertyName == nameof(RowTextFormat)) RowTextFormat = el.GetStringFormatEx(RowTextFormat);
				else if (propertyName == nameof(ColumnTextTick)) ColumnTextTick = el.Value.GetIntEx(ColumnTextTick);
				else if (propertyName == nameof(RowTextTick)) RowTextTick = el.Value.GetIntEx(RowTextTick);
				else if (propertyName == nameof(TopLeftText)) TopLeftText = el.Value;
			}
		}

		public static XElement Output()
		{
			XElement headerProperty = new("class", new XAttribute("name", nameof(HeaderProperty)));
			headerProperty.Add(ColumnIsEnabled.ToPropertyEx(nameof(ColumnIsEnabled)));
			headerProperty.Add(RowIsEnabled.ToPropertyEx(nameof(RowIsEnabled)));
			headerProperty.Add(ColumnLineIsEnabled.ToPropertyEx(nameof(ColumnLineIsEnabled)));
			headerProperty.Add(RowLineIsEnabled.ToPropertyEx(nameof(RowLineIsEnabled)));
			headerProperty.Add(ColumnGridIsEnabled.ToPropertyEx(nameof(ColumnGridIsEnabled)));
			headerProperty.Add(RowGridIsEnabled.ToPropertyEx(nameof(RowGridIsEnabled)));
			headerProperty.Add(TopLeftTextIsEnabled.ToPropertyEx(nameof(TopLeftTextIsEnabled)));
			headerProperty.Add(ColumnTextIsEnabled.ToPropertyEx(nameof(ColumnTextIsEnabled)));
			headerProperty.Add(RowTextIsEnabled.ToPropertyEx(nameof(RowTextIsEnabled)));
			headerProperty.Add(columnHeight.ToPropertyEx(nameof(ColumnHeight)));	//Getは他のプロパティに依存するため内部変数を出力
			headerProperty.Add(rowWidth.ToPropertyEx(nameof(RowWidth)));    //Getは他のプロパティに依存するため内部変数を出力
			headerProperty.Add(ColumnLinePen.ToPropertyEx(nameof(ColumnLinePen)));
			headerProperty.Add(RowLinePen.ToPropertyEx(nameof(RowLinePen)));
			headerProperty.Add(ColumnGridPen.ToPropertyEx(nameof(ColumnGridPen)));
			headerProperty.Add(RowGridPen.ToPropertyEx(nameof(RowGridPen)));
			headerProperty.Add(TopLeftTextFont.ToPropertyEx(nameof(TopLeftTextFont)));
			headerProperty.Add(ColumnTextFont.ToPropertyEx(nameof(ColumnTextFont)));
			headerProperty.Add(RowTextFont.ToPropertyEx(nameof(RowTextFont)));
			headerProperty.Add(TopLeftTextBrush.ToPropertyEx(nameof(TopLeftTextBrush)));
			headerProperty.Add(ColumnTextBrush.ToPropertyEx(nameof(ColumnTextBrush)));
			headerProperty.Add(RowTextBrush.ToPropertyEx(nameof(RowTextBrush)));
			headerProperty.Add(TopLeftTextFormat.ToPropertyEx(nameof(TopLeftTextFormat)));
			headerProperty.Add(ColumnTextFormat.ToPropertyEx(nameof(ColumnTextFormat)));
			headerProperty.Add(RowTextFormat.ToPropertyEx(nameof(RowTextFormat)));
			headerProperty.Add(ColumnTextTick.ToPropertyEx(nameof(ColumnTextTick)));
			headerProperty.Add(RowTextTick.ToPropertyEx(nameof(RowTextTick)));
			headerProperty.Add(TopLeftText.ToPropertyEx(nameof(TopLeftText)));
			return headerProperty;
		}

		public static void Reset()
		{
			ColumnIsEnabled = true;
			RowIsEnabled = true;
			ColumnLineIsEnabled = true;
			RowLineIsEnabled = true;
			ColumnGridIsEnabled = true;
			RowGridIsEnabled = true;
			TopLeftTextIsEnabled = false;
			ColumnTextIsEnabled = true;
			RowTextIsEnabled = true;
			ColumnHeight = Default.ColumnHeight;
			RowWidth = Default.RowWidth;
			ColumnLinePen = Default.ColumnLinePen;
			RowLinePen = Default.RowLinePen;
			ColumnGridPen = Default.ColumnGridPen;
			RowGridPen = Default.RowGridPen;
			TopLeftTextFont = Default.TopLeftTextFont;
			ColumnTextFont = Default.ColumnTextFont;
			RowTextFont = Default.RowTextFont;
			TopLeftTextBrush = Default.TopLeftTextBrush;
			ColumnTextBrush = Default.ColumnTextBrush;
			RowTextBrush = Default.RowTextBrush;
			TopLeftTextFormat = Default.TopLeftTextFormat;
			ColumnTextFormat = Default.ColumnTextFormat;
			RowTextFormat = Default.RowTextFormat;
			ColumnTextTick = Default.ColumnTextTick;
			RowTextTick = Default.RowTextTick;
			TopLeftText = string.Empty;
		}

		static int columnHeight = Default.ColumnHeight;
		static int rowWidth = Default.RowWidth;
		static Pen columnLinePen = Default.ColumnLinePen;
		static Pen rowLinePen = Default.RowLinePen;
		static Pen columnGridPen = Default.ColumnGridPen;
		static Pen rowGridPen = Default.RowGridPen;
		static Font topLeftTextFont = Default.TopLeftTextFont;
		static Font columnTextFont = Default.ColumnTextFont;
		static Font rowTextFont = Default.RowTextFont;
		static SolidBrush topLeftTextBrush = Default.TopLeftTextBrush;
		static SolidBrush columnTextBrush = Default.ColumnTextBrush;
		static SolidBrush rowTextBrush = Default.RowTextBrush;
		static StringFormat topLeftTextFormat = Default.TopLeftTextFormat;
		static StringFormat columnTextFormat = Default.ColumnTextFormat;
		static StringFormat rowTextFormat = Default.RowTextFormat;
		static int columnTextTick = Default.ColumnTextTick;
		static int rowTextTick = Default.RowTextTick;
		static string topLeftText = string.Empty;

		/// <summary>
		/// ColumnHeightに登録されている実際の値
		/// </summary>
		public static int TrueColumnHeight => columnHeight;

		/// <summary>
		/// RowWidthに登録されている実際の値
		/// </summary>
		public static int TrueRowWidth => rowWidth;

		/// <summary>
		/// 列ヘッダーを描画するか否か
		/// </summary>
		public static bool ColumnIsEnabled { get; set; } = true;

		/// <summary>
		/// 列ヘッダーの外枠の線を描画するか否か
		/// </summary>
		public static bool ColumnLineIsEnabled { get; set; } = true;

		/// <summary>
		/// 列ヘッダーの線を描画するか否か
		/// </summary>
		public static bool ColumnGridIsEnabled { get; set; } = true;

		/// <summary>
		/// 行ヘッダーを描画するか否か
		/// </summary>
		public static bool RowIsEnabled { get; set; } = true;

		/// <summary>
		/// 行ヘッダーの外枠の線を描画するか否か
		/// </summary>
		public static bool RowLineIsEnabled { get; set; } = true;

		/// <summary>
		/// 行ヘッダーの線を描画するか否か
		/// </summary>
		public static bool RowGridIsEnabled { get; set; } = true;

		/// <summary>
		/// ヘッダー左上にテキストを描画するか否か
		/// </summary>
		public static bool TopLeftTextIsEnabled { get; set; } = false;

		/// <summary>
		/// 列ヘッダーのテキストを描画するか否か
		/// </summary>
		public static bool ColumnTextIsEnabled { get; set; } = true;

		/// <summary>
		/// 行ヘッダーのテキストを描画するか否か
		/// </summary>
		public static bool RowTextIsEnabled { get; set; } = true;

		/// <summary>
		/// 列ヘッダーの高さ。ColumnIsEnabledがfalseのとき、0を返す
		/// </summary>
		public static int ColumnHeight { get => ColumnIsEnabled ? columnHeight : 0; set => columnHeight = value < 0 ? Default.ColumnHeight : value; }

		/// <summary>
		/// 行ヘッダーの幅。RowIsEnabledがfalseのとき、0を返す
		/// </summary>
		public static int RowWidth { get => RowIsEnabled ? rowWidth : 0; set => rowWidth = value < 0 ? Default.RowWidth : value; }

		/// <summary>
		/// 列ヘッダーの外枠
		/// </summary>
		public static Pen ColumnLinePen
		{
			get => columnLinePen;
			set
			{
				columnLinePen?.Dispose();
				columnLinePen = value ?? Default.ColumnLinePen;
			}
		}
		
		/// <summary>
		/// 行ヘッダーの外枠
		/// </summary>
		public static Pen RowLinePen
		{
			get => rowLinePen;
			set
			{
				rowLinePen?.Dispose();
				rowLinePen = value ?? Default.RowLinePen;
			}
		}

		/// <summary>
		/// 列ヘッダーの境界線
		/// </summary>
		public static Pen ColumnGridPen
		{
			get => columnGridPen;
			set
			{
				columnGridPen?.Dispose();
				columnGridPen = value ?? Default.ColumnGridPen;
			}
		}

		/// <summary>
		/// 行ヘッダーの境界線
		/// </summary>
		public static Pen RowGridPen
		{
			get => rowGridPen;
			set
			{
				rowGridPen?.Dispose();
				rowGridPen = value ?? Default.RowGridPen;
			}
		}

		/// <summary>
		/// ヘッダー左上に描画するテキストのフォント
		/// </summary>
		public static Font TopLeftTextFont
		{
			get => topLeftTextFont;
			set
			{
				topLeftTextFont?.Dispose();
				topLeftTextFont = value ?? Default.TopLeftTextFont;
			}
		}

		/// <summary>
		/// 列ヘッダーに描画するテキストのフォント
		/// </summary>
		public static Font ColumnTextFont {
			get => columnTextFont;
			set
			{
				columnTextFont?.Dispose();
				columnTextFont = value ?? Default.ColumnTextFont;
			}
		}

		/// <summary>
		/// 行ヘッダーに描画するテキストのフォント
		/// </summary>
		public static Font RowTextFont {
			get => rowTextFont;
			set
			{
				rowTextFont?.Dispose();
				rowTextFont = value ?? Default.RowTextFont;
			}
		}

		/// <summary>
		/// ヘッダー左上に描画するテキストのブラシの色
		/// </summary>
		public static Color TopLeftTextBrushColor { set => TopLeftTextBrush = new SolidBrush(value); }

		/// <summary>
		/// 列ヘッダーに描画するテキストのブラシの色
		/// </summary>
		public static Color ColumnTextBrushColor { set => ColumnTextBrush = new SolidBrush(value); }

		/// <summary>
		/// 行ヘッダーに描画するテキストのブラシの色
		/// </summary>
		public static Color RowTextBrushColor { set => RowTextBrush = new SolidBrush(value); }

		/// <summary>
		/// ヘッダー左上に描画するテキストのブラシ
		/// </summary>
		public static SolidBrush TopLeftTextBrush
		{
			get => topLeftTextBrush;
			private set
			{
				topLeftTextBrush?.Dispose();
				topLeftTextBrush = value ?? Default.TopLeftTextBrush;
			}
		}

		/// <summary>
		/// 列ヘッダーに描画するテキストのブラシ
		/// </summary>
		public static SolidBrush ColumnTextBrush
		{
			get => columnTextBrush;
			private set
			{
				columnTextBrush?.Dispose();
				columnTextBrush = value ?? Default.ColumnTextBrush;
			}
		}

		/// <summary>
		/// 行ヘッダーに描画するテキストのブラシ
		/// </summary>
		public static SolidBrush RowTextBrush
		{
			get => rowTextBrush;
			private set
			{
				rowTextBrush?.Dispose();
				rowTextBrush = value ?? Default.RowTextBrush;
			}
		}

		/// <summary>
		/// ヘッダー左上に描画するテキストのアラインメント
		/// </summary>
		public static StringFormat TopLeftTextFormat
		{
			get => topLeftTextFormat;
			set
			{
				topLeftTextFormat?.Dispose();
				topLeftTextFormat = value ?? Default.TopLeftTextFormat;
			}
		}

		/// <summary>
		/// 列ヘッダーに描画するテキストのアラインメント
		/// </summary>
		public static StringFormat ColumnTextFormat {
			get => columnTextFormat;
			set
			{
				columnTextFormat?.Dispose();
				columnTextFormat = value ?? Default.ColumnTextFormat;
			}
		}

		/// <summary>
		/// 行ヘッダーに描画するテキストのアラインメント
		/// </summary>
		public static StringFormat RowTextFormat {
			get => rowTextFormat;
			set
			{
				rowTextFormat?.Dispose();
				rowTextFormat = value ?? Default.RowTextFormat;
			}
		}

		/// <summary>
		/// 列ヘッダーにテキストを描画するセルの間隔
		/// </summary>
		public static int ColumnTextTick { get => columnTextTick; set => columnTextTick = value < 1 ? Default.ColumnTextTick : value; }

		/// <summary>
		/// 行ヘッダーにテキストを描画するセルの間隔
		/// </summary>
		public static int RowTextTick { get => rowTextTick; set => rowTextTick = value < 1 ? Default.RowTextTick : value; }

		/// <summary>
		/// ヘッダー左上に描画するテキスト
		/// </summary>
		public static string TopLeftText { get => topLeftText; set => topLeftText = value is null ? string.Empty : value; }
	}
}
