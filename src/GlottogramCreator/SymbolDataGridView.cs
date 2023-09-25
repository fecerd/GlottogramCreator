using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace WinFormsApp1
{
	public class SymbolDataGridView : DataGridView
	{
		List<Symbol> symbols = new();

		/// <summary>
		/// 表示されているSymbolオブジェクトのList
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public List<Symbol> Symbols
		{
			get => symbols;
			private set
			{
				int visibleIndex = VisibleIndex;
				int symbolIndex = SymbolIndex;
				int valueIndex = ValueIndex;
				int countIndex = CountIndex;
				if (visibleIndex == -1 || symbolIndex == -1 || valueIndex == -1 || countIndex == -1) return;
				symbols = value ?? new();
				Dictionary<Symbol, int> sum = MainData.GetSymbolSum();
				int scrollIndex = FirstDisplayedScrollingRowIndex;
				Rows.Clear();
				foreach (var s in symbols)
				{
					int rowIndex = Rows.Add();
					var cells = Rows[rowIndex].Cells;
					cells[visibleIndex].Value = s.Visible;
					cells[symbolIndex].Value = s.Data?.GetBitmap(height: cells[symbolIndex].Size.Height - 5);
					cells[valueIndex].Value = s.Name ?? s.Value;
					cells[countIndex].Value = sum.TryGetValue(s, out int count) ? count : 0;
					if (s.Parent is null) continue;
				}
				AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
				AutoResizeColumns();
				if (RowCount != 0) FirstDisplayedScrollingRowIndex = scrollIndex.ClampEx(0, RowCount - 1);
			}
		}

		/// <summary>
		/// Symbolsに共通する親Symbolオブジェクト
		/// nullのとき、AllowDrag == trueならSymbolsはトップレベルSymbol、AllowDrag == falseならSymbolsは親が非共通
		/// </summary>
		Symbol SymbolParent { get; set; } = null;

		/// <summary>
		/// 指定したSymbolのMembersを表示し、DragDropとGroupの追加を許可する
		/// </summary>
		/// <param name="parent">Membersを表示するSymbolオブジェクト。nullの場合、何も表示せず、DragDropとGroupの追加を不許可にする</param>
		public void SetParentSymbol(Symbol parent)
		{
			bool update = SymbolParent == parent;
			int selectedIndex = update ? SelectedRowIndex : -1;
			SymbolParent = parent;
			AllowDrag = SymbolParent is not null && SymbolParent.Name is not null;
			AllowDrop = SymbolParent is not null && SymbolParent.Name is not null;
			Symbols = SymbolParent?.Members ?? new();
			SelectedRowIndex = selectedIndex;
#pragma warning disable CA2245 // Do not assign a property to itself
			ContextMenuStrip = ContextMenuStrip;
#pragma warning restore CA2245 // Do not assign a property to itself
			if (update) OnMembersUpdated(EventArgs.Empty);
		}

		/// <summary>
		/// トップレベルSymbolを表示し、DragDropとGroupの追加を許可する
		/// </summary>
		public void SetRootSymbols()
		{
			bool update = SymbolParent is null && AllowDrag;
			int selectedIndex = update ? SelectedRowIndex : -1;
			SymbolParent = null;
			AllowDrag = true;
			AllowDrop = true;
			Symbols = SymbolData.GetRootSymbols();
			SelectedRowIndex = selectedIndex;
#pragma warning disable CA2245 // Do not assign a property to itself
			ContextMenuStrip = ContextMenuStrip;
#pragma warning restore CA2245 // Do not assign a property to itself
			if (update) OnMembersUpdated(EventArgs.Empty);
		}

		/// <summary>
		/// 指定したSymbolオブジェクト群を表示し、DragDropとGroupの追加を不許可にする
		/// </summary>
		/// <param name="symbol">表示するSymbolオブジェクト。nullは除外される</param>
		public void SetNoParentSymbols(params Symbol[] symbol)
		{
			SymbolParent = null;
			AllowDrag = false;
			AllowDrop = false;
			Symbols = symbol?.Where(x => x is not null).ToList();
			SelectedRowIndex = -1;
#pragma warning disable CA2245 // Do not assign a property to itself
			ContextMenuStrip = ContextMenuStrip;
#pragma warning restore CA2245 // Do not assign a property to itself
		}

		readonly string VisibleName = "表示";
		readonly string SymbolName = "記号";
		readonly string ValueName = "値";
		readonly string CountName = "個数";

		int VisibleIndex => Columns[VisibleName].Index;
		int SymbolIndex => Columns[SymbolName].Index;
		int ValueIndex => Columns[ValueName].Index;
		int CountIndex => Columns[CountName].Index;

		/// <summary>
		/// 列の初期化がされているか否か(ParentChanged内でのみ参照)
		/// </summary>
		bool IsLoaded { get; set; } = false;
#nullable enable
		static void AddGroup_Event(object sender, EventArgs e)
		{
			if (sender is not ToolStripMenuItem item || item.GetSourceControlEx() is not SymbolDataGridView symbolDataGridView || !symbolDataGridView.AllowDrag) return;
			if (SymbolData.AddGroup(symbolDataGridView.SymbolParent, -1, "新規グループ"))
			{
				Symbol? newGroup = SymbolData.GetRootSymbols().FindLast(x => x.Name == "新規グループ");
				if (newGroup is not null) newGroup.Visible = true;
				if (symbolDataGridView.SymbolParent is null) symbolDataGridView.SetRootSymbols();
				else symbolDataGridView.SetParentSymbol(symbolDataGridView.SymbolParent);
			}
		}
#nullable restore
		ToolStripMenuItem AddGroupToolStripMenuItem { get; } = new("グループを追加する", null, AddGroup_Event);

		public SymbolDataGridView()
		{
			AllowDrag = false;
			AllowDrop = false;
			AllowUserToAddRows = false;
			AllowUserToDeleteRows = false;
			AllowUserToOrderColumns = false;
			AllowUserToResizeColumns = false;
			AllowUserToResizeRows = false;
			ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
#pragma warning disable CA2245 // Do not assign a property to itself
			ContextMenuStrip = ContextMenuStrip;
			EnableHeadersVisualStyles = false;
			DefaultCellStyle = DefaultCellStyle;
#pragma warning restore CA2245 // Do not assign a property to itself
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
				if (AllowDrag && !base.ContextMenuStrip.Items.Contains(AddGroupToolStripMenuItem)) base.ContextMenuStrip.Items.Add(AddGroupToolStripMenuItem);
				else if (!AllowDrag && base.ContextMenuStrip.Items.Contains(AddGroupToolStripMenuItem)) base.ContextMenuStrip.Items.Remove(AddGroupToolStripMenuItem);
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

		[Browsable(true)]
		public event EventHandler MembersUpdated;

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
		/// 選択されているSymbolオブジェクト
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
#nullable enable
		public Symbol? SelectedSymbol
		{
			get
			{
				if (0 <= SelectedRowIndex && SelectedRowIndex < Symbols.Count) return Symbols[SelectedRowIndex];
				else return null;
			}
			set
			{
				if (value is null) SelectedRowIndex = -1;
				else SelectedRowIndex = Symbols.IndexOf(value);
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
			if (DesignMode || IsLoaded)
			{
				base.OnParentChanged(e);
				return;
			}
			Rows.Clear();
			Columns.Clear();
			Columns.Add(new DataGridViewCheckBoxColumn() { HeaderText = VisibleName, Name = VisibleName });
			Columns.Add(new DataGridViewImageColumn() { HeaderText = SymbolName, Name = SymbolName, ImageLayout = DataGridViewImageCellLayout.Normal, Description = string.Empty, Image = new Bitmap(10, 10) });
			Columns.Add(ValueName, ValueName);
			Columns.Add(
				new DataGridViewTextBoxColumn() 
				{
					HeaderText = CountName, Name = CountName, 
					DefaultCellStyle = new(DefaultCellStyle) 
					{
						Alignment = DataGridViewContentAlignment.MiddleRight, SelectionBackColor = DefaultCellStyle.BackColor, SelectionForeColor = DefaultCellStyle.ForeColor
					}
				}
				);
			foreach (DataGridViewColumn column in Columns) column.SortMode = DataGridViewColumnSortMode.NotSortable;
			Symbols = new();
			IsLoaded = true;
			base.OnParentChanged(e);
		}

		protected override void OnFontChanged(EventArgs e)
		{
			foreach (DataGridViewColumn column in Columns) column.DefaultCellStyle.Font = Font;
			base.OnFontChanged(e);
		}

		protected override void OnCellClick(DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex != -1 && e.ColumnIndex == VisibleIndex && e.RowIndex != -1 && e.RowIndex < Symbols.Count)
			{
				Symbol symbol = Symbols[e.RowIndex];
				symbol.Visible ^= true;
				this[e.ColumnIndex, e.RowIndex].Value = symbol.Visible;
			}
			base.OnCellClick(e);
		}

		protected override void OnCellDoubleClick(DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex != -1 && e.ColumnIndex == SymbolIndex && e.RowIndex != -1 && e.RowIndex < Symbols.Count)
			{
				Symbol symbol = Symbols[e.RowIndex];
				SvgViewer.GetSingleton().SetViewing(symbol.Data);
				SvgViewer.OpenOrShowDialog(FindForm());
				if (SvgViewer.StaticDialogResult == DialogResult.OK)
				{
					symbol.Data = SvgViewer.StaticDialogReturn as SvgWrapper.SvgData;
					DataGridViewCell cell = this[e.ColumnIndex, e.RowIndex];
					cell.Value = symbol.Data?.GetBitmap(height: cell.Size.Height - 5);
				}
			}
			SelectedRowIndex = e.RowIndex;
			base.OnCellDoubleClick(e);
		}

		protected override void OnRowPostPaint(DataGridViewRowPostPaintEventArgs e)
		{
			if (e.RowIndex != SelectedRowIndex) return;
			Rectangle bounds = e.RowBounds with { X = RowHeadersVisible ? RowHeadersWidth : 0, Y = e.RowBounds.Y + 1, Width = Columns.GetColumnsWidth(DataGridViewElementStates.Visible), Height = e.RowBounds.Height - 2 };
			using Pen pen = new(System.Drawing.SystemColors.Highlight, 2.0f);
			e.Graphics.DrawRectangle(pen, bounds);
		}

		protected override void OnSelectionChanged(EventArgs e)
		{
			base.OnSelectionChanged(e);
			var selectionChanged = SelectionChanged;
			if (selectionChanged is not null) selectionChanged(this, e);
		}

		protected override void OnParentFontChanged(EventArgs e)
		{
			ContextMenuStrip.Font = Parent.Font;
			base.OnParentFontChanged(e);
		}

		/// <summary>
		/// DragDrop開始の判定に使用されるマウス座標
		/// </summary>
		Point MousePoint = Point.Empty;

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

		protected override void OnMouseUp(MouseEventArgs e)
		{
			if (AllowDrag) MousePoint = Point.Empty;
			base.OnMouseUp(e);
		}

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
						if (rowIndex != -1 && rowIndex < Symbols.Count)
						{
							Symbol selected = SelectedSymbol;
							if (DoDragDrop(Symbols[rowIndex], DragDropEffects.Move) == DragDropEffects.Move)
							{
								if (SymbolParent is null) SetRootSymbols();
								else SetParentSymbol(SymbolParent);
								SelectedSymbol = selected;
							}
						}
						MousePoint = Point.Empty;
					}
				}
			}
			base.OnMouseMove(e);
		}

		protected override void OnQueryContinueDrag(QueryContinueDragEventArgs qcdevent)
		{
			if ((qcdevent.KeyState & 2) == 2) qcdevent.Action = DragAction.Cancel;
			base.OnQueryContinueDrag(qcdevent);
		}

		protected override void OnDragEnter(DragEventArgs drgevent)
		{
			if (drgevent.Data.GetDataPresent(typeof(Symbol))) drgevent.Effect = DragDropEffects.Move;
			else drgevent.Effect = DragDropEffects.None;
			base.OnDragEnter(drgevent);
		}

		protected override void OnDragOver(DragEventArgs drgevent)
		{
			int mousepos = PointToClient(Cursor.Position).Y;
			if (mousepos > (Location.Y + (Height * 0.9)))
			{
				if (FirstDisplayedScrollingRowIndex < RowCount - 1)
				{
					++FirstDisplayedScrollingRowIndex;
				}
			}
			if (mousepos < (Location.Y + (Height * 0.05)))
			{
				if (FirstDisplayedScrollingRowIndex > 0)
				{
					--FirstDisplayedScrollingRowIndex;
				}
			}
			base.OnDragOver(drgevent);
		}

		protected override void OnDragDrop(DragEventArgs drgevent)
		{
			if (drgevent.Data.GetData(typeof(Symbol)) is Symbol symbol)
			{
				Point client = PointToClient(new(drgevent.X, drgevent.Y));
				HitTestInfo hitTestInfo = HitTest(client.X, client.Y);
				int rowIndex = hitTestInfo.RowIndex;
				if (hitTestInfo.Type == DataGridViewHitTestType.Cell || hitTestInfo.Type == DataGridViewHitTestType.None)
				{
					Symbol selected = SelectedSymbol;
					if (SymbolData.Move(symbol, SymbolParent, rowIndex))
					{
						if (SymbolParent is null) SetRootSymbols();
						else SetParentSymbol(SymbolParent);
						SelectedSymbol = selected;
					}
					else drgevent.Effect = DragDropEffects.None;
				}
			}
			base.OnDragDrop(drgevent);
		}

		protected void OnMembersUpdated(EventArgs e)
		{
			var membersUpdated = MembersUpdated;
			if (membersUpdated is not null) membersUpdated(this, e);
		}
	}
}
