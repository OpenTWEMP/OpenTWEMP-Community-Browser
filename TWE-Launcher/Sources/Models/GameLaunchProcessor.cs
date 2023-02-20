using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace TWE_Launcher.Models
{
	public class GameLaunchProcessor
	{
		private GameModificationInfo current_modification;
		private CustomConfigState config_state;

		public GameLaunchProcessor(GameModificationInfo mod_info, CustomConfigState state)
		{
			current_modification = mod_info;
			config_state = state;
		}

		public bool IsModificationReadyToExecution()
		{
			bool[] preProcessingFlags = ExecuteModPreProcessing();

			// Preprocessing has success only when all flags are 'true'.

			foreach (var flag in preProcessingFlags)
			{
				if (flag == false)
				{
					return false;
				}
			}

			return true;
		}

		private bool[] ExecuteModPreProcessing()
		{
			const int operationsCount = 3;
			var preProcessingFlags = new bool[operationsCount];

			// The flag can assign 'true' value because of preprocessing might be skipped by a user.
			const bool skippedOperationStatus = true;

			bool isMapFileSuccessfullyProcessed = 
				(config_state.IsShouldBeDeleted_MapRWM) ? DeleteMapFile() : skippedOperationStatus;

			bool areStringsBinFilesSuccessfullyPreprocessed =
				(config_state.IsShouldBeDeleted_TextBin) ? DeleteStringsBinFiles() : skippedOperationStatus;

			bool areSoundPackFilesSuccessfullyPreprocessed =
				(config_state.IsShouldBeDeleted_SoundPacks) ? DeleteSoundPackFiles() : skippedOperationStatus;

			preProcessingFlags[0] = isMapFileSuccessfullyProcessed;
			preProcessingFlags[1] = areStringsBinFilesSuccessfullyPreprocessed;
			preProcessingFlags[2] = areSoundPackFilesSuccessfullyPreprocessed;

			return preProcessingFlags;
		}


		private bool DeleteMapFile()
		{
			bool hasOperationSuccessExecutionStatus = false;

			string mapFileName = "map.rwm";
			string mapRelativePath = "data\\world\\maps\\base\\";

			string mapFullPath = Path.Combine(current_modification.Location, mapRelativePath, mapFileName);

			if (File.Exists(mapFullPath))
			{
				File.Delete(mapFullPath);
				hasOperationSuccessExecutionStatus = true;
			}
			else
			{
				MessageBox.Show("ERROR: map.rwm does not exist", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			return hasOperationSuccessExecutionStatus;
		}

		private bool DeleteStringsBinFiles()
		{
			bool hasOperationSuccessExecutionStatus = false;

			string stringsBinFileExtension = ".strings.bin";
			string textFilesRelativePath = "data\\text";
			string textFilesFullPath = Path.Combine(current_modification.Location, textFilesRelativePath);

			if (Directory.Exists(textFilesFullPath))
			{
				string[] detectedFiles = Directory.GetFiles(textFilesFullPath);

				for (int i = 0; i < detectedFiles.Length; i++)
				{
					if (detectedFiles[i].EndsWith(stringsBinFileExtension))
					{
						File.Delete(detectedFiles[i]);
					}
				}

				hasOperationSuccessExecutionStatus = true;
			}
			else
			{
				MessageBox.Show("ERROR: *.strings.bin files' directory is not found", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			return hasOperationSuccessExecutionStatus;
		}

		private bool DeleteSoundPackFiles()
		{
			bool hasOperationSuccessExecutionStatus = false;

			string soundPacksRelativePath = "data\\sounds";
			string soundPacksFullPath = Path.Combine(current_modification.Location, soundPacksRelativePath);

			if (Directory.Exists(soundPacksFullPath))
			{
				string[] soundPacksFiles = Directory.GetFiles(soundPacksFullPath);

				for (int i = 0; i < soundPacksFiles.Length; i++)
				{
					string pack_file = soundPacksFiles[i];

					if (IsBinDatPack(pack_file) || IsBinIdxPack(pack_file))
					{
						File.Delete(pack_file);
					}
				}

				hasOperationSuccessExecutionStatus = true;
			}
			else
			{
				MessageBox.Show("ERROR: *.dat и *.idx files' directory is not found", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			return hasOperationSuccessExecutionStatus;
		}

		private bool IsBinDatPack(string filename)
		{
			string binDatFileExtension = ".dat";

			if (filename.EndsWith(binDatFileExtension))
			{
				return true;
			}

			return false;
		}

		private bool IsBinIdxPack(string filename)
		{
			string binIdxFileExtension = ".idx";

			if (filename.EndsWith(binIdxFileExtension))
			{
				return true;
			}

			return false;
		}


		public void ExecutePostProcessing(int modExecutionProcessID)
		{
			if (IsModExecutionProcessFinished(modExecutionProcessID))
			{
				if (config_state.EnabledLogsHistorySaving)
				{
					SaveModLogFile();
				}
			}
		}

		private bool IsModExecutionProcessFinished(int modExecutionProcessID)
		{
			Process[] currentProcesses = Process.GetProcesses();

			foreach (var process in currentProcesses)
			{
				if (process.Id == modExecutionProcessID)
				{
					return false;
				}
			}

			return true;
		}

		private void SaveModLogFile()
		{
			string modLogFilePath = Path.Combine(current_modification.Location, current_modification.LogFileName);

			if (File.Exists(modLogFilePath))
			{
				string modLogsDirectory = GetModLogsDirectory();

				if (!Directory.Exists(modLogsDirectory))
				{
					Directory.CreateDirectory(modLogsDirectory);
				}

				string savedModLogFilePath = GenerateModLogFilePath(modLogsDirectory);
				File.Copy(modLogFilePath, savedModLogFilePath);
			}
		}

		private string GetModLogsDirectory()
		{
			return Path.Combine(current_modification.Location, "twe-mod-logs");
		}

		private string GenerateModLogFilePath(string modLogsDirectoryPath)
		{
			string dt_year = DateTime.Now.Year.ToString();
			string dt_month = DateTime.Now.Month.ToString();
			string dt_day = DateTime.Now.Day.ToString();
			string dt_hour = DateTime.Now.Hour.ToString();
			string dt_min = DateTime.Now.Minute.ToString();
			string dt_sec = DateTime.Now.Second.ToString();

			string modLogDateTime = 
				" [ " +
					dt_year + "." + dt_month + "." + dt_day
					+ " " +
					dt_hour + "-" + dt_min + "-" + dt_sec
				+ " ]";

			string cfgFileNamePrefix = "twe-mod-log";
			string cfgFileExtension = ".log";

			string modLogFileName = cfgFileNamePrefix + modLogDateTime + cfgFileExtension;

			return Path.Combine(modLogsDirectoryPath, modLogFileName);
		}
	}
}