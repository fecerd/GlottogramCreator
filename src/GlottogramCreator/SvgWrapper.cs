using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Svg;  //SVG-net
using System.Drawing;
using System.Windows.Forms;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace WinFormsApp1
{
	public static class SvgWrapper
	{
		public class SvgData
		{
			public SvgData() { }

			/// <summary>
			/// SvgDataを作成する
			/// </summary>
			/// <param name="filePath">SVGファイルへのパス</param>
			public SvgData(string filePath) => FilePath = filePath;

			private string filePath = string.Empty;	//FilePathプロパティで使用
			private SvgDocument svgDocument = null; //読み込まれたSVGファイルの情報
			private float rotateAngle = 0.0f;

			/// <summary>
			/// SVGファイルへのパス
			/// </summary>
			public string FilePath {
				get
				{
					return filePath;
				}
				set
				{
					if (filePath != value)
					{
						filePath = value;
						try
						{
							if (System.IO.File.Exists(filePath))
							{
								svgDocument = SvgDocument.Open(filePath);
								return;
							}
						}
						catch {}
						svgDocument = null;
						filePath = string.Empty;
					}
				}
			}

			/// <summary>
			/// SVG画像全体のスケーリング。初期値は1.0f。
			/// </summary>
			public float CustomScale { get; set; } = 1.0f;

			/// <summary>
			/// 単色化する色。<see cref="System.Drawing.Color.Empty" />の場合、単色化しない。
			/// </summary>
			public Color Color { get; set; } = System.Drawing.Color.Empty;

			/// <summary>
			/// trueの場合、SVG画像全体を上下反転する。
			/// </summary>
			public bool VerticalInversion { get; set; } = false;

			/// <summary>
			/// trueの場合、SVG画像全体を左右反転する。
			/// </summary>
			public bool HorizontalInversion { get; set; } = false;

			/// <summary>
			/// SVG画像全体を回転させる角度(°)。初期値は0.0f。
			/// </summary>
			public float RotateAngle {
				get
				{
					return rotateAngle;
				}
				set
				{
					while (value < 0.0f) value += 360.0f;
					while (value > 360.0f) value -= 360.0f;
					rotateAngle = value;
				}
			}

			private SvgRectangle GetRawSize()
			{
				if (svgDocument == null) return null;
				foreach (var el in svgDocument.Descendants())
				{
					if (el is SvgRectangle && el.ID == "RawSize") return el.Clone() as SvgRectangle;
				}
				return null;
			}

			private T GetTransform<T>(string groupID) where T : Svg.Transforms.SvgTransform
			{
				if (svgDocument == null) return null;
				foreach (SvgElement el in svgDocument.Descendants())
				{
					if (el is SvgGroup && el.ID == groupID && el.Transforms != null)
					{
						foreach (Svg.Transforms.SvgTransform t in el.Transforms) if (t is T) return t as T;
						return null;
					}
				}
				return null;
			}

			private void RecalculateBounds()
			{
				SvgRectangle size = GetRawSize();
				var toCenter = GetTransform<Svg.Transforms.SvgTranslate>("ToCenterGroup");
				if (size == null || toCenter == null) return;
				size.Width *= this.CustomScale;
				size.Height *= this.CustomScale;
				float cos = MathF.Abs(MathF.Cos(RotateAngle * MathF.PI / 180.0f));
				float cos_another = MathF.Abs(MathF.Cos((90.0f - RotateAngle) * MathF.PI / 180.0f));
				svgDocument.Width = size.Width * cos + size.Height * cos_another;
				svgDocument.Height = size.Width * cos_another + size.Height * cos;
				toCenter.X = 0.5f * svgDocument.Width;
				toCenter.Y = 0.5f * svgDocument.Height;
			}

			private void SetCustomScale()
			{
				var tmp = GetTransform<Svg.Transforms.SvgScale>("ScaleGroup");
				if (tmp == null) return;
				tmp.X = CustomScale;
				tmp.Y = CustomScale;
			}

			private void SetRotateAngle()
			{
				var tmp = GetTransform<Svg.Transforms.SvgRotate>("RotateGroup");
				if (tmp != null) tmp.Angle = RotateAngle;
			}

			private void SetInversion()
			{
				var tmp = GetTransform<Svg.Transforms.SvgScale>("InversionGroup");
				if (tmp == null) return;
				tmp.X = this.HorizontalInversion ? -1 : 1;
				tmp.Y = this.VerticalInversion ? -1 : 1;
			}

			private void ChangeColor(IEnumerable<SvgElement> nodes, SvgColourServer c)
			{
				foreach (SvgElement node in nodes)
				{
					if (node.Fill != null && node.Fill != SvgPaintServer.None && node.Fill.ToString() != "White") node.Fill = c;
					if (node.Color != null && node.Color != SvgPaintServer.None) node.Color = c;
					if (node.Stroke != null && node.Stroke != SvgPaintServer.None) node.Stroke = c;
					ChangeColor(node.Descendants(), c);
				}
			}

			private void SetSingleColor()
			{
				if (svgDocument == null) return;
				SvgColourServer svgColourServer = new(this.Color);
				ChangeColor(svgDocument.Descendants(), svgColourServer);
			}

			private void GetBitmap_Common()
			{
				if (this.Color != System.Drawing.Color.Empty) SetSingleColor();
				SetInversion();
				SetRotateAngle();
				SetCustomScale();
				RecalculateBounds();
			}

			/// <summary>
			/// SVG画像をBitmap形式で取得する。
			/// </summary>
			/// <param name="scale">拡大率</param>
			/// <returns>幅と高さをscale倍したSVG画像</returns>
			public Bitmap GetBitmap(float scale)
			{
				if (svgDocument is null) return new Bitmap(100, 100);
				GetBitmap_Common();
				int width = (int)(svgDocument.Width * scale);
				return svgDocument.Draw(width == 0 ? 1 : width, 0);
			}

			/// <summary>
			/// SVG画像をBitmap形式で取得する。
			/// </summary>
			/// <param name="width">0以外の場合、取得する画像の幅。</param>
			/// <param name="height">0以外の場合、取得する画像の高さ。</param>
			/// <returns>指定した幅と高さにスケーリングされたSVG画像。引数の一方が0のとき、縦横比を維持してスケーリングする。</returns>
			public Bitmap GetBitmap(int width = 0, int height = 0)
			{
				if (svgDocument is null) return new Bitmap(width == 0 ? 1 : width, height == 0 ? 1 : height);
				GetBitmap_Common();
				if (width == 0 && height == 0) return svgDocument.Draw(1, 1);
				else return svgDocument.Draw(width, height);
			}
		}

		/// <summary>
		/// GAJ用記号のサイズを統一する
		/// </summary>
		/// <param name="filePath">SVGファイルのパス</param>
		/// <returns>編集後のファイル名, エラーの場合、null</returns>
		public static string Func(string filePath)
		{
			try
			{
				SvgDocument doc = SvgDocument.Open(filePath);

				SvgGroup centerGroup = new();
				centerGroup.ID = "ToCenterGroup";
				centerGroup.Transforms = new();
				centerGroup.Transforms.Add(new Svg.Transforms.SvgTranslate(doc.Width / 2.0f, doc.Height / 2.0f));

				SvgGroup translateGroup = new();
				translateGroup.ID = "TranslateGroup";
				translateGroup.Transforms = new();
				translateGroup.Transforms.Add(new Svg.Transforms.SvgTranslate(0, 0));

				SvgGroup scaleGroup = new();
				scaleGroup.ID = "ScaleGroup";
				scaleGroup.Transforms = new();
				scaleGroup.Transforms.Add(new Svg.Transforms.SvgScale(1, 1));

				SvgGroup inversionGroup = new();
				inversionGroup.ID = "InversionGroup";
				inversionGroup.Transforms = new();
				inversionGroup.Transforms.Add(new Svg.Transforms.SvgScale(1, 1));

				SvgGroup rotateGroup = new();
				rotateGroup.ID = "RotateGroup";
				rotateGroup.Transforms = new();
				rotateGroup.Transforms.Add(new Svg.Transforms.SvgRotate(0));

				SvgGroup originGroup = new();
				originGroup.ID = "ToOriginGroup";
				originGroup.Transforms = new();
				originGroup.Transforms.Add(new Svg.Transforms.SvgTranslate(-doc.Width / 2, -doc.Height / 2));

				SvgRectangle rectangle = new();
				rectangle.ID = "RawSize";
				rectangle.X = 0;
				rectangle.Y = 0;
				rectangle.Width = doc.Width;
				rectangle.Height = doc.Height;
				rectangle.Color = null;
				rectangle.Stroke = null;
				rectangle.Fill = SvgColourServer.None;

				originGroup.Children.Add(rectangle);

				foreach (var c in doc.Children)
				{
					if (c is SvgDefinitionList || (c is SvgRectangle && (c as SvgRectangle).ID.Contains("スライス"))) continue;
					originGroup.Children.Add(c);

				}
				rotateGroup.Children.Add(originGroup);
				inversionGroup.Children.Add(rotateGroup);
				scaleGroup.Children.Add(inversionGroup);
				translateGroup.Children.Add(scaleGroup);
				centerGroup.Children.Add(translateGroup);

				SvgDocument new_doc = new() { Width = doc.Width, Height = doc.Height };
				new_doc.Children.Add(centerGroup);

				string new_filePath = System.IO.Path.GetFullPath(filePath);

				using System.IO.TextWriter writer = new System.IO.StreamWriter(new_filePath);
				writer.Write(new_doc.GetXML());
				return new_filePath;
			}
			catch
			{
				return null;
			}
		}
	}
}
