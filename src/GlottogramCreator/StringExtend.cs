using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WinFormsApp1
{
	public static class StringExtend
	{
		public static bool GetBoolEx(this string s, bool defaultValue = default) => bool.TryParse(s, out bool ret) ? ret : defaultValue;
		public static byte GetByteEx(this string s, byte defaultValue = default) => byte.TryParse(s, out byte ret) ? ret : defaultValue;
		public static sbyte GetSByteEx(this string s, sbyte defaultValue = default) => sbyte.TryParse(s, out sbyte ret) ? ret : defaultValue;
		public static ushort GetUShortEx(this string s, ushort defaultValue = default) => ushort.TryParse(s, out ushort ret) ? ret : defaultValue;
		public static short GetShortEx(this string s, short defaultValue = default) => short.TryParse(s, out short ret) ? ret : defaultValue;
		public static uint GetUIntEx(this string s, uint defaultValue = default) => uint.TryParse(s, out uint ret) ? ret : defaultValue;
		public static int GetIntEx(this string s, int defaultValue = default) => int.TryParse(s, out int ret) ? ret : defaultValue;
		public static long GetLongEx(this string s, long defaultValue = default) => long.TryParse(s, out long ret) ? ret : defaultValue;
		public static ulong GetULongEx(this string s, ulong defaultValue = default) => ulong.TryParse(s, out ulong ret) ? ret : defaultValue;
		public static float GetFloatEx(this string s, float defaultValue = default) => float.TryParse(s, System.Globalization.NumberStyles.Float, null, out float ret) ? ret : defaultValue;
		public static double GetDoubleEx(this string s, double defaultValue = default) => double.TryParse(s, System.Globalization.NumberStyles.Float, null, out double ret) ? ret : defaultValue;
		public static decimal GetDecimalEx(this string s, decimal defaultValue = default) => decimal.TryParse(s, System.Globalization.NumberStyles.Float, null, out decimal ret) ? ret : defaultValue;
	}
}
