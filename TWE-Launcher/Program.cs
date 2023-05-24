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
		internal static List<GuiLocale> CurrentGUILocales { get; set; }

		static Program()
		{
			CurrentGUIStyle = GuiStyle.Default;
			CurrentGUILocales = new List<GuiLocale>();
		}


		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			// 1. Prepare configuration settings before launching GUI.

			CurrentGUILocales = LocalizationManager.GetSupportedLocalizations();
			Settings.SynchronizeGameSetupSettings();


			// 2. Launch application GUI.

			Application.SetHighDpiMode(HighDpiMode.SystemAware);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainLauncherForm());
		}
	}
}
