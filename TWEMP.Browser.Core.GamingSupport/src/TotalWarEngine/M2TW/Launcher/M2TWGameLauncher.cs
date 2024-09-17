// <copyright file="M2TWGameLauncher.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Launcher;

using System.Diagnostics;
using System.Text;
using TWEMP.Browser.Core.CommonLibrary;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration;
using TWEMP.Browser.Core.CommonLibrary.GameLauncherFeatures;
using TWEMP.Browser.Core.CommonLibrary.Messaging;
using TWEMP.Browser.Core.GamingSupport;
using TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Automation;
using TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Frontend;

/// <summary>
/// Implements the game launcher agent for the "Medieval 2 Total War" game engine (M2TW).
/// </summary>
public class M2TWGameLauncher : IGameLauncherAgent
{
    private readonly GameModificationInfo currentGameMod;
    private readonly CustomConfigState currentCfgState;
    private readonly IBrowserMessageProvider currentMessageProvider;

    private readonly M2TWGameConfigurator gameConfigurator;

    public M2TWGameLauncher(
        GameModificationInfo mod_info, CustomConfigState state, IBrowserMessageProvider messageProvider)
    {
        this.currentGameMod = mod_info;
        this.currentCfgState = state;
        this.currentMessageProvider = messageProvider;

        this.gameConfigurator = new M2TWGameConfigurator(this.currentGameMod);
    }

    public void Execute()
    {
        if (this.currentCfgState.UseLauncherProvider_M2TWEOP)
        {
            this.Launch(this.currentGameMod.CurrentPreset.LauncherProvider_M2TWEOP);
        }

        if (this.currentCfgState.UseLauncherProvider_M2TWEOP_NativeSetup)
        {
            this.Launch(this.currentGameMod.CurrentPreset.LauncherProvider_NativeSetup);
        }

        if (this.currentCfgState.UseLauncherProvider_M2TWEOP_NativeBatch)
        {
            this.Launch(this.currentGameMod.CurrentPreset.LauncherProvider_NativeBatch);
        }

        if (this.currentCfgState.UseLauncherProvider_TWEMP)
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
        string executableFilePath = Path.Combine(this.currentGameMod.Location, filename);

        if (File.Exists(executableFilePath))
        {
            var modProcessInfo = new ProcessStartInfo();
            modProcessInfo.FileName = executableFilePath;
            modProcessInfo.WorkingDirectory = this.currentGameMod.Location;

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
        List<CfgOptionsSubSet> mod_settings = this.gameConfigurator.InitializeMinimalModSettings(this.currentCfgState);

        string mod_config = this.GenerateModConfigFile(mod_settings);

        if (this.IsModificationReadyToExecution())
        {
            if (File.Exists(mod_config))
            {
                var modExecutionProcess = new Process();
                modExecutionProcess.StartInfo = this.InitializeGameLaunch(mod_config);
                string modExecutableBaseName = Path.GetFileNameWithoutExtension(this.currentGameMod.CurrentSetup.ExecutableFileName) !;

                if (modExecutableBaseName.Equals(TotalWarEngineSupportProvider.GAME_EXECUTABLE_BASENAME_CLASSIC2))
                {
                    modExecutionProcess.Start();
                    modExecutionProcess.WaitForExit();
                    return;
                }

                if (modExecutableBaseName.Equals(TotalWarEngineSupportProvider.GAME_EXECUTABLE_BASENAME_STEAM))
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

        modProcessInfo.WorkingDirectory = this.currentGameMod.CurrentSetup.HomeDirectory;
        modProcessInfo.FileName = Path.Combine(this.currentGameMod.CurrentSetup.HomeDirectory!, this.currentGameMod.CurrentSetup.ExecutableFileName!);
        modProcessInfo.Arguments = this.currentGameMod.ModArgRelativePath + Path.GetFileName(mod_config_file);

        return modProcessInfo;
    }

    private string GenerateModConfigFile(List<CfgOptionsSubSet> option_subsets)
    {
        string cfgFileName = "TWE_MOD_CFG.cfg";
        string cfgFilePath = Path.Combine(this.currentGameMod.Location, cfgFileName);

        var stream = new FileStream(cfgFilePath, FileMode.Create, FileAccess.ReadWrite);
        var writer = new StreamWriter(stream, Encoding.ASCII);

        foreach (CfgOptionsSubSet option_subset in option_subsets)
        {
            writer.WriteLine(option_subset.FormatToCfg());
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
            this.currentCfgState.IsShouldBeDeleted_MapRWM ?
                GameConfigRoutines.DeleteMapFile(this.currentGameMod, this.currentMessageProvider) : skippedOperationStatus;

        bool areStringsBinFilesSuccessfullyPreprocessed =
            this.currentCfgState.IsShouldBeDeleted_TextBin ?
                GameConfigRoutines.DeleteStringsBinFiles(this.currentGameMod, this.currentMessageProvider) : skippedOperationStatus;

        bool areSoundPackFilesSuccessfullyPreprocessed =
            this.currentCfgState.IsShouldBeDeleted_SoundPacks ?
                GameConfigRoutines.DeleteSoundPackFiles(this.currentGameMod, this.currentMessageProvider) : skippedOperationStatus;

        preProcessingFlags[0] = isMapFileSuccessfullyProcessed;
        preProcessingFlags[1] = areStringsBinFilesSuccessfullyPreprocessed;
        preProcessingFlags[2] = areSoundPackFilesSuccessfullyPreprocessed;

        return preProcessingFlags;
    }

    private void ExecutePostProcessing(int modExecutionProcessID)
    {
        if (IsModExecutionProcessFinished(modExecutionProcessID))
        {
            if (this.currentCfgState.EnabledLogsHistorySaving)
            {
                this.SaveModLogFile();
            }
        }
    }

    private void SaveModLogFile()
    {
        string modLogFilePath = Path.Combine(this.currentGameMod.Location, this.currentGameMod.LogFileName);

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
        return Path.Combine(this.currentGameMod.Location, "twe-mod-logs");
    }
}
