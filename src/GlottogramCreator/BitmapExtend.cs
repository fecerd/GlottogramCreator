using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace WinFormsApp1
{
	static class BitmapExtend
	{
		public static Bitmap JointEx(this Bitmap bitmap, Bitmap[] sources, Color fillColor, bool isHorizontal = true, bool alignCenter = true)
		{
			Bitmap[] tmp = new Bitmap[sources.Length + 1];
			tmp[0] = bitmap;
			for (int i = 1; i < tmp.Length; ++i) tmp[i] = sources[i - 1];
			return tmp.JointEx(fillColor, isHorizontal, alignCenter);
		}

		/// <summary>
		/// 配列内のBitmapを一列に結合した新たなBitmapを取得する。(配列内のBitmapに副作用はない)
		/// </summary>
		/// <param name="bitmaps">結合するBitmapの配列</param>
		/// <param name="fillColor">大きさの違いを埋める色</param>
		/// <param name="isTransparentColor">trueのときfillColorを透明色に設定する</param>
		/// <param name="isHorizontal">trueのとき、左から右へ結合する。falseのとき、上から下へ結合する</param>
		/// <param name="alignCenter">trueのとき、中央揃えにする。falseのとき左上を基準とする</param>
		/// <returns>新たに作成されたBitmap</returns>
		public static Bitmap JointEx(this Bitmap[] bitmaps, Color fillColor, bool isTransparentColor = true, bool isHorizontal = true, bool alignCenter = true)
		{
			Bitmap[] array = bitmaps.Where(x => x is not null).ToArray();
			if (array.Length == 0) return null;
			else if (array.Length == 1)
			{
				Bitmap r = array[0].Clone() as Bitmap;
				if (isTransparentColor) r.MakeTransparent(fillColor);
				return r;
			}
			int width = 0;
			int height = 0;
			if (isHorizontal)
			{
				foreach (Bitmap b in array)
				{
					width += b.Width;
					height = height < b.Height ? b.Height : height;
				}
			}
			else
			{
				foreach (Bitmap b in array)
				{
					width = width < b.Width ? b.Width : width;
					height += b.Height;
				}
			}
			Bitmap ret = new(width, height);
			using Graphics graphics = Graphics.FromImage(ret);
			graphics.Clear(fillColor);
			Point point = new(0, 0);
			if (isHorizontal)
			{
				foreach (Bitmap b in array)
				{
					if (alignCenter) point.Y = (ret.Height - b.Height) / 2;
					graphics.DrawImage(b, point);
					point.X += b.Width;
				}
			}
			else
			{
				foreach (Bitmap b in array)
				{
					if (alignCenter) point.X = (ret.Width - b.Width) / 2;
					graphics.DrawImage(b, point);
					point.Y += b.Height;
				}
			}
			if (isTransparentColor) ret.MakeTransparent(fillColor);
			return ret;
		}

		public static Bitmap TrimEx(this Bitmap bitmap, Color trimColor)
		{
			if (bitmap is null) return bitmap.Clone() as Bitmap;
			int step = Bitmap.GetPixelFormatSize(bitmap.PixelFormat);
			if (step != 24 && step != 32) return bitmap.Clone() as Bitmap;
			var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, bitmap.PixelFormat);
			var bytes = Math.Abs(bitmapData.Stride) * bitmap.Height;
			var rgbValues = new byte[bytes];
			System.Runtime.InteropServices.Marshal.Copy(bitmapData.Scan0, rgbValues, 0, bytes);
			bitmap.UnlockBits(bitmapData);

			byte b = trimColor.B, g = trimColor.G, r = trimColor.R, a = trimColor.A;

			int x0 = bitmap.Width - 1;
			int y0 = bitmap.Height - 1;
			int x1 = 0;
			int y1 = 0;

			int width = bitmap.Width;
			if (step == 24)
			{
				for (int i = 0; i < bytes; i += 3)
				{
					if (rgbValues[i] != b || rgbValues[i + 1] != g || rgbValues[i + 2] != r)
					{
						int x = i / 3 % width;
						int y = i / 3 / width;
						if (x0 > x) x0 = x;
						if (y0 > y) y0 = y;
						if (x1 < x) x1 = x;
						if (y1 < y) y1 = y;
					}
				}
			}
			else if (step == 32)
			{
				for (int i = 0; i < bytes; i += 4)
				{
					if (rgbValues[i + 3] == 0) continue;
					else if (rgbValues[i] != b || rgbValues[i + 1] != g || rgbValues[i + 2] != r)
					{
						int x = i / 4 % width;
						int y = i / 4 / width;
						if (x0 > x) x0 = x;
						if (y0 > y) y0 = y;
						if (x1 < x) x1 = x;
						if (y1 < y) y1 = y;
					}
				}
			}
			if (x0 > x1 || y0 > y1) return bitmap.Clone() as Bitmap;
			Rectangle rc = new Rectangle(x0, y0, x1 - x0 + 1, y1 - y0 + 1);
			Bitmap ret = new(rc.Width, rc.Height);
			using Graphics graphics = Graphics.FromImage(ret);
			graphics.DrawImage(bitmap, new Rectangle(0, 0, ret.Width, ret.Height), rc, GraphicsUnit.Pixel);
			return ret;
		}

		public static Bitmap JointEx(this Bitmap bitmap, Bitmap source, float relatedY, Color fillColor, bool isTransparentColor = true)
		{
			if (bitmap is null)
			{
				if (source is null) throw new ArgumentNullException();
				else return source.Clone() as Bitmap;
			}
			else if (source is null) return bitmap.Clone() as Bitmap;
			else return new BitmapFragment(bitmap, new Point(0, 0)).Joint(
				fillColor,
				isTransparentColor,
				new BitmapFragment(source, new Point(bitmap.Width, (int)((bitmap.Height - source.Height) * relatedY)))
				);
		}
	}

	struct BitmapFragment
	{
		Bitmap Bitmap { get; set; } = null;
		Point Point { get; set; } = Point.Empty;

		public BitmapFragment(Bitmap bitmap, Point point)
		{
			Bitmap = bitmap;
			Point = point;
		}

		public Bitmap Joint(Color fillColor, bool isTransparentColor, params BitmapFragment[] bitmapFragment)
		{
			IEnumerable<BitmapFragment> bitmapFragments = new[] { this }.Union(bitmapFragment.Where(x => x.Bitmap is not null));
			BitmapFragment first = bitmapFragments.FirstOrDefault();
			if (first.Bitmap is null)
			{
				Bitmap tmp = new(1, 1);
				using Graphics g = Graphics.FromImage(tmp);
				g.Clear(fillColor);
				if (isTransparentColor) tmp.MakeTransparent(fillColor);
				return tmp;
			}
			int top = first.Point.Y, left = first.Point.X, right = first.Point.X + first.Bitmap.Width, bottom = first.Point.Y + first.Bitmap.Height;
			foreach (BitmapFragment fragment in bitmapFragments)
			{
				if (left > fragment.Point.X) left = fragment.Point.X;
				if (top > fragment.Point.Y) top = fragment.Point.Y;
				int R = fragment.Point.X + fragment.Bitmap.Width;
				if (right < R) right = R;
				int B = fragment.Point.Y + fragment.Bitmap.Height;
				if (bottom < B) bottom = B;
			}
			Bitmap ret = new(right - left, bottom - top);
			using Graphics graphics = Graphics.FromImage(ret);
			graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			graphics.Clear(fillColor);
			foreach (BitmapFragment f in bitmapFragments)
			{
				graphics.DrawImage(f.Bitmap, new Point(f.Point.X - left, f.Point.Y - top));
			}
			if (isTransparentColor) ret.MakeTransparent(fillColor);
			return ret;
		}
	}
}
