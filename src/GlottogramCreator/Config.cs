using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Xml.Linq;
using System.Windows.Forms;

namespace WinFormsApp1
{
	internal static class Config
	{
		public static Font MainFont { get; } = new Font("Yu Gothic UI", 12);

		static Config()
		{
			if (XDocumentExtend.LoadEx(@"Setting\Config.xml")?.Root is XElement root)
			{
				foreach (XElement element in root.Elements().Where(x => x.Name == "property"))
				{
					if (element.GetAttributeValueEx("name") is not string propertyName) continue;
					if (propertyName == nameof(MainFont)) MainFont = element.GetFontEx(MainFont);
				}
			}
		}

		public static void SetMainFont(Form form) => SetFont(MainFont.FontFamily, MainFont.Size, MainFont.Style, MainFont.Unit, form);

		public static void SetFont(FontFamily fontFamily, float emSize, FontStyle style, GraphicsUnit unit, Form form)
		{
			Font font = new(fontFamily ?? MainFont.FontFamily, emSize, style, unit);
			bool autoSize = form.AutoSize;
			form.AutoSize = true;
			AutoSizeMode autoSizeMode = form.AutoSizeMode;
			form.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			form.Font = font;
			form.AutoSizeMode = autoSizeMode;
			form.AutoSize = autoSize;
			return;
		}
	}
}
