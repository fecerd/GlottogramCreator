using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Xml.Linq;

namespace WinFormsApp1
{
	/// <summary>
	/// 文字列とSvgDataの組み合わせ
	/// </summary>
	public class Symbol
	{
		string value = null;
		SvgWrapper.SvgData data = null;
		bool hasScale = false;
		int width = 0;
		int height = 0;
		float scale = 1.0f;
		Bitmap bitmap = null;

		SvgWrapper.SvgData elipsisData = null;
		bool hasElipsisScale = false;
		int elipsisWidth = 0;
		int elipsisHeight = 0;
		float elipsisScale = 1.0f;
		float elipsisRelatedY = 0.0f;
		Bitmap elipsisBitmap = null;

		/// <summary>
		/// このSymbolからトップレベルSymbolまでのVisibleがすべてtrueならtrue。それ以外の場合、false。
		/// </summary>
		bool VisibleRoot => Parent is null ? Visible : Visible && Parent.VisibleRoot;

		/// <summary>
		/// SVG画像情報を持つRootからこのSymbolまでで一番トップレベルに近いSymbolオブジェクト
		/// </summary>
		public Symbol SymbolicRoot => Parent?.SymbolicRoot ?? (Data is null ? null : this);
		
		/// <summary>
		/// 描画されるかどうかを切り替える
		/// </summary>
		public bool Visible { get; set; } = true;

		/// <summary>
		/// このSymbolに置き換えられるSymbolオブジェクトのグループ
		/// </summary>
		public List<Symbol> Members { get; private set; } = new();

		/// <summary>
		/// このSymbolをMembersの要素に持つSymbol
		/// </summary>
		public Symbol Parent { get; set; } = null;

		/// <summary>
		/// グループ名
		/// </summary>
		public string Name { get; set; } = null;

		/// <summary>
		/// 文字列
		/// </summary>
		public string Value
		{
			get => value;
			set
			{
				if (bitmap is not null) bitmap.Dispose();
				bitmap = null;
				this.value = value;
			}
		}

		/// <summary>
		/// 凡例描画時の変換モード
		/// </summary>
		public ConvertMode ConvertMode { get; set; } = ConvertMode.None;

		/// <summary>
		/// 凡例描画時の変換モードがCustomのとき使用される文字列
		/// </summary>
		public string CustomName { get; set; } = string.Empty;

		/// <summary>
		/// SVG画像情報
		/// </summary>
		public SvgWrapper.SvgData Data
		{
			get => data;
			set
			{
				if (bitmap is not null) bitmap.Dispose();
				bitmap = null;
				if (value is null) data = null;
				else
				{
					if (data is null) data = new();
					data.Color = value.Color;
					data.CustomScale = value.CustomScale;
					data.FilePath = value.FilePath;
					data.HorizontalInversion = value.HorizontalInversion;
					data.RotateAngle = value.RotateAngle;
					data.VerticalInversion = value.VerticalInversion;
				}
			}
		}

		/// <summary>
		/// <para>Bitmapの更新に使用するプロパティを切り替えるフラグ</para>
		/// <para>trueのとき、Scaleを使用する。falseのとき、Width, Heightを使用する</para>
		/// </summary>
		public bool HasScale
		{
			get => hasScale;
			set
			{
				if (hasScale != value)
				{
					if (bitmap is not null) bitmap.Dispose();
					bitmap = null;
				}
				hasScale = value;
			}
		}

		/// <summary>
		/// Bitmapの幅
		/// </summary>
		public int Width
		{
			get => width;
			set
			{
				if (value < 0) value = 0;
				if (width != value)
				{
					if (bitmap is not null) bitmap.Dispose();
					bitmap = null;
				}
				width = value;
			}
		}

		/// <summary>
		/// Bitmapの高さ
		/// </summary>
		public int Height
		{
			get => height;
			set
			{
				if (value < 0) value = 0;
				if (height != value)
				{
					if (bitmap is not null) bitmap.Dispose();
					bitmap = null;
				}
				height = value;
			}
		}

		/// <summary>
		/// Bitmapのスケール(元のSVG画像の大きさを1.0fとする)
		/// </summary>
		public float Scale
		{
			get => scale;
			set
			{
				if (value <= 0) value = 1.0f;
				if (scale != value)
				{
					if (bitmap is not null) bitmap.Dispose();
					bitmap = null;
				}
				scale = value;
			}
		}

		/// <summary>
		/// このインスタンスが表すBitmapオブジェクト。IsChangedがtrueのとき、自動で更新される
		/// </summary>
		public Bitmap Bitmap
		{
			get
			{
				if (Parent is not null)
				{
					if (!VisibleRoot) return null;
					Parent.HasScale = HasScale;
					Parent.Height = Height;
					Parent.Scale = Scale;
					Parent.Width = Width;
					if (Parent.Bitmap is Bitmap b) return b;
				}
				if (Data is null || !Visible) return null;
				if (bitmap is null)
				{
					Bitmap tmp;
					if (HasScale) tmp = Data.GetBitmap(Scale);
					else tmp = Data.GetBitmap(Width, Height);
					bitmap = tmp.TrimEx(Color.White);
					tmp.Dispose();
				}
				return bitmap;
			}
		}

		/// <summary>
		/// 省略記号の有効/無効
		/// </summary>
		public bool ElipsisEnabled { get; set; } = false;

		/// <summary>
		/// 省略記号のSVG画像情報
		/// </summary>
		public SvgWrapper.SvgData ElipsisData
		{
			get => elipsisData;
			set
			{
				elipsisBitmap?.Dispose();
				elipsisBitmap = null;
				if (value is null) elipsisData = null;
				else
				{
					if (elipsisData is null) elipsisData = new();
					elipsisData.Color = value.Color;
					elipsisData.CustomScale = value.CustomScale;
					elipsisData.FilePath = value.FilePath;
					elipsisData.HorizontalInversion = value.HorizontalInversion;
					elipsisData.RotateAngle = value.RotateAngle;
					elipsisData.VerticalInversion = value.VerticalInversion;
				}
			}
		}

		/// <summary>
		/// 省略記号がScaleとWidth, Heightのどちらを使用するか
		/// </summary>
		public bool HasElipsisScale
		{
			get => hasElipsisScale;
			set
			{
				if (hasElipsisScale != value)
				{
					elipsisBitmap?.Dispose();
					elipsisBitmap = null;
				}
				hasElipsisScale = value;
			}
		}

		/// <summary>
		/// 省略記号の幅
		/// </summary>
		public int ElipsisWidth
		{
			get => elipsisWidth;
			set
			{
				if (value < 0) value = 0;
				if (elipsisWidth != value)
				{
					elipsisBitmap?.Dispose();
					elipsisBitmap = null;
				}
				elipsisWidth = value;
			}
		}

		/// <summary>
		/// 省略記号の高さ
		/// </summary>
		public int ElipsisHeight
		{
			get => elipsisHeight;
			set
			{
				if (value < 0) value = 0;
				if (elipsisHeight != value)
				{
					elipsisBitmap?.Dispose();
					elipsisBitmap = null;
				}
				elipsisHeight = value;
			}
		}

		/// <summary>
		/// 省略記号のスケール
		/// </summary>
		public float ElipsisScale
		{
			get => elipsisScale;
			set
			{
				if (value <= 0) value = 1.0f;
				if (elipsisScale != value)
				{
					elipsisBitmap?.Dispose();
					elipsisBitmap = null;
				}
				elipsisScale = value;
			}
		}

		/// <summary>
		/// 省略記号が表示されるy座標。セルの中央からの相対ピクセル数(下方向が正)
		/// </summary>
		public float ElipsisRelatedY
		{
			get => elipsisRelatedY;
			set
			{
				if (elipsisRelatedY != value)
				{
					elipsisBitmap?.Dispose();
					elipsisBitmap = null;
				}
				elipsisRelatedY = value;
			}
		}

		/// <summary>
		/// 省略記号のビットマップ
		/// </summary>
		public Bitmap ElipsisBitmap
		{
			get
			{
				if (Parent is not null)
				{
					if (!VisibleRoot) return null;
					Parent.HasElipsisScale = HasScale;
					Parent.ElipsisHeight = Height;
					Parent.ElipsisScale = Scale;
					Parent.ElipsisWidth = Width;
					if (Parent.ElipsisBitmap is Bitmap b) return b;
				}
				if (!ElipsisEnabled || ElipsisData is null || !Visible) return null;
				if (elipsisBitmap is null)
				{
					if (HasElipsisScale) elipsisBitmap = ElipsisData.GetBitmap(ElipsisScale)?.TrimEx(Color.White);
					else elipsisBitmap = ElipsisData.GetBitmap(ElipsisWidth, ElipsisHeight)?.TrimEx(Color.White);
				}
				return elipsisBitmap;
			}
		}

		/// <summary>
		/// 第二引数のSymbolオブジェクトと再帰的に取得したグループメンバを、Listに追加する
		/// </summary>
		/// <param name="symbols">SymbolオブジェクトのList</param>
		/// <param name="symbol">追加するSymbolオブジェクト</param>
		static void DeploySymbols(List<Symbol> symbols, Symbol symbol)
		{
			if (symbol is null || symbols.Contains(symbol)) return;
			symbols.Add(symbol);
			foreach (Symbol s in symbol.Members) DeploySymbols(symbols, s);
		}

		/// <summary>
		/// このSymbolと再帰的に取得したグループメンバを取得する
		/// </summary>
		/// <returns>このSymbolと再帰的に取得したグループメンバのList</returns>
		public List<Symbol> GetThisAndAllMembers()
		{
			List<Symbol> ret = new();
			ret.Add(this);
			foreach (Symbol s in Members) DeploySymbols(ret, s);
			return ret;
		}

		public void Dispose()
		{
			foreach (Symbol child in Members) child.Dispose();
			Members.Clear();
			Parent = null;
			Data = null;
			ElipsisData = null;
		}
	}

	/// <summary>
	/// 文字列とSvgDataの組み合わせを保管するクラス
	/// </summary>
	static class SymbolData
	{
		/// <summary>
		/// 外部ファイルから&lt;class name="SymbolData"&gt;&lt;/class&gt;内のデータを読み取り、
		/// このクラスのデータとして登録する
		/// </summary>
		/// <param name="uri">このクラスのデータが保存されたXMLファイル</param>
		public static void Load(string uri)
		{
			XDocument xDocument = XDocumentExtend.LoadEx(uri);
			IEnumerable<XElement> properties = xDocument?.GetRootElementByNameEx("class", "name", nameof(SymbolData))?.Elements();
			if (properties is null) return;
			foreach (var el in properties)
			{
				string propertyName = el.GetAttributeValueEx("name") ?? string.Empty;
				if (propertyName == nameof(Symbols))
				{
					Symbols.Clear();
					Symbols = el.GetListEx() as List<Symbol> ?? new();
					static void func(Symbol symbol)
					{
						foreach (Symbol m in symbol.Members)
						{
							m.Parent = symbol;
							func(m);
						}
					};
					foreach (Symbol symbol in Symbols) func(symbol);
				}
			}
		}

		/// <summary>
		/// このクラスのプロパティをLoad関数で読み込み可能なXElementオブジェクトに出力する
		/// </summary>
		/// <returns>このクラスの情報が記述されたXElementオブジェクト</returns>
		public static XElement Output()
		{
			XElement ret = new("class", new XAttribute("name", nameof(SymbolData)));
			ret.Add(Symbols.ToPropertyEx(nameof(Symbols)));
			return ret;
		}

		public static void Reset()
		{
			foreach (Symbol symbol in Symbols) symbol.Dispose();
			Symbols.Clear();
		}

		/// <summary>
		/// ValueKeyが変化したとき、Symbolを追加する
		/// </summary>
		public static void Update() => MainData.GetSymbolSum();

		/// <summary>
		/// グループに属さないトップレベルのSymbolオブジェクトのList
		/// </summary>
		static List<Symbol> Symbols { get; set; } = new();

		/// <summary>
		/// 第二引数のSymbolオブジェクトと再帰的に取得したグループメンバを、Listに追加する
		/// </summary>
		/// <param name="symbols">SymbolオブジェクトのList</param>
		/// <param name="symbol">追加するSymbolオブジェクト</param>
		static void DeploySymbols(List<Symbol> symbols, Symbol symbol)
		{
			if (symbol is null || symbols.Contains(symbol)) return;
			symbols.Add(symbol);
			foreach (Symbol s in symbol.Members) DeploySymbols(symbols, s);
		}

		/// <summary>
		/// 登録されているすべてのSymbolのListを取得する
		/// </summary>
		/// <returns>すべてのSymbolのList</returns>
		public static List<Symbol> GetSymbolList()
		{
			List<Symbol> ret = new();
			foreach (Symbol s in Symbols) DeploySymbols(ret, s);
			return ret;
		}

		/// <summary>
		/// トップレベルのSymbolオブジェクトの配列を取得する
		/// </summary>
		/// <returns>トップレベルのSymbolオブジェクトの配列</returns>
		public static List<Symbol> GetRootSymbols() => Symbols.ToList();

		/// <summary>
		/// 指定したSymbolオブジェクトの順序をそれぞれ一つ後ろに移動する
		/// </summary>
		/// <param name="symbols">移動するSymbolオブジェクト(複数選択可)</param>
		public static void SwapNext(Symbol[] symbols)
		{
			if (symbols is null || !symbols.Any()) return;
			foreach (Symbol symbol in symbols)
			{
				if (symbol.Parent is not Symbol parent)
				{
					int index = Symbols.IndexOf(symbol);
					if (index != -1 && Symbols.Last() != symbol && !symbols.Contains(Symbols[index + 1])) Symbols.Reverse(index, 2);
				}
				else
				{
					int index = parent.Members.IndexOf(symbol);
					if (index != -1 && parent.Members.Last() != symbol && !symbols.Contains(parent.Members[index + 1])) parent.Members.Reverse(index, 2);
				}
			}
		}

		/// <summary>
		/// 指定したSymbolオブジェクトの順序をそれぞれ一つ前に移動する
		/// </summary>
		/// <param name="symbols">移動するSymbolオブジェクト(複数選択可)</param>
		public static void SwapPrev(Symbol[] symbols)
		{
			if (symbols is null || !symbols.Any()) return;
			foreach (Symbol symbol in symbols)
			{
				if (symbol.Parent is not Symbol parent)
				{
					int index = Symbols.IndexOf(symbol);
					if (index > 0 && !symbols.Contains(Symbols[--index])) Symbols.Reverse(index, 2);
				}
				else
				{
					int index = parent.Members.IndexOf(symbol);
					if (index > 0 && !symbols.Contains(parent.Members[--index])) parent.Members.Reverse(index, 2);
				}
			}
		}

		/// <summary>
		/// トップレベルSymbolオブジェクトを、Symbol[]型引数の順序に並び変える
		/// </summary>
		/// <param name="orderedValues">
		/// <para>並び変えたい順序のSymbol型配列。トップレベルに含まれないSymbolが混ざっていてもよい</para>
		/// <para>この配列に含まれないトップレベルSymbolオブジェクトはソート後の末尾に配置される</para>
		/// </param>
		public static void OrderByArray(Symbol[] orderedSymbols)
		{
			List<Symbol> tmp = new();
			List<Symbol> symbols = Symbols;
			foreach (var s in orderedSymbols) if (symbols.Where(x => x == s).FirstOrDefault() is Symbol t) tmp.Add(t);
			if (tmp.Count != symbols.Count) foreach (Symbol s in symbols) if (!tmp.Contains(s)) tmp.Add(s);
			Symbols = tmp;
		}

		/// <summary>
		/// 新たなグループを追加する
		/// </summary>
		/// <param name="dstParent">グループの追加先。nullのとき、トップレベルにグループを追加する</param>
		/// <param name="index">グループを追加するインデックス。範囲外のとき、最後尾に追加する</param>
		/// <param name="groupName">グループ名。nullのとき、この関数は何もしない</param>
		/// <param name="members">グループのメンバー。このSymbolオブジェクトがnullもしくは再帰的なメンバーにdstParentを持つ場合、除外される</param>
		public static bool AddGroup(Symbol dstParent, int index, string groupName, params Symbol[] members)
		{
			if (groupName is null) return false;
			Symbol group = new() { Name = groupName, Visible = true, Parent = dstParent };
			if (dstParent is null) Symbols.Insert(index < 0 ? Symbols.Count : index.ClampEx(0, Symbols.Count), group);
			else dstParent.Members.Insert(index < 0 ? dstParent.Members.Count : index.ClampEx(0, dstParent.Members.Count), group);
			if (members is null) return true;
			members = members.Where(x => x is not null).ToArray();
			foreach (Symbol s in members) Move(s, group, -1);
			if (!group.Members.Where(x => x.Visible).Any()) group.Visible = false;
			return true;
		}

		/// <summary>
		/// グループを解除する
		/// </summary>
		/// <param name="group">解除するグループ</param>
		public static void RemoveGroup(Symbol group)
		{
			if (group is null || group.Name is null) return;
			Symbol newParent = group.Parent;
			if (newParent is null)
			{
				int index = Symbols.IndexOf(group);
				if (index == -1) return;
				int i = 0;
				foreach (Symbol s in group.Members)
				{
					s.Parent = null;
					Symbols.Insert(index + i++, s);
				}
				Symbols.Remove(group);
				group.Members.Clear();
			}
			else
			{
				int index = newParent.Members.IndexOf(group);
				if (index == -1) return;
				int i = 0;
				foreach (Symbol s in group.Members)
				{
					s.Parent = newParent;
					newParent.Members.Insert(index + i++, s);
					if (!newParent.Visible && s.Visible) newParent.Visible = true;
				}
				newParent.Members.Remove(group);
				group.Members.Clear();
			}
		}

		/// <summary>
		/// 個数0の値を表すSymbolを削除する。グループは削除されない
		/// </summary>
		public static void RemoveNotFoundValue()
		{
			List<Symbol> symbols = GetSymbolList();
			Dictionary<Symbol, int> sum = MainData.GetSymbolSum(false);
			foreach (Symbol s in symbols.Where(x => !sum.ContainsKey(x)))
			{
				if (s.Name is null)
				{
					if (s.Parent is Symbol parent) parent.Members.Remove(s);
					else Symbols.Remove(s);
					s.Parent = null;
					s.Data = null;
					s.ElipsisData = null;
				}
			}
		}

		/// <summary>
		/// <para>文字列と記号を表すSVG画像情報の組み合わせをトップレベルSymbolオブジェクトとして登録する</para>
		/// <para>すでに同じ文字列が登録されている場合、SVG画像情報だけ変更する</para>
		/// </summary>
		/// <param name="value">登録する文字列</param>
		/// <param name="svgData">登録するSVG画像情報</param>
		public static void Add(string value, SvgWrapper.SvgData svgData)
		{
			List<Symbol> symbols = GetSymbolList();
			foreach (Symbol s in symbols)
			{
				if (s.Value != value) continue;
				s.Data = svgData;
				return;
			}
			Symbol tmp = new();
			tmp.Value = value;
			tmp.Data = svgData;
			Symbols.Add(tmp);
		}

		/// <summary>
		/// Symbolオブジェクトの親子関係を変更する
		/// </summary>
		/// <param name="src">移動するSymbolオブジェクト</param>
		/// <param name="dstParent">移動先のMembersプロパティを持つSymbolオブジェクト。nullのとき、SymbolData.Symbolsに移動する</param>
		/// <param name="index">移動先のインデックス。範囲外の場合、最後尾に追加される</param>
		public static bool Move(Symbol src, Symbol dstParent, int index)
		{
			if (src is null || src == dstParent) return false;
			List<Symbol> tmp = new();
			foreach (Symbol s in src.Members) DeploySymbols(tmp, s);
			if (tmp.Contains(dstParent)) return false;
			if (src.Parent is not null) src.Parent.Members.Remove(src);
			else Symbols.Remove(src);
			src.Parent = dstParent;
			List<Symbol> members = dstParent?.Members ?? Symbols;
			index = index < 0 ? members.Count : index.ClampEx(0, members.Count);
			members.Insert(index, src);
			return true;
		}

		/// <summary>
		/// 文字列に対応するSymbolオブジェクトを取得する。
		/// </summary>
		/// <param name="value">文字列</param>
		/// <returns>引数valueと同じ文字列を持つ、初めに見つかったSymbolオブジェクト。存在しない場合、nullを返す</returns>
		public static Symbol GetSymbol(string value) => value is null ? null : GetSymbolList().Where(x => x.Value == value).FirstOrDefault();

		/// <summary>
		/// 登録されている文字列と記号の組み合わせから、valueに対応する記号を返す
		/// </summary>
		/// <param name="value">記号に変換する文字列</param>
		/// <param name="width">描画される記号の幅。heightが0の場合、この値に合わせて記号をスケーリングする</param>
		/// <param name="height">描画される記号の高さ。widthが0の場合、この値に合わせて記号をスケーリングする</param>
		/// <returns>指定した幅と高さに引き伸ばして描画したBitmap。valueが登録されていない場合、null</returns>
		public static Bitmap GetBitmap(string value, int width = 0, int height = 0)
		{
			if (GetSymbol(value) is not Symbol symbol) return null;
			symbol.HasScale = false;
			symbol.Width = width;
			symbol.Height = height;
			return symbol.Bitmap;
		}

		/// <summary>
		/// 登録されている文字列と記号の組み合わせから、valueに対応する記号を返す
		/// </summary>
		/// <param name="value">記号に変換する文字列</param>
		/// <param name="scale">記号を描画するスケール。元のSVGファイルの大きさを基準とする。</param>
		/// <returns>scale倍で描画されたBitmap。valueが登録されていない場合、null</returns>
		public static Bitmap GetBitmap(string value, float scale)
		{
			if (GetSymbol(value) is not Symbol symbol) return null;
			symbol.HasScale = true;
			symbol.Scale = scale;
			return symbol.Bitmap;
		}

		/// <summary>
		/// 登録されている文字列と記号の組み合わせから、valueに対応する記号を水平に結合して返す
		/// </summary>
		/// <param name="values">記号に変換する文字列の配列</param>
		/// <param name="scale">記号を描画するスケール。元のSVGファイルの大きさを基準とする。</param>
		/// <returns>scale倍で描画し、結合されたBitmap。valuesが一つも登録されていない場合、null</returns>
		public static Bitmap GetBitmap(string[] values, float scale, out bool isMultiple)
		{
			isMultiple = false;
			var symbols = GetSymbolList().Where(x => !x.Members.Any());
			List<Symbol> added = new(values.Length);
			List<(Bitmap symbol, (Bitmap bitmap, float relatedY) elipsis)> bitmaps = new(values.Length);
			foreach (string value in values)
			{
				if (symbols.Where(x => x.Value == value).FirstOrDefault() is not Symbol tmp) continue;
				if (added.Contains(tmp.SymbolicRoot)) continue;
				else added.Add(tmp.SymbolicRoot);
				tmp.HasScale = true;
				tmp.Scale = scale;
				tmp.HasElipsisScale = true;
				tmp.ElipsisScale = scale;
				if (tmp.Bitmap is Bitmap bitmap) bitmaps.Add((bitmap, (tmp.ElipsisBitmap, tmp.ElipsisRelatedY)));
			}
			IEnumerable<Bitmap> symbolBitmaps = bitmaps.Where(x => x.elipsis.bitmap is null).Select(x => x.symbol);
			if (symbolBitmaps.Any())
			{
				isMultiple = symbolBitmaps.Count() > 1;
				Bitmap sTmp = symbolBitmaps.ToArray().JointEx(Color.White);
				foreach (var b in bitmaps.Where(x => x.elipsis.bitmap is not null))
				{
					Bitmap t = new BitmapFragment(sTmp, Point.Empty).Joint(
						Color.White,
						true,
						new BitmapFragment(b.elipsis.bitmap, new Point(sTmp.Width, (int)((sTmp.Height - b.elipsis.bitmap.Height) * b.elipsis.relatedY)))
						);
					sTmp.Dispose();
					sTmp = t;
					t = null;
				}
				return sTmp;
			}
			else
			{
				var hasElipsis = bitmaps.Where(x => x.elipsis.bitmap is not null);
				if (hasElipsis.Any())
				{
					Bitmap sTmp = hasElipsis.FirstOrDefault().symbol.Clone() as Bitmap;
					foreach (var b in hasElipsis.Skip(1))
					{
						Bitmap t = new BitmapFragment(sTmp, Point.Empty).Joint(
							Color.White,
							true,
							new BitmapFragment(b.elipsis.bitmap, new Point(sTmp.Width, (int)((sTmp.Height - b.elipsis.bitmap.Height) * b.elipsis.relatedY)))
							);
						sTmp.Dispose();
						sTmp = t;
						t = null;
					}
					return sTmp;
				}
				else return null;
			}
		}

		/// <summary>
		/// 登録されている文字列と記号の組み合わせから、valueに対応するSVG画像情報を返す
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static SvgWrapper.SvgData GetSvgData(string value) => GetSymbol(value)?.Data;
	}

	static partial class FromXElement
	{
		public static SvgWrapper.SvgData GetSvgDataEx(this XElement element, SvgWrapper.SvgData defaultValue)
		{
			if (defaultValue is null) defaultValue = new();
			SvgWrapper.SvgData ret = new();
			foreach (var el in CommonGetEx(element))
			{
				string propertyName = el.GetAttributeValueEx("name") ?? string.Empty;
				if (propertyName == nameof(defaultValue.Color)) ret.Color = el.GetColorEx(defaultValue.Color);
				else if (propertyName == nameof(defaultValue.CustomScale)) ret.CustomScale = el.Value.GetFloatEx(defaultValue.CustomScale);
				else if (propertyName == nameof(defaultValue.FilePath)) ret.FilePath = el.Value ?? defaultValue.FilePath;
				else if (propertyName == nameof(defaultValue.HorizontalInversion)) ret.HorizontalInversion = el.Value.GetBoolEx(defaultValue.HorizontalInversion);
				else if (propertyName == nameof(defaultValue.RotateAngle)) ret.RotateAngle = el.Value.GetFloatEx(defaultValue.RotateAngle);
				else if (propertyName == nameof(defaultValue.VerticalInversion)) ret.VerticalInversion = el.Value.GetBoolEx(defaultValue.VerticalInversion);
			}
			return ret;
		}

		public static Symbol GetSymbolEx(this XElement element, Symbol defaultValue)
		{
			if (defaultValue is null) defaultValue = new();
			Symbol ret = new();
			foreach (var el in CommonGetEx(element))
			{
				string propertyName = el.GetAttributeValueEx("name") ?? string.Empty;
				if (propertyName == nameof(defaultValue.Data)) ret.Data = el.GetSvgDataEx(defaultValue.Data);
				else if (propertyName == nameof(defaultValue.HasScale)) ret.HasScale = el.Value.GetBoolEx(defaultValue.HasScale);
				else if (propertyName == nameof(defaultValue.Height)) ret.Height = el.Value.GetIntEx(defaultValue.Height);
				else if (propertyName == nameof(defaultValue.Scale)) ret.Scale = el.Value.GetFloatEx(defaultValue.Scale);
				else if (propertyName == nameof(defaultValue.Value) && el.Value != string.Empty) ret.Value = el.Value;
				else if (propertyName == nameof(defaultValue.Width)) ret.Width = el.Value.GetIntEx(defaultValue.Width);
				else if (propertyName == nameof(defaultValue.Members) && el.GetListEx() is List<Symbol> l) foreach (Symbol s in l) ret.Members.Add(s);
				else if (propertyName == nameof(defaultValue.Name)) ret.Name = el.Value ?? string.Empty;
				else if (propertyName == nameof(defaultValue.ConvertMode)) ret.ConvertMode = el.GetEnumEx<ConvertMode>(defaultValue.ConvertMode);
				else if (propertyName == nameof(defaultValue.CustomName) && el.Value != string.Empty) ret.CustomName = el.Value;
				else if (propertyName == nameof(defaultValue.Visible)) ret.Visible = el.Value.GetBoolEx(defaultValue.Visible);
				else if (propertyName == nameof(defaultValue.ElipsisEnabled)) ret.ElipsisEnabled = el.Value.GetBoolEx(defaultValue.ElipsisEnabled);
				else if (propertyName == nameof(defaultValue.ElipsisData)) ret.ElipsisData = el.GetSvgDataEx(defaultValue.ElipsisData);
				else if (propertyName == nameof(defaultValue.HasElipsisScale)) ret.HasElipsisScale = el.Value.GetBoolEx(defaultValue.HasElipsisScale);
				else if (propertyName == nameof(defaultValue.ElipsisHeight)) ret.ElipsisHeight = el.Value.GetIntEx(defaultValue.ElipsisHeight);
				else if (propertyName == nameof(defaultValue.ElipsisScale)) ret.ElipsisScale = el.Value.GetFloatEx(defaultValue.ElipsisScale);
				else if (propertyName == nameof(defaultValue.ElipsisWidth)) ret.ElipsisWidth = el.Value.GetIntEx(defaultValue.ElipsisWidth);
				else if (propertyName == nameof(defaultValue.ElipsisRelatedY)) ret.ElipsisRelatedY = el.Value.GetFloatEx(defaultValue.ElipsisRelatedY);
			}
			return ret;
		}
	}

	static partial class ToXElement
	{
		public static XElement ToXElementEx(this SvgWrapper.SvgData value, string elementName, string varName)
		{
			XElement ret = CommonToXElement(elementName, varName, nameof(SvgWrapper.SvgData));
			ret.Add(
				value.Color.ToPropertyEx(nameof(value.Color)),
				value.CustomScale.ToPropertyEx(nameof(value.CustomScale)),
				value.FilePath.ToPropertyEx(nameof(value.FilePath)),
				value.HorizontalInversion.ToPropertyEx(nameof(value.HorizontalInversion)),
				value.RotateAngle.ToPropertyEx(nameof(value.RotateAngle)),
				value.VerticalInversion.ToPropertyEx(nameof(value.VerticalInversion))
				);
			return ret;
		}

		public static XElement ToXElementEx(this Symbol value, string elementName, string varName)
		{
			XElement ret = CommonToXElement(elementName, varName, nameof(Symbol));
			ret.Add(
				value.Data?.ToPropertyEx(nameof(value.Data)),
				value.HasScale.ToPropertyEx(nameof(value.HasScale)),
				value.Height.ToPropertyEx(nameof(value.Height)),
				value.Scale.ToPropertyEx(nameof(value.Scale)),
				value.Value?.ToPropertyEx(nameof(value.Value)),
				value.Width.ToPropertyEx(nameof(value.Width)),
				value.Members.ToPropertyEx(nameof(value.Members)),
				value.Name?.ToPropertyEx(nameof(value.Name)),
				value.ConvertMode.ToPropertyEx(nameof(value.ConvertMode)),
				value.CustomName?.ToPropertyEx(nameof(value.CustomName)),
				value.Visible.ToPropertyEx(nameof(value.Visible)),
				value.ElipsisEnabled.ToPropertyEx(nameof(value.ElipsisEnabled)),
				value.ElipsisData?.ToPropertyEx(nameof(value.ElipsisData)),
				value.HasElipsisScale.ToPropertyEx(nameof(value.HasElipsisScale)),
				value.ElipsisHeight.ToPropertyEx(nameof(value.ElipsisHeight)),
				value.ElipsisScale.ToPropertyEx(nameof(value.ElipsisScale)),
				value.ElipsisWidth.ToPropertyEx(nameof(value.ElipsisWidth)),
				value.ElipsisRelatedY.ToPropertyEx(nameof(value.ElipsisRelatedY))
				);
			return ret;
		}
	}

	static partial class ToProperty
	{
		public static XElement ToPropertyEx(this SvgWrapper.SvgData value, string varName) => value.ToXElementEx("property", varName);
		public static XElement ToPropertyEx(this Symbol value, string varName) => value.ToXElementEx("property", varName);
	}
}
