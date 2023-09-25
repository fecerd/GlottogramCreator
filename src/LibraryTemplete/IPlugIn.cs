using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.IO;

namespace PlugIns
{
	public interface IPlugIn
	{
		public abstract Func<List<Dictionary<string, string>>, List<string>, string, bool> GetFunction();

		public abstract string Text { get; }

		static string ToAbsolutePath(string path)
		{
			try
			{
				int length = path.Length;
				if ((length >= 2 && (path[0] == Path.DirectorySeparatorChar || path[0] == Path.AltDirectorySeparatorChar) && (path[1] == Path.DirectorySeparatorChar || path[1] == Path.AltDirectorySeparatorChar)) || (length >= 3 && path[1] == Path.VolumeSeparatorChar && (path[2] == Path.DirectorySeparatorChar || path[2] == Path.AltDirectorySeparatorChar)))
				{
					return path;
				}
				return Path.GetFullPath(path, Directory.GetCurrentDirectory());
			}
			catch { return string.Empty; }
		}

		public static IPlugIn? GetInstance(string libraryPath)
		{
			IPlugIn? ret = null!;
			Assembly assembly;
			try
			{
				assembly = Assembly.LoadFile(ToAbsolutePath(libraryPath));
				string plugin = typeof(IPlugIn).FullName!;
				if (plugin is null) return ret;
				if (assembly.GetTypes().Where(x => x.GetInterface(plugin) is not null).FirstOrDefault() is not Type type) return ret;
				if (type.FullName is string fullName) ret = assembly.CreateInstance(fullName) as IPlugIn;
			}
			catch { }
			return ret;
		}

		public static IEnumerable<IPlugIn> GetInstances(string libraryPath)
		{
			string plugin = typeof(IPlugIn).FullName!;
			if (plugin is null) yield break;
			Assembly assembly = null!;
			try
			{
				assembly = Assembly.LoadFile(ToAbsolutePath(libraryPath));
			}
			catch { yield break; }
			if (assembly is null) yield break;
			foreach (Type type in assembly.GetTypes().Where(x => x.GetInterface(plugin) is not null))
			{
				if (type.FullName is string fullName && assembly.CreateInstance(fullName) is IPlugIn ret) yield return ret;
			}
		}
	}
}
