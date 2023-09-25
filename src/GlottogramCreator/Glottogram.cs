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
	public partial class Glottogram : Glottogram_Internal
	{
		private Glottogram()
		{
			InitializeComponent();
			Icon = InitializeHelper.CreateIconFromResource(GetType(), "Icon.ico", Icon);
			viewScaleComboBox.SelectedIndex = 1;    //表示スケール20%
			//イベント設定
			glottogramPanel.MouseWheel += MouseWheel_Event;
			glottogramPictureBox.Click += (object sender, EventArgs e) => glottogramPanel.Focus();
			glottogramPictureBox.MouseDown += MouseDown_Event;
			glottogramPictureBox.MouseUp += MouseUp_Event;
			glottogramPictureBox.MouseLeave += MouseLeave_Event;
			void DeactivateControl(object sender, EventArgs e) => ActiveControl = null;
			selectedColumnGroupBox.Click += DeactivateControl;
			selectedRowGroupBox.Click += DeactivateControl;
			SizeChanged += (object sender, EventArgs e) => { viewScaleComboBox.SelectionLength = 0; };
			Click += DeactivateControl;
			Shown += (object sender, EventArgs e) => { ActiveControl = viewScaleComboBox; SelectNextControl(viewScaleComboBox, true, true, true, true); System.Windows.Forms.Application.DoEvents(); Draw(); };
			//フォント変更
			Config.SetMainFont(this);
		}

		Bitmap m_ggImageWithoutTextBox = null;
		private Bitmap GlottogramImageWithoutTextBox
		{
			get => m_ggImageWithoutTextBox;
			set
			{
				m_ggImageWithoutTextBox?.Dispose();
				m_ggImageWithoutTextBox = value;
			}
		}

		Graphics m_graphics = null;
		private Graphics Graphics
		{
			get => m_graphics;
			set
			{
				m_graphics?.Dispose();
				m_graphics = value;
				m_graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
				m_graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
			}
		}

		/// <summary>
		/// 描画したBitmap
		/// </summary>
		private Bitmap GlottogramImage { get; set; } = null;

		/// <summary>
		/// グロットグラム全体を描画する
		/// </summary>
		public void Draw(bool useCache = false)
		{
			Enabled = false;
			void Draw_Internal()
			{
				Init();
				if (EscThread.Pressed) return;
				DrawBackGroundImage();
				if (EscThread.Pressed) return;
				DrawHeader();
				if (EscThread.Pressed) return;
				DrawGrid();
				if (EscThread.Pressed) return;
				DrawRowHeaderText();
				if (EscThread.Pressed) return;
				DrawColumnHeaderText();
				if (EscThread.Pressed) return;
				DrawHeaderTopLeftText();
				if (EscThread.Pressed) return;
				DrawValue(useCache);
				if (EscThread.Pressed) return;
				DrawLegend();
				if (EscThread.Pressed) return;
				DrawTextBox();
			};
			void Draw_Finally()
			{
				Invoke(UpdateImage);
				Invoke(SetControls, useCache);
				Invoke(() => Enabled = true);
			};
			EscThread.Start(this, Draw_Internal, Draw_Finally);
		}

		/// <summary>
		/// PictureBox.Imageの設定
		/// </summary>
		private void Init()
		{
			GlottogramImage?.Dispose();
			GlottogramImage = null;
			GlottogramImageWithoutTextBox = new Bitmap(GlottogramHelper.ImageWidth, GlottogramHelper.ImageHeight);
			Graphics = Graphics.FromImage(GlottogramImageWithoutTextBox);
			Graphics.Clear(GlottogramProperty.BackColor);
		}

		/// <summary>
		/// 背景画像の描画
		/// </summary>
		private void DrawBackGroundImage()
		{
			if (!GlottogramProperty.BackgroundImageEnabled || GlottogramProperty.BackgroundImage is not Bitmap background || Graphics is null) return;
			Rectangle rectangle = GlottogramHelper.GlottogramBounds;
			BackgroundImageMode mode = GlottogramProperty.BackgroundImageMode;
			if (mode == BackgroundImageMode.Normal)
			{
				Graphics.SetClip(rectangle);
				Graphics.DrawImage(background, rectangle.Location);
			}
			else if (mode == BackgroundImageMode.Zoom)
			{
				float scale = MathF.Min((float)rectangle.Width / background.Width, (float)rectangle.Height / background.Height);
				if (scale == 0) scale = 1.0f;
				Graphics.DrawImage(background, rectangle.X, rectangle.Y, (int)(background.Width * scale), (int)(background.Height * scale));
			}
			else if (mode == BackgroundImageMode.Stretch) Graphics.DrawImage(background, rectangle);
		}

		/// <summary>
		/// ヘッダーの外枠と境界線を描画する
		/// </summary>
		private void DrawHeader()
		{
			if (Graphics is null) return;
			if (!(HeaderProperty.ColumnIsEnabled || HeaderProperty.RowIsEnabled)) return;
			Rectangle headerTopLeft = GlottogramHelper.HeaderTopLeftBounds;
			Rectangle glottogram = GlottogramHelper.GlottogramBounds;
			float xStart = headerTopLeft.X;
			float xStop = headerTopLeft.Right;
			float xEnd = glottogram.Right;
			float yStart = headerTopLeft.Y;
			float yStop = headerTopLeft.Bottom;
			float yEnd = glottogram.Bottom;
			if (HeaderProperty.ColumnGridIsEnabled)
			{
				Pen columnGridPen = HeaderProperty.ColumnGridPen;
				float width = GlottogramProperty.ColumnWidth;
				for (int i = 1, count = GlottogramData.ColumnCount; i < count; ++i)
				{
					if (EscThread.Pressed) return;
					float x = xStop + (width * i);
					Graphics.DrawLine(columnGridPen, x, yStart, x, yStop);
				}
			}
			if (HeaderProperty.ColumnLineIsEnabled)
			{
				Graphics.DrawLines(HeaderProperty.ColumnLinePen, new PointF[] { new(xStop, yStop), new(xStop, yStart), new(xEnd, yStart), new(xEnd, yStop) });
			}
			if (HeaderProperty.RowGridIsEnabled)
			{
				Pen rowGridPen = HeaderProperty.RowGridPen;
				float height = GlottogramProperty.RowHeight;
				for (int i = 1, count = GlottogramData.RowCount; i < count; ++i)
				{
					if (EscThread.Pressed) return;
					float y = yStop + (height * i);
					Graphics.DrawLine(rowGridPen, xStart, y, xStop, y);
				}
			}
			if (HeaderProperty.RowLineIsEnabled)
			{
				Graphics.DrawLines(HeaderProperty.RowLinePen, new PointF[] { new(xStop, yStop), new(xStart, yStop), new(xStart, yEnd), new(xStop, yEnd) });
			}
			if (HeaderProperty.ColumnLineIsEnabled && HeaderProperty.RowLineIsEnabled)
			{
				Graphics.DrawLine(HeaderProperty.ColumnLinePen, new PointF(xStop, yStart), new PointF(xStart, yStart));
				Graphics.DrawLine(HeaderProperty.RowLinePen, new PointF(xStart, yStart), new PointF(xStart, yStop));
			}
		}

		/// <summary>
		/// グロットグラム本体の外枠と境界線を描画する
		/// </summary>
		private void DrawGrid()
		{
			if (Graphics is null) return;
			Rectangle glottogram = GlottogramHelper.GlottogramBounds;
			PointF Origin = glottogram.Location;
			PointF End = new(glottogram.Right, glottogram.Bottom);
			if (GlottogramProperty.ColumnGridEnabled)
			{
				Pen columnGridPen = GlottogramProperty.ColumnGridPen;
				float width = GlottogramProperty.ColumnWidth;
				for (int i = 1, count = GlottogramData.ColumnCount; i < count; ++i)
				{
					if (EscThread.Pressed) return;
					float x = Origin.X + (i * width);
					Graphics.DrawLine(columnGridPen, x, Origin.Y, x, End.Y);
				}
			}
			if (GlottogramProperty.RowGridEnabled)
			{
				Pen rowGridPen = GlottogramProperty.RowGridPen;
				float height = GlottogramProperty.RowHeight;
				for (int i = 1, count = GlottogramData.RowCount; i < count; ++i)
				{
					if (EscThread.Pressed) return;
					float y = Origin.Y + (i * height);
					Graphics.DrawLine(rowGridPen, Origin.X, y, End.X, y);
				}
			}
			if (GlottogramProperty.LineEnabled) Graphics.DrawLines(GlottogramProperty.LinePen, new PointF[] { Origin, new(Origin.X, End.Y), End, new(End.X, Origin.Y), Origin });
		}

		/// <summary>
		/// 行ヘッダーに文字列を描画する
		/// </summary>
		private void DrawRowHeaderText()
		{
			if (Graphics is null) return;
			if (!HeaderProperty.RowIsEnabled || !HeaderProperty.RowTextIsEnabled) return;
			RectangleF rect = (RectangleF)GlottogramHelper.RowHeaderBounds with { Height = GlottogramProperty.RowHeight };
			StringFormat stringFormat = HeaderProperty.RowTextFormat;
			if (stringFormat.Alignment == StringAlignment.Center) rect.X += HeaderProperty.RowWidth / 2;
			else if (stringFormat.Alignment == StringAlignment.Far) rect.X += HeaderProperty.RowWidth;
			if (stringFormat.LineAlignment == StringAlignment.Center) rect.Y += GlottogramProperty.RowHeight / 2;
			else if (stringFormat.LineAlignment == StringAlignment.Far) rect.Y += GlottogramProperty.RowHeight;
			Brush rowTextBrush = HeaderProperty.RowTextBrush;
			Font font = HeaderProperty.RowTextFont;
			int tick = GlottogramData.RowTick;
			int textTick = HeaderProperty.RowTextTick;
			int cellIndex = 0;
			if (GlottogramData.RowSortKey == GlottogramData.RowKey)
			{
				if (GlottogramData.RowAscendingOrder)
				{
					for (int i = GlottogramData.RowMin, end = GlottogramData.RowMax; i <= end; i += tick * textTick, cellIndex += textTick)
					{
						if (EscThread.Pressed) return;
						PointF location = rect.Location with { Y = rect.Y + cellIndex * rect.Height };
						Graphics.DrawString(i.ToString(), font, rowTextBrush, location, stringFormat);
					}
				}
				else
				{
					for (int i = GlottogramData.RowMax, end = GlottogramData.RowMin; i >= end; i -= tick * textTick, cellIndex += textTick)
					{
						if (EscThread.Pressed) return;
						PointF location = rect.Location with { Y = rect.Y + cellIndex * rect.Height };
						Graphics.DrawString(i.ToString(), font, rowTextBrush, location, stringFormat);
					}
				}
			}
			else
			{
				Dictionary<string, string> converter = MainData.GetConverter(GlottogramData.RowSortKey, GlottogramData.RowKey);
				if (GlottogramData.RowAscendingOrder)
				{
					for (int i = GlottogramData.RowMin, end = GlottogramData.RowMax; i <= end; i += tick * textTick, cellIndex += textTick)
					{
						if (EscThread.Pressed) return;
						if (converter.TryGetValue(i.ToString(), out string value))
						{
							PointF location = rect.Location with { Y = rect.Y + cellIndex * rect.Height };
							Graphics.DrawString(value, font, rowTextBrush, location, stringFormat);
						}
					}
				}
				else
				{
					for (int i = GlottogramData.RowMax, end = GlottogramData.RowMin; i >= end; i -= tick * textTick, cellIndex += textTick)
					{
						if (EscThread.Pressed) return;
						if (converter.TryGetValue(i.ToString(), out string value))
						{
							PointF location = rect.Location with { Y = rect.Y + cellIndex * rect.Height };
							Graphics.DrawString(value, font, rowTextBrush, location, stringFormat);
						}
					}
				}
			}
		}

		/// <summary>
		/// 列ヘッダーに文字列を描画する
		/// </summary>
		private void DrawColumnHeaderText()
		{
			if (Graphics is null) return;
			if (!HeaderProperty.ColumnIsEnabled || !HeaderProperty.ColumnTextIsEnabled) return;
			StringFormat stringFormat = HeaderProperty.ColumnTextFormat;
			RectangleF rect = (RectangleF)GlottogramHelper.ColumnHeaderBounds with { Width = GlottogramProperty.ColumnWidth };
			if (stringFormat.Alignment == StringAlignment.Center) rect.X += GlottogramProperty.ColumnWidth / 2;
			else if (stringFormat.Alignment == StringAlignment.Far) rect.X += GlottogramProperty.ColumnWidth;
			if (stringFormat.LineAlignment == StringAlignment.Center) rect.Y += HeaderProperty.ColumnHeight / 2;
			else if (stringFormat.LineAlignment == StringAlignment.Far) rect.Y += HeaderProperty.ColumnHeight;
			Brush columnTextbrush = HeaderProperty.ColumnTextBrush;
			Font font = HeaderProperty.ColumnTextFont;
			int tick = GlottogramData.ColumnTick;
			int cellIndex = 0;
			int textTick = HeaderProperty.ColumnTextTick;
			if (GlottogramData.ColumnSortKey == GlottogramData.ColumnKey)
			{
				if (GlottogramData.ColumnAscendingOrder)
				{
					for (int i = GlottogramData.ColumnMin, end = GlottogramData.ColumnMax; i <= end; i += tick * textTick, cellIndex += textTick)
					{
						if (EscThread.Pressed) return;
						PointF location = rect.Location with { X = rect.X + cellIndex * rect.Width };
						Graphics.DrawString(i.ToString(), font, columnTextbrush, location, stringFormat);
					}
				}
				else
				{
					for (int i = GlottogramData.ColumnMax, end = GlottogramData.ColumnMin; i >= end; i -= tick * textTick, cellIndex += textTick)
					{
						if (EscThread.Pressed) return;
						PointF location = rect.Location with { X = rect.X + cellIndex * rect.Width };
						Graphics.DrawString(i.ToString(), font, columnTextbrush, location, stringFormat);
					}
				}
			}
			else
			{
				Dictionary<string, string> converter = MainData.GetConverter(GlottogramData.ColumnSortKey, GlottogramData.ColumnKey);
				if (GlottogramData.ColumnAscendingOrder)
				{
					for (int i = GlottogramData.ColumnMin, end = GlottogramData.ColumnMax; i <= end; i += tick * textTick, cellIndex += textTick)
					{
						if (EscThread.Pressed) return;
						if (converter.TryGetValue(i.ToString(), out string value))
						{
							PointF location = rect.Location with { X = rect.X + cellIndex * rect.Width };
							Graphics.DrawString(value, font, columnTextbrush, location, stringFormat);
						}
					}
				}
				else
				{
					for (int i = GlottogramData.ColumnMax, end = GlottogramData.ColumnMin; i >= end; i -= tick * textTick, cellIndex += textTick)
					{
						if (EscThread.Pressed) return;
						if (converter.TryGetValue(i.ToString(), out string value))
						{
							PointF location = rect.Location with { X = rect.X + cellIndex * rect.Width };
							Graphics.DrawString(value, font, columnTextbrush, location, stringFormat);
						}
					}
				}
			}
		}

		/// <summary>
		/// ヘッダーの左上に文字列を描画する
		/// </summary>
		private void DrawHeaderTopLeftText()
		{
			if (Graphics is null) return;
			if (!HeaderProperty.ColumnIsEnabled || !HeaderProperty.RowIsEnabled || !HeaderProperty.TopLeftTextIsEnabled || string.IsNullOrEmpty(HeaderProperty.TopLeftText)) return;
			StringFormat stringFormat = HeaderProperty.TopLeftTextFormat;
			RectangleF rect = GlottogramHelper.HeaderTopLeftBounds;
			if (stringFormat.Alignment == StringAlignment.Center) rect.X += rect.Width / 2;
			else if (stringFormat.Alignment == StringAlignment.Far) rect.X += rect.Width;
			if (stringFormat.LineAlignment == StringAlignment.Center) rect.Y += rect.Height / 2;
			else if (stringFormat.LineAlignment == StringAlignment.Far) rect.Y += rect.Height;
			Brush topLeftTextbrush = HeaderProperty.TopLeftTextBrush;
			Font font = HeaderProperty.TopLeftTextFont;
			Graphics.DrawString(HeaderProperty.TopLeftText, font, topLeftTextbrush, rect.Location, stringFormat);
		}

		/// <summary>
		/// 記号を描画する
		/// </summary>
		/// <param name="useCache">キャッシュを使用する</param>
		private void DrawValue(bool useCache = false)
		{
			if (Graphics is null) return;
			if (!useCache) GlottogramCache.Update();
			Rectangle glottogram = GlottogramHelper.GlottogramBounds;
			float x0 = glottogram.X;
			float y0 = glottogram.Y;
			float columnWidth = GlottogramProperty.ColumnWidth;
			float rowHeight = GlottogramProperty.RowHeight;
			int columnOrigin = GlottogramData.ColumnAscendingOrder ? GlottogramData.ColumnMin : GlottogramData.ColumnMax;
			int rowOrigin = GlottogramData.RowAscendingOrder ? GlottogramData.RowMin : GlottogramData.RowMax;
			int columnTick = GlottogramData.ColumnTick;
			int rowTick = GlottogramData.RowTick;
			int columnCount = GlottogramData.ColumnCount;
			int rowCount = GlottogramData.RowCount;
			float multipleRelatedY = GlottogramProperty.MultipleSymbolRelatedY;
			Bitmap multipleSymbol = null;
			if (GlottogramProperty.MultipleSymbolEnabled) multipleSymbol = GlottogramProperty.MultipleSymbol?.Bitmap;
			foreach (var cache in GlottogramCache.Caches)
			{
				if (EscThread.Pressed) return;
				if (cache.Bitmap is not Bitmap bitmap || cache.RemovedByFiltering) continue;
				int columnIndex, rowIndex;
				try
				{
					columnIndex = Math.Abs(cache.XSortValue - columnOrigin) / columnTick;
					rowIndex = Math.Abs(cache.YSortValue - rowOrigin) / rowTick;
				}
				catch { continue; }
				if (columnIndex < 0 || columnIndex >= columnCount || rowIndex < 0 || rowIndex >= rowCount) continue;
				(float x, float y) related = MainData.GetRelatedTranslate(cache.DataIndex) is (int x, int y) tuple ? (tuple.x / 100.0f, tuple.y / 100.0f) : (0, 0);
				PointF point = new(x0 + columnWidth * (columnIndex + related.x) + (columnWidth - bitmap.Width) / 2, y0 + rowHeight * (rowIndex + related.y) + (rowHeight - bitmap.Height) / 2);
				Graphics.DrawImage(bitmap, point);
				if (cache.IsMultiple && multipleSymbol is not null)
				{
					using Bitmap multiple = new(bitmap.Width, multipleSymbol.Height);
					using Graphics g = Graphics.FromImage(multiple);
					g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
					g.DrawImage(multipleSymbol, 0, 0, multiple.Width, multiple.Height);
					Graphics.DrawImage(multiple, point.X, point.Y - multiple.Height - (int)(bitmap.Height * multipleRelatedY));
				}
			}
		}

		/// <summary>
		/// 凡例の境界線の種類
		/// </summary>
		enum LegendGrid
		{
			None = 0,
			Normal = 1,
			Group = 2,
			Line = 3,
		}

		/// <summary>
		/// [内部関数]凡例の行を描画する
		/// </summary>
		/// <param name="graphics">GlottogramImageから取得したGraphics</param>
		/// <param name="root">描画するSymbol。描画すべき子Symbolを持つ場合、それらに対してこの関数を再帰的に呼び出す</param>
		/// <param name="rowCount">描画する行が何行目か指定し、次に描画する行が何行目か返す</param>
		/// <param name="valueSum">Symbolオブジェクトと数値の組み合わせ</param>
		/// <param name="upper">上の行との境界線の種類。この行の境界線より優先度が低い場合、上書きされる</param>
		/// <param name="drawSymbol">記号列に画像を描画するか否か</param>
		/// <param name="drawSymbolGrid">グループ描画時に記号列の境界線を描画するか否か</param>
		/// <returns>この行の下の境界線の種類</returns>
		private LegendGrid DrawLegendRow(Graphics graphics, Symbol root, ref int rowCount, Dictionary<Symbol, int> valueSum, LegendGrid upper, bool drawSymbol = true, bool drawSymbolGrid = true)
		{
			LegendGrid ret = upper;
			if (root is null || !root.Visible) return ret;
			float rowHeight = LegendProperty.RowHeight;
			float y0 = LegendProperty.Top + rowHeight * rowCount;
			if (!root.Members.Any() || (root.Data is not null && !string.IsNullOrEmpty(root.Name)))
			{
				using Bitmap symbolBitmap = root.Data?.GetBitmap(LegendProperty.SymbolScale);
				if (drawSymbol && symbolBitmap is null) return ret;
				if (!valueSum.TryGetValue(root, out int count)) return ret;
				ret = LegendGrid.Normal;
				RectangleF valueBounds = GlottogramHelper.LegendValueColumnBounds;
				string value = (root.Members.Any() ? root.Name : root.Value) ?? string.Empty;
				switch (root.ConvertMode)
				{
					case ConvertMode.Hiragana:
						value = KanaConverter.ToHiragana(value);
						break;
					case ConvertMode.Katakana:
						value = KanaConverter.ToKatakana(value);
						break;
					case ConvertMode.HalfKatakana:
						value = KanaConverter.ToHankakuKatakana(value);
						break;
					case ConvertMode.IPA:
						value = IPAConverter.ToIPA(value);
						break;
					case ConvertMode.Custom:
						value = root.CustomName ?? string.Empty;
						break;
				}
				float height = rowHeight;
				++rowCount;
				//値列の値が収まる行数を計算し、height = 行数 * 行の高さにする
				if (!valueBounds.IsEmpty)
				{
					using Bitmap tmp = new(16, 16);
					using Graphics g = Graphics.FromImage(tmp);
					g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
					g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
					ColumnProperty property = LegendProperty.ValueProperty;
					float textHeight = g.MeasureString(value, property.TextFont, property.Width, property.TextFormat).Height;
					//textHeightが収まる高さを計算
					for (int i = 1; i < 200; ++i)   //200行が限度
					{
						height = rowHeight * i;
						if (height > textHeight) break;
						++rowCount;
					}
				}
				RectangleF symbolBounds = GlottogramHelper.LegendSymbolColumnBounds;
				RectangleF countBounds = GlottogramHelper.LegendCountColumnBounds;
				if (LegendProperty.BackgroundColorEnabled)
				{
					RectangleF row = (RectangleF)GlottogramHelper.LegendBounds with { Y = y0, Width = symbolBounds.Width + valueBounds.Width + countBounds.Width, Height = height };
					using SolidBrush brush = new(LegendProperty.BackgroundColor);
					graphics.FillRectangle(brush, row);
				}
				if (!symbolBounds.IsEmpty)
				{
					RectangleF row = symbolBounds with { Y = y0, Height = height };
					if (drawSymbol && symbolBitmap is not null) graphics.DrawImage(symbolBitmap, row.X + (row.Width - symbolBitmap.Width) / 2, row.Y + (row.Height - symbolBitmap.Height) / 2);
				}
				Pen columnGridPen = LegendProperty.ColumnGridPen;
				if (!valueBounds.IsEmpty)
				{
					RectangleF row = valueBounds with { Y = y0, Height = height };
					if (!symbolBounds.IsEmpty && LegendProperty.ColumnGridIsEnabled) graphics.DrawLine(columnGridPen, row.Location, new(row.Left, row.Bottom));
					ColumnProperty property = LegendProperty.ValueProperty;
					graphics.DrawString(value, property.TextFont, property.TextBrush, row, property.TextFormat);
				}
				if (!countBounds.IsEmpty)
				{
					RectangleF row = countBounds with { Y = y0, Height = height };
					if ((!symbolBounds.IsEmpty || !valueBounds.IsEmpty) && LegendProperty.ColumnGridIsEnabled) graphics.DrawLine(columnGridPen, row.Location, new(row.Left, row.Bottom));
					ColumnProperty property = LegendProperty.CountProperty;
					graphics.DrawString(valueSum.TryGetValue(root, out int c) ? c.ToString() : string.Empty, property.TextFont, property.TextBrush, row, property.TextFormat);
				}
				//この行の上の境界線を描画する
				RectangleF legendBounds = GlottogramHelper.LegendBounds;
				if (!legendBounds.IsEmpty && upper != LegendGrid.None)
				{
					RectangleF row = new(legendBounds.X + (drawSymbolGrid ? 0 : symbolBounds.Width), y0, drawSymbolGrid ? legendBounds.Width : valueBounds.Width + countBounds.Width, height);
					Pen upperPen = null;
					if (upper == LegendGrid.Line && LegendProperty.LineIsEnabled) upperPen = LegendProperty.LinePen;
					else if (upper == LegendGrid.Group)
					{
						if (LegendProperty.RowGroupGridIsEnabled) upperPen = LegendProperty.RowGroupGridPen;
						else
						{
							if (y0 == LegendProperty.Top && LegendProperty.LineIsEnabled) upperPen = LegendProperty.LinePen;
							else if (LegendProperty.RowGridIsEnabled) upperPen = LegendProperty.RowGridPen;
						}
					}
					else if (LegendProperty.RowGridIsEnabled) upperPen = LegendProperty.RowGridPen;
					if (upperPen is not null) graphics.DrawLine(upperPen, row.Location, new PointF(row.Right, row.Top));
				}
			}
			else
			{
				Bitmap groupSymbol = root.Data?.GetBitmap(LegendProperty.SymbolScale);
				bool noGroupSymbol = groupSymbol is null;
				if (noGroupSymbol)
				{
					upper = upper == LegendGrid.Line ? upper : LegendGrid.Group;
					foreach (Symbol symbol in root.Members) upper = DrawLegendRow(graphics, symbol, ref rowCount, valueSum, upper);
					ret = LegendGrid.Group;
				}
				else
				{
					ret = LegendGrid.Normal;
					int count = rowCount;
					foreach (Symbol symbol in root.Members)
					{
						upper = DrawLegendRow(graphics, symbol, ref rowCount, valueSum, upper, noGroupSymbol, drawSymbolGrid);
						drawSymbolGrid = false;
					}
					RectangleF symbolRow = (RectangleF)GlottogramHelper.LegendSymbolColumnBounds with { Y = y0, Height = rowHeight * (rowCount - count) };
					graphics.DrawImage(groupSymbol, new PointF(symbolRow.Left + (symbolRow.Width - groupSymbol.Width) / 2, symbolRow.Top + (symbolRow.Height - groupSymbol.Height) / 2));
				}
			}
			return ret;
		}

		/// <summary>
		/// 凡例を描画する
		/// </summary>
		private void DrawLegend()
		{
			if (Graphics is null) return;
			if (!LegendProperty.Enabled) return;
			//凡例のヘッダーを描画する
			static LegendGrid DrawLegendHeader(Graphics graphics)
			{
				float rowHeight = LegendProperty.RowHeight;
				RectangleF symbolBounds = GlottogramHelper.LegendSymbolColumnBounds;
				RectangleF valueBounds = GlottogramHelper.LegendValueColumnBounds;
				Rectangle countBounds = GlottogramHelper.LegendCountColumnBounds;
				if (LegendProperty.BackgroundColorEnabled)
				{
					RectangleF rowBounds = (RectangleF)GlottogramHelper.LegendBounds with { Width = symbolBounds.Width + valueBounds.Width + countBounds.Width, Height = rowHeight };
					if (rowBounds.Width != 0)
					{
						using SolidBrush brush = new(LegendProperty.BackgroundColor);
						graphics.FillRectangle(brush, rowBounds);
					}
				}
				Pen columnGridPen = LegendProperty.ColumnGridPen;
				if (!symbolBounds.IsEmpty)
				{
					RectangleF row = symbolBounds with { Height = rowHeight };
					ColumnProperty property = LegendProperty.SymbolProperty;
					StringFormat nameFormat = property.NameFormat;
					graphics.DrawString(property.Name, property.NameFont, property.NameBrush, row.GetPointEx(nameFormat.Alignment, nameFormat.LineAlignment), nameFormat);
				}
				if (!valueBounds.IsEmpty)
				{
					RectangleF row = valueBounds with { Height = rowHeight };
					if (!symbolBounds.IsEmpty && LegendProperty.ColumnGridIsEnabled) graphics.DrawLine(columnGridPen, row.Location, new(row.Left, row.Bottom));
					ColumnProperty property = LegendProperty.ValueProperty;
					StringFormat nameFormat = property.NameFormat;
					graphics.DrawString(property.Name, property.NameFont, property.NameBrush, row.GetPointEx(nameFormat.Alignment, nameFormat.LineAlignment), nameFormat);
				}
				if (!countBounds.IsEmpty)
				{
					RectangleF row = (RectangleF)countBounds with { Height = rowHeight };
					if ((!symbolBounds.IsEmpty || !valueBounds.IsEmpty) && LegendProperty.ColumnGridIsEnabled) graphics.DrawLine(columnGridPen, row.Location, new(row.Left, row.Bottom));
					ColumnProperty property = LegendProperty.CountProperty;
					StringFormat nameFormat = property.NameFormat;
					graphics.DrawString(property.Name, property.NameFont, property.NameBrush, row.GetPointEx(nameFormat.Alignment, nameFormat.LineAlignment), nameFormat);
				}
				return LegendGrid.Line;
			};
			LegendGrid upper = DrawLegendHeader(Graphics);
			int rowCount = 1;
			Dictionary<Symbol, int> valueSum = MainData.GetSymbolSumByView();
			foreach (Symbol s in SymbolData.GetRootSymbols()) upper = DrawLegendRow(Graphics, s, ref rowCount, valueSum, upper);
			RectangleF bounds = (RectangleF)GlottogramHelper.LegendBounds with { Height = LegendProperty.RowHeight * rowCount };
			if (!bounds.IsEmpty && LegendProperty.LineIsEnabled)
			{
				Graphics.DrawLines(LegendProperty.LinePen, new PointF[] { bounds.Location, new(bounds.X, bounds.Bottom), new(bounds.Right, bounds.Bottom), new(bounds.Right, bounds.Top), bounds.Location });
			}
		}

		/// <summary>
		/// テキストボックスを描画する
		/// </summary>
		private void DrawTextBox()
		{
			if (GlottogramImageWithoutTextBox is null) return;
			GlottogramImage?.Dispose();
			GlottogramImage = GlottogramImageWithoutTextBox.Clone() as Bitmap;
			using Graphics g = Graphics.FromImage(GlottogramImage);
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
			foreach (GraphicsTextBox textBox in GlottogramProperty.TextBoxes.Reverse<GraphicsTextBox>())
			{
				if (EscThread.Pressed) return;
				if (textBox.Enabled) textBox.Draw(g);
			}
		}

		/// <summary>
		/// GlottogramImageプロパティに保存したBitmapをGlottogramProperty.ViewScaleでスケーリングし、PictureBoxに表示する。
		/// </summary>
		private void UpdateImage()
		{
			if (GlottogramImage is null) GlottogramImage = GlottogramImageWithoutTextBox?.Clone() as Bitmap;
			if (GlottogramImage is null) return;
			if (glottogramPictureBox.Image is not null) glottogramPictureBox.Image.Dispose();
			float scale = GlottogramProperty.ViewScale;
			int width = (int)(GlottogramImage.Width * scale);
			int height = (int)(GlottogramImage.Height * scale);
			Bitmap bitmap = new(width != 0 ? width : 1, height != 0 ? height : 1);
			using Graphics graphics = Graphics.FromImage(bitmap);
			graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			graphics.Clear(GlottogramProperty.BackColor);
			graphics.DrawImage(GlottogramImage, 0, 0, bitmap.Width, bitmap.Height);
			glottogramPictureBox.Image = bitmap;
			glottogramPictureBox.Invalidate();
		}

		/// <summary>
		/// フォーム上のコントロールを設定する
		/// </summary>
		private void SetControls(bool useCache = false)
		{
			if (columnSortKeyBox.Items.Count == 0 || rowSortKeyBox.Items.Count == 0)
			{
				string[] keys = MainData.GetKeys();
				if (columnSortKeyBox.Items.Count == 0) columnSortKeyBox.InitEx(keys);
				if (rowSortKeyBox.Items.Count == 0) rowSortKeyBox.InitEx(keys);
			}
			int index = columnSortKeyBox.Items.IndexOf(GlottogramData.ColumnSortKey);
			if (index != -1) columnSortKeyBox.SelectedIndex = index;
			index = rowSortKeyBox.Items.IndexOf(GlottogramData.RowSortKey);
			if (index != -1) rowSortKeyBox.SelectedIndex = index;
			if (!useCache)
			{
				if (symbolPictureBox.Image is not null) symbolPictureBox.Image.Dispose();
				symbolPictureBox.Image = null;
				valueListBox.Items.Clear();
				columnNumberBox.Value = null;
				rowNumberBox.Value = null;
				columnTranslateNumberBox.Value = null;
				rowTranslateNumberBox.Value = null;
			}
		}

		/// <summary>
		/// 表示スケールを変更する
		/// </summary>
		private void ViewScale_Changed(object sender, EventArgs e)
		{
			if (sender is not ComboBox comboBox) return;
			if (comboBox.SelectedIndex == -1 || comboBox.SelectedItem is not string value) return;
			if (!int.TryParse(value.Trim('%').Trim(), out int tmp)) return;
			float scale = tmp / 100.0f;
			if (scale == 0.0f) return;
			GlottogramProperty.ViewScale = scale;
			UpdateImage();
		}

		/// <summary>
		/// コントロールに表示されているキャッシュのインデックス
		/// </summary>
		int CacheIndex { get; set; } = -1;

		/// <summary>
		/// クリックしたグロットグラムのセルのソート値と相対移動値をテキストボックスに表示する
		/// </summary>
		private void Glottogram_MouseClick(object sender, MouseEventArgs e)
		{
			if (sender is not PictureBox) return;
			if ((e.Button | MouseButtons.Left) == MouseButtons.Left)
			{
				float scale = GlottogramProperty.ViewScale;
				Cache cache = GlottogramCache.GetCache(new PointF(e.X / scale, e.Y / scale));
				if (cache is null)
				{
					symbolPictureBox.Image = null;
					valueListBox.Items.Clear();
					columnNumberBox.Value = null;
					rowNumberBox.Value = null;
					columnTranslateNumberBox.Value = null;
					rowTranslateNumberBox.Value = null;
					return;
				}
				CacheIndex = cache.DataIndex;
				symbolPictureBox.Image = cache.Bitmap;
				valueListBox.Items.Clear();
				valueListBox.Items.AddRange(MainData.GetValues(cache.DataIndex));
				columnNumberBox.Value = cache.XSortValue;
				rowNumberBox.Value = cache.YSortValue;
				(int rx, int ry) = MainData.GetRelatedTranslate(cache.DataIndex);
				columnTranslateNumberBox.Value = (rx / 100.0f);
				rowTranslateNumberBox.Value = (ry / 100.0f);
			}
		}

		/// <summary>
		/// 選択されているデータの相対移動値を0にする
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ZeroButton_Click(object sender, EventArgs e)
		{
			if (sender is not Button button) return;
			if (button == columnZeroButton)
			{
				MainData.SetRelatedX(CacheIndex, 0);
				(int rx, int _) = MainData.GetRelatedTranslate(CacheIndex);
				columnTranslateNumberBox.Value = (rx / 100.0f);
			}
			else if (button == rowZeroButton)
			{
				MainData.SetRelatedY(CacheIndex, 0);
				(int _, int ry) = MainData.GetRelatedTranslate(CacheIndex);
				rowTranslateNumberBox.Value = (ry / 100.0f);
			}
			else return;
			Draw(true);
		}

		/// <summary>
		/// 選択されているデータの相対移動値を0.1減らす
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MinusButton_Click(object sender, EventArgs e)
		{
			if (sender is not Button button) return;
			if (button == columnMinusButton)
			{
				(int rx, int _) = MainData.GetRelatedTranslate(CacheIndex);
				MainData.SetRelatedX(CacheIndex, rx - 10);
				columnTranslateNumberBox.Value = ((rx - 10) / 100.0f);
			}
			else if (button == rowMinusButton)
			{
				(int _, int ry) = MainData.GetRelatedTranslate(CacheIndex);
				MainData.SetRelatedY(CacheIndex, ry - 10);
				rowTranslateNumberBox.Value = ((ry - 10) / 100.0f);
			}
			else return;
			Draw(true);
		}

		/// <summary>
		/// 選択されているデータの相対移動値を0.1増やす
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PlusButton_Click(object sender, EventArgs e)
		{
			if (sender is not Button button) return;
			if (button == columnPlusButton)
			{
				(int rx, int _) = MainData.GetRelatedTranslate(CacheIndex);
				MainData.SetRelatedX(CacheIndex, rx + 10);
				columnTranslateNumberBox.Value = ((rx + 10) / 100.0f);
			}
			else if (button == rowPlusButton)
			{
				(int _, int ry) = MainData.GetRelatedTranslate(CacheIndex);
				MainData.SetRelatedY(CacheIndex, ry + 10);
				rowTranslateNumberBox.Value = ((ry + 10) / 100.0f);
			}
			else return;
			Draw(true);
		}

		/// <summary>
		/// 選択されているデータの相対移動値を変更する
		/// </summary>
		private void RelatedValue_Leave(object sender, EventArgs e)
		{
			if (sender is not NumberBox box) return;
			if (box == columnTranslateNumberBox)
			{
				(int rx, int _) = MainData.GetRelatedTranslate(CacheIndex);
				float nx = box.GetValue<float>(MathF.Round(rx / 100.0f));
				MainData.SetRelatedX(CacheIndex, (int)(nx * 100.0f));
				columnTranslateNumberBox.Value = nx;
			}
			else if (box == rowTranslateNumberBox)
			{
				(int _, int ry) = MainData.GetRelatedTranslate(CacheIndex);
				float ny = box.GetValue<float>(MathF.Round(ry / 100.0f));
				MainData.SetRelatedY(CacheIndex, (int)(ny * 100.0f));
				rowTranslateNumberBox.Value = ny;
			}
			else return;
			Draw(true);
		}

		/// <summary>
		/// マウスホイールによるスクロールを行う
		/// </summary>
		private void MouseWheel_Event(object sender, MouseEventArgs e)
		{
			VScrollProperties properties = glottogramPanel.VerticalScroll;
			properties.Value = (properties.Value + e.Delta / 20).ClampEx(properties.Minimum, properties.Maximum);
		}

		/// <summary>
		/// プロパティの読み込み
		/// </summary>
		private void LoadProperty_Event(object sender, EventArgs e)
		{
			using OpenFileDialog ofd = new();
			ofd.FileName = ".gcp";
			ofd.Filter = "GlottogramCreator Propertyデータファイル(*.gcp)|*.gcp|XMLファイル(*.xml)|*.xml";
			ofd.FilterIndex = 1;
			ofd.Title = "ファイルを選択してください";
			ofd.RestoreDirectory = true;
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				GlottogramProperty.Load(ofd.FileName);
				HeaderProperty.Load(ofd.FileName);
				LegendProperty.Load(ofd.FileName);
				Draw();
			}
		}

		/// <summary>
		/// プロパティの出力
		/// </summary>
		private void ExportProperty_Event(object sender, EventArgs e)
		{
			using SaveFileDialog fileDialog = new();
			fileDialog.FileName = ".gcp";
			fileDialog.Filter = "GlottogramCreator Propertyデータファイル(*.gcp)|*.gcp|XMLファイル(*.xml)|*.xml";
			fileDialog.FilterIndex = 1;
			fileDialog.Title = "名前をつけて保存";
			fileDialog.RestoreDirectory = true;
			if (fileDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					System.Xml.Linq.XDocument xDocument = XDocumentExtend.CreateEx("root");
					xDocument.Root.Add(GlottogramProperty.Output());
					xDocument.Root.Add(HeaderProperty.Output());
					xDocument.Root.Add(LegendProperty.Output());
					if (!xDocument.SaveEx(fileDialog.FileName)) throw new Exception("ファイル保存エラー");
				}
				catch (Exception ex)
				{
					MessageForm.Show("保存中に以下の例外が発生しました。\n" + ex.Message, "例外エラー");
					return;
				}
				MessageForm.Show("編集データをファイルに保存しました。\n保存先：" + fileDialog.FileName);
			}
		}

		/// <summary>
		/// 印刷ボタンから印刷する
		/// </summary>
		private void PrintToolStripMenuItem_Click(object sender, EventArgs e)
		{
			System.Drawing.Printing.PrintDocument printDocument = new();
			printDocument.PrintPage += new(PrintEvent);
			PrintDialog printDialog = new();
			printDialog.Document = printDocument;
			printDialog.UseEXDialog = true;
			if (printDialog.ShowDialog() == DialogResult.OK) printDocument.Print();
		}

		/// <summary>
		/// 印刷用イベント
		/// </summary>
		private void PrintEvent(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			if (GlottogramImage is not null) e.Graphics.DrawImage(GlottogramImage, e.PageBounds);
			e.HasMorePages = false;
		}

		/// <summary>
		/// 画像保存用イベント
		/// </summary>
		private void SaveImage_Event(object sender, EventArgs e)
		{
			using SaveFileDialog fileDialog = new();
			fileDialog.FileName = ".bmp";
			fileDialog.Filter = "ビットマップ画像ファイル(*.bmp)|*.bmp|PNG画像ファイル(*.png)|*.png|JPEG画像ファイル(*.jpg;*.jpeg)|*.jpg;*jpeg";
			fileDialog.FilterIndex = 1;
			fileDialog.Title = "名前をつけて保存";
			fileDialog.RestoreDirectory = true;
			if (fileDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					if (GlottogramImage is null) MessageForm.Show("エラー：画像が描画されていません。", "エラー");
					else
					{
						string extension = System.IO.Path.GetExtension(fileDialog.FileName);
						if (string.IsNullOrEmpty(extension))
						{
							MessageForm.Show("エラー：画像フォーマットが特定できません。", "エラー");
							return;
						}
						else if (string.Compare(extension, ".bmp", true) == 0) GlottogramImage.Save(fileDialog.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
						else if (string.Compare(extension, ".png", true) == 0) GlottogramImage.Save(fileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
						else if (string.Compare(extension, ".jpg", true) == 0 || string.Compare(extension, ".jpeg", true) == 0) GlottogramImage.Save(fileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
						else
						{
							MessageForm.Show("エラー：拡張子" + extension + "には対応していません。", "エラー");
							return;
						}
						MessageForm.Show("保存しました。\n保存先：" + fileDialog.FileName);
					}
				}
				catch (Exception ex)
				{
					MessageForm.Show("エラー：保存中に以下の例外が発生しました。\n" + ex.Message, "例外エラー");
				}
			}
		}

		/// <summary>
		/// プロパティの変更
		/// </summary>
		private void PropertyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PropertyToolWindow.OpenOrShowDialog(this);
			if (PropertyToolWindow.StaticDialogResult == DialogResult.OK) Draw();
		}

		/// <summary>
		/// DPISettingを開き、グロットグラムの大きさを用紙サイズに合わせる
		/// </summary>
		private void SizeSetting_Click(object sender, EventArgs e)
		{
			DPISetting.OpenOrShowDialog(this);
			if (DPISetting.StaticDialogResult == DialogResult.OK) Draw();
		}

		/// <summary>
		/// 新しいテキストボックスを追加する
		/// </summary>
		private void AddTextBox_Event(object sender, EventArgs e)
		{
			Point client = glottogramPictureBox.PointToClient(MousePosition);
			float scale = GlottogramProperty.ViewScale;
			PointF pF = new(client.X / scale, client.Y / scale);
			GraphicsTextBox tmp = new();
			tmp.Text = "新規テキストボックス";
			tmp.Rectangle = new(pF.X, pF.Y, 200, 200);
			GlottogramProperty.TextBoxes.Add(tmp);
			DrawTextBox();
			UpdateImage();
		}

		bool IsDragging = false;
		GraphicsTextBox DraggingTextBox = null;
		MouseButtons DraggingButton = MouseButtons.None;
		float DraggingOldX = 0;
		float DraggingOldY = 0;
		Timer DraggingTimer = null;

		bool IsResizing = false;
		GraphicsTextBox ResizingTextBox = null;
		Edge ResizingEdge = Edge.None;
		float ResizingOldX = 0;
		float ResizingOldY = 0;
		Timer ResizingTimer = null;

		ToolStripMenuItem EditTextBoxMenu { get; set; } = null;
		ToolStripMenuItem RemoveTextBoxMenu { get; set; } = null;

		enum Edge
		{
			None,
			Top = 1,
			Left = 2,
			Right = 4,
			Bottom = 8
		}

		/// <summary>
		/// (内部関数)PictureBox内の座標からGraphicsTextBoxを探す
		/// </summary>
		/// <param name="clientPos">glottogramPictureBox内のクライアント座標</param>
		/// <returns>第一引数を含むGraphicsTextBox。存在しない場合、null</returns>
#nullable enable
		private static GraphicsTextBox? GetGraphicsTextBox(Point clientPos, out Edge edge)
		{
			IEnumerable<GraphicsTextBox> textBoxes = GlottogramProperty.TextBoxes.Where(x => x.Enabled);
			float scale = GlottogramProperty.ViewScale;
			PointF pF = new(clientPos.X / scale, clientPos.Y / scale);
			GraphicsTextBox? ret = textBoxes.Where(x => x.Rectangle.Contains(pF.X, pF.Y)).FirstOrDefault();
			edge = Edge.None;
			if (ret is not null)
			{
				RectangleF rect = ret.Rectangle;
				float wEdgeRange = MathF.Min(rect.Width * 0.05f, 20);
				float hEdgeRange = MathF.Min(rect.Height * 0.05f, 20);
				if (MathF.Abs(rect.Bottom - pF.Y) <= hEdgeRange) edge |= Edge.Bottom;
				else if (MathF.Abs(rect.Top - pF.Y) <= hEdgeRange) edge |= Edge.Top;
				if (MathF.Abs(rect.Right - pF.X) <= wEdgeRange) edge |= Edge.Right;
				else if (MathF.Abs(rect.Left - pF.X) <= wEdgeRange) edge |= Edge.Left;
			}
			return ret;
		}
#nullable restore
		/// <summary>
		/// GraphicsTextBoxのドラッグ移動・サイズ変更と編集右クリックメニュー設定用
		/// </summary>
#nullable enable
		private void MouseDown_Event(object sender, MouseEventArgs e)
		{
			if (sender is not PictureBox pictureBox) return;
			if (e.Button == MouseButtons.Left)
			{
				GraphicsTextBox? textBox = GetGraphicsTextBox(e.Location, out Edge edge);
				if (textBox is null) return;
				//辺周辺以外の場合、ドラッグ移動
				if (edge == Edge.None)
				{
					float scale = GlottogramProperty.ViewScale;
					IsDragging = true;
					Cursor = Cursors.SizeAll;
					DraggingTextBox = textBox;
					DraggingButton = e.Button;
					DraggingOldX = e.X / scale;
					DraggingOldY = e.Y / scale;
					void MouseMove_Event()
					{
						if (IsDragging && DraggingTextBox is not null && DraggingButton == MouseButtons.Left)
						{
							RectangleF rect = DraggingTextBox.Rectangle;
							float scale = GlottogramProperty.ViewScale;
							Point point = pictureBox.PointToClient(MousePosition);
							Rectangle client = pictureBox.ClientRectangle;
							if (!client.Contains(point))
							{
								point.X = point.X < client.X ? client.X : client.Right < point.X ? client.Right : point.X;
								point.Y = point.Y < client.Y ? client.Y : client.Bottom < point.Y ? client.Bottom : point.Y;
							}
							PointF pF = new(point.X / scale, point.Y / scale);
							DraggingTextBox.Rectangle = new RectangleF(rect.X + pF.X - DraggingOldX, rect.Y + pF.Y - DraggingOldY, rect.Width, rect.Height);
							DraggingOldX = pF.X;
							DraggingOldY = pF.Y;
							DrawTextBox();
							UpdateImage();
						}
					};
					if (DraggingTimer is not null && DraggingTimer.Enabled) DraggingTimer.Stop();
					DraggingTimer?.Dispose();
					DraggingTimer = new();
					DraggingTimer.Interval = 20;
					DraggingTimer.Tick += (object? sender, EventArgs e) => Invoke(MouseMove_Event);
					DraggingTimer.Start();
				}
				//辺の周辺の場合、サイズ変更
				else
				{
					if (edge == Edge.Top || edge == Edge.Bottom) Cursor = Cursors.SizeNS;
					else if (edge == Edge.Left || edge == Edge.Right) Cursor = Cursors.SizeWE;
					else if (edge == (Edge.Left | Edge.Top) || edge == (Edge.Right | Edge.Bottom)) Cursor = Cursors.SizeNWSE;
					else if (edge == (Edge.Left | Edge.Bottom) || edge == (Edge.Right | Edge.Top)) Cursor = Cursors.SizeNESW;
					else return;
					float scale = GlottogramProperty.ViewScale;
					IsResizing = true;
					ResizingTextBox = textBox;
					ResizingEdge = edge;
					ResizingOldX = e.X / scale;
					ResizingOldY = e.Y / scale;
					void MouseMove_Event()
					{
						if (IsResizing && ResizingTextBox is not null)
						{
							RectangleF rect = ResizingTextBox.Rectangle;
							float scale = GlottogramProperty.ViewScale;
							Point point = pictureBox.PointToClient(MousePosition);
							Rectangle client = pictureBox.ClientRectangle;
							if (!client.Contains(point))
							{
								point.X = point.X < client.X ? client.X : client.Right < point.X ? client.Right : point.X;
								point.Y = point.Y < client.Y ? client.Y : client.Bottom < point.Y ? client.Bottom : point.Y;
							}
							PointF pF = new(point.X / scale, point.Y / scale);
							float deltaX = pF.X - ResizingOldX;
							float deltaY = pF.Y - ResizingOldY;
							if ((ResizingEdge & Edge.Bottom) == Edge.Bottom)
							{
								float newHeight = rect.Height + deltaY;
								if (newHeight <= 1) newHeight = 1;
								rect.Height = newHeight;
							}
							else if ((ResizingEdge & Edge.Top) == Edge.Top)
							{
								float newHeight = rect.Height - deltaY;
								if (newHeight <= 1)
								{
									newHeight = 1;
									deltaY = rect.Height - newHeight;
								}
								rect.Y += deltaY;
								rect.Height = newHeight;
							}
							if ((ResizingEdge & Edge.Right) == Edge.Right)
							{
								float newWidth = rect.Width + deltaX;
								if (newWidth <= 1) newWidth = 1;
								rect.Width = newWidth;
							}
							else if ((ResizingEdge & Edge.Left) == Edge.Left)
							{
								float newWidth = rect.Width - deltaX;
								if (newWidth <= 1)
								{
									newWidth = 1;
									deltaX = rect.Width - newWidth;
								}
								rect.X += deltaX;
								rect.Width = newWidth;
							}
							ResizingTextBox.Rectangle = new RectangleF(rect.X, rect.Y, rect.Width, rect.Height);
							ResizingOldX = pF.X;
							ResizingOldY = pF.Y;
							DrawTextBox();
							UpdateImage();
						}
					};
					if (ResizingTimer is not null && ResizingTimer.Enabled) ResizingTimer.Stop();
					ResizingTimer?.Dispose();
					ResizingTimer = new();
					ResizingTimer.Interval = 20;
					ResizingTimer.Tick += (object? sender, EventArgs e) => Invoke(MouseMove_Event);
					ResizingTimer.Start();
				}
			}
			else if (e.Button == MouseButtons.Right)
			{
				if (GetGraphicsTextBox(e.Location, out _) is GraphicsTextBox graphicsTextBox)
				{
					void Edit(object? sender, EventArgs ev)
					{
						if (sender is not ToolStripMenuItem item || item.Tag is not GraphicsTextBox textBox) return;
						if (EditGraphicsTextBox.ShowDialog(this, textBox) == DialogResult.OK)
						{
							DrawTextBox();
							UpdateImage();
						}
					};
					if (EditTextBoxMenu is null)
					{
						EditTextBoxMenu = new ToolStripMenuItem() { Text = "テキストボックスを編集する", Name = "Edit" };
						EditTextBoxMenu.Click += Edit;
					}
					EditTextBoxMenu.Tag = graphicsTextBox;
					if (!pictureBox.ContextMenuStrip.Items.Contains(EditTextBoxMenu)) pictureBox.ContextMenuStrip.Items.Add(EditTextBoxMenu);
					void Remove(object? sender, EventArgs e)
					{
						if (sender is not ToolStripMenuItem item || item.Tag is not GraphicsTextBox textBox) return;
						if (MessageForm.Show("このテキストボックスを削除してもよろしいですか？\nテキスト：" + textBox.Text, "テキストボックスの削除", MessageBoxButtons.YesNo) == DialogResult.Yes)
						{
							GlottogramProperty.TextBoxes.Remove(textBox);
							DrawTextBox();
							UpdateImage();
						}
					};
					if (RemoveTextBoxMenu is null)
					{
						RemoveTextBoxMenu = new ToolStripMenuItem() { Text = "テキストボックスを削除する", Name = "Remove" };
						RemoveTextBoxMenu.Click += Remove;
					}
					RemoveTextBoxMenu.Tag = graphicsTextBox;
					if (!pictureBox.ContextMenuStrip.Items.Contains(RemoveTextBoxMenu)) pictureBox.ContextMenuStrip.Items.Add(RemoveTextBoxMenu);
				}
				else
				{
					if (EditTextBoxMenu is not null)
					{
						EditTextBoxMenu.Tag = null;
						pictureBox.ContextMenuStrip.Items.Remove(EditTextBoxMenu);
					}
					if (RemoveTextBoxMenu is not null)
					{
						RemoveTextBoxMenu.Tag = null;
						pictureBox.ContextMenuStrip.Items.Remove(RemoveTextBoxMenu);
					}
				}
			}
		}
#nullable restore
		/// <summary>
		/// GraphicsTextBoxのドラッグ移動終了用
		/// </summary>
		private void MouseUp_Event(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (IsDragging)
				{
					IsDragging = false;
					DraggingButton = MouseButtons.None;
					DraggingOldX = 0;
					DraggingOldY = 0;
					DraggingTextBox = null;
					Cursor = Cursors.Default;
					DraggingTimer?.Stop();
					DraggingTimer?.Dispose();
					DraggingTimer = null;
				}
				if (IsResizing)
				{
					IsResizing = false;
					ResizingOldX = 0;
					ResizingOldY = 0;
					ResizingTextBox = null;
					Cursor = Cursors.Default;
					ResizingTimer?.Stop();
					ResizingTimer?.Dispose();
					ResizingTimer = null;
				}
			}
		}

		/// <summary>
		/// マウスが離れたときにGraphicsTextBoxのドラッグ移動を終了する
		/// </summary>
		private void MouseLeave_Event(object sender, EventArgs e) => MouseUp_Event(sender, new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0));

		/// <summary>
		/// GraphicsTextBoxListフォームを開く
		/// </summary>
		private void OpenTextBoxList_Event(object sender, EventArgs e)
		{
			GraphicsTextBoxList.OpenOrShowDialog(this);
			DrawTextBox();
			UpdateImage();
		}
	}
	public class Glottogram_Internal : SingletonForm<Glottogram> { }

	static class GlottogramHelper
	{
		public static int ImageWidth => GlottogramWidthWithPadding + LegendWidthWithPadding;
		public static int ImageHeight => GlottogramHeightWithPadding;
		public static int GlottogramWidthWithPadding => GlottogramProperty.Horizontal + GlottogramProperty.Width + HeaderProperty.RowWidth;
		public static int GlottogramHeightWithPadding => GlottogramProperty.Vertical + GlottogramProperty.Height + HeaderProperty.ColumnHeight;
		public static int LegendWidthWithPadding => LegendProperty.Enabled && (LegendProperty.Horizontal + LegendWidth) > 0 ? LegendProperty.Horizontal + LegendWidth : 0;
		public static int LegendHeightWithPadding => LegendProperty.Enabled ? GlottogramHeightWithPadding : 0;
		public static Rectangle HeaderTopLeftBounds => new(GlottogramProperty.Left, GlottogramProperty.Top, HeaderProperty.RowWidth, HeaderProperty.ColumnHeight);
		public static Rectangle ColumnHeaderBounds => new(GlottogramProperty.Left + HeaderProperty.RowWidth, GlottogramProperty.Top, GlottogramProperty.Width, HeaderProperty.ColumnHeight);
		public static Rectangle RowHeaderBounds => new(GlottogramProperty.Left, GlottogramProperty.Top + HeaderProperty.ColumnHeight, HeaderProperty.RowWidth, GlottogramProperty.Height);
		public static Rectangle GlottogramBounds => new(GlottogramProperty.Left + HeaderProperty.RowWidth, GlottogramProperty.Top + HeaderProperty.ColumnHeight, GlottogramProperty.Width, GlottogramProperty.Height);
		public static Rectangle LegendBounds => new(GlottogramWidthWithPadding + LegendProperty.Left, LegendProperty.Top, LegendProperty.Width, GlottogramHeightWithPadding - LegendProperty.Bottom);
		public static int LegendSymbolColumnWidth => LegendProperty.Enabled && LegendProperty.SymbolProperty.Enabled ? LegendProperty.SymbolProperty.Width : 0;
		public static int LegendValueColumnWidth => LegendProperty.Enabled && LegendProperty.ValueProperty.Enabled ? LegendProperty.ValueProperty.Width : 0;
		public static int LegendCountColumnWidth => LegendProperty.Enabled && LegendProperty.CountProperty.Enabled ? LegendProperty.CountProperty.Width : 0;
		public static int LegendWidth => LegendSymbolColumnWidth + LegendValueColumnWidth + LegendCountColumnWidth;
		public static Rectangle LegendSymbolColumnBounds => LegendProperty.Enabled && LegendProperty.SymbolProperty.Enabled ? new(GlottogramWidthWithPadding + LegendProperty.Left, LegendProperty.Top, LegendProperty.SymbolProperty.Width, GlottogramHeightWithPadding - LegendProperty.Vertical) : Rectangle.Empty;
		public static Rectangle LegendValueColumnBounds => LegendProperty.Enabled && LegendProperty.ValueProperty.Enabled ? new(GlottogramWidthWithPadding + LegendProperty.Left + LegendSymbolColumnWidth, LegendProperty.Top, LegendProperty.ValueProperty.Width, GlottogramHeightWithPadding - LegendProperty.Vertical) : Rectangle.Empty;
		public static Rectangle LegendCountColumnBounds => LegendProperty.Enabled && LegendProperty.CountProperty.Enabled ? new(GlottogramWidthWithPadding + LegendProperty.Left + LegendSymbolColumnWidth + LegendValueColumnWidth, LegendProperty.Top, LegendProperty.CountProperty.Width, GlottogramHeightWithPadding - LegendProperty.Vertical) : Rectangle.Empty;
	}
}
