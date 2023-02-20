using System.IO;

namespace TWE_Launcher.Models
{
	public class GameModificationInfo
	{
		public string Location { get; }
		public GameSetupInfo CurrentSetup { get; }
		public string ShortName { get; }
		public string CacheDirectory { get; }
		public string ModArgRelativePath { get; }
		public string ModCfgRelativePath { get; }
		public string LogFileName { get; }
		public string LogFileRelativePath { get; }
		public string LogotypeImage { get; }

		// example: modificationURI = "A:\TWEMP\modcenter_M2TW\MEDD"
		public GameModificationInfo(string modificationURI, ModCenterInfo parentModCenter, GameSetupInfo setupInfo)
		{
			Location = modificationURI;
			CurrentSetup = setupInfo;

			ShortName = (new DirectoryInfo(modificationURI)).Name;
			CacheDirectory = InitializeCacheDirectory(parentModCenter.CacheDirectory, ShortName);

			ModArgRelativePath = InitializeModArgRelativePath(ShortName, parentModCenter.Name);
			ModCfgRelativePath = InitializeModCfgRelativePath(ShortName, parentModCenter.Name);

			LogFileName = InitializeLogFileName();
			LogFileRelativePath = InitializeLogFileRelativePath(ModCfgRelativePath, LogFileName);

			LogotypeImage = InitializeCachedLogotypeImage(Location);
		}

		private string InitializeCacheDirectory(string cacheModCenterDirectoryPath, string cacheModFolderName)
		{
			string cacheDirectoryPath = Path.Combine(cacheModCenterDirectoryPath, cacheModFolderName);

			if (!Directory.Exists(cacheDirectoryPath))
			{
				Directory.CreateDirectory(cacheDirectoryPath);
			}

			return cacheDirectoryPath;
		}

		private string InitializeModArgRelativePath(string modFolderName, string modcenterFolderName)
		{
			const string argumentLabel = "@";
			const string separatorSlash = "\\";

			return argumentLabel + modcenterFolderName + separatorSlash + modFolderName + separatorSlash; // example: "@mods\MEDD\"
		}

		private string InitializeModCfgRelativePath(string modFolderName, string modcenterFolderName)
		{
			const string separatorSlash = "/";
			return modcenterFolderName + separatorSlash + modFolderName; // example: "mod = mods/MEDD"
		}

		private string InitializeLogFileRelativePath(string modRelativePath, string modLogFileName)
		{
			return Path.Combine(modRelativePath, modLogFileName); // example: "to = mods/MEDD/system.log.txt"
		}

		private string InitializeLogFileName()
		{
			string fileBaseName = "twe-mod-log";
			string fileExtension = ".txt";

			return fileBaseName + fileExtension;
		}

		private string InitializeCachedLogotypeImage(string modificationURI)
		{
			string cachedLogotypeImageExtension = ".png";
			string cachedLogotypeImageFileName = ShortName + cachedLogotypeImageExtension;
			string cachedLogotypeImagePath = Path.Combine(CacheDirectory, cachedLogotypeImageFileName);

			if (ContainsLogotypeImage(CacheDirectory, cachedLogotypeImageFileName))
			{
				return cachedLogotypeImagePath;
			}


			string sourceLogotypeImageDirectoryPath = $"{modificationURI}\\data\\menu\\";
			string sourceLogotypeImageFileName = "splash.tga";

			if (ContainsLogotypeImage(sourceLogotypeImageDirectoryPath, sourceLogotypeImageFileName))
			{
				string sourceLogotypeImagePath = Path.Combine(sourceLogotypeImageDirectoryPath, sourceLogotypeImageFileName);

				if (!ContainsLogotypeImage(CacheDirectory, cachedLogotypeImageFileName))
				{
					ImageConverter.ConvertTgaToPng(sourceLogotypeImagePath, cachedLogotypeImagePath);
				}
			}

			return cachedLogotypeImagePath;
		}

		private bool ContainsLogotypeImage(string imageDirectoryPath, string imageFileName)
		{
			string[] files = Directory.GetFiles(imageDirectoryPath);

			foreach (var file in files)
			{
				string fileBaseName = (new FileInfo(file)).Name;

				if (fileBaseName.Equals(imageFileName))
				{
					return true;
				}
			}

			return false;
		}
	}
}
