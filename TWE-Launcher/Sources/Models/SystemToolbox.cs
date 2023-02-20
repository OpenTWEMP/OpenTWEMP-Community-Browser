using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace TWE_Launcher.Models
{
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
			else
			{
				MessageBox.Show("ERROR: Specified directory does not exist.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
