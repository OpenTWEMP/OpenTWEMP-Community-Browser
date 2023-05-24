using System.Collections.Generic;
using TWE_Launcher.Sources.Models.Localizations;

namespace TWE_Launcher.Forms.Localization
{
	public abstract class FormLocaleDescription
	{
		public abstract string FormName { get; }
		public abstract List<string> LocalizedControls { get; }

		public abstract FormLocaleSnapshot CreateLocaleSnapshotFor_ENG();
		public abstract FormLocaleSnapshot CreateLocaleSnapshotFor_RUS();
	}


	// Derived class for 'MainLauncherForm' form.

	public class GuiLocaleDescr_MainLauncher : FormLocaleDescription
	{
		public override string FormName { get; }
		public override List<string> LocalizedControls { get; }

		public GuiLocaleDescr_MainLauncher()
		{
			FormName = "MainLauncherForm";
			LocalizedControls = new List<string>();
		}

		public override FormLocaleSnapshot CreateLocaleSnapshotFor_ENG()
		{
			return new FormLocaleSnapshot(FormName, new Dictionary<string, string>()
				{
					{ "buttonLaunch", "LAUNCH" },
					{ "modQuickNavigationButton", "MOD QUICK NAVIGATION" },
					{ "buttonExplore", "MOD HOME FOLDER" },

					{ "appLocalizationGroupBox", "Select GUI language" },
					{ "enableEngLocaleRadioButton", "ENGLISH (by default)" },
					{ "enableRusLocaleRadioButton", "RUSSIAN (in progress)" },

					{ "groupBoxConfigCleanerMode", "Select mod clean routines" },
					{ "checkBoxCleaner_MapRWM", "Delete map.rwm file" },
					{ "checkBoxCleaner_textBIN", "Delete localization *strings.bin files" },
					{ "checkBoxCleaner_soundPacks", "Delete sound pack files (*.DAT + *.IDX)" },

					{ "groupBoxConfigLogMode", "Select a mode of creating system.log file" },
					{ "radioButtonLogOnlyError", "Only Errors" },
					{ "radioButtonLogOnlyTrace", "Only Trace" },
					{ "radioButtonLogErrorAndTrace", "Errors + Trace" },
					{ "checkBoxLogHistory", "Save game system.log files" },

					{ "groupBoxConfigLaunchMode", "Select game launch mode" },
					{ "radioButtonLaunchWindowScreen", "Windowed Mode" },
					{ "radioButtonLaunchFullScreen", "Full-Screen Mode" },
					{ "checkBoxVideo", "Enable Game Video" },
					{ "checkBoxBorderless", "Borderless Windowed Mode" }
				}
			); // test
		}

		public override FormLocaleSnapshot CreateLocaleSnapshotFor_RUS()
		{
			return new FormLocaleSnapshot(FormName, new Dictionary<string, string>()); // test
		}

	}



	// Derived class for 'ApplicationSettingsForm' form.

	public class GuiLocaleDescr_AppSettings : FormLocaleDescription
	{
		public override string FormName { get; }
		public override List<string> LocalizedControls { get; }

		public GuiLocaleDescr_AppSettings()
		{
			FormName = "ApplicationSettingsForm";
			LocalizedControls = new List<string>();
		}

		public override FormLocaleSnapshot CreateLocaleSnapshotFor_ENG()
		{
			return new FormLocaleSnapshot(FormName, new Dictionary<string, string>()
				{
					{ "appColorThemeGroupBox", "Select GUI style theme" },
					{ "uiStyleByDefaultThemeRadioButton", "Standard Theme (by default)" },
					{ "uiStyleByLightThemeRadioButton", "Light Theme" },
					{ "uiStyleByDarkThemeRadioButton", "Dark Theme" }
				}
			); // test
		}

		public override FormLocaleSnapshot CreateLocaleSnapshotFor_RUS()
		{
			return new FormLocaleSnapshot(FormName, new Dictionary<string, string>()); // test
		}
	}



	// Derived class for 'GameSetupConfigForm' form.

	public class GuiLocaleDescr_GameSetupConfig : FormLocaleDescription
	{
		public override string FormName { get; }
		public override List<string> LocalizedControls { get; }

		public GuiLocaleDescr_GameSetupConfig()
		{
			FormName = "GameSetupConfigForm";
			LocalizedControls = new List<string>();
		}

		public override FormLocaleSnapshot CreateLocaleSnapshotFor_ENG()
		{
			return new FormLocaleSnapshot(FormName, new Dictionary<string, string>()); // test
		}

		public override FormLocaleSnapshot CreateLocaleSnapshotFor_RUS()
		{
			return new FormLocaleSnapshot(FormName, new Dictionary<string, string>()); // test
		}
	}


	// Derived class for 'AddNewGameSetupForm' form.

	public class GuiLocaleDescr_AddNewGameSetup : FormLocaleDescription
	{
		public override string FormName { get; }
		public override List<string> LocalizedControls { get; }

		public GuiLocaleDescr_AddNewGameSetup()
		{
			FormName = "AddNewGameSetupForm";
			LocalizedControls = new List<string>();
		}

		public override FormLocaleSnapshot CreateLocaleSnapshotFor_ENG()
		{
			return new FormLocaleSnapshot(FormName, new Dictionary<string, string>()); // test
		}

		public override FormLocaleSnapshot CreateLocaleSnapshotFor_RUS()
		{
			return new FormLocaleSnapshot(FormName, new Dictionary<string, string>()); // test
		}
	}


	// Derived class for 'ModConfigSettingsForm' form.

	public class GuiLocaleDescr_ModConfigSettings : FormLocaleDescription
	{
		public override string FormName { get; }
		public override List<string> LocalizedControls { get; }

		public GuiLocaleDescr_ModConfigSettings()
		{
			FormName = "ModConfigSettingsForm";
			LocalizedControls = new List<string>();
		}

		public override FormLocaleSnapshot CreateLocaleSnapshotFor_ENG()
		{
			return new FormLocaleSnapshot(FormName, new Dictionary<string, string>()); // test
		}

		public override FormLocaleSnapshot CreateLocaleSnapshotFor_RUS()
		{
			return new FormLocaleSnapshot(FormName, new Dictionary<string, string>()); // test
		}
	}


	// Derived class for 'ModQuickNavigatorForm' form.

	public class GuiLocaleDescr_ModQuickNavigator : FormLocaleDescription
	{
		public override string FormName { get; }
		public override List<string> LocalizedControls { get; }

		public GuiLocaleDescr_ModQuickNavigator()
		{
			FormName = "ModQuickNavigatorForm";
			LocalizedControls = new List<string>();
		}

		public override FormLocaleSnapshot CreateLocaleSnapshotFor_ENG()
		{
			return new FormLocaleSnapshot(FormName, new Dictionary<string, string>()); // test
		}

		public override FormLocaleSnapshot CreateLocaleSnapshotFor_RUS()
		{
			return new FormLocaleSnapshot(FormName, new Dictionary<string, string>()); // test
		}
	}


	// Derived class for 'AboutProjectForm' form.

	public class GuiLocaleDescr_AboutProject : FormLocaleDescription
	{
		public override string FormName { get; }
		public override List<string> LocalizedControls { get; }


		public GuiLocaleDescr_AboutProject()
		{
			FormName = "AboutProjectForm";
			LocalizedControls = new List<string>();
		}

		public override FormLocaleSnapshot CreateLocaleSnapshotFor_ENG()
		{
			return new FormLocaleSnapshot(FormName, new Dictionary<string, string>()); // test
		}

		public override FormLocaleSnapshot CreateLocaleSnapshotFor_RUS()
		{
			return new FormLocaleSnapshot(FormName, new Dictionary<string, string>()); // test
		}
	}
}
