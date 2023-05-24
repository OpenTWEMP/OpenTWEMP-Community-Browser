using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

using TWE_Launcher.Forms;
using TWE_Launcher.Sources.Models;
using TWE_Launcher.Sources.Models.Localizations;

namespace TWE_Launcher
{
	internal static class Program
	{
		internal static GuiStyle CurrentGUIStyle { get; set; }
		internal static List<GuiLocale> AvailableLocalizations { get; set; }
		internal static GuiLocale CurrentLocalization { get; set; }

		static Program()
		{
			// 1. Setup GUI style by default.

			CurrentGUIStyle = GuiStyle.Default;


			// 2. Setup GUI localization by default.

			AvailableLocalizations = LocalizationManager.GetSupportedLocalizations();
			InitializeLocalizationByDefault(AvailableLocalizations);
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
			// 1. Prepare configuration settings before launching GUI.

			Settings.SynchronizeGameSetupSettings();


			// 2. Launch application GUI.

			Application.SetHighDpiMode(HighDpiMode.SystemAware);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainLauncherForm());
		}
	}
}
