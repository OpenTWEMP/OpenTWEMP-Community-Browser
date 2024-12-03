using System;
using System.IO;

namespace TWE_GameSetup_Testing
{
	internal class Program
	{
		static void Main(string[] args)
		{
			TestExecutable();
		}

		static void TestExecutable()
		{
			string executable = "A:\\TWEMP\\kingdoms.exe";
			PrintExecutableInfo(executable);
		}

		private static void PrintExecutableInfo(string executable)
		{
			Console.WriteLine("GetFullPath: {0}", Path.GetFullPath(executable));
			Console.WriteLine("GetFileName: {0}", Path.GetFileName(executable));
			Console.WriteLine("GetFileNameWithoutExtension: {0}", Path.GetFileNameWithoutExtension(executable));
			Console.WriteLine("GetPathRoot: {0}", Path.GetPathRoot(executable));
			Console.WriteLine("GetExtension: {0}", Path.GetExtension(executable));
			Console.WriteLine("GetDirectoryName: {0}", Path.GetDirectoryName(executable));
		}

		static void TestModcenter()
		{
			string modcenter_path = "A:\\TWEMP\\mods\\";
			PrintModcenterInfo(modcenter_path);
		}

		private static void PrintModcenterInfo(string modcenter_path)
		{
			Console.WriteLine("modcenter_path: \"{0}\"", modcenter_path);
			DirectoryInfo directoryInfo = new DirectoryInfo(modcenter_path);

			Console.WriteLine("directoryInfo.FullName: {0}", directoryInfo.FullName);
			Console.WriteLine("directoryInfo.Name: {0}", directoryInfo.Name);
			Console.WriteLine("directoryInfo.Parent: {0}", directoryInfo.Parent);
			Console.WriteLine("directoryInfo.Root: {0}", directoryInfo.Root);
		}

		private static void PrintLauncherPathsForModcenter()
		{
			string modcenterPath = "A:\\TWEMP\\modcenter_M2TW\\";
			string[] modsFolders = Directory.GetDirectories(modcenterPath);

			foreach (var folder in modsFolders)
			{
				string[] files = Directory.GetFiles(folder);

				foreach (var file in files)
				{
					if (file.EndsWith(".exe"))
					{
						Console.WriteLine("'{0}': '{1}'", folder, file);
					}
				}
			}
		}
	}
}
