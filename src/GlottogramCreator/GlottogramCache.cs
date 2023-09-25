using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WinFormsApp1
{
	/// <summary>
	/// グロットグラムに表示されている画像と位置のキャッシュ
	/// </summary>
	public static class GlottogramCache
	{
		/// <summary>
		/// MainDataから取得したグロットグラムに表示されるデータのList
		/// </summary>
		public static List<Cache> Caches { get; private set; } = new();

		/// <summary>
		/// MainDataから情報を取得し、Cachesを更新する
		/// </summary>
		public static void Update()
		{
			Caches.Clear();
			Caches = MainData.GetCaches();
		}

		/// <summary>
		/// GlottogramImage上の座標pointに描画されているCacheを取得する
		/// </summary>
		/// <param name="point">GlottogramImage上の点。PictureBoxから取得した場合、GlottogramProperty.ViewScaleで除算する必要がある。</param>
		/// <returns>座標に対応したCaches内の一要素。存在しない場合、null。</returns>
		public static Cache GetCache(PointF point)
		{
			RectangleF glottogram = GlottogramHelper.GlottogramBounds;
			float x0 = glottogram.X;
			float y0 = glottogram.Y;
			float columnWidth = GlottogramProperty.ColumnWidth;
			float rowHeight = GlottogramProperty.RowHeight;
			int columnOrigin = GlottogramData.ColumnAscendingOrder ? GlottogramData.ColumnMin : GlottogramData.ColumnMax;
			int rowOrigin = GlottogramData.RowAscendingOrder ? GlottogramData.RowMin : GlottogramData.RowMax;
			int columnCount = GlottogramData.ColumnCount;
			int rowCount = GlottogramData.RowCount;
			int columnTick = GlottogramData.ColumnTick;
			int rowTick = GlottogramData.RowTick;
			RectangleF rect = new(x0, y0, 0, 0);
			foreach (var cache in Caches.Where(x => !x.RemovedByFiltering))
			{
				int columnIndex = Math.Abs(cache.XSortValue - columnOrigin) / columnTick;
				int rowIndex = Math.Abs(cache.YSortValue - rowOrigin) / rowTick;
				Bitmap bitmap = cache.Bitmap;
				if (bitmap is null || columnIndex < 0 || columnIndex >= columnCount || rowIndex < 0 || rowIndex >= rowCount) continue;
				(float x, float y) related = MainData.GetRelatedTranslate(cache.DataIndex) is (int x, int y) tuple ? (tuple.x / 100.0f, tuple.y / 100.0f) : (0, 0);
				RectangleF tmp = rect with {
					X = rect.X + (columnIndex + related.x) * columnWidth + (columnWidth - bitmap.Width) / 2,
					Y = rect.Y + (rowIndex + related.y) * rowHeight + (rowHeight - bitmap.Height) / 2,
					Width = bitmap.Width,
					Height = bitmap.Height
				};
				if (tmp.Contains(point)) return cache;
			}
			return null;
		}
	}
}
