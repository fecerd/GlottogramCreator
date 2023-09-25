using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Drawing;

namespace WinFormsApp1
{
	/// <summary>
	/// このプログラムで扱うメインデータ
	/// </summary>
	static class MainData
	{
		static List<Dictionary<string, string>> data = new();
		static List<Dictionary<string, string>> Data { get => data; set { Filters.Clear(); data = value; } } //一話者のデータをDictionary<string, string>に格納したもののリスト(全話者データ)
		static List<string> m_keys = new(); //話者名、性別、項目名などの見出し(重複なし)
		static bool m_isLoaded = false; //m_keysとDataが正常に読み込めている場合、true
		static (int x, int y)[] m_related = Array.Empty<(int x, int y)>();   //話者ごとの追加情報(グロットグラム上の座標からの相対移動値)
		static List<Filter> Filters { get; set; } = new();  //フィルター
		static List<bool> Views { get; set; } = new();	//話者ごとの表示/非表示設定

		/// <summary>
		/// フィルタリングされた話者のデータ
		/// </summary>
		static IEnumerable<Dictionary<string, string>> FilteredData
		{
			get
			{
				List<Dictionary<string, string>> ret = new();
				FilteredIndex.Clear();
				for (int i = 0, end = Data.Count; i < end; ++i)
				{
					Dictionary<string, string> result = Filters.TryGetData(Data[i]);
					if (result is null) continue;
					ret.Add(result);
					FilteredIndex.Add(i);
				}
				return ret;
			}
		}
		/// <summary>
		/// フィルタリングされているデータのインデックス
		/// </summary>
		static List<int> FilteredIndex { get; } = new();

		public static void Load(string uri)
		{
			XDocument xDocument = XDocumentExtend.LoadEx(uri);
			XElement element = xDocument?.GetRootElementByNameEx("class", "name", nameof(MainData));
			XElement data = element?.Elements().Where(x => x?.GetAttributeValueEx("name") is string s && s == "data" && x.Value is string).FirstOrDefault();
			if (data is null) return;
			string dataValue = string.Empty;
			try
			{
				dataValue = Crypto.DecryptString(data.Value, Crypto.Password);
			}
			catch
			{
				dataValue = string.Empty;
			}
			LoadClipBoardText(dataValue, '\t', false);
			XElement related = element.Elements().Where(x => x.GetAttributeValueEx("name") is string s && s == "related").FirstOrDefault();
			if (related?.GetListEx() is List<(int x, int y)> l) m_related = l.ToArray();
			XElement filters = element.Elements().Where(x => x.GetAttributeValueEx("name") is string s && s == nameof(Filters)).FirstOrDefault();
			if (filters?.GetListEx() is List<Filter> f) Filters = f;
			XElement views = element.Elements().Where(x => x.GetAttributeValueEx("name") is string s && s == nameof(Views)).FirstOrDefault();
			if (views?.GetListEx() is List<bool> v) Views = v;
		}

		public static XElement Output()
		{
			XElement ret = new("class", new XAttribute("name", nameof(MainData)));
			string dataValue = string.Empty;
			try
			{
				dataValue = Crypto.EncryptString(OutputText('\t'), Crypto.Password);
			}
			catch
			{
				dataValue = string.Empty;
			}
			XElement data = new("property", new XAttribute("type", typeof(string).Name), new XAttribute("name", "data"), dataValue);
			ret.Add(data);
			ret.Add(m_related.ToList().ToPropertyEx("related"));
			ret.Add(Filters.ToPropertyEx(nameof(Filters)));
			ret.Add(Views.ToPropertyEx(nameof(Views)));
			return ret;
		}

		public static void Reset()
		{
			foreach (Dictionary<string, string> d in data) d.Clear();
			data.Clear();
			m_keys.Clear();
			m_isLoaded = false;
			m_related = Array.Empty<(int x, int y)>();
			Filters.Clear();
			Views.Clear();
			FilteredIndex.Clear();
		}

		static void SetProperties(List<string> tKeys, List<Dictionary<string, string>> tData)
		{
			m_keys = tKeys ?? new();
			Data = tData ?? new();
			m_related = new (int x, int y)[Data.Count];
			Views = new(Data.Count);
			for (int i = 0, count = Data.Count; i < count; ++i) Views.Add(true);
			m_isLoaded = true;
		}

		/// <summary>
		/// クリップボードテキストからレコードを作成する
		/// </summary>
		/// <param name="text">Clipboard.GetText()の戻り値</param>
		public static void LoadClipBoardText(string text, char separator = '\t', bool showErrorMessageBox = true)
		{
			if (text == null)
			{
				if (showErrorMessageBox) MessageForm.Show("エラー：クリップボードテキストがnullです。");
				return;
			}
			string data = text.Replace("\r\n", "\n").Trim(new[] { '\r', '\n' });	//改行コードを一文字に統一し、最後の改行コードを削除する
			string[] line = data.Split(new[] { '\r', '\n' });   //行ごとに分解
			//キーが存在しないまたはキーに対応する値が一つも存在しない場合、何もしない
			if (line.Length <= 1)
			{
				if (showErrorMessageBox) MessageForm.Show("エラー：" + (line.Length == 0 ? "データが存在しません。" : "キーに対応する値が一つもありません。"));
				return;
			}
			//一行目をキーとして使用
			List<string> tmpKeys = new();
			string[] segment = line[0].Split(separator).Select(x => x.Trim('"').Trim()).Where(x => x != string.Empty).ToArray();
			foreach (string s in segment)
			{
				//同名のキーが存在する場合、****_2, ****_3...のように末尾に番号をつける
				if (tmpKeys.Contains(s))
				{
					int i = 2;
					for (; i < int.MaxValue; ++i)
					{
						if (tmpKeys.Contains(s + '_' + i.ToString()))
						{
							tmpKeys.Add(s + '_' + i.ToString());
							break;
						}
					}
					//同名のキーがint.MaxValue個以上存在する場合、データの読み取りを中止する
					if (i == int.MaxValue)
					{
						if (showErrorMessageBox) MessageForm.Show("エラー：同名のキーが" + i.ToString() + "個以上存在します。\nデータを読み取れません。");
						return;
					}
				}
				else tmpKeys.Add(s);
			}
			//二行目以降は一行1レコードとして、キーに対応する値を保存する
			List<Dictionary<string, string>> tmpData = new();
			for (int i = 1; i < line.Length; ++i)
			{
				segment = line[i].Split(separator).Select(x => x.Trim('"').Trim()).ToArray();
				Dictionary<string, string> tmp = new();
				//キーの個数より値の個数が多い場合、あふれた値は無視する
				if (segment.Length >= tmpKeys.Count) for (int j = 0; j < tmpKeys.Count; ++j) tmp.Add(tmpKeys[j], segment[j]);
				else
				{
					//キーの個数より値の個数が少ない場合、空文字列で埋める
					for (int j = 0; j < segment.Length; ++j) tmp.Add(tmpKeys[j], segment[j]);
					for (int j = segment.Length; j < tmpKeys.Count; ++j) tmp.Add(tmpKeys[j], "");
				}
				tmpData.Add(tmp);
			}
			//メンバ変数に保存
			SetProperties(tmpKeys, tmpData);
		}

		/// <summary>
		/// CSVファイルからレコードを作成する
		/// </summary>
		/// <param name="filePath">CSVファイルへのパス</param>
		public static void LoadCSV(string filePath)
		{
			if (filePath is null)
			{
				MessageForm.Show("エラー：ファイルパスがnullです。");
				return;
			}
			List<string> tmpKeys = new();
			List<Dictionary<string, string>> tmpData = new();
			try
			{
				Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
				using FileStream fs = new(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
				using StreamReader file = new(fs, Encoding.GetEncoding("Shift-JIS"));
				//ファイルにデータがない場合、何もしない
				if (file.EndOfStream)
				{
					MessageForm.Show("エラー：ファイルに読み取れるデータが存在しません。");
					return;
				}
				//一行目をキーとして使用
				string line = file.ReadLine();
				//ファイルにキーに対応する値が一つもない(二行目以降がない)場合、何もしない
				if (file.EndOfStream)
				{
					MessageForm.Show("エラー：キーに対応する値が一つもありません。");
					return;
				}
				var splitCSV = (string line) =>
				{
					string[] segment = line.Split(',');
					List<string> list = new(segment.Length);
					for (int i = 0, length = segment.Length; i < length; ++i)
					{
						if (segment[i].StartsWith('"'))
						{
							string tmp = string.Empty;
							while (i < length)
							{
								tmp += segment[i];
								if (segment[i].EndsWith('"')) break;
								++i;
							}
							list.Add(tmp.Trim('"'));
						}
						else list.Add(segment[i]);
					}
					return list.ToArray();
				};
				string[] segment = splitCSV(line);
				foreach (string s in segment)
				{
					//同名のキーが存在する場合、****_2, ****_3...のように末尾に番号をつける
					if (tmpKeys.Contains(s))
					{
						int i = 2;
						for (; i < int.MaxValue; ++i)
						{
							if (tmpKeys.Contains(s + '_' + i.ToString()))
							{
								tmpKeys.Add(s + '_' + i.ToString());
								break;
							}
						}
						//同名のキーがint.MaxValue個以上存在する場合、データの読み取りを中止する
						if (i == int.MaxValue)
						{
							MessageForm.Show("エラー：同名のキーが" + i.ToString() + "個以上存在します。\nデータを読み取れません。");
							return;
						}
					}
					else tmpKeys.Add(s);
				}
				//二行目以降は一行1レコードとして、キーに対応する値を保存する
				while (!file.EndOfStream)
				{
					line = file.ReadLine();
					segment = splitCSV(line);
					Dictionary<string, string> tmp = new();
					//キーの個数より値の個数が多い場合、あふれた値は無視する
					if (segment.Length >= tmpKeys.Count) for (int j = 0; j < tmpKeys.Count; ++j) tmp.Add(tmpKeys[j], segment[j]);
					else
					{
						//キーの個数より値の個数が少ない場合、空文字列で埋める
						for (int j = 0; j < segment.Length; ++j) tmp.Add(tmpKeys[j], segment[j]);
						for (int j = segment.Length; j < tmpKeys.Count; ++j) tmp.Add(tmpKeys[j], "");
					}
					tmpData.Add(tmp);
				}
			}
			catch (Exception ex)
			{
				MessageForm.Show("ファイル操作中に例外が発生しました。\n" + ex.Message, "例外エラー");
				return;
			}
			SetProperties(tmpKeys, tmpData);
		}

		/// <summary>
		/// TSVファイルからレコードを作成する
		/// </summary>
		/// <param name="filePath">TSVファイルへのパス</param>
		public static void LoadTSV(string filePath)
		{
			if (filePath is null)
			{
				MessageForm.Show("エラー：ファイルパスがnullです。");
				return;
			}
			List<string> tmpKeys = new();
			List<Dictionary<string, string>> tmpData = new();
			try
			{
				Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
				using FileStream fs = new(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
				using StreamReader file = new(fs, Encoding.GetEncoding("Shift-JIS"));
				//ファイルにデータがない場合、何もしない
				if (file.EndOfStream)
				{
					MessageForm.Show("エラー：ファイルに読み取れるデータが存在しません。");
					return;
				}
				//一行目をキーとして使用
				string line = file.ReadLine();
				//ファイルにキーに対応する値が一つもない(二行目以降がない)場合、何もしない
				if (file.EndOfStream)
				{
					MessageForm.Show("エラー：キーに対応する値が一つもありません。");
					return;
				}
				string[] segment = line.Split('\t').Select(x => x.Trim('"')).ToArray();
				foreach (string s in segment)
				{
					//同名のキーが存在する場合、****_2, ****_3...のように末尾に番号をつける
					if (tmpKeys.Contains(s))
					{
						int i = 2;
						for (; i < int.MaxValue; ++i)
						{
							if (tmpKeys.Contains(s + '_' + i.ToString()))
							{
								tmpKeys.Add(s + '_' + i.ToString());
								break;
							}
						}
						//同名のキーがint.MaxValue個以上存在する場合、データの読み取りを中止する
						if (i == int.MaxValue)
						{
							MessageForm.Show("エラー：同名のキーが" + i.ToString() + "個以上存在します。\nデータを読み取れません。");
							return;
						}
					}
					else tmpKeys.Add(s);
				}
				//二行目以降は一行1レコードとして、キーに対応する値を保存する
				while (!file.EndOfStream)
				{
					line = file.ReadLine();
					segment = line.Split('\t').Select(x => x.Trim('"')).ToArray();
					Dictionary<string, string> tmp = new();
					//キーの個数より値の個数が多い場合、あふれた値は無視する
					if (segment.Length >= tmpKeys.Count) for (int j = 0; j < tmpKeys.Count; ++j) tmp.Add(tmpKeys[j], segment[j]);
					else
					{
						//キーの個数より値の個数が少ない場合、空文字列で埋める
						for (int j = 0; j < segment.Length; ++j) tmp.Add(tmpKeys[j], segment[j]);
						for (int j = segment.Length; j < tmpKeys.Count; ++j) tmp.Add(tmpKeys[j], "");
					}
					tmpData.Add(tmp);
				}
			}
			catch (Exception ex)
			{
				MessageForm.Show("ファイル操作中に例外が発生しました。\n" + ex.Message, "例外エラー");
				return;
			}
			SetProperties(tmpKeys, tmpData);
		}

		/// <summary>
		/// レコードから得られるDataTableをseparatorによって文字列化して取得する
		/// </summary>
		/// <param name="separator">区切り文字(',', '\t'など)</param>
		/// <returns>DataTableの行ごとに改行の入った文字列</returns>
		private static string OutputText(char separator)
		{
			StringBuilder sb = new();
			string header = "";
			DataTable dataTable = GetDataTable();
			int rowCount = dataTable.Rows.Count;
			foreach (DataColumn column in dataTable.Columns)
			{
				string tmp = column.ColumnName;
				if (tmp.Contains('"')) tmp = tmp.Replace("\"", "\"\"");
				if (tmp.Contains(',') || tmp.Contains('"') || tmp.Contains('\r') || tmp.Contains('\n')) tmp = '"' + tmp + '"';
				header += tmp + separator;
			}
			header = header.TrimEnd(separator);
			sb.Append(header + '\n');
			for (int r = 0; r < rowCount; ++r)
			{
				string line = "";
				var items = dataTable.Rows[r].ItemArray;
				for (int c = 0, count = items.Length; c < count; ++c)
				{
					if (items[c] is not string tmp) line += separator;
					else
					{
						if (tmp.Contains('"')) tmp = tmp.Replace("\"", "\"\"");
						if (tmp.Contains(',') || tmp.Contains('"') || tmp.Contains('\r') || tmp.Contains('\n')) tmp = '"' + tmp + '"';
						line += tmp + separator;
					}
				}
				line = line.TrimEnd(separator);
				sb.Append(line + '\n');
			}
			return sb.ToString();
		}

		/// <summary>
		/// レコードからデータテーブルを取得する
		/// </summary>
		/// <returns>
		/// <para>レコードが正常に読み込まれている場合、レコードの内容を書き込んだデータテーブルを返す</para>
		/// <para>レコードが読み込まれていない場合、new DataTable()を返す</para>
		/// </returns>
		public static DataTable GetDataTable(bool filtered = false)
		{
			DataTable ret = new();
			if (!m_isLoaded) return ret;
			//キーを列に設定
			for (int i = 0; i < m_keys.Count; ++i) ret.Columns.Add(m_keys[i]);
			//行ごとに値を設定
			foreach (Dictionary<string, string> d in filtered ? FilteredData : Data)
			{
				DataRow row = ret.NewRow();
				foreach (string key in m_keys)
				{
					if (d.ContainsKey(key)) row[key] = d[key];
				}
				ret.Rows.Add(row);
			}
			return ret;
		}

		/// <summary>
		/// キーをstring型配列で取得する
		/// </summary>
		/// <returns>
		/// <para>レコードが正常に読み込まれている場合、全キーをstring型配列で返す</para>
		/// <para>レコードが読み込まれていない場合、new List<see cref="{string}"/>().ToArray()を返す</para>
		/// </returns>
		public static string[] GetKeys()
		{
			if (m_keys != null) return m_keys.ToArray();
			else return new List<string>().ToArray();
		}

		/// <summary>
		/// <para>GlottogramData.ValueKeysのキーについて、SymbolDataに登録された記号ごとのデータ数を取得する</para>
		/// <para>SymbolDataに存在しない値は自動的に追加される</para>
		/// </summary>
		/// <param name="autoSort">trueのとき、この関数内で新しくSymbolが追加されていれば、SymbolDataのトップレベルSymbolをデータ数で降順にソートする</param>
		/// <returns>Symbolオブジェクトとそのデータ数のDictionary</returns>
		public static Dictionary<Symbol, int> GetSymbolSum(bool autoSort = true)
		{
			Dictionary<Symbol, int> ret = new();
			if (!m_isLoaded) return ret;
			List<Symbol> symbols = SymbolData.GetSymbolList().Where(x => !x.Members.Any()).ToList();
			bool isNewSymbol = false;
			string[] valueKeys = GlottogramData.ValueKeys.ToArray();
			foreach (var data in Data)
			{
				List<Symbol> added = new();
				foreach (string valueKey in valueKeys)
				{
					if (data.TryGetValue(valueKey, out string value))
					{
						if (value == string.Empty) continue;
						if (symbols.Where(x => x.Value == value).FirstOrDefault() is not Symbol symbol)
						{
							SymbolData.Add(value, null);
							if (SymbolData.GetSymbol(value) is not Symbol newSymbol) continue;
							symbols.Add(newSymbol);
							symbol = newSymbol;
							isNewSymbol = true;
						}
						if (ret.ContainsKey(symbol)) ++ret[symbol];
						else ret.Add(symbol, 1);
						Symbol parent = symbol.Parent;
						while (parent is not null && !added.Contains(parent))
						{
							if (ret.ContainsKey(parent)) ++ret[parent];
							else ret.Add(parent, 1);
							added.Add(parent);
							parent = parent.Parent;
						}
					}
				}
			}
			if (autoSort && isNewSymbol) SymbolData.OrderByArray(ret.OrderByDescending(x => x.Value).Select(x => x.Key).ToArray());
			return ret;
		}

		/// <summary>
		/// 各Symbolが表示範囲内にいくつ存在するか取得する。
		/// </summary>
		/// <returns>Symbolとその個数のペア</returns>
		public static Dictionary<Symbol, int> GetSymbolSumByView()
		{
			Dictionary<Symbol, int> ret = new();
			string xSortKey = GlottogramData.ColumnSortKey;
			string ySortKey = GlottogramData.RowSortKey;
			if (!(m_isLoaded && m_keys.Contains(xSortKey) && m_keys.Contains(ySortKey))) return ret;
			string[] valueKeys = GlottogramData.ValueKeys.ToArray();
			var xRange = GlottogramData.ColumnRange;
			var yRange = GlottogramData.RowRange;
			IEnumerable<Symbol> symbols = SymbolData.GetSymbolList().Where(x => !x.Members.Any());
			int dataCount = 0;
			foreach (var data in Data)
			{
				for (int count = Views.Count; dataCount >= count; ++count) Views.Add(true);
				if (!Views[dataCount++]) continue;
				if (int.TryParse(data[xSortKey], out int x) && int.TryParse(data[ySortKey], out int y))
				{
					if (x < xRange.Min || xRange.Max < x || y < yRange.Min || yRange.Max < y) continue;
				}
				else continue;
				if (Filters.Where(x => !x.Includes(data)).Any()) continue;
				List<Symbol> added = new();
				foreach (string valueKey in valueKeys)
				{
					if (data.TryGetValue(valueKey, out string value))
					{
						if (value == string.Empty || symbols.Where(x => x.Value == value).FirstOrDefault() is not Symbol symbol) continue;
						Symbol root = symbol.SymbolicRoot;
						if (added.Contains(root)) continue;
						else added.Add(root);
						if (ret.ContainsKey(symbol)) ++ret[symbol];
						else ret.Add(symbol, 1);
						Symbol parent = symbol.Parent;
						while (parent is not null)
						{
							if (ret.ContainsKey(parent)) ++ret[parent];
							else ret.Add(parent, 1);
							parent = parent.Parent;
						}
					}
				}
			}
			return ret;
		}

		/// <summary>
		/// 各レコード内からsrcKeyの値とdstKeyの値を取り出し、対応関係をDictionaryとして取得する。
		/// </summary>
		/// <param name="srcKey">入力する値のキー</param>
		/// <param name="dstKey">出力される値のキー</param>
		/// <returns>
		/// <para>srcKeyの値からdstKeyの値への全単射な対応を表すDictionary。</para>
		/// <para>srcKeyのある値に対して、複数のdstKeyの値が対応する場合、最初に見つかった対応関係のみ使用される。</para>
		/// </returns>
		public static Dictionary<string, string> GetConverter(string srcKey, string dstKey)
		{
			Dictionary<string, string> ret = new();
			if (!m_isLoaded || !m_keys.Contains(srcKey) || !m_keys.Contains(dstKey)) return ret;
			foreach (Dictionary<string, string> data in Data)
			{
				if (data.TryGetValue(srcKey, out string src) && data.TryGetValue(dstKey, out string dst))
				{
					if (ret.ContainsKey(src)) continue;
					else ret.Add(src, dst);
				}
			}
			return ret;
		}

		/// <summary>
		/// GlottogramDataとSymbolDataの情報を使用してグロットグラムに表示するデータを取得する
		/// </summary>
		/// <returns>CacheオブジェクトのList</returns>
		public static List<Cache> GetCaches()
		{
			List<Cache> ret = new();
			string xSortKey = GlottogramData.ColumnSortKey;
			string ySortKey = GlottogramData.RowSortKey;
			if (!(m_isLoaded && m_keys.Contains(xSortKey) && m_keys.Contains(ySortKey))) return ret;
			var valueKeys = GlottogramData.ValueKeys.Where(x => m_keys.Contains(x));
			int i = 0;
			float scale = GlottogramProperty.SymbolScale;
			foreach (Dictionary<string, string> data in Data)
			{
				for (int count = Views.Count; i >= count; ++count) Views.Add(true);
				if (Views[i])
				{
					if (int.TryParse(data[xSortKey], out int x) && int.TryParse(data[ySortKey], out int y))
					{
						Cache cache = new();
						cache.DataIndex = i;
						cache.XSortValue = x;
						cache.YSortValue = y;
						string[] values = data.Where(x => valueKeys.Contains(x.Key)).Select(x => x.Value).ToArray();
						cache.Bitmap = SymbolData.GetBitmap(values, scale, out bool isMultiple);
						cache.IsMultiple = isMultiple;
						cache.RemovedByFiltering = Filters.Where(x => !x.Includes(data)).Any();
						ret.Add(cache);
					}
				}
				++i;
			}
			return ret;
		}

		/// <summary>
		/// インデックスに対応するデータからGlottogramData.ValueKeysをキーとする値を取得する
		/// </summary>
		/// <param name="index">データのインデックス</param>
		/// <returns>GlottogramData.ValueKeysをキーとする値の配列。存在しない場合、string型の空配列</returns>
		public static string[] GetValues(int index)
		{
			if (!m_isLoaded || index < 0 || Data.Count <= index) return Array.Empty<string>();
			string[] valueKeys = GlottogramData.ValueKeys.ToArray();
			var tmp = Data[index].Where(x => valueKeys.Contains(x.Key));
			int count = tmp.Count();
			if (count == 0) return Array.Empty<string>();
			string[] ret = new string[count];
			for (int i = 0; i < count; ++i) ret[i] = tmp.Where(x => x.Key == valueKeys[i]).First().Value;
			return ret;
		}

		/// <summary>
		/// インデックスに対応するデータのグロットグラム上の座標からの相対移動値を取得する
		/// </summary>
		/// <param name="index">データのインデックス</param>
		/// <returns>セルサイズを基準とする相対移動値。インデックスが範囲外の場合、(0, 0)</returns>
		public static (int x, int y) GetRelatedTranslate(int index) => (m_related is not null && 0 <= index && index < m_related.Length) ? m_related[index] : (0, 0);

		/// <summary>
		/// インデックスに対応するデータのグロットグラム上の座標からのx軸方向の相対移動値を設定する
		/// </summary>
		/// <param name="index">データのインデックス</param>
		/// <param name="x">設定する相対移動値</param>
		public static void SetRelatedX(int index, int x)
		{
			if (m_related is not null && 0 <= index && index < m_related.Length) m_related[index] = (x, m_related[index].y);
		}

		/// <summary>
		/// インデックスに対応するデータのグロットグラム上の座標からのy軸方向の相対移動値を設定する
		/// </summary>
		/// <param name="index">データのインデックス</param>
		/// <param name="x">設定する相対移動値</param>
		public static void SetRelatedY(int index, int y)
		{
			if (m_related is not null && 0 <= index && index < m_related.Length) m_related[index] = (m_related[index].x, y);
		}

		/// <summary>
		/// 検索フィルターを追加する
		/// </summary>
		/// <param name="key">フィルターのキー</param>
		/// <param name="value">フィルターの値</param>
		/// <param name="filterType">フィルターの種類</param>
		public static void AddFilter(string key, string value, FilterType filterType)
		{
			Filter tmp = new(key, value, filterType);
			if (!Filters.Where(x => x.Equals(tmp)).Any()) Filters.Add(tmp);
		}
		
		/// <summary>
		/// 検索フィルターを解除する
		/// </summary>
		/// <param name="index">削除するフィルターのインデックス</param>
		public static void RemoveFilter(int index)
		{
			if (0 <= index && index < Filters.Count) Filters.RemoveAt(index);
		}

		/// <summary>
		/// フィルターの一覧を取得する
		/// </summary>
		/// <returns>フィルターの内容を表す文字列の配列</returns>
		public static string[] GetFilters()
		{
			List<string> ret = new(Filters.Count);
			foreach (Filter filter in Filters) ret.Add(filter.ToString());
			return ret.ToArray();
		}

		/// <summary>
		/// インデックスに対応するデータの表示/非表示を設定する
		/// </summary>
		/// <param name="index">データのインデックス</param>
		/// <param name="view">trueのとき、表示する</param>
		public static void SetView(int index, bool view, bool filtered = true)
		{
			if (filtered)
			{
				if (index >= FilteredIndex.Count) return;
				int dataIndex = FilteredIndex[index];
				if (dataIndex >= Views.Count) return;
				Views[dataIndex] = view;
			}
			else if (index < Views.Count) Views[index] = view;
		}

		/// <summary>
		/// データの表示/非表示の設定を取得する
		/// </summary>
		/// <returns>データの表示/非表示の設定を表すbool値の配列</returns>
		public static bool[] GetViews(bool filtered = true)
		{
			for (int count = Views.Count, end = Data.Count; count < end; ++count) Views.Add(true);
			int viewCount = Views.Count;
			List<bool> ret = new(viewCount);
			IEnumerable<int> indices = filtered ? FilteredIndex : Enumerable.Range(0, Views.Count);
			foreach (int index in indices) if (index < viewCount) ret.Add(Views[index]);
			return ret.ToArray();
		}

		/// <summary>
		/// レコード内のキーに対応する値を分割し、新たなキーに格納する
		/// </summary>
		/// <param name="key">値を分割するキー</param>
		/// <param name="splitChar">区切り文字の配列</param>
		/// <returns>成功した場合、trueを返す</returns>
		public static bool SplitValue(string key, char[] splitChar)
		{
			if (!m_isLoaded || !m_keys.Contains(key))
			{
				MessageForm.Show("エラー：キーが存在しません。");
				return false;
			}
			string firstkey = GenerateCopyKey(key);
			if (firstkey == null) return false;
			int index = m_keys.IndexOf(key);    //keyのインデックス
			int newKeyCount = 1;    //追加したキーの数
			m_keys.Insert(index + newKeyCount, firstkey);
			for (int i = 0; i < Data.Count; ++i)
			{
				Dictionary<string, string> d = Data[i];
				string[] values = d[key].Split(splitChar);
				for (int j = 0; j < values.Length; ++j)
				{
					while (newKeyCount <= j)
					{
						string nextKey = GenerateCopyKey(key, false);
						if (nextKey == null) break;
						m_keys.Insert(index + (++newKeyCount), nextKey);
						for (int k = 0; k < i; ++k) Data[k].Add(nextKey, "");
					}
					if (newKeyCount <= j) break;
					d.Add(m_keys[index + j + 1], values[j]);
				}
				for (int j = values.Length; j < newKeyCount; ++j) d.Add(m_keys[index + j + 1], "");
			}
			return true;
		}

		/// <summary>
		/// レコードに存在しない新しいキーを生成する
		/// </summary>
		/// <param name="srcKey">元のキー</param>
		/// <param name="showErrorMessageBox">エラーの場合、メッセージボックスを表示する</param>
		/// <returns>
		/// <para>レコード内のキーと重複しないキーを返す。srcKeyの末尾に_1, _2, _3...をつけて重複を回避する</para>
		/// <para>エラーの場合、nullを返す</para>
		/// </returns>
		static string GenerateCopyKey(string srcKey, bool showErrorMessageBox = true)
		{
			int i = 1;
			string new_key = srcKey + '_' + i.ToString();
			while (m_keys.Contains(new_key) && i < int.MaxValue) new_key = srcKey + '_' + (++i).ToString();
			if (i == int.MaxValue)
			{
				if (showErrorMessageBox) MessageForm.Show("エラー：新たなキーを生成できませんでした。");
				return null;
			}
			return new_key;
		}

		/// <summary>
		/// sortKeyに対応する値にIDを振り、データ列に追加する
		/// </summary>
		/// <param name="sortKey">IDを振るキー</param>
		/// <returns>成功した場合、true</returns>
		public static bool AddIDKeyValue(string sortKey)
		{
			if (!m_isLoaded || sortKey is null || !m_keys.Contains(sortKey)) return false;
			string idKey = "ID:" + sortKey;
			if (m_keys.Contains(idKey)) idKey = GenerateCopyKey(idKey, false);
			if (idKey is null) return false;
			Dictionary<string, int> tmp = new();
			int id = 0;
			foreach (var data in Data)
			{
				if (data.TryGetValue(sortKey, out string value))
				{
					if (!tmp.ContainsKey(value)) tmp.Add(value, ++id);
					data.Add(idKey, tmp[value].ToString());
				}
			}
			m_keys.Insert(m_keys.IndexOf(sortKey), idKey);
			return true;
		}

		/// <summary>
		/// sortKeyに対応する値にIndexを振り、データ列に追加する
		/// </summary>
		/// <param name="sortKey">Indexを振るキー</param>
		/// <returns>成功した場合、true</returns>
		public static bool AddIndexKeyValue(string sortKey)
		{
			if (!m_isLoaded || sortKey is null || !m_keys.Contains(sortKey)) return false;
			string indexKey = "Index:" + sortKey;
			if (m_keys.Contains(indexKey)) indexKey = GenerateCopyKey(indexKey, false);
			if (indexKey is null) return false;
			Dictionary<string, int> tmp = new();
			foreach (var data in Data)
			{
				if (data.TryGetValue(sortKey, out string value))
				{
					if (!tmp.ContainsKey(value)) tmp.Add(value, 1);
					else ++tmp[value];
					data.Add(indexKey, tmp[value].ToString());
				}
			}
			m_keys.Insert(m_keys.IndexOf(sortKey), indexKey);
			return true;
		}

		/// <summary>
		/// 指定したキーを削除する
		/// </summary>
		/// <param name="key">削除するキー</param>
		/// <returns>削除に成功した、または指定したキーが含まれていないとき、trueを返す</returns>
		public static bool RemoveKey(string key)
		{
			if (!m_isLoaded || key is null) return false;
			if (!m_keys.Contains(key)) return false;
			foreach (var data in Data) if (data.ContainsKey(key)) data.Remove(key);
			m_keys.Remove(key);
			return true;
		}

		/// <summary>
		/// 指定したキーに指定した操作を行う
		/// </summary>
		/// <param name="func">MainDataに行う操作</param>
		/// <param name="key">指定したキー。第一引数で指定する関数の第三引数に使用される</param>
		/// <returns>関数が成功したとき、true</returns>
		public static bool Invoke(Func<List<Dictionary<string, string>>, List<string>, string, bool> func, string key)
		{
			if (!m_isLoaded) return false;
			else return func(Data, m_keys, key);
		}
	}

	/// <summary>
	/// MainDataから取得されるデータ
	/// </summary>
	public class Cache
	{
		/// <summary>
		/// 複数回答か否か
		/// </summary>
		public bool IsMultiple { get; set; } = false;

		/// <summary>
		/// フィルターによって非表示になっているか否か
		/// </summary>
		public bool RemovedByFiltering { get; set; } = false;

		/// <summary>
		/// GlottogramData.XSortKeyに対応する値
		/// </summary>
		public int XSortValue { get; set; } = 0;

		/// <summary>
		/// GlottogramData.YSortKeyに対応する値
		/// </summary>
		public int YSortValue { get; set; } = 0;
		
		/// <summary>
		/// MainData内のレコードインデックス
		/// </summary>
		public int DataIndex { get; set; } = 0;
		
		/// <summary>
		/// GlottogramData.ValueKeysに対応する値をSybolDataで変換し、結合した画像データ
		/// </summary>
		public Bitmap Bitmap { get; set; } = null;
	}

	/// <summary>
	/// 文字列の暗号化
	/// </summary>
	static class Crypto
	{
		/// <summary>
		/// パスワード(研究室内利用限定のため、埋め込み。Github公開用に伏字。)
		/// </summary>
		public static string Password = "***************************";

		/// <summary>
		/// パスワードから共有キーと初期化ベクタを生成する
		/// </summary>
		/// <param name="password">基になるパスワード</param>
		/// <param name="keySize">共有キーのサイズ（ビット）</param>
		/// <param name="key">作成された共有キー</param>
		/// <param name="blockSize">初期化ベクタのサイズ（ビット）</param>
		/// <param name="iv">作成された初期化ベクタ</param>
		private static void GenerateKeyFromPassword(string password, int keySize, out byte[] key, int blockSize, out byte[] iv)
		{
			//パスワードから共有キーと初期化ベクタを作成する
			//saltを決める
			byte[] salt = System.Text.Encoding.UTF8.GetBytes("saltは必ず8バイト以上");
			//Rfc2898DeriveBytesオブジェクトを作成する
			using System.Security.Cryptography.Rfc2898DeriveBytes deriveBytes =new System.Security.Cryptography.Rfc2898DeriveBytes(password, salt);
			//反復処理回数を指定する デフォルトで1000回
			deriveBytes.IterationCount = 1000;
			//共有キーと初期化ベクタを生成する
			key = deriveBytes.GetBytes(keySize / 8);
			iv = deriveBytes.GetBytes(blockSize / 8);
		}

		/// <summary>
		/// 文字列を暗号化する
		/// </summary>
		/// <param name="sourceString">暗号化する文字列</param>
		/// <param name="password">暗号化に使用するパスワード</param>
		/// <returns>暗号化された文字列</returns>
		public static string EncryptString(string sourceString, string password)
		{
			using System.Security.Cryptography.Aes aes = System.Security.Cryptography.AesCng.Create();
						
			//パスワードから共有キーと初期化ベクタを作成
			byte[] key, iv;
			GenerateKeyFromPassword(password, aes.KeySize, out key, aes.BlockSize, out iv);
			aes.Key = key;
			aes.IV = iv;

			//文字列をバイト型配列に変換する
			byte[] strBytes = System.Text.Encoding.UTF8.GetBytes(sourceString);

			//対称暗号化オブジェクトの作成
			using System.Security.Cryptography.ICryptoTransform encryptor = aes.CreateEncryptor();
			//バイト型配列を暗号化する
			byte[] encBytes = encryptor.TransformFinalBlock(strBytes, 0, strBytes.Length);
			
			//バイト型配列を文字列に変換して返す
			return System.Convert.ToBase64String(encBytes);
		}

		/// <summary>
		/// 暗号化された文字列を復号化する
		/// </summary>
		/// <param name="sourceString">暗号化された文字列</param>
		/// <param name="password">暗号化に使用したパスワード</param>
		/// <returns>復号化された文字列</returns>
		public static string DecryptString(string sourceString, string password)
		{
			using System.Security.Cryptography.Aes aes = System.Security.Cryptography.AesCng.Create();

			//パスワードから共有キーと初期化ベクタを作成
			byte[] key, iv;
			GenerateKeyFromPassword(password, aes.KeySize, out key, aes.BlockSize, out iv);
			aes.Key = key;
			aes.IV = iv;

			//文字列をバイト型配列に戻す
			byte[] strBytes = System.Convert.FromBase64String(sourceString);

			//対称暗号化オブジェクトの作成
			using System.Security.Cryptography.ICryptoTransform decryptor = aes.CreateDecryptor();
			//バイト型配列を復号化する
			//復号化に失敗すると例外CryptographicExceptionが発生
			byte[] decBytes = decryptor.TransformFinalBlock(strBytes, 0, strBytes.Length);

			//バイト型配列を文字列に戻して返す
			return System.Text.Encoding.UTF8.GetString(decBytes);
		}

	}

	/// <summary>
	/// フィルター機能
	/// </summary>
	class Filter : IEquatable<Filter>
	{
		public string Key { get; private set; } = null;
		public string Value { get; private set; } = null;
		public FilterType Type { get; private set; } = FilterType.Match;

		public Filter(string key, string value, FilterType type)
		{
			Key = key;
			Value = value;
			Type = type;
		}

		public bool Match(Dictionary<string, string> x) => x.TryGetValue(Key, out string value) && value == Value;
		public bool NotMatch(Dictionary<string, string> x) => x.TryGetValue(Key, out string value) && value != Value;
		public bool Contain(Dictionary<string, string> x) => x.TryGetValue(Key, out string value) && value.Contains(Value);
		public bool NotContain(Dictionary<string, string> x) => x.TryGetValue(Key, out string value) && !value.Contains(Value);
		public bool StartWith(Dictionary<string, string> x) => x.TryGetValue(Key, out string value) && value.StartsWith(Value);
		public bool NotStartWith(Dictionary<string, string> x) => x.TryGetValue(Key, out string value) && !value.StartsWith(Value);
		public bool EndWith(Dictionary<string, string> x) => x.TryGetValue(Key, out string value) && value.EndsWith(Value);
		public bool NotEndWith(Dictionary<string, string> x) => x.TryGetValue(Key, out string value) && !value.EndsWith(Value);
		public bool Greater(Dictionary<string, string> x) => x.TryGetValue(Key, out string value) && string.Compare(value, Value) > 0;
		public bool Less(Dictionary<string, string> x) => x.TryGetValue(Key, out string value) && string.Compare(value, Value) < 0;
		public bool GreaterEqual(Dictionary<string, string> x) => x.TryGetValue(Key, out string value) && string.Compare(value, Value) >= 0;
		public bool LessEqual(Dictionary<string, string> x) => x.TryGetValue(Key, out string value) && string.Compare(value, Value) <= 0;
		public bool GreaterByInt64(Dictionary<string, string> x) => long.TryParse(Value, System.Globalization.NumberStyles.Any, null, out long l) ? x.TryGetValue(Key, out string value) && long.TryParse(value, System.Globalization.NumberStyles.Any, null, out long lv) && lv > l : true;
		public bool LessByInt64(Dictionary<string, string> x) => long.TryParse(Value, System.Globalization.NumberStyles.Any, null, out long l) ? x.TryGetValue(Key, out string value) && long.TryParse(value, System.Globalization.NumberStyles.Any, null, out long lv) && lv < l : true;
		public bool GreaterEqualByInt64(Dictionary<string, string> x) => long.TryParse(Value, System.Globalization.NumberStyles.Any, null, out long l) ? x.TryGetValue(Key, out string value) && long.TryParse(value, System.Globalization.NumberStyles.Any, null, out long lv) && lv >= l : true;
		public bool LessEqualByInt64(Dictionary<string, string> x) => long.TryParse(Value, System.Globalization.NumberStyles.Any, null, out long l) ? x.TryGetValue(Key, out string value) && long.TryParse(value, System.Globalization.NumberStyles.Any, null, out long lv) && lv <= l : true;
		public bool GreaterByDouble(Dictionary<string, string> x) => double.TryParse(Value, System.Globalization.NumberStyles.Any, null, out double d) ? x.TryGetValue(Key, out string value) && double.TryParse(value, System.Globalization.NumberStyles.Any, null, out double dv) && dv > d : true;
		public bool LessByDouble(Dictionary<string, string> x) => double.TryParse(Value, System.Globalization.NumberStyles.Any, null, out double d) ? x.TryGetValue(Key, out string value) && double.TryParse(value, System.Globalization.NumberStyles.Any, null, out double dv) && dv < d : true;
		public bool GreaterEqualByDouble(Dictionary<string, string> x) => double.TryParse(Value, System.Globalization.NumberStyles.Any, null, out double d) ? x.TryGetValue(Key, out string value) && double.TryParse(value, System.Globalization.NumberStyles.Any, null, out double dv) && dv >= d : true;
		public bool LessEqualByDouble(Dictionary<string, string> x) => double.TryParse(Value, System.Globalization.NumberStyles.Any, null, out double d) ? x.TryGetValue(Key, out string value) && double.TryParse(value, System.Globalization.NumberStyles.Any, null, out double dv) && dv <= d : true;

		public IEnumerable<Dictionary<string, string>> Func(IEnumerable<Dictionary<string, string>> data)
		{
			if (Key is null || Value is null) return data;
			return Type switch
			{
				FilterType.Match => data.Where(Match),
				FilterType.NotMatch => data.Where(NotMatch),
				FilterType.Contain => data.Where(Contain),
				FilterType.NotContain => data.Where(NotContain),
				FilterType.StartWith => data.Where(StartWith),
				FilterType.NotStartWith => data.Where(NotStartWith),
				FilterType.EndWith => data.Where(EndWith),
				FilterType.NotEndWith => data.Where(NotEndWith),
				FilterType.Greater => data.Where(Greater),
				FilterType.Less => data.Where(Less),
				FilterType.GreaterEqual => data.Where(GreaterEqual),
				FilterType.LessEqual => data.Where(LessEqual),
				FilterType.GreaterByInt64 => long.TryParse(Value, System.Globalization.NumberStyles.Any, null, out long l) ? data.Where(x => x.TryGetValue(Key, out string value) && long.TryParse(value, System.Globalization.NumberStyles.Any, null, out long lv) && lv > l) : data,
				FilterType.LessByInt64 => long.TryParse(Value, System.Globalization.NumberStyles.Any, null, out long l) ? data.Where(x => x.TryGetValue(Key, out string value) && long.TryParse(value, System.Globalization.NumberStyles.Any, null, out long lv) && lv < l) : data,
				FilterType.GreaterEqualByInt64 => long.TryParse(Value, System.Globalization.NumberStyles.Any, null, out long l) ? data.Where(x => x.TryGetValue(Key, out string value) && long.TryParse(value, System.Globalization.NumberStyles.Any, null, out long lv) && lv >= l) : data,
				FilterType.LessEqualByInt64 => long.TryParse(Value, System.Globalization.NumberStyles.Any, null, out long l) ? data.Where(x => x.TryGetValue(Key, out string value) && long.TryParse(value, System.Globalization.NumberStyles.Any, null, out long lv) && lv <= l) : data,
				FilterType.GreaterByDouble => double.TryParse(Value, System.Globalization.NumberStyles.Any, null, out double d) ? data.Where(x => x.TryGetValue(Key, out string value) && double.TryParse(value, System.Globalization.NumberStyles.Any, null, out double dv) && dv > d) : data,
				FilterType.LessByDouble => double.TryParse(Value, System.Globalization.NumberStyles.Any, null, out double d) ? data.Where(x => x.TryGetValue(Key, out string value) && double.TryParse(value, System.Globalization.NumberStyles.Any, null, out double dv) && dv < d) : data,
				FilterType.GreaterEqualByDouble => double.TryParse(Value, System.Globalization.NumberStyles.Any, null, out double d) ? data.Where(x => x.TryGetValue(Key, out string value) && double.TryParse(value, System.Globalization.NumberStyles.Any, null, out double dv) && dv >= d) : data,
				FilterType.LessEqualByDouble => double.TryParse(Value, System.Globalization.NumberStyles.Any, null, out double d) ? data.Where(x => x.TryGetValue(Key, out string value) && double.TryParse(value, System.Globalization.NumberStyles.Any, null, out double dv) && dv <= d) : data,
				_ => data
			};
		}

		public bool Includes(Dictionary<string, string> data)
		{
			return Type switch
			{
				FilterType.Match => Match(data),
				FilterType.NotMatch => NotMatch(data),
				FilterType.Contain => Contain(data),
				FilterType.NotContain => NotContain(data),
				FilterType.StartWith => StartWith(data),
				FilterType.NotStartWith => NotStartWith(data),
				FilterType.EndWith => EndWith(data),
				FilterType.NotEndWith => NotEndWith(data),
				FilterType.Greater => Greater(data),
				FilterType.Less => Less(data),
				FilterType.GreaterEqual => GreaterEqual(data),
				FilterType.LessEqual => LessEqual(data),
				FilterType.GreaterByInt64 => GreaterByInt64(data),
				FilterType.LessByInt64 => LessByInt64(data),
				FilterType.GreaterEqualByInt64 => GreaterEqualByInt64(data),
				FilterType.LessEqualByInt64 => LessEqualByInt64(data),
				FilterType.GreaterByDouble => GreaterByDouble(data),
				FilterType.LessByDouble => LessByDouble(data),
				FilterType.GreaterEqualByDouble => GreaterEqualByDouble(data),
				FilterType.LessEqualByDouble => LessEqualByDouble(data),
				_ => true
			};
		}

#nullable enable
		public override bool Equals(object? obj) => obj is Filter f ? Key == f.Key && Value == f.Value && Type == f.Type : base.Equals(obj);

		public bool Equals(Filter? obj) => obj is not null ? Key == obj.Key && Value == obj.Value && Type == obj.Type : false;
#nullable restore
		public override int GetHashCode() => new { Key, Value, Type }.GetHashCode();

		public override string ToString() => "キー『" + Key + "』の値が『" + Value + "』" + ToEnumName.ToEnumNameEx(Type, 0);
	}

	static class FilterEx
	{
#nullable enable
		public static Dictionary<string, string>? TryGetData(this IEnumerable<Filter> filters, Dictionary<string, string> data)
		{
			foreach (Filter filter in filters)
			{
				if (filter.Key is null || filter.Value is null) continue;
				bool result = filter.Type switch
				{
					FilterType.Match => filter.Match(data),
					FilterType.NotMatch => filter.NotMatch(data),
					FilterType.Contain => filter.Contain(data),
					FilterType.NotContain => filter.NotContain(data),
					FilterType.StartWith => filter.StartWith(data),
					FilterType.NotStartWith => filter.NotStartWith(data),
					FilterType.EndWith => filter.EndWith(data),
					FilterType.NotEndWith => filter.NotEndWith(data),
					FilterType.Greater => filter.Greater(data),
					FilterType.Less => filter.Less(data),
					FilterType.GreaterEqual => filter.GreaterEqual(data),
					FilterType.LessEqual => filter.LessEqual(data),
					FilterType.GreaterByInt64 => filter.GreaterByInt64(data),
					FilterType.LessByInt64 => filter.LessByInt64(data),
					FilterType.GreaterEqualByInt64 => filter.GreaterEqualByInt64(data),
					FilterType.LessEqualByInt64 => filter.LessEqualByInt64(data),
					FilterType.GreaterByDouble => filter.GreaterByDouble(data),
					FilterType.LessByDouble => filter.LessByDouble(data),
					FilterType.GreaterEqualByDouble => filter.GreaterEqualByDouble(data),
					FilterType.LessEqualByDouble => filter.LessEqualByDouble(data),
					_ => true
				};
				if (result) continue;
				else return null;
			}
			return data;
		}
#nullable restore
	}

	static partial class FromXElement
	{
		public static Filter GetFilterEx(this XElement element, Filter defaultValue)
		{
			string key = defaultValue?.Key, value = defaultValue?.Value;
			FilterType type = defaultValue?.Type ?? FilterType.Match;
			foreach (var el in CommonGetEx(element))
			{
				if (el.GetAttributeValueEx("name") is not string propertyName) continue;
				if (propertyName == nameof(defaultValue.Key)) key = el.Value;
				else if (propertyName == nameof(defaultValue.Value)) value = el.Value;
				else if (propertyName == nameof(defaultValue.Type)) type = el.GetEnumEx<FilterType>(type);
			}
			return new(key, value, type);
		}
	}

	static partial class ToXElement
	{
		public static XElement ToXElementEx(this Filter value, string elementName, string varName)
		{
			XElement ret = CommonToXElement(elementName, varName, nameof(Filter));
			ret.Add(
				value.Key.ToPropertyEx(nameof(value.Key)),
				value.Value.ToPropertyEx(nameof(value.Value)),
				value.Type.ToPropertyEx(nameof(value.Type))
				);
			return ret;
		}
	}

	static partial class ToProperty
	{
		public static XElement ToPropertyEx(this Filter value, string varName) => value.ToXElementEx("property", varName);
	}

	public enum FilterType
	{
		Match,
		NotMatch,
		Contain,
		NotContain,
		StartWith,
		NotStartWith,
		EndWith,
		NotEndWith,
		Greater,
		Less,
		GreaterEqual,
		LessEqual,
		GreaterByInt64,
		LessByInt64,
		GreaterEqualByInt64,
		LessEqualByInt64,
		GreaterByDouble,
		LessByDouble,
		GreaterEqualByDouble,
		LessEqualByDouble
	}

	static partial class ToEnumName
	{
		public static string ToEnumNameEx(FilterType value, int mode)
		{
			return value switch
			{
				FilterType.Match => "と一致する",
				FilterType.NotMatch => "と一致しない",
				FilterType.Contain => "を含む",
				FilterType.NotContain => "を含まない",
				FilterType.StartWith => "で始まる",
				FilterType.NotStartWith => "で始まらない",
				FilterType.EndWith => "で終わる",
				FilterType.NotEndWith => "で終わらない",
				FilterType.Greater => "より大きい",
				FilterType.Less => "より小さい",
				FilterType.GreaterEqual => "以上",
				FilterType.LessEqual => "以下",
				FilterType.GreaterByInt64 => "より大きい(整数比較)",
				FilterType.LessByInt64 => "より小さい(整数比較)",
				FilterType.GreaterEqualByInt64 => "以上(整数比較)",
				FilterType.LessEqualByInt64 => "以下(整数比較)",
				FilterType.GreaterByDouble => "より大きい(小数比較)",
				FilterType.LessByDouble => "より小さい(小数比較)",
				FilterType.GreaterEqualByDouble => "以上(小数比較)",
				FilterType.LessEqualByDouble => "以下(小数比較)",
				_ => ""
			};
		}
	}
}
