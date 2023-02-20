using System.IO;
using System.Collections.Generic;

namespace TWE_Launcher.Models
{
	public class ModCenterInfo
	{
		private readonly GameSetupInfo parentGameSetup;
		public string Location { get; }
		public string Name { get; }
		public string CacheDirectory { get; }
		public List<GameModificationInfo> InstalledModifications { get; }

		public ModCenterInfo(string modcenterDirectory, GameSetupInfo gameSetupInfo)
		{
			parentGameSetup = gameSetupInfo;
			var modcenterDirectoryInfo = new DirectoryInfo(modcenterDirectory);
			Location = modcenterDirectoryInfo.FullName;
			Name = modcenterDirectoryInfo.Name;
			CacheDirectory = InitializeCacheDirectory(parentGameSetup.CacheDirectory, Name);
			InstalledModifications = new List<GameModificationInfo>();
		}

		private string InitializeCacheDirectory(string cacheGameSetupDirectoryPath, string cacheModCenterFolderName)
		{
			string cacheDirectoryPath = Path.Combine(cacheGameSetupDirectoryPath, cacheModCenterFolderName);

			if (!Directory.Exists(cacheDirectoryPath))
			{
				Directory.CreateDirectory(cacheDirectoryPath);
			}

			return cacheDirectoryPath;
		}

		public List<GameModificationInfo> FindAllModifications()
		{
			string[] modFolders = Directory.GetDirectories(Location);
			InstalledModifications.Clear();

			foreach (string modFolder in modFolders)
			{
				if (IsModification(modFolder))
				{
					var mod = new GameModificationInfo(modFolder, this, parentGameSetup);
					InstalledModifications.Add(mod);
				}
			}

			return InstalledModifications;
		}

		private bool IsModification(string modFolder)
		{
			const string modConfigExtension = ".cfg";
			string[] modBaseFiles = Directory.GetFiles(modFolder);

			foreach (var baseFile in modBaseFiles)
			{
				if (baseFile.EndsWith(modConfigExtension))
				{
					return true;
				}
			}

			return false;
		}
	}
}
