using Pfim;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace TWE.ModsDetector
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string modcenter_configuration_filename = "modcenter.cfg";

			List<string> modcenter_paths = ReadPathsFromConfigurationFile(modcenter_configuration_filename);
			List<string> mod_folders = GetModsFolders(modcenter_paths);
			PrintModFolders(mod_folders);
			PrintModsCounts(mod_folders);
			Console.WriteLine();
			
			//

			Console.WriteLine();
		}


		private static List<string> ReadPathsFromConfigurationFile(string filename)
		{
			var modcenter_paths = new List<string>();

			if (File.Exists(filename))
			{
				string[] paths = File.ReadAllLines(filename);

				foreach (var path in paths)
				{
					modcenter_paths.Add(path);
				}
			}

			return modcenter_paths;
		}

		private static bool IsModFolder(string folder)
		{
			string[] files_in_folder = Directory.GetFiles(folder);

			string mod_bat_extension = ".bat";
			string mod_cfg_extension = ".cfg";

			bool folder_has_bat_file = false;
			bool folder_has_cfg_file = false;

			foreach (var file in files_in_folder)
			{
				if (file.EndsWith(mod_bat_extension))
				{
					folder_has_bat_file = true;
				}

				if (file.EndsWith(mod_cfg_extension))
				{
					folder_has_cfg_file = true;
				}
			}

			return (folder_has_bat_file && folder_has_cfg_file);
		}

		private static List<string> GetModsFolders(List<string> modcenter_paths)
		{
			var mods_folders = new List<string>();

			foreach (var modcenter_path in modcenter_paths)
			{
				string[] folders = Directory.GetDirectories(modcenter_path);

				foreach (var folder in folders)
				{
					if (IsModFolder(folder))
					{
						mods_folders.Add(folder);
					}
				}

			}

			return mods_folders;
		}

		private static void PrintModFolders(List<string> mod_folders)
		{
			foreach (var mod_folder in mod_folders)
			{
				Console.WriteLine(mod_folder);
			}
		}

		private static void PrintModsCounts(List<string> mod_folders)
		{
			Console.WriteLine("[RESULT] Detected " + mod_folders.Count + " mods.");
		}

		private static void DeleteAllModSupportPresets(List<string> mod_folders)
		{
			foreach (var folder in mod_folders)
			{
				string[] subFolders = Directory.GetDirectories(folder);

				foreach (var subFolder in subFolders)
				{
					if ((new DirectoryInfo(subFolder)).Name.Equals(".twemp"))
					{
						Directory.Delete(subFolder, true);
						Console.WriteLine("DELETED: {0}", subFolder);
					}
				}
			}
		}

		private static List<string> GetModLogoFiles(List<string> mod_folders)
		{
			var logo_files = new List<string>();

			string logo_subfolder = "\\data\\menu\\";
			string logo_filename = "splash.tga";

			for (int i = 0; i < mod_folders.Count; i++)
			{
				string mod_logo = mod_folders[i] + logo_subfolder + logo_filename;

				if (File.Exists(mod_logo))
				{
					logo_files.Add(mod_logo);
				}
			}

			return logo_files;
		}

		private static List<string> CopyLogoFiles(List<string> logo_files)
		{
			List<string> copiedFiles = new List<string>();
			Console.WriteLine("--- COPYING LOGOTYPES ---");

			for (int i = 0; i < logo_files.Count; i++)
			{
				string filename = Directory.GetCurrentDirectory() + "\\image_" + i + ".tga";

				if (File.Exists(filename))
				{
					Console.WriteLine("COPYING: File already exists. Copying was declined.");
				}
				else
				{
					File.Copy(logo_files[i], filename);
					Console.WriteLine("COPYING: " + filename);
					copiedFiles.Add(filename);
				}
			}

			Console.WriteLine();
			return copiedFiles;
		}


		private static void PrintModLogoFiles(List<string> files)
		{
			Console.WriteLine("----- MOD LOGO FILES -----");

			for (int i = 0; i < files.Count; i++)
			{
				Console.WriteLine("[" + i + "] " + files[i]);
			}

			Console.WriteLine("\n[RESULT] Detected " + files.Count + " logotypes.\n");
		}

		private static void PrintLogotypesInfo(List<string> logo_files)
		{
			foreach (var logo_file in logo_files)
			{
				Console.Write("[IMAGE]: " + logo_file + "(" + (new FileInfo(logo_file)).Length + ")" + " | ");

				var image = Pfimage.FromFile(logo_file);
				Console.WriteLine("Format: " + image.Format.ToString());
			}
		}
	}
}
