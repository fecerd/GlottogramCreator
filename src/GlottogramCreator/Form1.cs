using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WinFormsApp1
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			Icon = InitializeHelper.CreateIconFromResource(this.GetType(), "Icon.ico", Icon);
			mainDataGridView.DataSourceChanged += (object sender, EventArgs e) => {
				if (sender is DataGridView d && d.DataSource is not null)
				{
					filterKeyComboBox.InitEx(MainData.GetKeys(), filterKeyComboBox.SelectedIndex);
					filterValueTextBox.Text = null;
					filterTypeEnumComboBox.SelectedIndex = -1;
					selectedFilterListBox.Items.Clear();
					selectedFilterListBox.Items.AddRange(MainData.GetFilters());
					selectedFilterListBox.ContextMenuStrip = selectedFilterListBox.Items.Count > 0 ? selectedFilterContextMenuStrip : null;
				}
			};
			mainDataGridView.CellClick += (object sender, DataGridViewCellEventArgs e) =>
			{
				if (e.ColumnIndex != 0 || e.RowIndex < 0) return;
				if (sender is not DataGridView dataGridView) return;
				var cell = dataGridView[e.ColumnIndex, e.RowIndex];
				if (cell.Value is not bool b) return;
				MainData.SetView(e.RowIndex, !b, true);
				cell.Value = !b;
			};
			filterAddButton.Click += (object sender, EventArgs e) =>
			{
				if (filterKeyComboBox.SelectedItem is string key && filterTypeEnumComboBox.SelectedEnumValue is FilterType type)
				{
					MainData.AddFilter(key, filterValueTextBox.Text, type);
					selectedFilterListBox.Items.Clear();
					selectedFilterListBox.Items.AddRange(MainData.GetFilters());
					selectedFilterListBox.ContextMenuStrip = selectedFilterListBox.Items.Count > 0 ? selectedFilterContextMenuStrip : null;
					DataGridView_Update();
				}
			};
			selectedFilterDeleteToolStripMenuItem.Click += (object sender, EventArgs e) =>
			{
				if ((sender as ToolStripMenuItem)?.GetSourceControlEx() is not ListBox listBox) return;
				if (listBox.SelectedIndex != -1) MainData.RemoveFilter(listBox.SelectedIndex);
				selectedFilterListBox.Items.Clear();
				selectedFilterListBox.Items.AddRange(MainData.GetFilters());
				selectedFilterListBox.ContextMenuStrip = selectedFilterListBox.Items.Count > 0 ? selectedFilterContextMenuStrip : null;
				DataGridView_Update();
			};
			//プラグインロード
			try
			{
				foreach (string file in System.IO.Directory.GetFiles("PlugIns"))
				{
					if (System.IO.Path.GetExtension(file) is string ex && ex == ".dll")
					{
						foreach (PlugIns.IPlugIn plugIn in PlugIns.IPlugIn.GetInstances(file))
						{
							ToolStripMenuItem menuItem = new();
							var func = plugIn.GetFunction();
							menuItem.Text = plugIn.Text;
							menuItem.Click += (object sender, EventArgs e) =>
							{
								(DataGridView dataGridView, string key) = GetDataGridViewAndSelectColumnHeaderText(sender);
								if (dataGridView is null || key is null) return;
								if (MainData.Invoke(func, key)) DataGridView_Update();
							};
							dataGridViewContextMenuStrip.Items.Add(menuItem);
						}
					}
				}
			}
			catch { }
			//フォント変更
			Key = new(this);
			Symbol = new(this);
			Load += (object sender, EventArgs e) => Config.SetMainFont(this);
		}

		/// <summary>
		/// [内部関数]DataGridViewを更新する必要があるときに呼び出す
		/// </summary>
		private void DataGridView_Update()
		{
			DataGridViewAutoSizeColumnsMode columnMode = mainDataGridView.AutoSizeColumnsMode;
			DataGridViewAutoSizeRowsMode rowMode = mainDataGridView.AutoSizeRowsMode;
			DataGridViewColumnHeadersHeightSizeMode heightSizeMode = mainDataGridView.ColumnHeadersHeightSizeMode;
			DataGridViewSelectionMode selectionMode = mainDataGridView.SelectionMode;
			mainDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
			mainDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
			mainDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			mainDataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
			mainDataGridView.DataSource = null;
			mainDataGridView.Columns.Clear();
			mainDataGridView.DataSource = MainData.GetDataTable(true);
			bool[] views = MainData.GetViews(true);
			DataGridViewCheckBoxColumn column = new();
			column.HeaderText = "表示";
			column.TrueValue = true;
			column.FalseValue = false;
			mainDataGridView.Columns.Insert(0, column);
			for (int i = 0, end = Math.Min(mainDataGridView.Rows.Count, views.Length); i < end; ++i) mainDataGridView.Rows[i].Cells[0].Value = views[i];
			mainDataGridView.SelectionMode = selectionMode;
			mainDataGridView.ColumnHeadersHeightSizeMode = heightSizeMode;
			mainDataGridView.AutoSizeRowsMode = rowMode;
			mainDataGridView.AutoSizeColumnsMode = columnMode;
			Key.Update();
			Symbol.Update();
		}

		/// <summary>
		/// DataGridViewの数値の入ったセルを右揃えにする
		/// </summary>
		private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) => e.FormatNumberEx();

		/// <summary>
		/// ファイルメニューからTSVファイルを読み込む
		/// </summary>
		private void tSVFiletsvToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new();
			ofd.FileName = ".tsv";
			ofd.Filter = "TSVファイル(*.tsv)|*.tsv";
			ofd.FilterIndex = 1;
			ofd.Title = "TSVファイルを選択してください";
			ofd.RestoreDirectory = true;
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				SymbolData.Reset();
				GlottogramData.Reset();
				LegendProperty.Reset();
				HeaderProperty.Reset();
				GlottogramProperty.Reset();
				MainData.LoadTSV(ofd.FileName);
				DataGridView_Update();
			}
		}
		
		/// <summary>
		/// ファイルメニューからCSVファイルを読み込む
		/// </summary>
		private void loadCSV_Event(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new();
			ofd.FileName = ".csv";
			ofd.Filter = "CSVファイル(*.csv)|*.csv";
			ofd.FilterIndex = 1;
			ofd.Title = "CSVファイルを選択してください";
			ofd.RestoreDirectory = true;
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				SymbolData.Reset();
				GlottogramData.Reset();
				LegendProperty.Reset();
				HeaderProperty.Reset();
				GlottogramProperty.Reset();
				MainData.LoadCSV(ofd.FileName);
				DataGridView_Update();
			}
		}

		/// <summary>
		/// ファイルメニューからクリップボードを読み込む
		/// </summary>
		private void loadClipboardToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SymbolData.Reset();
			GlottogramData.Reset();
			LegendProperty.Reset();
			HeaderProperty.Reset();
			GlottogramProperty.Reset();
			try
			{
				MainData.LoadClipBoardText(Clipboard.GetText());
			}
			catch
			{
				MessageForm.Show("エラー：クリップボードの取得に失敗しました。");
				return;
			}
			DataGridView_Update();
		}

		/// <summary>
		/// (ファイルメニュー)すべてのデータをリセットする
		/// </summary>
		private void LoadNew(object sender, EventArgs e)
		{
			if (MessageForm.Show(this, "現在の編集データを保存しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
			{
				using SaveFileDialog fileDialog = new();
				fileDialog.FileName = ".gce";
				fileDialog.Filter = "GlottogramCreator Editデータファイル(*.gce)|*.gce|XMLファイル(*.xml)|*.xml";
				fileDialog.FilterIndex = 1;
				fileDialog.Title = "名前をつけて保存";
				fileDialog.RestoreDirectory = true;
				if (fileDialog.ShowDialog() == DialogResult.OK)
				{
					try
					{
						XDocument xDocument = XDocumentExtend.CreateEx("root");
						XElement root = xDocument.Root;
						root.Add(GlottogramData.Output());
						root.Add(GlottogramProperty.Output());
						root.Add(HeaderProperty.Output());
						root.Add(LegendProperty.Output());
						root.Add(SymbolData.Output());
						root.Add(MainData.Output());
						xDocument.Save(fileDialog.FileName);
					}
					catch (Exception ex)
					{
						MessageForm.Show("保存中に以下の例外が発生しました。\n" + ex.Message, "例外エラー");
						return;
					}
					MessageForm.Show("編集データをファイルに保存しました。\n保存先：" + fileDialog.FileName);
				}
				else return;
			}
			SymbolData.Reset();
			GlottogramData.Reset();
			LegendProperty.Reset();
			HeaderProperty.Reset();
			GlottogramProperty.Reset();
			MainData.Reset();
			DataGridView_Update();
			mainDataGridView.DataSource = null;
			mainDataGridView.Columns.Clear();
		}

		/// <summary>
		/// (ファイルメニュー)編集データを読み込む
		/// </summary>
		private void LoadEditData(object sender, EventArgs e)
		{
			using OpenFileDialog ofd = new();
			ofd.FileName = ".gce";
			ofd.Filter = "GlottogramCreator Editデータファイル(*.gce)|*.gce|XMLファイル(*.xml)|*.xml";
			ofd.FilterIndex = 1;
			ofd.Title = "編集データファイルを選択してください";
			ofd.RestoreDirectory = true;
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				MainData.Load(ofd.FileName);
				GlottogramProperty.Load(ofd.FileName);
				HeaderProperty.Load(ofd.FileName);
				LegendProperty.Load(ofd.FileName);
				GlottogramData.Load(ofd.FileName);
				SymbolData.Load(ofd.FileName);
				DataGridView_Update();
			}
		}

		/// <summary>
		/// (ファイルメニュー)編集データを保存する
		/// </summary>
		private void SaveEditData(object sender, EventArgs e)
		{
			using SaveFileDialog fileDialog = new();
			fileDialog.FileName = ".gce";
			fileDialog.Filter = "GlottogramCreator Editデータファイル(*.gce)|*.gce|XMLファイル(*.xml)|*.xml";
			fileDialog.FilterIndex = 1;
			fileDialog.Title = "名前をつけて保存";
			fileDialog.RestoreDirectory = true;
			if (fileDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					XDocument xDocument = XDocumentExtend.CreateEx("root");
					XElement root = xDocument.Root;
					root.Add(GlottogramData.Output());
					root.Add(GlottogramProperty.Output());
					root.Add(HeaderProperty.Output());
					root.Add(LegendProperty.Output());
					root.Add(SymbolData.Output());
					root.Add(MainData.Output());
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
		/// (ファイルメニュー)MainDataのデータをTSVファイルに保存する
		/// </summary>
		private void SaveTSVFile_Event(object sender, EventArgs e)
		{
			mainDataGridView.SaveAsTSVEx();
		}

		/// <summary>
		/// (ファイルメニュー)MainDataのデータをCSVファイルに保存する
		/// </summary>
		private void SaveCSVFile_Event(object sender, EventArgs e)
		{
			mainDataGridView.SaveAsCSVEx();
		}

		/// <summary>
		/// Glottogramをモードレスで起動する
		/// </summary>
		private void button1_Click(object sender, EventArgs e) => Glottogram.OpenOrShowDialog(this);

		/// <summary>
		/// DataGridViewをソート禁止・列選択可にし、右クリックメニューを設定する
		/// </summary>
		private void DataGridView_DataSourceChanged(object sender, EventArgs e)
		{
			if (sender is not DataGridView dataGridView) return;
			dataGridView.ContextMenuStrip = dataGridView.DataSource is null ? null : dataGridViewContextMenuStrip;
			foreach (DataGridViewColumn c in dataGridView.Columns) c.SortMode = DataGridViewColumnSortMode.NotSortable;
		}

		/// <summary>
		/// 右クリックメニュー用の内部関数
		/// </summary>
		/// <param name="sender">ToolStripMenuItem.Clickイベントの第一引数</param>
		/// <returns>右クリックメニューが呼び出されたDataGridViewと選択されている列のヘッダーテキスト</returns>
		private static (DataGridView dataGridView, string text) GetDataGridViewAndSelectColumnHeaderText(object sender)
		{
			if (sender is not ToolStripMenuItem item || item.GetSourceControlEx() is not Control src) MessageForm.Show("エラー：右クリックメニューが不正に呼び出されました。");
			else if (src is not DataGridView dataGridView) MessageForm.Show("エラー：右クリックメニューがDataGridView以外から呼び出されました。");
			else
			{
				var columns = dataGridView.SelectedColumns;
				if (columns.Count == 0) MessageForm.Show("エラー：列が選択されていません。");
				else if (columns.Count != 1) MessageForm.Show("エラー：複数の列が選択されています。\n一度に操作できるのは一列だけです。");
				else if (columns[0].Index == 0) MessageForm.Show("エラー：この列を対象にすることはできません。");
				else return (dataGridView, columns[0].HeaderText);
			}
			return (null, null);
		}

		/// <summary>
		/// (右クリックメニュー)DataGridViewの選択されている列を区切り文字で分割する
		/// </summary>
		private void splitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			(DataGridView dataGridView, string key) = GetDataGridViewAndSelectColumnHeaderText(sender);
			if (dataGridView is null || key is null) return;
			//区切り文字選択用ウィンドウを表示
			List<char> splitChar = new();
			using SplitToolWindow splitToolWindow = new();
			if (splitToolWindow.ShowDialog(this) == DialogResult.OK)
			{
				if (splitToolWindow.slashCheckBox.Checked) splitChar.Add('/');
				if (splitToolWindow.commaCheckBox.Checked) splitChar.Add(',');
				if (splitToolWindow.spaceCheckBox.Checked) splitChar.Add(' ');
				if (splitToolWindow.tabCheckBox.Checked) splitChar.Add('\t');
				if (splitToolWindow.otherCheckBox.Checked && splitToolWindow.otherTextBox.Text != null) splitChar.Add(splitToolWindow.otherTextBox.Text[0]);
				//分割された列をMainDataに追加し、DataGridViewの表示を更新する
				if (splitChar.Any())
				{
					if (MainData.SplitValue(key, splitChar.ToArray())) DataGridView_Update();
					else MessageForm.Show("エラー：列の分割に失敗しました。");
				}
			}
		}

		/// <summary>
		/// (右クリックメニュー)DataGridViewの選択されている列の値にIDを設定する
		/// </summary>
		private void CreateIDColumn_Click(object sender, EventArgs e)
		{
			(DataGridView dataGridView, string key) = GetDataGridViewAndSelectColumnHeaderText(sender);
			if (dataGridView is null || key is null) return;
			if (MainData.AddIDKeyValue(key)) DataGridView_Update();
			else MessageForm.Show("エラー：ID列作成に失敗しました。");
		}

		/// <summary>
		/// (右クリックメニュー)DataGridViewの選択されている列の値にIndexを設定する
		/// </summary>
		private void CreateIndexColumn_Click(object sender, EventArgs e)
		{
			(DataGridView dataGridView, string key) = GetDataGridViewAndSelectColumnHeaderText(sender);
			if (dataGridView is null || key is null) return;
			if (MainData.AddIndexKeyValue(key)) DataGridView_Update();
			else MessageForm.Show("エラー：Index列作成に失敗しました。");
		}

		/// <summary>
		/// (右クリックメニュー)DataGridViewの選択されている列を削除する
		/// </summary>
		private void RemoveColumn_Click(object sender, EventArgs e)
		{
			(DataGridView dataGridView, string key) = GetDataGridViewAndSelectColumnHeaderText(sender);
			if (dataGridView is null || key is null) return;
			if (MessageForm.Show("以下の名前の列を削除します。本当によろしいですか？\n列名：" + key, "確認ウィンドウ", MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				if (MainData.RemoveKey(key)) DataGridView_Update();
				else MessageForm.Show("エラー：列削除に失敗しました。");
			}
		}

		private class KeyImpl
		{
			Form1 Form { get; } = null;

			public KeyImpl(Form1 form)
			{
				Form = form;
				//イベント設定
				Form.Load += Load_Event;
				Form.x_axisKeyBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
				Form.x_axisSortKeyBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
				Form.x_axisViewOrderBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
				Form.y_axisKeyBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
				Form.y_axisSortKeyBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
				Form.y_axisViewOrderBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
				Form.x_axisViewMinBox.Leave += NumberBox_Leave;
				Form.x_axisViewMaxBox.Leave += NumberBox_Leave;
				Form.y_axisViewMinBox.Leave += NumberBox_Leave;
				Form.y_axisViewMaxBox.Leave += NumberBox_Leave;
				Form.x_axisTickBox.Leave += NumberBox_Leave;
				Form.y_axisTickBox.Leave += NumberBox_Leave;
				Form.valueListBox.SelectedIndexChanged += ListBox_SelectedIndexChanged;
				Form.addValueButton.Click += addValueButton_Click;
				Form.deleteKeyToolStripMenuItem.Click += deleteKeyToolStripMenuItem_Click;
			}

			public void Update() => Load_Event(Form, new EventArgs());

			private void Load_Event(object sender, EventArgs e)
			{
				//コンボボックスの初期化
				string[] keys = MainData.GetKeys();
				Form.x_axisKeyBox.InitEx(keys, GlottogramData.ColumnKey);
				Form.x_axisSortKeyBox.InitEx(keys, GlottogramData.ColumnSortKey);
				Form.x_axisViewOrderBox.InitEx(new[] { "昇順", "降順" }, GlottogramData.ColumnAscendingOrder ? 0 : 1);
				Form.y_axisKeyBox.InitEx(keys, GlottogramData.RowKey);
				Form.y_axisSortKeyBox.InitEx(keys, GlottogramData.RowSortKey);
				Form.y_axisViewOrderBox.InitEx(new[] { "昇順", "降順" }, GlottogramData.RowAscendingOrder ? 0 : 1);
				Form.valueKeyBox.InitEx(keys);
				//GlottogramDataを反映
				Form.x_axisViewMinBox.Value = GlottogramData.ColumnMin;
				Form.x_axisViewMaxBox.Value = GlottogramData.ColumnMax;
				Form.x_axisTickBox.Value = GlottogramData.ColumnTick;
				Form.y_axisViewMinBox.Value = GlottogramData.RowMin;
				Form.y_axisViewMaxBox.Value = GlottogramData.RowMax;
				Form.y_axisTickBox.Value = GlottogramData.RowTick;
				Form.valueListBox.Items.Clear();
				foreach (string valueKey in GlottogramData.ValueKeys)
				{
					if (Form.valueListBox.Items.Contains(valueKey)) continue;
					Form.valueListBox.Items.Add(valueKey);
				}
			}

			private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
			{
				if (sender is not ComboBox comboBox || comboBox.SelectedIndex == -1) return;
				if (comboBox == Form.x_axisKeyBox) GlottogramData.ColumnKey = comboBox.SelectedItem as string;
				else if (comboBox == Form.x_axisSortKeyBox) GlottogramData.ColumnSortKey = comboBox.SelectedItem as string;
				else if (comboBox == Form.x_axisViewOrderBox) GlottogramData.ColumnAscendingOrder = comboBox.SelectedIndex != 1;
				else if (comboBox == Form.y_axisKeyBox) GlottogramData.RowKey = comboBox.SelectedItem as string;
				else if (comboBox == Form.y_axisSortKeyBox) GlottogramData.RowSortKey = comboBox.SelectedItem as string;
				else if (comboBox == Form.y_axisViewOrderBox) GlottogramData.RowAscendingOrder = comboBox.SelectedIndex != 1;
			}

			private void NumberBox_Leave(object sender, EventArgs e)
			{
				if (sender is not NumberBox numberBox) return;
				if (numberBox == Form.x_axisViewMinBox || numberBox == Form.x_axisViewMaxBox) GlottogramData.ColumnRange = (Form.x_axisViewMinBox.GetValue<int>(0), Form.x_axisViewMaxBox.GetValue<int>(0));
				else if (numberBox == Form.y_axisViewMinBox || numberBox == Form.y_axisViewMaxBox) GlottogramData.RowRange = (Form.y_axisViewMinBox.GetValue<int>(0), Form.y_axisViewMaxBox.GetValue<int>(0));
				else if (numberBox == Form.x_axisTickBox) GlottogramData.ColumnTick = numberBox.GetValue<int>(GlottogramData.ColumnTick);
				else if (numberBox == Form.y_axisTickBox) GlottogramData.RowTick = numberBox.GetValue<int>(GlottogramData.RowTick);
			}

			private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
			{
				if (sender is not ListBox listBox) return;
				listBox.ContextMenuStrip = listBox.SelectedIndex == -1 ? null : Form.valueListBoxMenu;
			}

			private void addValueButton_Click(object sender, EventArgs e)
			{
				if (Form.valueKeyBox.SelectedItem is not string key) return;
				List<string> valueKeys = GlottogramData.ValueKeys;
				if (valueKeys.Contains(key)) return;
				valueKeys.Add(key);
				SymbolData.Update();
				Form.valueListBox.Items.Clear();
				Form.valueListBox.Items.AddRange(valueKeys.ToArray());
				Form.Symbol.Update();
			}

			private void deleteKeyToolStripMenuItem_Click(object sender, EventArgs e)
			{
				Control control = (sender as ToolStripMenuItem)?.GetSourceControlEx();
				if (control is not ListBox listBox) MessageForm.Show("エラー：\n右クリックメニューが不正に呼び出されました。");
				else
				{
					if (listBox.SelectedIndex == -1 || listBox.SelectedItem is not string key) return;
					List<string> valueKeys = GlottogramData.ValueKeys;
					if (!valueKeys.Contains(key)) return;
					valueKeys.Remove(key);
					Form.valueListBox.Items.Clear();
					Form.valueListBox.Items.AddRange(valueKeys.ToArray());
					Form.Symbol.Update();
				}
			}
		}

		private class SymbolImpl
		{
			Form1 Form { get; } = null;

			SymbolDataGridView symbolDataGridView { get; } = null;

			ContextMenuStripEx SymbolDataGridViewContextMenuStrip { get; } = new ContextMenuStripEx();

			public SymbolImpl(Form1 form)
			{
				Form = form;
				symbolDataGridView = Form.symbolDataGridView;
				//イベント設定
				Form.loadSymbolDataToolStripMenuItem.Click += LoadSymbol_Event;
				Form.exportSymbolToolStripMenuItem.Click += ExportSymbol_Event;
				symbolDataGridView.CellDoubleClick += SymbolDataGridView_CellDoubleClick;
				Form.selectedSymbolUngroupButton.Click += SelectedSymbolControl_Click;
				Form.selectedSymbolViewCheckBox.CheckedChanged += SelectedSymbolControl_CheckedChanged;
				Form.selectedSymbolPictureBox.Click += SelectedSymbolControl_Click;
				Form.selectedSymbolValueTextBox.KeyPress += SelectedSymbolControl_KeyPress;
				Form.selectedSymbolValueTextBox.Leave += SelectedSymbolControl_Leave;
				Form.selectedSymbolConvertModeEnumComboBox.SelectedIndexChanged += SelectedSymbolControl_SelectedIndexChanged;
				Form.selectedSymbolCustomNameTextBox.KeyPress += SelectedSymbolControl_KeyPress;
				Form.selectedSymbolCustomNameTextBox.Leave += SelectedSymbolControl_Leave;
				Form.selectedSymbolElipsisEnabledCheckBox.CheckedChanged += SelectedSymbolControl_CheckedChanged;
				Form.selectedSymbolElipsisPictureBox.Click += SelectedSymbolControl_Click;
				Form.selectedSymbolElipsisRelatedYNumberBox.Leave += SelectedSymbolControl_Leave;
				Form.selectedSymbolMembersDataGridView.CellDoubleClick += SymbolDataGridView_CellDoubleClick;
				Form.selectedSymbolMembersDataGridView.MembersUpdated += SymbolDataGridView_MembersUpdated;
				Form.selectedSymbolParentDataGridView.CellDoubleClick += SymbolDataGridView_CellDoubleClick;
				{
					ToolStripMenuItem removeEvent = new("個数が0の値をすべて削除する", null, SymbolDataGridView_NotFoundValueRemove);
					SymbolDataGridViewContextMenuStrip.Items.Add(removeEvent);
				}
			}

			public void Update() => Load_Event(Form, new EventArgs());

			private void Load_Event(object sender, EventArgs e)
			{
				symbolDataGridView.SetRootSymbols();
				SelectedSymbol_Update(null);
				symbolDataGridView.ContextMenuStrip = symbolDataGridView.Rows.Count == 0 ? null : SymbolDataGridViewContextMenuStrip;
			}

			private void LoadSymbol_Event(object sender, EventArgs e)
			{
				using OpenFileDialog ofd = new();
				ofd.FileName = ".gcs";
				ofd.Filter = "GlottogramCreator Symbolデータファイル(*.gcs)|*.gcs|XMLファイル(*.xml)|*.xml";
				ofd.FilterIndex = 1;
				ofd.Title = "ファイルを選択してください";
				ofd.RestoreDirectory = true;
				if (ofd.ShowDialog() == DialogResult.OK)
				{
					SymbolData.Load(ofd.FileName);
					SymbolData.Update();
					Update();
				}
			}

			private void ExportSymbol_Event(object sender, EventArgs e)
			{
				using SaveFileDialog fileDialog = new();
				fileDialog.FileName = ".gcs";
				fileDialog.Filter = "GlottogramCreator Symbolデータファイル(*.gcs)|*.gcs|XMLファイル(*.xml)|*.xml";
				fileDialog.FilterIndex = 1;
				fileDialog.Title = "名前をつけて保存";
				fileDialog.RestoreDirectory = true;
				if (fileDialog.ShowDialog() == DialogResult.OK)
				{
					try
					{
						System.Xml.Linq.XDocument xDocument = XDocumentExtend.CreateEx("root");
						xDocument.Root.Add(SymbolData.Output());
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

			private void SymbolDataGridView_NotFoundValueRemove(object sender, EventArgs e)
			{
				Symbol selected = SelectedSymbol;
				SymbolData.RemoveNotFoundValue();
				symbolDataGridView.SetRootSymbols();
				SelectedSymbol_Update(selected);
				symbolDataGridView.ContextMenuStrip = symbolDataGridView.Rows.Count == 0 ? null : SymbolDataGridViewContextMenuStrip;

			}

			private void SymbolDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
			{
				if (e.RowIndex == -1 || sender is not SymbolDataGridView dataGridView) return;
				if (dataGridView.SelectedSymbol is Symbol symbol) SelectedSymbol_Update(symbol);
			}

			private void SymbolDataGridView_MembersUpdated(object sender, EventArgs e)
			{
				if (sender is not SymbolDataGridView dataGridView) return;
				if (dataGridView == Form.selectedSymbolMembersDataGridView) SelectedSymbol_Update(SelectedSymbol, false, true);
			}

			Symbol SelectedSymbol { get; set; } = null;

			private void SelectedSymbol_Update(Symbol symbol, bool membersUpdate = true, bool parentUpdate = true)
			{
				SelectedSymbol = symbol;
				Form.selectedSymbolTypeTextBox.Text = symbol is null ? "未選択" : symbol.Name is not null ? "グループ" : "値";
				Form.selectedSymbolUngroupButton.Enabled = symbol?.Name is not null;
				Form.selectedSymbolViewCheckBox.Checked = symbol?.Visible ?? false;
				Form.selectedSymbolPictureBox.Image?.Dispose();
				Form.selectedSymbolPictureBox.Image = symbol?.Data?.GetBitmap(1.0f);
				Form.selectedSymbolValueTextBox.Enabled = symbol?.Name is not null;
				Form.selectedSymbolValueTextBox.Text = symbol is null ? null : symbol.Name ?? symbol.Value;
				Dictionary<Symbol, int> sum = MainData.GetSymbolSum();
				Form.selectedSymbolCountTextBox.Text = symbol is null ? null : sum.TryGetValue(symbol, out int count) ? count.ToString() : "0";
				Form.selectedSymbolConvertModeEnumComboBox.SelectedEnumValue = symbol?.ConvertMode ?? ConvertMode.None;
				Form.selectedSymbolCustomNameTextBox.Text = symbol?.CustomName;
				Form.selectedSymbolElipsisEnabledCheckBox.Checked = symbol?.ElipsisEnabled ?? false;
				Form.selectedSymbolElipsisPictureBox.Image?.Dispose();
				Form.selectedSymbolElipsisPictureBox.Image = symbol?.ElipsisData?.GetBitmap(1.0f);
				Form.selectedSymbolElipsisRelatedYNumberBox.Value = symbol?.ElipsisRelatedY;
				symbolDataGridView.SelectedSymbol = SelectedSymbol;
				if (membersUpdate) Form.selectedSymbolMembersDataGridView.SetParentSymbol(SelectedSymbol);
				if (parentUpdate) Form.selectedSymbolParentDataGridView.SetNoParentSymbols(SelectedSymbol?.Parent);
			}

			private void SelectedSymbolControl_Click(object sender, EventArgs e)
			{
				if (SelectedSymbol is null) return;
				if (sender is Button button)
				{
					if (button == Form.selectedSymbolUngroupButton)
					{
						if (SelectedSymbol.Name is not null)
						{
							SymbolData.RemoveGroup(SelectedSymbol);
							SelectedSymbol_Update(null);
							symbolDataGridView.SetRootSymbols();
						}
					}
				}
				else if (sender is PictureBox pictureBox)
				{
					if (pictureBox == Form.selectedSymbolPictureBox)
					{
						SvgViewer.GetSingleton().SetViewing(SelectedSymbol.Data);
						SvgViewer.OpenOrShowDialog(Form);
						if (SvgViewer.StaticDialogResult == DialogResult.OK)
						{
							SvgWrapper.SvgData data = SvgViewer.StaticDialogReturn as SvgWrapper.SvgData;
							SelectedSymbol.Data = data;
							pictureBox.Image?.Dispose();
							pictureBox.Image = SelectedSymbol.Data?.GetBitmap(1.0f);
						}
						if (symbolDataGridView.Symbols.Contains(SelectedSymbol)) symbolDataGridView.SetRootSymbols();
					}
					else if (pictureBox == Form.selectedSymbolElipsisPictureBox)
					{
						SvgViewer.GetSingleton().SetViewing(SelectedSymbol.ElipsisData);
						SvgViewer.OpenOrShowDialog(Form);
						if (SvgViewer.StaticDialogResult == DialogResult.OK)
						{
							SvgWrapper.SvgData data = SvgViewer.StaticDialogReturn as SvgWrapper.SvgData;
							SelectedSymbol.ElipsisData = data;
							pictureBox.Image?.Dispose();
							pictureBox.Image = SelectedSymbol.ElipsisData?.GetBitmap(1.0f);
						}
					}
				}
			}

			private void SelectedSymbolControl_CheckedChanged(object sender, EventArgs e)
			{
				if (SelectedSymbol is null) return;
				if (sender is CheckBox checkBox)
				{
					if (checkBox == Form.selectedSymbolViewCheckBox)
					{
						SelectedSymbol.Visible = checkBox.Checked;
						if (symbolDataGridView.Symbols.Contains(SelectedSymbol)) symbolDataGridView.SetRootSymbols();
					}
					else if (checkBox == Form.selectedSymbolElipsisEnabledCheckBox)
					{
						SelectedSymbol.ElipsisEnabled = checkBox.Checked;
					}
				}
			}

			private void SelectedSymbolControl_SelectedIndexChanged(object sender, EventArgs e)
			{
				if (SelectedSymbol is null) return;
				if (sender is EnumComboBox enumComboBox)
				{
					if (enumComboBox == Form.selectedSymbolConvertModeEnumComboBox)
					{
						if (enumComboBox.SelectedEnumValue is not ConvertMode mode) return;
						SelectedSymbol.ConvertMode = mode;
						Form.selectedSymbolCustomNameTextBox.Enabled = mode == ConvertMode.Custom;
					}
				}
			}

			private void SelectedSymbolControl_KeyPress(object sender, KeyPressEventArgs e)
			{
				if (sender is TextBox textBox)
				{
					if (e.KeyChar == (char)Keys.Enter)
					{
						e.Handled = true;
						if (textBox.Parent is not null) textBox.Parent.SelectNextControl(textBox, true, true, true, true);
					}
				}
			}

			private void SelectedSymbolControl_Leave(object sender, EventArgs e)
			{
				if (SelectedSymbol is null) return;
				if (sender is NumberBox numberBox)
				{
					if (numberBox == Form.selectedSymbolElipsisRelatedYNumberBox) SelectedSymbol.ElipsisRelatedY = numberBox.GetValue<float>(SelectedSymbol.ElipsisRelatedY);
				}
				else if (sender is TextBox textBox)
				{
					if (textBox == Form.selectedSymbolCustomNameTextBox) SelectedSymbol.CustomName = textBox.Text ?? string.Empty;
					else if (textBox == Form.selectedSymbolValueTextBox)
					{
						if (SelectedSymbol.Name is not null)
						{
							SelectedSymbol.Name = textBox.Text ?? string.Empty;
							if (symbolDataGridView.Symbols.Contains(SelectedSymbol)) symbolDataGridView.SetRootSymbols();
						}
					}
				}
			}
		}

		KeyImpl Key { get; } = null;

		SymbolImpl Symbol { get; } = null;
	}
}
