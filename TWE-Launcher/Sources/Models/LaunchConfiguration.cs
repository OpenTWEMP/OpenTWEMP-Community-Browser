using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

using TWE_Launcher.Models.GamesSupport;

namespace TWE_Launcher.Models
{
	public struct CfgOption
	{
		private string name;
		private object value;

		public CfgOption(string option_name, object option_value)
		{
			name = option_name;
			value = option_value;
		}

		public string ToConfigFormat()
		{
			return (name + " = " + value.ToString());
		}
	}


	public struct CfgOptionsSubSet
	{
		private string name;
		private List<CfgOption> options;

		public CfgOptionsSubSet(string subset_name, List<CfgOption> config_options)
		{
			name = subset_name;
			options = config_options;
		}

		public string FormatToCfg()
		{
			string optionsSubSet;

			optionsSubSet = FormatNameToCfg() + "\n";

			foreach (var option in options)
			{
				optionsSubSet += option.ToConfigFormat() + "\n";
			}

			return optionsSubSet;
		}

		private string FormatNameToCfg()
		{
			return ("[" + name + "]");
		}
	}


	public class LaunchConfiguration
	{
		private GameModificationInfo current_modification;
		private CustomConfigState custom_configuration;

		public LaunchConfiguration(GameModificationInfo mod_info, CustomConfigState state)
		{
			current_modification = mod_info;
			custom_configuration = state;
		}


		public void Execute()
		{
			if (custom_configuration.UseLauncherProvider_M2TWEOP)
			{
				Launch(current_modification.CurrentPreset.LauncherProvider_M2TWEOP);
			}

			if (custom_configuration.UseLauncherProvider_M2TWEOP_NativeSetup)
			{
				Launch(current_modification.CurrentPreset.LauncherProvider_NativeSetup);
			}

			if (custom_configuration.UseLauncherProvider_M2TWEOP_NativeBatch)
			{
				Launch(current_modification.CurrentPreset.LauncherProvider_NativeBatch);
			}

			if (custom_configuration.UseLauncherProvider_TWEMP)
			{
				Launch();
			}
		}

		private void Launch(string filename)
		{
			string executableFilePath = Path.Combine(current_modification.Location, filename);

			if (File.Exists(executableFilePath))
			{
				var modProcessInfo = new ProcessStartInfo();
				modProcessInfo.FileName = executableFilePath;
				modProcessInfo.WorkingDirectory = current_modification.Location;

				var process = new Process();
				process.StartInfo = modProcessInfo;
				process.Start();
				process.WaitForExit();
			}
			else
			{
				MessageBox.Show("ERROR: Executable File Is Not Found !!!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void Launch()
		{
			List<CfgOptionsSubSet> mod_settings = InitializeMinimalModSettings();
			string mod_config = GenerateModConfigFile(mod_settings);

			var gameLaunchProcessor = new GameLaunchProcessor(current_modification, custom_configuration);

			if (gameLaunchProcessor.IsModificationReadyToExecution())
			{
				if (File.Exists(mod_config))
				{
					var modExecutionProcess = new Process();
					modExecutionProcess.StartInfo = InitializeGameLaunch(mod_config);
					string modExecutableBaseName = Path.GetFileNameWithoutExtension(current_modification.CurrentSetup.ExecutableFileName);

					if (modExecutableBaseName.Equals(GameProvider_M2TW.GAME_EXECUTABLE_BASENAME_CLASSIC2))
					{
						modExecutionProcess.Start();
						modExecutionProcess.WaitForExit();
						return;
					}

					if (modExecutableBaseName.Equals(GameProvider_M2TW.GAME_EXECUTABLE_BASENAME_STEAM))
					{
						modExecutionProcess.Start();
						System.Threading.Thread.Sleep(20_000); // 20 seconds

						foreach (var process in Process.GetProcesses())
						{
							if (process.ProcessName.Equals(modExecutableBaseName))
							{
								process.WaitForExit();
							}
						}
					}
				}
			}
			else
			{
				MessageBox.Show("ERROR: This mod does not pass preprocessing", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private ProcessStartInfo InitializeGameLaunch(string mod_config_file)
		{
			ProcessStartInfo modProcessInfo = new ProcessStartInfo();

			modProcessInfo.WorkingDirectory = current_modification.CurrentSetup.HomeDirectory;
			modProcessInfo.FileName = Path.Combine(current_modification.CurrentSetup.HomeDirectory, current_modification.CurrentSetup.ExecutableFileName);
			modProcessInfo.Arguments = current_modification.ModArgRelativePath + Path.GetFileName(mod_config_file);

			return modProcessInfo;
		}


		private string GenerateModConfigFile(List<CfgOptionsSubSet> option_subsets)
		{
			string cfgFileName = "TWE_MOD_CFG.cfg";
			string cfgFilePath = Path.Combine(current_modification.Location, cfgFileName);

			var stream = new FileStream(cfgFilePath, FileMode.Create, FileAccess.ReadWrite);
			var writer = new StreamWriter(stream, Encoding.ASCII);

			foreach (CfgOptionsSubSet option_subset in option_subsets)
			{
				writer.WriteLine(option_subset.FormatToCfg());
			}

			writer.Close();
			stream.Close();

			return cfgFilePath;
		}

		private List<CfgOptionsSubSet> InitializeMinimalModSettings()
		{
			List<CfgOptionsSubSet> settings = new List<CfgOptionsSubSet>();

			// [features]
			CfgOptionsSubSet features_subset = GetFeaturesSubSet();
			settings.Add(features_subset);
			// [io]
			CfgOptionsSubSet io_subset = GetIOSubSet();
			settings.Add(io_subset);
			// [log]
			CfgOptionsSubSet log_subset = GetLogSubSet();
			settings.Add(log_subset);
			// [video]
			CfgOptionsSubSet video_subset = GetVideoSubSet();
			settings.Add(video_subset);

			return settings;
		}


		private CfgOptionsSubSet GetFeaturesSubSet()
		{
			string subsetName = "features";

			var subsetOptions = new List<CfgOption>();
			//subsetOptions.Add(new CfgOption("editor", true));
			subsetOptions.Add(new CfgOption("mod", current_modification.ModCfgRelativePath));

			return new CfgOptionsSubSet(subsetName, subsetOptions);
		}

		private CfgOptionsSubSet GetIOSubSet()
		{
			string subsetName = "io";

			var subsetOptions = new List<CfgOption>();
			subsetOptions.Add(new CfgOption("file_first", true));

			return new CfgOptionsSubSet(subsetName, subsetOptions);
		}

		private CfgOptionsSubSet GetLogSubSet()
		{
			string subsetName = "log";

			var subsetOptions = new List<CfgOption>();
			subsetOptions.Add(new CfgOption("to", current_modification.LogFileRelativePath));
			subsetOptions.Add(new CfgOption("level", SetLogLevel()));

			return new CfgOptionsSubSet(subsetName, subsetOptions);
		}

		private string SetLogLevel()
		{
			const string strLogLevelError = "* error";
			const string strLogLevelTrace = "* trace";
			const string strLogLevelScriptTrace = "*script* trace";

			string strLogLevel = string.Empty;

			if (custom_configuration.ValidatorLogLevel1)
			{
				strLogLevel = strLogLevelError;
			}

			if (custom_configuration.ValidatorLogLevel2)
			{
				strLogLevel = strLogLevelTrace;
			}

			if (custom_configuration.ValidatorLogLevel3)
			{
				strLogLevel = strLogLevelScriptTrace;
			}

			return strLogLevel;
		}

		private CfgOptionsSubSet GetVideoSubSet()
		{
			string subsetName = "video";
			var subsetOptions = new List<CfgOption>();
			subsetOptions.Add(new CfgOption("windowed", custom_configuration.IsEnabledWindowedMode));
			subsetOptions.Add(new CfgOption("movies", custom_configuration.ValidatorVideo));
			subsetOptions.Add(new CfgOption("borderless_window", custom_configuration.ValidatorBorderless));

			return new CfgOptionsSubSet(subsetName, subsetOptions);
		}



		public List<CfgOptionsSubSet> GetBaseOptsSet()
		{
			// todo

			return new List<CfgOptionsSubSet>();
		}

		public List<CfgOptionsSubSet> GetFullOptsSet()
		{
			// todo

			return new List<CfgOptionsSubSet>();
		}

		public CfgOptionsSubSet GenerateOptsSubSet(string subsetName, Dictionary<string, object> settings)
		{
			var subsetOptions = new List<CfgOption>();

			foreach (var setting in settings)
			{
				subsetOptions.Add(new CfgOption(setting.Key, setting.Value));
			}

			return new CfgOptionsSubSet(subsetName, subsetOptions);
		}

		private Dictionary<string, object> GenerateDefaultVideoSettings()
		{
			Dictionary<string, object> settings;

			settings = new Dictionary<string, object>()
			{
				{ "assassination_movies", false },
				{ "autodetect", false },
				{ "bloom", true },
				{ "borderless_window", false },
				{ "event_movies", true },
				{ "infiltration_movies", false },
				{ "movies", false },
				{ "no_background_fmv", true },
				{ "reflection", true },
				{ "sabotage_movies", false },
				{ "show_banners", false },
				{ "show_package_litter", true },
				{ "skip_mip_levels", false },
				{ "splashes", true },
				{ "stencil_shadows", true },
				{ "subtitles", false },
				{ "vegetation", false },
				{ "vsync", false },
				{ "widescreen", false },
				{ "windowed", false },
				{ "anti_alias_mode", "off" },
				{ "building_detail", "high" },
				{ "effect_quality", "highest" },
				{ "terrain_quality", "custom" },
				{ "unit_detail", "highest"},
				{ "vegetation_quality", "high"},
				{ "anisotropic_level", 16 },
				{ "antialiasing", 8 },
				{ "depth_shadows", 2 },
				{ "depth_shadows_resolution", 3 },
				{ "gamma", 122 },
				{ "grass_distance", 500 },
				{ "ground_buffers_per_node", 4 },
				{ "ground_cover_buffers_per_node", 4 },
				{ "model_buffers_per_node", 4 },
				{ "shader", 2 },
				{ "sprite_buffers_per_node", 4 },
				{ "texture_filtering", 2 },
				{ "water_buffers_per_node", 4 },
				{ "battle_resolution", new uint[] {1600, 900} },
				{ "campaign_resolution", new uint[] { 1600, 900 } }
			};

			return settings;
		}


		private CfgOptionsSubSet GetHotseatSubSet()
		{

			string subsetName = "hotseat";

			var subsetOptions = new List<CfgOption>();
			subsetOptions.Add(new CfgOption("scroll", false));
			subsetOptions.Add(new CfgOption("turns", false));
			subsetOptions.Add(new CfgOption("disable_console", false));
			subsetOptions.Add(new CfgOption("admin_password", "qwerty")); // resolve password !!!
			subsetOptions.Add(new CfgOption("update_ai_camera", true));
			subsetOptions.Add(new CfgOption("disable_papal_elections", false));
			subsetOptions.Add(new CfgOption("autoresolve_battles", false));
			subsetOptions.Add(new CfgOption("validate_diplomacy", false));
			subsetOptions.Add(new CfgOption("save_prefs", true));
			subsetOptions.Add(new CfgOption("autosave", true));
			subsetOptions.Add(new CfgOption("save_config", true));
			subsetOptions.Add(new CfgOption("close_after_save", true));
			subsetOptions.Add(new CfgOption("gamename", "hotseat_gamename"));
			subsetOptions.Add(new CfgOption("validate_data", true));
			subsetOptions.Add(new CfgOption("allow_validation_failures", false));

			return new CfgOptionsSubSet(subsetName, subsetOptions);
		}

		private CfgOptionsSubSet GetMultiplayerSubSet()
		{
			string subsetName = "multiplayer";

			var subsetOptions = new List<CfgOption>();
			subsetOptions.Add(new CfgOption("playable", true));

			return new CfgOptionsSubSet(subsetName, subsetOptions);
		}

		private CfgOptionsSubSet GetGameSubSet()
		{
			string subsetName = "game";

			var subsetOptions = new List<CfgOption>();
			subsetOptions.Add(new CfgOption("unlimited_men_on_battlefield", true));
			subsetOptions.Add(new CfgOption("unit_size", "huge"));
			subsetOptions.Add(new CfgOption("no_campaign_battle_time_limit", false));
			subsetOptions.Add(new CfgOption("advisor_verbosity", false));
			subsetOptions.Add(new CfgOption("event_cutscenes", false));

			return new CfgOptionsSubSet(subsetName, subsetOptions);
		}

		private Dictionary<string, bool> GenerateDefaultGameSettings()
		{
			return new Dictionary<string, bool>
			{
				{ "advanced_stats_always", true },
				{ "allusers", true },
				{ "auto_save", true },
				{ "blind_advisor", false },
				{ "disable_arrow_markers", false },
				{ "disable_events", false },
				{ "english", false },
				{ "event_cutscenes", true },
				{ "fatigue", true },
				{ "first_time_play", false },
				{ "gamespy_save_passwrd", true },
				{ "label_characters", false },
				{ "label_settlements", true },
				{ "micromanage_all_settlements", true },
				{ "morale", true },
				{ "mute_advisor", false },
				{ "no_campaign_battle_time_limit", false },
				{ "tutorial_battle_played", true },
				{ "use_quickchat", false }
			};
		}

		private CfgOptionsSubSet GetUISubSet()
		{
			string subsetName = "ui";
			Dictionary<string, object> settings = GenerateDefaultUISettings();

			return GenerateOptsSubSet(subsetName, settings);
		}

		private Dictionary<string, object> GenerateDefaultUISettings()
		{
			return new Dictionary<string, object>
			{
				{"full_battle_HUD", true },
				{"show_tooltips", true },
				{"buttons", "slide" },
				{"radar", "slide" },
				{"unit_cards", "slide" },
				{"SA_cards", "slide" }
			};
		}

		private CfgOptionsSubSet GetMiscSubSet()
		{
			string subsetName = "misc";

			var subsetOptions = new List<CfgOption>();
			subsetOptions.Add(new CfgOption("show_hud_date", true));
			subsetOptions.Add(new CfgOption("bypass_sprite_script", true));
			subsetOptions.Add(new CfgOption("bypass_to_strategy_save", "game_name.sav"));

			return new CfgOptionsSubSet(subsetName, subsetOptions);
		}
	}
}
