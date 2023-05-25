using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace TWE_Launcher.Models
{
	public class CustomModSupportPreset
	{
		private const string MOD_PRESET_FOLDERNAME = ".twemp";
		private const string MOD_PRESET_FILENAME = "mod_support.json";

		private const string MOD_TITLE = "My_Mod_Title";
		private const string MOD_VERSION = "My_Mod_Version";
		private const string LOGOTYPE_IMAGE = "My_Logotype_Image.png";
		private const string BACKGROUND_SOUNDTRACK = "My_Background_SoundTrack.mp3";
		private const string LAUNCHER_PROVIDER_M2TWEOP = "M2TWEOP GUI.exe";
		private const string LAUNCHER_PROVIDER_NATIVE_SETUP = "My_Setup_Program.exe";
		private const string LAUNCHER_PROVIDER_NATIVE_BATCH = "My_Batch_Script.bat";

		public string ModTitle { get; set; }
		public string ModVersion { get; set; }
		public string LogotypeImage { get; set; }
		public string BackgroundSoundTrack { get; set; }
		public string LauncherProvider_M2TWEOP { get; set; }
		public string LauncherProvider_NativeSetup { get; set; }
		public string LauncherProvider_NativeBatch { get; set; }
		public Dictionary<string, string> ModURLs { get; }

		public CustomModSupportPreset()
		{
			ModTitle = MOD_TITLE;
			ModVersion = MOD_VERSION;

			LogotypeImage = LOGOTYPE_IMAGE;
			BackgroundSoundTrack = BACKGROUND_SOUNDTRACK;

			LauncherProvider_M2TWEOP = LAUNCHER_PROVIDER_M2TWEOP;
			LauncherProvider_NativeSetup = LAUNCHER_PROVIDER_NATIVE_SETUP;
			LauncherProvider_NativeBatch = LAUNCHER_PROVIDER_NATIVE_BATCH;

			ModURLs = new Dictionary<string, string>()
			{
				{ "URL1", "file://my-example-url1.mod/" },
				{ "URL2", "file://my-example-url2.mod" },
				{ "URL3", "file://my-example-url3.mod" },
			};
		}

		public void CreatePresetByDefault(string modificationURI)
		{
			string presetFilePath = Path.Combine(modificationURI, MOD_PRESET_FOLDERNAME, MOD_PRESET_FILENAME);
			string presetJsonText = JsonConvert.SerializeObject(this, Formatting.Indented);
			File.WriteAllText(presetFilePath, presetJsonText);
		}

		public static string GetPresetDirectoryPath(string modificationURI)
		{
			return Path.Combine(modificationURI, MOD_PRESET_FOLDERNAME);
		}

		public static string GetPresetFilePath(string modificationURI)
		{
			return Path.Combine(modificationURI, MOD_PRESET_FOLDERNAME, MOD_PRESET_FILENAME);
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
	}
}
