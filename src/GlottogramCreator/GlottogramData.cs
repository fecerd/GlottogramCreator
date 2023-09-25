using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WinFormsApp1
{
	/// <summary>
	/// Form2で設定される列と行のデータ
	/// </summary>
	static class GlottogramData
	{
		public static void Load(string uri)
		{
			XDocument xDocument = XDocumentExtend.LoadEx(uri);
			XElement element = xDocument?.GetRootElementByNameEx("class", "name", nameof(GlottogramData));
			if (element is null) return;
			foreach (var el in element.Elements())
			{
				if (el.GetAttributeValueEx("name") is not string propertyName) continue;
				if (propertyName == nameof(ColumnKey)) ColumnKey = el.Value;
				else if (propertyName == nameof(ColumnSortKey)) ColumnSortKey = el.Value;
				else if (propertyName == nameof(ColumnRange) && el.GetTupleEx() is ValueTuple<int, int> c) ColumnRange = c;
				else if (propertyName == nameof(ColumnAscendingOrder)) ColumnAscendingOrder = el.Value.GetBoolEx(ColumnAscendingOrder);
				else if (propertyName == nameof(ColumnTick)) ColumnTick = el.Value.GetIntEx(ColumnTick);
				else if (propertyName == nameof(RowKey)) RowKey = el.Value;
				else if (propertyName == nameof(RowSortKey)) RowSortKey = el.Value;
				else if (propertyName == nameof(RowRange) && el.GetTupleEx() is ValueTuple<int, int> r) RowRange = r;
				else if (propertyName == nameof(RowAscendingOrder)) RowAscendingOrder = el.Value.GetBoolEx(RowAscendingOrder);
				else if (propertyName == nameof(RowTick)) RowTick = el.Value.GetIntEx(RowTick);
				else if (propertyName == nameof(ValueKeys) && el.GetListEx() is List<string> s) ValueKeys = s;
			}
		}

		public static XElement Output()
		{
			XElement ret = new("class", new XAttribute("name", nameof(GlottogramData)));
			ret.Add(ColumnKey.ToPropertyEx(nameof(ColumnKey)));
			ret.Add(ColumnSortKey.ToPropertyEx(nameof(ColumnSortKey)));
			ret.Add(ColumnRange.ToPropertyEx(nameof(ColumnRange)));
			ret.Add(ColumnAscendingOrder.ToPropertyEx(nameof(ColumnAscendingOrder)));
			ret.Add(ColumnTick.ToPropertyEx(nameof(ColumnTick)));
			ret.Add(RowKey.ToPropertyEx(nameof(RowKey)));
			ret.Add(RowSortKey.ToPropertyEx(nameof(RowSortKey)));
			ret.Add(RowRange.ToPropertyEx(nameof(RowRange)));
			ret.Add(RowAscendingOrder.ToPropertyEx(nameof(RowAscendingOrder)));
			ret.Add(RowTick.ToPropertyEx(nameof(RowTick)));
			ret.Add(ValueKeys.ToPropertyEx(nameof(ValueKeys)));
			return ret;
		}

		public static void Reset()
		{
			ColumnKey = string.Empty;
			ColumnSortKey = string.Empty;
			ColumnRange = (0, 0);
			ColumnAscendingOrder = true;
			ColumnTick = 1;
			RowKey = string.Empty;
			RowSortKey = string.Empty;
			RowRange = (0, 0);
			RowAscendingOrder = true;
			RowTick = 1;
			ValueKeys.Clear();
		}

		static string columnKey = string.Empty;
		static string columnSortKey = string.Empty;
		static (int Min, int Max) columnRange = (0, 0);
		static int columnTick = 1;
		static string rowKey = string.Empty;
		static string rowSortKey = string.Empty;
		static (int Min, int Max) rowRange = (0, 0);
		static int rowTick = 1;

		/// <summary>
		/// 列ヘッダーに表示されるキー
		/// </summary>
		public static string ColumnKey { get => columnKey; set => columnKey = value ?? string.Empty; }

		/// <summary>
		/// グロットグラム上の列座標を特定するキー
		/// </summary>
		public static string ColumnSortKey { get => columnSortKey; set => columnSortKey = value ?? string.Empty; }

		/// <summary>
		/// 列の範囲(最小値と最大値)
		/// </summary>
		public static (int Min, int Max) ColumnRange { get => columnRange; set => columnRange = value.Min <= value.Max ? value : (value.Max, value.Min); }

		/// <summary>
		/// 列の最小値
		/// </summary>
		public static int ColumnMin => ColumnRange.Min;

		/// <summary>
		/// 列の最大値
		/// </summary>
		public static int ColumnMax => ColumnRange.Max;

		/// <summary>
		/// 列を昇順で描画する
		/// </summary>
		public static bool ColumnAscendingOrder { get; set; } = true;

		/// <summary>
		///列の目盛りを描画する間隔 
		/// </summary>
		public static int ColumnTick { get => columnTick; set => columnTick = value < 1 ? 1 : value; }

		/// <summary>
		/// 行ヘッダーに表示されるキー
		/// </summary>
		public static string RowKey { get => rowKey; set => rowKey = value ?? string.Empty; }

		/// <summary>
		/// グロットグラム上の行座標を特定するキー
		/// </summary>
		public static string RowSortKey { get => rowSortKey; set => rowSortKey = value ?? string.Empty; }

		/// <summary>
		/// 行の範囲(最小値と最大値)
		/// </summary>
		public static (int Min, int Max) RowRange { get => rowRange; set => rowRange = value.Min <= value.Max ? value : (value.Max, value.Min); }

		/// <summary>
		/// 行の最小値
		/// </summary>
		public static int RowMin => RowRange.Min;

		/// <summary>
		/// 行の最大値
		/// </summary>
		public static int RowMax => RowRange.Max;

		/// <summary>
		/// 行を昇順で描画する
		/// </summary>
		public static bool RowAscendingOrder { get; set; } = true;

		/// <summary>
		///行の目盛りを描画する間隔 
		/// </summary>
		public static int RowTick { get => rowTick; set => rowTick = value < 1 ? 1 : value; }

		/// <summary>
		/// 描画する値のキー
		/// </summary>
		public static List<string> ValueKeys { get; private set; } = new();

		/// <summary>
		/// 列数(columnMin, columnMax, columnTickより算出)
		/// </summary>
		public static int ColumnCount => (int)Math.Round(((float)ColumnMax - (float)ColumnMin) / (float)ColumnTick, MidpointRounding.ToPositiveInfinity) + 1;

		/// <summary>
		/// 行数(rowMin, rowMax, rowTickより算出)
		/// </summary>
		public static int RowCount => (int)Math.Round(((float)RowMax - (float)RowMin) / (float)RowTick, MidpointRounding.ToPositiveInfinity) + 1;
	}
}
