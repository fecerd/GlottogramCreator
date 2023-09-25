using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace WinFormsApp1
{
	/// <summary>
	/// コントロール用拡張メソッド
	/// </summary>
	static class ControlExtend
	{
		/// <summary>
		/// ComboBoxの初期化を行う
		/// </summary>
		/// <param name="comboBox">対象のComboBox</param>
		/// <param name="items">追加するアイテム</param>
		/// <param name="selectedIndex">初期選択インデックス。デフォルトは0、無効な値が設定された場合、-1</param>
		public static void InitEx(this ComboBox comboBox, string[] items, int selectedIndex = 0)
		{
			comboBox.Items.Clear();
			comboBox.Items.AddRange(items);
			comboBox.SelectedIndex = comboBox.Items.Count > selectedIndex ? selectedIndex : -1;
		}

		/// <summary>
		/// ComboBoxの初期化を行う
		/// </summary>
		/// <param name="comboBox">対象のComboBox</param>
		/// <param name="items">追加するアイテム</param>
		/// <param name="selectedIndex">初期選択アイテム</param>
		public static void InitEx(this ComboBox comboBox, string[] items, string selectedItem)
		{
			comboBox.Items.Clear();
			comboBox.Items.AddRange(items);
			comboBox.SelectedItem = selectedItem;
		}

		/// <summary>
		/// ToolStripMenuItemが所属するContextMenuStripExのTagプロパティをControl型で取得する
		/// </summary>
		/// <param name="menuItem"></param>
		/// <returns>ToolStripが呼び出されたコントロール。存在しない場合、null</returns>
		public static Control GetSourceControlEx(this ToolStripMenuItem menuItem)
		{
			ToolStripItem tmp = menuItem;
			while (tmp.OwnerItem is not null) tmp = tmp.OwnerItem;
			if (tmp.Owner is ContextMenuStripEx contextMenuStrip) return contextMenuStrip.SourceControlEx;
			else return null;
		}

		/// <summary>
		/// DataGridViewのセルに数値が入っている場合、セルのスタイルを右揃えにする
		/// </summary>
		/// <param name="e">DataGridViewのCellFormattingイベントが受け取る引数</param>
		public static void FormatNumberEx(this DataGridViewCellFormattingEventArgs e)
		{
			if (e.Value == null) return;
			if (int.TryParse(e.Value.ToString(), System.Globalization.NumberStyles.Integer | System.Globalization.NumberStyles.AllowThousands, System.Globalization.CultureInfo.CurrentCulture, out _)
				|| double.TryParse(e.Value.ToString(), System.Globalization.NumberStyles.Float | System.Globalization.NumberStyles.AllowThousands, System.Globalization.CultureInfo.CurrentCulture, out _))
			{
				e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			}
		}

		/// <summary>
		/// 数値が入っている場合、スタイルを右揃えにする
		/// </summary>
		/// <param name="cell">DataGridViewのセル</param>
		public static void FormatNumberEx(this DataGridViewCell cell)
		{
			if (cell.Value == null) return;
			if (int.TryParse(cell.Value.ToString(), System.Globalization.NumberStyles.Integer | System.Globalization.NumberStyles.AllowThousands, System.Globalization.CultureInfo.CurrentCulture, out _)
				|| double.TryParse(cell.Value.ToString(), System.Globalization.NumberStyles.Float | System.Globalization.NumberStyles.AllowThousands, System.Globalization.CultureInfo.CurrentCulture, out _))
			{
				cell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
			}
		}

		/// <summary>
		/// ファイルドロップを受け入れる
		/// </summary>
		/// <param name="e"></param>
		public static void DragFileEnterEx(this DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.All;
			else e.Effect = DragDropEffects.None;
		}

		/// <summary>
		/// 画像列を追加する
		/// </summary>
		/// <param name="dataGridView">対象のDataGridView</param>
		/// <param name="index">追加先の列インデックス</param>
		/// <param name="name">列名</param>
		/// <param name="layout">セルのレイアウト</param>
		/// <param name="description">列の説明</param>
		/// <param name="defaultImage">画像が設定されていないときに表示するデフォルト画像</param>
		public static void AddImageColumn(this DataGridView dataGridView, int index, string name, DataGridViewImageCellLayout layout, DataGridViewCellStyle cellStyle, string description, System.Drawing.Image defaultImage)
		{
			object dataSource = dataGridView.DataSource;
			dataGridView.DataSource = null;
			if (!dataGridView.Columns.Contains(name))
			{
				DataGridViewImageColumn imageColumn = new();
				imageColumn.Name = name;
				imageColumn.ImageLayout = layout;
				imageColumn.DefaultCellStyle = cellStyle;
				imageColumn.Description = description == null ? string.Empty : description;
				imageColumn.Image = defaultImage;
				dataGridView.Columns.Insert(index, imageColumn);
			}
			dataGridView.DataSource = dataSource;
		}

		enum FileFormat
		{
			TSV,
			CSV
		}

		/// <summary>
		/// [内部関数]SaveAs***Ex()関数の機能をまとめたもの。
		/// </summary>
		/// <param name="fileFormat">TSVとCSVで切り替える</param>
		private static void SaveFile_Internal(this DataGridView dataGridView, CodePage codePage, FileFormat fileFormat)
		{
			int columnCount = dataGridView.ColumnCount;
			int rowCount = dataGridView.RowCount;
			if (columnCount == 0 || rowCount == 0)
			{
				MessageForm.Show("保存するレコードが存在しません。\n" + "列数：" + columnCount.ToString() + "\n行数：" + rowCount.ToString());
				return;
			}

			using SaveFileDialog fileDialog = new();
			if (fileFormat == FileFormat.CSV)
			{
				fileDialog.FileName = ".csv";
				fileDialog.Filter = "CSVファイル(*.csv)|*.csv";
			}
			else if (fileFormat == FileFormat.TSV)
			{
				fileDialog.FileName = ".tsv";
				fileDialog.Filter = "TSVファイル(*.tsv)|*.tsv";
			}
			fileDialog.FilterIndex = 1;
			fileDialog.Title = "名前をつけて保存";
			fileDialog.RestoreDirectory = true;
			if (fileDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					
					using FileStream fileStream = new(fileDialog.FileName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
					StreamWriter streamWriter;
					if (codePage == CodePage.UTF16) streamWriter = new(fileStream, Encoding.Unicode);
					else if (codePage == CodePage.UTF8) streamWriter = new(fileStream, Encoding.UTF8);
					else if (codePage == CodePage.Shift_JIS)
					{
						Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
						streamWriter = new(fileStream, Encoding.GetEncoding("Shift-JIS"));
					}
					else return;
					char separator = '\0';
					if (fileFormat == FileFormat.CSV) separator = ',';
					else if (fileFormat == FileFormat.TSV) separator = '\t';
					char[] specialChar = new[] { ',', '\r', '\n' };
					string header = "";
					foreach (DataGridViewColumn column in dataGridView.Columns)
					{
						string tmp = column.HeaderText;
						if (tmp.Contains('"')) tmp = tmp.Replace("\"", "\"\"");
						if (tmp.Contains(',') || tmp.Contains('"') || tmp.Contains('\r') || tmp.Contains('\n')) tmp = '"' + tmp + '"';
						header += tmp + separator;
					}
					header.TrimEnd(separator);
					streamWriter.WriteLine(header);
					for (int r = 0; r < rowCount; ++r)
					{
						string line = "";
						var items = dataGridView.Rows[r].Cells;
						for (int c = 0, count = items.Count; c < count; ++c)
						{
							if (items[c].Value is not string tmp) line += separator;
							else
							{
								if (tmp.Contains('"')) tmp = tmp.Replace("\"", "\"\"");
								if (tmp.Contains(',') || tmp.Contains('"') || tmp.Contains('\r') || tmp.Contains('\n')) tmp = '"' + tmp + '"';
								line += tmp + separator;
							}
						}
						line.TrimEnd(separator);
						streamWriter.WriteLine(line);
					}
					streamWriter.Close();
					streamWriter.Dispose();
				}
				catch (Exception ex)
				{
					MessageForm.Show("ファイル操作中に以下の例外が発生しました。\n" + ex.Message, "例外エラー");
					return;
				}
				string message = string.Empty;
				if (fileFormat == FileFormat.CSV) message = "CSVファイルを保存しました。\n";
				else if (fileFormat == FileFormat.TSV) message = "TSVファイルを保存しました。\n";
				MessageForm.Show(message + "保存先：" + fileDialog.FileName);
			}
		}

		/// <summary>
		/// DataGridViewの内容をTSV形式で保存する。関数内でファイル保存ダイアログが呼ばれる。
		/// </summary>
		/// <param name="dataGridView">保存するDataGridView</param>
		/// <param name="codePage">保存するエンコーディング。デフォルトはShift-JIS</param>
		public static void SaveAsTSVEx(this DataGridView dataGridView, CodePage codePage = CodePage.Shift_JIS)
		{
			dataGridView.SaveFile_Internal(codePage, FileFormat.TSV);
		}

		/// <summary>
		/// DataGridViewの内容をCSV形式で保存する。関数内でファイル保存ダイアログが呼ばれる。
		/// </summary>
		/// <param name="dataGridView">保存するDataGridView</param>
		/// <param name="codePage">保存するエンコーディング。デフォルトはShift-JIS</param>
		public static void SaveAsCSVEx(this DataGridView dataGridView, CodePage codePage = CodePage.Shift_JIS)
		{
			dataGridView.SaveFile_Internal(codePage, FileFormat.CSV);
		}

		public static void SetDataSource(this DataGridView dataGridView, object dataSource)
		{
			DataGridViewSelectionMode mode = dataGridView.SelectionMode;
			dataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
			dataGridView.DataSource = null;
			dataGridView.Columns.Clear();
			dataGridView.DataSource = dataSource;
			dataGridView.SelectionMode = mode;
		}
	}

	public enum CodePage
	{
		UTF16,
		UTF8,
		Shift_JIS
	}
}
