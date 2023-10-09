using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

using TWE_Launcher.Forms;
using TWE_Launcher.Sources.Models;
using TWE_Launcher.Sources.Models.Localizations;

namespace TWE_Launcher
{
	internal static class Program
	{
		private const string APP_SUPPORT_NODE1_M2TW = "M2TWK";
		private const string APP_SUPPORT_NODE2_LOGO = "images";

		internal static readonly DirectoryInfo AppSupportNode_M2TW_LOGO_DirectoryInfo;

		internal static GuiStyle CurrentGUIStyle { get; set; }
		internal static List<GuiLocale> AvailableLocalizations { get; set; }
		internal static GuiLocale CurrentLocalization { get; set; }

		internal static bool UseExperimentalFeatures { get; set; }


		static Program()
		{

#if DISABLE_WHEN_MIGRATION
			// 0. Initialize app's file system.
			if (!Settings.AppSupportDirectoryInfo.Exists)
			{
				Settings.AppSupportDirectoryInfo.Create();
			}

			string appSupportNode_M2TW_LOGO_DirectoryPath = Path.Combine(appSupportDirectoryPath, APP_SUPPORT_NODE1_M2TW, APP_SUPPORT_NODE2_LOGO);
			AppSupportNode_M2TW_LOGO_DirectoryInfo = new DirectoryInfo(appSupportNode_M2TW_LOGO_DirectoryPath);

			if (!AppSupportNode_M2TW_LOGO_DirectoryInfo.Exists)
			{
				AppSupportNode_M2TW_LOGO_DirectoryInfo.Create();
			}
#endif

            // 1. Setup GUI style by default.
            CurrentGUIStyle = GuiStyle.Default;


			// 2. Setup GUI localization by default.
			AvailableLocalizations = LocalizationManager.GetSupportedLocalizations();
			InitializeLocalizationByDefault(AvailableLocalizations);

			// 3. Initialize extra flags by default.

			UseExperimentalFeatures = true;

		}

		private static void InitializeLocalizationByDefault(List<GuiLocale> guiLocales)
		{
			string guiLocaleNameByDefault = "ENG";
			
			foreach (var localization in AvailableLocalizations)
			{
				if (localization.Name == guiLocaleNameByDefault)
				{
					CurrentLocalization = localization;
					break;
				}
			}
		}

		internal static void SetCurrentLocalizationByName(string guiLocaleName)
		{
			if (CurrentLocalization.Name != guiLocaleName)
			{
				foreach (var localization in AvailableLocalizations)
				{
					if (localization.Name == guiLocaleName)
					{
						CurrentLocalization = localization;
						break;
					}
				}
			}
		}


		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
#if DISABLE_WHEN_MIGRATION
			// 1. Prepare configuration settings before launching GUI.
			Settings.SynchronizeGameSetupSettings();
#endif

			// 2. Launch application GUI.
			Application.SetHighDpiMode(HighDpiMode.SystemAware);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainLauncherForm());
		}
	}
}
