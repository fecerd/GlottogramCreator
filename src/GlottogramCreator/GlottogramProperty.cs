using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WinFormsApp1
{
	/// <summary>
	/// グロットグラムの基本設定
	/// </summary>
	public static class GlottogramProperty
	{
		private static class Default
		{
			public static int Width => 2894 - 20;
			public static int Height => 4093 - 20;
			public static Padding Padding => new(10);
			public static Pen LinePen => InitializeHelper.CreatePen(Color.Black, 2.0f);
			public static Pen ColumnGridPen => InitializeHelper.CreatePen(Color.Gray, 1.0f);
			public static Pen RowGridPen => InitializeHelper.CreatePen(Color.Gray, 1.0f);
			public static Color BackColor => Color.White;
			public static float SymbolScale => 1.5f;
			public static float ViewScale => 0.5f;
		}

		public static void Load(string uri)
		{
			XDocument xDocument = XDocumentExtend.LoadEx(uri);
			IEnumerable<XElement> properties = xDocument?.GetRootElementByNameEx("class", "name", nameof(GlottogramProperty))?.Elements();
			if (properties is null) return;
			foreach (XElement el in properties)
			{
				if (el.GetAttributeValueEx("name") is not string propertyName) continue;
				if (propertyName == nameof(Width)) Width = el.Value.GetIntEx(Width);
				else if (propertyName == nameof(Height)) Height = el.Value.GetIntEx(Height);
				else if (propertyName == nameof(Padding)) Padding = el.GetPaddingEx(Padding);
				else if (propertyName == nameof(LineEnabled)) LineEnabled = el.Value.GetBoolEx(LineEnabled);
				else if (propertyName == nameof(ColumnGridEnabled)) ColumnGridEnabled = el.Value.GetBoolEx(ColumnGridEnabled);
				else if (propertyName == nameof(RowGridEnabled)) RowGridEnabled = el.Value.GetBoolEx(RowGridEnabled);
				else if (propertyName == nameof(LinePen)) LinePen = el.GetPenEx(LinePen);
				else if (propertyName == nameof(ColumnGridPen)) ColumnGridPen = el.GetPenEx(ColumnGridPen);
				else if (propertyName == nameof(RowGridPen)) RowGridPen = el.GetPenEx(RowGridPen);
				else if (propertyName == nameof(BackColor)) BackColor = el.GetColorEx(BackColor);
				else if (propertyName == nameof(BackgroundImageEnabled)) BackgroundImageEnabled = el.Value.GetBoolEx(BackgroundImageEnabled);
				else if (propertyName == nameof(BackgroundImageMode)) BackgroundImageMode = el.GetEnumEx<BackgroundImageMode>(BackgroundImageMode.Normal);
				else if (propertyName == nameof(BackgroundImage)) BackgroundImage = el.GetBitmapEx(BackgroundImage);
				else if (propertyName == nameof(SymbolScale)) SymbolScale = el.Value.GetFloatEx(SymbolScale);
				else if (propertyName == nameof(ViewScale)) ViewScale = el.Value.GetFloatEx(ViewScale);
				else if (propertyName == nameof(MultipleSymbolEnabled)) MultipleSymbolEnabled = el.Value.GetBoolEx(MultipleSymbolEnabled);
				else if (propertyName == nameof(MultipleSymbol)) MultipleSymbol = el.GetSymbolEx(MultipleSymbol);
				else if (propertyName == nameof(MultipleSymbolRelatedY)) MultipleSymbolRelatedY = el.Value.GetFloatEx(MultipleSymbolRelatedY);
				else if (propertyName == nameof(TextBoxes) && el.GetListEx() is List<GraphicsTextBox> list)
				{
					foreach (var t in TextBoxes) t.Dispose();
					TextBoxes.Clear();
					TextBoxes = list;
				}
			}
		}

		public static XElement Output()
		{
			XElement property = new("class", new XAttribute("name", nameof(GlottogramProperty)));
			property.Add(Width.ToPropertyEx(nameof(Width)));
			property.Add(Height.ToPropertyEx(nameof(Height)));
			property.Add(Padding.ToPropertyEx(nameof(Padding)));
			property.Add(LineEnabled.ToPropertyEx(nameof(LineEnabled)));
			property.Add(ColumnGridEnabled.ToPropertyEx(nameof(ColumnGridEnabled)));
			property.Add(RowGridEnabled.ToPropertyEx(nameof(RowGridEnabled)));
			property.Add(LinePen.ToPropertyEx(nameof(LinePen)));
			property.Add(ColumnGridPen.ToPropertyEx(nameof(ColumnGridPen)));
			property.Add(RowGridPen.ToPropertyEx(nameof(RowGridPen)));
			property.Add(BackColor.ToPropertyEx(nameof(BackColor)));
			property.Add(BackgroundImageEnabled.ToPropertyEx(nameof(BackgroundImageEnabled)));
			property.Add(BackgroundImageMode.ToPropertyEx(nameof(BackgroundImageMode)));
			if (BackgroundImage is not null) property.Add(BackgroundImage.ToPropertyEX(nameof(BackgroundImage)));
			property.Add(SymbolScale.ToPropertyEx(nameof(SymbolScale)));
			property.Add(ViewScale.ToPropertyEx(nameof(ViewScale)));
			property.Add(MultipleSymbolEnabled.ToPropertyEx(nameof(MultipleSymbolEnabled)));
			property.Add(MultipleSymbol?.ToPropertyEx(nameof(MultipleSymbol)));
			property.Add(MultipleSymbolRelatedY.ToPropertyEx(nameof(MultipleSymbolRelatedY)));
			property.Add(TextBoxes.ToPropertyEx(nameof(TextBoxes)));
			return property;
		}

		public static void Reset()
		{
			Width = Default.Width;
			Height = Default.Height;
			Padding = Default.Padding;
			LineEnabled = true;
			ColumnGridEnabled = true;
			RowGridEnabled = true;
			LinePen = Default.LinePen;
			ColumnGridPen = Default.ColumnGridPen;
			RowGridPen = Default.RowGridPen;
			BackColor = Default.BackColor;
			BackgroundImageEnabled = true;
			BackgroundImageMode = BackgroundImageMode.Normal;
			BackgroundImage = null;
			SymbolScale = Default.SymbolScale;
			ViewScale = Default.ViewScale;
			MultipleSymbolEnabled = true;
			MultipleSymbol = null;
			MultipleSymbolRelatedY = 0.0f;
			foreach (var t in TextBoxes) t.Dispose();
			TextBoxes.Clear();
		}

		static int width = Default.Width;
		static int height = Default.Height;
		static Padding padding = Default.Padding;
		static Pen linePen = Default.LinePen;
		static Pen columnGridPen = Default.ColumnGridPen;
		static Pen rowGridPen = Default.RowGridPen;		
		static Color backColor = Default.BackColor;
		static float symbolScale = Default.SymbolScale;
		static float viewScale = Default.ViewScale;
		static Bitmap backgroundImage = null;

		public static int Top => padding.Top;
		public static int Left => padding.Left;
		public static int Right => padding.Right;
		public static int Bottom => padding.Bottom;
		public static int Horizontal => padding.Horizontal;
		public static int Vertical => padding.Vertical;

		/// <summary>
		/// グロットグラム本体の幅
		/// </summary>
		public static int Width { get => width; set => width = value <= 0 ? Default.Width : value; }

		/// <summary>
		/// グロットグラム本体の高さ
		/// </summary>
		public static int Height { get => height; set => height = value <= 0 ? Default.Height : value; }

		/// <summary>
		/// Bitmapの端とグロットグラム(ヘッダー含む)の間のパディング
		/// </summary>
		public static Padding Padding
		{
			get => padding;
			set
			{
				if (value.Left < 0) value.Left = 0;
				if (value.Right < 0) value.Right = 0;
				if (value.Top < 0) value.Top = 0;
				if (value.Bottom < 0) value.Bottom = 0;
				padding = value;
			}
		}

		/// <summary>
		/// 列幅(width, columnMin, columnMax, columnTickより算出)
		/// </summary>
		public static float ColumnWidth => (float)width / (float)(GlottogramData.ColumnMax - GlottogramData.ColumnMin + 1) * GlottogramData.ColumnTick;

		/// <summary>
		/// 行の高さ(height, rowMin, rowMax, rowTickより算出)
		/// </summary>
		public static float RowHeight => (float)height / (float)(GlottogramData.RowMax - GlottogramData.RowMin + 1) * GlottogramData.RowTick;

		/// <summary>
		/// 外枠の線を描画するか否か
		/// </summary>
		public static bool LineEnabled { get; set; } = true;

		/// <summary>
		/// 列の境界線を描画するか否か
		/// </summary>
		public static bool ColumnGridEnabled { get; set; } = true;

		/// <summary>
		/// 行の境界線を描画するか否か
		/// </summary>
		public static bool RowGridEnabled { get; set; } = true;

		/// <summary>
		/// 外枠の線
		/// </summary>
		public static Pen LinePen {
			get => linePen;
			set
			{
				linePen?.Dispose();
				linePen = value ?? Default.LinePen;
			}
		}
		
		/// <summary>
		/// 列間の境界線
		/// </summary>
		public static Pen ColumnGridPen {
			get => columnGridPen;
			set
			{
				columnGridPen?.Dispose();
				columnGridPen = value ?? Default.ColumnGridPen;
			}
		}

		/// <summary>
		/// 行間の境界線
		/// </summary>
		public static Pen RowGridPen {
			get => rowGridPen;
			set
			{
				rowGridPen?.Dispose();
				rowGridPen = value ?? Default.RowGridPen;
			}
		}

		/// <summary>
		/// グロットグラム画像全体の背景色
		/// </summary>
		public static Color BackColor { get => backColor; set => backColor = value; }

		/// <summary>
		/// 背景に画像を表示するか否か
		/// </summary>
		public static bool BackgroundImageEnabled { get; set; } = true;

		/// <summary>
		/// 背景画像の拡大縮小モード
		/// </summary>
		public static BackgroundImageMode BackgroundImageMode { get; set; } = BackgroundImageMode.Normal;

		/// <summary>
		/// 背景画像
		/// </summary>
		public static Bitmap BackgroundImage
		{
			get => backgroundImage;
			set
			{
				if (backgroundImage != value) backgroundImage?.Dispose();
				backgroundImage = value;
			}
		}

		/// <summary>
		/// Glottogram.DrawValue()内で使用される記号のスケール
		/// </summary>
		public static float SymbolScale { get => symbolScale; set => symbolScale = value <= 0.0f ? Default.SymbolScale : value; }

		/// <summary>
		/// 複数回答を示す記号を表示するか否か
		/// </summary>
		public static bool MultipleSymbolEnabled { get; set; } = true;

		/// <summary>
		/// 複数回答を示す記号
		/// </summary>
		public static Symbol MultipleSymbol { get; set; } = null;

		/// <summary>
		/// 複数回答を示す記号を表示する位置。記号の画像の上に接するときを0として、上方向への距離を表す。単位は記号結合後のビットマップの高さ
		/// </summary>
		public static float MultipleSymbolRelatedY { get; set; } = 0.0f;

		/// <summary>
		/// PictureBoxに表示するグロットグラム画像のスケール
		/// </summary>
		public static float ViewScale { get => viewScale; set => viewScale = value <= 0.0f ? Default.ViewScale : value; }

		/// <summary>
		/// グロットグラム上に描画されるテキストボックス
		/// </summary>
		public static List<GraphicsTextBox> TextBoxes { get; set; } = new();
	}

	public enum BackgroundImageMode
	{
		Normal,
		Zoom,	//サイズ比維持
		Stretch	//サイズを合わせる
	}
}
