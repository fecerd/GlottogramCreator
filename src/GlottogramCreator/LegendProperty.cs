using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Xml.Linq;
using System.Windows.Forms;

namespace WinFormsApp1
{
	static class LegendProperty
	{
		static class Default
		{
			public static readonly Padding Padding = new(5);
			public const int RowHeight = 30;
			public static Pen LinePen => InitializeHelper.CreatePen(Color.Black, 4.0f);
			public static Pen ColumnGridPen => InitializeHelper.CreatePen(Color.Black, 1.5f);
			public static Pen RowGridPen => InitializeHelper.CreatePen(Color.Black, 1.5f);
			public static Pen RowGroupGridPen => InitializeHelper.CreatePen(Color.Black, 4.0f);
			public const float SymbolScale = 0.7f;
		}

		public static void Load(string uri)
		{
			XDocument xDocument = XDocumentExtend.LoadEx(uri);
			IEnumerable<XElement> elements = xDocument?.GetRootElementByNameEx("class", "name", nameof(LegendProperty))?.Elements();
			if (elements is null) return;
			foreach (var el in elements)
			{
				string propertyName = el.GetAttributeValueEx("name");
				if (propertyName is null) continue;
				if (propertyName == nameof(Enabled)) Enabled = el.Value.GetBoolEx(Enabled);
				else if (propertyName == nameof(BackgroundColorEnabled)) BackgroundColorEnabled = el.Value.GetBoolEx(BackgroundColorEnabled);
				else if (propertyName == nameof(LineIsEnabled)) LineIsEnabled = el.Value.GetBoolEx(LineIsEnabled);
				else if (propertyName == nameof(ColumnGridIsEnabled)) ColumnGridIsEnabled = el.Value.GetBoolEx(ColumnGridIsEnabled);
				else if (propertyName == nameof(RowGridIsEnabled)) RowGridIsEnabled = el.Value.GetBoolEx(RowGridIsEnabled);
				else if (propertyName == nameof(RowGroupGridIsEnabled)) RowGroupGridIsEnabled = el.Value.GetBoolEx(RowGroupGridIsEnabled);
				else if (propertyName == nameof(RowHeight)) RowHeight = el.Value.GetFloatEx(RowHeight);
				else if (propertyName == nameof(Padding)) Padding = el.GetPaddingEx(Padding);
				else if (propertyName == nameof(BackgroundColor)) BackgroundColor = el.GetColorEx(BackgroundColor);
				else if (propertyName == nameof(LinePen)) LinePen = el.GetPenEx(LinePen);
				else if (propertyName == nameof(ColumnGridPen)) ColumnGridPen = el.GetPenEx(ColumnGridPen);
				else if (propertyName == nameof(RowGridPen)) RowGridPen = el.GetPenEx(RowGridPen);
				else if (propertyName == nameof(RowGroupGridPen)) RowGroupGridPen = el.GetPenEx(RowGroupGridPen);
				else if (propertyName == nameof(SymbolScale)) SymbolScale = el.Value.GetFloatEx(SymbolScale);
				else if (propertyName == nameof(ConvertID)) ConvertID = el.Value.GetUIntEx(0);
				else if (propertyName == nameof(FormatID)) FormatID = el.Value.GetUIntEx(0);
				else if (propertyName == nameof(SymbolProperty)) SymbolProperty = el.GetColumnPropertyEx(SymbolProperty);
				else if (propertyName == nameof(ValueProperty)) ValueProperty = el.GetColumnPropertyEx(ValueProperty);
				else if (propertyName == nameof(CountProperty)) CountProperty = el.GetColumnPropertyEx(CountProperty);
			}
		}

		public static XElement Output()
		{
			XElement legendProperty = new("class", new XAttribute("name", nameof(LegendProperty)));
			legendProperty.Add(Enabled.ToPropertyEx(nameof(Enabled)));
			legendProperty.Add(BackgroundColorEnabled.ToPropertyEx(nameof(BackgroundColorEnabled)));
			legendProperty.Add(LineIsEnabled.ToPropertyEx(nameof(LineIsEnabled)));
			legendProperty.Add(ColumnGridIsEnabled.ToPropertyEx(nameof(ColumnGridIsEnabled)));
			legendProperty.Add(RowGridIsEnabled.ToPropertyEx(nameof(RowGridIsEnabled)));
			legendProperty.Add(RowGroupGridIsEnabled.ToPropertyEx(nameof(RowGroupGridIsEnabled)));
			legendProperty.Add(RowHeight.ToPropertyEx(nameof(RowHeight)));
			legendProperty.Add(Padding.ToPropertyEx(nameof(Padding)));
			legendProperty.Add(BackgroundColor.ToPropertyEx(nameof(BackgroundColor)));
			legendProperty.Add(LinePen.ToPropertyEx(nameof(LinePen)));
			legendProperty.Add(ColumnGridPen.ToPropertyEx(nameof(ColumnGridPen)));
			legendProperty.Add(RowGridPen.ToPropertyEx(nameof(RowGridPen)));
			legendProperty.Add(RowGroupGridPen.ToPropertyEx(nameof(RowGroupGridPen)));
			legendProperty.Add(SymbolScale.ToPropertyEx(nameof(SymbolScale)));
			legendProperty.Add(ConvertID.ToPropertyEx(nameof(ConvertID)));
			legendProperty.Add(FormatID.ToPropertyEx(nameof(FormatID)));
			legendProperty.Add(SymbolProperty.ToPropertyEx(nameof(SymbolProperty)));
			legendProperty.Add(ValueProperty.ToPropertyEx(nameof(ValueProperty)));
			legendProperty.Add(CountProperty.ToPropertyEx(nameof(CountProperty)));
			return legendProperty;
		}

		public static void Reset()
		{
			Enabled = true;
			BackgroundColorEnabled = false;
			LineIsEnabled = true;
			ColumnGridIsEnabled = true;
			RowGridIsEnabled = true;
			RowGroupGridIsEnabled = true;
			RowHeight = Default.RowHeight;
			Padding = Default.Padding;
			BackgroundColor = Color.White;
			LinePen = Default.LinePen;
			ColumnGridPen = Default.ColumnGridPen;
			RowGridPen = Default.RowGridPen;
			RowGroupGridPen = Default.RowGroupGridPen;
			SymbolScale = Default.SymbolScale;
			IPAConverter.Reset();
			IPAFormatter.Reset();
			SymbolProperty.Reset();
			ValueProperty.Reset();
			CountProperty.Reset();
		}

		static Padding padding = Default.Padding;
		static float rowHeight = Default.RowHeight;
		static Pen columnGridPen = Default.ColumnGridPen;
		static Pen rowGridPen = Default.RowGridPen;
		static Pen rowGroupGridPen = Default.RowGroupGridPen;
		static Pen linePen = Default.LinePen;
		static ColumnProperty symbolProperty = new("記号", 70);
		static ColumnProperty valueProperty = new("値", 120);
		static ColumnProperty countProperty = new("個数", 90);

		public static int Top => padding.Top;
		public static int Left => padding.Left;
		public static int Right => padding.Right;
		public static int Bottom => padding.Bottom;
		public static int Horizontal => padding.Horizontal;
		public static int Vertical => padding.Vertical;
		public static int Width => SymbolProperty.Width + ValueProperty.Width + CountProperty.Width;

		/// <summary>
		/// 凡例を描画するか否か
		/// </summary>
		public static bool Enabled { get; set; } = true;

		/// <summary>
		/// 凡例の背景色を塗りつぶすか否か
		/// </summary>
		public static bool BackgroundColorEnabled { get; set; } = false;

		/// <summary>
		/// 外枠の線を描画するか否か
		/// </summary>
		public static bool LineIsEnabled { get; set; } = true;

		/// <summary>
		/// 列の境界線を描画するか否か
		/// </summary>
		public static bool ColumnGridIsEnabled { get; set; } = true;

		/// <summary>
		/// 行の境界線を描画するか否か
		/// </summary>
		public static bool RowGridIsEnabled { get; set; } = true;

		/// <summary>
		/// グループの境界線を描画するか否か
		/// </summary>
		public static bool RowGroupGridIsEnabled { get; set; } = true;

		/// <summary>
		/// 行の高さ
		/// </summary>
		public static float RowHeight { get => rowHeight; set => rowHeight = value < 1 ? 1 : value; }

		/// <summary>
		/// TopとLeftが凡例の位置を決定する。凡例がグロットグラム内部よりも右側に領域を持つとき、Rightが右端の余白を表す。
		/// Bottomは使用しない。
		/// </summary>
		public static Padding Padding
		{
			get => padding;
			set
			{
				padding.Left = value.Left;
				padding.Top = value.Top < 0 ? 0 : value.Top;
				padding.Right = value.Right < 0 ? 0 : value.Right;
				padding.Bottom = value.Bottom < 0 ? 0 : value.Bottom;
			}
		}

		/// <summary>
		/// 凡例の背景色
		/// </summary>
		public static Color BackgroundColor { get; set; } = Color.White;

		/// <summary>
		/// 外枠の線
		/// </summary>
		public static Pen LinePen
		{
			get => linePen;
			set
			{
				linePen?.Dispose();
				linePen = value ?? Default.LinePen;
			}
		}

		/// <summary>
		/// 列の境界線
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
		/// 行の境界線
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
		/// グループの境界線
		/// </summary>
		public static Pen RowGroupGridPen
		{
			get => rowGroupGridPen;
			set
			{
				rowGroupGridPen?.Dispose();
				rowGroupGridPen = value ?? Default.RowGroupGridPen;
			}
		}

		/// <summary>
		/// 記号列に描画される画像のスケール
		/// </summary>
		public static float SymbolScale { get; set; } = Default.SymbolScale;

		/// <summary>
		/// IPAConverter.ConvertIDへのアクセサ
		/// </summary>
		public static uint ConvertID { get => IPAConverter.ConvertID; set => IPAConverter.ConvertID = value; }

		/// <summary>
		/// IPAFormatter.FormatIDへのアクセサ
		/// </summary>
		public static uint FormatID { get => IPAFormatter.FormatID; set => IPAFormatter.FormatID = value; }

		/// <summary>
		/// 記号列の設定
		/// </summary>
		public static ColumnProperty SymbolProperty { get => symbolProperty; private set => symbolProperty = value ?? symbolProperty; }

		/// <summary>
		/// 値列の設定
		/// </summary>
		public static ColumnProperty ValueProperty { get => valueProperty; private set => valueProperty = value ?? valueProperty; }

		/// <summary>
		/// 個数列の設定
		/// </summary>
		public static ColumnProperty CountProperty { get => countProperty; private set => countProperty = value ?? countProperty; }
	}

	class ColumnProperty
	{
		static class Default
		{
			public const int Width = 120;
			public static SolidBrush NameBrush => new(Color.Black);
			public static SolidBrush TextBrush => new(Color.Black);
			public static Font NameFont => new(SystemFonts.DefaultFont.FontFamily, 24.0f, GraphicsUnit.Pixel);
			public static Font TextFont => new(SystemFonts.DefaultFont.FontFamily, 24.0f, GraphicsUnit.Pixel);
			public static StringFormat NameFormat => InitializeHelper.CreateStringFormat(StringAlignment.Near, StringAlignment.Center);
			public static StringFormat TextFormat => InitializeHelper.CreateStringFormat(StringAlignment.Near, StringAlignment.Center);
		}

		public ColumnProperty() { }

		public ColumnProperty(string name, int width)
		{
			Name = name;
			Width = width;
		}

		public void Reset()
		{
			Enabled = true;
			Width = Default.Width;
			Name = string.Empty;
			NameBrush = Default.NameBrush;
			TextBrush = Default.TextBrush;
			NameFont = Default.NameFont;
			TextFont = Default.TextFont;
			NameFormat = Default.NameFormat;
			TextFormat = Default.TextFormat;
		}

		int width = Default.Width;
		SolidBrush nameBrush = Default.NameBrush;
		SolidBrush textBrush = Default.TextBrush;
		Font nameFont = Default.NameFont;
		Font textFont = Default.TextFont;
		StringFormat nameFormat = Default.NameFormat;
		StringFormat textFormat = Default.TextFormat;

		/// <summary>
		/// 列を描画するか否か
		/// </summary>
		public bool Enabled { get; set; } = true;

		/// <summary>
		/// 幅
		/// </summary>
		public int Width { get => width; set => width = value < 1 ? 1 : value; }

		/// <summary>
		/// ヘッダーに描画される文字列
		/// </summary>
		public string Name { get; set; } = string.Empty;

		/// <summary>
		/// ヘッダー描画用のブラシ
		/// </summary>
		public SolidBrush NameBrush {
			get => nameBrush;
			set
			{
				nameBrush?.Dispose();
				nameBrush = value ?? Default.NameBrush;
			}
		}

		/// <summary>
		/// 値描画用のブラシ
		/// </summary>
		public SolidBrush TextBrush
		{
			get => textBrush;
			set
			{
				textBrush?.Dispose();
				textBrush = value ?? Default.TextBrush;
			}
		}

		/// <summary>
		/// ヘッダー描画用のブラシを設定
		/// </summary>
		public Color NameColor { set => NameBrush = new(value); }

		/// <summary>
		/// 値描画用のブラシを設定
		/// </summary>
		public Color TextColor { set => TextBrush = new(value); }

		/// <summary>
		/// ヘッダー描画用のフォント
		/// </summary>
		public Font NameFont
		{
			get => nameFont;
			set
			{
				nameFont?.Dispose();
				nameFont = value ?? Default.NameFont;
			}
		}

		/// <summary>
		/// 値描画用のフォント
		/// </summary>
		public Font TextFont
		{
			get => textFont;
			set
			{
				textFont?.Dispose();
				textFont = value ?? Default.TextFont;
			}
		}

		/// <summary>
		/// ヘッダーに描画される文字列のフォーマット
		/// </summary>
		public StringFormat NameFormat {
			get => nameFormat;
			set
			{
				nameFormat?.Dispose();
				nameFormat = value ?? Default.NameFormat;
			}
		}

		/// <summary>
		/// 値の文字列のフォーマット
		/// </summary>
		public StringFormat TextFormat {
			get => textFormat;
			set
			{
				textFormat?.Dispose();
				textFormat = value ?? Default.TextFormat;
			}
		}
	}

	static partial class FromXElement
	{
		public static ColumnProperty GetColumnPropertyEx(this XElement element, ColumnProperty defaultValue)
		{
			if (defaultValue is null) defaultValue = new();
			ColumnProperty ret = new();
			foreach (var el in CommonGetEx(element))
			{
				string propertyName = el.GetAttributeValueEx("name") ?? string.Empty;
				if (propertyName == nameof(ret.Enabled)) ret.Enabled = el.Value.GetBoolEx(defaultValue.Enabled);
				else if (propertyName == nameof(ret.Name)) ret.Name = el.Value ?? defaultValue.Name;
				else if (propertyName == nameof(ret.NameBrush)) ret.NameBrush = el.GetSolidBrushEx(defaultValue.NameBrush);
				else if (propertyName == nameof(ret.NameFont)) ret.NameFont = el.GetFontEx(defaultValue.NameFont);
				else if (propertyName == nameof(ret.NameFormat)) ret.NameFormat = el.GetStringFormatEx(defaultValue.NameFormat);
				else if (propertyName == nameof(ret.TextBrush)) ret.TextBrush = el.GetSolidBrushEx(defaultValue.TextBrush);
				else if (propertyName == nameof(ret.TextFont)) ret.TextFont = el.GetFontEx(defaultValue.TextFont);
				else if (propertyName == nameof(ret.TextFormat)) ret.TextFormat = el.GetStringFormatEx(defaultValue.TextFormat);
				else if (propertyName == nameof(ret.Width)) ret.Width = el.Value.GetIntEx(defaultValue.Width);
			}
			return ret;
		}
	}

	static partial class ToXElement
	{
		public static XElement ToXElementEx(this ColumnProperty value, string elementName, string varName)
		{
			XElement ret = CommonToXElement(elementName, varName, nameof(ColumnProperty));
			ret.Add(
				value.Enabled.ToPropertyEx(nameof(value.Enabled)),
				value.Name.ToPropertyEx(nameof(value.Name)),
				value.NameBrush.ToPropertyEx(nameof(value.NameBrush)),
				value.NameFont.ToPropertyEx(nameof(value.NameFont)),
				value.NameFormat.ToPropertyEx(nameof(value.NameFormat)),
				value.TextBrush.ToPropertyEx(nameof(value.TextBrush)),
				value.TextFont.ToPropertyEx(nameof(value.TextFont)),
				value.TextFormat.ToPropertyEx(nameof(value.TextFormat)),
				value.Width.ToPropertyEx(nameof(value.Width))
				);
			return ret;
		}
	}

	static partial class ToProperty
	{
		public static XElement ToPropertyEx(this ColumnProperty value, string varName) => value.ToXElementEx("property", varName);
	}
}
