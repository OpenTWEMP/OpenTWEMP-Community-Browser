// <copyright file="M2TWGameLauncher.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Launcher;

using System.Diagnostics;
using System.Text;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration;
using TWEMP.Browser.Core.CommonLibrary.GameLauncherFeatures;
using TWEMP.Browser.Core.CommonLibrary.Messaging;
using TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Automation;
using TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Frontend;

/// <summary>
/// Implements the game launcher agent for the "Medieval 2 Total War" game engine (M2TW).
/// </summary>
public class M2TWGameLauncher : IGameLauncherAgent
{
    public const string GameKingdomsExecutableBaseFileName = "kingdoms";
    public const string GameMedievalExecutableBaseFileName = "medieval2";

    private readonly M2TWGameConfigurator currentGameConfigurator;
    private readonly IBrowserMessageProvider currentMessageProvider;

    public M2TWGameLauncher(M2TWGameConfigurator gameConfigurator, IBrowserMessageProvider messageProvider)
    {
        this.currentGameConfigurator = gameConfigurator;
        this.currentMessageProvider = messageProvider;
    }

    public void Execute()
    {
        if (this.currentGameConfigurator.CurrentState.UseLauncherProvider_M2TWEOP)
        {
            this.Launch(this.currentGameConfigurator.CurrentInfo.CurrentPreset.LauncherProvider_M2TWEOP);
        }

        if (this.currentGameConfigurator.CurrentState.UseLauncherProvider_M2TWEOP_NativeSetup)
        {
            this.Launch(this.currentGameConfigurator.CurrentInfo.CurrentPreset.LauncherProvider_NativeSetup);
        }

        if (this.currentGameConfigurator.CurrentState.UseLauncherProvider_M2TWEOP_NativeBatch)
        {
            this.Launch(this.currentGameConfigurator.CurrentInfo.CurrentPreset.LauncherProvider_NativeBatch);
        }

        if (this.currentGameConfigurator.CurrentState.UseLauncherProvider_TWEMP)
        {
            this.Launch();
        }
    }

    private static bool IsModExecutionProcessFinished(int modExecutionProcessID)
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

    private static string GenerateModLogFilePath(string modLogsDirectoryPath)
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

    private void Launch(string filename)
    {
        string executableFilePath = Path.Combine(this.currentGameConfigurator.CurrentInfo.Location, filename);

        if (File.Exists(executableFilePath))
        {
            var modProcessInfo = new ProcessStartInfo();
            modProcessInfo.FileName = executableFilePath;
            modProcessInfo.WorkingDirectory = this.currentGameConfigurator.CurrentInfo.Location;

            var process = new Process();
            process.StartInfo = modProcessInfo;
            process.Start();
            process.WaitForExit();
        }
        else
        {
            this.currentMessageProvider.Show(
                msgText: "ERROR: Executable File Is Not Found !!!",
                msgCaption: "Error Message",
                msgType: BrowserMessageType.Error);
        }
    }

    private void Launch()
    {
        GameCfgSection[] configSettings = this.currentGameConfigurator.GetCurrentConfigSettings();
        string configurationFilePath = this.GenerateModConfigFile(configSettings);

        if (this.IsModificationReadyToExecution())
        {
            if (File.Exists(configurationFilePath))
            {
                var modExecutionProcess = new Process();
                modExecutionProcess.StartInfo = this.InitializeGameLaunch(configurationFilePath);
                string modExecutableBaseName = Path.GetFileNameWithoutExtension(this.currentGameConfigurator.CurrentInfo.CurrentSetup.ExecutableFileName) !;

                if (modExecutableBaseName.Equals(GameKingdomsExecutableBaseFileName))
                {
                    modExecutionProcess.Start();
                    modExecutionProcess.WaitForExit();
                    return;
                }

                if (modExecutableBaseName.Equals(GameMedievalExecutableBaseFileName))
                {
                    modExecutionProcess.Start();
                    Thread.Sleep(20_000); // 20 seconds

                    foreach (var process in Process.GetProcesses())
                    {
                        if (process.ProcessName.Equals(modExecutableBaseName))
                        {
                            process.WaitForExit();
                        }
                    }
                }

                this.ExecutePostProcessing(modExecutionProcess.Id);
            }
        }
        else
        {
            this.currentMessageProvider.Show(
                msgText: "ERROR: This mod does not pass preprocessing",
                msgCaption: "Error Message",
                msgType: BrowserMessageType.Error);
        }
    }

    private ProcessStartInfo InitializeGameLaunch(string mod_config_file)
    {
        ProcessStartInfo modProcessInfo = new ProcessStartInfo();

        modProcessInfo.WorkingDirectory = this.currentGameConfigurator.CurrentInfo.CurrentSetup.HomeDirectory;
        modProcessInfo.FileName = Path.Combine(
            this.currentGameConfigurator.CurrentInfo.CurrentSetup.HomeDirectory!, this.currentGameConfigurator.CurrentInfo.CurrentSetup.ExecutableFileName!);
        modProcessInfo.Arguments = this.currentGameConfigurator.CurrentInfo.ModArgRelativePath + Path.GetFileName(mod_config_file);

        return modProcessInfo;
    }

    private string GenerateModConfigFile(GameCfgSection[] gameConfigSections)
    {
        string cfgFileName = "twemp_game_config.cfg";
        string cfgFilePath = Path.Combine(this.currentGameConfigurator.CurrentInfo.Location, cfgFileName);

        var stream = new FileStream(cfgFilePath, FileMode.Create, FileAccess.ReadWrite);
        var writer = new StreamWriter(stream, Encoding.ASCII);

        foreach (GameCfgSection section in gameConfigSections)
        {
            string sectionConfigOptions = section.GetOutputConfigFormat();
            writer.WriteLine(sectionConfigOptions);
        }

        writer.Close();
        stream.Close();

        return cfgFilePath;
    }

    private bool IsModificationReadyToExecution()
    {
        bool[] preProcessingFlags = this.ExecuteModPreProcessing();

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
            this.currentGameConfigurator.CurrentState.IsShouldBeDeleted_MapRWM ?
                GameConfigRoutines.DeleteMapFile(this.currentGameConfigurator.CurrentInfo, this.currentMessageProvider) : skippedOperationStatus;

        bool areStringsBinFilesSuccessfullyPreprocessed =
            this.currentGameConfigurator.CurrentState.IsShouldBeDeleted_TextBin ?
                GameConfigRoutines.DeleteStringsBinFiles(this.currentGameConfigurator.CurrentInfo, this.currentMessageProvider) : skippedOperationStatus;

        bool areSoundPackFilesSuccessfullyPreprocessed =
            this.currentGameConfigurator.CurrentState.IsShouldBeDeleted_SoundPacks ?
                GameConfigRoutines.DeleteSoundPackFiles(this.currentGameConfigurator.CurrentInfo, this.currentMessageProvider) : skippedOperationStatus;

        preProcessingFlags[0] = isMapFileSuccessfullyProcessed;
        preProcessingFlags[1] = areStringsBinFilesSuccessfullyPreprocessed;
        preProcessingFlags[2] = areSoundPackFilesSuccessfullyPreprocessed;

        return preProcessingFlags;
    }

    private void ExecutePostProcessing(int modExecutionProcessID)
    {
        if (IsModExecutionProcessFinished(modExecutionProcessID))
        {
            if (this.currentGameConfigurator.CurrentState.EnabledLogsHistorySaving)
            {
                this.SaveModLogFile();
            }
        }
    }

    private void SaveModLogFile()
    {
        string modLogFilePath = Path.Combine(this.currentGameConfigurator.CurrentInfo.Location, this.currentGameConfigurator.CurrentInfo.LogFileName);

        if (File.Exists(modLogFilePath))
        {
            string modLogsDirectory = this.GetModLogsDirectory();

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
        return Path.Combine(this.currentGameConfigurator.CurrentInfo.Location, "twe-mod-logs");
    }
}
