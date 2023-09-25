using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
	static class EnumExtend
	{
		static readonly Type[] signedTypes = new Type[] { typeof(sbyte), typeof(short), typeof(int), typeof(long) };
		public static long ToInt64(this Enum value)
		{
			IConvertible convertible = value;
			try
			{
				return convertible.ToInt64(System.Globalization.CultureInfo.InvariantCulture);
			}
			catch
			{
				return 0;
			}
		}
		public static ulong ToUInt64(this Enum value)
		{
			IConvertible convertible = value;
			try
			{
				return convertible.ToUInt64(System.Globalization.CultureInfo.InvariantCulture);
			}
			catch
			{
				return 0;
			}
		}
		public static bool IsSigned(this Enum value)
		{
			Type type = Enum.GetUnderlyingType(value.GetType());
			return signedTypes.Contains(type);
		}
	}

	static class XDocumentExtend
	{
		static string ZipPassword = "Linguistic Atlas of Japan";

		/// <summary>
		/// URIからXDocumentオブジェクトを作成する。この関数は例外を投げない。
		/// </summary>
		/// <param name="uri">読み込むデータのURI</param>
		/// <returns>成功した場合、作成したXDocument。失敗した場合、null。</returns>
		public static XDocument LoadEx(string uri)
		{
			XDocument xDocument;
			try
			{
				using ICSharpCode.SharpZipLib.Zip.ZipFile zipFile = new(uri);
				zipFile.Password = ZipPassword;
				ICSharpCode.SharpZipLib.Zip.ZipEntry zipEntry = zipFile.GetEntry("Value.data");
				if (zipEntry is null) return null;
				using System.IO.Stream stream = zipFile.GetInputStream(zipEntry);
				byte[] buffer = new byte[zipEntry.Size];
				stream.Read(buffer, 0, buffer.Length);
				using System.IO.Stream bufStream = new System.IO.MemoryStream(buffer);
				using System.IO.StreamReader reader = new(bufStream);
				xDocument = XDocument.Load(reader);
			}
			catch
			{
				try
				{
					xDocument = XDocument.Load(uri);
					return xDocument;
				}
				catch {  }
				return null;
			}
			return xDocument;
		}

		/// <summary>
		/// XDocumentをZip形式で保存する
		/// </summary>
		/// <param name="document">保存するXDocument</param>
		/// <param name="fileName">保存するファイル名</param>
		/// <returns>保存に成功した場合、true。それ以外の場合、false</returns>
		public static bool SaveEx(this XDocument document, string fileName)
		{
			try
			{
				using System.IO.FileStream fileStream = new(fileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
				using ICSharpCode.SharpZipLib.Zip.ZipOutputStream zipOutputStream = new(fileStream);
				zipOutputStream.SetLevel(9);
				zipOutputStream.Password = ZipPassword;
				ICSharpCode.SharpZipLib.Zip.ZipEntry zipEntry = new("Value.data");
				zipOutputStream.PutNextEntry(zipEntry);
				byte[] utf8 = System.Text.Encoding.UTF8.GetBytes(document.ToString(SaveOptions.DisableFormatting));
				zipOutputStream.Write(utf8, 0, utf8.Length);
				zipOutputStream.Finish();
				zipOutputStream.Close();
			}
			catch
			{
				return false;
			}
			return true;
		}

		/// <summary>
		/// ルート要素として&lt;rootElementName&gt;&lt;/rootElementName&gt;を持つXDocumentを作成する。
		/// </summary>
		/// <param name="rootElementName">ルート要素名</param>
		/// <returns>新たに作成したXDocument</returns>
		public static XDocument CreateEx(string rootElementName)
		{
			XDocument ret = new();
			ret.Add(new XElement(rootElementName));
			return ret;
		}

		/// <summary>
		/// XDocumentのルート直下の要素から、&lt;elementName attributeName="attributeValue"&gt;&lt;/elementName&gt;を取得する。
		/// </summary>
		/// <param name="xDocument"></param>
		/// <param name="elementName">要素名</param>
		/// <param name="attributeName">属性名</param>
		/// <param name="attributeValue">属性attributeNameの値</param>
		/// <returns>初めに見つかった要素。存在しない場合、null</returns>
		public static XElement GetRootElementByNameEx(this XDocument xDocument, string elementName, string attributeName, string attributeValue)
		{
			if (xDocument is null || elementName is null) return null;
			XName name = elementName;
			XAttribute attribute = attributeName is not null && attributeValue is not null ? new XAttribute(attributeName, attributeValue) : null;
			IEnumerable<XElement> tmp = null;
			if (attribute is not null) tmp = xDocument.Root.Elements().Where(x => x.Name.LocalName == name && x.GetAttributeValueEx(attributeName) is string value && value == attributeValue);
			else tmp = xDocument.Root.Elements().Where(x => x.Name.LocalName == name);
			if (tmp.Any()) return tmp.First();
			else return null;
		}

		/// <summary>
		/// XDocumentのルート直下に、&lt;elementName attributeName="attributeValue"&gt;&lt;/elementName&gt;を追加する。
		/// </summary>
		/// <param name="xDocument"></param>
		/// <param name="elementName">要素名</param>
		/// <param name="attributeName">属性名</param>
		/// <param name="attributeValue">属性attibuteNameの値</param>
		/// <returns>追加した要素。指定した要素がすでに存在する場合、初めに見つかった要素。失敗した場合、null。</returns>
		public static XElement CreateRootElementEx(this XDocument xDocument, string elementName, string attributeName, string attributeValue)
		{
			if (xDocument is null || elementName is null) return null;
			XName name = elementName;
			XAttribute attribute = attributeName is not null && attributeValue is not null ? new XAttribute(attributeName, attributeValue) : null;
			IEnumerable<XElement> tmp = null;
			if (attribute is not null) tmp = xDocument.Root.Elements().Where(x => x.Name.LocalName == name && x.GetAttributeValueEx(attributeName) is string value && value == attributeValue);
			else tmp = xDocument.Root.Elements().Where(x => x.Name.LocalName == name);
			if (tmp.Any()) return tmp.First();
			if (attribute is null) xDocument.Root.Add(new XElement(elementName));
			else xDocument.Root.Add(new XElement(elementName, attribute));
			if (attribute is not null) tmp = xDocument.Root.Elements().Where(x => x.Name.LocalName == name && x.GetAttributeValueEx(attributeName) is string value && value == attributeValue);
			else tmp = xDocument.Root.Elements().Where(x => x.Name.LocalName == name);
			if (tmp.Any()) return tmp.First();
			else return null;
		}

		public static IEnumerable<XElement> GetElements(string uri)
		{
			using System.Xml.XmlReader reader = System.Xml.XmlReader.Create(uri);
			if (reader is null) yield break;
			reader.MoveToContent();
			XElement ret = null;
			XElement current = null;
			while (reader.Read())
			{
				switch (reader.NodeType)
				{
					case System.Xml.XmlNodeType.Element:
						if (current is null)
						{
							ret = new(reader.Name);
							current = ret;
						}
						else
						{
							XElement tmp = new(reader.Name);
							current.Add(tmp);
							current = tmp;
						}
						for (int i = 0, count = reader.AttributeCount; i < count; ++i)
						{
							reader.MoveToAttribute(i);
							current.Add(new XAttribute(reader.Name, reader.Value));
						}
						break;
					case System.Xml.XmlNodeType.EndElement:
						if (current?.Parent is null)
						{
							XElement el = ret;
							ret = null;
							current = null;
							yield return el;
						}
						else current = current.Parent;
						break;
					case System.Xml.XmlNodeType.Attribute:
						if (current is null) yield break;
						current.Add(new XAttribute(reader.Name, reader.Value));
						break;
					case System.Xml.XmlNodeType.Text:
						if (current is null) break;
						current.Add(reader.Value);
						break;
				}
			}
		}

		public static IEnumerable<XElement> GetElements(string uri, string attributeName, string[] attributeValues)
		{
			using System.Xml.XmlReader reader = System.Xml.XmlReader.Create(uri);
			if (reader is null) yield break;
			reader.MoveToContent();
			XElement ret = null;
			XElement current = null;
			while (reader.Read())
			{
				switch (reader.NodeType)
				{
					case System.Xml.XmlNodeType.Element:
						if (current is null)
						{
							ret = new(reader.Name);
							current = ret;
						}
						else
						{
							XElement tmp = new(reader.Name);
							current.Add(tmp);
							current = tmp;
							tmp = null;
						}
						for (int i = 0, count = reader.AttributeCount; i < count; ++i)
						{
							reader.MoveToAttribute(i);
							current.Add(new XAttribute(reader.Name, reader.Value));
						}
						if (current.Parent is null && !attributeValues.Contains(current.GetAttributeValueEx(attributeName)))
						{
							while (current is not null && reader.Read())
							{
								if (reader.NodeType == System.Xml.XmlNodeType.EndElement && reader.Name == current.Name)
								{
									current = current.Parent;
								}
							}
							ret = null;
						}
						break;
					case System.Xml.XmlNodeType.EndElement:
						if (current?.Parent is null)
						{
							{
								XElement el = ret;
								ret = null;
								current = null;
								if (el is null) yield break;
								else yield return el;
								el = null;
							}
							GC.Collect();
						}
						else current = current.Parent;
						break;
					case System.Xml.XmlNodeType.Attribute:
						if (current is null) yield break;
						current.Add(new XAttribute(reader.Name, reader.Value));
						break;
					case System.Xml.XmlNodeType.Text:
						if (current is null) break;
						current.Add(reader.Value);
						break;
				}
			}
		}
	}

	static partial class FromXElement
	{
		static IEnumerable<XElement> CommonGetEx(XElement element)
		{
			XName name = XName.Get("name");
			return element.Elements().Where(x => x.Attribute(name)?.Value is string);
		}

		public static T GetEnumEx<T>(this XElement element, T defaultValue) where T : Enum, IConvertible
		{
			object ret;
			try
			{
				if (defaultValue.IsSigned())
				{
					ret = Enum.ToObject(typeof(T), element.Value?.GetLongEx(defaultValue.ToInt64()) ?? defaultValue.ToInt64());
				}
				else
				{
					ret = Enum.ToObject(typeof(T), element.Value?.GetLongEx(defaultValue.ToInt64()) ?? defaultValue.ToInt64());
				}
				return (T)ret;
			}
			catch
			{
				return defaultValue;
			}
		}
		public static Enum GetEnumEx(this XElement element, Type type)
		{
			object ret;
			Enum defaultValue = Activator.CreateInstance(type) as Enum;
			if (defaultValue is null) return null;
			try
			{
				if (defaultValue.IsSigned())
				{
					ret = Enum.ToObject(type, element.Value?.GetLongEx(defaultValue.ToInt64()) ?? defaultValue.ToInt64());
				}
				else
				{
					ret = Enum.ToObject(type, element.Value?.GetLongEx(defaultValue.ToInt64()) ?? defaultValue.ToInt64());
				}
				return ret as Enum;
			}
			catch
			{
				return defaultValue;
			}
		}

		/// <summary>
		/// name属性がPenオブジェクトを指しているXElementからPenオブジェクトを作成する。
		/// </summary>
		/// <param name="element"></param>
		/// <param name="defaultValue">設定されていないプロパティに使用されるデフォルト値</param>
		/// <returns>新たに作成されたPenオブジェクト</returns>
		public static Pen GetPenEx(this XElement element, Pen defaultValue)
		{
			if (defaultValue is null) defaultValue = Pens.Black;
			Color color = defaultValue.Color;
			float width = defaultValue.Width;
			System.Drawing.Drawing2D.DashStyle style = defaultValue.DashStyle;
			foreach (var el in CommonGetEx(element))
			{
				string propertyName = el.GetAttributeValueEx("name") ?? string.Empty;
				if (propertyName == nameof(defaultValue.Color)) color = el.GetColorEx(color);
				else if (propertyName == nameof(defaultValue.Width)) width = el.Value.GetFloatEx(width);
				else if (propertyName == nameof(defaultValue.DashStyle)) style = el.GetEnumEx(style);
			}
			return InitializeHelper.CreatePen(color, width, style);
		}

		/// <summary>
		/// name属性がFontオブジェクトを指しているXElementからFontオブジェクトを作成する。
		/// </summary>
		/// <param name="element"></param>
		/// <param name="defaultValue">設定されていないプロパティに使用されるデフォルト値</param>
		/// <returns>新たに作成されたFontオブジェクト</returns>
		public static Font GetFontEx(this XElement element, Font defaultValue)
		{
			if (defaultValue is null) defaultValue = SystemFonts.DefaultFont;
			string familyName = defaultValue.FontFamily.Name;
			float size = defaultValue.Size;
			GraphicsUnit unit = defaultValue.Unit;
			foreach (var el in CommonGetEx(element))
			{
				string propertyName = el.GetAttributeValueEx("name") ?? string.Empty;
				if (propertyName == nameof(defaultValue.FontFamily.Name)) familyName = el.Value;
				else if (propertyName == nameof(defaultValue.Size)) size = el.Value.GetFloatEx(size);
				else if (propertyName == nameof(defaultValue.Unit)) unit = el.GetEnumEx(unit);
			}
			try
			{
				return new Font(familyName, size, unit);
			}
			catch
			{
				return defaultValue.Clone() as Font;
			}
		}

		/// <summary>
		/// name属性がSolidBrushオブジェクトを指しているXElementからSolidBrushオブジェクトを作成する。
		/// </summary>
		/// <param name="element"></param>
		/// <param name="defaultValue">設定されていないプロパティに使用されるデフォルト値</param>
		/// <returns>新たに作成されたSolidBrushオブジェクト</returns>
		public static SolidBrush GetSolidBrushEx(this XElement element, SolidBrush defaultValue)
		{
			if (defaultValue is null) defaultValue = new(default);
			Color color = defaultValue.Color;
			foreach (var el in CommonGetEx(element))
			{
				string propertyName = el.GetAttributeValueEx("name") ?? string.Empty;
				if (propertyName == nameof(defaultValue.Color)) color = el.GetColorEx(color);
			}
			return new SolidBrush(color);
		}

		/// <summary>
		/// name属性がStringFormatオブジェクトを指しているXElementからStringFormatオブジェクトを作成する。
		/// </summary>
		/// <param name="element"></param>
		/// <param name="defaultValue">設定されていないプロパティに使用されるデフォルト値</param>
		/// <returns>新たに作成されたStringFormatオブジェクト</returns>
		public static StringFormat GetStringFormatEx(this XElement element, StringFormat defaultValue)
		{
			if (defaultValue is null) defaultValue = new();
			StringAlignment alignment = defaultValue.Alignment;
			StringAlignment lineAlignment = defaultValue.LineAlignment;
			foreach (var el in CommonGetEx(element))
			{
				string propertyName = el.GetAttributeValueEx("name") ?? string.Empty;
				if (propertyName == nameof(defaultValue.Alignment)) alignment = el.GetEnumEx(alignment);
				else if (propertyName == nameof(defaultValue.LineAlignment)) lineAlignment = el.GetEnumEx(lineAlignment);
			}
			return InitializeHelper.CreateStringFormat(alignment, lineAlignment);
		}

		/// <summary>
		/// name属性がPaddingオブジェクトを指しているXElementからPaddingオブジェクトを作成する。
		/// </summary>
		/// <param name="element"></param>
		/// <param name="defaultValue">設定されていないプロパティに使用されるデフォルト値</param>
		/// <returns>新たに作成されたPaddingオブジェクト</returns>
		public static Padding GetPaddingEx(this XElement element, Padding defaultValue)
		{
			int left = defaultValue.Left, top = defaultValue.Top, right = defaultValue.Right, bottom = defaultValue.Bottom;
			foreach (var el in CommonGetEx(element))
			{
				string propertyName = el.GetAttributeValueEx("name") ?? string.Empty;
				if (propertyName == nameof(defaultValue.Left)) left = el.Value.GetIntEx(left);
				else if (propertyName == nameof(defaultValue.Top)) top = el.Value.GetIntEx(top);
				else if (propertyName == nameof(defaultValue.Right)) right = el.Value.GetIntEx(right);
				else if (propertyName == nameof(defaultValue.Bottom)) bottom = el.Value.GetIntEx(bottom);
			}
			return new Padding(left, top, right, bottom);
		}

		/// <summary>
		/// name属性がColorオブジェクトを指しているXElementからColorオブジェクトを作成する。
		/// </summary>
		/// <param name="element"></param>
		/// <param name="defaultValue">設定されていないプロパティに使用されるデフォルト値</param>
		/// <returns>新たに作成されたColorオブジェクト</returns>
		public static Color GetColorEx(this XElement element, Color defaultValue)
		{
			byte a = defaultValue.A, r = defaultValue.R, g = defaultValue.G, b = defaultValue.B;
			foreach (var el in CommonGetEx(element))
			{
				string propertyName = el.GetAttributeValueEx("name") ?? string.Empty;
				if (propertyName == nameof(defaultValue.A)) a = el.Value.GetByteEx(a);
				else if (propertyName == nameof(defaultValue.R)) r = el.Value.GetByteEx(r);
				else if (propertyName == nameof(defaultValue.G)) g = el.Value.GetByteEx(g);
				else if (propertyName == nameof(defaultValue.B)) b = el.Value.GetByteEx(b);
			}
			return Color.FromArgb(a, r, g, b);
		}

		/// <summary>
		/// name属性がRectangleFオブジェクトを指しているXElementからRectangleFオブジェクトを作成する。
		/// </summary>
		/// <param name="element"></param>
		/// <param name="defaultValue">設定されていないプロパティに使用されるデフォルト値</param>
		/// <returns>新たに作成されたRectangleFオブジェクト</returns>
		public static RectangleF GetRectangleFEx(this XElement element, RectangleF defaultValue)
		{
			float x = defaultValue.X, y = defaultValue.Y, w = defaultValue.Width, h = defaultValue.Height;
			foreach (var el in CommonGetEx(element))
			{
				if (el.GetAttributeValueEx("name") is not String propertyName) continue;
				if (propertyName == nameof(defaultValue.X)) x = el.Value.GetFloatEx(x);
				else if (propertyName == nameof(defaultValue.Y)) y = el.Value.GetFloatEx(y);
				else if (propertyName == nameof(defaultValue.Width)) w = el.Value.GetFloatEx(w);
				else if (propertyName == nameof(defaultValue.Height)) h = el.Value.GetFloatEx(h);
			}
			return new RectangleF(x, y, w, h);
		}

		public static System.Runtime.CompilerServices.ITuple GetTupleEx(this XElement element, Type tupleType = null)
		{
			if (tupleType is null) tupleType = element.GetAttributeValueEx("type") is not string typeName ? typeof(ValueTuple<>) : Type.GetType(typeName) ?? typeof(ValueTuple<>);
			var items = element.Elements().Where(x => x.Name == "item");
			Type[] args = items.Where(x => x.GetAttributeValueEx("type") is not null).Select(x => Type.GetType(x.GetAttributeValueEx("type"))).ToArray();
			if (tupleType.IsGenericTypeDefinition) tupleType = tupleType.MakeGenericType(args) ?? typeof(ValueTuple<>).MakeGenericType(new Type[] { typeof(object) });
			System.Runtime.CompilerServices.ITuple tuple = Activator.CreateInstance(tupleType, null) as System.Runtime.CompilerServices.ITuple;
			if (tuple is null) tuple = new ValueTuple<object>();
			if (!items.Any()) return tuple;
			Func<System.Reflection.MethodInfo, Type, bool> func =
				(System.Reflection.MethodInfo x, Type type) => {
					var para = x.GetParameters();
					if (para.Length == 2)
					{
						return para[0].ParameterType == typeof(XElement) && para[1].ParameterType == type && x.Name == "Get" + type.Name + "Ex";
					}
					else return false;
				};
			var methods = typeof(FromXElement).GetMethods(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic)
				.Where(x => x.IsDefined(typeof(System.Runtime.CompilerServices.ExtensionAttribute), false));
			int i = 0, count = items.Count();
			Type currentTupleType = tupleType;
			System.Runtime.CompilerServices.ITuple currentTuple = tuple;
			foreach (var el in items)
			{
				Type itemType = Type.GetType(el.GetAttributeValueEx("type") ?? string.Empty) ?? typeof(object);
				string value = el.Value;
				int index = (i % 7) + 1;
				System.Reflection.FieldInfo fieldInfo = currentTupleType.GetField("Item" + index.ToString());
				if (itemType == typeof(byte)) fieldInfo?.SetValue(currentTuple, value.GetByteEx());
				else if (itemType == typeof(sbyte)) fieldInfo?.SetValue(currentTuple, value.GetSByteEx());
				else if (itemType == typeof(short)) fieldInfo?.SetValue(currentTuple, value.GetShortEx());
				else if (itemType == typeof(ushort)) fieldInfo?.SetValue(currentTuple, value.GetUShortEx());
				else if (itemType == typeof(int)) fieldInfo?.SetValue(currentTuple, value.GetIntEx());
				else if (itemType == typeof(uint)) fieldInfo?.SetValue(currentTuple, value.GetUIntEx());
				else if (itemType == typeof(long)) fieldInfo?.SetValue(currentTuple, value.GetLongEx());
				else if (itemType == typeof(ulong)) fieldInfo?.SetValue(currentTuple, value.GetULongEx());
				else if (itemType == typeof(float)) fieldInfo?.SetValue(currentTuple, value.GetFloatEx());
				else if (itemType == typeof(double)) fieldInfo?.SetValue(currentTuple, value.GetDoubleEx());
				else if (itemType == typeof(bool)) fieldInfo?.SetValue(currentTuple, value.GetBoolEx());
				else if (itemType == typeof(string)) fieldInfo?.SetValue(currentTuple, value);
				else if (itemType.IsEnum) fieldInfo?.SetValue(currentTuple, el.GetEnumEx(itemType));
				else
				{
					System.Reflection.MethodInfo method = null;
					foreach (var m in methods)
					{
						var para = m.GetParameters();
						if (para.Length == 2)
						{
							if (para[0].ParameterType == typeof(XElement) && para[1].ParameterType == itemType && m.Name == "Get" + itemType.Name + "Ex")
							{
								method = m;
								break;
							}
						}
					}
					if (method is null) fieldInfo?.SetValue(currentTuple, null);
					else
					{
						object defaultValue = itemType.IsValueType ? Activator.CreateInstance(itemType) : null;
						fieldInfo?.SetValue(currentTuple, method.Invoke(null, new object[] { el, defaultValue }));
					}
				}
				if (++i >= count) break;
				if (index == 7)
				{
					currentTuple = currentTupleType?.GetField("Rest")?.GetValue(tuple) as System.Runtime.CompilerServices.ITuple;
					currentTupleType = currentTuple?.GetType();
					if (currentTuple is null || currentTupleType is null) return tuple;
				}
			}
			return tuple;
		}

		public static (int, int) GetIntTupleEx(this XElement element, (int, int) defaultValue)
		{
			foreach (var el in CommonGetEx(element))
			{
				string propertyName = el.GetAttributeValueEx("name") ?? string.Empty;
				if (propertyName == nameof(defaultValue.Item1)) defaultValue.Item1 = el.Value.GetIntEx(defaultValue.Item1);
				else if (propertyName == nameof(defaultValue.Item2)) defaultValue.Item2 = el.Value.GetIntEx(defaultValue.Item2);
			}
			return defaultValue;
		}

		/// <summary>
		/// name属性がListオブジェクトを指しているXElementからListオブジェクトを作成する。
		/// </summary>
		/// <param name="element"></param>
		/// <returns>新たに作成されたListオブジェクト</returns>
		public static System.Collections.IList GetListEx(this XElement element)
		{
			Type type = typeof(object);
			if (element.GetAttributeValueEx("generic_type") is string typeName) type = Type.GetType(typeName) ?? typeof(object);
			Type listType = typeof(List<>).MakeGenericType(new Type[] { type });
			System.Collections.IList list = listType.GetConstructor(Type.EmptyTypes)?.Invoke(null) as System.Collections.IList;
			if (list is null) list = new List<object>();
			var tmp = CommonGetEx(element).Where(x => nameof(list.Count) == (x.GetAttributeValueEx("name") ?? string.Empty));
			int count = 0;
			if (tmp.Any()) count = tmp.First().Value?.GetIntEx(count) ?? count;
			if (count == 0) return list;
			tmp = element.Elements().Where(x => x.Name == "items");
			if (!tmp.Any()) return list;
			Func<System.Reflection.MethodInfo, bool> func = 
				(System.Reflection.MethodInfo x) => {
					var para = x.GetParameters();
					if (para.Length == 2)
					{
						return para[0].ParameterType == typeof(XElement) && para[1].ParameterType == type && x.Name == "Get" + type.Name + "Ex";
					}
					else return false;
				};
			var methods = typeof(FromXElement).GetMethods(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic)
				.Where(x => x.IsDefined(typeof(System.Runtime.CompilerServices.ExtensionAttribute), false)).Where(func);
			var method = methods.Any() ? methods.First() : null;
			object defaultValue = type.IsValueType ? Activator.CreateInstance(type) : null;
			foreach (var el in tmp.First().Elements())
			{
				if (el.Name != "item") continue;
				string value = el.Value;
				if (type == typeof(byte)) list.Add(value.GetByteEx());
				else if (type == typeof(sbyte)) list.Add(value.GetSByteEx());
				else if (type == typeof(short)) list.Add(value.GetShortEx());
				else if (type == typeof(ushort)) list.Add(value.GetUShortEx());
				else if (type == typeof(uint)) list.Add(value.GetUIntEx());
				else if (type == typeof(int)) list.Add(value.GetIntEx());
				else if (type == typeof(long)) list.Add(value.GetLongEx());
				else if (type == typeof(ulong)) list.Add(value.GetULongEx());
				else if (type == typeof(bool)) list.Add(value.GetBoolEx());
				else if (type == typeof(string)) list.Add(value);
				else if (type.IsEnum) list.Add(el.GetEnumEx(type));
				else if (type.GetInterfaces().Contains(typeof(System.Runtime.CompilerServices.ITuple))) list.Add(el.GetTupleEx(type));
				else
				{
					if (method is null) list.Add(null);
					else list.Add(method.Invoke(null, new object[] { el, defaultValue }));
				}
			}
			return list;
		}

		/// <summary>
		/// 要素内の属性名から値を取得する。
		/// </summary>
		/// <param name="element"></param>
		/// <param name="attributeName">取得する値の属性名</param>
		/// <returns>属性の値。存在しない場合、null</returns>
		public static string GetAttributeValueEx(this XElement element, string attributeName)
		{
			return element.Attribute(attributeName)?.Value;
		}

		public static Bitmap GetBitmapEx(this XElement element, Bitmap defaultValue)
		{
			string bufferString = string.Empty;
			foreach (var el in CommonGetEx(element))
			{
				string propertyName = el.GetAttributeValueEx("name") ?? string.Empty;
				if (propertyName == "Buffer") bufferString = el.Value;
			}
			if (string.IsNullOrEmpty(bufferString)) return defaultValue;
			byte[] buffer = System.Convert.FromBase64String(bufferString);
			if (buffer is null || buffer.Length == 0) return defaultValue;
			using System.IO.MemoryStream stream = new(buffer);
			return new Bitmap(Image.FromStream(stream)) ?? defaultValue;
		}
	}

	static partial class ToXElement
	{
		static class ToItem_Function
		{
			static XElement CommonToItem(int index)
			{
				XElement ret = new("item", new XAttribute("index", index.ToString()));
				return ret;
			}
			static XElement ToItem_Internal<T>(T value, int index)
			{
				XElement ret = CommonToItem(index);
				ret.SetValue(value.ToString());
				return ret;
			}

			static XElement ToItem(byte value, int index) => ToItem_Internal(value, index);
			static XElement ToItem(sbyte value, int index) => ToItem_Internal(value, index);
			static XElement ToItem(short value, int index) => ToItem_Internal(value, index);
			static XElement ToItem(ushort value, int index) => ToItem_Internal(value, index);
			static XElement ToItem(int value, int index) => ToItem_Internal(value, index);
			static XElement ToItem(uint value, int index) => ToItem_Internal(value, index);
			static XElement ToItem(ulong value, int index) => ToItem_Internal(value, index);
			static XElement ToItem(long value, int index) => ToItem_Internal(value, index);
			static XElement ToItem(float value, int index) => ToItem_Internal(value, index);
			static XElement ToItem(double value, int index) => ToItem_Internal(value, index);
			static XElement ToItem(bool value, int index) => ToItem_Internal(value, index);
			static XElement ToItem(string value, int index) => ToItem_Internal(value, index);
			static XElement ToItem(Enum value, int index)
			{
				if (value.IsSigned()) return ToItem(value.ToInt64(), index);
				else return ToItem(value.ToUInt64(), index);
			}
			static XElement ToItem(System.Runtime.CompilerServices.ITuple value, int index)
			{
				Type tupleType = value.GetType();
				Type[] args = tupleType.IsGenericType ? tupleType.GetGenericArguments() : new Type[value.Length];
				XElement ret = new("item", new XAttribute("index", index.ToString()));
				for (int i = 0, count = value.Length; i < count; ++i)
				{
					XElement item = ToItem(value[i], i);
					if (args[i] is null) args[i] = value[i].GetType();
					item.SetAttributeValue("type", args[i].FullName);
					ret.Add(item);
				}
				return ret;
			}

			public static XElement ToItem<T>(T value, int index)
			{
				if (value is byte by) return ToItem(by, index);
				else if (value is sbyte sb) return ToItem(sb, index);
				else if (value is ushort us) return ToItem(us, index);
				else if (value is short sh) return ToItem(sh, index);
				else if (value is uint ui) return ToItem(ui, index);
				else if (value is int i) return ToItem(i, index);
				else if (value is ulong ul) return ToItem(ul, index);
				else if (value is long l) return ToItem(l, index);
				else if (value is float f) return ToItem(f, index);
				else if (value is double d) return ToItem(d, index);
				else if (value is bool bo) return ToItem(bo, index);
				else if (value is string s) return ToItem(s, index);
				else if (value is Enum e) return ToItem(e, index);
				else if (value is System.Runtime.CompilerServices.ITuple it) return ToItem(it, index);
				else
				{
					XElement ret = null;
					Type type = value.GetType();
					var methods = typeof(ToXElement).GetMethods(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic)
						.Where(x => x.IsDefined(typeof(System.Runtime.CompilerServices.ExtensionAttribute), false)).Where(x => x.GetParameters()[0].ParameterType == type && x.Name == "ToXElementEx");
					if (!methods.Any()) ret = CommonToItem(index);
					else if (methods.Count() == 1)
					{
						ret = methods.First().Invoke(null, new object[] { value, "item", null }) as XElement;
						ret.Attribute("type")?.Remove();
						ret.SetAttributeValue("index", index);
					}
					return ret;
				}
			}
		}

		static XElement CommonToXElement(string elementName, string varName, string typeName)
		{
			XElement ret = new(elementName);
			if (typeName is not null) ret.SetAttributeValue("type", typeName);
			if (varName is not null) ret.SetAttributeValue("name", varName);
			return ret;
		}
		static XElement CommonToXElement(this System.Collections.IList value, string elementName, string varName, string genericTypeName)
		{
			XElement ret = new(elementName, new XAttribute("type", typeof(List<int>).Name));
			if (genericTypeName is not null) ret.SetAttributeValue("generic_type", genericTypeName);
			if (varName is not null) ret.SetAttributeValue("name", varName);
			ret.Add(value.Count.ToPropertyEx(nameof(value.Count)));
			return ret;
		}

		static XElement ToXElement_Internal<T>(this T value, string elementName, string varName)
		{
			XElement ret = CommonToXElement(elementName, varName, typeof(T).Name);
			if (value.ToString() is string s) ret.SetValue(s);
			return ret;
		}

		public static XElement ToXElementEx(this byte value, string elementName, string varName) => value.ToXElement_Internal(elementName, varName);
		public static XElement ToXElementEx(this int value, string elementName, string varName) => value.ToXElement_Internal(elementName, varName);
		public static XElement ToXElementEx(this uint value, string elementName, string varName) => value.ToXElement_Internal(elementName, varName);
		public static XElement ToXElementEx(this long value, string elementName, string varName) => value.ToXElement_Internal(elementName, varName);
		public static XElement ToXElementEx(this ulong value, string elementName, string varName) => value.ToXElement_Internal(elementName, varName);
		public static XElement ToXElementEx(this float value, string elementName, string varName) => value.ToXElement_Internal(elementName, varName);
		public static XElement ToXElementEx(this bool value, string elementName, string varName) => value.ToXElement_Internal(elementName, varName);
		public static XElement ToXElementEx(this string value, string elementName, string varName) => value.ToXElement_Internal(elementName, varName);
		public static XElement ToXElementEx(this Enum value, string elementName, string varName)
		{
			XElement ret = CommonToXElement(elementName, varName, value.GetType().Name);
			if (value.IsSigned()) ret.SetValue(value.ToInt64().ToString());
			else ret.SetValue(value.ToUInt64().ToString());
			return ret;
		}
		public static XElement ToXElementEx(this Color value, string elementName, string varName)
		{
			XElement ret = CommonToXElement(elementName, varName, nameof(Color));
			ret.Add(
				value.A.ToPropertyEx(nameof(value.A)),
				value.R.ToPropertyEx(nameof(value.R)),
				value.G.ToPropertyEx(nameof(value.G)),
				value.B.ToPropertyEx(nameof(value.B))
				);
			return ret;
		}
		public static XElement ToXElementEx(this Pen value, string elementName, string varName)
		{
			XElement ret = CommonToXElement(elementName, varName, nameof(Pen));
			ret.Add(
				value.Color.ToPropertyEx(nameof(value.Color)),
				value.Width.ToPropertyEx(nameof(value.Width)),
				value.DashStyle.ToPropertyEx(nameof(value.DashStyle))
				);
			return ret;
		}
		public static XElement ToXElementEx(this Font value, string elementName, string varName)
		{
			XElement ret = CommonToXElement(elementName, varName, nameof(Font));
			ret.Add(
				value.FontFamily.Name.ToPropertyEx(nameof(value.FontFamily.Name)),
				value.Size.ToPropertyEx(nameof(value.Size)),
				value.Unit.ToPropertyEx(nameof(value.Unit))
				);
			return ret;
		}
		public static XElement ToXElementEx(this SolidBrush value, string elementName, string varName)
		{
			XElement ret = CommonToXElement(elementName, varName, nameof(SolidBrush));
			ret.Add(
				value.Color.ToPropertyEx(nameof(value.Color))
				);
			return ret;
		}
		public static XElement ToXElementEx(this StringFormat value, string elementName, string varName)
		{
			XElement ret = CommonToXElement(elementName, varName, nameof(StringFormat));
			ret.Add(
				value.Alignment.ToPropertyEx(nameof(value.Alignment)),
				value.LineAlignment.ToPropertyEx(nameof(value.LineAlignment))
				);
			return ret;
		}
		public static XElement ToXElementEx(this Padding value, string elementName, string varName)
		{
			XElement ret = CommonToXElement(elementName, varName, nameof(Padding));
			ret.Add(
				value.Left.ToPropertyEx(nameof(value.Left)),
				value.Top.ToPropertyEx(nameof(value.Top)),
				value.Right.ToPropertyEx(nameof(value.Right)),
				value.Bottom.ToPropertyEx(nameof(value.Bottom))
				);
			return ret;
		}
		public static XElement ToXElementEx(this RectangleF value, string elementName, string varName)
		{
			XElement ret = CommonToXElement(elementName, varName, nameof(RectangleF));
			ret.Add(
				value.X.ToPropertyEx(nameof(value.X)),
				value.Y.ToPropertyEx(nameof(value.Y)),
				value.Width.ToPropertyEx(nameof(value.Width)),
				value.Height.ToPropertyEx(nameof(value.Height))
				);
			return ret;
		}
		public static XElement ToXElementEx(this System.Runtime.CompilerServices.ITuple value, string elementName, string varName)
		{
			Type tupleType = value.GetType();
			Type[] args = tupleType.IsGenericType ? tupleType.GetGenericArguments() : new Type[value.Length];
			XElement ret = new(elementName, new XAttribute("type", tupleType.FullName), new XAttribute("name", varName));
			for (int i = 0, count = value.Length; i < count; ++i)
			{
				XElement item = ToItem_Function.ToItem(value[i], i);
				if (args[i] is null) args[i] = value[i].GetType();
				item.SetAttributeValue("type", args[i].FullName);
				ret.Add(item);
			}
			return ret;
		}
		public static XElement ToXElementEx(this System.Collections.IList value, string elementName, string varName)
		{
			Type type = null;
			if (value.Count != 0) type = value[0].GetType();
			else type = typeof(object);
			XElement ret = value.CommonToXElement(elementName, varName, type.FullName);
			XElement items = new("items", new XAttribute("type", type.Name));
			for (int i = 0, count = value.Count; i < count; ++i) items.Add(ToItem_Function.ToItem(value[i], i));
			ret.Add(items);
			return ret;
		}

		public static XElement ToXElementEx(this Bitmap value, string elementName, string varName)
		{
			using System.IO.MemoryStream stream = new();
			try
			{
				value.Save(stream, value.RawFormat);
			}
			catch
			{
				value.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
			}
			stream.Position = 0;
			byte[] buffer = stream.GetBuffer();
			XElement ret = CommonToXElement(elementName, varName, nameof(Bitmap));
			XElement property = new XElement("property", new XAttribute("type", typeof(byte[]).Name), new XAttribute("name", "Buffer"));
			property.Add(System.Convert.ToBase64String(buffer));
			ret.Add(property);
			return ret;
		}
	}

	static partial class ToProperty
	{
		public static XElement ToPropertyEx(this byte value, string name) => value.ToXElementEx("property", name);
		public static XElement ToPropertyEx(this int value, string name) => value.ToXElementEx("property", name);
		public static XElement ToPropertyEx(this uint value, string name) => value.ToXElementEx("property", name);
		public static XElement ToPropertyEx(this long value, string name) => value.ToXElementEx("property", name);
		public static XElement ToPropertyEx(this ulong value, string name) => value.ToXElementEx("property", name);
		public static XElement ToPropertyEx(this float value, string name) => value.ToXElementEx("property", name);
		public static XElement ToPropertyEx(this bool value, string name) => value.ToXElementEx("property", name);
		public static XElement ToPropertyEx(this string value, string name) => value.ToXElementEx("property", name);
		public static XElement ToPropertyEx(this Enum value, string name) => value.ToXElementEx("property", name);
		public static XElement ToPropertyEx(this Color value, string name) => value.ToXElementEx("property", name);
		public static XElement ToPropertyEx(this Pen value, string name) => value.ToXElementEx("property", name);
		public static XElement ToPropertyEx(this Font value, string name) => value.ToXElementEx("property", name);
		public static XElement ToPropertyEx(this SolidBrush value, string name) => value.ToXElementEx("property", name);
		public static XElement ToPropertyEx(this StringFormat value, string name) => value.ToXElementEx("property", name);
		public static XElement ToPropertyEx(this Padding value, string name) => value.ToXElementEx("property", name);
		public static XElement ToPropertyEx(this RectangleF value, string name) => value.ToXElementEx("property", name);
		public static XElement ToPropertyEX(this Bitmap value, string name) => value.ToXElementEx("property", name);
		public static XElement ToPropertyEx(this System.Runtime.CompilerServices.ITuple value, string name) => value.ToXElementEx("property", name);
		public static XElement ToPropertyEx(this System.Collections.IList value, string name) => value.ToXElementEx("property", name);
	}
}
