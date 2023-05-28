#define FUTURE_SUPPORT
#undef FUTURE_SUPPORT

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace TWE_Launcher.Models
{
	public class CustomModSupportPreset
	{
		public const string MOD_PRESET_FOLDERNAME = ".twemp";
		private const string MOD_PRESET_FILENAME = "mod_support.json";

		private const string MOD_TITLE = "My_Title";
		private const string MOD_VERSION = "My_Version";
		private const string LOGOTYPE_IMAGE = "DEFAULT.png";

		private const string LAUNCHER_PROVIDER_NATIVE_BATCH = "My_Batch_Script.bat";
		private const string LAUNCHER_PROVIDER_NATIVE_SETUP = "My_Setup_Program.exe";
		private const string LAUNCHER_PROVIDER_M2TWEOP = "M2TWEOP GUI.exe";

		public string ModTitle { get; set; }
		public string ModVersion { get; set; }
		public string LogotypeImage { get; set; }

		public string LauncherProvider_NativeBatch { get; set; }
		public string LauncherProvider_NativeSetup { get; set; }
		public string LauncherProvider_M2TWEOP { get; set; }

#if FUTURE_SUPPORT
		private const string BACKGROUND_SOUNDTRACK = "My_Background_SoundTrack.mp3";

		public string BackgroundSoundTrack { get; set; }

		public Dictionary<string, string> ModURLs { get; set; }
#endif

		public CustomModSupportPreset()
		{
			ModTitle = MOD_TITLE;
			ModVersion = MOD_VERSION;
			LogotypeImage = LOGOTYPE_IMAGE;

			LauncherProvider_NativeBatch = LAUNCHER_PROVIDER_NATIVE_BATCH;
			LauncherProvider_NativeSetup = LAUNCHER_PROVIDER_NATIVE_SETUP;
			LauncherProvider_M2TWEOP = LAUNCHER_PROVIDER_M2TWEOP;

#if FUTURE_SUPPORT
			BackgroundSoundTrack = BACKGROUND_SOUNDTRACK;

			ModURLs = new Dictionary<string, string>()
			{
				{ "URL1", "file://my-example-url1.mod/" },
				{ "URL2", "file://my-example-url2.mod" },
				{ "URL3", "file://my-example-url3.mod" },
			};
#endif
		}

		public static CustomModSupportPreset CreatePresetByDefault(string modificationURI)
		{
			// 1. Prepare preset's folder into modification's home directory.

			string presetHomeDirectoryPath = Path.Combine(modificationURI, MOD_PRESET_FOLDERNAME);

			if (!Directory.Exists(presetHomeDirectoryPath))
			{
				Directory.CreateDirectory(presetHomeDirectoryPath);
			}


			// 2. Prepare default assets for the default preset.

			// 2.1. Add mod's logotype image by default.

			string supportAssetsDirectoryPath = Program.AppSupportDirectoryInfo.FullName;

			string srcLogoImageFilePath = Path.Combine(supportAssetsDirectoryPath, AppGameSupportManager.M2TWK_DEFAULT_LOGO_FILENAME);
			string destLogoImageFilePath = Path.Combine(presetHomeDirectoryPath, AppGameSupportManager.M2TWK_DEFAULT_LOGO_FILENAME);

			if (File.Exists(srcLogoImageFilePath))
			{
				File.Copy(srcLogoImageFilePath, destLogoImageFilePath);
			}


			// 3. Generate 'mod_support.json' preset configuration file.

			var presetByDefault = new CustomModSupportPreset();
			string presetJsonText = JsonConvert.SerializeObject(presetByDefault, Formatting.Indented);
			string presetFilePath = Path.Combine(presetHomeDirectoryPath, MOD_PRESET_FILENAME);

			File.WriteAllText(presetFilePath, presetJsonText);

			return presetByDefault;
		}

		public static bool Exists(string modificationURI)
		{
			return File.Exists(Path.Combine(modificationURI, MOD_PRESET_FOLDERNAME, MOD_PRESET_FILENAME));
		}

		public static CustomModSupportPreset ReadExistingPreset(string modificationURI)
		{
			string modPresetFilePath = Path.Combine(modificationURI, MOD_PRESET_FOLDERNAME, MOD_PRESET_FILENAME);
			string presetJsonText = File.ReadAllText(modPresetFilePath);
			return JsonConvert.DeserializeObject<CustomModSupportPreset>(presetJsonText);
		}


		public static string GetPresetFilePath(string modificationURI)
		{
			return Path.Combine(modificationURI, MOD_PRESET_FOLDERNAME, MOD_PRESET_FILENAME);
		}
	}
}
