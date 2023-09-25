using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Reflection;

namespace WinFormsApp1
{
	public class EditListDataGridView<T> : DataGridView
	{
		List<T> m_items = new();
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		List<T> Items {
			get => m_items;
			set
			{
				if (value is null) m_items = new();
				else m_items = value;
			}
		}

		public T[] ReadOnlyItems => Items.ToArray();

		[Browsable(true)]
		[Category("Extend")]
		[Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))]
		[TypeConverter(typeof(CollectionConverter))]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public List<string> ViewProperties { get; } = new();

		protected virtual T GetNewInstance() => default(T);

		public EditListDataGridView()
		{
			AllowDrag = true;
			AllowDrop = true;
			AllowUserToAddRows = false;
			AllowUserToDeleteRows = false;
			AllowUserToOrderColumns = false;
			AllowUserToResizeColumns = true;
			AllowUserToResizeRows = false;
			ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			ContextMenuStrip = ContextMenuStrip;
			EnableHeadersVisualStyles = false;
			DefaultCellStyle = DefaultCellStyle;
			ColumnHeadersDefaultCellStyle = new(ColumnHeadersDefaultCellStyle) { BackColor = DefaultCellStyle.BackColor };
			RowHeadersDefaultCellStyle = new(RowHeadersDefaultCellStyle) { BackColor = DefaultCellStyle.BackColor };
			RowTemplate = new() { HeaderCell = new DataGridViewRowHeaderCellWithoutArrow() };
			DoubleBuffered = true;
			EditMode = DataGridViewEditMode.EditProgrammatically;
			ReadOnly = true;
			SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			ShowCellToolTips = false;
			ShowEditingIcon = false;
			RowHeadersVisible = false;
		}

		public void UpdateView()
		{
			Rows.Clear();
			Columns.Clear();
			int count = 0;
			PropertyInfo[] propertyInfos = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (propertyInfos.Length == 0)
			{
				Columns.Add("0", "Value");
				foreach (DataGridViewColumn column in Columns) column.SortMode = DataGridViewColumnSortMode.NotSortable;
				foreach (T item in Items)
				{
					DataGridViewRow row = new();
					row.CreateCells(this);
					row.Cells[0].Value = item.ToString();
					Rows.Add(row);
				}
			}
			else
			{
				List<PropertyInfo> ViewPropertyInfo = new();
				foreach (string p in ViewProperties)
				{
					if (propertyInfos.Where(x => x.Name == p).FirstOrDefault() is not PropertyInfo property) continue;
					ViewPropertyInfo.Add(property);
					Type type = property.PropertyType;
					if (type.IsAssignableTo(typeof(Bitmap)) || type == typeof(Color))
					{
						DataGridViewImageColumn imageColumn = new() { Name = count.ToString(), HeaderText = p };
						Columns.Add(imageColumn);
					}
					else Columns.Add(count.ToString(), p);
					++count;
				}
				if (count == 0) return;
				foreach (DataGridViewColumn column in Columns) column.SortMode = DataGridViewColumnSortMode.NotSortable;
				foreach (T item in Items)
				{
					DataGridViewRow row = new();
					row.CreateCells(this);
					for (int i = 0; i < count; ++i)
					{
						if (ViewPropertyInfo[i].GetValue(item) is not object obj) continue;
						if (obj is Bitmap) row.Cells[i].Value = obj;
						else if (obj is Color color)
						{
							Bitmap tmp = new(row.Height, row.Height);
							using Graphics graphics = Graphics.FromImage(tmp);
							graphics.Clear(color);
							row.Cells[i].Value = tmp;
						}
						else row.Cells[i].Value = obj.ToString();
					}
					Rows.Add(row);
				}
			}
			AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
			AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
		}

		public void SetItems(List<T> items)
		{
			Items = items;
			UpdateView();
		}

		public void AddItem(T item)
		{
			if (item is null) return;
			Items.Add(item);
			UpdateView();
		}

		public void RemoveAt(int index)
		{
			if (0 <= index && index < Items.Count)
			{

				Items.RemoveAt(index);
				UpdateView();
			}
		}

		static void AddItem_Event(object sender, EventArgs e)
		{
			if (sender is not ToolStripMenuItem item || item.GetSourceControlEx() is not EditListDataGridView<T> dataGridView) return;
			dataGridView.AddItem(dataGridView.GetNewInstance());
		}

		static void RemoveItem_Event(object sender, EventArgs e)
		{
			if (sender is not ToolStripMenuItem item || item.GetSourceControlEx() is not EditListDataGridView<T> dataGridView) return;
			if (dataGridView.SelectedRowIndex == -1) MessageForm.Show("列が選択されていません。", "エラー", MessageBoxButtons.OK);
			else dataGridView.RemoveAt(dataGridView.SelectedRowIndex);
		}

		ToolStripMenuItem AddItemToolStripMenuItem { get; } = new("新規追加", null, AddItem_Event);

		ToolStripMenuItem RemoveItemStripMenuItem { get; } = new("選択列を削除", null, RemoveItem_Event);

		bool m_enabledAddEvent = true;
		[Browsable(true)]
		[Category("Extend")]
		[DefaultValue(true)]
		public bool EnabledAddEvent
		{
			get => m_enabledAddEvent;
			set
			{
				m_enabledAddEvent = value;
				if (EnabledAddEvent && !base.ContextMenuStrip.Items.Contains(AddItemToolStripMenuItem)) base.ContextMenuStrip.Items.Add(AddItemToolStripMenuItem);
				else if (!EnabledAddEvent && base.ContextMenuStrip.Items.Contains(AddItemToolStripMenuItem)) base.ContextMenuStrip.Items.Remove(AddItemToolStripMenuItem);
			}
		}

		bool m_enabledRemoveEvent = true;
		[Browsable(true)]
		[Category("Extend")]
		[DefaultValue(true)]
		public bool EnabledRemoveEvent
		{
			get => m_enabledRemoveEvent;
			set
			{
				m_enabledRemoveEvent = value;
				if (EnabledRemoveEvent && !base.ContextMenuStrip.Items.Contains(RemoveItemStripMenuItem)) base.ContextMenuStrip.Items.Add(RemoveItemStripMenuItem);
				else if (!EnabledRemoveEvent && base.ContextMenuStrip.Items.Contains(RemoveItemStripMenuItem)) base.ContextMenuStrip.Items.Add(RemoveItemStripMenuItem);
			}
		}

		[Browsable(false)]
		[Category("Behavior")]
		[DefaultValue(false)]
		public bool AllowDrag { get; set; } = false;

		[Browsable(false)]
		[DefaultValue(false)]
		public new bool AllowDrop { get => base.AllowDrop; set => base.AllowDrop = value; }

		[Browsable(false)]
		[DefaultValue(false)]
		public new bool AllowUserToAddRows { get => base.AllowUserToAddRows; set => base.AllowUserToAddRows = value; }

		[Browsable(false)]
		[DefaultValue(false)]
		public new bool AllowUserToDeleteRows { get => base.AllowUserToDeleteRows; set => base.AllowUserToDeleteRows = value; }

		[Browsable(false)]
		[DefaultValue(false)]
		public new bool AllowUserToOrderColumns { get => base.AllowUserToOrderColumns; set => base.AllowUserToOrderColumns = value; }

		[Browsable(false)]
		[DefaultValue(false)]
		public new bool AllowUserToResizeColumns { get => base.AllowUserToResizeColumns; set => base.AllowUserToResizeColumns = value; }

		[Browsable(false)]
		[DefaultValue(false)]
		public new bool AllowUserToResizeRows { get => base.AllowUserToResizeRows; set => base.AllowUserToResizeRows = value; }

		[Browsable(true)]
		[DefaultValue(typeof(DataGridViewColumnHeadersHeightSizeMode), nameof(DataGridViewColumnHeadersHeightSizeMode.AutoSize))]
		public new DataGridViewColumnHeadersHeightSizeMode ColumnHeadersHeightSizeMode { get => base.ColumnHeadersHeightSizeMode; set => base.ColumnHeadersHeightSizeMode = value; }

		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DefaultValue(typeof(ContextMenuStrip), "(none)")]
		public new ContextMenuStrip ContextMenuStrip
		{
			get => base.ContextMenuStrip;
			set
			{
				base.ContextMenuStrip = value is ContextMenuStripEx ? value : value is not null ? new ContextMenuStripEx(value) : new ContextMenuStripEx();
				if (EnabledAddEvent && !base.ContextMenuStrip.Items.Contains(AddItemToolStripMenuItem)) base.ContextMenuStrip.Items.Add(AddItemToolStripMenuItem);
				else if (!EnabledAddEvent && base.ContextMenuStrip.Items.Contains(AddItemToolStripMenuItem)) base.ContextMenuStrip.Items.Remove(AddItemToolStripMenuItem);
				if (EnabledRemoveEvent && !base.ContextMenuStrip.Items.Contains(RemoveItemStripMenuItem)) base.ContextMenuStrip.Items.Add(RemoveItemStripMenuItem);
				else if (!EnabledRemoveEvent && base.ContextMenuStrip.Items.Contains(RemoveItemStripMenuItem)) base.ContextMenuStrip.Items.Add(RemoveItemStripMenuItem);
			}
		}

		[Browsable(false)]
		[DefaultValue(typeof(DataGridViewEditMode), nameof(DataGridViewEditMode.EditProgrammatically))]
		public new DataGridViewEditMode EditMode { get => base.EditMode; set => base.EditMode = value; }

		[Browsable(true)]
		[DefaultValue(false)]
		public new bool EnableHeadersVisualStyles { get => base.EnableHeadersVisualStyles; set => base.EnableHeadersVisualStyles = value; }

		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new DataGridViewCellStyle DefaultCellStyle { get => base.DefaultCellStyle; set => base.DefaultCellStyle = value; }

		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new DataGridViewCellStyle ColumnHeadersDefaultCellStyle { get => base.ColumnHeadersDefaultCellStyle; set => base.ColumnHeadersDefaultCellStyle = value; }

		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new DataGridViewCellStyle RowHeadersDefaultCellStyle { get => base.RowHeadersDefaultCellStyle; set => base.RowHeadersDefaultCellStyle = value; }

		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new DataGridViewRow RowTemplate { get => base.RowTemplate; set => base.RowTemplate = value; }

		[Browsable(false)]
		[DefaultValue(true)]
		public new bool ReadOnly { get => base.ReadOnly; set => base.ReadOnly = value; }

		[Browsable(false)]
		[DefaultValue(typeof(DataGridViewSelectionMode), nameof(DataGridViewSelectionMode.FullRowSelect))]
		public new DataGridViewSelectionMode SelectionMode { get => base.SelectionMode; set => base.SelectionMode = value; }

		[Browsable(true)]
		[DefaultValue(false)]
		public new bool ShowCellToolTips { get => base.ShowCellToolTips; set => base.ShowCellToolTips = value; }

		[Browsable(true)]
		[DefaultValue(false)]
		public new bool ShowEditingIcon { get => base.ShowEditingIcon; set => base.ShowEditingIcon = value; }

		[Browsable(true)]
		[DefaultValue(false)]
		public new bool RowHeadersVisible { get => base.RowHeadersVisible; set => base.RowHeadersVisible = value; }

		[Browsable(false)]
		private new event EventHandler SelectionChanged;

		int selectedRowIndex = -1;

		/// <summary>
		/// 選択されている行のインデックス
		/// </summary>
		int SelectedRowIndex
		{
			get => selectedRowIndex;
			set
			{
				selectedRowIndex = value;
				Refresh();
			}
		}

		/// <summary>
		/// 選択されているオブジェクト
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
#nullable enable
		public T? SelectedItem
		{
			get
			{
				if (0 <= SelectedRowIndex && SelectedRowIndex < Items.Count) return Items[SelectedRowIndex];
				else return default(T);
			}
			set
			{
				if (value is null) SelectedRowIndex = -1;
				else SelectedRowIndex = Items.IndexOf(value);
			}
		}
#nullable disable

		protected override void OnDefaultCellStyleChanged(EventArgs e)
		{
			DefaultCellStyle.SelectionBackColor = DefaultCellStyle.BackColor;
			DefaultCellStyle.SelectionForeColor = DefaultCellStyle.ForeColor;
			base.OnDefaultCellStyleChanged(e);
		}

		protected override void OnColumnHeadersDefaultCellStyleChanged(EventArgs e)
		{
			ColumnHeadersDefaultCellStyle.SelectionBackColor = ColumnHeadersDefaultCellStyle.BackColor;
			ColumnHeadersDefaultCellStyle.SelectionForeColor = ColumnHeadersDefaultCellStyle.ForeColor;
			base.OnColumnHeadersDefaultCellStyleChanged(e);
		}

		protected override void OnRowHeadersDefaultCellStyleChanged(EventArgs e)
		{
			RowHeadersDefaultCellStyle.SelectionBackColor = RowHeadersDefaultCellStyle.BackColor;
			RowHeadersDefaultCellStyle.SelectionForeColor = RowHeadersDefaultCellStyle.ForeColor;
			base.OnRowHeadersDefaultCellStyleChanged(e);
		}

		protected override void OnParentChanged(EventArgs e)
		{
			if (!DesignMode) UpdateView();
			base.OnParentChanged(e);
		}

		protected override void OnFontChanged(EventArgs e)
		{
			foreach (DataGridViewColumn column in Columns) column.DefaultCellStyle.Font = Font;
			base.OnFontChanged(e);
		}

		/// <summary>
		/// 行を選択する
		/// </summary>
		protected override void OnCellClick(DataGridViewCellEventArgs e)
		{
			SelectedRowIndex = e.RowIndex;
			base.OnCellClick(e);
		}

		/// <summary>
		/// 選択されている行をSystem.Drawing.SystemColors.Highlightで囲む
		/// </summary>
		protected override void OnRowPostPaint(DataGridViewRowPostPaintEventArgs e)
		{
			if (e.RowIndex != SelectedRowIndex) return;
			Rectangle bounds = e.RowBounds with { X = RowHeadersVisible ? RowHeadersWidth : 0, Y = e.RowBounds.Y + 1, Width = Columns.GetColumnsWidth(DataGridViewElementStates.Visible), Height = e.RowBounds.Height - 2 };
			using Pen pen = new(System.Drawing.SystemColors.Highlight, 2.0f);
			e.Graphics.DrawRectangle(pen, bounds);
			base.OnRowPostPaint(e);
		}

		/// <summary>
		/// SelectionChangedイベントを呼び出す
		/// </summary>
		protected override void OnSelectionChanged(EventArgs e)
		{
			base.OnSelectionChanged(e);
			var selectionChanged = SelectionChanged;
			if (selectionChanged is not null) selectionChanged(this, e);
		}

		/// <summary>
		/// 親のフォントをContextMenuStripに適用する
		/// </summary>
		/// <param name="e"></param>
		protected override void OnParentFontChanged(EventArgs e)
		{
			if (ContextMenuStrip is not null) ContextMenuStrip.Font = Parent.Font;
			base.OnParentFontChanged(e);
		}

		/// <summary>
		/// DragDrop開始の判定に使用されるマウス座標
		/// </summary>
		Point MousePoint = Point.Empty;

		/// <summary>
		/// マウス押下座標を保存
		/// </summary>
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (AllowDrag)
			{
				if (e.Button == MouseButtons.Left)
				{
					int rowIndex = HitTest(e.X, e.Y).RowIndex;
					if (rowIndex != -1 && rowIndex < RowCount) MousePoint = e.Location;
				}
				else MousePoint = Point.Empty;
			}
			base.OnMouseDown(e);
		}

		/// <summary>
		/// マウス押下座標をリセット
		/// </summary>
		protected override void OnMouseUp(MouseEventArgs e)
		{
			if (AllowDrag) MousePoint = Point.Empty;
			base.OnMouseUp(e);
		}

		struct DraggingObject
		{
			public int index;
			public EditListDataGridView<T> sender;

			public DraggingObject(EditListDataGridView<T> sender, int index)
			{
				this.index = index;
				this.sender = sender;
			}
		}

		/// <summary>
		/// ドラッグ移動開始判定
		/// </summary>
		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (AllowDrag)
			{
				if (e.Button == MouseButtons.Left && MousePoint != Point.Empty)
				{
					Rectangle dragStartRect = new(MousePoint.X - SystemInformation.DragSize.Width / 2, MousePoint.Y - SystemInformation.DragSize.Height / 2, SystemInformation.DragSize.Width, SystemInformation.DragSize.Height);
					if (!dragStartRect.Contains(e.X, e.Y))
					{
						int rowIndex = HitTest(e.X, e.Y).RowIndex;
						if (rowIndex != -1 && rowIndex < Items.Count) DoDragDrop(new DraggingObject(this, rowIndex), DragDropEffects.Move);
						MousePoint = Point.Empty;
					}
				}
			}
			base.OnMouseMove(e);
		}

		/// <summary>
		/// 右クリックでドラッグ移動を中止
		/// </summary>
		protected override void OnQueryContinueDrag(QueryContinueDragEventArgs qcdevent)
		{
			if ((qcdevent.KeyState & 2) == 2) qcdevent.Action = DragAction.Cancel;
			base.OnQueryContinueDrag(qcdevent);
		}

		/// <summary>
		/// ドロップ可能か判定
		/// </summary>
		protected override void OnDragEnter(DragEventArgs drgevent)
		{
			if (AllowDrop)
			{
				if (drgevent.Data.GetDataPresent(typeof(DraggingObject))) drgevent.Effect = DragDropEffects.Move;
				else drgevent.Effect = DragDropEffects.None;
			}
			else drgevent.Effect = DragDropEffects.None;
			base.OnDragEnter(drgevent);
		}

		/// <summary>
		/// ドラッグ移動中は上部及び下部付近でスクロール可能
		/// </summary>
		protected override void OnDragOver(DragEventArgs drgevent)
		{
			int mousepos = PointToClient(Cursor.Position).Y;
			if (mousepos > (Location.Y + (Height * 0.9)))
			{
				if (FirstDisplayedScrollingRowIndex < RowCount - 1)
				{
					FirstDisplayedScrollingRowIndex = FirstDisplayedScrollingRowIndex + 1;
				}
			}
			if (mousepos < (Location.Y + (Height * 0.05)))
			{
				if (FirstDisplayedScrollingRowIndex > 0)
				{
					FirstDisplayedScrollingRowIndex = FirstDisplayedScrollingRowIndex - 1;
				}
			}
			base.OnDragOver(drgevent);
		}

		protected override void OnDragDrop(DragEventArgs drgevent)
		{
			if (AllowDrop)
			{
				if (drgevent.Data.GetData(typeof(DraggingObject)) is DraggingObject draggingObject)
				{
					Point client = PointToClient(new(drgevent.X, drgevent.Y));
					HitTestInfo hitTestInfo = HitTest(client.X, client.Y);
					if (hitTestInfo.Type == DataGridViewHitTestType.Cell || hitTestInfo.Type == DataGridViewHitTestType.None)
					{
						int rowIndex = hitTestInfo.RowIndex < 0 ? Items.Count : hitTestInfo.RowIndex.ClampEx(0, Items.Count);
						if (draggingObject.sender == this)
						{
							Items.Insert(rowIndex, draggingObject.sender.ReadOnlyItems[draggingObject.index]);
							Items.RemoveAt(rowIndex <= draggingObject.index ? draggingObject.index + 1 : draggingObject.index);
							SelectedRowIndex = rowIndex <= draggingObject.index ? rowIndex : (rowIndex - 1).ClampEx(0, rowIndex);
						}
						else
						{
							Items.Insert(rowIndex, draggingObject.sender.ReadOnlyItems[draggingObject.index]);
							draggingObject.sender.RemoveAt(draggingObject.index);
							SelectedRowIndex = rowIndex;
						}
						UpdateView();
					}
				}
			}
			base.OnDragDrop(drgevent);
		}

		/// <summary>
		/// 行ヘッダーの矢印を描画しないRowHeaderCell
		/// </summary>
		class DataGridViewRowHeaderCellWithoutArrow : DataGridViewRowHeaderCell
		{
			protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
			{
				base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts & ~DataGridViewPaintParts.ContentBackground);
			}
		}
	}

	public class GraphicsTextBoxEditDataGridView : EditListDataGridView<GraphicsTextBox>
	{
		protected override GraphicsTextBox GetNewInstance()
		{
			return new GraphicsTextBox() { Text = "新規テキストボックス", Rectangle = new(0, 0, 200, 200) };
		}
	}
}
