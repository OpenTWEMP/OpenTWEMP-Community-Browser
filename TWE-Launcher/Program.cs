using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using TWE_Launcher.Forms;

namespace TWE_Launcher
{
	internal static class Program
	{
		private const string APP_SUPPORT_NODE1_M2TW = "M2TWK";
		private const string APP_SUPPORT_NODE2_LOGO = "images";

		internal static readonly DirectoryInfo AppSupportNode_M2TW_LOGO_DirectoryInfo;


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
