using System;
using System.Windows.Forms;

using TWE_Launcher.Forms;

namespace TWE_Launcher
{
	internal static class Program
	{
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
