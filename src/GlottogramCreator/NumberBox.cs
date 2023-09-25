using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Xml.Linq;
using Windows.Foundation.Collections;
using System.Drawing;
using System.Reflection;
using System.Globalization;

namespace WinFormsApp1
{
	public class NumberBox : TextBox
	{
		static readonly IEnumerable<Type> AllowTypes = new Type[]
		{
			typeof(byte), typeof(sbyte), typeof(short), typeof(ushort),
			typeof(int), typeof(uint), typeof(long), typeof(ulong), typeof(float), typeof(double), typeof(decimal)
		};
		static readonly IEnumerable<Type> SignedAllowTypes = new Type[]
		{
			typeof(sbyte), typeof(short), typeof(int),
			typeof(long), typeof(float), typeof(double), typeof(decimal)
		};

		Type type = typeof(int);
		object valueMin = int.MinValue;
		object valueMax = int.MaxValue;
		object defaultValue = 0;
		object value = null;
		string viewFormat = null;

		static bool TryConvert(object src, Type dstType, out object result)
		{
			result = null;
			if (src is null || !AllowTypes.Contains(dstType)) return result is not null;
			if (src.GetType() == dstType) result = src;
			else if (src is byte b)
			{
				if (dstType == typeof(byte)) result = (byte)b;
				else if (dstType == typeof(sbyte)) result = (sbyte)b;
				else if (dstType == typeof(short)) result = (short)b;
				else if (dstType == typeof(ushort)) result = (ushort)b;
				else if (dstType == typeof(int)) result = (int)b;
				else if (dstType == typeof(uint)) result = (uint)b;
				else if (dstType == typeof(long)) result = (long)b;
				else if (dstType == typeof(ulong)) result = (ulong)b;
				else if (dstType == typeof(float)) result = (float)b;
				else if (dstType == typeof(double)) result = (double)b;
				else if (dstType == typeof(decimal)) result = (decimal)b;
			}
			else if (src is sbyte sb)
			{
				if (dstType == typeof(byte)) result = (byte)sb;
				else if (dstType == typeof(sbyte)) result = (sbyte)sb;
				else if (dstType == typeof(short)) result = (short)sb;
				else if (dstType == typeof(ushort)) result = (ushort)sb;
				else if (dstType == typeof(int)) result = (int)sb;
				else if (dstType == typeof(uint)) result = (uint)sb;
				else if (dstType == typeof(long)) result = (long)sb;
				else if (dstType == typeof(ulong)) result = (ulong)sb;
				else if (dstType == typeof(float)) result = (float)sb;
				else if (dstType == typeof(double)) result = (double)sb;
				else if (dstType == typeof(decimal)) result = (decimal)sb;
			}
			else if (src is short s)
			{
				if (dstType == typeof(byte)) result = (byte)s;
				else if (dstType == typeof(sbyte)) result = (sbyte)s;
				else if (dstType == typeof(short)) result = (short)s;
				else if (dstType == typeof(ushort)) result = (ushort)s;
				else if (dstType == typeof(int)) result = (int)s;
				else if (dstType == typeof(uint)) result = (uint)s;
				else if (dstType == typeof(long)) result = (long)s;
				else if (dstType == typeof(ulong)) result = (ulong)s;
				else if (dstType == typeof(float)) result = (float)s;
				else if (dstType == typeof(double)) result = (double)s;
				else if (dstType == typeof(decimal)) result = (decimal)s;
			}
			else if (src is ushort us)
			{
				if (dstType == typeof(byte)) result = (byte)us;
				else if (dstType == typeof(sbyte)) result = (sbyte)us;
				else if (dstType == typeof(short)) result = (short)us;
				else if (dstType == typeof(ushort)) result = (ushort)us;
				else if (dstType == typeof(int)) result = (int)us;
				else if (dstType == typeof(uint)) result = (uint)us;
				else if (dstType == typeof(long)) result = (long)us;
				else if (dstType == typeof(ulong)) result = (ulong)us;
				else if (dstType == typeof(float)) result = (float)us;
				else if (dstType == typeof(double)) result = (double)us;
				else if (dstType == typeof(decimal)) result = (decimal)us;
			}
			else if (src is int i)
			{
				if (dstType == typeof(byte)) result = (byte)i;
				else if (dstType == typeof(sbyte)) result = (sbyte)i;
				else if (dstType == typeof(short)) result = (short)i;
				else if (dstType == typeof(ushort)) result = (ushort)i;
				else if (dstType == typeof(int)) result = (int)i;
				else if (dstType == typeof(uint)) result = (uint)i;
				else if (dstType == typeof(long)) result = (long)i;
				else if (dstType == typeof(ulong)) result = (ulong)i;
				else if (dstType == typeof(float)) result = (float)i;
				else if (dstType == typeof(double)) result = (double)i;
				else if (dstType == typeof(decimal)) result = (decimal)i;
			}
			else if (src is uint ui)
			{
				if (dstType == typeof(byte)) result = (byte)ui;
				else if (dstType == typeof(sbyte)) result = (sbyte)ui;
				else if (dstType == typeof(short)) result = (short)ui;
				else if (dstType == typeof(ushort)) result = (ushort)ui;
				else if (dstType == typeof(int)) result = (int)ui;
				else if (dstType == typeof(uint)) result = (uint)ui;
				else if (dstType == typeof(long)) result = (long)ui;
				else if (dstType == typeof(ulong)) result = (ulong)ui;
				else if (dstType == typeof(float)) result = (float)ui;
				else if (dstType == typeof(double)) result = (double)ui;
				else if (dstType == typeof(decimal)) result = (decimal)ui;
			}
			else if (src is long l)
			{
				if (dstType == typeof(byte)) result = (byte)l;
				else if (dstType == typeof(sbyte)) result = (sbyte)l;
				else if (dstType == typeof(short)) result = (short)l;
				else if (dstType == typeof(ushort)) result = (ushort)l;
				else if (dstType == typeof(int)) result = (int)l;
				else if (dstType == typeof(uint)) result = (uint)l;
				else if (dstType == typeof(long)) result = (long)l;
				else if (dstType == typeof(ulong)) result = (ulong)l;
				else if (dstType == typeof(float)) result = (float)l;
				else if (dstType == typeof(double)) result = (double)l;
				else if (dstType == typeof(decimal)) result = (decimal)l;
			}
			else if (src is ulong ul)
			{
				if (dstType == typeof(byte)) result = (byte)ul;
				else if (dstType == typeof(sbyte)) result = (sbyte)ul;
				else if (dstType == typeof(short)) result = (short)ul;
				else if (dstType == typeof(ushort)) result = (ushort)ul;
				else if (dstType == typeof(int)) result = (int)ul;
				else if (dstType == typeof(uint)) result = (uint)ul;
				else if (dstType == typeof(long)) result = (long)ul;
				else if (dstType == typeof(ulong)) result = (ulong)ul;
				else if (dstType == typeof(float)) result = (float)ul;
				else if (dstType == typeof(double)) result = (double)ul;
				else if (dstType == typeof(decimal)) result = (decimal)ul;
			}
			else if (src is float f)
			{
				if (dstType == typeof(byte)) result = (byte)f;
				else if (dstType == typeof(sbyte)) result = (sbyte)f;
				else if (dstType == typeof(short)) result = (short)f;
				else if (dstType == typeof(ushort)) result = (ushort)f;
				else if (dstType == typeof(int)) result = (int)f;
				else if (dstType == typeof(uint)) result = (uint)f;
				else if (dstType == typeof(long)) result = (long)f;
				else if (dstType == typeof(ulong)) result = (ulong)f;
				else if (dstType == typeof(float)) result = (float)f;
				else if (dstType == typeof(double)) result = (double)f;
				else if (dstType == typeof(decimal)) result = (decimal)f;
			}
			else if (src is double d)
			{
				if (dstType == typeof(byte)) result = (byte)d;
				else if (dstType == typeof(sbyte)) result = (sbyte)d;
				else if (dstType == typeof(short)) result = (short)d;
				else if (dstType == typeof(ushort)) result = (ushort)d;
				else if (dstType == typeof(int)) result = (int)d;
				else if (dstType == typeof(uint)) result = (uint)d;
				else if (dstType == typeof(long)) result = (long)d;
				else if (dstType == typeof(ulong)) result = (ulong)d;
				else if (dstType == typeof(float)) result = (float)d;
				else if (dstType == typeof(double)) result = (double)d;
				else if (dstType == typeof(decimal)) result = (decimal)d;
			}
			else if (src is decimal dec)
			{
				if (dstType == typeof(byte)) result = (byte)dec;
				else if (dstType == typeof(sbyte)) result = (sbyte)dec;
				else if (dstType == typeof(short)) result = (short)dec;
				else if (dstType == typeof(ushort)) result = (ushort)dec;
				else if (dstType == typeof(int)) result = (int)dec;
				else if (dstType == typeof(uint)) result = (uint)dec;
				else if (dstType == typeof(long)) result = (long)dec;
				else if (dstType == typeof(ulong)) result = (ulong)dec;
				else if (dstType == typeof(float)) result = (float)dec;
				else if (dstType == typeof(double)) result = (double)dec;
				else if (dstType == typeof(decimal)) result = (decimal)dec;
			}
			return result is not null;
		}

#nullable enable
		public static object? GetMinValue(Type type)
		{
			if (type is null) return null;
			else if (type == typeof(byte)) return byte.MinValue;
			else if (type == typeof(sbyte)) return sbyte.MinValue;
			else if (type == typeof(short)) return short.MinValue;
			else if (type == typeof(ushort)) return ushort.MinValue;
			else if (type == typeof(int)) return int.MinValue;
			else if (type == typeof(uint)) return uint.MinValue;
			else if (type == typeof(long)) return long.MinValue;
			else if (type == typeof(ulong)) return ulong.MinValue;
			else if (type == typeof(float)) return float.MinValue;
			else if (type == typeof(double)) return double.MinValue;
			else if (type == typeof(decimal)) return decimal.MinValue;
			else return null;
		}

		public static object? GetMaxValue(Type type)
		{
			if (type is null) return null;
			else if (type == typeof(byte)) return byte.MaxValue;
			else if (type == typeof(sbyte)) return sbyte.MaxValue;
			else if (type == typeof(short)) return short.MaxValue;
			else if (type == typeof(ushort)) return ushort.MaxValue;
			else if (type == typeof(int)) return int.MaxValue;
			else if (type == typeof(uint)) return uint.MaxValue;
			else if (type == typeof(long)) return long.MaxValue;
			else if (type == typeof(ulong)) return ulong.MaxValue;
			else if (type == typeof(float)) return float.MaxValue;
			else if (type == typeof(double)) return double.MaxValue;
			else if (type == typeof(decimal)) return decimal.MaxValue;
			else return null;
		}

		static object? GetDefaultValue(Type type)
		{
			if (type is null) return null;
			else if (type == typeof(byte)) return default(byte);
			else if (type == typeof(sbyte)) return default(sbyte);
			else if (type == typeof(short)) return default(short);
			else if (type == typeof(ushort)) return default(ushort);
			else if (type == typeof(int)) return default(int);
			else if (type == typeof(uint)) return default(uint);
			else if (type == typeof(long)) return default(long);
			else if (type == typeof(ulong)) return default(ulong);
			else if (type == typeof(float)) return default(float);
			else if (type == typeof(double)) return default(double);
			else if (type == typeof(decimal)) return default(decimal);
			else return null;
		}
#nullable disable

		static string ConvertString(object src, string format)
		{
			if (src is null || format is null) return src?.ToString();
			try
			{
				if (src is byte b) return b.ToString(format);
				else if (src is sbyte sb) return sb.ToString(format);
				else if (src is short s) return s.ToString(format);
				else if (src is ushort us) return us.ToString(format);
				else if (src is int i) return i.ToString(format);
				else if (src is uint ui) return ui.ToString(format);
				else if (src is long l) return l.ToString(format);
				else if (src is ulong ul) return ul.ToString(format);
				else if (src is float f) return f.ToString(format);
				else if (src is double d) return d.ToString(format);
				else if (src is decimal dec) return dec.ToString(format);
				else return src.ToString();
			}
			catch (FormatException) { return src.ToString(); }
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Type Type
		{
			get => type;
			set
			{
				if (type == value || !AllowTypes.Contains(value)) return;
				type = value;
				valueMin = TryConvert(valueMin, type, out object min) ? min : GetMinValue(type);
				valueMax = TryConvert(valueMax, type, out object max) ? max : GetMaxValue(type);
				defaultValue = TryConvert(defaultValue, type, out object def) ? def : GetDefaultValue(type);
				this.value = TryConvert(value, type, out object val) ? val : null;
			}
		}

		[Browsable(true)]
		[Category("Extend")]
		[Description("表示する数値型名")]
		[DefaultValue(nameof(System.Int32))]
		public virtual string TypeName
		{
			get => type.Name;
			set => Type = AllowTypes.Where(x => x.Name == value).FirstOrDefault() ?? Type;
		}

		/// <summary>
		/// このテキストボックスが許容する最小値
		/// </summary>
		[Browsable(true)]
		[Category("Extend")]
		[Description("このテキストボックスが許容する最小値")]
		[DefaultValue(int.MinValue)]
		[TypeConverter(typeof(ObjectConverter))]
		public object ValueMin
		{
			get => valueMin;
			set => valueMin = TryConvert(value, Type, out object min) ? min : value is string s && s == "Min" && GetMinValue(Type) is object obj ? obj : valueMin;
		}

		/// <summary>
		/// このテキストボックスが許容する最大値
		/// </summary>
		[Browsable(true)]
		[Category("Extend")]
		[Description("このテキストボックスが許容する最大値")]
		[DefaultValue(int.MaxValue)]
		[TypeConverter(typeof(ObjectConverter))]
		public object ValueMax
		{
			get => valueMax;
			set => valueMax = TryConvert(value, Type, out object max) ? max : value is string s && s == "Max" && GetMaxValue(Type) is object obj ? obj : valueMax;
		}

		[Browsable(true)]
		[Category("Extend")]
		[Description("エラー時に使用される値")]
		[DefaultValue(0)]
		[TypeConverter(typeof(ObjectConverter))]
		public object DefaultValue
		{
			get => defaultValue;
			set => defaultValue = TryConvert(value, Type, out object val) ? val : defaultValue;
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override string Text { get => base.Text; set => base.Text = value; }

		/// <summary>
		/// このテキストボックスの値
		/// </summary>
		[Browsable(true)]
		[Category("Extend")]
		[Description("このテキストボックスの値")]
		[DefaultValue(null)]
		[TypeConverter(typeof(ObjectConverter))]
		public object Value
		{
			get => value ?? DefaultValue;
			set
			{
				this.value = value is null || !TryConvert(value, Type, out object val) ? null : val;
				this.value = ClampValue(out _);
				Text = ConvertString(this.value, ViewFormat);
			}
		}

		[Browsable(true)]
		[Category("Extend")]
		[Description("このテキストボックスの表示フォーマット")]
		[DefaultValue(null)]
		public string ViewFormat
		{
			get => viewFormat;
			set
			{
				viewFormat = value == string.Empty ? null : value;
				Text = ConvertString(this.value, ViewFormat);
			}
		}

		/// <summary>
		/// デフォルトのTextChangedイベントを使用するか
		/// </summary>
		[Browsable(true)]
		[Category("Extend")]
		[Description("デフォルトのTextChangedイベントを使用するか")]
		[DefaultValue(true)]
		public bool EnableTextChanged { get; set; } = true;

		/// <summary>
		/// デフォルトのLeaveイベントを使用するか
		/// </summary>
		[Browsable(true)]
		[Category("Extend")]
		[Description("デフォルトのLeaveイベントを使用するか")]
		[DefaultValue(true)]
		public bool EnableLeave { get; set; } = true;

		/// <summary>
		/// デフォルトのKeyPressイベントを使用するか
		/// </summary>
		[Browsable(true)]
		[Category("Extend")]
		[Description("デフォルトのKeyPressイベントを使用するか")]
		[DefaultValue(true)]
		public bool EnableKeyPress { get; set; } = true;

		/// <summary>
		/// このテキストボックスに入力されている数値を型Tで取得する
		/// </summary>
		/// <typeparam name="T">取得する数値型</typeparam>
		/// <param name="defaultValue">取得できなかった場合に返す値</param>
		/// <returns>T型に変換された数値。このNumberBoxに指定されている数値型以外を指定した場合、数値型間のキャストが可能ならば変換した値を返す</returns>
		public T GetValue<T>(T defaultValue) where T : struct => TryConvert(Value, typeof(T), out object result) ? (T)result : defaultValue;

		/// <summary>
		/// このテキストボックスに入力されている数値を[ValueMin, ValueMax]に収める
		/// </summary>
		/// <returns>テキストボックスに表示されている数値(何も表示されていない場合、DefaultValueプロパティの値)を[ValueMin, ValueMax]の範囲にクランプした結果</returns>
		public object ClampValue(out bool isClamped)
		{
			object val = null;
			isClamped = false;
			if (Type == typeof(byte))
			{
				val = ((byte)Value).ClampEx((byte)ValueMin, (byte)ValueMax);
				isClamped = (byte)val != (byte)Value;
			}
			else if (Type == typeof(sbyte))
			{
				val = ((sbyte)Value).ClampEx((sbyte)ValueMin, (sbyte)ValueMax);
				isClamped = (sbyte)val != (sbyte)Value;
			}
			else if (Type == typeof(short))
			{
				val = ((short)Value).ClampEx((short)ValueMin, (short)ValueMax);
				isClamped = (short)val != (short)Value;
			}
			else if (Type == typeof(ushort))
			{
				val = ((ushort)Value).ClampEx((ushort)ValueMin, (ushort)ValueMax);
				isClamped = (ushort)val != (ushort)Value;
			}
			else if (Type == typeof(int))
			{
				val = ((int)Value).ClampEx((int)ValueMin, (int)ValueMax);
				isClamped = (int)val != (int)Value;
			}
			else if (Type == typeof(uint))
			{
				val = ((uint)Value).ClampEx((uint)ValueMin, (uint)ValueMax);
				isClamped = (uint)val != (uint)Value;
			}
			else if (Type == typeof(long))
			{
				val = ((long)Value).ClampEx((long)ValueMin, (long)ValueMax);
				isClamped = (long)val != (long)Value;
			}
			else if (Type == typeof(ulong))
			{
				val = ((ulong)Value).ClampEx((ulong)ValueMin, (ulong)ValueMax);
				isClamped = (ulong)val != (ulong)Value;
			}
			else if (Type == typeof(float))
			{
				val = ((float)Value).ClampEx((float)ValueMin, (float)ValueMax);
				isClamped = (float)val != (float)Value;
			}
			else if (Type == typeof(double))
			{
				val = ((double)Value).ClampEx((double)ValueMin, (double)ValueMax);
				isClamped = (double)val != (double)Value;
			}
			else if (Type == typeof(decimal))
			{
				val = ((decimal)Value).ClampEx((decimal)ValueMin, (decimal)ValueMax);
				isClamped = (decimal)val != (decimal)Value;
			}
			return val;
		}

		/// <summary>
		/// このテキストボックスに入力されている数値を[ValueMin, ValueMax]に収めて型T?で取得する
		/// </summary>
		/// <typeparam name="T">取得する型</typeparam>
		/// <returns>テキストボックスに表示されている数値(何も表示されていない場合、DefaultValueプロパティの値)を[ValueMin, ValueMax]の範囲にクランプし、T型に変換した結果。数値型以外を指定した場合、nullを返す</returns>
		public T? ClampValue<T>(out bool isClamped) where T : struct => TryConvert(ClampValue(out isClamped), typeof(T), out object result) ? (T)result : null;

		object GetText()
		{
			if (Type == typeof(byte)) return Text.GetByteEx((byte)DefaultValue);
			else if (Type == typeof(sbyte)) return Text.GetSByteEx((sbyte)DefaultValue);
			else if (Type == typeof(short)) return Text.GetShortEx((short)DefaultValue);
			else if (Type == typeof(ushort)) return Text.GetUShortEx((ushort)DefaultValue);
			else if (Type == typeof(int)) return Text.GetIntEx((int)DefaultValue);
			else if (Type == typeof(uint)) return Text.GetUIntEx((uint)DefaultValue);
			else if (Type == typeof(long)) return Text.GetLongEx((long)DefaultValue);
			else if (Type == typeof(ulong)) return Text.GetULongEx((ulong)DefaultValue);
			else if (Type == typeof(float)) return Text.GetFloatEx((float)DefaultValue);
			else if (Type == typeof(double)) return Text.GetDoubleEx((double)DefaultValue);
			else if (Type == typeof(decimal)) return Text.GetDecimalEx((decimal)DefaultValue);
			else return DefaultValue;
		}

		protected override void OnTextChanged(EventArgs e)
		{
			if (EnableTextChanged)
			{
				if (Text == this.value?.ToString()) return;
				if (Text == "-" && SignedAllowTypes.Contains(Type)) return;
				if (string.IsNullOrEmpty(Text)) Value = null;
				else Value = GetText();
			}
			base.OnTextChanged(e);
		}

		protected override void OnLeave(EventArgs e)
		{
			if (EnableLeave)
			{
				if (Text == this.value?.ToString()) return;
				if (string.IsNullOrEmpty(Text)) Value = null;
				else Value = GetText();
			}
			base.OnLeave(e);
		}

		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			if (EnableKeyPress)
			{
				if (e.KeyChar == (char)Keys.Enter)
				{
					e.Handled = true;
					Form form = FindForm();
					if (form is not null)
					{
						bool result = form.SelectNextControl(this, true, true, true, true);
						if (!result) form.ActiveControl = null;
					}
				}
			}
			base.OnKeyPress(e);
		}
	}

	public class ObjectConverter : ExpandableObjectConverter
	{
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType == typeof(object)) return true;
			return base.CanConvertTo(context, destinationType);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == typeof(string) && value is not null) return value.ToString();
			else if (destinationType == typeof(int) && value is not null) return value.ToString().GetIntEx(0);
			return base.ConvertTo(context, culture, value, destinationType);
		}

		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			if (sourceType == typeof(string) || sourceType == typeof(int)) return true;
			return base.CanConvertFrom(context, sourceType);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value is string s)
			{
				if (ulong.TryParse(s, NumberStyles.Integer, null, out ulong ul)) return ul;
				else if (long.TryParse(s, NumberStyles.Integer, null, out long l)) return l;
				else if (double.TryParse(s, NumberStyles.Float, null, out double d)) return d;
				else if (decimal.TryParse(s, NumberStyles.Float, null, out decimal dec)) return dec;
				else return s;
			}
			else if (value is int i) return i;
			return base.ConvertFrom(context, culture, value);
		}
	}
}
