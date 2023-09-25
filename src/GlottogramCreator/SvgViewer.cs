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
	public partial class SvgViewer : SvgViewer_Internal
	{
		private SvgViewer()
		{
			InitializeComponent();
			//フォント変更
			Config.SetMainFont(this);
			//イベント設定
			Shown += (sender, e) =>
			{
				Application.DoEvents();
				Init();
				SetViewing_Internal();
				pictureBox1_Update(dataGridView1);
			};
		}

		const int columnWidth = 50;	//dataGridViewの列幅
		const int rowHeight = 50;   //dataGridViewの行幅
		const int columnWidthWithoutPadding = columnWidth - 10;
		const int rowHeightWithPadding = rowHeight - 10;
		readonly Padding padding = new(5);  //セルのパディング

		List<string> FilePath { get; } = new();  //SVGファイルへの相対パスのList
		int CellCount => FilePath.Count;
		int ColumnCount => dataGridView1.Width / columnWidth;
		int RowCount
		{
			get
			{
				int cellCount = CellCount;
				int columnCount = ColumnCount;
				return cellCount % columnCount == 0 ? cellCount / columnCount : cellCount / columnCount + 1;
			}
		}

		static readonly Uri currentDirectory = new(System.IO.Directory.GetCurrentDirectory() + @"\");	//このプログラムのディレクトリ
		static readonly string svgDirectory = System.IO.Directory.GetCurrentDirectory() + @"\SYMBOL";	//SVGファイルのディレクトリ

		/// <summary>
		/// svgDirectoryからfilePathにファイル名を読み込む
		/// </summary>
		private void filePath_Load()
		{
			try
			{
				string[] files = System.IO.Directory.GetFiles(svgDirectory);
				foreach (string file in files)
				{
					if (System.IO.Path.GetExtension(file) != ".svg") continue;
					string relatedPath = null;
					try
					{
						relatedPath = currentDirectory.MakeRelativeUri(new Uri(file)).ToString();
					}
					catch
					{
						relatedPath = file;
					}
					if (relatedPath is not null) FilePath.Add(relatedPath);
				}
			}
			catch{}
		}

		/// <summary>
		/// DataGridViewの読み込みを行う
		/// </summary>
		private void Init()
		{
			if (dataGridView1.Rows.Count != 0) return;
			filePath_Load();
			//DataGridViewの描画
			int columnCount = ColumnCount;
			DataGridViewImageColumn imageColumn = new();
			imageColumn.ImageLayout = DataGridViewImageCellLayout.Normal;
			imageColumn.Image = new Bitmap(10, 10);
			for (int i = 0; i < columnCount; ++i)
			{
				DataGridViewImageColumn tmp = imageColumn.Clone() as DataGridViewImageColumn;
				tmp.Name = i.ToString();
				dataGridView1.Columns.Add(tmp);
				dataGridView1.Columns[i].Width = columnWidth;
			}
			for (int i = 0, rowCount = RowCount; i < rowCount; ++i)
			{
				dataGridView1.Rows.Add();
				dataGridView1.Rows[i].Height = rowHeight;
				for (int j = 0; j < columnCount; ++j)
				{
					if (i * columnCount + j >= FilePath.Count) break;
					if (dataGridView1.Rows[i].Cells[j] is not DataGridViewImageCell cell) continue;
					cell.Style.Padding = padding;
					cell.Value = new SvgWrapper.SvgData(FilePath[i * columnCount + j]).GetBitmap(1.0f);
					if (cell.Value is Image image && (image.Width > columnWidthWithoutPadding || image.Height > rowHeightWithPadding)) cell.ImageLayout = DataGridViewImageCellLayout.Zoom;
				}
			}
			if (dataGridView1.Columns.Count != 0 && dataGridView1.Rows.Count != 0) dataGridView1[0, 0].Selected = true;
			pictureBox1_Update(dataGridView1);
		}

		/// <summary>
		/// DataGridView内のセル座標に対応するList&lt;string&gt; filePathの値を取得する
		/// </summary>
		/// <param name="columnCount">DataGridViewの列数</param>
		/// <param name="columnIndex">セルの列座標</param>
		/// <param name="rowIndex">セルの行座標</param>
		/// <returns>対応するファイルパス。不正な座標の場合、null</returns>
		private string GetFilePath(int columnCount, int columnIndex, int rowIndex)
		{
			int index = rowIndex * columnCount + columnIndex;
			if (FilePath.Count <= index) return null;
			else return FilePath[index];
		}

		/// <summary>
		/// pictureBox1を更新する
		/// </summary>
		/// <param name="dataGridView">連動するDataGridView</param>
		/// <param name="color">使用する色</param>
		private void pictureBox1_Update(DataGridView dataGridView, bool textChanged = false)
		{
			if (dataGridView.SelectedCells.Count == 0 || dataGridView1.SelectedCells[0] is not DataGridViewCell cell) return;
			if (pictureBox1.Image is not null) pictureBox1.Image.Dispose();
			pictureBox1.Image = null;
			if (GetFilePath(dataGridView.Columns.Count, cell.ColumnIndex, cell.RowIndex) is not string path) return;
			SvgWrapper.SvgData svgData = new(path);
			svgData.Color = colorButton.BackColor;
			svgData.VerticalInversion = verticalInversionCheckBox.Checked;
			svgData.HorizontalInversion = horizontalInversionCheckBox.Checked;
			if (textChanged)
			{
				svgData.RotateAngle = angleBox.Text.GetFloatEx(0);
				svgData.CustomScale = scaleBox.Text.GetFloatEx(1.0f);
			}
			else
			{
				svgData.RotateAngle = angleBox.GetValue(0);
				svgData.CustomScale = scaleBox.GetValue(1.0f);
			}
			pictureBox1.Image = svgData.GetBitmap(1.8f);
		}

		/// <summary>
		/// 色の選択をpictureBox1に反映する
		/// </summary>
		private void ColorButton_Click(object sender, EventArgs e) => pictureBox1_Update(dataGridView1);

		/// <summary>
		/// 角度とスケールの変更をpictureBox1に反映する
		/// </summary>
		private void NumberBox_TextChanged(object sender, EventArgs e) => pictureBox1_Update(dataGridView1, true);

		/// <summary>
		/// 角度とスケールの変更をpictureBox1に反映する
		/// </summary>
		private void NumberBox_Leave(object sender, EventArgs e) => pictureBox1_Update(dataGridView1);

		/// <summary>
		/// セルの選択をpictureBox1に反映する
		/// </summary>
		private void dataGridView1_SelectionChanged(object sender, EventArgs e) => pictureBox1_Update(dataGridView1);

		/// <summary>
		/// 反転用CheckBoxの変更をpictureBox1に反映する
		/// </summary>
		private void CheckBox_CheckedChanged(object sender, EventArgs e) => pictureBox1_Update(dataGridView1);

		/// <summary>
		/// submitButtonが押されたとき、DialogReturnにSvgWrapper.SvgDataを設定し、フォームを閉じる
		/// </summary>
		private void submitButton_Click(object sender, EventArgs e)
		{
			DialogReturn = null;
			if (dataGridView1.SelectedCells.Count == 0 || dataGridView1.SelectedCells[0] is not DataGridViewCell cell) MessageForm.Show("エラー：\n記号が選択されていません。");			
			else if (GetFilePath(dataGridView1.Columns.Count, cell.ColumnIndex, cell.RowIndex) is not string filePath) MessageForm.Show("エラー：\n選択された記号のファイル名が取得できませんでした。");
			else
			{
				SvgWrapper.SvgData svgData = new();
				svgData.FilePath = filePath;
				svgData.Color = colorButton.BackColor;
				svgData.VerticalInversion = verticalInversionCheckBox.Checked;
				svgData.HorizontalInversion = horizontalInversionCheckBox.Checked;
				svgData.RotateAngle = angleBox.GetValue<float>(0);
				svgData.CustomScale = scaleBox.GetValue<float>(1.0f);
				this.DialogReturn = svgData;
				this.DialogResult = DialogResult.OK;
				this.Close();
				return;
			}
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		/// <summary>
		/// cancelButtonが押されたとき、DialogReturnにnullを設定し、フォームを閉じる
		/// </summary>
		private void CancelButton_Click(object sender, EventArgs e)
		{
			DialogReturn = null;
			DialogResult = DialogResult.Cancel;
			Close();
		}

		/// <summary>
		/// resetButtonが押されたとき、DialogReturnにnullを設定し、フォームを閉じる
		/// </summary>
		private void ResetButton_Click(object sender, EventArgs e)
		{
			DialogReturn = null;
			DialogResult = DialogResult.OK;
			Close();
		}

		SvgWrapper.SvgData ViewingData { get; set; } = null;

		private void SetViewing_Internal()
		{
			if (ViewingData is null) return;
			SvgWrapper.SvgData data = ViewingData;
			ViewingData = null;
			int index = FilePath.IndexOf(data.FilePath);
			if (index == -1) return;
			int columnCount = ColumnCount;
			int rowIndex = index / columnCount;
			int columnIndex = index % columnCount;
			if (rowIndex < dataGridView1.RowCount && columnIndex < dataGridView1.Rows[rowIndex].Cells.Count) dataGridView1[columnIndex, rowIndex].Selected = true;
			else return;
			colorButton.BackColor = data.Color;
			verticalInversionCheckBox.Checked = data.VerticalInversion;
			horizontalInversionCheckBox.Checked = data.HorizontalInversion;
			angleBox.Value = data.RotateAngle;
			scaleBox.Value = data.CustomScale;
		}

		/// <summary>
		/// 各コントロールの値を設定する
		/// </summary>
		/// <param name="data"></param>
		public void SetViewing(SvgWrapper.SvgData data)
		{
			if (data is null)
			{
				if (dataGridView1.Rows.Count != 0 && dataGridView1.Columns.Count != 0) dataGridView1[0, 0].Selected = true;
				colorButton.BackColor = Color.Black;
				verticalInversionCheckBox.Checked = false;
				horizontalInversionCheckBox.Checked = false;
				angleBox.Value = 0.0f;
				scaleBox.Value = 1.0f;
			}
			else
			{
				ViewingData = data;
				if (dataGridView1.Rows.Count != 0) SetViewing_Internal();
			}
		}
	}
	public class SvgViewer_Internal : SingletonForm<SvgViewer> { }
}
