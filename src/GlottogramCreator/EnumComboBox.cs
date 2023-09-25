using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Reflection;
using System.Drawing.Design;
using System.Windows.Forms.Design;

namespace WinFormsApp1
{
	public class EnumComboBox : ComboBox
	{
		static Assembly ExecutingAssembly = Assembly.GetExecutingAssembly();
		static IEnumerable<Type> enumTypes = ExecutingAssembly.GetReferencedAssemblies().Select(x => System.Reflection.Assembly.Load(x)).Union(new Assembly[] { ExecutingAssembly }).SelectMany(x => x.GetTypes()).Where(x => x.IsEnum);

		enum ErrorType { None = 0 }

		Type enumType = typeof(ErrorType);

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new ObjectCollection Items => base.Items;

		[Browsable(true)]
		[Category("Extend")]
		[Description("表示するEnum型の名前")]
		public virtual string EnumName 
		{
			get => enumType.Name;
			set
			{
				EnumType = enumTypes.Where(x => x.Name == value).FirstOrDefault() ?? typeof(ErrorType);
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Type EnumType
		{
			get => enumType;
			set
			{
				if (!value.IsEnum) return;
				enumType = value;
				Items.Clear();
				Items.AddRange(enumType.GetEnumNamesEx(ConvertMode));
			}
		}

		[Browsable(true)]
		[Category("Extend")]
		[Description("Enumから変換する文字列を切り替える")]
		[DefaultValue(0)]
		public int ConvertMode { get; set; } = 0;

#nullable enable
		public Enum? GetItem(int index) => index == -1 || Items.Count <= index ? null : enumType.GetEnumValues().GetValue(index) is object obj ? Enum.ToObject(enumType, obj) as Enum : null;

		[Browsable(false)]
		public Enum? SelectedEnumValue
		{
			get => GetItem(SelectedIndex);
			set
			{
				if (value is null || value.GetType() != enumType) return;
				int index = enumType.GetEnumNames().ToList().IndexOf(value.ToString());
				if (index != -1) SelectedIndex = index;
			}
		}
#nullable restore

		/// <summary>
		/// 選択されている列挙型の値を取得する
		/// </summary>
		/// <typeparam name="T">取得する型を指定する</typeparam>
		/// <param name="defaultValue">取得できなかった場合に関数が返す値</param>
		/// <returns>選択されている値を返す。指定した列挙型とこのコンボボックスの列挙型が異なる場合や、列挙値を取得できなかった場合、第一引数の値を返す</returns>
		public T GetSelectedEnumValue<T>(T defaultValue) where T : Enum => SelectedEnumValue is T ret ? ret : defaultValue;
	}

	static partial class ToEnumName
	{
		public static string[] GetEnumNamesEx(this Type enumType, int mode)
		{
			if (enumType is null || !enumType.IsEnum) return new string[] { };
			Array values = enumType.GetEnumValues();
			if (values.Length == 0) return new string[] { };
			MethodInfo method = typeof(ToEnumName).GetMethod("ToEnumNameEx", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, new Type[] { enumType, typeof(int) });
			if (method is null) return enumType.GetEnumNames();
			List<string> ret = new(values.Length);
			foreach (object value in values)
			{
				object obj = Enum.ToObject(enumType, value);
				if (obj is null) continue;
				else
				{
					if (method.Invoke(null, new object[] { obj, mode }) is string result) ret.Add(result);
					else ret.Add(string.Empty);
				}
			}
			return ret.ToArray();
		}
	}
}
