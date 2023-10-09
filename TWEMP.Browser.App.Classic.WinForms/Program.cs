namespace TWEMP.Browser.App.Classic.WinForms;

using TWEMP.Browser.Core.CommonLibrary;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
		// Prepare configuration settings before launching GUI.
		Settings.SynchronizeGameSetupSettings();

        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new MainBrowserForm());
    }
}
