using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WinFormsApp1
{
	static class ValueExtend
	{
		public static int RoundUpEx(this float v) => (int)MathF.Round(v, MidpointRounding.AwayFromZero);
		public static int RoundDownEx(this float v) => (int)MathF.Round(v, MidpointRounding.ToZero);
		public static PointF GetPointEx(this RectangleF value, StringAlignment alignment, StringAlignment lineAlignment)
		{
			return value.Location with
			{
				X = value.X + (alignment == StringAlignment.Center ? value.Width / 2 : alignment == StringAlignment.Far ? value.Width : 0),
				Y = value.Y + (lineAlignment == StringAlignment.Center ? value.Height / 2 : lineAlignment == StringAlignment.Far ? value.Height : 0)
			};
		}
		public static byte ClampEx(this byte value, byte min, byte max) => value < min ? min : value > max ? max : value;
		public static sbyte ClampEx(this sbyte value, sbyte min, sbyte max) => value < min ? min : value > max ? max : value;
		public static short ClampEx(this short value, short min, short max) => value < min ? min : value > max ? max : value;
		public static ushort ClampEx(this ushort value, ushort min, ushort max) => value < min ? min : value > max ? max : value;
		public static int ClampEx(this int value, int min, int max) => value < min ? min : value > max ? max : value;
		public static uint ClampEx(this uint value, uint min, uint max) => value < min ? min : value > max ? max : value;
		public static long ClampEx(this long value, long min, long max) => value < min ? min : value > max ? max : value;
		public static ulong ClampEx(this ulong value, ulong min, ulong max) => value < min ? min : value > max ? max : value;
		public static float ClampEx(this float value, float min, float max) => value < min ? min : value > max ? max : value;
		public static double ClampEx(this double value, double min, double max) => value < min ? min : value > max ? max : value;
		public static decimal ClampEx(this decimal value, decimal min, decimal max) => value < min ? min : value > max ? max : value;
		public static bool IsInteger(this float value, float d, out int i)
		{
			if (MathF.Abs(value - value.RoundUpEx()) < d)
			{
				i = value.RoundUpEx();
				return true;
			}
			else if (MathF.Abs(value - value.RoundDownEx()) < d)
			{
				i = value.RoundDownEx();
				return true;
			}
			else
			{
				i = 0;
				return false;
			}
		}
		public static bool IsRangeClosed(this int value, int min, int max) => min <= value && value <= max;
	}
}
