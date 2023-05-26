using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using TWE_Launcher.Models;

namespace TWE_Launcher
{
	public class Settings
	{
		public static List<GameSetupInfo> GameInstallations { get; }
		public static List<GameModificationInfo> TotalModificationsList { get; }
		public static CustomModsCollection FavoriteModsCollection { get; set; }
		public static List<CustomModsCollection> UserCollections { get; set; }

		public static string CacheDirectoryPath { get; }

		private static readonly string gameSetupConfFile;

		static Settings()
		{
			GameInstallations = new List<GameSetupInfo>();
			TotalModificationsList = new List<GameModificationInfo>();
			FavoriteModsCollection = CustomModsCollection.CreateFavoriteCollection();
			UserCollections = new List<CustomModsCollection>();
			CacheDirectoryPath = GetCacheDirectory();
			gameSetupConfFile = GetSetupConfFileName();
		}

		private static string GetCacheDirectory()
		{
			string appHomeDirectory = Directory.GetCurrentDirectory();
			string cacheFolderName = "cache";

			return Path.Combine(appHomeDirectory, cacheFolderName);
		}

		private static string GetSetupConfFileName()
		{
			string cfgFileExtension = ".conf";
			string cfgFileBaseName = "setup";

			string cfgFilename = cfgFileBaseName + cfgFileExtension;
			string cfgFileLocation = Directory.GetCurrentDirectory();

			return Path.Combine(cfgFileLocation, cfgFilename);
		}

		public static GameSetupInfo RegistrateGameInstallation(string setupName, string executableFullPath, List<string> modcenterPaths)
		{
			WriteNewSetupToConfFile(gameSetupConfFile, setupName, executableFullPath, modcenterPaths);

			var gameSetupInfo = new GameSetupInfo(setupName, executableFullPath, modcenterPaths);
			GameInstallations.Add(gameSetupInfo);

			return gameSetupInfo;
		}

		private static void WriteNewSetupToConfFile(string setupConfFileName, string setupName, string executableFullPath, List<string> modcenterPaths)
		{
			var writer = new StreamWriter(setupConfFileName, true, Encoding.UTF8);

			string gameSetupElemName = "GameSetupInfo";
			string gameSetupNameAttrKey = "Name";
			string gameSetupNameAttrValue = setupName;
			string gameSetupNamePairAttribute = gameSetupNameAttrKey + "=\"" + gameSetupNameAttrValue + "\"";
			string gameSetupBegTag = "<" + gameSetupElemName + " " + gameSetupNamePairAttribute + ">";
			string gameSetupEndTag = "</" + gameSetupElemName + ">";

			string executableElemName = "Executable";
			string executableBegTag = "<" + executableElemName + ">";
			string executableEndTag = "</" + executableElemName + ">";
			string executableElemValue = executableFullPath;
			string executableElement = executableBegTag + executableElemValue + executableEndTag;

			string modcentersElemName = "AttachedModCenters";
			string modcentersBegTag = "<" + modcentersElemName + ">";
			string modcentersEndTag = "</" + modcentersElemName + ">";
			string modCenterElemName = "ModCenter";
			string modCenterBegTag = "<" + modCenterElemName + ">";
			string modCenterEndTag = "</" + modCenterElemName + ">";
			List<string> modCenterElements = new List<string>();
			foreach (string modcenter in modcenterPaths)
			{
				string modCenterElement = modCenterBegTag + modcenter + modCenterEndTag;
				modCenterElements.Add(modCenterElement);
			}

			writer.WriteLine(gameSetupBegTag);
			writer.WriteLine("   {0}", executableElement);
			writer.WriteLine("   {0}", modcentersBegTag);
			foreach (string modCenter in modCenterElements)
			{
				writer.WriteLine("      {0}", modCenter);
			}
			writer.WriteLine("   {0}", modcentersEndTag);
			writer.WriteLine(gameSetupEndTag);

			writer.Close();
		}

		public static void UpdateTotalModificationsList()
		{
			TotalModificationsList.Clear();

			foreach (var installation in GameInstallations)
			{
				List<GameModificationInfo> mods = installation.GetInstalledMods();
				TotalModificationsList.AddRange(mods);
			}
		}

		public static GameModificationInfo GetActiveModificationInfo(int mod_index)
		{
			return TotalModificationsList[mod_index];
		}

		public static GameModificationInfo GetActiveModificationInfo(string modShortName)
		{
			foreach (GameModificationInfo modInfo in TotalModificationsList)
			{
				if (modInfo.ShortName.Equals(modShortName))
				{
					return modInfo;
				}
			}

			return null;
		}


		public static void ClearAllSettings()
		{
			TotalModificationsList.Clear();
			GameInstallations.Clear();

			if (File.Exists(gameSetupConfFile))
			{
				File.Delete(gameSetupConfFile);
				CreateSetupConfFile(gameSetupConfFile);
			}
		}

		public static List<GameSetupInfo> SynchronizeGameSetupSettings()
		{
			if (ShouldGameSetupConfFileBeCreated(gameSetupConfFile))
			{
				CreateSetupConfFile(gameSetupConfFile);
				PrepareCacheFolder();
			}
			else
			{
				if (GameInstallations.Count == 0)
				{
					uint gameSetupObjectsCount = ReadTotalGameSetupCount(gameSetupConfFile);

					if (gameSetupObjectsCount > 0)
					{
						List<GameSetupInfo> gameSetupObjects = ReadAllSetupConfFile(gameSetupConfFile);
						GameInstallations.AddRange(gameSetupObjects);
					}
				}
			}

			return GameInstallations;
		}

		private static bool ShouldGameSetupConfFileBeCreated(string setupConfFileName)
		{
			if (File.Exists(setupConfFileName))
			{
				return false;
			}

			return true;
		}

		private static void CreateSetupConfFile(string setupConfFileName)
		{
			var stream = new FileStream(setupConfFileName, FileMode.CreateNew);
			var writer = new StreamWriter(stream, Encoding.UTF8);

			string rootElementName = "ApplicationVersion";
			string elemBegTag = "<" + rootElementName + ">";
			string elemEndTag = "</" + rootElementName + ">";

			writer.WriteLine($"{elemBegTag}{Application.ProductVersion}{elemEndTag}");

			writer.Close();
			stream.Close();
		}

		private static void PrepareCacheFolder()
		{
			if (!Directory.Exists(CacheDirectoryPath))
			{
				Directory.CreateDirectory(CacheDirectoryPath);
			}
		}

		private static uint ReadTotalGameSetupCount(string setupConfFileName)
		{
			string[] readDataStrings = File.ReadAllLines(setupConfFileName, Encoding.UTF8);

			uint totalGameSetupCount = 0;
			string gameSetupObjectMarker = "<GameSetupInfo";

			for (int i = 0; i < readDataStrings.Length; i++)
			{
				if (readDataStrings[i].StartsWith(gameSetupObjectMarker))
				{
					totalGameSetupCount++;
				}
			}

			return totalGameSetupCount;
		}

		private static List<GameSetupInfo> ReadAllSetupConfFile(string setupConfFileName)
		{
			var readGameSetupObjects = new List<GameSetupInfo>();

			string setupElemEntryBeg = "<GameSetupInfo Name=\"";
			string setupElemEntryEnd = "\">";

			string[] readDataStrings = File.ReadAllLines(setupConfFileName, Encoding.UTF8);

			// 1. Define GameSetupInfo objects coordinates into the config file via indexes.
			var gameSetupObjectsStartEntryIndexes = new List<int>();
			for (int index = 0; index < readDataStrings.Length; index++)
			{
				if (readDataStrings[index].StartsWith(setupElemEntryBeg))
				{
					gameSetupObjectsStartEntryIndexes.Add(index);
				}
			}

			// 2. Read GameSetupInfo objects from the config file by detected coordinates.
			for (int entryIndex = 0; entryIndex < gameSetupObjectsStartEntryIndexes.Count; entryIndex++)
			{
				int begEntryIndex = gameSetupObjectsStartEntryIndexes[entryIndex];

				int endEntryIndex;
				if (entryIndex == (gameSetupObjectsStartEntryIndexes.Count - 1))
				{
					// We don't know the end entry index of the last GameSetupInfo object.
					endEntryIndex = readDataStrings.Length - 1;
				}
				else
				{
					// We know the begin entry index of the next GameSetupInfo object.
					endEntryIndex = gameSetupObjectsStartEntryIndexes[entryIndex + 1];
				}

				// 3. Read the GameSetupInfo object.

				// 3.1. 'Name'
				string gameSetupName = readDataStrings[begEntryIndex];
				gameSetupName = gameSetupName.Replace(setupElemEntryBeg, string.Empty);
				gameSetupName = gameSetupName.Replace(setupElemEntryEnd, string.Empty);

				var executableFullPath = string.Empty;
				var attachedModCenters = new List<string>();

				for (int dataIndex = begEntryIndex; dataIndex < endEntryIndex; dataIndex++)
				{
					string data = readDataStrings[dataIndex].TrimStart();

					// 3.2. 'Executable'

					string executableElemEntryBeg = "<Executable>";
					string executableElemEntryEnd = "</Executable>";

					if (data.StartsWith(executableElemEntryBeg) && data.EndsWith(executableElemEntryEnd))
					{
						executableFullPath = data.Replace(executableElemEntryBeg, string.Empty);
						executableFullPath = executableFullPath.Replace(executableElemEntryEnd, string.Empty);
						continue;
					}

					// 3.3. 'AttachedModCenters'

					string modcenterElemEntryBeg = "<ModCenter>";
					string modcenterElemEntryEnd = "</ModCenter>";

					if (data.StartsWith(modcenterElemEntryBeg) && data.EndsWith(modcenterElemEntryEnd))
					{
						string modcenter = data.Replace(modcenterElemEntryBeg, string.Empty);
						modcenter = modcenter.Replace(modcenterElemEntryEnd, string.Empty);

						attachedModCenters.Add(modcenter);
					}
				}

				// 4. Generate a new GameSetupInfo object.
				var gameSetupInfo = new GameSetupInfo(gameSetupName, executableFullPath, attachedModCenters);
				readGameSetupObjects.Add(gameSetupInfo);
			}

			return readGameSetupObjects;
		}


		public static void DeleteGameSetupByIndex(int gameSetupIndex)
		{
			GameSetupInfo gameSetupInfo = GameInstallations[gameSetupIndex];
			DeleteGameSetupFromConfFile(gameSetupInfo);
			GameInstallations.RemoveAt(gameSetupIndex);
		}

		private static void DeleteGameSetupFromConfFile(GameSetupInfo gameSetupInfo)
		{
			// 1. Read all GameSetupInfo objects as an array of strings.
			string[] allReadData = File.ReadAllLines(gameSetupConfFile, Encoding.UTF8);


			// 2. Find the begin of the target GameSetupInfo object.

			int gameSetupObjectBegIndex = 0;
			string gameSetupElemBeg = "<GameSetupInfo Name=\"";
			string gameSetupElemEnd = "\">";
			string gameSetupOpeningTag = gameSetupElemBeg + gameSetupInfo.Name + gameSetupElemEnd;

			for (int i = 0; i < allReadData.Length; i++)
			{
				if (allReadData[i].StartsWith(gameSetupOpeningTag))
				{
					gameSetupObjectBegIndex = i;
					break;
				}
			}


			// 3. Find the end of the target GameSetupInfo object.

			int gameSetupObjectEndIndex = gameSetupObjectBegIndex;
			string gameSetupClosingTag = "</GameSetupInfo>";

			for (int j = gameSetupObjectBegIndex; j < allReadData.Length; j++)
			{
				if (allReadData[j].StartsWith(gameSetupClosingTag))
				{
					gameSetupObjectEndIndex = j;
					break;
				}
			}

			// 4. Update data about GameSetupInfo objects via deleting target GameSetupInfo object's data.

			var updatedDataStrings = new List<string>();

			for (int index = 0; index < allReadData.Length; index++)
			{
				bool moreOrEqualBegIndex = (index >= gameSetupObjectBegIndex);
				bool lessOrEqualEndIndex = (index <= gameSetupObjectEndIndex);

				if (moreOrEqualBegIndex && lessOrEqualEndIndex)
				{
					continue;
				}

				updatedDataStrings.Add(allReadData[index]);
			}


			// 5. Rewrite updated data to the configuration file.

			var writer = new StreamWriter(gameSetupConfFile, false, Encoding.UTF8);

			foreach (var dataString in updatedDataStrings)
			{
				writer.WriteLine(dataString);
			}

			writer.Close();
		}
	}
}
