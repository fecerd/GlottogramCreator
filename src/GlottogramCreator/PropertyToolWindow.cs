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
	public partial class PropertyToolWindow : PropertyToolWindow_Internal
	{
		private PropertyToolWindow()
		{
			InitializeComponent();
			//フォント変更
			Config.SetMainFont(this);
			//イベント設定
			Load += (object sender, EventArgs e) =>
			{
				Application.DoEvents();
				PropertyToolWindow_Load(sender, e);
			};
		}

		protected override void OnFontChanged(EventArgs e)
		{
			base.OnFontChanged(e);
			TableLayoutPanel[] tableLayoutPanels = Controls.OfType<TableLayoutPanel>().FirstOrDefault().Controls.OfType<TabControl>().FirstOrDefault()?.TabPages.OfType<TabPage>().Select(x => x.Controls.OfType<Panel>().FirstOrDefault()?.Controls.OfType<TableLayoutPanel>().FirstOrDefault()).Where(x => x is not null).ToArray();
			TableLayoutPanel max = tableLayoutPanels.MaxBy(x => x.Width);
			foreach (var t in tableLayoutPanels) t.Dock = DockStyle.Top;
			if (max.Width - (max.Parent.Width - 30) > 0) Width += max.Width - max.Parent.Width + 30;
		}

		Font headerTopLeftTextFont = null;
		Font HeaderTopLeftTextFont
		{
			set
			{
				if (value is not null) headerTopLeftTextFont?.Dispose();
				headerTopLeftTextFont = value ?? headerTopLeftTextFont;
				headerTextFontNameTextBox.Text = headerTopLeftTextFont.Name;
				headerTextFontStyleTextBox.Text = headerTopLeftTextFont.Style.ToString();
				headerTextFontSizeTextBox.Text = headerTopLeftTextFont.Size.ToString() + " " + headerTopLeftTextFont.Unit.ToString();
				headerTextFontUnderlineCheckBox.Checked = headerTopLeftTextFont.Underline;
				headerTextFontStrikeoutCheckBox.Checked = headerTopLeftTextFont.Strikeout;
			}
		}

		Font columnHeaderFont = null;
		Font ColumnHeaderFont
		{
			set
			{
				if (value is not null) columnHeaderFont?.Dispose();
				columnHeaderFont = value ?? columnHeaderFont;
				columnHeaderFontNameTextBox.Text = columnHeaderFont.Name;
				columnHeaderFontStyleTextBox.Text = columnHeaderFont.Style.ToString();
				columnHeaderFontSizeTextBox.Text = columnHeaderFont.Size.ToString() + " " + columnHeaderFont.Unit.ToString();
				columnHeaderFontUnderlineCheckBox.Checked = columnHeaderFont.Underline;
				columnHeaderFontStrikeoutCheckBox.Checked = columnHeaderFont.Strikeout;
			}
		}

		Font rowHeaderFont = null;
		Font RowHeaderFont
		{
			set
			{
				if (value is not null) rowHeaderFont?.Dispose();
				rowHeaderFont = value ?? rowHeaderFont;
				rowHeaderFontNameTextBox.Text = rowHeaderFont.Name;
				rowHeaderFontStyleTextBox.Text = rowHeaderFont.Style.ToString();
				rowHeaderFontSizeTextBox.Text = rowHeaderFont.Size.ToString() + " " + rowHeaderFont.Unit.ToString();
				rowHeaderFontUnderlineCheckBox.Checked = rowHeaderFont.Underline;
				rowHeaderFontStrikeoutCheckBox.Checked = rowHeaderFont.Strikeout;
			}
		}

		Font legendSymbolColumnNameFont = null;
		Font LegendSymbolColumnNameFont
		{
			set
			{
				if (value is not null) legendSymbolColumnNameFont?.Dispose();
				legendSymbolColumnNameFont = value ?? legendSymbolColumnNameFont;
				legendSymbolColumnNameFontNameTextBox.Text = legendSymbolColumnNameFont.Name;
				legendSymbolColumnNameFontStyleTextBox.Text = legendSymbolColumnNameFont.Style.ToString();
				legendSymbolColumnNameFontSizeTextBox.Text = legendSymbolColumnNameFont.Size.ToString() + " " + legendSymbolColumnNameFont.Unit.ToString();
				legendSymbolColumnTextFontUnderlineCheckBox.Checked = legendSymbolColumnNameFont.Underline;
				legendSymbolColumnTextFontStrikeoutCheckBox.Checked = legendSymbolColumnNameFont.Strikeout;
			}
		}

		Font legendSymbolColumnTextFont = null;
		Font LegendSymbolColumnTextFont
		{
			set
			{
				if (value is not null) legendSymbolColumnTextFont?.Dispose();
				legendSymbolColumnTextFont = value ?? legendSymbolColumnTextFont;
				legendSymbolColumnTextFontNameTextBox.Text = legendSymbolColumnTextFont.Name;
				legendSymbolColumnTextFontStyleTextBox.Text = legendSymbolColumnTextFont.Style.ToString();
				legendSymbolColumnTextFontSizeTextBox.Text = legendSymbolColumnTextFont.Size.ToString() + " " + legendSymbolColumnTextFont.Unit.ToString();
				legendSymbolColumnTextFontUnderlineCheckBox.Checked = legendSymbolColumnTextFont.Underline;
				legendSymbolColumnTextFontStrikeoutCheckBox.Checked = legendSymbolColumnTextFont.Strikeout;
			}
		}

		Font legendValueColumnNameFont = null;
		Font LegendValueColumnNameFont
		{
			set
			{
				if (value is not null) legendValueColumnNameFont?.Dispose();
				legendValueColumnNameFont = value ?? legendValueColumnNameFont;
				legendValueColumnNameFontNameTextBox.Text = legendValueColumnNameFont.Name;
				legendValueColumnNameFontStyleTextBox.Text = legendValueColumnNameFont.Style.ToString();
				legendValueColumnNameFontSizeTextBox.Text = legendValueColumnNameFont.Size.ToString() + " " + legendValueColumnNameFont.Unit.ToString();
				legendValueColumnNameFontUnderlineCheckBox.Checked = legendValueColumnNameFont.Underline;
				legendValueColumnNameFontStrikeoutCheckBox.Checked = legendValueColumnNameFont.Strikeout;
			}
		}

		Font legendValueColumnTextFont = null;
		Font LegendValueColumnTextFont
		{
			set
			{
				if (value is not null) legendValueColumnTextFont?.Dispose();
				legendValueColumnTextFont = value ?? legendValueColumnTextFont;
				legendValueColumnTextFontNameTextBox.Text = legendValueColumnTextFont.Name;
				legendValueColumnTextFontStyleTextBox.Text = legendValueColumnTextFont.Style.ToString();
				legendValueColumnTextFontSizeTextBox.Text = legendValueColumnTextFont.Size.ToString() + " " + legendValueColumnTextFont.Unit.ToString();
				legendValueColumnTextFontUnderlineCheckBox.Checked = legendValueColumnTextFont.Underline;
				legendValueColumnTextFontStrikeoutCheckBox.Checked = legendValueColumnTextFont.Strikeout;
			}
		}

		Font legendCountColumnNameFont = null;
		Font LegendCountColumnNameFont
		{
			set
			{
				if (value is not null) legendCountColumnNameFont?.Dispose();
				legendCountColumnNameFont = value ?? legendCountColumnNameFont;
				legendCountColumnNameFontNameTextBox.Text = legendCountColumnNameFont.Name;
				legendCountColumnNameFontStyleTextBox.Text = legendCountColumnNameFont.Style.ToString();
				legendCountColumnNameFontSizeTextBox.Text = legendCountColumnNameFont.Size.ToString() + " " + legendCountColumnNameFont.Unit.ToString();
				legendCountColumnNameFontUnderlineCheckBox.Checked = legendCountColumnNameFont.Underline;
				legendCountColumnNameFontStrikeoutCheckBox.Checked = legendCountColumnNameFont.Strikeout;
			}
		}

		Font legendCountColumnTextFont = null;
		Font LegendCountColumnTextFont
		{
			set
			{
				if (value is not null) legendCountColumnTextFont?.Dispose();
				legendCountColumnTextFont = value ?? legendCountColumnTextFont;
				legendCountColumnTextFontNameTextBox.Text = legendCountColumnTextFont.Name;
				legendCountColumnTextFontStyleTextBox.Text = legendCountColumnTextFont.Style.ToString();
				legendCountColumnTextFontSizeTextBox.Text = legendCountColumnTextFont.Size.ToString() + " " + legendCountColumnTextFont.Unit.ToString();
				legendCountColumnTextFontUnderlineCheckBox.Checked = legendCountColumnTextFont.Underline;
				legendCountColumnTextFontStrikeoutCheckBox.Checked = legendCountColumnTextFont.Strikeout;
			}
		}

		Bitmap glottogramBackgroundImage = null;
		Bitmap GlottogramBackgroundImage
		{
			set
			{
				glottogramBackgroundImage = value;
				if (glottogramBackgroundImagePictureBox.Image is Image image)
				{
					glottogramBackgroundImagePictureBox.Image = null;
					image.Dispose();
				}
				if (glottogramBackgroundImage is not null)
				{
					float scale = MathF.Max((float)glottogramBackgroundImagePanel.Width / glottogramBackgroundImage.Width, (float)glottogramBackgroundImagePanel.Height / glottogramBackgroundImage.Height);
					scale = scale > 1 || scale == 0 ? 1 : scale;
					Bitmap bitmap = new((int)(glottogramBackgroundImage.Width * scale), (int)(glottogramBackgroundImage.Height * scale));
					using Graphics graphics = Graphics.FromImage(bitmap);
					graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
					graphics.Clear(Color.White);
					graphics.DrawImage(glottogramBackgroundImage, 0, 0, bitmap.Width, bitmap.Height);
					glottogramBackgroundImagePictureBox.Image = bitmap;
				}
			}
		}

		SvgWrapper.SvgData glottogramMultipleSymbol = null;
		SvgWrapper.SvgData GlottogramMultipleSymbol
		{
			set
			{
				glottogramMultipleSymbol = value;
				glottogramMultipleSymbolPictureBox.Image = glottogramMultipleSymbol?.GetBitmap(height : glottogramMultipleSymbolPictureBox.Height - 2);
			}
		}

		/// <summary>
		/// 各コントロールに値を読みこむ
		/// </summary>
		private void PropertyToolWindow_Load(object sender, EventArgs e)
		{
			//本体タブ
			{
				glottogramWidthNumberBox.Value = GlottogramProperty.Width;
				glottogramHeightNumberBox.Value = GlottogramProperty.Height;
				glottogramCellWidthNumberBox.Value = GlottogramProperty.ColumnWidth;
				glottogramCellHeightNumberBox.Value = GlottogramProperty.RowHeight;
				glottogramPaddingTopNumberBox.Value = GlottogramProperty.Top;
				glottogramPaddingBottomNumberBox.Value = GlottogramProperty.Bottom;
				glottogramPaddingLeftNumberBox.Value = GlottogramProperty.Left;
				glottogramPaddingRightNumberBox.Value = GlottogramProperty.Right;
				backColorButton.Color = GlottogramProperty.BackColor;
				glottogramBackgroundImageEnabledCheckBox.Checked = GlottogramProperty.BackgroundImageEnabled;
				glottogramBackgroundImageModeEnumComboBox.SelectedEnumValue = GlottogramProperty.BackgroundImageMode;
				GlottogramBackgroundImage = GlottogramProperty.BackgroundImage;
				symbolScaleNumberBox.Value = GlottogramProperty.SymbolScale;
				{
					glottogramLineEnabledCheckBox.Checked = GlottogramProperty.LineEnabled;
					Pen linePen = GlottogramProperty.LinePen;
					glottogramLineColorButton.Color = linePen.Color;
					glottogramLineWidthNumberBox.Value = linePen.Width;
					int index = glottogramLineStyleComboBox.Items.IndexOf(linePen.DashStyle.ToString());
					if (index != -1) glottogramLineStyleComboBox.SelectedIndex = index;
				}
				{
					glottogramColumnGridEnabledCheckBox.Checked = GlottogramProperty.ColumnGridEnabled;
					Pen columnGridPen = GlottogramProperty.ColumnGridPen;
					glottogramColumnGridColorButton.Color = columnGridPen.Color;
					glottogramColumnGridWidthNumberBox.Value = columnGridPen.Width;
					int index = glottogramColumnGridLineStyleComboBox.Items.IndexOf(columnGridPen.DashStyle.ToString());
					if (index != -1) glottogramColumnGridLineStyleComboBox.SelectedIndex = index;
				}
				{
					glottogramRowGridEnabledCheckBox.Checked = GlottogramProperty.RowGridEnabled;
					Pen rowGridPen = GlottogramProperty.RowGridPen;
					glottogramRowGridColorButton.Color = rowGridPen.Color;
					glottogramRowGridWidthNumberBox.Value = rowGridPen.Width;
					int index = glottogramRowGridLineStyleComboBox.Items.IndexOf(rowGridPen.DashStyle.ToString());
					if (index != -1) glottogramRowGridLineStyleComboBox.SelectedIndex = index;
				}
				glottogramMultipleSymbolEnabledCheckBox.Checked = GlottogramProperty.MultipleSymbolEnabled;
				GlottogramMultipleSymbol = GlottogramProperty.MultipleSymbol?.Data;
				glottogramMultipleSymbolRelatedYNumberBox.Value = GlottogramProperty.MultipleSymbolRelatedY;
			}
			//ヘッダータブ
			{
				//左上
				headerTextEnabledCheckBox.Checked = HeaderProperty.TopLeftTextIsEnabled;
				headerTextBox.Text = HeaderProperty.TopLeftText;
				HeaderTopLeftTextFont = HeaderProperty.TopLeftTextFont.Clone() as Font;
				headerTextFontColorButton.Color = HeaderProperty.TopLeftTextBrush.Color;
				headerTextAlignmentEnumComboBox.SelectedEnumValue = HeaderProperty.TopLeftTextFormat.Alignment;
				headerTextLineAlignmentEnumComboBox.SelectedEnumValue = HeaderProperty.TopLeftTextFormat.LineAlignment;
				//列ヘッダー
				columnHeaderEnabledCheckBox.Checked = HeaderProperty.ColumnIsEnabled;
				columnHeaderHeightCheckBox.Checked = false;
				columnHeaderHeightNumberBox.Value = HeaderProperty.TrueColumnHeight;
				columnHeaderLineEnabledCheckBox.Checked = HeaderProperty.ColumnLineIsEnabled;
				{
					Pen pen = HeaderProperty.ColumnLinePen;
					columnHeaderLineStyleComboBox.SelectedDashStyle = pen.DashStyle;
					columnHeaderLineWidthNumberBox.Value = pen.Width;
					columnHeaderLineColorButton.Color = pen.Color;
				}
				columnHeaderGridEnabledCheckBox.Checked = HeaderProperty.ColumnGridIsEnabled;
				{
					Pen pen = HeaderProperty.ColumnGridPen;
					columnHeaderGridLineStyleComboBox.SelectedDashStyle = pen.DashStyle;
					columnHeaderGridWidthNumberBox.Value = pen.Width;
					columnHeaderGridColorButton.Color = pen.Color;
				}
				columnHeaderTextEnabledCheckBox.Checked = HeaderProperty.ColumnTextIsEnabled;
				ColumnHeaderFont = HeaderProperty.ColumnTextFont.Clone() as Font;
				columnHeaderFontColorButton.Color = HeaderProperty.ColumnTextBrush.Color;
				columnHeaderTextAlignmentEnumComboBox.SelectedEnumValue = HeaderProperty.ColumnTextFormat.Alignment;
				columnHeaderTextLineAlignmentEnumComboBox.SelectedEnumValue = HeaderProperty.ColumnTextFormat.LineAlignment;
				columnHeaderTickNumberBox.Value = HeaderProperty.ColumnTextTick;
				//行ヘッダー
				rowHeaderEnabledCheckBox.Checked = HeaderProperty.RowIsEnabled;
				rowHeaderWidthCheckBox.Checked = false;
				rowHeaderWidthNumberBox.Value = HeaderProperty.TrueRowWidth;
				rowHeaderLineEnabledCheckBox.Checked = HeaderProperty.RowLineIsEnabled;
				{
					Pen pen = HeaderProperty.RowLinePen;
					rowHeaderLineStyleComboBox.SelectedDashStyle = pen.DashStyle;
					rowHeaderLineWidthNumberBox.Value = pen.Width;
					rowHeaderLineColorButton.Color = pen.Color;
				}
				rowHeaderGridEnabledCheckBox.Checked = HeaderProperty.RowGridIsEnabled;
				{
					Pen pen = HeaderProperty.RowGridPen;
					rowHeaderGridLineStyleComboBox.SelectedDashStyle = pen.DashStyle;
					rowHeaderGridWidthNumberBox.Value = pen.Width;
					rowHeaderGridColorButton.Color = pen.Color;
				}
				rowHeaderTextEnabledCheckBox.Checked = HeaderProperty.RowTextIsEnabled;
				RowHeaderFont = HeaderProperty.RowTextFont.Clone() as Font;
				rowHeaderFontColorButton.Color = HeaderProperty.RowTextBrush.Color;
				rowHeaderTextAlignmentEnumComboBox.SelectedEnumValue = HeaderProperty.RowTextFormat.Alignment;
				rowHeaderTextLineAlignmentEnumComboBox.SelectedEnumValue = HeaderProperty.RowTextFormat.LineAlignment;
				rowHeaderTickNumberBox.Value = HeaderProperty.RowTextTick;
			}
			//凡例タブ
			{
				//凡例全般
				legendEnabledCheckBox.Checked = LegendProperty.Enabled;
				legendRowHeightNumberBox.Value = LegendProperty.RowHeight;
				legendPaddingTopNumberBox.Value = LegendProperty.Top;
				legendPaddingRightNumberBox.Value = LegendProperty.Right;
				legendPaddingLeftNumberBox.Value = LegendProperty.Left;
				legendBackgroundColorEnabledCheckBox.Checked = LegendProperty.BackgroundColorEnabled;
				legendBackgroundColorButton.Color = LegendProperty.BackgroundColor;
				legendLineEnabledCheckBox.Checked = LegendProperty.LineIsEnabled;
				{
					Pen pen = LegendProperty.LinePen;
					legendLineStyleComboBox.SelectedDashStyle = pen.DashStyle;
					legendLineWidthNumberBox.Value = pen.Width;
					legendLineColorButton.Color = pen.Color;
				}
				legendRowGroupGridEnabledCheckBox.Checked = LegendProperty.RowGroupGridIsEnabled;
				{
					Pen pen = LegendProperty.RowGroupGridPen;
					legendRowGroupGridLineStyleComboBox.SelectedDashStyle = pen.DashStyle;
					legendRowGroupGridWidthNumberBox.Value = pen.Width;
					legendRowGroupGridColorButton.Color = pen.Color;
				}
				legendColumnGridEnabledCheckBox.Checked = LegendProperty.ColumnGridIsEnabled;
				{
					Pen pen = LegendProperty.ColumnGridPen;
					legendColumnGridLineStyleComboBox.SelectedDashStyle = pen.DashStyle;
					legendColumnGridWidthNumberBox.Value = pen.Width;
					legendColumnGridColorButton.Color = pen.Color;
				}
				legendRowGridEnabledCheckBox.Checked = LegendProperty.RowGridIsEnabled;
				{
					Pen pen = LegendProperty.RowGridPen;
					legendRowGridLineStyleComboBox.SelectedDashStyle = pen.DashStyle;
					legendRowGridWidthNumberBox.Value = pen.Width;
					legendRowGridColorButton.Color = pen.Color;
				}
				//記号列
				{
					ColumnProperty property = LegendProperty.SymbolProperty;
					legendSymbolColumnEnabledCheckBox.Checked = property.Enabled;
					legendSymbolColumnWidthNumberBox.Value = property.Width;
					legendSymbolColumnNameTextBox.Text = property.Name;
					LegendSymbolColumnNameFont = property.NameFont.Clone() as Font;
					legendSymbolColumnNameFontColorButton.Color = property.NameBrush.Color;
					legendSymbolColumnNameAlignmentEnumComboBox.SelectedEnumValue = property.NameFormat.Alignment;
					legendSymbolColumnNameLineAlignmentEnumComboBox.SelectedEnumValue = property.NameFormat.LineAlignment;
					LegendSymbolColumnTextFont = property.TextFont.Clone() as Font;
					legendSymbolColumnTextFontColorButton.Color = property.TextBrush.Color;
					legendSymbolColumnTextAlignmentEnumComboBox.SelectedEnumValue = property.TextFormat.Alignment;
					legendSymbolColumnTextLineAlignmentEnumComboBox.SelectedEnumValue = property.TextFormat.LineAlignment;
					legendSymbolScaleNumberBox.Value = LegendProperty.SymbolScale;
				}
				//値列
				{
					ColumnProperty property = LegendProperty.ValueProperty;
					legendValueColumnEnabledCheckBox.Checked = property.Enabled;
					legendValueColumnWidthNumberBox.Value = property.Width;
					legendValueColumnNameTextBox.Text = property.Name;
					LegendValueColumnNameFont = property.NameFont.Clone() as Font;
					legendValueColumnNameFontColorButton.Color = property.NameBrush.Color;
					legendValueColumnNameAlignmentEnumComboBox.SelectedEnumValue = property.NameFormat.Alignment;
					legendValueColumnNameLineAlignmentEnumComboBox.SelectedEnumValue = property.NameFormat.LineAlignment;
					LegendValueColumnTextFont = property.TextFont.Clone() as Font;
					legendValueColumnTextFontColorButton.Color = property.TextBrush.Color;
					legendValueColumnTextAlignmentEnumComboBox.SelectedEnumValue = property.TextFormat.Alignment;
					legendValueColumnTextLineAlignmentEnumComboBox.SelectedEnumValue = property.TextFormat.LineAlignment;
				}
				//個数列
				{
					ColumnProperty property = LegendProperty.CountProperty;
					legendCountColumnEnabledCheckBox.Checked = property.Enabled;
					legendCountColumnWidthNumberBox.Value = property.Width;
					legendCountColumnNameTextBox.Text = property.Name;
					LegendCountColumnNameFont = property.NameFont.Clone() as Font;
					legendCountColumnNameFontColorButton.Color = property.NameBrush.Color;
					legendCountColumnNameAlignmentEnumComboBox.SelectedEnumValue = property.NameFormat.Alignment;
					legendCountColumnNameLineAlignmentEnumComboBox.SelectedEnumValue = property.NameFormat.LineAlignment;
					LegendCountColumnTextFont = property.TextFont.Clone() as Font;
					legendCountColumnTextFontColorButton.Color = property.TextBrush.Color;
					legendCountColumnTextAlignmentEnumComboBox.SelectedEnumValue = property.TextFormat.Alignment;
					legendCountColumnTextLineAlignmentEnumComboBox.SelectedEnumValue = property.TextFormat.LineAlignment;
				}
			}
			//IPAタブ
			{
				uint convertID = LegendProperty.ConvertID;
				if (0 != (convertID & 1)) flag1RadioButton1.Checked = true;
				else flag1RadioButton0.Checked = true;
				if (0 != (convertID & (1 << 1))) flag2RadioButton1.Checked = true;
				else flag2RadioButton0.Checked = true;
				if (0 != (convertID & (1 << 2))) flag3RadioButton1.Checked = true;
				else flag3RadioButton0.Checked = true;
				if (0 != (convertID & (1 << 3))) flag4RadioButton1.Checked = true;
				else flag4RadioButton0.Checked = true;
				if (0 != (convertID & (1 << 4)))
				{
					if (0 != (convertID & (1 << 5))) flag5_6RadioButton3.Checked = true;
					else flag5_6RadioButton1.Checked = true;
				}
				else
				{
					if (0 != (convertID & (1 << 5))) flag5_6RadioButton2.Checked = true;
					else flag5_6RadioButton0.Checked = true;
				}
				if (0 != (convertID & (1 << 6))) flag7RadioButton1.Checked = true;
				else flag7RadioButton0.Checked = true;
				if (0 != (convertID & (1 << 7))) flag8RadioButton1.Checked = true;
				else flag8RadioButton0.Checked = true;
				if (0 != (convertID & (1 << 8))) flag9RadioButton1.Checked = true;
				else flag9RadioButton0.Checked = true;
				if (0 != (convertID & (1 << 9))) flag10RadioButton1.Checked = true;
				else flag10RadioButton0.Checked = true;
				if (0 != (convertID & (1 << 10))) flag11RadioButton1.Checked = true;
				else flag11RadioButton0.Checked = true;
				if (0 != (convertID & (1 << 11))) flag12RadioButton1.Checked = true;
				else flag12RadioButton0.Checked = true;
				if (0 != (convertID & (1 << 12))) flag13RadioButton1.Checked = true;
				else flag13RadioButton0.Checked = true;
				if (0 != (convertID & (1 << 13))) flag14RadioButton1.Checked = true;
				else flag14RadioButton0.Checked = true;
				if (0 != (convertID & (1 << 14))) flag15RadioButton1.Checked = true;
				else flag15RadioButton0.Checked = true;
				if (0 != (convertID & (1 << 15))) flag16RadioButton1.Checked = true;
				else flag16RadioButton0.Checked = true;
				if (0 != (convertID & (1 << 16))) flag17RadioButton1.Checked = true;
				else flag17RadioButton0.Checked = true;
				if (0 != (convertID & (1 << 17))) flag18RadioButton1.Checked = true;
				else flag18RadioButton0.Checked = true;
				if (0 != (convertID & (1 << 18))) flag19RadioButton1.Checked = true;
				else flag19RadioButton0.Checked = true;
				if (0 != (convertID & (1 << 19))) flag20RadioButton1.Checked = true;
				else flag20RadioButton0.Checked = true;
				if (0 != (convertID & (1 << 20))) flag21RadioButton1.Checked = true;
				else flag21RadioButton0.Checked = true;
				if (0 != (convertID & (1 << 21))) flag22RadioButton1.Checked = true;
				else flag22RadioButton0.Checked = true;
				if (0 != (convertID & (1 << 22))) flag23RadioButton1.Checked = true;
				else flag23RadioButton0.Checked = true;
				if (0 != (convertID & (1 << 23))) flag24RadioButton1.Checked = true;
				else flag24RadioButton0.Checked = true;
				if (0 != (convertID & (1 << 24))) flag25RadioButton1.Checked = true;
				else flag25RadioButton0.Checked = true;
				if (0 != (convertID & (1 << 25))) flag26RadioButton1.Checked = true;
				else flag26RadioButton0.Checked = true;
				if (0 != (convertID & (1 << 26))) flag27RadioButton1.Checked = true;
				else flag27RadioButton0.Checked = true;
				if (0 != (convertID & (1 << 27))) flag28RadioButton1.Checked = true;
				else flag28RadioButton0.Checked = true;
				if (0 != (convertID & (1 << 28))) flag29RadioButton1.Checked = true;
				else flag29RadioButton0.Checked = true;
				if (0 != (convertID & (1 << 29))) flag30RadioButton1.Checked = true;
				else flag30RadioButton0.Checked = true;
				if (0 != (convertID & (1 << 30))) flag31RadioButton1.Checked = true;
				else flag31RadioButton0.Checked = true;
				if (0 != (convertID & (1 << 31))) flag32RadioButton1.Checked = true;
				else flag32RadioButton0.Checked = true;
				uint formatID = LegendProperty.FormatID;
				if (0 != (formatID & 1))
				{
					if (0 != (formatID & (1 << 1))) format1_2RadioButton0.Checked = true;
					else format1_2RadioButton1.Checked = true;
				}
				else
				{
					if (0 != (formatID & (1 << 1))) format1_2RadioButton2.Checked = true;
					else format1_2RadioButton0.Checked = true;
				}
				if (0 != (formatID & (1 << 2))) format3RadioButton1.Checked = true;
				else format3RadioButton0.Checked = true;
				if (0 != (formatID & (1 << 3))) format4RadioButton1.Checked = true;
				else format4RadioButton0.Checked = true;
				if (0 != (formatID & (1 << 4))) format5RadioButton1.Checked = true;
				else format5RadioButton0.Checked = true;
				if (0 != (formatID & (1 << 5))) format6RadioButton1.Checked = true;
				else format6RadioButton0.Checked = true;
				if (0 != (formatID & (1 << 6))) format7RadioButton1.Checked = true;
				else format7RadioButton0.Checked = true;
				if (0 != (formatID & (1 << 7))) format8RadioButton1.Checked = true;
				else format8RadioButton0.Checked = true;
				if (0 != (formatID & (1 << 8))) format9RadioButton1.Checked = true;
				else format9RadioButton0.Checked = true;
				if (0 != (formatID & (1 << 9))) format10RadioButton1.Checked = true;
				else format10RadioButton0.Checked = true;
				if (0 != (formatID & (1 << 10))) format11RadioButton1.Checked = true;
				else format11RadioButton0.Checked = true;
				if (0 != (formatID & (1 << 11))) format12RadioButton1.Checked = true;
				else format12RadioButton0.Checked = true;
				if (0 != (formatID & (1 << 12))) format13RadioButton1.Checked = true;
				else format13RadioButton0.Checked = true;
				if (0 != (formatID & (1 << 13))) format14RadioButton1.Checked = true;
				else format14RadioButton0.Checked = true;
				if (0 != (formatID & (1 << 14))) format15RadioButton1.Checked = true;
				else format15RadioButton0.Checked = true;
				if (0 != (formatID & (1 << 15))) format16RadioButton1.Checked = true;
				else format16RadioButton0.Checked = true;
			}
		}

		/// <summary>
		/// 値を保存し、ダイアログウィンドウを閉じる
		/// </summary>
		private void DialogOK_Click(object sender, EventArgs e)
		{
			//本体タブ
			{
				GlottogramProperty.Width = glottogramWidthNumberBox.GetValue(GlottogramProperty.Width);
				GlottogramProperty.Height = glottogramHeightNumberBox.GetValue(GlottogramProperty.Height);
				GlottogramProperty.Padding = new(
					glottogramPaddingLeftNumberBox.GetValue(0),
					glottogramPaddingTopNumberBox.GetValue(0),
					glottogramPaddingRightNumberBox.GetValue(0),
					glottogramPaddingBottomNumberBox.GetValue(0)
					);
				GlottogramProperty.BackColor = backColorButton.Color;
				GlottogramProperty.BackgroundImageEnabled = glottogramBackgroundImageEnabledCheckBox.Checked;
				GlottogramProperty.BackgroundImageMode = glottogramBackgroundImageModeEnumComboBox.GetSelectedEnumValue(BackgroundImageMode.Normal);
				GlottogramProperty.BackgroundImage = glottogramBackgroundImage;
				GlottogramProperty.SymbolScale = symbolScaleNumberBox.GetValue<float>(1.0f);
				GlottogramProperty.LineEnabled = glottogramLineEnabledCheckBox.Checked;
				GlottogramProperty.LinePen = InitializeHelper.CreatePen(
					glottogramLineColorButton.Color,
					glottogramLineWidthNumberBox.GetValue<float>(1.0f),
					glottogramLineStyleComboBox.SelectedDashStyle
					);
				GlottogramProperty.ColumnGridEnabled = glottogramColumnGridEnabledCheckBox.Checked;
				GlottogramProperty.ColumnGridPen = InitializeHelper.CreatePen(
					glottogramColumnGridColorButton.Color,
					glottogramColumnGridWidthNumberBox.GetValue<float>(1.0f),
					glottogramColumnGridLineStyleComboBox.SelectedDashStyle
					);
				GlottogramProperty.RowGridEnabled = glottogramRowGridEnabledCheckBox.Checked;
				GlottogramProperty.RowGridPen = InitializeHelper.CreatePen(
					glottogramRowGridColorButton.Color,
					glottogramRowGridWidthNumberBox.GetValue<float>(1.0f),
					glottogramRowGridLineStyleComboBox.SelectedDashStyle
					);
				GlottogramProperty.MultipleSymbolEnabled = glottogramMultipleSymbolEnabledCheckBox.Checked;
				if (glottogramMultipleSymbol is null) GlottogramProperty.MultipleSymbol = null;
				else
				{
					if (GlottogramProperty.MultipleSymbol is null) GlottogramProperty.MultipleSymbol = new();
					Symbol symbol = GlottogramProperty.MultipleSymbol;
					symbol.HasScale = true;
					symbol.Scale = GlottogramProperty.SymbolScale;
					symbol.Data = glottogramMultipleSymbol;
				}
				GlottogramProperty.MultipleSymbolRelatedY = glottogramMultipleSymbolRelatedYNumberBox.GetValue<float>(GlottogramProperty.MultipleSymbolRelatedY);
			}
			//ヘッダータブ
			{
				//左上
				HeaderProperty.TopLeftTextIsEnabled = headerTextEnabledCheckBox.Checked;
				HeaderProperty.TopLeftText = headerTextBox.Text;
				HeaderProperty.TopLeftTextFont = headerTopLeftTextFont.Clone() as Font;
				HeaderProperty.TopLeftTextBrushColor = headerTextFontColorButton.Color;
				HeaderProperty.TopLeftTextFormat = InitializeHelper.CreateStringFormat(
					headerTextAlignmentEnumComboBox.GetSelectedEnumValue(StringAlignment.Near),
					headerTextLineAlignmentEnumComboBox.GetSelectedEnumValue(StringAlignment.Near)
					);
				//列ヘッダー
				HeaderProperty.ColumnIsEnabled = columnHeaderEnabledCheckBox.Checked;
				HeaderProperty.ColumnHeight = columnHeaderHeightNumberBox.GetValue<int>(HeaderProperty.ColumnHeight);
				HeaderProperty.ColumnLineIsEnabled = columnHeaderLineEnabledCheckBox.Checked;
				HeaderProperty.ColumnLinePen = InitializeHelper.CreatePen(columnHeaderLineColorButton.Color, columnHeaderLineWidthNumberBox.GetValue<float>(1), columnHeaderLineStyleComboBox.SelectedDashStyle);
				HeaderProperty.ColumnGridIsEnabled = columnHeaderGridEnabledCheckBox.Checked;
				HeaderProperty.ColumnGridPen = InitializeHelper.CreatePen(columnHeaderGridColorButton.Color, columnHeaderGridWidthNumberBox.GetValue<float>(1), columnHeaderGridLineStyleComboBox.SelectedDashStyle);
				HeaderProperty.ColumnTextIsEnabled = columnHeaderTextEnabledCheckBox.Checked;
				HeaderProperty.ColumnTextFont = columnHeaderFont.Clone() as Font;
				HeaderProperty.ColumnTextBrushColor = columnHeaderFontColorButton.Color;
				HeaderProperty.ColumnTextFormat = InitializeHelper.CreateStringFormat(
					columnHeaderTextAlignmentEnumComboBox.GetSelectedEnumValue(StringAlignment.Near),
					columnHeaderTextLineAlignmentEnumComboBox.GetSelectedEnumValue(StringAlignment.Near)
					);
				HeaderProperty.ColumnTextTick = columnHeaderTickNumberBox.GetValue<int>(1);
				//行ヘッダー
				HeaderProperty.RowIsEnabled = rowHeaderEnabledCheckBox.Checked;
				HeaderProperty.RowWidth = (int)rowHeaderWidthNumberBox.GetValue<float>(HeaderProperty.RowWidth);
				HeaderProperty.RowLineIsEnabled = rowHeaderLineEnabledCheckBox.Checked;
				HeaderProperty.RowLinePen = InitializeHelper.CreatePen(rowHeaderLineColorButton.Color, rowHeaderLineWidthNumberBox.GetValue<float>(1), rowHeaderLineStyleComboBox.SelectedDashStyle);
				HeaderProperty.RowGridIsEnabled = rowHeaderGridEnabledCheckBox.Checked;
				HeaderProperty.RowGridPen = InitializeHelper.CreatePen(rowHeaderGridColorButton.Color, rowHeaderGridWidthNumberBox.GetValue<float>(1), rowHeaderGridLineStyleComboBox.SelectedDashStyle);
				HeaderProperty.RowTextIsEnabled = rowHeaderTextEnabledCheckBox.Checked;
				HeaderProperty.RowTextFont = rowHeaderFont.Clone() as Font;
				HeaderProperty.RowTextBrushColor = rowHeaderFontColorButton.Color;
				HeaderProperty.RowTextFormat = InitializeHelper.CreateStringFormat(
					rowHeaderTextAlignmentEnumComboBox.GetSelectedEnumValue(StringAlignment.Near),
					rowHeaderTextLineAlignmentEnumComboBox.GetSelectedEnumValue(StringAlignment.Near)
					);
				HeaderProperty.RowTextTick = rowHeaderTickNumberBox.GetValue<int>(1);
			}
			//凡例タブ
			{
				LegendProperty.Enabled = legendEnabledCheckBox.Checked;
				LegendProperty.RowHeight = legendRowHeightNumberBox.GetValue<float>(LegendProperty.RowHeight);
				LegendProperty.Padding = new(
					legendPaddingLeftNumberBox.GetValue<int>(0),
					legendPaddingTopNumberBox.GetValue<int>(0),
					legendPaddingRightNumberBox.GetValue<int>(0),
					0
					);
				LegendProperty.BackgroundColorEnabled = legendBackgroundColorEnabledCheckBox.Checked;
				LegendProperty.BackgroundColor = legendBackgroundColorButton.Color;
				LegendProperty.LineIsEnabled = legendLineEnabledCheckBox.Checked;
				LegendProperty.LinePen = InitializeHelper.CreatePen(legendLineColorButton.Color, legendLineWidthNumberBox.GetValue<float>(1), legendLineStyleComboBox.SelectedDashStyle); ;
				LegendProperty.RowGroupGridIsEnabled = legendRowGroupGridEnabledCheckBox.Checked;
				LegendProperty.RowGroupGridPen = InitializeHelper.CreatePen(legendRowGroupGridColorButton.Color, legendRowGroupGridWidthNumberBox.GetValue<float>(1), legendRowGroupGridLineStyleComboBox.SelectedDashStyle);
				LegendProperty.ColumnGridIsEnabled = legendColumnGridEnabledCheckBox.Checked;
				LegendProperty.ColumnGridPen = InitializeHelper.CreatePen(legendColumnGridColorButton.Color, legendColumnGridWidthNumberBox.GetValue<float>(1), legendColumnGridLineStyleComboBox.SelectedDashStyle);
				LegendProperty.RowGridIsEnabled = legendRowGridEnabledCheckBox.Checked;
				LegendProperty.RowGridPen = InitializeHelper.CreatePen(legendRowGridColorButton.Color, legendRowGridWidthNumberBox.GetValue<float>(1), legendRowGridLineStyleComboBox.SelectedDashStyle);
				//記号列
				{
					ColumnProperty property = LegendProperty.SymbolProperty;
					property.Enabled = legendSymbolColumnEnabledCheckBox.Checked;
					property.Width = legendSymbolColumnWidthNumberBox.GetValue<int>(1);
					property.Name = legendSymbolColumnNameTextBox.Text;
					property.NameFont = legendSymbolColumnNameFont.Clone() as Font;
					property.NameColor = legendSymbolColumnTextFontColorButton.Color;
					property.NameFormat = InitializeHelper.CreateStringFormat(
						legendSymbolColumnNameAlignmentEnumComboBox.GetSelectedEnumValue(StringAlignment.Near),
						legendSymbolColumnNameLineAlignmentEnumComboBox.GetSelectedEnumValue(StringAlignment.Near)
						);
					property.TextFont = legendSymbolColumnTextFont.Clone() as Font;
					property.TextColor = legendSymbolColumnTextFontColorButton.Color;
					property.TextFormat = InitializeHelper.CreateStringFormat(
						legendSymbolColumnTextAlignmentEnumComboBox.GetSelectedEnumValue(StringAlignment.Near),
						legendSymbolColumnTextLineAlignmentEnumComboBox.GetSelectedEnumValue(StringAlignment.Near)
						);
					LegendProperty.SymbolScale = legendSymbolScaleNumberBox.GetValue<float>(1);
				}
				//値列
				{
					ColumnProperty property = LegendProperty.ValueProperty;
					property.Enabled = legendValueColumnEnabledCheckBox.Checked;
					property.Width = legendValueColumnWidthNumberBox.GetValue<int>(1);
					property.Name = legendValueColumnNameTextBox.Text;
					property.NameFont = legendValueColumnNameFont.Clone() as Font;
					property.NameColor = legendValueColumnTextFontColorButton.Color;
					property.NameFormat = InitializeHelper.CreateStringFormat(
						legendValueColumnNameAlignmentEnumComboBox.GetSelectedEnumValue(StringAlignment.Near),
						legendValueColumnNameLineAlignmentEnumComboBox.GetSelectedEnumValue(StringAlignment.Near)
						);
					property.TextFont = legendValueColumnTextFont.Clone() as Font;
					property.TextColor = legendValueColumnTextFontColorButton.Color;
					property.TextFormat = InitializeHelper.CreateStringFormat(
						legendValueColumnTextAlignmentEnumComboBox.GetSelectedEnumValue(StringAlignment.Near),
						legendValueColumnTextLineAlignmentEnumComboBox.GetSelectedEnumValue(StringAlignment.Near)
						);
				}
				//個数列
				{
					ColumnProperty property = LegendProperty.CountProperty;
					property.Enabled = legendCountColumnEnabledCheckBox.Checked;
					property.Width = legendCountColumnWidthNumberBox.GetValue<int>(1);
					property.Name = legendCountColumnNameTextBox.Text;
					property.NameFont = legendCountColumnNameFont.Clone() as Font;
					property.NameColor = legendCountColumnTextFontColorButton.Color;
					property.NameFormat = InitializeHelper.CreateStringFormat(
						legendCountColumnNameAlignmentEnumComboBox.GetSelectedEnumValue(StringAlignment.Near),
						legendCountColumnNameLineAlignmentEnumComboBox.GetSelectedEnumValue(StringAlignment.Near)
						);
					property.TextFont = legendCountColumnTextFont.Clone() as Font;
					property.TextColor = legendCountColumnTextFontColorButton.Color;
					property.TextFormat = InitializeHelper.CreateStringFormat(
						legendCountColumnTextAlignmentEnumComboBox.GetSelectedEnumValue(StringAlignment.Near),
						legendCountColumnTextLineAlignmentEnumComboBox.GetSelectedEnumValue(StringAlignment.Near)
						);
				}
			}
			//IPAタブ
			{
				uint convertID = 0;
				if (flag1RadioButton1.Checked) convertID += 1u;
				if (flag2RadioButton1.Checked) convertID += (1u << 1);
				if (flag3RadioButton1.Checked) convertID += (1u << 2);
				if (flag4RadioButton1.Checked) convertID += (1u << 3);
				if (flag5_6RadioButton1.Checked) convertID += (1u << 4);
				else if (flag5_6RadioButton2.Checked) convertID += (1u << 5);
				else if (flag5_6RadioButton3.Checked) convertID += (3u << 4);
				if (flag7RadioButton1.Checked) convertID += (1u << 6);
				if (flag8RadioButton1.Checked) convertID += (1u << 7);
				if (flag9RadioButton1.Checked) convertID += (1u << 8);
				if (flag10RadioButton1.Checked) convertID += (1u << 9);
				if (flag11RadioButton1.Checked) convertID += (1u << 10);
				if (flag12RadioButton1.Checked) convertID += (1u << 11);
				if (flag13RadioButton1.Checked) convertID += (1u << 12);
				if (flag14RadioButton1.Checked) convertID += (1u << 13);
				if (flag15RadioButton1.Checked) convertID += (1u << 14);
				if (flag16RadioButton1.Checked) convertID += (1u << 15);
				if (flag17RadioButton1.Checked) convertID += (1u << 16);
				if (flag18RadioButton1.Checked) convertID += (1u << 17);
				if (flag19RadioButton1.Checked) convertID += (1u << 18);
				if (flag20RadioButton1.Checked) convertID += (1u << 19);
				if (flag21RadioButton1.Checked) convertID += (1u << 20);
				if (flag22RadioButton1.Checked) convertID += (1u << 21);
				if (flag23RadioButton1.Checked) convertID += (1u << 22);
				if (flag24RadioButton1.Checked) convertID += (1u << 23);
				if (flag25RadioButton1.Checked) convertID += (1u << 24);
				if (flag26RadioButton1.Checked) convertID += (1u << 25);
				if (flag27RadioButton1.Checked) convertID += (1u << 26);
				if (flag28RadioButton1.Checked) convertID += (1u << 27);
				if (flag29RadioButton1.Checked) convertID += (1u << 28);
				if (flag30RadioButton1.Checked) convertID += (1u << 29);
				if (flag31RadioButton1.Checked) convertID += (1u << 30);
				if (flag32RadioButton1.Checked) convertID += (1u << 31);
				LegendProperty.ConvertID = convertID;
				uint formatID = 0;
				if (format1_2RadioButton1.Checked) formatID += 1u;
				else if (format1_2RadioButton2.Checked) formatID += (1u << 1);
				if (format3RadioButton1.Checked) formatID += (1u << 2);
				if (format4RadioButton1.Checked) formatID += (1u << 3);
				if (format5RadioButton1.Checked) formatID += (1u << 4);
				if (format6RadioButton1.Checked) formatID += (1u << 5);
				if (format7RadioButton1.Checked) formatID += (1u << 6);
				if (format8RadioButton1.Checked) formatID += (1u << 7);
				if (format9RadioButton1.Checked) formatID += (1u << 8);
				if (format10RadioButton1.Checked) formatID += (1u << 9);
				if (format11RadioButton1.Checked) formatID += (1u << 10);
				if (format12RadioButton1.Checked) formatID += (1u << 11);
				if (format13RadioButton1.Checked) formatID += (1u << 12);
				if (format14RadioButton1.Checked) formatID += (1u << 13);
				if (format15RadioButton1.Checked) formatID += (1u << 14);
				if (format16RadioButton1.Checked) formatID += (1u << 15);
				LegendProperty.FormatID = formatID;
			}
			DialogResult = DialogResult.OK;
			Close();
		}

		/// <summary>
		/// セルの大きさ設定を本体サイズに反映する
		/// </summary>
		private void CellSize_Leave(object sender, EventArgs e)
		{
			if (sender is not NumberBox numberBox || !numberBox.Enabled) return;
			if (numberBox == glottogramCellWidthNumberBox || numberBox == glottogramCellHeightNumberBox)
			{
				float f = numberBox.GetValue<float>(1);
				if (numberBox == glottogramCellWidthNumberBox) glottogramWidthNumberBox.Value = ((int)MathF.Round(f * GlottogramData.ColumnCount, MidpointRounding.ToPositiveInfinity));
				else if (numberBox == glottogramCellHeightNumberBox) glottogramHeightNumberBox.Value = ((int)MathF.Round(f * GlottogramData.RowCount, MidpointRounding.ToPositiveInfinity));
			}
			else if (numberBox == glottogramWidthNumberBox || numberBox == glottogramHeightNumberBox)
			{
				int i = numberBox.GetValue<int>(100);
				if (numberBox == glottogramWidthNumberBox) glottogramCellWidthNumberBox.Value = ((float)i / GlottogramData.ColumnCount);
				else if (numberBox == glottogramHeightNumberBox) glottogramCellHeightNumberBox.Value = ((float)i / GlottogramData.RowCount);
			}
		}

		/// <summary>
		/// 設定コントールの有効/無効を切り替える
		/// </summary>
		private void CheckBox_CheckedChange(object sender, EventArgs e)
		{
			if (sender is not CheckBox checkBox) return;
			bool enabled = checkBox.Checked;
			if (checkBox == glottogramCellSizeCheckBox)
			{
				glottogramCellWidthNumberBox.Enabled = enabled;
				glottogramCellHeightNumberBox.Enabled = enabled;
			}
			else if (checkBox == columnHeaderHeightCheckBox)
			{	
				columnHeaderHeightNumberBox.Enabled = !enabled;
				if (enabled) columnHeaderHeightNumberBox.Value = GlottogramProperty.RowHeight;
			}
			else if (checkBox == rowHeaderWidthCheckBox)
			{
				rowHeaderWidthNumberBox.Enabled = !enabled;
				if (enabled) rowHeaderWidthNumberBox.Value = GlottogramProperty.ColumnWidth;
			}
			else if (checkBox == legendUseGlottogramRowHeightCheckBox)
			{
				legendRowHeightNumberBox.Enabled = !enabled;
				if (enabled) legendRowHeightNumberBox.Value = GlottogramProperty.RowHeight;
			}
		}

		/// <summary>
		/// [内部関数]フォント選択ウィンドウを開く
		/// </summary>
		/// <param name="colorButton">フォントの色を表示するColorButton</param>
		/// <param name="font">フォント選択ウィンドウに表示するデフォルトフォント</param>
		/// <returns>選択されたフォント</returns>
		static Font FontButton_Click_Internal(ColorButton colorButton, Font font)
		{
			if (FontDialogEx.ShowDialog(colorButton.Color, font) == DialogResult.OK)
			{
				colorButton.Color = FontDialogEx.StaticColor;
				return FontDialogEx.StaticFont.Clone() as Font;
			}
			else return font.Clone() as Font;
		}

		/// <summary>
		/// 文字列描画用フォントを選択する
		/// </summary>
		private void FontButton_Click(object sender, EventArgs e)
		{
			if (sender is not Button button) return;
			if (button == headerTextFontButton) HeaderTopLeftTextFont = FontButton_Click_Internal(headerTextFontColorButton, headerTopLeftTextFont);
			else if (button == columnHeaderFontButton) ColumnHeaderFont = FontButton_Click_Internal(columnHeaderFontColorButton, columnHeaderFont);
			else if (button == rowHeaderFontButton) RowHeaderFont = FontButton_Click_Internal(rowHeaderFontColorButton, rowHeaderFont);
			else if (button == legendSymbolColumnNameFontButton) LegendSymbolColumnNameFont = FontButton_Click_Internal(legendSymbolColumnNameFontColorButton, legendSymbolColumnNameFont);
			else if (button == legendSymbolColumnTextFontButton) LegendSymbolColumnTextFont = FontButton_Click_Internal(legendSymbolColumnTextFontColorButton, legendSymbolColumnTextFont);
			else if (button == legendValueColumnNameFontButton) LegendValueColumnNameFont = FontButton_Click_Internal(legendValueColumnNameFontColorButton, legendValueColumnNameFont);
			else if (button == legendValueColumnTextFontButton) LegendValueColumnTextFont = FontButton_Click_Internal(legendValueColumnTextFontColorButton, legendValueColumnTextFont);
			else if (button == legendCountColumnNameFontButton) LegendCountColumnNameFont = FontButton_Click_Internal(legendCountColumnNameFontColorButton, legendCountColumnNameFont);
			else if (button == legendCountColumnTextFontButton) LegendCountColumnTextFont = FontButton_Click_Internal(legendCountColumnTextFontColorButton, legendCountColumnTextFont);
		}

		/// <summary>
		/// 背景画像を選択する
		/// </summary>
		private void ImageButton_Click(object sender, EventArgs e)
		{
			if (sender is not Button button) return;
			if (button == glottogramBackgroundImageResetButton) GlottogramBackgroundImage = null;
			else if (button == glottogramBackgroundImageSelectButton)
			{
				using OpenFileDialog ofd = new();
				ofd.FileName = ".bmp";
				ofd.Filter = "ビットマップファイル|*.bmp|JPG|*.jpg;*.jpeg|PNG|*.png";
				ofd.FilterIndex = 1;
				ofd.Title = "ファイルを選択してください";
				ofd.RestoreDirectory = true;
				if (ofd.ShowDialog() == DialogResult.OK)
				{
					Bitmap bitmap = null;
					try
					{
						bitmap = new Bitmap(Image.FromFile(ofd.FileName));
					}
					catch (Exception ex)
					{
						MessageForm.Show("画像データの読み込み中に以下の例外が発生しました。\n" + ex.Message, "例外エラー");
						return;
					}
					GlottogramBackgroundImage = bitmap;
				}
			}
		}

		/// <summary>
		/// 複数回答用記号を選択する
		/// </summary>
		private void SymbolPictureBox_Click(object sender, EventArgs e)
		{
			SvgViewer.GetSingleton().SetViewing(glottogramMultipleSymbol);
			SvgViewer.OpenOrShowDialog(this);
			if (SvgViewer.StaticDialogResult == DialogResult.OK)
			{
				SvgWrapper.SvgData data = SvgViewer.StaticDialogReturn as SvgWrapper.SvgData;
				GlottogramMultipleSymbol = data;
			}
		}
	}
	public class PropertyToolWindow_Internal : SingletonForm<PropertyToolWindow> { }

	static partial class ToEnumName
	{
		public static string ToEnumNameEx(StringAlignment value, int mode)
		{
			return value switch
			{
				StringAlignment.Near => mode == 0 ? "左揃え" : "上揃え",
				StringAlignment.Center => "中央揃え",
				StringAlignment.Far => mode == 0 ? "右揃え" : "下揃え",
				_ => ""
			};
		}
	}
}
