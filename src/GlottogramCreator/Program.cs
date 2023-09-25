using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Drawing;
using System.Runtime;

namespace WinFormsApp1
{
	static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			try
			{
				Application.SetHighDpiMode(HighDpiMode.SystemAware);
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new Form1());
			}
			catch (Exception ex)
			{
				MessageForm.Show("以下の例外により、プログラムを終了します。\n" + ex.Message + "\n場所：" + (ex.StackTrace ?? string.Empty), "例外エラー");
			}

			try
			{
				const int limit = 5;
				XDocument xDocument = XDocumentExtend.CreateEx("root");
				XElement root = xDocument.Root;
				root.Add(GlottogramData.Output());
				root.Add(GlottogramProperty.Output());
				root.Add(HeaderProperty.Output());
				root.Add(LegendProperty.Output());
				root.Add(SymbolData.Output());
				root.Add(MainData.Output());
				string folder = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Recovery");
				if (!System.IO.Directory.Exists(folder)) System.IO.Directory.CreateDirectory(folder);
				string path = System.IO.Path.Combine(folder, "RecoveryData_");
				string[] files = System.IO.Directory.GetFiles(folder);
				if (files.Contains(path + limit.ToString() + ".gce"))
				{
					for (int i = 2; i <= limit; ++i)
					{
						string file = path + i.ToString() + ".gce";
						if (files.Contains(file))
						{
							System.IO.File.Copy(
								System.IO.Path.Combine(folder, file),
								System.IO.Path.Combine(folder, path + (i - 1).ToString() + ".gce"),
								true
								);
						}
					}
					xDocument.SaveEx(System.IO.Path.Combine(folder, path + limit.ToString() + ".gce"));
				}
				else
				{
					for (int i = 1; i <= limit; ++i)
					{
						string file = path + i.ToString() + ".gce";
						if (files.Contains(file)) continue;
						xDocument.SaveEx(System.IO.Path.Combine(folder, file));
						break;
					}
				}
			}
			catch { }
		}
	}
}
