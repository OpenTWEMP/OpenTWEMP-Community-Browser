namespace TWEMP.Browser.Core.CommonLibrary;

using System.Diagnostics;

public static class SystemToolbox
{
    public static void ShowFileSystemDirectory(string directory)
    {
        if (Directory.Exists(directory))
        {
            var explorerProcInfo = new ProcessStartInfo();

            string execFileName = "explorer.exe"; // Windows Explorer
            explorerProcInfo.FileName = execFileName;
            explorerProcInfo.Arguments = directory;

            Process.Start(explorerProcInfo);
        }
#if DISABLE_WHEN_MIGRATION
        else
        {
            // TODO: Replace to TWEMP.Browser.App.Classic.CommonLibrary.BrowserErrorMessage.ShowAboutDirectoryNotFound()
            MessageBox.Show("ERROR: Specified directory does not exist.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
#endif
    }
}
