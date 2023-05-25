using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TWE_Launcher.Forms;

using TWE_Launcher.Models.GamesSupport;


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
		private string modLogotypeImage { get; }

		public CustomModSupportPreset CurrentPreset { get; }


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

			modLogotypeImage = InitializeCachedLogotypeImage(Location);


			// Read the existing preset else create the preset by default.


			string presetHomeDirectoryPath = CustomModSupportPreset.GetPresetDirectoryPath(modificationURI);

			if (!Directory.Exists(presetHomeDirectoryPath))
			{
				Directory.CreateDirectory(presetHomeDirectoryPath);
			}

			string presetFilePath = CustomModSupportPreset.GetPresetFilePath(modificationURI);

			if (CustomModSupportPreset.Exists(modificationURI))
			{
				CurrentPreset = CustomModSupportPreset.ReadExistingPreset(modificationURI);
			}
			else
			{
				CurrentPreset = new CustomModSupportPreset();
				CurrentPreset.CreatePresetByDefault(modificationURI);
			}
		}


		public void ShowModVisitingCard(PictureBox modLogotypePictureBox, Label modStatusLabel)
		{
			const string modLogoErrorMsg = "Mod Caching Error: Logotype image was not found.";

			if (modLogotypePictureBox.Image != null)
			{
				modLogotypePictureBox.Image.Dispose();
				modLogotypePictureBox.Image = null;
			}

			if (File.Exists(modLogotypeImage))
			{
				modLogotypePictureBox.Load(modLogotypeImage);
				modLogotypePictureBox.Visible = true;
				modStatusLabel.Text = Location;
			}
			else
			{
				modLogotypePictureBox.Visible = true;
				modLogotypePictureBox.BackColor = Color.Silver;
				modStatusLabel.Text = modLogoErrorMsg;
			}
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
			string destLogoImageExtension = ".png";
			string cachedLogotypeImageFileName = ShortName + destLogoImageExtension;
			string cachedLogotypeImagePath = Path.Combine(CacheDirectory, cachedLogotypeImageFileName);

			// 1. Find mod's logotype image in app's cache directory.

			if (ContainsLogotypeImage(CacheDirectory, cachedLogotypeImageFileName))
			{
				return cachedLogotypeImagePath;
			}

			// 2. Find mod's logotype image in mod's home directory.

			string srcLogoImageDirectoryPath = Path.Combine(modificationURI, GameProvider_M2TW.MOD_ROOT, GameProvider_M2TW.MOD_NODE1_MENU);
			string srcLogoImageFileName = GameProvider_M2TW.MENU_IMAGE_LOGO;

			if (Directory.Exists(srcLogoImageDirectoryPath) && ContainsLogotypeImage(srcLogoImageDirectoryPath, srcLogoImageFileName))
			{
				string srcLogoImagePath = Path.Combine(srcLogoImageDirectoryPath, srcLogoImageFileName);

				if (!ContainsLogotypeImage(CacheDirectory, cachedLogotypeImageFileName))
				{
					ImageConverter.ConvertTgaToPng(srcLogoImagePath, cachedLogotypeImagePath);
				}
			}
			else
			{
				// 3. Load mod's logotype image from app's support folder.

				try
				{
					if (ShortName.Equals(GameProvider_M2TW.M2TWK_FOLDERNAME_MOD1))
					{
						srcLogoImageFileName = AppGameSupportManager.M2TWK_MOD1_LOGO_FILENAME;
					}

					if (ShortName.Equals(GameProvider_M2TW.M2TWK_FOLDERNAME_MOD2))
					{
						srcLogoImageFileName = AppGameSupportManager.M2TWK_MOD2_LOGO_FILENAME;
					}

					if (ShortName.Equals(GameProvider_M2TW.M2TWK_FOLDERNAME_MOD3))
					{
						srcLogoImageFileName = AppGameSupportManager.M2TWK_MOD3_LOGO_FILENAME;
					}

					if (ShortName.Equals(GameProvider_M2TW.M2TWK_FOLDERNAME_MOD4))
					{
						srcLogoImageFileName = AppGameSupportManager.M2TWK_MOD4_LOGO_FILENAME;
					}

					string srcLogoImagePath = Path.Combine(Program.AppSupportNode_M2TW_LOGO_DirectoryInfo.FullName, srcLogoImageFileName);
					ImageConverter.ConvertTgaToPng(srcLogoImagePath, cachedLogotypeImagePath);
				}
				catch (DirectoryNotFoundException)
				{
					cachedLogotypeImagePath = null;
				}
				catch (FileNotFoundException)
				{
					cachedLogotypeImagePath = null;
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
