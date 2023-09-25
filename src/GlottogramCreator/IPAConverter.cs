using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WinFormsApp1
{
	static class KanaConverter
	{
		/// <summary>
		/// 全角ひらがなの文字に濁点・半濁点を加える
		/// </summary>
		/// <param name="c">対象の全角ひらがなの文字</param>
		/// <param name="mark">濁点もしくは半濁点</param>
		/// <returns>濁点・半濁点を加えた全角ひらがなの文字。濁点・半濁点が加えられない場合、第二引数をそのままmarkに返す</returns>
		static (char c, char mark) PlusMarkHiragana(char c, char mark)
		{
			if (mark == 0x3099)	//濁点
			{
				if (c == 0x3046) return ((char)0x3090, '\0');   //う
				else if (0x304b <= c && c <= 0x3061) return ((char)(c % 2 == 0 ? c : c + 1), '\0');  //か～ち
				else if (0x3064 <= c && c <= 0x3068) return ((char)(c % 2 == 0 ? c + 1 : c), '\0'); //つ～と
				else if (0x306f <= c && c <= 0x307b) return ((char)(c % 3 == 0 ? c + 1 : c), '\0'); //は～ほ
				else if (c == 0x309d) return ((char)0x309e, '\0');	//ゝ
			}
			else if (mark == 0x309a)	//半濁点
			{
				if (0x306f <= c && c <= 0x307b) return ((char)(c % 3 == 0 ? c + 2 : c), '\0'); //は～ほ
			}
			return (c, mark);
		}

		/// <summary>
		/// 全角カタカナの文字に濁点・半濁点を加える
		/// </summary>
		/// <param name="c">対象の全角カタカナの文字</param>
		/// <param name="mark">濁点もしくは半濁点</param>
		/// <returns>濁点・半濁点を加えた全角カタカナの文字。濁点・半濁点が加えられない場合、第二引数をそのままmarkに返す</returns>
		static (char c, char mark) PlusMarkKatakana(char c, char mark)
		{
			if (mark == 0x3099) //濁点
			{
				if (c == 0x30a6) return ((char)0x30f4, '\0');   //ウ
				else if (0x30ab <= c && c <= 0x30c1) return ((char)(c % 2 == 0 ? c : c + 1), '\0'); //カ～チ
				else if (0x30c4 <= c && c <= 0x30c8) return ((char)(c % 2 == 0 ? c + 1 : c), '\0'); //ツ～ト
				else if (0x30cf <= c && c <= 0x30db) return ((char)(c % 3 == 0 ? c + 1 : c), '\0'); //ハ～ホ
				else if (0x30ef < c && c <= 0x30f2) return ((char)(c + 8), '\0');   //ワ～ヲ
				else if (c == 0x30fd) return ((char)0x30fe, '\0');	//ヽ
			}
			else if (mark == 0x309a)    //半濁点
			{
				if (0x30cf <= c && c <= 0x30db) return ((char)(c % 3 == 0 ? c + 2 : c), '\0'); //ハ～ホ
			}
			return (c, mark);
		}

		/// <summary>
		/// 全角ひらがなを全角カタカナに変換する。
		/// </summary>
		/// <param name="c">変換する文字</param>
		/// <param name="extend">濁点(0x3099)・半濁点(0x309a)</param>
		/// <returns>
		/// 入力に対応する全角カタカナの文字。
		/// 第一引数の変換結果と第二引数の濁点が結合可能なとき、cは結合後の文字を、extendは'\0'を返す。
		/// </returns>
		static (char c, char extend) HiraganaToKatakana(char c, char extend = '\0')
		{
			if ((0x3041 <= c && c <= 0x3096) || c == 0x309d || c == 0x309e) return PlusMarkKatakana((char)(c + 0x60), extend);
			else return PlusMarkKatakana(c, extend);
		}

		/// <summary>
		/// 全角カタカナを全角ひらがなに変換する。
		/// </summary>
		/// <param name="c">変換する文字</param>
		/// <param name="extend">濁点(0x3099)・半濁点(0x309a)</param>
		/// <returns>
		/// 入力に対応する全角ひらがなの文字。
		/// 第一引数がヷ, ヸ, ヹ, ヺのとき、extendは濁点(0x3099)を返す。それ以外の場合、第二引数をそのまま返す。
		/// </returns>
		static (char c, char extend) KatakanaToHiragana(char c, char extend = '\0')
		{
			if ((0x30a1 <= c && c <= 0x30f6) || c == 0x30fd || c == 0x30fe) return ((char)(c - 0x60), extend);
			else if (0x30f7 <= c && c <= 0x30fa) return ((char)(c - 0x68), (char)0x3099);	//ヷ～ヺ
			else return (c, extend);
		}

		/// <summary>
		/// <para>記号はｰ, ﾞ, ﾟ, ｡, ｢, ｣, ､, ･が全角に変換される</para>
		/// </summary>
		/// <param name="c"></param>
		/// <param name="extend"></param>
		/// <returns></returns>
		static (char c, char extend) HalfKatakanaToKatakana(char c, char extend = '\0')
		{
			extend = (char)(extend == 0xff9e ? 0x3099 : extend == 0xff9f ? 0x309a : '\0');
			if (c == 0xff66) return PlusMarkKatakana((char)0x30f2, extend); //ヲ
			else if (0xff67 <= c && c <= 0xff6b) return ((char)(0x30a1 + (c - 0xff67) * 2), extend);  //ァ～ォ
			else if (0xff6c <= c && c <= 0xff6e) return ((char)(0x30e3 + (c - 0xff6c) * 2), extend);  //ャ～ョ
			else if (c == 0xff6f) return ((char)0x30c3, extend);  //ッ
			else if (c == 0xff70) return ((char)0x30fc, extend);    //ー
			else if (0xff71 <= c && c <= 0xff75) return PlusMarkKatakana((char)(0x30a2 + (c - 0xff71) * 2), extend);    //ア～オ
			else if (0xff76 <= c && c <= 0xff81) return PlusMarkKatakana((char)(0x30ab + (c - 0xff76) * 2), extend);    //カ～チ
			else if (0xff82 <= c && c <= 0xff84) return PlusMarkKatakana((char)(0x30c4 + (c - 0xff82) * 2), extend);    //ツ～ト
			else if (0xff85 <= c && c <= 0xff89) return ((char)(0x30ca + (c - 0xff85)), extend);  //ナ～ノ
			else if (0xff8a <= c && c <= 0xff8e) return PlusMarkKatakana((char)(0x30cf + (c - 0xff8a) * 3), extend);    //ハ～ホ
			else if (0xff8f <= c && c <= 0xff93) return ((char)(0x30de + (c - 0xff8f)), extend);  //マ～モ
			else if (0xff94 <= c && c <= 0xff96) return ((char)(0x30e4 + (c - 0xff94) * 2), extend);  //ヤ～ヨ
			else if (0xff97 <= c && c <= 0xff9b) return ((char)(0x30e9 + (c - 0xff97)), extend);  //ラ～ロ
			else if (c == 0xff9c) return PlusMarkKatakana((char)0x30ef, extend);    //ワ
			else if (c == 0xff9d) return ((char)0x30f3, extend);    //ン
			else if (c == 0xff9e) return ((char)0x3099, '\0');  //濁点(結合文字)
			else if (c == 0xff9f) return ((char)0x309a, '\0');  //半濁点(結合文字)
			else if (0xff61 <= c && c <= 0xff65)    //半角記号
			{
				if (c == 0xff61) return ('。', extend);
				else if (c == 0xff62) return ('「', extend);
				else if (c == 0xff63) return ('」', extend);
				else if (c == 0xff64) return ('、', extend);
				else if (c == 0xff65) return ('・', extend);
			}
			return (c, extend);
		}

		/// <summary>
		/// 全角カタカナを半角カタカナに変換する。
		/// ヮ, ヰ, ヱ, ヵ, ヶ, ヸ, ヹ, ヽ, ヾは変換しない。
		/// 記号はー, ゛, ゜, 。, 「, 」, 、, ・が半角に変換される。
		/// </summary>
		/// <param name="c">変換する文字</param>
		/// <param name="extend">濁点(0x3099)・半濁点(0x309a)</param>
		/// <returns>
		/// 入力に対応する半角カタカナの文字。
		/// 第一引数が濁点・半濁点を含む文字の場合、cは清音文字、extendは濁点・半濁点を返す。それ以外の場合、extendは第二引数をそのまま返す。
		/// </returns>
		static (char c, char extend) KatakanaToHalfKatakana(char c, char extend = '\0')
		{
			extend = (char)(extend == 0x3099 ? 0xff9e : extend == 0x309a ? 0xff9f : '\0');
			if (0x30a1 <= c && c <= 0x30aa) //ァ～オ
			{
				if (c % 2 == 0) return ((char)(0xff71 + (c - 0x30a2) / 2), extend); //ア～オ
				else return ((char)(0xff67 + (c - 0x30a1) / 2), extend);    //ァ～ォ
			}
			else if (0x30ab <= c && c <= 0x30c2)    //カ～ヂ
			{
				if (c % 2 == 0) return ((char)(0xff76 + (c - 0x30ac) / 2), (char)0xff9e);   //ガ～ヂ
				else return ((char)(0xff76 + (c - 0x30ab) / 2), extend);    //カ～チ
			}
			else if (c == 0x30c3) return ((char)0xff6f, extend);    //ッ
			else if (0x30c4 <= c && c <= 0x30c9)    //ツ～ド
			{
				if (c % 2 == 0) return ((char)(0xff82 + (c - 0x30c4) / 2), extend); //ツ～ト
				else return ((char)(0xff82 + (c - 0x30c5) / 2), (char)0xff9e);  //ヅ～ド
			}
			else if (0x30ca <= c && c <= 0x30ce) return ((char)(0xff85 + (c - 0x30ca)), extend);    //ナ～ノ
			else if (0x30cf <= c && c <= 0x30dd)    //ハ～ポ
			{
				int mod = c % 3;
				if (mod == 0) return ((char)(0xff8a + (c - 0x30cf) / 3), extend); //ハ～ホ
				else if (mod == 1) return ((char)(0xff8a + (c - 0x30d0) / 3), (char)0xff9e);    //バ～ボ
				else if (mod == 2) return ((char)(0xff8a + (c - 0x30d1) / 3), (char)0xff9f);    //パ～ポ
			}
			else if (0x30de <= c && c <= 0x30e2) return ((char)(0xff8f + (c - 0x30de)), extend);    //マ～モ
			else if (0x30e3 <= c && c <= 0x30e8)    //ャ～ヨ
			{
				if (c % 2 == 0) return ((char)(0xff94 + (c - 0x30e4) / 2), extend); //ヤ～ヨ
				else return ((char)(0xff6c + (c - 0x30e3) / 2), extend);    //ャ～ョ
			}
			else if (0x30e9 <= c && c <= 0x30ed) return ((char)(0xff97 + (c - 0x30e9)), extend);
			else if (c == 0x30ef) return ((char)0xff9c, extend);    //ワ
			else if (c == 0x30f2) return ((char)0xff66, extend);    //ヲ
			else if (c == 0x30f3) return ((char)0xff9d, extend);    //ン
			else if (c == 0x30f4) return ((char)0xff73, (char)0xff9e);  //ヴ
			else if (c == 0x30f7) return ((char)0xff9c, (char)0xff9e);  //ヷ
			else if (c == 0x30fa) return ((char)0xff66, (char)0xff9e);  //ヺ
			else if (c == 0x30fc) return ((char)0xff70, extend);	//ー
			else if (c == '。') return ((char)0xff61, extend);
			else if (c == '「') return ((char)0xff62, extend);
			else if (c == '」') return ((char)0xff63, extend);
			else if (c == '、') return ((char)0xff64, extend);
			else if (c == '・') return ((char)0xff65, extend);
			else if (c == 0x3099) return ((char)0xff9e, '\0');  //゛
			else if (c == 0x309a) return ((char)0xff9f, '\0');  //゜
			return (c, extend);
		}

		/// <summary>
		/// markが全角濁点もしくは全角半濁点のとき、trueを返す
		/// </summary>
		static bool IsZenkakuMark(char mark) => mark == 0x3099 || mark == 0x309a;

		/// <summary>
		/// 文字列内の全角カタカナと半角カタカナを全角ひらがなに置き換えた文字列を生成する。
		/// 一部の半角記号(ｰ, ﾞ, ﾟ, ｡, ｢, ｣, ､, ･)も全角記号に置き換えられる。
		/// </summary>
		/// <param name="src">対象の文字列</param>
		/// <returns>新たに生成された文字列</returns>
		public static string ToHiragana(string src)
		{
			char[] array = src.ToCharArray();
			List<char> list = new(array.Length * 2);
			for (int i = 0, length = array.Length; i < length; ++i)
			{
				(char, char) tmp = HalfKatakanaToKatakana(array[i]);
				tmp = KatakanaToHiragana(tmp.Item1, tmp.Item2);
				if (IsZenkakuMark(tmp.Item1))
				{
					tmp = PlusMarkHiragana(list.Last(), tmp.Item1);
					list[list.Count - 1] = tmp.Item1;
					if (tmp.Item2 != '\0') list.Add(tmp.Item2);
				}
				else
				{
					list.Add(tmp.Item1);
					if (tmp.Item2 != '\0') list.Add(tmp.Item2);
				}
			}
			return new string(list.ToArray());
		}

		/// <summary>
		/// 文字列内の半角カタカナと全角ひらがなを全角カタカナに置き換えた文字列を生成する。
		/// 一部の半角記号(ｰ, ﾞ, ﾟ, ｡, ｢, ｣, ､, ･)も全角記号に置き換えられる。
		/// </summary>
		/// <param name="src">対象の文字列</param>
		/// <returns>新たに生成された文字列</returns>
		public static string ToKatakana(string src)
		{
			char[] array = src.ToCharArray();
			List<char> list = new(array.Length * 2);
			for (int i = 0, length = array.Length; i < length; ++i)
			{
				(char, char) tmp = HalfKatakanaToKatakana(array[i]);
				tmp = HiraganaToKatakana(tmp.Item1, tmp.Item2);
				if (IsZenkakuMark(tmp.Item1))
				{
					tmp = PlusMarkKatakana(list.Last(), tmp.Item1);
					list[list.Count - 1] = tmp.Item1;
					if (tmp.Item2 != '\0') list.Add(tmp.Item2);
				}
				else
				{
					list.Add(tmp.Item1);
					if (tmp.Item2 != '\0') list.Add(tmp.Item2);
				}
			}
			return new string(list.ToArray());
		}

		/// <summary>
		/// 文字列内の全角ひらがなと全角カタカナを半角カタカナに置き換えた文字列を生成する。
		/// ゎ, ゐ, ゑ, ゕ, ゖ, ゝ, ゞは全角カタカナに変換され、ヮ, ヰ, ヱ, ヵ, ヶ, ヸ, ヹ, ヽ, ヾは変換しない。
		/// 一部の全角記号(ー, ゛, ゜, 。, 「, 」, 、, ・)も半角記号に置き換えられる。
		/// </summary>
		/// <param name="src">対象の文字列</param>
		/// <returns>新たに生成された文字列</returns>
		public static string ToHankakuKatakana(string src)
		{
			char[] array = src.ToCharArray();
			List<char> list = new(array.Length * 2);
			for (int i = 0, length = array.Length; i < length; ++i)
			{
				(char, char) tmp = HiraganaToKatakana(array[i]);
				tmp = KatakanaToHalfKatakana(tmp.Item1, tmp.Item2);
				list.Add(tmp.Item1);
				if (tmp.Item2 != '\0') list.Add(tmp.Item2);
			}
			return new string(list.ToArray());
		}
	}

	static class IPAConverter
	{
		static IEnumerable<XElement> elements = new List<XElement>();
		static IEnumerable<string> followings = new List<string>();
		static IEnumerable<XElement> kana = new List<XElement>();

		public static uint ConvertID { get; set; } = 0;

		static IPAConverter()
		{
			XDocument document = XDocumentExtend.LoadEx(@"Setting\IPAConvert.xml");
			elements = document?.Root?.Elements() ?? elements;
			followings = elements.Where(x => x.Name == "following").Select(x => x.Value);
			kana = elements.Descendants("kana");
		}

		public static void Reset() => ConvertID = 0;

		/// <summary>
		/// IEnumerable&lt;string&gt; followingに含まれているか調べる
		/// </summary>
		/// <param name="c">検索する文字</param>
		/// <returns>引数がIEnumerable&lt;string&gt; followingに含まれているとき、true</returns>
		static bool IsFollowingCharacter(char c)
		{
			return followings.Where(x => x.StartsWith(c)).Any();
		}

		/// <summary>
		/// 立っているビットの数を取得する
		/// </summary>
		/// <param name="bit">対象のビット列</param>
		/// <returns>引数のビット列で立っているビットの数</returns>
		static int BitCount(uint bit)
		{
			int ret = 0;
			for (; bit != 0; ++ret) bit &= bit - 1;
			return ret;
		}

		/// <summary>
		/// 排他的論理和の否定(XNOR)と等価なビット演算を行う
		/// </summary>
		/// <param name="lhs">ビット列</param>
		/// <param name="rhs">ビット列</param>
		/// <returns>引数にXNOR演算を行った結果</returns>
		static uint XNOR(uint lhs, uint rhs) => (lhs & rhs) | (~lhs & ~rhs);

		/// <summary>
		/// [内部関数]文字をIPAに変換する
		/// </summary>
		/// <param name="c">変換する文字</param>
		/// <returns>変換後の文字</returns>
		static string ToIPA_Internal(string c)
		{
			XElement el = kana.Where(x => x.Value == c).FirstOrDefault();
			if (el is null) return string.Empty;
			IEnumerable<XElement> ipas = el.Parent?.Elements("ipa").Where(x => x.Attribute("id") is not null);
			if (!ipas.Any()) return c;
			else return ipas.OrderByDescending(x => BitCount(XNOR(x.GetAttributeValueEx("id")?.GetUIntEx() ?? 0, ConvertID))).FirstOrDefault()?.Value ?? c;
		}

		/// <summary>
		/// 文字列をIPA表記に変換する。
		/// </summary>
		/// <param name="src">変換する文字列</param>
		/// <param name="format">IPAを整形するか否か</param>
		/// <remarks>IPA表記への変換の前に全角カタカナへの変換が行われる。</remarks>
		/// <returns>変換後の文字列</returns>
		public static string ToIPA(string src, bool format = true)
		{
			src = KanaConverter.ToKatakana(src);
			string ret = string.Empty;
			string c = string.Empty;
			char[] array = src.ToCharArray();
			for (int i = 0, length = array.Length; i < length; ++i)
			{
				if (c == string.Empty || IsFollowingCharacter(array[i]))
				{
					c += array[i];
					if (i + 1 < length && IsFollowingCharacter(array[i + 1])) continue;
				}
				string result = ToIPA_Internal(c);
				char[] tmp = new char[c.Length];
				while (result == string.Empty && c.Length > 1)
				{
					tmp[c.Length - 1] = c[c.Length - 1];
					c = c.Remove(0, c.Length - 1);
					result = ToIPA_Internal(c);
				}
				if (result == string.Empty && !tmp.Where(x => x != default(char)).Any()) tmp = c.ToArray();
				ret += result + new string(tmp.Where(x => x != default(char)).ToArray());
				c = string.Empty;
			}
			return format ? IPAFormatter.Format(ret) : ret;
		}
	}

	static class IPAFormatter
	{
		static IEnumerable<XElement> rules = new List<XElement>();
		static IEnumerable<XElement> chars = new List<XElement>();

		public static uint FormatID { get; set; } = 0;

		static IPAFormatter()
		{
			XDocument document = XDocumentExtend.LoadEx(@"Setting\IPAFormat.xml");
			rules = document?.Root?.Elements("rule") ?? rules;
			chars = rules.Descendants("char");
		}

		public static void Reset() => FormatID = 0;

		static string InternalFunction(string src, int index, XElement parent, string elementName, bool multiple)
		{
			string ret = string.Empty;
			IEnumerable<XElement> elements = parent.Elements(elementName).Where(x => (x.GetAttributeValueEx("id")?.GetUIntEx() ?? 0u) is uint u && (u == 0 || u == (u & FormatID)));
			foreach (XElement el in elements)
			{
				string[] pre = el.Elements("prefix").Select(x => x.Value).ToArray();
				string sub = src.Substring(0, index);
				foreach (string s in pre)
				{
					if (sub.EndsWith(s) || s == string.Empty)
					{
						if (multiple) ret += el.Elements("result").FirstOrDefault()?.Value ?? string.Empty;
						else return el.Elements("result").FirstOrDefault()?.Value ?? string.Empty + src[index];
					}
				}
				string[] post = el.Elements("postfix").Select(x => x.Value).ToArray();
				sub = src.Substring(index + 1);
				foreach (string s in post)
				{
					if (sub.StartsWith(s) || s == string.Empty)
					{
						if (multiple) ret += el.Elements("result").FirstOrDefault()?.Value ?? string.Empty;
						else return el.Elements("result").FirstOrDefault()?.Value ?? string.Empty + src[index];
					}
				}
			}
			if (multiple) return ret;
			else return string.Empty + src[index];
		}

		/// <summary>
		/// IPA表記の文字列をさらに整形する。
		/// </summary>
		/// <param name="src">整形する文字列</param>
		/// <returns>整形後の文字列</returns>
		public static string Format(string src)
		{
			if (string.IsNullOrEmpty(src)) return src;
			string ret = string.Empty;
			char[] array = src.ToCharArray();
			for (int i = 0, length = array.Length; i < length; ++i)
			{
				char tmp = array[i];
				if (chars.Where(x => x.Value[0] == tmp).FirstOrDefault()?.Parent is not XElement parent) ret += tmp;
				else
				{
					string replace = InternalFunction(src, i, parent, "replace", false);
					string prefix = InternalFunction(src, i, parent, "addprefix", true);
					string postfix = InternalFunction(src, i, parent, "addpostfix", true);
					ret += prefix + replace + postfix;
				}
			}
			return ret;
		}
	}

	public enum ConvertMode
	{
		None,
		Hiragana,
		Katakana,
		HalfKatakana,
		IPA,
		Custom
	}

	static partial class ToEnumName
	{
		static string ToEnumNameEx(ConvertMode value, int mode)
		{
			return value switch
			{
				ConvertMode.None => "変換しない",
				ConvertMode.Hiragana => "ひらがな",
				ConvertMode.Katakana => "カタカナ",
				ConvertMode.HalfKatakana => "半角カタカナ",
				ConvertMode.IPA => "IPA表記",
				ConvertMode.Custom => "カスタム",
				_ => "表示エラー"
			};
		}
	}
}
