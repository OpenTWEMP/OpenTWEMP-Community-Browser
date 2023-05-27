#define LEGACY_LOGO_CACHING_IMPL
#undef LEGACY_LOGO_CACHING_IMPL

using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TWE_Launcher.Forms;

using TWE_Launcher.Models.GamesSupport;
using TWE_Launcher.Properties;

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
		//private string modLogotypeImage { get; }

		public CustomModSupportPreset CurrentPreset { get; }

		public bool IsFavoriteMod { get; set; }


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

#if LEGACY_LOGO_CACHING_IMPL
			modLogotypeImage = InitializeCachedLogotypeImage(Location);
#endif

			CurrentPreset = InitializeModificationPreset(modificationURI);

			IsFavoriteMod = false;
		}


		public bool CanBeLaunchedViaNativeBatch()
		{
			return File.Exists(Path.Combine(Location, CurrentPreset.LauncherProvider_NativeBatch));
		}

		public bool CanBeLaunchedViaNativeSetup()
		{
			return File.Exists(Path.Combine(Location, CurrentPreset.LauncherProvider_NativeSetup));
		}

		public bool CanBeLaunchedViaM2TWEOP()
		{
			return File.Exists(Path.Combine(Location, CurrentPreset.LauncherProvider_M2TWEOP));
		}


		public void ShowModVisitingCard(PictureBox modLogotypePictureBox, Label modStatusLabel)
		{
			const string modLogoErrorMsg = "Add your own logotype image to '.twemp' folder and replace default 'DEFAULT.png' value into 'mod_support.json'.";

			if (modLogotypePictureBox.Image != null)
			{
				modLogotypePictureBox.Image.Dispose();
				modLogotypePictureBox.Image = null;
			}


			string modPresetLogoImageFilePath = Path.Combine(Location, CustomModSupportPreset.MOD_PRESET_FOLDERNAME, CurrentPreset.LogotypeImage);

			if (File.Exists(modPresetLogoImageFilePath))
			{
				modLogotypePictureBox.Load(modPresetLogoImageFilePath);
				//modLogotypePictureBox.Visible = true;
				modStatusLabel.Text = Location;
			}

#if LEGACY_LOGO_CACHING_IMPL
			if (File.Exists(modLogotypeImage))
			{
				modLogotypePictureBox.Load(modLogotypeImage);
				modLogotypePictureBox.Visible = true;
				modStatusLabel.Text = Location;
			}
#endif
			else
			{
				//modLogotypePictureBox.Visible = true;
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


		private CustomModSupportPreset InitializeModificationPreset(string modificationURI)
		{
			if (CustomModSupportPreset.Exists(modificationURI))
			{
				return CustomModSupportPreset.ReadExistingPreset(modificationURI);
			}
			else
			{
				return CustomModSupportPreset.CreatePresetByDefault(modificationURI);
			}
		}

#if LEGACY_LOGO_CACHING_IMPL
		private string InitializeCachedLogotypeImage(string modificationURI)
		{
			string destLogoImageExtension = ".png";
			//string cachedLogotypeImageFileName = ShortName + destLogoImageExtension;
			string cachedLogotypeImageFileName = "SPLASH" + destLogoImageExtension;
			string cachedLogotypeImagePath = Path.Combine(CacheDirectory, cachedLogotypeImageFileName);

			// 1. Find mod's logotype image in app's cache directory.

			if (ContainsLogotypeImage(CacheDirectory, cachedLogotypeImageFileName))
			{
				return cachedLogotypeImagePath;
			}
			else
			{
				// 2. Find mod's logotype image in mod's home directory.

				string srcLogoImageDirectoryPath = Path.Combine(modificationURI, GameProvider_M2TW.MOD_ROOT, GameProvider_M2TW.MOD_NODE1_MENU);
				string srcLogoImageFileName = GameProvider_M2TW.MENU_IMAGE_LOGO;

				if (Directory.Exists(srcLogoImageDirectoryPath) && ContainsLogotypeImage(srcLogoImageDirectoryPath, srcLogoImageFileName))
				{
					try
					{
						ImageConverter.ConvertTgaToPng(Path.Combine(srcLogoImageDirectoryPath, srcLogoImageFileName), cachedLogotypeImagePath);
					}
					catch (System.Exception)
					{
						cachedLogotypeImagePath = Path.Combine(Program.AppSupportDirectoryInfo.FullName, AppGameSupportManager.M2TWK_DEFAULT_LOGO_FILENAME);
					}
				}
				else
				{
					// 3. Load mod's logotype image from app's support folder.
					try
					{
						if (ShortName.Equals(GameProvider_M2TW.M2TWK_FOLDERNAME_MOD1))
						{
							ImageConverter.ConvertTgaToPng(Path.Combine(Program.AppSupportNode_M2TW_LOGO_DirectoryInfo.FullName, AppGameSupportManager.M2TWK_MOD1_LOGO_FILENAME), cachedLogotypeImagePath);
							return cachedLogotypeImagePath;
						}

						if (ShortName.Equals(GameProvider_M2TW.M2TWK_FOLDERNAME_MOD2))
						{
							ImageConverter.ConvertTgaToPng(Path.Combine(Program.AppSupportNode_M2TW_LOGO_DirectoryInfo.FullName, AppGameSupportManager.M2TWK_MOD2_LOGO_FILENAME), cachedLogotypeImagePath);
							return cachedLogotypeImagePath;
						}

						if (ShortName.Equals(GameProvider_M2TW.M2TWK_FOLDERNAME_MOD3))
						{
							ImageConverter.ConvertTgaToPng(Path.Combine(Program.AppSupportNode_M2TW_LOGO_DirectoryInfo.FullName, AppGameSupportManager.M2TWK_MOD3_LOGO_FILENAME), cachedLogotypeImagePath);
							return cachedLogotypeImagePath;
						}

						if (ShortName.Equals(GameProvider_M2TW.M2TWK_FOLDERNAME_MOD4))
						{
							ImageConverter.ConvertTgaToPng(Path.Combine(Program.AppSupportNode_M2TW_LOGO_DirectoryInfo.FullName, AppGameSupportManager.M2TWK_MOD4_LOGO_FILENAME), cachedLogotypeImagePath);
							return cachedLogotypeImagePath;
						}
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
#endif
	}
}
